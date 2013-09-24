using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hitachi.Coding.Model
{
    /// <summary>
    /// A class representing a graph node
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {

        #region Private Variables

        private T nodeData;
        private List<T> neighbours;

        #endregion

        #region properties

        /// <summary>
        /// Name of  the node
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// List of edges to other nodes in the graph
        /// </summary>
        public List<Edge<T>> Edges { get; set; }

        /// <summary>
        /// Read only count of edges
        /// </summary>
        public int EdgeCount
        {
            get { return Edges.Count; }

        }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data contained in the node.</value>
        public T Data
        {
            get
            {
                return nodeData;
            }
            set
            {
                this.nodeData = value;
            }
        }
        #endregion

        #region Public Methods
        
        public Edge<T> AddEdge(T destination, double weight)
        {
            Edge<T> edge = new Edge<T>(Data, destination, weight);
            Edges.Add(edge);
            neighbours.Add(destination);
            return edge;
        }

        public double GetJourneyTime(T destination)
        {
            if (neighbours.Contains(destination))
            {
                foreach (Edge<T> item in Edges)
                {
                    if (item.Destination.Equals(destination))
                    {
                        return item.Weight;
                    }
                }
            }
            else
            {
                throw new Exception("Journey not valid");
                
            }

            return 0;
        }

        #endregion


        #region Constructors

        public Node(T data)
        {
            nodeData = data;
            Edges = new List<Edge<T>>();
            neighbours = new List<T>();
        }
        #endregion

    }
}
