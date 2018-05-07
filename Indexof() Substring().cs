using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS20180417
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random RN = new Random();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int[,] studentscores = new int[int.Parse(textBox1.Text), 4];
                checkedListBox1.Items.Clear();
                checkedListBox1.Items.Add("名字 : 計概 + 國文 + 英文 = 總分");
                int NameLength;
                string FamilyName;
                for (int i = 0; i < int.Parse(textBox1.Text); i++)
                {
                    NameLength = RN.Next(3, 8);
                    FamilyName = ((char)(65 + RN.Next(0, 26))).ToString();
                    for (int j = 1; j <= NameLength; j++)
                    {
                        FamilyName += ((char)(97 + RN.Next(0, 26))).ToString();
                    }

                    for (int k = 1; k <= 3; k++)
                    {
                        studentscores[i, k] = RN.Next(0, 101);
                        studentscores[i, 0] += studentscores[i, k];
                    }
                    checkedListBox1.Items.Add(FamilyName+" :"+ studentscores[i, 1]+" + " + studentscores[i, 2]+" + "+ studentscores[i, 3]+" ="+ studentscores[i, 0]);
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "0";
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (string iteam in checkedListBox1.CheckedItems)
            {
                if (!(iteam.Substring(5,1) == "計"))
                {
                    listBox1.Items.Add(iteam);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            try
            {
                for (int i = 1; i < checkedListBox1.Items.Count; i++)
                {
                    int pos1 = checkedListBox1.Items[i].ToString().IndexOf("+");
                    int pos2 = checkedListBox1.Items[i].ToString().IndexOf("+",pos1 +1);
                    listBox2.Items.Add(checkedListBox1.Items[i].ToString().Substring(pos1 + 2, pos2 - pos1-1-2));
                    if (int.Parse(checkedListBox1.Items[i].ToString().Substring(pos1 + 2, pos2 - pos1 - 1 - 2)) >= 60)
                    {
                        listBox1.Items.Add(checkedListBox1.Items[i].ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "0";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("請選擇移除項目", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("沒有可移除項目", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.Text = listBox1.SelectedIndex.ToString();
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            label1.Text = listBox1.Items.Count.ToString();
        }

        private void listBox1_MouseEnter(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0) return;
            int Score=0;
            int S = 0;
            int Name = 0;
            string N = null;

            int HScore = 0;        
            string HName = null;
            int LScore = 100 * 3;
            string LName = null;
            for (int i = 0;i < listBox1.Items.Count;i++)
            {
                //1.取出總分
                Score = listBox1.Items[i].ToString().IndexOf("=");
                S = int.Parse(listBox1.Items[i].ToString().Substring(Score+1));
                //2.取出姓名
                Name = listBox1.Items[i].ToString().IndexOf(":");
                N = listBox1.Items[i].ToString().Substring(0,Name);
                //3.比較總分(最高分)
                if (S > HScore)
                {
                    HScore = S;
                    HName = N;
                }
                //4.比較總分(最低分)
                if (S < LScore)
                {
                    LScore = S;
                    LName = N;
                }
            }
            label2.Text = HName + " : " + HScore;
            label3.Text = LName + " : " + LScore;

        }

        private void listBox1_MouseLeave(object sender, EventArgs e)
        {
            label2.Text = "最高分者";
            label3.Text = "最低分者";
        }
    } 
}
