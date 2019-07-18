using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApp1
{
    class Matrix
    {
        //定义矩阵的维度m X n
        public int m;
        public int n;
        //定义矩阵的类型：double型
        public double[,] dMatrix;

        //Matrix类的构造函数 
       public Matrix(int a, int b)  
        {
           m=a;
           n=b;
           dMatrix = new double[m, n];
        }

        //Matrix类的析构函数
        ~Matrix()
        {}


        /*Matrix类的方法
         * 1矩阵求逆
         * 2矩阵相乘
         * 3矩阵转置
         * 4计算当前矩阵的det函数
         * 5获取当前矩阵A的元素aij的余子式矩阵
         * 6获取当前矩阵 A的伴随矩阵
        */

        /*矩阵求逆
         * 传入参数：矩阵B
         * 将当前矩阵A的逆矩阵存入矩阵B
        */
        public Matrix qiuni()
        {
            Matrix B = new Matrix(m, n);
         
            //判断传入的矩阵是否可以求逆
            if (m != n)
            {
                //不可以则输出错误提示
                Console.WriteLine("Wrong Input!");
            }
            else //可以的话开始求逆
            {
                for(int i=0;i<m;i++)
                    for (int j = 0; j < n; j++)
                    {
                        B.dMatrix[i, j] = Awith().zhuanzhi().dMatrix[i, j] / det();
                    }
                

            }

            return B;
        }

        /*矩阵相乘
         * 传入参数：矩阵A、矩阵B与矩阵C
         * 把矩阵A与矩阵B相乘的结果传入矩阵C
         * 可以通过改变AB的顺序来满足谁左谁右
        */
        public Matrix xiangcheng( Matrix B)
        {

            Matrix C = new Matrix(m, B.n);//新矩阵维度 前行 后列

            //定义相乘用到的变量
            double ab=0;

            for (int i = 0; i < C.m; i++)
            {
                for (int j = 0; j < C.n; j++)
                {
                    //
                    for (int t = 0; t < n; t++)
                    {
                        ab += dMatrix[i, t] * B.dMatrix[t, j];
                    }

                    //
                    C.dMatrix[i, j] = ab;
                    ab = 0;
                }

            }

            return C;

        }

        /*矩阵转置
         * 返回当前矩阵的转置矩阵
        */
        public Matrix zhuanzhi()
        {
            Matrix B = new Matrix(n, m);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    B.dMatrix[i,j]=dMatrix[j,i];
                }
            }
            return B;
        }




        //计算当前矩阵的det函数
       public double det()
        {
            double detA=0;

            //计算detA
                //1维行列式为特殊情况
            if (m == 1)
                detA = dMatrix[0, 0];
            else
            {
                //二维及以上计算detA需要迭代
                for (int i = 0; i < m; i++)
                {
                    detA += dMatrix[0, i] * Mij(0,i).det()*Math.Pow(-1,i);
                }
            }

            return detA;
        }


        //获取当前矩阵A的元素aij的余子式矩阵
       public Matrix Mij(int a,int b)
       {
           Matrix M=new Matrix(m-1,n-1);
           for ( int i = 0; i < M.m; i++)
           {
               for (int j = 0; j < M.n; j++)
               {
                   if (i < a && j < b)
                       M.dMatrix[i, j] = dMatrix[i, j];
                   else if (i < a && j >=b)
                       M.dMatrix[i, j] = dMatrix[i, j + 1];
                   else if (i >= a && j < b)
                       M.dMatrix[i, j] = dMatrix[i + 1, j];
                   else if (i >= a && j >= b)
                       M.dMatrix[i, j] = dMatrix[i + 1, j + 1];
               }
           }
           return M;
       }

        //获取当前矩阵 A的伴随矩阵
       public Matrix Awith()
       {
           Matrix Awith = new Matrix(m, n);
           for(int i=0;i<m;i++)
               for (int j = 0; j < n; j++)
               {
                   Awith.dMatrix[i, j] = Math.Pow(-1, i + j) * Mij(i,j).det();
               }


           return Awith;
       }

    }
}
