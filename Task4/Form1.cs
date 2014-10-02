using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Task4
{
    enum States { Begin, Sum }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OutPut.Items.Clear();
            string[] input = InputText.Text.Split(' ');
            int MaxSum = 0;
            int CurSum = 0;
            int MinLength = Int32.MaxValue;
            int CurLength = 0;
            int MinStart = 0;
            int MinEnd = 0;
            int i = 0;
            int j = 0;
            int Len = input.Length;
            States State = States.Begin;
            do
            {
                int tmp;
                if (Int32.TryParse(input[i].Trim(), out tmp))
                {
                    switch (State)
                    {
                        case States.Begin:
                            CurSum = 0;
                            CurLength = 0;
                            break;
                        case States.Sum:
                            break;
                    }
                    CurSum += tmp;
                    CurLength++;
                    if (CurSum <= 0)
                    {
                        State = States.Begin;
                    }
                    else
                    {
                        State = States.Sum;
                        if (CurSum >= MaxSum)
                        {
                            if (CurSum > MaxSum)
                            {
                                MaxSum = CurSum;
                                MinLength = CurLength;
                                MinStart = j - CurLength + 1;
                                MinEnd = j;
                            }
                            else if (CurLength < MinLength)
                            {
                                MinLength = CurLength;
                                MinStart = j - CurLength + 1;
                                MinEnd = j;
                            }
                        }
                    }
                    j++;
                }
                i++;
            } while (i < Len);
            if (MaxSum == 0)
                OutPut.Items.Add("Отсутствуют элементы > 0");
            else
            {
                OutPut.Items.Add("Максимальная сумма = " + MaxSum.ToString());
                OutPut.Items.Add("Длина последовательности : " + MinLength.ToString());
                OutPut.Items.Add("Начало : " + MinStart.ToString());
                OutPut.Items.Add("Конец : " + MinEnd.ToString()); 
            }
        }

        private void InputText_TextChanged(object sender, EventArgs e)
        {
            OutPut.Items.Clear();
        }
    }
}
