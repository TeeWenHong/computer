using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using homework7;

namespace homework7
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        double th1;
        double th2;
        double per1;
        double per2;

        public Form1()
        {
            InitializeComponent();
            base1();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.comboBox1.Items.Add("Red");
            this.comboBox1.Items.Add("Bule");
            this.comboBox1.Items.Add("Green");
            this.comboBox1.SelectedItem = 1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            graphics = this.pictureBox1.CreateGraphics();
            
            int n = int.Parse(textBox1.Text);
            double leng = double.Parse(textBox2.Text);
            double per1 = double.Parse(textBox3.Text);
            double per2 = double.Parse(textBox4.Text);
            double th1 = double.Parse(textBox5.Text) * Math.PI/180;
            double th2 = double.Parse(textBox6.Text) * Math.PI/180;
            drawCayleyTree(10, 200, 310, 100, -Math.PI / 2);
        }
        public void base1()
        {
            this.textBox1.Text = "10";
            this.textBox2.Text = "100";
            this.textBox3.Text = "0.6";
            this.textBox4.Text = "0.7";
            this.textBox5.Text = "30";
            this.textBox6.Text = "20";
        }
        void drawCayleyTree(int n,double x0, double y0, double leng, double th)
        {
            if (n == 0) { return; }

            double x1 = x0 + leng*Math.Cos(th);
            double y1 = y0 + leng*Math.Sin(th);

            drawLine(x0, y0, x1, y1);
            
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th - th2);
        }
        void drawLine(double x0, double y0, double x1, double y1)
        {
            String color = this.comboBox1.SelectedItem.ToString();
            switch (color)
            {
                case "Pink":
                    graphics.DrawLine(Pens.Pink, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case "Blue":
                    graphics.DrawLine(Pens.Blue, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case "Green":
                    graphics.DrawLine(Pens.Green, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
            }
        }
        private void pictureBox1_Click(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Pink,2);
            g.DrawLine(p, 0, 0, 100, 100);
        }

     
    }
}
