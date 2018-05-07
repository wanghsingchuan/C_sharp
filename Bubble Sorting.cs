using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS20180320
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[] Scores = new int[100];
        string[] Names = new string[100];
        Random RN = new Random();

        STUDENT [] ST= new STUDENT [100];
        struct STUDENT
        {
            public int Score;
            public string Name;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            int NameLength, Score;
            string Name;
            for(byte i=0; i < numericUpDown1.Value; i++)
            {
                Name = ((char)RN.Next(65, 91)).ToString();

                NameLength = RN.Next(3, 8);
                for (byte j = 1; j <= NameLength; j++)
                {
                    Name += ((char)RN.Next(97, 123)).ToString();
                }
                ST[i].Name = Name;
                Score = RN.Next(0, 101);
                ST[i].Score = Score;
                //textBox1.Text += i +". "+ Names[i] + ":" + Scores[i] + Environment.NewLine;
                textBox1.Text += i + ". " + ST[i].Name + ":" + ST[i].Score + Environment.NewLine;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //1. 間接點擊Button1
            button1.PerformClick();

            //2.使用button1_Click的程式
            //button1_Click(null, null);

            //3. Code Copy
            //textBox1.Clear();
            //int NameLength, Score;
            //string Name;
            //for (byte i = 0; i < numericUpDown1.Value; i++)
            //{
            //    Name = ((char)RN.Next(65, 91)).ToString();

            //    NameLength = RN.Next(3, 8);
            //    for (byte j = 1; j <= NameLength; j++)
            //    {
            //        Name += ((char)RN.Next(97, 123)).ToString();
            //    }
            //    Names[i] = Name;
            //    Score = RN.Next(0, 101);
            //    Scores[i] = Score;
            //    textBox1.Text += i + ". " + Names[i] + ":" + Scores[i] + Environment.NewLine;
            //}
        }

        private void numericUpDown1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Clear();
            int NameLength, Score;
            string Name;
            for (byte i = 0; i < numericUpDown1.Value; i++)
            {
                Name = ((char)RN.Next(65, 91)).ToString();

                NameLength = RN.Next(3, 8);
                for (byte j = 1; j <= NameLength; j++)
                {
                    Name += ((char)RN.Next(97, 123)).ToString();
                }
                ST[i].Name = Name;
                Score = RN.Next(0, 101);
                ST[i].Score = Score;
                textBox1.Text += i + ". " + ST[i].Name + ":" + ST[i].Score + Environment.NewLine;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int TempScore = 0;
            string TempName = null;
            textBox2.Clear();
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    for (int i = 0; i < numericUpDown1.Value; i++)
                    {
                        textBox2.Text += i + ". " + ST[i].Name + ":" + ST[i].Score + Environment.NewLine;
                    }
                    break;
                case 1:
                    for (int i= (int)(numericUpDown1.Value-1); i>=0; i--) //if i<0 byte 無法執行而會產生當掉的狀態
                    {
                        textBox2.Text += i + ". " + ST[i].Name + ":" + ST[i].Score + Environment.NewLine;
                    }
                    break;
                case 2://分數小->大
                    //Round
                    for (int i = 1; i < numericUpDown1.Value; i++)
                    {
                        //times
                        for (int j =1; j <= numericUpDown1.Value-i; j++)
                        {
                            if (ST[j - 1].Score > ST[j].Score)
                            {
                                TempScore = ST[j - 1].Score;
                                ST[j-1].Score = ST[j].Score;
                                ST[j].Score = TempScore;

                                TempName = ST[j - 1].Name;
                                ST[j - 1].Name = ST[j].Name;
                                ST[j].Name = TempName;
                            }
                        }
                    }
                    //顯示:由大排到小
                    for (int k = (int)numericUpDown1.Value - 1; k >= 0; k--)
                    {
                        textBox2.Text += k + ". " + ST[k].Name + ":" + ST[k].Score + Environment.NewLine;
                    }
                    break;
                case 3://姓名Z->A
                    //Round
                    for (int i = 1; i < numericUpDown1.Value; i++)
                    {
                        //times
                        for (int j = 1; j <= numericUpDown1.Value - i; j++)
                        {
                            if (string.Compare(ST[j - 1].Name, ST[j].Name) >0) 
                            {
                                TempScore = ST[j - 1].Score;
                                ST[j - 1].Score = ST[j].Score;
                                ST[j].Score = TempScore;

                                TempName = ST[j - 1].Name;
                                ST[j - 1].Name = ST[j].Name;
                                ST[j].Name = TempName;
                            }
                        }
                    }
                    for (int k =0 ; k < (int)numericUpDown1.Value; k++)
                    {
                        textBox2.Text += k + ". " + ST[k].Name + ":" + ST[k].Score + Environment.NewLine;
                    }
                    break;
                case 4:
                    for (int i = 1; i < numericUpDown1.Value; i++)
                    {
                        //times
                        for (int j = 1; j <= numericUpDown1.Value - i; j++)
                        {
                            if (ST[j - 1].Score > ST[j].Score)
                            {
                                TempScore = ST[j - 1].Score;
                                ST[j - 1].Score = ST[j].Score;
                                ST[j].Score = TempScore;

                                TempName = ST[j - 1].Name;
                                ST[j - 1].Name = ST[j].Name;
                                ST[j].Name = TempName;
                            }
                            if (ST[j - 1].Score == ST[j].Score)
                            {
                                for (int K = 1; K < numericUpDown1.Value; K++)
                                {
                                    //times
                                    for (int L = 1; L <= numericUpDown1.Value - i; L++)
                                    {
                                        if (string.Compare(ST[L - 1].Name, ST[L].Name) > 0)
                                        {
                                            TempName = ST[L - 1].Name;
                                            ST[L - 1].Name = ST[L].Name;
                                            ST[L].Name = TempName;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    for (int k = 0; k < (int)numericUpDown1.Value; k++)
                    {
                        textBox2.Text += k + ". " + ST[k].Name + ":" + ST[k].Score + Environment.NewLine;
                    }
                    break;
            }
        }
    }
}
