using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hopfield_barbu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static readonly int N = 10;
        private Size BtnSize  =new Size(30, 30);

        private int[,] srcGrid = new int[N, N];
        private int[,] dstGrid = new int[N, N];

        private Button[,] srcBtnGrid = new Button[N, N];
        private Button[,] dstBtnGrid = new Button[N, N];

        struct BtnGridId
        {
            public int i;
            public int j;
            public bool isSrc;

            public BtnGridId(int param_i, int param_j, bool param_isSrc) : this()
            {
                i = param_i;
                j = param_j;
                isSrc = param_isSrc;
            }
        }

        private void draw_grid(Point upperLeft, bool isSrcGrid)
        {
            int leftPadding = 10;
            int upperPadding = 10;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Button b = new Button();
                    b.Size = BtnSize;
                    Point location = new Point(upperLeft.X + leftPadding + j * BtnSize.Width, upperLeft.Y + upperPadding + i * BtnSize.Height);
                    b.Location = location;
                    b.Click += new EventHandler(this.BtnGridClick);

                    b.Tag = new BtnGridId(i, j, isSrcGrid);

                    SetBtn(b, false);

                    if(isSrcGrid)
                    {
                        srcBtnGrid[i, j] = b;
                    }
                    else
                    {
                        dstBtnGrid[i, j] = b;
                    }

                    this.Controls.Add(b);
                }
            }
        }

        bool IsSetBtn(Button b)
        {
            // black color = on/set
            // control color = off/not set
            if (b.BackColor != Color.Black)
            {
                return false;
            }
            return true;
        }

        void SetBtn(Button b, bool on)
        {
            // black color = on/set
            // control color = off/not set
            if (on)
            {                
                b.BackColor = Color.Black;
            }
            else
            {
                b.BackColor = SystemColors.Control;
            }

            BtnGridId btnId = (BtnGridId)b.Tag;

            if (btnId.isSrc)
            {
                srcGrid[btnId.i, btnId.j] = on ? 1 : 0;
            }
            else
            {
                dstGrid[btnId.i, btnId.j] = on ? 1 : 0;
            }
        }

        private void BtnGridClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            SetBtn(b, !IsSetBtn(b)); // toggle the button

            //BtnGridId btnId = (BtnGridId)b.Tag;
            //SetBtn(dstBtnGrid[btnId.i, btnId.j], true);
        }

        void prettyPrintArray(int[,] array)
        {
            for(int i=0; i<array.GetLength(0);i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i,j] + " ");
                }
                Console.WriteLine();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int y = 50;
            draw_grid(new Point(10, y), true); // src grid
            draw_grid(new Point(400, y), false); // dst grid
        }

        private void printArraysBtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("SRC:");
            prettyPrintArray(srcGrid);

            Console.WriteLine("\n\nDST:");
            prettyPrintArray(dstGrid);
        }
    }
}
