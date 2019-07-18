using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    class ReadFile
    {
        //属性
       

       public List<string> pname = new List<string>();
       public List<double> px = new List<double>();
       public List<double> py = new List<double>();
    

        //方法
        //构造函数
        public ReadFile(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            try
            {

                sr.ReadLine();//跳过每个txt文件的无用第一行

                for (string line = sr.ReadLine(); line != null; line = sr.ReadLine())
                {
                    string[] aline = line.Split(' ');
                    //存取点name x y
                    pname.Add(aline[0]);
                    px.Add(System.Convert.ToDouble(aline[1]));
                    py.Add(System.Convert.ToDouble(aline[2]));
                }
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (sr != null)
                    sr.Close(); 
                    MessageBox.Show("同名点数据加载成功！");
            }
        }



        //析构函数
        ~ReadFile()
        { }
    }
}
