using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        //两个读文件类实例 分别对应002.txt 004.txt
        ReadFile RF1;//内有同名点扫描坐标系坐标
        ReadFile RF2;

        Image image_left;//内有图片宽高
        Image image_right;

        Point point_ori1;
        Point point_Sxy1;//像平面
        Point point_SXYZ1;//像空辅

        Point point_ori2;
        Point point_Sxy2;//像平面
        Point point_SXYZ2;//像空辅


        //共面条件算核线用到的B
        double BX, BY, BZ;
        double phi, omega, kappa;

        //绘制核线的点名
        string POINT_name;
        double POINT_Xleft;
        double POINT_Yleft;
        double POINT_Xright;
        double POINT_Yright;

        int index;


        //内方位元素
        double f;
        double x0;
        double y0;
        int neifangwei = 0;//用于判断内方位元素是否赋值

        //外方位元素_左片
        double Xs_left;
        double Ys_left;
        double Zs_left;
        double Phi_left;
        double Omega_left;
        double Kappa_left;
        int waifangwei_left = 0;//

        //外方位元素_右片
        double Xs_right;
        double Ys_right;
        double Zs_right;
        double Phi_right;
        double Omega_right;
        double Kappa_right;
        int waifangwei_right = 0;//

        private void 加载左片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                image_left = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = image_left;
            }
        }

        private void 加载右片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                image_right = Image.FromFile(openFileDialog1.FileName);
                pictureBox2.Image = image_right;
            }
        }

        private void 加载左片同名点坐标ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                RF1 = new ReadFile(openFileDialog2.FileName);
                point_ori1 = new Point(RF1.pname, RF1.px, RF1.py);
            }
        }

        private void 加载右片同名点坐标ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                 RF2 = new ReadFile(openFileDialog2.FileName);
                point_ori2 = new Point(RF2.pname, RF2.px, RF2.py);
            }
        }

        private void 计算右片相对左片的方位元素ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calculate calculate = new Calculate(point_Sxy1,point_Sxy2,f);
            calculate.ShowResultsAndSave();

            //传一些计算的值出来
            BX = calculate.GetBX();
            BY = calculate.GetBY();
            BZ = calculate.GetBZ();
            phi = calculate.Getphi();
            omega = calculate.Getomaga();
            kappa = calculate.Getkappa();

        }



        private void 加载内外方位元素ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadOrientationData loadOrientationData = new LoadOrientationData();
            loadOrientationData.Show();

            //通过委托将子窗体的值传回主窗体
            loadOrientationData.delegateShow1 = loadOrientationData_ShowDelegateEventHandler1;
            loadOrientationData.delegateShow2 = loadOrientationData_ShowDelegateEventHandler2;
            loadOrientationData.delegateShow3 = loadOrientationData_ShowDelegateEventHandler3;
        }

        void loadOrientationData_ShowDelegateEventHandler1(string text1, string text2, string text3)
        {
            try
            {
                f = System.Convert.ToDouble(text1);
                x0 = System.Convert.ToDouble(text2);
                y0 = System.Convert.ToDouble(text3);
                neifangwei = 1;

                MessageBox.Show("加载内方位元素成功!");
            }
            catch (Exception)
            {
                MessageBox.Show("内方位元素不允许为空");
            }
        }
        void loadOrientationData_ShowDelegateEventHandler2(string text1, string text2, string text3,string text4,string text5,string text6)
        {
            try
            {
                Xs_left = System.Convert.ToDouble(text1);
                Ys_left = System.Convert.ToDouble(text2);
                Zs_left = System.Convert.ToDouble(text3);
                Phi_left = System.Convert.ToDouble(text4);
                Omega_left = System.Convert.ToDouble(text5);
                Kappa_left = System.Convert.ToDouble(text6);
                waifangwei_left = 1;
                MessageBox.Show("加载左片外方位元素成功!");
            }
            catch (Exception)
            {
                MessageBox.Show("外方位元素不允许为空");
            }
        }
        void loadOrientationData_ShowDelegateEventHandler3(string text1, string text2, string text3, string text4, string text5, string text6)
        {
            try
            {
                Xs_right = System.Convert.ToDouble(text1);
                Ys_right = System.Convert.ToDouble(text2);
                Zs_right = System.Convert.ToDouble(text3);
                Phi_right = System.Convert.ToDouble(text4);
                Omega_right = System.Convert.ToDouble(text5);
                Kappa_right = System.Convert.ToDouble(text6);
                waifangwei_right = 1;
                MessageBox.Show("加载右片外方位元素成功!");
            }
            catch(Exception)
            {
                MessageBox.Show("外方位元素不允许为空");
            }
        }

        private void 进行内定向ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //检测内定向需要的数据是否齐全
            if (neifangwei == 0)
                MessageBox.Show("获取内方位元素失败！");
            if (image_left == null)
                MessageBox.Show("获取左片宽高失败！");
            if (image_right == null)
                MessageBox.Show("获取右片宽高失败!");
            //
            if (neifangwei == 1 && image_left != null && image_right != null)
            {
                point_Sxy1 = point_ori1.ConvertToSxy(x0, y0, image_left.Width, image_left.Height);
                point_Sxy2 = point_ori2.ConvertToSxy(x0, y0, image_right.Width, image_right.Height);
                MessageBox.Show("内定向完成！");
            }          
        }

        private void 输出内定向结果ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                try
                {
                    sw.WriteLine("左片同名像点内定向结果：");
                    for(int i=0;i<point_Sxy1.Get_X().Count();i++)
                    {
                        sw.WriteLine("{0} {1} {2}", point_Sxy1.Get_name()[i], point_Sxy1.Get_X()[i], point_Sxy1.Get_Y()[i]);
                    }
                    sw.WriteLine("右片同名像点内定向结果：");
                    for (int i = 0; i < point_Sxy2.Get_X().Count(); i++)
                    {
                        sw.WriteLine("{0} {1} {2}", point_Sxy2.Get_name()[i], point_Sxy2.Get_X()[i], point_Sxy2.Get_Y()[i]);
                    }
                }
                catch(Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
                finally
                {
                    if (sw != null)
                        sw.Close();
                }
            }
        }

        private void 绘制同名核线ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            GetPointName getPointName = new GetPointName();
            getPointName.Show();
            //show了之后 在那边点确定传绘制同名核线的点名过来     
            getPointName.pointnamedelegate = pointnamedelegataeventhandler;//得到了要画核线的点名POINT_name  并将其在左右片的像点坐标传递给对应参数           
        }



        //获取点名 找坐标 算核线 绘图
        void pointnamedelegataeventhandler(string s)
        {           
            POINT_name = s;
            index = point_Sxy1.Get_NameIndex(POINT_name);
            POINT_Xleft = point_Sxy1.Get_X()[index];
            POINT_Yleft = point_Sxy1.Get_Y()[index];
            POINT_Xright = point_Sxy2.Get_X()[index];
            POINT_Yright = point_Sxy2.Get_Y()[index];

            // 左片
            CorrespondingEpipolarLine correspondingEpipolarLineLEFT = new CorrespondingEpipolarLine(BX, BY, BZ, POINT_Xleft, POINT_Yleft, f);
            //获取左片同名点的同名核线的起始点坐标值
            double x1, y1, x2, y2;
            x1 = 0;
            x2 = Convert.ToDouble(image_left.Width);
           

            y1 = correspondingEpipolarLineLEFT.GetY4S_ori(x1,Convert.ToDouble( image_left.Width),Convert.ToDouble( image_left.Height), x0, y0);            
            y2= correspondingEpipolarLineLEFT.GetY4S_ori(x2, Convert.ToDouble(image_left.Width), Convert.ToDouble(image_left.Height), x0, y0);
            //绘制左片同名核线
            DrawCorrespondingEpipolarLine_left(x1, y1, x2, y2);


            //右片                    
            //不能直接用左片的方法，右片需要一个M21矩阵变换一下？
            double a1, a2, a3, b1, b2, b3, c1, c2, c3;
            a1 = Math.Cos(phi) * Math.Cos(kappa) - Math.Sin(phi) * Math.Sin(omega) * Math.Sin(kappa);
            a2 = -Math.Cos(phi) * Math.Sin(kappa) - Math.Sin(phi) * Math.Sin(omega) * Math.Cos(kappa);
            a3 = -Math.Sin(phi) * Math.Cos(omega);
            b1 = Math.Cos(omega) * Math.Sin(kappa);
            b2 = Math.Cos(omega) * Math.Cos(kappa);
            b3 = -Math.Sin(omega);
            c1 = Math.Sin(phi) * Math.Cos(kappa) + Math.Cos(phi) * Math.Sin(omega) * Math.Sin(kappa);
            c2 = -Math.Sin(phi) * Math.Sin(kappa) + Math.Cos(phi) * Math.Sin(omega) * Math.Cos(kappa);
            c3 = Math.Cos(phi) * Math.Cos(omega);

            double up, vp, wp;
            double us, vs, ws;

            up = a1 * POINT_Xleft + b1 * POINT_Yleft - c1 * f;
            vp = a2 * POINT_Xleft + b2 * POINT_Yleft - c2 * f;
            wp = a3 * POINT_Xleft + b3 * POINT_Yleft - c3 * f;
            us = a1 * BX + b1 * BY + c1 * BZ;
            vs = a2 * BX + b2 * BY + c2 * BZ;
            ws = a3 * BX + b3 * BY + c3 * BZ;
            /*
            up = a1 * POINT_Xleft + a2 * POINT_Yleft - a3 * f;
            vp = b1 * POINT_Xleft + b2 * POINT_Yleft - b3 * f;
            wp = c1 * POINT_Xleft + c2 * POINT_Yleft - c3 * f;
            us = a1 * BX + a2 * BY + a3 * BZ;
            vs = b1 * BX + b2 * BY + b3 * BZ;
            ws = c1 * BX + c2 * BY + c3 * BZ;
            */

            double x3, y3, x4, y4;
            x3 = 0;
            x4 = Convert.ToDouble(image_right.Width);
            CorrespondingEpipolarLine correspondingEpipolarLineRIGHT = new CorrespondingEpipolarLine( up, vp, wp,us, vs, ws,f);
            y3 = correspondingEpipolarLineRIGHT.GetV4S_ori(x3, Convert.ToDouble(image_right.Width), Convert.ToDouble(image_right.Height), x0, y0);
            y4 = correspondingEpipolarLineRIGHT.GetV4S_ori(x4, Convert.ToDouble(image_right.Width), Convert.ToDouble(image_right.Height), x0, y0);

            /*  直接用左片的算法画右片*/
        /*    CorrespondingEpipolarLine correspondingEpipolarLineRIGHT = new CorrespondingEpipolarLine(BX, BY, BZ, POINT_Xright, POINT_Yright, f);

            double x3,y3, x4, y4;
            x3 = 0;
            x4 = Convert.ToDouble(image_right.Width);
            y3 = correspondingEpipolarLineRIGHT.GetY4S_ori(x3, Convert.ToDouble(image_right.Width), Convert.ToDouble(image_right.Height), x0, y0);
            y4 = correspondingEpipolarLineRIGHT.GetY4S_ori(x4, Convert.ToDouble(image_right.Width), Convert.ToDouble(image_right.Height), x0, y0);              
    */
            //绘制右片同名核线
            DrawCorrespondingEpipolarLine_right(x3, y3, x4, y4);
        }





        //绘图函数
        void DrawCorrespondingEpipolarLine_left(double x1,double y1,double x2,double y2)
        {
            Graphics g = Graphics.FromImage(image_left);
            Pen p = new Pen(Color.Red,5);
            g.DrawLine(p,Convert.ToSingle( x1),Convert.ToSingle( y1),Convert.ToSingle( x2),Convert.ToSingle( y2));
            pictureBox1.Image = image_left;           
        }

        void DrawCorrespondingEpipolarLine_right(double x1, double y1, double x2, double y2)
        {
            Graphics g = Graphics.FromImage(image_right);
            Pen p = new Pen(Color.Red, 5);
            g.DrawLine(p, Convert.ToSingle(x1), Convert.ToSingle(y1), Convert.ToSingle(x2), Convert.ToSingle(y2));
            pictureBox2.Image = image_right;
        }

        private void 保存左片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog3.ShowDialog()==DialogResult.OK)
            {
                string filename = saveFileDialog3.FileName.ToString();
                image_left.Save(filename);
            }

        }

        private void 保存右片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog4.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog4.FileName.ToString();
                image_right.Save(filename);
            }
        }

        private void 空间直角坐标系的旋转变换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //检测旋转变换需要的参数是否齐全
            if (waifangwei_left == 0)
                MessageBox.Show("加载左片外方位元素失败！");
            if (waifangwei_right == 0)
                MessageBox.Show("加载右片外方位元素失败! ");
            //
            if(waifangwei_left!=0&&waifangwei_right!=0)
            {
                point_SXYZ1 = point_Sxy1.ConvertToSXYZ(f, Phi_left, Omega_left, Kappa_left);
                point_SXYZ2 = point_Sxy2.ConvertToSXYZ(f, Phi_right, Omega_right, Kappa_right);
                MessageBox.Show("空间直角坐标系的旋转变换完成!");
            }

        }

        private void 输出变换结果ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog2.ShowDialog()==DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                try
                {
                    sw.WriteLine("左片同名像点旋转变换结果：");
                    for (int i = 0; i < point_SXYZ1.Get_X().Count(); i++)
                    {
                        sw.WriteLine("{0} {1} {2} {3}", point_SXYZ1.Get_name()[i], point_SXYZ1.Get_X()[i], point_SXYZ1.Get_Y()[i],point_SXYZ1.Get_Z()[i]);
                    }
                    sw.WriteLine("右片同名像点旋转变换结果：");
                    for (int i = 0; i < point_SXYZ2.Get_X().Count(); i++)
                    {
                        sw.WriteLine("{0} {1} {2} {3}", point_SXYZ2.Get_name()[i], point_SXYZ2.Get_X()[i], point_SXYZ2.Get_Y()[i], point_SXYZ2.Get_Z()[i]);
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
                finally
                {
                    if (sw != null)
                        sw.Close();
                }
            }
        }
    }
}
