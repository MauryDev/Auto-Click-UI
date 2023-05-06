using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoClickAPP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            ((TextBox)sender).Text = e.KeyCode.ToString();
            e.SuppressKeyPress = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int result))
            {
                AutoClickEmbed.delay = result;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (Enum.TryParse(textBox2.Text,out Keys result))
            {
                AutoClickEmbed.keys[0] = result;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (Enum.TryParse(textBox3.Text, out Keys result))
            {
                AutoClickEmbed.keys[1] = result;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            AutoClickEmbed.enable = checkBox1.Checked;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
