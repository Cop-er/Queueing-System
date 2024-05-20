using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace Queuing_System
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = @"C:\Users\Administrator\Downloads\Video\LeAnn Rimes - I Need You (Official Music Video).mp4";
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.settings.autoStart = true;
            axWindowsMediaPlayer1.settings.setMode("loop", true);
            axWindowsMediaPlayer1.Focus();
        }

        private void t1_TextChanged(object sender, EventArgs e)
        {
            TextBox typeText = sender as TextBox;
            string tableName = q1.Text;
            string numberText = typeText.Text;
            callNumber(tableName, numberText);
        }

        private void callNumber(string x1, string x2)
        {
            if (x2 != "") { 
            SpeechSynthesizer _ss = new SpeechSynthesizer();
            axWindowsMediaPlayer1.Ctlcontrols.pause();
            for (int i = 1; i<3; i++) { 
            string text = $" {x2}! Please Proceed to {x1}";
            _ss.Speak(text);
            }
            axWindowsMediaPlayer1.Ctlcontrols.play();
            axWindowsMediaPlayer1.Focus();
            }
        }

        private void t2_TextChanged(object sender, EventArgs e)
        {
            TextBox typeText = sender as TextBox;
            string tableName = q2.Text;
            string numberText = typeText.Text;
            callNumber(tableName, numberText);
        }

        private void t3_TextChanged(object sender, EventArgs e)
        {
            TextBox typeText = sender as TextBox;
            string tableName = q3.Text;
            string numberText = typeText.Text;
            callNumber(tableName, numberText);
        }

        private void t4_TextChanged(object sender, EventArgs e)
        {
            TextBox typeText = sender as TextBox;
            string tableName = q4.Text;
            string numberText = typeText.Text;
            callNumber(tableName, numberText);
        }

        private void t5_TextChanged(object sender, EventArgs e)
        {
            TextBox typeText = sender as TextBox;
            string tableName = q5.Text;
            string numberText = typeText.Text;
            callNumber(tableName, numberText);
        }

        private void t6_TextChanged(object sender, EventArgs e)
        {
            TextBox typeText = sender as TextBox;
            string tableName = q6.Text;
            string numberText = typeText.Text;
            callNumber(tableName, numberText);
        }

        private void t7_TextChanged(object sender, EventArgs e)
        {
            TextBox typeText = sender as TextBox;
            string tableName = q7.Text;
            string numberText = typeText.Text;
            callNumber(tableName, numberText);
        }
    }
}
