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
              
        public double GetJourneyTime(params T[] nodes)
        {
            return 7.0;

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
