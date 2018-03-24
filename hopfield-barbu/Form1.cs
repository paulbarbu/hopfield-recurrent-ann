using MathNet.Numerics.LinearAlgebra;
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
        
        private Matrix<double> srcGrid = Matrix<double>.Build.Dense(N, N, -1);
        private Matrix<double> dstGrid = Matrix<double>.Build.Dense(N, N, -1);

        private Button[,] srcBtnGrid = new Button[N, N];
        private Button[,] dstBtnGrid = new Button[N, N];

        private Hopfield hopfield = new Hopfield(N);

        List<double[]> samples = new List<double[]>();
        bool clicked = false;

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
                    
                    
                    b.Tag = new BtnGridId(i, j, isSrcGrid);

                    SetBtn(b, false);

                    if(isSrcGrid)
                    {
                        srcBtnGrid[i, j] = b;

                        b.Click += new EventHandler(this.BtnGridClick);
                        b.MouseEnter += new EventHandler(this.BtnSrcEnter);
                    }
                    else
                    {
                        b.Enabled = false;
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
                srcGrid[btnId.i, btnId.j] = on ? 1 : -1;
            }
            else
            {
                dstGrid[btnId.i, btnId.j] = on ? 1 : -1;
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
            int y = 150;
            draw_grid(new Point(10, y), true); // src grid
            draw_grid(new Point(400, y), false); // dst grid
        }

        void update_grid(Matrix<double> to, bool isSrcGrid)
        {
            for(int i=0; i<N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if(isSrcGrid)
                    {
                        SetBtn(srcBtnGrid[i, j], to[i, j] == 1);
                    }
                    else
                    {
                        SetBtn(dstBtnGrid[i, j], to[i, j] == 1);
                    }                    
                }
            }
            
        }

        private void printArraysBtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("SRC:");
            //prettyPrintArray(srcGrid);
            Console.WriteLine(srcGrid.ToString());

            Console.WriteLine("\n\nDST:");
            //prettyPrintArray(dstGrid);
            Console.WriteLine(dstGrid.ToString());
        }

        private void storePatternBtn_Click(object sender, EventArgs e)
        {
            //samples.Add(srcGrid.ToRowMajorArray());
            hopfield.store(srcGrid.ToRowMajorArray());
        }

        private void hopfieldDetailsBtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine(hopfield.ToString());
        }

        private void recallPatternBtn_Click(object sender, EventArgs e)
        {
            //hopfield = new Hopfield(N);
            //hopfield.store(samples);

            // send the src grid to the network and get the result
            Tuple<Matrix<double>, int> result = hopfield.recall(srcGrid.ToRowMajorArray());

            // the above operation gives a column matrix, I need to make it an NxN matrix
            Matrix<double> processed_result = Matrix<double>.Build.DenseOfRowMajor(N, N, result.Item1.ToRowMajorArray());

            //then place the matrix result on screen on the DST grid
            update_grid(processed_result, false);

            recallStatusLbl.Text = "k = " + result.Item2;
        }

        private void resetSrcGrid_Click(object sender, EventArgs e)
        {
            update_grid(Matrix<double>.Build.Dense(N, N, -1), true);
        }

        private void resetNetworkBtn_Click(object sender, EventArgs e)
        {
            samples = new List<double[]>();
            update_grid(Matrix<double>.Build.Dense(N, N, -1), true);
            update_grid(Matrix<double>.Build.Dense(N, N, -1), false);
            hopfield = new Hopfield(N);
        }
        
        private void BtnSrcEnter(object sender, EventArgs e)
        {
            if (clicked)
            {
                Button b = (Button)sender;

                SetBtn(b, !IsSetBtn(b)); // toggle the button
            }
        }
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.X)
            {
                clicked = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.X)
            {
                clicked = false;
            }
        }
    }
}
