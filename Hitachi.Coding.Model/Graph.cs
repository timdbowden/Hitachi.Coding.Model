using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hitachi.Coding.Model
{
    public class Graph<T>
    {

        #region Private Variables

        private List<Node<T>> graphNodes;

        #endregion


        #region Properties

        public List<Node<T>> Nodes 
        { 
            get {return graphNodes;} 
            set {graphNodes = value;} 
        }


        #endregion

        #region Public Methods

        public Node<T> AddNode(T item)
        {

            Node<T> node = new Node<T>(item);
                 
            graphNodes.Add(node);
            return node; 
        }
              
        public double GetJourneyTime(T origin, params T[] nodes)
        {
            double dblReturn = 0;
            Node<T> nodStart = GetNodeFromData(origin);

            foreach (T item in nodes)
            {
                dblReturn += nodStart.GetJourneyTime(item);
                nodStart = GetNodeFromData(item);
            }   

            return dblReturn;

        }

        public Node<T> GetNodeFromData(T data)
        {
            foreach (Node<T> item in Nodes)
            {
                if (item.Data.Equals(data))
                {
                    return item;
                }
            }

            return null;
        }

        #endregion

        #region Constructor


        #endregion

        #region Overrides

        public override string ToString()
        {

            string strReturn = "";
            
            foreach (var item in Nodes)
            {
                strReturn += item.Data.ToString() + Environment.NewLine;

                foreach (var edge in item.Edges)
                {
                    strReturn += "-->" + edge.Destination.ToString() + " (" + edge.Weight.ToString() + ")" + Environment.NewLine;
                }

                strReturn += "--------------------------------------" + Environment.NewLine;
            }
            
            return strReturn;
        }

        #endregion
    }


    public class GraphException : Exception
    {

    }
}
