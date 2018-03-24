using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hopfield_barbu
{
    /**
     * Zurada page 335, Summary of the Recurrent Associative Memory Storage and Retrieval Algorithm (RAMSRA)
    */
    class Hopfield
    {
        MatrixBuilder<double> M = Matrix<double>.Build;
        VectorBuilder<double> V = Vector<double>.Build;

        Matrix<double> W = null;
        Matrix<double> I = null;
        int m = 0;

        // the number of neurons
        int size;

        /**
         * n = size of a colum vector given as sample to the network
         */
        public Hopfield(int n)
        {
            //TODO: what is the proper size of what I need to store?
            size = n * n;
            W = M.Dense(size, size, 0);
            I = M.DenseIdentity(size, size);
        }

        public override String ToString()
        {
            return string.Format("m = {0}\nW =\n{1}", m, W.ToString());
        }

        /**
         * sample is a line matrix (generated from a matrix in row-major order)
         */
        public void store(double[] sample)
        {
            // s is a column-only matrix
            Matrix<double> s = M.DenseOfRowMajor(sample.Length, 1, sample);
            Matrix<double> st = s.Transpose();
            W = W.Add(s * st - I);
            m += 1;

            validateWeightMatrix();
        }

        public void store(List<double[]> samples)
        {
            for (int i = 0; i < samples.Count; i++)
            {
                // s is a column-only matrix
                Matrix<double> s = M.DenseOfRowMajor(samples[i].Length, 1, samples[i]);
                Matrix<double> st = s.Transpose();
                W = W.Add(s * st);
                m += 1;
            }

            W = W.Subtract(I.Multiply(m));

            validateWeightMatrix();
        }

        /**
         * v_input is a line matrix (generated from a matrix in row-major order)
         */
        public Tuple<Matrix<double>, int> recall(double[] v_input)
        {
            Random rnd = new Random();
            int[] orderedArray = new int[size];
            for (int i = 0; i < size; i++)
            {
                orderedArray[i] = i;
            }
            
            // v and vnew are a column-only matrix
            Matrix<double> v = M.DenseOfRowMajor(v_input.Length, 1, v_input);
            Matrix<double> vnew = M.DenseOfMatrix(v);
            int k = 0;

            //continue until we reached a stable state
            while (true)
            {
                int[] randomArray = orderedArray.OrderBy(x => rnd.Next()).ToArray();
                
                for (int i = 0; i < size; i++)
                {
                    int index = randomArray[i];
                    Matrix<double> row = M.DenseOfRowVectors(W.Row(index));
                    Matrix<double> net = row.Multiply(vnew); //net is of size 1x1

                    // modify just the i-th neuron, which is the i-th line in the vnew column matrix
                    vnew[index, 0] = net[0, 0];
                    vnew = vnew.PointwiseSign();
                }
                
                if(v.Equals(vnew))
                {
                    break;
                }

                v = M.DenseOfMatrix(vnew);
                k += 1;
            }
            
            return new Tuple<Matrix<double>, int>(vnew, k);
        }

        private void validateWeightMatrix()
        {
            for (int i = 0; i< size; i ++)
            {
                for (int j = 0; j < size; j++)
                {
                    if(W[i,j] != m && W[i,j] != -m && W[i,j] != 0)
                    {
                        //throw new Exception("invalid W matrix");
                    }
                }
            }
        }
    }
}
