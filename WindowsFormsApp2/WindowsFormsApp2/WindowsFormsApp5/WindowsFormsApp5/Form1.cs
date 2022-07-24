using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        int flag;
        int flag2 = 0;
        int ct = 0;
        int i;
        string y;
        string x;
        string z;
        class partation
        {
            public int x;
        }
        class processes
        {
            public int x;
        }
        class processes2
        {
            public int x, y;
        }
        List<processes2> FIFO = new List<processes2>();
        List<processes2> worst = new List<processes2>();
        List<processes2> best = new List<processes2>();
        List<partation> part1 = new List<partation>();
        List<partation> part2 = new List<partation>();
        List<partation> part3 = new List<partation>();
        List<processes> proc = new List<processes>();
        public Form1()
        {
            InitializeComponent();
        }
    
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num1 = 1;
            textBox1.Text += Convert.ToString(num1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("please enter the number of partations");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int num1 = 3;
            textBox1.Text += Convert.ToString(num1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int num1 = 5;
            textBox1.Text += Convert.ToString(num1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int num1 = 7;
            textBox1.Text += Convert.ToString(num1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int num1 = 2;
            textBox1.Text += Convert.ToString(num1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int num1 = 4;
            textBox1.Text += Convert.ToString(num1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int num1 = 6;
            textBox1.Text += Convert.ToString(num1);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int num1 = 8;
            textBox1.Text += Convert.ToString(num1);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int num1 = 9;
            textBox1.Text += Convert.ToString(num1);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int num1 = 0;
            textBox1.Text += Convert.ToString(num1);
        }
        int h = 1;
        int num3 = 0;
        int num4 = 0;
        int num5 = 0;
        int num6 = 0;
        int maxI;
        int minI;
        int max = -999;
        int min = 99999999;
        private void button11_Click(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                string z = null;
                z = textBox1.Text;
                for (i = 0; i < textBox1.TextLength; i++)
                {
                    y += z[i];
                }
            //    MessageBox.Show("" + i);

                num3 = Convert.ToInt32(y);
                if (num3 > 0)
                {
                    MessageBox.Show("now enter the size of each partation");
                    flag = 1;
                }
                else
                {
                    MessageBox.Show("please enter a positive number");
                }
            }
            else if (flag == 1)
            {
               
               

                    string z = textBox1.Text;
                    for (i = 0; i < textBox1.TextLength; i++)
                    {
                        y += z[i];
                    }
                    num4 = Convert.ToInt32(y);
                if (num4 > 0)
                {
                    partation pnn = new partation();
                    pnn.x = num4;
                    part1.Add(pnn);
                    partation pnn2 = new partation();
                    pnn2.x = num4;
                    part2.Add(pnn2);
                    partation pnn3 = new partation();
                    pnn3.x = num4;
                    part3.Add(pnn3);
                    h++;
                }


                else
                {
                    MessageBox.Show("please enter a positive number");
                }
                    if (h > num3)
                    {
                        h = 1;

                        MessageBox.Show("now enter the number of processes");
                        flag = 2;
                    }
                }
            
            else if (flag == 2)
            {
                string z = textBox1.Text;
                for (i = 0; i < textBox1.TextLength; i++)
                {
                    y += z[i];
                }
                num5 = Convert.ToInt32(y);
                if (num5 > 0)
                {
                    flag = 3;
                    MessageBox.Show("now enter the size of each process");
                }
                else
                {
                    MessageBox.Show("please enter a positive number");
                }
            }
            else if (flag == 3)
            {
               
               
                    string z = textBox1.Text;
                    for (i = 0; i < textBox1.TextLength; i++)
                    {
                        y += z[i];
                    }
                    num6 = Convert.ToInt32(y);
                    if (num6 > 0)
                    {
                        processes pnn = new processes();
                        pnn.x = num6;
                        proc.Add(pnn);
                        h++;
                    }
                    else
                    {
                        MessageBox.Show("please enter a positive number");
                    }
                    if (h > num5)
                    {

                        flag = 4;
                    }
                
            }
            if (flag == 4)
            {
                //for (int j = 0; j < proc.Count; j++)
                //{ MessageBox.Show("" + proc[j].x
                //    ); }
                // third we calculate the best fit
                //MessageBox.Show(proc.Count + "    " + part3.Count);
                for (int i = 0; i < proc.Count; i++)
                {
                    flag2 = 0;
                    min = 999999;
                    for (int j = 0; j < part3.Count; j++)
                    {
                        if (part3[j].x < min && part3[j].x >= proc[i].x)
                        {
                            min = part3[j].x;
                            minI = j;
                            flag2++;
                        }
                    }
                    if (flag2 != 0)
                    {
                        processes2 pnn = new processes2();
                        pnn.x = proc[i].x;
                        pnn.y = part3[minI].x;
                        best.Add(pnn);
                        part3[minI].x = part3[minI].x - proc[i].x;
                    }
                }
                // now we put each one of them in the richbox
               // MessageBox.Show("" + best.Count);
                for (int i = 0; i < best.Count; i++)
                {
                    richTextBox1.Text += (Convert.ToString(best[i].x) + " in " + Convert.ToString(best[i].y) + '\n');
                }
               
            }
            y = null;
            textBox1.Text = null;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
