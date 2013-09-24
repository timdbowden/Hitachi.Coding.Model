﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hitachi.Coding.Model;

namespace Hitachi.Coding.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<Port> graThis = new Graph<Port>();

            graThis.Nodes = new List<Node<Port>>();

            Port prtNY = new Port { Name = "New York" };
            Port prtLiverpool = new Port { Name = "Liverpool" };
            Port prtBA = new Port { Name = "Buenos Aires" };
            Port prtCT = new Port { Name = "Cape Town" };
            Port prtCasablanca = new Port { Name = "Casablanca" };

            Node<Port> nodThis = null;

            nodThis = graThis.AddNode(prtNY);
            nodThis.AddEdge(prtLiverpool, 4.0);

            nodThis = graThis.AddNode(prtLiverpool);
            nodThis.AddEdge(prtCasablanca, 3.0);
            nodThis.AddEdge(prtCT, 6.0);

            nodThis = graThis.AddNode(prtBA);
            nodThis.AddEdge(prtNY, 6.0);
            nodThis.AddEdge(prtCasablanca, 5.0);
            nodThis.AddEdge(prtCT, 4.0);

            nodThis = graThis.AddNode(prtCT);
            nodThis.AddEdge(prtNY, 8.0);

            nodThis = graThis.AddNode(prtCasablanca);
            nodThis.AddEdge(prtLiverpool, 3.0);
            nodThis.AddEdge(prtCT, 6.0);
            


            Console.WriteLine(graThis.ToString());
            Console.WriteLine("BA --> NY --> Liverpool: " + graThis.GetJourneyTime(prtBA, prtNY, prtLiverpool).ToString());
            Console.WriteLine("BA --> Casablanca --> Liverpool: " + graThis.GetJourneyTime(prtBA, prtCasablanca, prtLiverpool).ToString());
            Console.WriteLine("BA --> Cape Town --> NY --> Liverpool --> Casablanca: " + graThis.GetJourneyTime(prtBA, prtCT, prtNY, prtLiverpool, prtCasablanca).ToString());
            try
            {
                Console.WriteLine("BA --> Cape Town --> Casablanca: " + graThis.GetJourneyTime(prtBA, prtCT, prtCasablanca).ToString());
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
            }
            


            Console.ReadLine();
            

        }
    }
}
