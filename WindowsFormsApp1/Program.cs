using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            float a = 4.6f;
            a += 0.5f;
            Console.WriteLine((int)a);
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            
            
        }
    }
    class FinalData {
        public Queue<Node> AllPathPoint;
        public Stack<Node> FinalPathPoint;

        public FinalData(Queue<Node> allPathPoint, Stack<Node> finalPathPoint)
        {
            AllPathPoint = allPathPoint;
            FinalPathPoint = finalPathPoint;
        }
    }
    class FindPathBFS {
        public int[,] map = 
        {
           { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            { 1,0,0,0,1,0,0,0,0,0,0,0,0,0,1},
            { 1,0,8,0,1,0,0,1,1,1,0,0,0,1,1},
            { 1,0,0,0,1,0,0,0,0,1,0,0,0,0,1},
            { 1,0,0,0,1,1,1,1,1,1,1,1,1,0,1},
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            { 1,0,1,0,0,1,1,1,1,1,1,1,1,1,1},
            { 1,0,1,0,0,0,0,0,0,0,0,0,0,0,1},
            { 1,0,1,0,0,0,0,0,0,0,0,0,0,9,1},
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
        };

        Stack<Node> PathPointStack=new Stack<Node>();


        Queue<Node> PathPoint = new Queue<Node>();
        public Queue<Node> AllPathPoint = new Queue<Node>();
        List<Point> BeCheckedPoint;
        public Stack<Node> FinalPathPoint = new Stack<Node>();
        bool isFinish=false;
        public FinalData Start() {
            BeCheckedPoint = new List<Point>();
            Node StartPoint = new Node()
            {
                SelfIndex = new Point(2, 2),
                Parent = null
            };
            PathPointStack.Push(StartPoint);
        //    AllPathPoint.Enqueue(StartPoint);
            while (PathPointStack.Count!=0&&!isFinish)
            {
                DFSCheckBoundPoint8(PathPointStack.Pop(), 15, 10);
            }
            return new FinalData(AllPathPoint, FinalPathPoint);
        }
        public FinalData BFSStart()
        {
            BeCheckedPoint = new List<Point>();
            Node StartPoint = new Node()
            {
                SelfIndex = new Point(2, 2),
                Parent = null
            };
            PathPoint.Enqueue(StartPoint);
            //    AllPathPoint.Enqueue(StartPoint);
            while (PathPoint.Count != 0 && !isFinish)
            {
                BFSCheckBoundPoint8(PathPoint.Dequeue(), 15, 10);
            }
            return new FinalData(AllPathPoint, FinalPathPoint);
        }
        private void DFSCheckBoundPoint8(Node node,int width,int height) {
            Point index = node.SelfIndex;
            
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <=1; j++)
                {
                    if (i!=0||j!=0) {
                        
                        if ((index.X+i)<0|| (index.Y + j)<0|| (index.X + i)>height|| (index.Y + j)>width|| CheckPointIsChecked(new Point(index.X + i, index.Y + j))) {
                            continue;
                        }
                        Point point = new Point(index.X + i, index.Y + j);
                        if (CheckPointIsFinal(point)) {
                            isFinish = true;
                            Node ParentNode = node;
                            Node FinalNode = new Node
                            {
                                SelfIndex = new Point(index.X + i, index.Y + j),
                                Parent = node
                            };
                            AllPathPoint.Enqueue(FinalNode);
                            FinalPathPoint.Push(FinalNode);
                            int x = 0;
                            while (ParentNode.Parent!=null)
                            {
                                x++;
                                Console.WriteLine("父路径点     " + ParentNode.Parent.SelfIndex);
                                FinalPathPoint.Push(ParentNode);
                                ParentNode = ParentNode.Parent;
                            }
                         //   new Form1().Draw(AllPathPoint,FinalPathPoint);
                            Console.WriteLine("路径总长度：     " + x);
                        }
                        if (CheckPointIsCanWalk(point)) {
                            Node thisNode = new Node
                            {
                                SelfIndex = point,
                                Parent = node
                            };
                            PathPointStack.Push(thisNode);
                            AllPathPoint.Enqueue(thisNode);
                            BeCheckedPoint.Add(point);
                            return;
                        }
                    }
                }
            }
            PathPointStack.Push(node.Parent);
        }
        private void BFSCheckBoundPoint8(Node node, int width, int height)
        {
            Point index = node.SelfIndex;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i != 0 || j != 0)
                    {

                        if ((index.X + i) < 0 || (index.Y + j) < 0 || (index.X + i) > height || (index.Y + j) > width || CheckPointIsChecked(new Point(index.X + i, index.Y + j)))
                        {
                            continue;
                        }
                        Point point = new Point(index.X + i, index.Y + j);
                        if (CheckPointIsFinal(point))
                        {
                            isFinish = true;
                            Node ParentNode = node;
                            Node FinalNode = new Node
                            {
                                SelfIndex = new Point(index.X + i, index.Y + j),
                                Parent = node
                            };
                            AllPathPoint.Enqueue(FinalNode);
                            FinalPathPoint.Push(FinalNode);
                            int x = 0;
                            while (ParentNode.Parent != null)
                            {
                                x++;
                                Console.WriteLine("父路径点     " + ParentNode.Parent.SelfIndex);
                                FinalPathPoint.Push(ParentNode);
                                ParentNode = ParentNode.Parent;
                            }
                            //   new Form1().Draw(AllPathPoint,FinalPathPoint);
                            Console.WriteLine("路径总长度：     " + x);
                        }
                        if (CheckPointIsCanWalk(point))
                        {
                            Node thisNode = new Node
                            {
                                SelfIndex = point,
                                Parent = node
                            };
                            PathPoint.Enqueue(thisNode);
                            AllPathPoint.Enqueue(thisNode);
                            BeCheckedPoint.Add(point);
                        }
                    }
                }
            }
        }
        private bool CheckPointIsCanWalk(Point point) {
            return map[point.X, point.Y] == 0;
        }
        private bool CheckPointIsFinal(Point point) {
            return map[point.X, point.Y] == 9;
        }
        private bool CheckPointIsChecked(Point point) {
            return BeCheckedPoint.Contains(point);
        }
    }
    public class Node {
        public Point SelfIndex;
        public Node Parent; 
    }
}
