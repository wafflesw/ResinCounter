//stuff that still needs to be done
//figure out how to make the picture box dragable
//design
//  Button customization
//  Text within the userinput
//  color of background
//  see if you can change the shape of the total resin box and timer box
//  


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace GUIEX2
{

    public partial class Form1 : Form
    {
        private bool _dragging = false;
        private Point _offest;
        private Point _start_point = new Point(0,0);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)//this is the start button
        {
            string currentResin = textBox1.Text;
            int currentResinValue = int.Parse(currentResin);
            if (currentResinValue > 160)
            {
                currentResinValue = 160;
            }
            else if (currentResinValue < 0)
            {
                currentResinValue = 0;
            }
            currentResin = currentResinValue.ToString();
            textBox4.Visible = true; //used to interact with the total resin box
            textBox4.Text = currentResin + "/160";
            TotalResinCounter.Enabled = true;

            int resinTimer = currentResinValue * 8; 
            resinTimer = 1280 - resinTimer;
            int resinMins = resinTimer % 60;
            int resinHours = resinTimer / 60;
            textBox3.Visible = true; //used to interact with the time left box
            textBox3.Text = resinHours.ToString() + ":" + resinMins.ToString() + ":00";
            TimeTillResinIsDone.Enabled = true;

            button1.Visible = true;
            button4.Visible = true;

            label1.Visible = false; // removes the orginal layout for the timer and the total resin
            textBox1.Visible = false;
            button3.Visible = false;
            button2.Visible = false;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        private void timer1_Tick(object sender, EventArgs e)//timer for the total resin count
        {
            string var = textBox4.Text;
            char[] seperator = { '/', ' ' };
            int count = 2;
            string[] strings = var.Split(seperator, count, StringSplitOptions.None);
            int currentResinValue = int.Parse(strings[0]);
            currentResinValue += 1;
            string strResinValue = currentResinValue.ToString();
            string combinedResinValue = strResinValue + "/" + strings[1];
            if (currentResinValue <= 160)
            {
                textBox4.Text = combinedResinValue;
            }
            else { TotalResinCounter.Enabled = false; }           
        }

        private void TimeTillResinIsDone_Tick(object sender, EventArgs e)//timer for the countdown timer
        {
            int s, m, h;
            bool timeron = true;
            string var = textBox3.Text;
            char[] seperator = { ':', ' ' };
            int count = 3;//look here if there are any problems
            string[] strings = var.Split(seperator, count, StringSplitOptions.None);
            s = int.Parse(strings[2]);
            m = int.Parse(strings[1]);
            h = int.Parse(strings[0]);
            if (h == 0 && m == 0 && s == 0)
            {
                TimeTillResinIsDone.Enabled = false;
                timeron = false;
            }
            if (timeron)
            {
                if (s <= 0)
                {
                    m--;
                    s = 60;
                }
                if (m <= 0)
                {
                    h--;
                    m = 59;
                }
                s--;
                string newtime = h.ToString() + ":" + m.ToString() + ":" + s.ToString();
                textBox3.Text = newtime;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//the reset button
        {
            textBox4.Visible = false;
            TotalResinCounter.Enabled = false;
            textBox3.Visible = false; 
            TimeTillResinIsDone.Enabled = false;
            button1.Visible = false;
            button4.Visible = false;

            label1.Visible = true;
            textBox1.Visible = true;
            button3.Visible = true;
            button2.Visible = true;

        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X,e.Y);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);

            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

    }
}
