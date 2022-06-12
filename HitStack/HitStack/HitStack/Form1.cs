using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
namespace HitStack
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(Keys vKey);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        private const int PrimaryUp = 0x0004;
        private const int PrimaryDown = 0x0002;

        private const int SecondaryUp = 0x0010;
        private const int SecondaryDown = 0x0008;
        int Amount;
        int Delay;
        int Amount2;
        int Delay2;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void HitStack()
        {
            for (int i = 0; i<=Amount; i++)
            {
                mouse_event(dwFlags: PrimaryUp, dx: 0, dy: 0, cButtons: 0, dwExtraInfo: 0);
                mouse_event(dwFlags: PrimaryDown, dx: 0, dy: 0, cButtons: 0, dwExtraInfo: 0);
                i++;
            }
            Thread.Sleep(Delay);
        }
        private void HitStackRight()
        {
            for (int i = 0; i <= Amount2; i++)
            {
                mouse_event(dwFlags: SecondaryUp, dx: 0, dy: 0, cButtons: 0, dwExtraInfo: 0);
                mouse_event(dwFlags: SecondaryDown, dx: 0, dy: 0, cButtons: 0, dwExtraInfo: 0);
                i++;
            }
            Thread.Sleep(Delay2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            backgroundWorker1.RunWorkerAsync();
            Thread A = new Thread(HitStack);
            A.Start();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                

                if (checkBox1.Checked == true)
                {
                    if (Button.MouseButtons == MouseButtons.Left)
                    {
                        HitStack();
                    }
                    if (Button.MouseButtons == MouseButtons.Right)
                    {
                        HitStackRight();
                    }
                }
                if (GetAsyncKeyState(Keys.XButton2) < 0)
                {
                    checkBox1.Checked = true;
                }
                if (GetAsyncKeyState(Keys.MButton) < 0)
                {
                    checkBox1.Checked = false;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out Amount))
            {
                label6.Text = "Working";
            }
            else
            {
                label6.Text = "Int Number Required";
            }
            label5.Text = Convert.ToString(Amount);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out Delay))
            {
                label7.Text = "Working";
            }
            else
            {
                label7.Text = "Int Number Required";
            }
            label8.Text = Convert.ToString(Delay);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox4.Text, out Delay2))
            {
                label10.Text = "Working";
            }
            else
            {
                label10.Text = "Int Number Required";
            }
            label11.Text = Convert.ToString(Delay2);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox3.Text, out Amount2))
            {
                label13.Text = "Working";
            }
            else
            {
                label13.Text = "Int Number Required";
            }
            label14.Text = Convert.ToString(Amount2);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
