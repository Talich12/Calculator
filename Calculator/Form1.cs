using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + (sender as Button).Text;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button_sign_Click(object sender, EventArgs e)
        {
            if (!DataBank.IsNegative)
            {
                textBox2.Text = '-' + textBox2.Text;
                DataBank.IsNegative = true;
            }
            else
            {
                textBox2.Text = textBox2.Text.Remove(0, 1);
                DataBank.IsNegative = false;
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox1.Text = "";
            DataBank.memory = 0;
            DataBank.code = -1;
            DataBank.a = 0;
            DataBank.b = 0;
            DataBank.IsNegative = false;
            DataBank.IsRealNumber = false;
            DataBank.IsSqrt = false;
        }

        private void button_clear_entry_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            DataBank.IsRealNumber = false;
            DataBank.IsNegative = false;
        }

        private void button_backspace_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length != 0)
            {
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1, 1);
            }
        }

        private void button_mamory_clean_Click(object sender, EventArgs e)
        {
            DataBank.memory = 0;
        }

        private void button_memory_read_Click(object sender, EventArgs e)
        {
            textBox2.Text = Convert.ToString(DataBank.memory);
        }

        private void button_memory_save_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                if (Char.IsDigit(textBox1.Text[textBox1.Text.Length - 1]))
                {
                    DataBank.memory = Convert.ToDouble(textBox1.Text);
                }
                else
                {
                    DataBank.memory = Convert.ToDouble(textBox2.Text.Substring(0, textBox2.Text.Length - 1));
                }
            }
        }

        private void button_memory_minus_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                DataBank.memory -= DataBank.a;
            }
        }

        private void button_memory_plus_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                if (Char.IsDigit(textBox1.Text[textBox1.Text.Length - 1]))
                {
                    DataBank.memory += Convert.ToDouble(textBox1.Text);
                }
                else
                {
                    DataBank.memory += Convert.ToDouble(textBox2.Text.Substring(0, textBox2.Text.Length - 1));
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad1:
                    button1.PerformClick();
                    break;
                case Keys.NumPad2:
                    button2.PerformClick();
                    break;
                case Keys.NumPad3:
                    button3.PerformClick();
                    break;
                case Keys.NumPad4:
                    button4.PerformClick();
                    break;
                case Keys.NumPad5:
                    button5.PerformClick();
                    break;
                case Keys.NumPad6:
                    button6.PerformClick();
                    break;
                case Keys.NumPad7:
                    button7.PerformClick();
                    break;
                case Keys.NumPad8:
                    button8.PerformClick();
                    break;
                case Keys.NumPad9:
                    button9.PerformClick();
                    break;
                case Keys.NumPad0:
                    button0.PerformClick();
                    break;
                case Keys.D1:
                    button1.PerformClick();
                    break;
                case Keys.D2:
                    button2.PerformClick();
                    break;
                case Keys.D3:
                    button3.PerformClick();
                    break;
                case Keys.D4:
                    button4.PerformClick();
                    break;
                case Keys.D5:
                    button5.PerformClick();
                    break;
                case Keys.D6:
                    button6.PerformClick();
                    break;
                case Keys.D7:
                    button7.PerformClick();
                    break;
                case Keys.D8:
                    button8.PerformClick();
                    break;
                case Keys.D9:
                    button9.PerformClick();
                    break;
                case Keys.D0:
                    button0.PerformClick();
                    break;
                case Keys.Back:
                    button_backspace.PerformClick();
                    break;
                case Keys.Add:
                    button_addition.PerformClick();
                    break;
                case Keys.Subtract:
                    button_substraction.PerformClick();
                    break;
                case Keys.Multiply:
                    button_multiplication.PerformClick();
                    break;
                case Keys.Divide:
                    button_division.PerformClick();
                    break;
                case Keys.Enter:
                    button_equality.PerformClick();
                    break;
                case Keys.Decimal:
                    button_comma.PerformClick();
                    break;
                case Keys.Delete:
                    button_clear.PerformClick();
                    break;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled= true;
        }

        private void button_comma_Click(object sender, EventArgs e)
        {
            if (!DataBank.IsRealNumber)
            {
                textBox2.Text += ',';
                DataBank.IsRealNumber = true;
            }
        }
    }
    
}
