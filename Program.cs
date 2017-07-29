using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASD.Graphs;
using System.IO;

namespace ProgramsAlgorithms
{

    class Program
    {
        static void Main(string[] args)
        {
            DSatur DSAT = new DSatur();
            LargestFirst LF = new LargestFirst();
            SmallestLast SL = new SmallestLast();
            List<ColoringGraphs> methods = new List<ColoringGraphs> { DSAT, LF, SL };
            int i;
            int[] limitt = new int[14];   //{ 3, 12 , 9999999};
            for (i = 0; i < limitt.Length - 1; i++)
                limitt[i] = 2 + i;
            limitt[13] = 9999999;
            
            int GraphCount=100;   
            
            foreach(int limit in limitt)
            {
                string file_name = "results" + limit.ToString() + ".txt";

                /*

                File.AppendAllText(file_name, "drzewo test" + Environment.NewLine);
                Graph drzewo = new AdjacencyListsGraph<SimpleAdjacencyList>(false, 8) { new Edge(0, 1), new Edge(1, 2), new Edge(2, 3), new Edge(3, 4), new Edge(4, 5), new Edge(1, 6), new Edge(4, 7) };                            
                Graph[] drzew = new Graph[1];
                drzew[0] = drzewo;
                compareMethods(methods, drzew, limit);
                
                

                
                
                File.AppendAllText(file_name, "eulerians" + Environment.NewLine);
                Graph[] eulerians = new Graph[GraphCount];
                for (i = 0; i < GraphCount; i++)
                    eulerians[i] = RGG.eulerian();
                compareMethods(methods, eulerians, limit);              
                      
                File.AppendAllText(file_name, "semieulerians" + Environment.NewLine);
                Graph[] semieulerians = new Graph[GraphCount];
                for (i = 0; i < GraphCount; i++)
                    semieulerians[i] = RGG.semieulerian();
                compareMethods(methods, semieulerians, limit);
                */
                /*
                File.AppendAllText(file_name, "hamiltonians" + Environment.NewLine);
                Graph[] hamiltonians = new Graph[GraphCount];
                for (i = 0; i < GraphCount; i++)
                    hamiltonians[i] = RGG.hamiltonian();
                compareMethods(methods, hamiltonians, limit);
                Graph[] hypohamiltonians = new Graph[GraphCount];
                /*          
                File.AppendAllText(file_name, "randoms" + Environment.NewLine);
                Graph[] randoms = new Graph[GraphCount];
                for (i = 0; i < GraphCount; i++)
                    randoms[i] = RGG.random();
                compareMethods(methods, randoms, limit);
                */
                
                File.AppendAllText(file_name, "cycles" + Environment.NewLine);
                Graph[] cycles = new Graph[GraphCount];
                for (i = 0; i < GraphCount; i++)
                    cycles[i] = RGG.cycle();
                compareMethods(methods, cycles, limit);
                /*
                File.AppendAllText(file_name, "monocyclics" + Environment.NewLine);
                Graph[] monocyclics = new Graph[GraphCount];
                for (i = 0; i < GraphCount; i++)
                    monocyclics[i] = RGG.monocyclic();
                compareMethods(methods, monocyclics, limit);
                
                File.AppendAllText(file_name, "bicyclics" + Environment.NewLine);
                Graph[] bicyclics = new Graph[GraphCount];
                for (i = 0; i < GraphCount; i++)
                    bicyclics[i] = RGG.bicyclic();
                compareMethods(methods, bicyclics, limit);

                File.AppendAllText(file_name, "trees" + Environment.NewLine);
                Graph[] trees = new Graph[GraphCount];
                for (i = 0; i < GraphCount; i++)
                    trees[i] = RGG.tree();
                compareMethods(methods, trees, limit);

                File.AppendAllText(file_name, "2-trees" + Environment.NewLine);
                Graph[] twotrees = new Graph[GraphCount];
                for (i = 0; i < GraphCount; i++)
                    twotrees[i] = RGG.twotree();
                compareMethods(methods, twotrees, limit);

                File.AppendAllText(file_name, "web graphs" + Environment.NewLine);
                Graph[] webs = new Graph[GraphCount];
                for (i = 0; i < GraphCount; i++)
                    webs[i] = RGG.webGraph();
                compareMethods(methods, webs, limit);            
                
                File.AppendAllText(file_name, "helms" + Environment.NewLine);
                Graph[] helms = new Graph[GraphCount];
                for (i = 0; i < GraphCount; i++)
                    helms[i] = RGG.helm();
                compareMethods(methods, helms, limit);
                */
                /*
                File.AppendAllText(file_name, "closed helms" + Environment.NewLine);
                Graph[] closedHelms = new Graph[GraphCount];
                for (i = 0; i < GraphCount; i++)
                    closedHelms[i] = RGG.closedHelm();
                compareMethods(methods, closedHelms, limit);
                /*
                File.AppendAllText(file_name, "tree of polygons" + Environment.NewLine);
                Graph[] polygonTrees = new Graph[GraphCount];
                for (i = 0; i < GraphCount; i++)
                    polygonTrees[i] = RGG.treeOfPolygons();
                compareMethods(methods, polygonTrees, limit);                

                File.AppendAllText(file_name, "necklaces" + Environment.NewLine);
                Graph[] necklaces = new Graph[GraphCount];
                for (i = 0; i < GraphCount; i++)
                    necklaces[i] = RGG.necklace();
                compareMethods(methods, necklaces, limit);
                
                File.AppendAllText(file_name, "cactuses" + Environment.NewLine);
                Graph[] cactuses = new Graph[GraphCount];
                for (i = 0; i < GraphCount; i++)
                    cactuses[i] = RGG.cactus();
                compareMethods(methods, cactuses, limit);
                
                File.AppendAllText(file_name, "Petersen" + Environment.NewLine);
                Graph petersenGraph =
                  new AdjacencyMatrixGraph(false, 10)
                  { new Edge(0,1), new Edge(0,4), new Edge(0,7), new Edge(1,2), new Edge(1,5), new Edge(2,3),
                    new Edge(2,9), new Edge(9,8), new Edge(9,7), new Edge(5,6), new Edge(6,7), new Edge(5,8),
                    new Edge(3,4), new Edge(3,6), new Edge(8,4)};
                Graph[] petersen = new Graph[1];
                petersen[0] = petersenGraph;
                compareMethods(methods, petersen, limit);

                File.AppendAllText(file_name, "bipartite" + Environment.NewLine);
                Graph[] bipartites = new Graph[GraphCount];
                for (i = 0; i < GraphCount; i++)
                    bipartites[i] = RGG.bipartite();
                compareMethods(methods, bipartites, limit);
                */
                /*
                File.AppendAllText(file_name, "wheels" + Environment.NewLine);
                Graph[] wheels = new Graph[GraphCount];
                for (i = 0; i < GraphCount; i++)
                    wheels[i] = RGG.wheel();
                compareMethods(methods, wheels, limit);
                /*
                File.AppendAllText(file_name, "paths" + Environment.NewLine);
                Graph[] paths = new Graph[GraphCount];
                for (i = 0; i < GraphCount; i++)
                    paths[i] = RGG.path();
                compareMethods(methods, paths, limit);
                */

            }

            /*
            List<ColoringGraphs> painters = new List<ColoringGraphs>() { new LargestFirst(), new SmallestLast(), new DSatur() };
            foreach (var painter in painters)
            {
                painter.GetPaintedVertices(graphToPaint: petersenGraph, limit: 3, verbose: true);
            }
            */
        }
        public static void compareMethods(List<ColoringGraphs> listOfMethods, Graph[] graphs, int limit)
        {
            string file_name = "results" + limit + ".txt";
            File.AppendAllText(file_name, limit.ToString() + Environment.NewLine);
            for (int i = 0; i < graphs.Length; i++)
            {
                int maxDegree = 0;
                for (int j = 0; j < graphs[i].VerticesCount; j++)
                    if (graphs[i].OutDegree(j) > maxDegree)
                        maxDegree = graphs[i].OutDegree(j);
                int nbOfColorsUsed;
                List<long> elapsedMs = new List<long>();
                foreach (ColoringGraphs method in listOfMethods)
                {
                    var watch = System.Diagnostics.Stopwatch.StartNew();                        
                    method.GetPaintedVertices(graphs[i], limit, false, out nbOfColorsUsed);
                    watch.Stop();
                    elapsedMs.Add(watch.ElapsedMilliseconds);
                    File.AppendAllText(file_name, nbOfColorsUsed.ToString()+ " ");
                    //Console.Write(nbOfColorsUsed);
                }
                File.AppendAllText(file_name, maxDegree.ToString() +" ");
                foreach (long eMS in elapsedMs)
                    File.AppendAllText(file_name, eMS.ToString() + " ");
                File.AppendAllText(file_name, Environment.NewLine);
        }
        }
    }        
}
