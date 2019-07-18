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
    public partial class GetPointName : Form
    {
        public GetPointName()
        {
            InitializeComponent();
        }

        public delegate void Pointnamedelegate(string s);
        public Pointnamedelegate pointnamedelegate;



        private void 确定_Click(object sender, EventArgs e)
        {

            if (this.textBox1.Text == "")
                MessageBox.Show("点名不能为空");
            else
            {
                pointnamedelegate(this.textBox1.Text);
                this.Close();
            }
           
        }
    }
}
