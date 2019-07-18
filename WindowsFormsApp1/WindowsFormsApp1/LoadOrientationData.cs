using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class LoadOrientationData : Form
    {
        public LoadOrientationData()
        {
            InitializeComponent();
        }

        //内方位元素委托
        public delegate void ShowDelegate1(string text1, string text2, string text3);//声明委托
        public ShowDelegate1 delegateShow1;//public委托变量

        //外方位元素委托
        public delegate void ShowDelegate2(string text1, string text2, string text3, string text4, string text5, string text6);
        public ShowDelegate2 delegateShow2;
        public ShowDelegate2 delegateShow3;


        private void 确定内方位元素_Click(object sender, EventArgs e)
        {
            delegateShow1(this.textBox1.Text,this.textBox2.Text,this.textBox3.Text);          
        }

        private void 确定左片外方位元素_Click(object sender, EventArgs e)
        {
            delegateShow2(this.textBox4.Text, this.textBox5.Text, this.textBox6.Text, this.textBox8.Text, this.textBox7.Text, this.textBox9.Text);
        }

        private void 确定右片外方位元素_Click(object sender, EventArgs e)
        {
            delegateShow3(this.textBox15.Text, this.textBox14.Text, this.textBox13.Text, this.textBox11.Text, this.textBox12.Text, this.textBox10.Text);

        }
    }
}
