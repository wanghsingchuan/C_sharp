using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace CS20180306
{
    public partial class Form1 : Form
    {
        Random RN = new Random();
        byte A, B;
        int SleepTime;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (DateTime.Now.Second % 2 != 0)
            //{ DisplayB.Text = DateTime.Now.ToString(); }
            //else
            //{ DisplayA.Text = DateTime.Now.ToString(); }
            DisplayB.Text = DateTime.Now.ToString();
            SleepTime = int.Parse(MSec.Text);

            //1.Thread.Sleep
            //Thread.Sleep(SleepTime);

            //2.Random
            SleepTime = RN.Next(0, 10);
            if (DateTime.Now.Second % 10 != SleepTime) return;

            if (RN.Next(0, 2) == 0)  //甲班
            {
                A++;
                textBox1.Text += "資一甲(" + A + "):" + DateTime.Now.ToString() + Environment.NewLine;
                if (A == byte.Parse(Nth.Text))
                {
                    textBox1.Text += "Winner : 資一甲";
                    timer1.Enabled = false;
                }
            }
            else                     //乙班
            {
                B++;
                textBox2.Text += "資一乙(" + B + "):" + DateTime.Now.ToString() + Environment.NewLine;  //Environment.NewLine= " \n"
                if (B == byte.Parse(Nth.Text))
                {
                    textBox2.Text += "Winner : 資一乙";
                    timer1.Enabled = false;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //DisplayA.Text = DateTime.Now.ToString();
            System.DateTime today = System.DateTime.Now;
            System.TimeSpan duration = new System.TimeSpan(0, -7, 0, 0);
            System.DateTime answer = today.Add(duration);
            DisplayA.Text = answer.ToString();
            //System.Console.WriteLine("{0:dddd}", answer); 
        }

        private void DisplayA_DoubleClick(object sender, EventArgs e)
        {
           // timer2.Enabled = !timer2.Enabled;
        }

        private void DisplayA_MouseEnter(object sender, EventArgs e)
        {
            timer2.Enabled = false;
        }

        private void DisplayA_MouseLeave(object sender, EventArgs e)
        {
            timer2.Enabled = true;
        }

        private void Nth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar !=8)
            {
                this.Text = e.KeyChar.ToString();
                e.Handled = true; 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            A = 0; B = 0;
            textBox1.Clear(); textBox2.Clear();

            timer1.Enabled = !timer1.Enabled;
            if (timer1.Enabled == true)
            {
                button1.Text = "暫停";
                button1.BackColor = Color.LightGreen;
            }
            else
            {
                button1.Text = "啟動";
                button1.BackColor = Color.Red;
            }
        }

     
    }
}
