using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class FCFCS : Form
    {
        DataTable table = new DataTable("table");
        int  head, totalMov;
        bool flagAllDone = false;
        char hold;
        char hold2;
        List<Num> Nums = new List<Num>();
        List<int> queue = new List<int>();
        List<int> movements = new List<int>();
        List<int> SortedMovements = new List<int>();
        public FCFCS()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
           // this.BackColor = Color.GreenYellow;
        }
        private void textBoxQueue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {

                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
            if (hold == (char)(Keys.Space) && e.KeyChar == (char)(Keys.Space))
            {
                e.Handled = true;
            }
            hold = e.KeyChar;

        }


        private void textBoxHead_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {

                e.Handled = true;
                //textBoxHead.Text += Convert.ToString(e.KeyChar);
            }
            else
            {
                e.Handled = false;
            }
            if (hold2 == (char)(Keys.Space) && e.KeyChar == (char)(Keys.Space))
            {
                e.Handled = true;
            }

            hold2 = e.KeyChar;

        }
        private void FCFs()
        {
            int d, cur_track, headTmp = head;
            movements.Add(headTmp);

            for (int i = 0; i < queue.Count(); i++)
            {
                cur_track = queue[i];
                d = Math.Abs(cur_track - headTmp);
                totalMov += d;
                headTmp = cur_track;
                movements.Add(headTmp);

            }
        }

        private void FCFCS_Load(object sender, EventArgs e)
        {
            table.Columns.Add("Order of served requests", Type.GetType("System.Int32"));
            dataGridView1.DataSource = table;
        }

        private void plot()
        {
            var font2 = new Font(FontFamily.GenericSansSerif, 15);
            Graphics g = CreateGraphics();
          //  g.Clear(Color.GreenYellow);
    

            g.DrawLine(
               new Pen(Color.White, 5),
              20, (this.ClientSize.Height / 2) - (150), this.ClientSize.Width - 20, (this.ClientSize.Height / 2) - (150));
            SortedMovements = new List<int>(movements);
            SortedMovements.Sort();
            float x = (this.ClientSize.Width - 20) - 20;

            x = x / (movements.Count());

            var font = new Font(FontFamily.GenericSansSerif, 20);
            float startx = 0;
            g.DrawString(0.ToString(), font, Brushes.White, 20, (this.ClientSize.Height / 2) - (190));
            g.DrawLine(
            new Pen(Color.Black, 3),
            30, (this.ClientSize.Height / 2) - (160), 30, (this.ClientSize.Height / 2) - (140));
            startx = startx + x;

            for (int i = 0; i < movements.Count; i++)
            {
                Num Num = new Num();
                Num.value = movements[i];
                Nums.Add(Num);
            }
            //int hx = 580;
            //for (int i = 0; i < Nums.Count; i++)
            //{
            //    g.DrawString(Nums[i].value.ToString(), font2, Brushes.Red, hx, 50);
            //    hx += 50;
            //}
            //MessageBox.Show(SortedMovements[movements.Count - 1].ToString());
            for (int i = 0; i < movements.Count; i++)
            {
                g.DrawLine(
                    new Pen(Color.Black, 3),
                    startx + 10, (this.ClientSize.Height / 2) - (160), startx + 10, (this.ClientSize.Height / 2) - (140));
                g.DrawString(SortedMovements[i].ToString(), font, Brushes.White, (startx)-10, (this.ClientSize.Height / 2) - 190);

                for (int j = 0; j < Nums.Count; j++)
                {
                    if (SortedMovements[i] == Nums[j].value)
                    {

                        Nums[j].x = startx;


                    }
                }

                startx += x;

            }
            float yval = 0;

            float y = (this.ClientSize.Height / 2) - (130);
            g.FillEllipse(Brushes.GreenYellow, Nums[0].x, (y - 5), 15, 15);

            for (int j = 0; j < Nums.Count; j++)
            {

                if (j + 1 < Nums.Count)
                {
                    g.FillEllipse(Brushes.GreenYellow, Nums[j + 1].x, (y + 45), 15, 15);
                    g.DrawLine(
                    new Pen(Color.Red, 3),
                    Nums[j].x, y, Nums[j + 1].x, (y + (50)));
                    
                    y += 50;


                }

            }
            for (int i = 0; i < Nums.Count; i++)
            {
                table.Rows.Add(Nums[i].value);

            }

        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            flagAllDone = false;
            totalMov = 0;
            movements.Clear();
            if (textBoxQueue.Text != "" &&
                textBoxHead.Text != "")
            {
                flagAllDone = true;
            }
            if (hold == (char)(Keys.Space) || hold2 == (char)(Keys.Space))
            {
                flagAllDone = false;
            }
            if (flagAllDone)
            {

                head = Int32.Parse(textBoxHead.Text);

                string diskQueue = textBoxQueue.Text;
                queue = diskQueue.Split(' ').Select(Int32.Parse).ToList();

                FCFs();



                label4.Text += totalMov + "";

                plot();
            }
            else
            {
                MessageBox.Show("The field cannot be empty. Please enter a value");
            }
        }
    }
    public class Num
    {
        public float value, x;
    }
}
