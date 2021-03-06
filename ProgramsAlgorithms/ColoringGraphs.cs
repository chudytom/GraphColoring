﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASD.Graphs;

namespace ProgramsAlgorithms
{
    public abstract class ColoringGraphs
    {
        public abstract int[] GetPaintedVertices(Graph graphToPaint, int limit, bool verbose);
        public abstract string Name { get; }
        public int ColorsUsedCount { get; set; }
        protected int[] PaintVerticesGreedily(Graph graphToPaint, int limit, int[] sortedVertices)
        {
            int[] verticesColors = new int[graphToPaint.VerticesCount];
            for (int i = 0; i < verticesColors.Length; i++)
            {
                verticesColors[i] = -1;
            }
            //how many vertices are painted in particular color
            List<int> verticesInSameColorCount = new List<int>();
            foreach (var currentVertex in sortedVertices)
            {
                int colorsUsedCount = verticesInSameColorCount.Count;
                HashSet<int> neighbourColors = new HashSet<int>();
                foreach (var edge in graphToPaint.OutEdges(currentVertex))
                {
                    int colorOfNeighbour = edge.To;
                    if (verticesColors[colorOfNeighbour] == -1) continue;
                    if (!neighbourColors.Contains(verticesColors[colorOfNeighbour]))
                        neighbourColors.Add(verticesColors[colorOfNeighbour]);
                }
                for (int currentColor = 0; currentColor < colorsUsedCount; currentColor++)
                {
                    if (neighbourColors.Contains(currentColor) || verticesInSameColorCount[currentColor] >= limit) continue;
                    else
                    {
                        verticesColors[currentVertex] = currentColor;
                        verticesInSameColorCount[currentColor]++;
                        break;
                    }
                }
                //If could not color vertex in any color already used
                if (verticesColors[currentVertex] == -1)
                {
                    verticesInSameColorCount.Add(1);
                    verticesColors[currentVertex] = verticesInSameColorCount.Count - 1;
                }
            }
            ColorsUsedCount = verticesInSameColorCount.Count;
            return verticesColors;
        }

        protected void BottomUpMergeSort(Graph graphToSort, out int[] outputVertices, bool verbose)
        {
            int i;
            int verticesCount = graphToSort.VerticesCount;
            int[] degrees = new int[verticesCount]; // tablica do posortowania
            for (i = 0; i < verticesCount; i++)
                degrees[i] = graphToSort.OutDegree(i);
            outputVertices = new int[verticesCount];      // docelowo tablica indeksow i posortowana wg A[i] malejąco
            for (i = 0; i < verticesCount; i++)
                outputVertices[i] = i;
            // Algorytm zapisuje w CA coraz dluzsze posortowane ciagi 2, 4, 8, 16... 
            // aż tablica A jest posortowana. Zwraca też tablicę kolejnosci wierzcholkow CA
            for (int width = 1; width < verticesCount; width *= 2)
            {
                for (i = 0; i < verticesCount; i += 2 * width)
                {
                    // złącz dwa ciągi: A[i:i+width-1] and A[i+width:i+2*width-1] i wstaw do B[] 
                    // przy laczeniu zapisz tablicę numerow wierzcholkow z CA do CB	   
                    // lub skopiuj A[i:n-1] to B[] ( if(i+width >= n) )
                    BottomUpMerge(degrees, i, Math.Min(i + width, verticesCount), Math.Min(i + 2 * width, verticesCount), outputVertices, out outputVertices);
                }
            }
            if (verbose)
                for (i = 0; i < outputVertices.Length; i++)
                    Console.WriteLine(" Vertices[ " + i + " ] = " + outputVertices[i]);
        }
        //  lewy ciąg to A[CA[iLeft :iRight-1]].
        // prawy ciąg to A[CA[iRight:iEnd-1]].
        private void BottomUpMerge(int[] degrees, int leftListStartIndex, int rightListStartIndex, int mergedListElementsCount, int[] vertices, out int[] outputVertices)
        {
            int leftListIndex, rightListIndex, k;
            outputVertices = new int[degrees.Length];
            for (leftListIndex = 0; leftListIndex < vertices.Length; leftListIndex++) outputVertices[leftListIndex] = vertices[leftListIndex];
            leftListIndex = leftListStartIndex; rightListIndex = rightListStartIndex;
            for (k = leftListStartIndex; k < mergedListElementsCount; k++)
            {
                // jeśli head lewego ciągu istnieje i jest <= head prawego ciągu
                if (leftListIndex < rightListStartIndex && (rightListIndex >= mergedListElementsCount || degrees[vertices[leftListIndex]] >= degrees[vertices[rightListIndex]]))
                {
                    outputVertices[k] = vertices[leftListIndex];
                    leftListIndex++;
                }
                else
                {
                    outputVertices[k] = vertices[rightListIndex];
                    rightListIndex++;
                }
            }
        }

        protected void PrintColors(bool verbose, int[] sortedVertices, int[] verticesColors)
        {
            if (verbose)
            {
                Console.WriteLine($"Coloring algorithm {Name}");
                foreach (var vertex in sortedVertices)
                {
                    Console.WriteLine($"Vertex number {vertex} colored in color {verticesColors[vertex]}");
                }
                Console.WriteLine();
            }
        }
    }
}
