using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
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
        public Point[,] mapPos;

        //Queue<Node> AllPathPoint;
        //Stack<Node> FinalPathPoint;


        public Form1()
        {
            InitializeComponent();
           // CreateLine();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FindPathBFS bfs = new FindPathBFS();
            FinalData fd= bfs.Start();
            Draw(fd.AllPathPoint,fd.FinalPathPoint);
        }
        void CreateLine() {
            mapPos = new Point[map.GetLength(0), map.GetLength(1)];

            // 获取当前窗体的坐标
            Rectangle rect = panel1.Bounds;
            Graphics gra = panel1.CreateGraphics();
            // 网格的列数
            int col = map.GetLength(1) - 1;
            // 网格的行数
            int row = map.GetLength(0) - 1;
            int colva = rect.Width / (col + 1);
            int rowva = rect.Height / (row + 1);
            int drawRow = 0;
            int drawCol = 0;




            // 实例化画笔。
            Pen p = new Pen(Brushes.Blue);
            // 设置画笔的样式(虚线)。
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

            // 画水平线
            gra.DrawLine(p, 0, 0, rect.Width, 0);
            gra.DrawLine(p, 0, rect.Height - 1, rect.Width, rect.Height - 1);
            gra.DrawLine(p, 0, 0, 0, rect.Height);
            gra.DrawLine(p, rect.Width - 1, 0, rect.Width - 1, rect.Height);

            for (int i = 1; i <= row; i++)
            {
                drawRow += rowva;
                gra.DrawLine(p, 0, drawRow, rect.Width, drawRow);
                //  Console.WriteLine(rowva);
            }
            for (int j = 1; j <= col; j++)
            {
                drawCol += colva;
                gra.DrawLine(p, drawCol, 0, drawCol, rect.Height);
            }
            SolidBrush sb = new SolidBrush(Color.Red);
            int x = 0;
            int y = 0;
            int xx = 0;
            int yy = 0;
            foreach (int item in map)
            {
                xx = x % (col + 1);
                yy = y / (col + 1);
                if (item == 1)
                {
                    sb.Color = Color.Red;
                }
                if (item == 0)
                {
                    sb.Color = Color.White;
                }
                if (item == 8)
                {
                    sb.Color = Color.Pink;
                }
                if (item == 9)
                {
                    sb.Color = Color.Yellow;
                }
                gra.FillRectangle(sb, new Rectangle(new Point(colva * xx, rowva * yy), new Size(colva - 1, rowva - 1)));
                mapPos[yy, xx] = new Point(colva * xx + colva - 1, rowva * yy + rowva - 1);
                x++;
                y++;
            }

        }
        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

            mapPos = new Point[map.GetLength(0), map.GetLength(1)];

            // 获取当前窗体的坐标
            Rectangle rect = panel1.Bounds;
            // 网格的列数
            int col = map.GetLength(1) - 1;
            // 网格的行数
            int row = map.GetLength(0) - 1;
            int colva = rect.Width / (col + 1);
            int rowva = rect.Height / (row + 1);
            int drawRow = 0;
            int drawCol = 0;




            // 实例化画笔。
            Pen p = new Pen(Brushes.Blue);
            // 设置画笔的样式(虚线)。
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

            // 画水平线
            e.Graphics.DrawLine(p, 0, 0, rect.Width, 0);
            e.Graphics.DrawLine(p, 0, rect.Height - 1, rect.Width, rect.Height - 1);
            e.Graphics.DrawLine(p, 0, 0, 0, rect.Height);
            e.Graphics.DrawLine(p, rect.Width - 1, 0, rect.Width - 1, rect.Height);

            for (int i = 1; i <= row; i++)
            {
                drawRow += rowva;
                e.Graphics.DrawLine(p, 0, drawRow, rect.Width, drawRow);
                //  Console.WriteLine(rowva);
            }
            for (int j = 1; j <= col; j++)
            {
                drawCol += colva;
                e.Graphics.DrawLine(p, drawCol, 0, drawCol, rect.Height);
            }
            SolidBrush sb = new SolidBrush(Color.Red);
            int x = 0;
            int y = 0;
            int xx = 0;
            int yy = 0;
            foreach (int item in map)
            {
                xx = x % (col + 1);
                yy = y / (col + 1);
                if (item == 1)
                {
                    sb.Color = Color.Red;
                }
                if (item == 0)
                {
                    sb.Color = Color.White;
                }
                if (item == 8)
                {
                    sb.Color = Color.Pink;
                }
                if (item == 9)
                {
                    sb.Color = Color.Yellow;
                }
                e.Graphics.FillRectangle(sb, new Rectangle(new Point(colva * xx, rowva * yy), new Size(colva - 1, rowva - 1)));
                mapPos[yy, xx] = new Point(colva * xx+(colva - 1) /2 , rowva * yy+(rowva - 1) /2 );
                x++;
                y++;
            }
        }
        public void Draw(Queue<Node> AllPathPoint, Stack<Node> FinalPathPoint)
        {
            panel2.Refresh();
            Pen p = new Pen(Brushes.Black);
            
            // 设置画笔的样式(虚线)。
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            while (AllPathPoint.Count != 0)
            {
                Node node = AllPathPoint.Dequeue();
                Point ParentPos = mapPos[node.Parent.SelfIndex.X, node.Parent.SelfIndex.Y];
                Point SelfPos = mapPos[node.SelfIndex.X, node.SelfIndex.Y];
                panel2.CreateGraphics().DrawLine(p, ParentPos, SelfPos);
                Thread.Sleep(100);
            }
            p = new Pen(Brushes.Green);
            // 设置画笔的样式(虚线)。
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            p.Width = 3f;
            while (FinalPathPoint.Count!=0)
            {
                Node node = FinalPathPoint.Pop();
                Point ParentPos = mapPos[node.Parent.SelfIndex.X, node.Parent.SelfIndex.Y];
                Point SelfPos = mapPos[node.SelfIndex.X, node.SelfIndex.Y];
                panel2.CreateGraphics().DrawLine(p, ParentPos, SelfPos);
                Thread.Sleep(10);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FindPathBFS bfs = new FindPathBFS();
            FinalData fd = bfs.BFSStart();
            Draw(fd.AllPathPoint, fd.FinalPathPoint);
        }
    }
}
