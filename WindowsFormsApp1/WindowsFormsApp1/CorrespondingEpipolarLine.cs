using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class CorrespondingEpipolarLine
    {

        //属性
        double Bx, By, Bz;
        double xp, yp;
        double f;
        double up, vp, wp, us, vs, ws;




        //方法
        //构造函数
    public CorrespondingEpipolarLine(double Bx1,double By1,double Bz1,double xp1,double yp1,double f1)
        {
            Bx = Bx1;
            By = By1;
            Bz = Bz1;
            xp = xp1;
            yp = yp1;
            f = f1;
        }

        //核线方程   左片用
        public double GetY4Line(double X)
        {
            double Y;
            double A = f * By + yp * Bz;
            double B = f * Bx + xp * Bz;
            double C = yp * Bx - xp * By;
            Y = (A / B) * X + (C / B) * f;
            return Y;
        }

        //返回扫描坐标系下的Y值    左片用
        public double GetY4S_ori(double X,double width,double height,double x0,double y0)
        {
            double Y = 0;
            //扫描坐标系下的X先转成像平面坐标系下的X'
            double X_Sxy = X - width / 2-x0;
            //计算对应的Y'的像平面坐标系下的值
            double Y_Sxy = GetY4Line(X_Sxy);
            //将像平面的Y'转换到扫描坐标系的Y
            Y = height / 2 - y0 - Y_Sxy;
            return Y;
        }


///////////////////////////////////////////////////////////////////////////////////////////////////

        //右片专用
        //重载一个右片的构造函数
        public CorrespondingEpipolarLine(double up1,double vp1,double wp1,double us1,double vs1,double ws1,double f1)
        {
            up = up1;
            vp = vp1;
            wp = wp1;
            us = us1;
            vs = vs1;
            ws = ws1;
            f = f1;
        }

        //核线方程 右片用
        public double GetV4Line(double u)
        {
            double v;

            double A = vp * ws - wp * vs;
            double B = up * ws - wp * us;
            double C = vp * us - up * vs;
            v = (A / B) * u + (C / B) * f;

            return v;
        }
        //返回扫描坐标系下的Y值    右片用
        public double GetV4S_ori(double X, double width, double height, double x0, double y0)
        {
            double Y = 0;
            //扫描坐标系下的X先转成像平面坐标系下的X'
            double X_Sxy = X - width / 2 - x0;
            //计算对应的Y'的像平面坐标系下的值
            double Y_Sxy = GetV4Line(X_Sxy);
            //将像平面的Y'转换到扫描坐标系的Y
            Y = height / 2 - y0 - Y_Sxy;
            return Y;
        }

    






        //析构函数
        ~CorrespondingEpipolarLine()
        { }






    }
}
