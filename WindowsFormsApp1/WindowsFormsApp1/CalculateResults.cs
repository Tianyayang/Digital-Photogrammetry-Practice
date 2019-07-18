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
    public partial class CalculateResults : Form
    {
        public CalculateResults()
        {
            InitializeComponent();
      
        }

        public string text1;
        public string text2;
        public string text3;
        public string text4;
        public string text5;


        private void 确定_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CalculateResults_Load(object sender, EventArgs e)
        {
            this.label1.Text = text1;
            this.label2.Text = text2;
            this.label3.Text = text3;
            this.label4.Text = text4;
            this.label5.Text = text5;
        }

        private void 保存_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                try
                {
                    sw.WriteLine("右片相对左片的方位元素为：");
                    sw.WriteLine(text1);
                    sw.WriteLine(text2);
                    sw.WriteLine(text3);
                    sw.WriteLine(text4);
                    sw.WriteLine(text5);
                }
                catch(Exception)
                {
                    MessageBox.Show("保存失败！");
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
