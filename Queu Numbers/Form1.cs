using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleTCP;

namespace Queu_Numbers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string ipAddress = "192.168.4.109";
        private string portNumber = "8910";
        private string c1 = "";
        SimpleTcpClient client;

        private void button1_Click(object sender, EventArgs e)
        {
            passData("add");
        }

        private async void passData(string nk)
        {
            try
            {
                if (int.TryParse(label1.Text, out int number))
                {
                    label1.Text = "***";
                    this.Enabled = false;
                    await Task.Delay(1000);

                    int incrementedNumber = number;
                    if (nk == "add")
                    {
                        incrementedNumber = number + 1;
                    }
                    else if (nk == "sub")
                    {
                        incrementedNumber = number - 1;
                    }

                    scanRadio();

                    string message = $"{c1}:" + incrementedNumber.ToString();

                    client.WriteLineAndGetReply(message, TimeSpan.FromSeconds(2));
                    await Task.Delay(8000);
                    label1.Text = incrementedNumber.ToString();
                    this.Enabled = true;

                }
                else
                {
                    textBox1.Text += "Error: Invalid number format in label1" + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                textBox1.Text += $"Error: {ex.Message}" + Environment.NewLine;
            }
        }


        private void Client_DataReceived(object sender, SimpleTCP.Message e)
        {
            try { 
            string message = e.MessageString.Trim((char)client.Delimiter);
            textBox1.Invoke((MethodInvoker)delegate
            {
                textBox1.AppendText(message + Environment.NewLine);
            });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
            
        }

        private void startConnect()
        {
            try
            {
                int port = Convert.ToInt32(portNumber);
                client.Connect(ipAddress, port);
            }
            catch
            {
                MessageBox.Show($"Error: Queuing Main System is currently not running" + Environment.NewLine);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try {
                radioButton1.Checked = true;
            client = new SimpleTcpClient();
            client.StringEncoder = Encoding.UTF8;
            client.DataReceived += Client_DataReceived;
            startConnect();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            passData("sub");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            passData("");

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void scanRadio ()
        {

            TableLayoutPanel tableLayoutPanel3 = null;
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                if (control is TableLayoutPanel panel && control.Name == "tableLayoutPanel3")
                {
                    tableLayoutPanel3 = panel;
                    break;
                }
            }
            if (tableLayoutPanel3 != null)
            {
                foreach (Control control in tableLayoutPanel3.Controls)
                {
                    if (control is RadioButton radioButton && radioButton.Checked)
                    {
                        string selectedText = radioButton.Text;
                        c1 = selectedText;
                        return;
                    }
                }
            }
        }
    }
}
