using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    //Модифицируйте DFS и BFS из предыдущего урока, но уже для графа, также с выводом каждого шага

    class Program
    {
        public class Vertex //Вершина
        {
            public int Number { get; set; }
            public List<Edge> Edges { get; set; }  //исходящие связи
            public bool Visited { get; set; }      //посещенная вершина
        }

        public class Edge //Ребро
        {
            public int Weight { get; set; }        //вес связи
            public Vertex Vert { get; set; }       // узел, на который связь ссылается
        }

        public class Graph
        {
            public List<Vertex> VertList;

            public Graph()
            {
                VertList = new List<Vertex>();
            }

            public void AddVertex(int Num)
            {
                Vertex V = new Vertex();
                V.Number = Num;
                V.Visited = false;
                V.Edges = new List<Edge>();
                VertList.Add(V);
            }

            public void AddEdge(int VertSourceN, int VertDestN, int Weight)
            {
                if (VertSourceN > VertList.Count - 1 || VertDestN > VertList.Count - 1) return;
                if (VertSourceN < 0 || VertDestN < 0) return;

                Edge E = new Edge();
                E.Weight = Weight;
                E.Vert = VertList[VertDestN];
                VertList[VertSourceN].Edges.Add(E);
            }

            private void ClearVisitedVertexes()
            {
                for(int i=0; i<VertList.Count; i++)
                    VertList[i].Visited = false;
            }

            public void BFS()
            {
                ClearVisitedVertexes();
                var stack = new Stack<Vertex>();
                stack.Push(VertList[0]);
                VertList[0].Visited = true;
                Console.WriteLine("BFS:");
                Console.WriteLine($"->   N= {VertList[0].Number}");
                while (stack.Count > 0)
                {
                    var gn = stack.Pop();
                    Console.WriteLine($"  <- N= {gn.Number}");
                    for (int i = 0; i < gn.Edges.Count; i++)
                    {
                        if (!gn.Edges[i].Vert.Visited)
                        {
                            gn.Edges[i].Vert.Visited = true;
                            stack.Push(gn.Edges[i].Vert); 
                            Console.WriteLine($"->  W= {gn.Edges[i].Weight}");
                        }
                    }
                }
            }

            public void DFS()
            {
                ClearVisitedVertexes();
                var queue = new Queue<Vertex>();
                queue.Enqueue(VertList[0]);
                VertList[0].Visited = true;
                Console.WriteLine("DFS:");
                Console.WriteLine($"->   N= {VertList[0].Number}");
                while (queue.Count > 0)
                {
                    var gn = queue.Dequeue();
                    Console.WriteLine($"  <- N= {gn.Number}");

                    for (int i = 0; i < gn.Edges.Count; i++)
                    {
                        if (!gn.Edges[i].Vert.Visited)
                        {
                            gn.Edges[i].Vert.Visited = true;
                            queue.Enqueue(gn.Edges[i].Vert);
                            Console.WriteLine($"->  W= {gn.Edges[i].Weight}");
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {

            Graph G = new Graph();

            G.AddVertex(0);
            G.AddVertex(1);
            G.AddVertex(2);
            G.AddVertex(3);
            G.AddEdge(0, 1, 10);
            G.AddEdge(0, 2, 11);
            G.AddEdge(0, 3, 12);
            G.AddEdge(1, 2, 13);
            G.AddEdge(2, 3, 14);

            G.BFS();

            Console.WriteLine("==================================");

            G.DFS();

            Console.WriteLine("==================================");

            Console.ReadKey();
        }
    }
}
