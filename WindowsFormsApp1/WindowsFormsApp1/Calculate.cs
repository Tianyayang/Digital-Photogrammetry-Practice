using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;



namespace WindowsFormsApp1
{
      
    class Calculate
    {
        //属性
        
        //右片相对左片的方位元素 初值为0
        double u=0;
        double v=0;
        double phi=0;
        double omega=0;
        double kappa=0;

        //用于解算同名核线
        double BX=1; //自己设定 不影响什么
        double BY; //在后面会更新值
        double BZ;
        

        //方法

        // 传入左片右片的像点平面坐标 内方位元素f  
       public Calculate(Point point_Sxy1,Point point_Sxy2,double f)
            {
            //定义连续像对相对定向需要用到的一些变量
            double a1, a2, a3;
            double b1, b2, b3;
            double c1, c2, c3;

            

            //改正数  全部赋初值1 方便while循环的进行
            double du=1;
            double dv=1;
            double dphi=1;
            double domega=1;
            double dkappa=1;


            //记录循环次数
            int countOfwhile = 0;


            //判断改正数大于限差开始循环
            while (du >= 0.00003 || dv >= 0.00003 || dphi >= 0.00003 || domega >= 0.00003 || dkappa >= 0.00003)
            {

                //更新循环次数
                countOfwhile++;

                //计算右片的旋转矩阵
                a1 = Math.Cos(phi) * Math.Cos(kappa) - Math.Sin(phi) * Math.Sin(omega) * Math.Sin(kappa);
                a2 = -Math.Cos(phi) * Math.Sin(kappa) - Math.Sin(phi) * Math.Sin(omega) * Math.Cos(kappa);
                a3 = -Math.Sin(phi) * Math.Cos(omega);
                b1 = Math.Cos(omega) * Math.Sin(kappa);
                b2 = Math.Cos(omega) * Math.Cos(kappa);
                b3 = -Math.Sin(omega);
                c1 = Math.Sin(phi) * Math.Cos(kappa) + Math.Cos(phi) * Math.Sin(omega) * Math.Sin(kappa);
                c2 = -Math.Sin(phi) * Math.Sin(kappa) + Math.Cos(phi) * Math.Sin(omega) * Math.Cos(kappa);
                c3 = Math.Cos(phi) * Math.Cos(omega);
                Matrix R2 = new Matrix(3, 3);//右片的旋转矩阵
                R2.dMatrix = new double[3, 3] { { a1, a2, a3 }, { b1, b2, b3 }, { c1, c2, c3 } };
                // Matrix R1 = R2.qiuni();//左片的旋转矩阵

                //左片水平 不用旋转？？？？
                Matrix R1 = new Matrix(3, 3);
                R1.dMatrix = new double[3, 3] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
                

                //确定有多少对同名像点
                int Pnum = point_Sxy1.Get_X().Count();
                //根据点的数量确定用到的矩阵大小
                // Matrix A = new Matrix(Pnum, 4);
                // Matrix B = new Matrix(Pnum, 5);
                Matrix A = new Matrix(Pnum,5);
                Matrix L = new Matrix(Pnum, 1);

                //开始循环
                for (int num = 0; num < Pnum; num++)
                {
                    //计算像空间辅助坐标
                    //左片用左片的旋转矩阵
                    double X1 = R1.dMatrix[0,0] * point_Sxy1.Get_X()[num] + R1.dMatrix[0,1] * point_Sxy1.Get_Y()[num] - R1.dMatrix[0, 2] * f;
                    double Y1 = R1.dMatrix[1, 0] * point_Sxy1.Get_X()[num] + R1.dMatrix[1, 1] * point_Sxy1.Get_Y()[num] - R1.dMatrix[1, 2] * f;
                    double Z1 = R1.dMatrix[2, 0] * point_Sxy1.Get_X()[num] + R1.dMatrix[2, 1] * point_Sxy1.Get_Y()[num] - R1.dMatrix[2, 2] * f;

                    //右片用右片的旋转矩阵
                    double X2 = a1 * point_Sxy2.Get_X()[num] + a2 * point_Sxy2.Get_Y()[num] - a3 * f;
                    double Y2 = b1 * point_Sxy2.Get_X()[num] + b2 * point_Sxy2.Get_Y()[num] - b3 * f;
                    double Z2 = c1 * point_Sxy2.Get_X()[num] + c2 * point_Sxy2.Get_Y()[num] - c3 * f;

                    //计算By,Bz,N,N',q
                    double Bx = 1;
                    //double Bx = point_Sxy2.Get_X()[num] - point_Sxy1.Get_X()[num];//Bx=x2-x1
                    double By = Bx * u;//课本P55近似公式
                    double Bz = Bx * v;
                    double N1 = (Bx * Z2 - Bz * X2) / (X1 * Z2 - Z1 * X2);
                    double N2 = (Bx * Z1 - Bz * X1) / (X1 * Z2 - Z1 * X2);
                    double q = N1 * Y1 - N2 * Y2 - By;

                    //使用一般式
                    //计算各系数值
                    double A1 = -X2 * Y2 * N2 / Z2;//dphi
                    double A2 = -(Z2 + Y2 * Y2 / Z2) * N2;//domega
                    double A3 = X2 * N2;//dkappa
                    double A4 = Bx;//du
                    double A5 = -Y2 * Bx / Z2;//dv
                    A.dMatrix[num, 0] = A1;
                    A.dMatrix[num, 1] = A2;
                    A.dMatrix[num, 2] = A3;
                    A.dMatrix[num, 3] = A4;
                    A.dMatrix[num, 4] = A5;
                    L.dMatrix[num, 0] = q;
                    //不使用严密式
                    //为计算误差方程各系数值做准备
                    /* Matrix t1 = new Matrix(3, 3);
                     t1.dMatrix = new double[3, 3] { { Bx, By, Bz }, { a1, b1, c1 }, { X2, Y2, Z2 } };
                     Matrix t2 = new Matrix(3, 3);
                     t2.dMatrix = new double[3, 3] { { Bx, By, Bz }, { a2, b2, c2 }, { X2, Y2, Z2 } };
                     Matrix t3 = new Matrix(3, 3);
                     t3.dMatrix = new double[3, 3] { { Bx, By, Bz }, { X1, Y1, Z1 }, { R1.dMatrix[0, 0], R1.dMatrix[1, 0], R1.dMatrix[2, 0] } };
                     Matrix t4 = new Matrix(3, 3);
                     t4.dMatrix = new double[3, 3] { { Bx, By, Bz }, { X1, Y1, Z1 }, { R1.dMatrix[0, 1], R1.dMatrix[1, 1], R1.dMatrix[2, 1] } };
                     Matrix t5 = new Matrix(2, 2);
                     t5.dMatrix = new double[2, 2] { { X1, Z1 }, { X2, Z2 } };
                     Matrix t6 = new Matrix(2, 2);
                     t6.dMatrix = new double[2, 2] { { X1, Y1 }, { X2, Y2 } };
                     Matrix t7 = new Matrix(3, 3);
                     t7.dMatrix = new double[3, 3] { { Bx, By, Bz }, { X1, Y1, Z1 }, { -Z2, 0, X2 } };

                     double temp1 = -Y2 * Math.Sin(phi);
                     double temp2 = X2 * Math.Sin(phi) - Z2 * Math.Cos(omega);
                     double temp3 = Y2 * Math.Cos(phi);
                     Matrix t8 = new Matrix(3, 3);
                     t8.dMatrix = new double[3, 3] { { Bx, By, Bz }, { X1, Y1, Z1 }, { temp1, temp2, temp3 } };

                     double temp4 = -Y2 * Math.Cos(phi) * Math.Cos(omega) - Z2 * Math.Sin(omega);
                     double temp5 = X2 * Math.Cos(phi) * Math.Cos(omega) + Z2 * Math.Sin(phi) * Math.Cos(omega);
                     double temp6 = X2 * Math.Sin(omega) - Y2 * Math.Sin(phi) * Math.Cos(omega);
                     Matrix t9 = new Matrix(3, 3);
                     t8.dMatrix = new double[3, 3] { { Bx, By, Bz }, { X1, Y1, Z1 }, { temp4, temp5, temp6 } };

                     //计算各系数值
                     double A1 = t1.det() / t5.det();
                     double A2 = t2.det() / t5.det();
                     double A3 = t3.det() / t5.det();
                     double A4 = t4.det() / t5.det();

                     double B1 = 1;
                     double B2 = -t6.det() / t5.det();
                     double B3 = -t7.det() / t5.det();
                     double B4 = -t8.det() / t5.det();
                     double B5 = -t9.det() / t5.det();

                     //将各系数值存入矩阵中
                     A.dMatrix[num, 0] = A1;
                     A.dMatrix[num, 1] = A2;
                     A.dMatrix[num, 2] = A3;
                     A.dMatrix[num, 3] = A4;

                     B.dMatrix[num, 0] = B1;
                     B.dMatrix[num, 1] = B2;
                     B.dMatrix[num, 2] = B3;
                     B.dMatrix[num, 3] = B4;
                     B.dMatrix[num, 4] = B5;
                     */

                }

                //解法方程，求未知数改正数
                Matrix X = new Matrix(5, 1);


                //太复杂 慢慢来 一步步来
                // X = ((A.zhuanzhi().xiangcheng(A)).qiuni().xiangcheng(A.zhuanzhi())).xiangcheng(L);

                Matrix AT = A.zhuanzhi();
                Matrix Temp1 = AT.xiangcheng(A);
                Matrix Temp2 = Temp1.qiuni();
                Matrix Temp3 = Temp2.xiangcheng(AT);
                X = Temp3.xiangcheng(L);
               

                dphi = X.dMatrix[0, 0];
                domega = X.dMatrix[1, 0];
                dkappa = X.dMatrix[2, 0];
                du = X.dMatrix[3, 0];
                dv = X.dMatrix[4, 0];



                //计算相对定向元素新值
                u += du;
                v += dv;
                phi += dphi;
                omega += domega;
                kappa += dkappa;

                //更新 BY BZ
                BY = BX * u;
                BZ = BX * v;

            }
            MessageBox.Show("循环次数:"+Convert.ToString( countOfwhile) );
        }


        //Get BX BY BZ phi omaga kappa
        public double GetBX()
        {
            double a = BX;
            return a;
        }
        public double GetBY()
        {
            double a = BY;
            return a;
        }
        public double GetBZ()
        {
            double a = BZ;
            return a;
        }
        public double Getphi()
        {
            double a = phi;
            return a;
        }
        public double Getomaga()
        {
            double a = omega;
            return a;
        }
        public double Getkappa()
        {
            double a = kappa;
            return a;
        }




        //析构函数
        ~Calculate()
        { }

    
        //弹窗显示计算的方位元素的值，同时可以保存为txt文件到选定路径。
        public void ShowResultsAndSave()
        {
            //角度转换
            double phidu, omegadu, kappadu;

            phidu = phi * 180 / Math.PI;
            omegadu = omega * 180 / Math.PI;
            kappadu = kappa * 180 / Math.PI;

            CalculateResults calculateResults = new CalculateResults();
            calculateResults.text1 = "u = " + System.Convert.ToString(u);
            calculateResults.text2 = "v = " + System.Convert.ToString(v);
            calculateResults.text3 = "phi = " + System.Convert.ToString(phidu);
            calculateResults.text4 = "omega = " + System.Convert.ToString(omegadu);
            calculateResults.text5 = "kappa = " + System.Convert.ToString(kappadu);
            calculateResults.ShowDialog();
        }
    }
}
