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



    public partial class LRU : Form
    {

        Clist L, B;
        List<number> No = new List<number>();
        List<blocks> bl = new List<blocks>();
        Bitmap Bg = new Bitmap("Background.jpg");

        Bitmap off;
        int flagBL = 0;
        int TeqF = 0;
        int TeqO = 0;
        int TeqL = 0;
        int ct, NumFrames, p1 = 100, p2 = 50, pp1 = 105, pp2 = 55, id, min = 9999999, max = -9999999;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public LRU()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.Paint += LRU_Paint;
            this.Load += LRU_Load;
            this.KeyDown += LRU_KeyDown;

        }

        private void LRU_KeyDown(object sender, KeyEventArgs e)
        {
            L = new Clist();
            B = new Clist();
            Graphics g = this.CreateGraphics();
            if (e.KeyCode == Keys.NumPad0)
            {
                if (ct == 0)
                {
                    number n = new number();
                    n.num = 0;
                    n.id += 1;
                    No.Add(n);
                }

            }
            if (e.KeyCode == Keys.NumPad1)
            {
                if (ct == 0)
                {
                    number n = new number();
                    n.num = 1;
                    n.id += 1;
                    No.Add(n);
                }
                else if (ct == 1)
                {
                    NumFrames = 1;
                    ct++;
                }
            }
            if (e.KeyCode == Keys.NumPad2)
            {
                if (ct == 0)
                {
                    number n = new number();
                    n.num = 2;
                    n.id += 1;
                    No.Add(n);
                }
                else if (ct == 1)
                {
                    NumFrames = 2;
                    ct++;
                }
            }
            if (e.KeyCode == Keys.NumPad3)
            {
                if (ct == 0)
                {
                    number n = new number();
                    n.num = 3;
                    n.id += 1;
                    No.Add(n);
                }
                else if (ct == 1)
                {
                    NumFrames = 3;
                    ct++;
                }
            }
            if (e.KeyCode == Keys.NumPad4)
            {
                if (ct == 0)
                {
                    number n = new number();
                    n.num = 4;
                    n.id += 1;
                    No.Add(n);
                }
                else if (ct == 1)
                {
                    NumFrames = 4;
                    ct++;
                }
            }
            if (e.KeyCode == Keys.NumPad5)
            {
                if (ct == 0)
                {
                    number n = new number();
                    n.num = 5;
                    n.id += 1;
                    No.Add(n);
                }
                else if (ct == 1)
                {
                    NumFrames = 5;
                    ct++;
                }
            }
            if (e.KeyCode == Keys.NumPad6)
            {
                if (ct == 0)
                {
                    number n = new number();
                    n.num = 6;
                    n.id += 1;
                    No.Add(n);
                }
                else if (ct == 1)
                {
                    NumFrames = 6;
                    ct++;
                }
            }
            if (e.KeyCode == Keys.NumPad7)
            {
                if (ct == 0)
                {
                    number n = new number();
                    n.num = 7;
                    n.id += 1;
                    No.Add(n);
                }
                else if (ct == 1)
                {
                    NumFrames = 7;
                    ct++;
                }
            }
            if (e.KeyCode == Keys.NumPad8)
            {
                if (ct == 0)
                {
                    number n = new number();
                    n.num = 8;
                    n.id += 1;
                    No.Add(n);
                }
                else if (ct == 1)
                {
                    NumFrames = 8;
                    ct++;
                }
            }
            if (e.KeyCode == Keys.NumPad9)
            {
                if (ct == 0)
                {
                    number n = new number();
                    n.num = 9;
                    n.id += 1;
                    No.Add(n);

                }
                else if (ct == 1)
                {
                    NumFrames = 9;
                    ct++;
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (ct == 0)
                {
                    ct++;
                    MessageBox.Show("please enter the number of frames");
                }
                else
                {
                    for (int i = 0; i < No.Count; i++)
                    {
                        Console.WriteLine(No[i].num);
                    }
                    MessageBox.Show("please enter the Teq L for LRU");


                }

            }

            if (e.KeyCode == Keys.L)
            {
                TeqL = 1;
                flagBL = 1;
                CNode nm = new CNode();
                for (int i = 0; i < No.Count; i++)
                {
                    CNode pnn = new CNode();
                    CNode pll = new CNode();
                    pnn = L.ptail;
                    int ct1 = 0;
                    while (pnn != null)
                    {


                        if (pnn.info == No[i].num)
                        {
                            ct1++;
                            pnn.AttachId = id;
                            id++;
                            Console.WriteLine(pnn.info);
                            Console.WriteLine(pnn.AttachId);

                            break;

                        }
                        pnn = pnn.down;
                    }
                    if (ct1 == 0)
                    {


                        blocks x = new blocks();
                        x.x = p1;
                        x.y = p2;
                        x.W = 50;
                        x.H = 50 * NumFrames;
                        bl.Add(x);
                        for (int j = 0; j < NumFrames; j++)
                        {
                            CNode ptr = new CNode();
                            ptr.X = pp1;
                            ptr.Y = pp2;
                            ptr.W = 40;
                            ptr.H = 40;

                            ptr.IsActive = 1;
                            if (j == 0)
                            {
                                ptr.row = 1;
                                nm = ptr;
                                L.Attach(ptr);


                            }
                            else
                            {
                                if (j != NumFrames)
                                {
                                    nm.down = ptr;
                                }
                                ptr.up = nm;
                                nm = ptr;


                            }


                            pp2 += 50;
                        }
                        pp1 += 60;
                        pp2 = 55;
                        p1 += 60;


                        pnn = L.phead;
                        pll = L.ptail;
                        if (L.phead != L.ptail && bl.Count <= NumFrames)
                        {

                            while (pnn != null)
                            {
                                if (pnn.right.right == null)
                                {

                                    while (pll != null)
                                    {
                                        pll.info = pnn.info;
                                        pll.AttachId = pnn.AttachId;
                                        pll.check = pnn.check;
                                        pll = pll.down;
                                        pnn = pnn.down;
                                    }
                                    break;

                                }
                                pnn = pnn.right;
                            }


                        }
                        else if (bl.Count > NumFrames)
                        {
                            while (pnn != null)
                            {
                                if (pnn.right.right == null)
                                {
                                    CNode o = new CNode();
                                    o = pnn;
                                    int v = 0;
                                    int cct = 0;
                                    while (pll != null)
                                    {
                                        for (int vv = i; vv > 0; vv--)
                                        {
                                            if (No[vv].num == o.info && o.pid == 0)
                                            {
                                                o.pid = vv;
                                                cct++;
                                                break;
                                            }

                                        }
                                        pll = pll.down;
                                        o = o.down;
                                        if (cct == NumFrames)
                                        {
                                            break;
                                        }
                                    }
                                    o = pnn;
                                    while (o != null)
                                    {

                                        if (o.pid <= min)
                                        {
                                            min = o.pid;

                                            Console.WriteLine(o.pid);

                                        }

                                        else if (cct < NumFrames)
                                        {
                                            if (o.pid == 0 && o.AttachId < min)
                                            {
                                                //Console.WriteLine(o.pid);
                                                min = o.AttachId;


                                            }
                                        }
                                        o = o.down;
                                    }

                                    pll = L.ptail;
                                    o = pnn;
                                    while (pll != null)
                                    {
                                        pll.info = o.info;
                                        if (o.pid == min && v == 0)
                                        {

                                            pll.info = -1;

                                        }
                                        else
                                        {
                                            pll.AttachId = o.AttachId;

                                        }

                                        pll = pll.down;
                                        o = o.down;
                                    }
                                    break;

                                }
                                pnn = pnn.right;
                            }
                        }
                        max = -9999999;
                        min = 999999999;
                        pnn = L.ptail;
                        while (pnn != null)
                        {
                            Console.WriteLine(pnn.info);
                            if (pnn.info == -1)
                            {
                                if (No[i].num == 0)
                                {
                                    pnn.check = 1;
                                }
                                pnn.info = No[i].num;
                                pnn.AttachId = id;
                                id++;
                                Console.WriteLine(pnn.info);

                                break;
                            }
                            pnn = pnn.down;

                        }
                        pll = L.phead;

                        DrawDubb(CreateGraphics());
                    }

                }
            }
            if (flagBL == 1)
            {
                flagBL = 2;
            }
            DrawDubb(CreateGraphics());
        }

        private void LRU_Load(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            off = new Bitmap(ClientSize.Width, ClientSize.Height);
            MessageBox.Show("please enter the string of numbers and press enter");


            DrawDubb(CreateGraphics());
        }

        private void LRU_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(CreateGraphics());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {





        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        void DrawScene(Graphics g)
        {
            // g.Clear(Color.Black);
            // g.FillRectangle(Brushes.White, 50, 600, 400, 150);

            string b = bl.Count.ToString();
            string S = NumFrames.ToString();
            string hits = (No.Count - bl.Count).ToString();
            for (int i = 0; i < bl.Count; i++)
            {
                g.FillRectangle(Brushes.Cyan, bl[i].x, bl[i].y, bl[i].W, bl[i].H);
            }

            if (L != null)
            {
                CNode p = new CNode();
                CNode pb = new CNode();
                p = L.phead;
                string x;
                while (p != null)
                {
                    pb = p.down;
                    if (p.info == -1)
                    {
                        //  x = p.info.ToString();
                        g.FillRectangle(Brushes.Green, p.X, p.Y, p.W, p.H);

                    }
                    else
                    {
                        x = p.info.ToString();
                        g.FillRectangle(Brushes.RoyalBlue, p.X, p.Y, p.W, p.H);

                        g.DrawString(x, new Font("System", 16), Brushes.Red, p.X + 10, p.Y + 10);
                    }
                    while (pb != null)
                    {
                        if (pb.info == -1)
                        {

                            g.FillRectangle(Brushes.Yellow, pb.X, pb.Y, pb.W, pb.H);

                            pb = pb.down;
                        }
                        else
                        {
                            string xl = pb.info.ToString();
                            g.FillRectangle(Brushes.RosyBrown, pb.X, pb.Y, pb.W, pb.H);
                            g.DrawString(xl, new Font("System", 16), Brushes.Red, pb.X + 10, pb.Y + 10);
                            pb = pb.down;
                        }
                    }

                    p = p.right;
                }


                if (NumFrames != 0)
                {
                    g.DrawString("YOUR NUMBER OF FRAMES = " + S, new Font("Bold", 16), Brushes.Black, 50, this.ClientSize.Height - 125);



                }
                int l = 0;
                for (int i = 0; i < No.Count; i++)
                {
                    string s = No[i].num.ToString();
                    g.DrawString("YOUR STRING OF PAGES =", new Font("Bold", 16), Brushes.Black, 50, this.ClientSize.Height - 150);
                    g.DrawString(s, new Font("System", 16), Brushes.Black, 330 + l, this.ClientSize.Height - 150);

                    l += 15;


                }


            }

            if (flagBL == 2)
            {

                g.DrawString("YOUR PAGE FAULTS NUMBER = " + b, new Font("Bold", 16), Brushes.Black, 50, this.ClientSize.Height - 100);
                g.DrawString("YOUR PAGE HITS NUMBER = " + hits, new Font("Bold", 16), Brushes.Black, 50, this.ClientSize.Height - 80);
            }




        }
        void DrawDubb(Graphics g)
        {
            int Buff = No.Count - 14;
            Buff = Buff * 15;
            if (Buff < 0)
            {
                Buff = 0;
            }
            g.DrawImage(Bg, 0, 0, ClientSize.Width, ClientSize.Height);
            g.FillRectangle(Brushes.Black, 40, this.ClientSize.Height - 160, 520 + Buff, 160);
            g.FillRectangle(Brushes.White, 50, this.ClientSize.Height - 150, 500 + Buff, 150);
            if (TeqL == 1)
            {
                g.FillRectangle(Brushes.Black, 600 + Buff, this.ClientSize.Height - 160, 600, 160);
                g.FillRectangle(Brushes.White, 610 + Buff, this.ClientSize.Height - 150, 580, 150);
                // ENTERS IS THE FIRST VALUE TO SWAP OUT
                g.DrawString("LRU", new Font("Bold", 30), Brushes.White, 620 + Buff, this.ClientSize.Height - 200);
                g.DrawString(" THIS METHOD WORKS AS THE VAlUE WHICH  ", new Font("Bold", 16), Brushes.Black, 620 + Buff, this.ClientSize.Height - 150);
                g.DrawString(" HAVE BEEN LEAST RECENTLY USED IS TO SWAP OUT  ", new Font("Bold", 16), Brushes.Black, 620 + Buff, this.ClientSize.Height - 120);
                //MessageBox.Show("" + this.ClientSize.Width );
            }

            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }
    }



    public class number
    {
        public int num, id;

        public Color clr;


    }
    public class blocks
    {
        public int x, y, id, W, H;

        public Color clr;


    }

    public class CNode
    {
        public int X, Y, info = -1;
        public int W, H;
        public Color clr;
        public int IsActive, AttachId, row, column, pid, check;
        public CNode right = null, left = null, up = null, down = null;


    }
    public class Clist
    {

        public CNode phead;
        public CNode ptail;

        public Clist()
        {
            phead = null;
            ptail = null;
        }
        public void Attach(CNode pnn)
        {

            if (phead == null)
            {
                phead = ptail = pnn;
            }
            else
            {
                pnn.left = ptail;
                ptail.right = pnn;
                ptail = pnn;

            }

        }

    };
}
