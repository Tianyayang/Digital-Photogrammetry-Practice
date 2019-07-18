using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Point
    {

        //点类
        List<string> name = new List<string>();
        List<double> X = new List<double>();
        List<double> Y = new List<double>();
        List<double> Z = new List<double>();


        //SET
        public  Point()
        {
        }
        public Point(List<string> name1, List<double> x, List<double> y)
        {
            name = name1;
            X = x;
            Y = y;
        }
        public Point(List<string> name1, List<double> x, List<double> y, List<double> z)
        {
            name = name1;
            X = x;
            Y = y;
            Z = z;
        }        

        //GET
        public List<string> Get_name()
        {
            return name;
        }
        public List<double> Get_X()
        {
            return X;
        }
        public List<double> Get_Y()
        {
            return Y;
        }
        public List<double> Get_Z()
        {
            return Z;
        }


        //GET NAME INDEX
        public int Get_NameIndex(string s)
        {
            int index;
            index = name.IndexOf(s);
            return index;
        }

        //坐标转换
      public  Point ConvertToSxy(double xo,double yo,int width,int height)
        {
            Point point = new Point();
            point.name = name;

            //如果用foreach  需要遍历三次 不方便

            int count = X.Count(); //xy数量应该相等
            for(int i=0;i<count;i++)
            {
                point.X.Add(Tot(Convert.ToDouble( width)/2, X[i])-xo);
                point.Y.Add(Tot(Y[i], Convert.ToDouble(height) / 2)-yo);
            }


            return point;
        }


        double Tot(double t, double tt)
        {
            t = tt - t;
            return t;
        }


        double ToT(double t1,double t2,double t3,double f,double x,double y)
        {
            double T;
            T = t1 * x + t2 * y - t3 * f;
            return T;
        }
        


        public Point ConvertToSXYZ(double f,double phi,double omega,double kappa)
        {
            Point point = new Point();

            point.name = name;
            //
            double a1, a2, a3;
            double b1, b2, b3;
            double c1, c2, c3;
            //
            a1 = Math.Cos(phi) * Math.Cos(kappa) - Math.Sin(phi) * Math.Sin(omega) * Math.Sin(kappa);
            a2 = -Math.Cos(phi) * Math.Sin(kappa) - Math.Sin(phi) * Math.Sin(omega) * Math.Cos(kappa);
            a3 = -Math.Sin(phi) * Math.Cos(omega);
            b1 = Math.Cos(phi) * Math.Sin(kappa);
            b2= Math.Cos(phi) * Math.Cos(kappa);
            b3 = -Math.Sin(omega);
            c1 = Math.Sin(phi) * Math.Cos(kappa) + Math.Cos(phi) * Math.Sin(omega) * Math.Sin(kappa);
            c2 = -Math.Sin(phi) * Math.Sin(kappa) + Math.Cos(phi) * Math.Sin(omega) * Math.Cos(kappa);
            c3 = Math.Cos(phi) * Math.Cos(omega);

            int count = X.Count();
            for(int i=0;i<count;i++)
            {
                point.X.Add(ToT(a1, a2, a3, f, X[i], Y[i]));
                point.Y.Add(ToT(b1, b2, b3, f, X[i], Y[i]));
                point.Z.Add(ToT(c1, c2, c3, f, X[i], Y[i]));
            }

            return point;
        }



        ~ Point()
        { }


    }
}
