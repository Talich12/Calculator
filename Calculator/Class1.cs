using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class DataBank
    {
        public static bool IsNegative = false;
        public static bool IsSqrt = false;
        public static bool IsRealNumber = false;
        public static double memory = 0;
        public static double a;
        public static double b;
        public static int code = -1;
    }
    partial class Form1
    {
        private void button_division_Click(object sender, EventArgs e)
        {
            if (!math.test(textBox2.Text))
            {
                return;
            }
            else
            {
                string text1 = textBox1.Text;
                string text2 = textBox2.Text;
                math.build(ref text1, ref text2, 4, '/');
                textBox1.Text = text1;
                textBox2.Text = text2;
            }
        }

        private void button_multiplication_Click(object sender, EventArgs e)
        {

            if (!math.test(textBox2.Text))
            {
                return;
            }
            else
            {
                string text1 = textBox1.Text;
                string text2 = textBox2.Text;
                math.build(ref text1, ref text2, 3, '*');
                textBox1.Text = text1;
                textBox2.Text = text2;
            }
        }

        private void button_substraction_Click(object sender, EventArgs e)
        {
            if (!math.test(textBox2.Text))
            {
                return;
            }
            else
            {
                string text1 = textBox1.Text;
                string text2 = textBox2.Text;
                math.build(ref text1, ref text2, 2, '-');
                textBox1.Text = text1;
                textBox2.Text = text2;
            }
        }

        private void button_addition_Click(object sender, EventArgs e)
        {
            if (!math.test(textBox2.Text))
            {
                return;
            }
            else
            {
                string text1 = textBox1.Text;
                string text2 = textBox2.Text;
                math.build(ref text1, ref text2, 1, '+');
                textBox1.Text = text1;
                textBox2.Text = text2;
            }
        }

        private void button_equality_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0 || !math.test(textBox2.Text))
            {
                return;
            }
            if (DataBank.code == -1 || DataBank.code == 0)
            {
                DataBank.a = Convert.ToDouble(textBox2.Text);
                textBox1.Text = Convert.ToString(DataBank.a);
                DataBank.code = 0;
                textBox2.Text = "";
                DataBank.IsRealNumber = false;
                DataBank.IsSqrt = false;
                DataBank.IsNegative = false;
            }
            else
            {
                DataBank.b = Convert.ToDouble(textBox2.Text);
                textBox1.Text = Convert.ToString(math.action(DataBank.a, DataBank.b));
                DataBank.a = Convert.ToDouble(textBox1.Text);
                DataBank.code = 0;
                textBox2.Text = "";
                DataBank.IsRealNumber = false;
                DataBank.IsSqrt = false;
                DataBank.IsNegative = false;
            }
        }

        private void button_sqrt_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0 || !math.test(textBox2.Text))
            {
                return;
            }
            else
            {
                DataBank.b = Math.Sqrt(Convert.ToDouble(textBox2.Text));
                textBox2.Text = Convert.ToString(DataBank.b);
            }
        }

        private void button_percent_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0 || !math.test(textBox2.Text))
            {
                return;
            }
            else
            {
                DataBank.b = Convert.ToDouble(textBox2.Text) / 100;
                textBox2.Text = Convert.ToString(DataBank.b);
            }
        }

        private void button_1_division_on_x_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0 || !math.test(textBox2.Text))
            {
                return;
            }
            else
            {
                DataBank.b = 1 / Convert.ToDouble(textBox2.Text);
                textBox2.Text = Convert.ToString(DataBank.b);
            }
        }
    }
    public static class math
    {
        public static double action(double a, double b)
        {
            double res = 0;
            switch (DataBank.code)
            {
                case 1:
                    res = DataBank.a + DataBank.b;
                    break;
                case 2:
                    res = DataBank.a - DataBank.b;
                    break;
                case 3:
                    res = DataBank.a * DataBank.b;
                    break;
                case 4:
                    res = DataBank.a / DataBank.b;
                    break;
            }
            return res;

        }
        public static void build(ref string text1, ref string text2, int code, char sign)
        {
            if (text1.Length != 0 || text2.Length != 0)
            {
                if (DataBank.code == 0)
                {
                    text1 += sign;
                    DataBank.code = code;
                }
                else if (text1.Length == 0)
                {
                    DataBank.a = Convert.ToDouble(text2);
                    text1 = Convert.ToString(DataBank.a) + sign;
                    DataBank.code = code;
                    text2 = "";
                    DataBank.IsRealNumber = false;
                }
                else if (text2.Length == 0)
                {
                    if (DataBank.code > 0)
                    {
                        DataBank.code = code;
                        text1 = text1.Substring(0, text1.Length - 1);
                        text1 += sign;
                    }
                }
                else
                {
                    DataBank.b = Convert.ToDouble(text2);
                    text1 = Convert.ToString(math.action(DataBank.a, DataBank.b));
                    DataBank.a = Convert.ToDouble(text1);
                    text1 += sign;
                    DataBank.code = code;
                    text2 = "";
                    DataBank.IsRealNumber = false;
                }
            }
        }
        public static bool test(string text)
        {
            if ((text.Length == 1 && (text[0] == '-' || text[0] == ',')) || (text.Length == 2 && text[0] == '-' && text[1] == ','))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
