using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS20180412
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
            Random RN = new Random();
            int NUM;
            private void button1_Click(object sender, EventArgs e)
            {
                NUM = RN.Next(0, 10);
                this.Text = NUM.ToString();
                progressBar1.Value = 30;
                timer1.Enabled = true;
            }

            private void timer1_Tick(object sender, EventArgs e)
            {
                if (progressBar1.Value == 0)
                {
                    timer1.Enabled = false;
                    MessageBox.Show("Game Over", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    progressBar1.PerformStep();
                    label1.Text = progressBar1.Value.ToString();
                }
            }

            private void textBox1_TextChanged(object sender, EventArgs e)
            {
                try
                {
                    if (int.Parse(textBox1.Text) == NUM)
                    {
                        timer1.Enabled = false;
                        MessageBox.Show("答對啦", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    timer1.Enabled = false;
                    MessageBox.Show("請輸入數字(0-9)", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                    button1_Click(null, null);
                }
            }

            private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    this.Text = e.KeyChar.ToString();
                    e.Handled = true;
                }
            }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        pictureBox1.Image = Resource1._1_秋色;
                        break;
                    case 1:
                        pictureBox1.Image = Resource1._2_日落;
                        break;
                    case 2:
                        pictureBox1.Image = Resource1._3_微軟;
                        break;
                    case 3:
                        pictureBox1.Image = Resource1._4_夕陽;
                        break;
                    case 4:
                        pictureBox1.Image = Resource1._5_沙漠;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            pictureBox1.Height = vScrollBar1.Value;
            pictureBox1.Width = vScrollBar1.Value;
            this.Text = "圖形大小 : " + vScrollBar1.Value + "這麼大";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer2.Enabled = !timer2.Enabled;
            if (timer2.Enabled)
            {
                button2.Text = "暫停";
            }
            else
            {
                button2.Text = "自動撥放";
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //comboBox1.Text = comboBox1.Items[RN.Next(0,5)].ToString();
            
           if (timer2.Enabled == true)
            {
                int i = 0;
                for (int j = 0; j < 5; j++)
                {
                    comboBox1.Text = comboBox1.Items[i].ToString();
                    i++;
                }
                if (i > 4) { i = 0; }
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            timer2.Interval = hScrollBar1.Value;
            this.Text = "間格時間" + Math.Round((double)hScrollBar1.Value / 1000,3) + "秒";
        }
    }
}
       