﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace simpleCalcMP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    //FUNCTIONS
    //update display live [DONE]
    //decimal point [DONE]
    //clear all [DONE]
    //sqrt [DONE]
    //history
    //clear one char at a time
    public partial class MainWindow : Window
    {
        Button[] btnNums = new Button[10];
        double num1 = 0;
        double num2 = 0;
        double ope = -1;
        string charOpe = "";
        public MainWindow()
        {
            InitializeComponent();

            btnNums[0] = btn0;
            btnNums[1] = btn1;
            btnNums[2] = btn2;
            btnNums[3] = btn3;
            btnNums[4] = btn4;
            btnNums[5] = btn5;
            btnNums[6] = btn6;
            btnNums[7] = btn7;
            btnNums[8] = btn8;
            btnNums[9] = btn9;

            for (int x = 0; x < btnNums.Length; x++)
                btnNums[x].Content = x;

            btnAdd.Content = "+";
            btnMin.Content = "-";
            btnMult.Content = "x";
            btnDiv.Content = "/";
            btnEnter.Content = "=";
            btnClear.Content = "C";
            btnPoint.Content = ".";
            btnClearChar.Content = "<--";
            btnSqrt.Content = "x^2";

            tbAnswer.Text = "0";
        }
        private void numberEnter(string x)
        {
            string[] nums = new string[] { };
            string input = tbCalc.Text;
            input += x;

            if (ope == -1)
                num1 = double.Parse(input);
            else
            {
                nums = input.Split(charOpe[0]);
                num2 = double.Parse(nums[1]);
            }

            tbCalc.Text = input;
            displayAnswer();
        }

        #region KeypadEvents
        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            numberEnter("9");
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            numberEnter("8");
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            numberEnter("7");
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            numberEnter("6");
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            numberEnter("5");
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            numberEnter("4");
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            numberEnter("3");
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {

            numberEnter("2");
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {

            numberEnter("1");
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            numberEnter("0");
        }
        private void btnDec_Point(object sender, RoutedEventArgs e)
        {
            numberEnter("0.");
        }
        #endregion

        #region OperationEvents
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ope = 0;
            tbCalc.Text += "+";
            charOpe = btnAdd.Content.ToString();
        }

        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            ope = 1;
            tbCalc.Text += "-";
            charOpe = btnMin.Content.ToString();
        }

        private void btnMult_Click(object sender, RoutedEventArgs e)
        {
            ope = 2;
            tbCalc.Text += "*";
            charOpe = "*";
        }

        private void btnDiv_Click(object sender, RoutedEventArgs e)
        {
            ope = 3;
            tbCalc.Text += "/";
            charOpe = btnDiv.Content.ToString();
        }
        #endregion

        #region OtherButtons
        private void btnClear_Content(object sender, RoutedEventArgs e)
        {
            num1 = 0;
            num2 = 0;
            ope = -1;
            tbCalc.Text = "";
            displayAnswer();
        }
        private void btnClear_Char(object sender, RoutedEventArgs e)
        {
            string[] word = new string[] { };
            string tempWord = tbCalc.Text;
            tbCalc.Text = "";
            for (int i = 0; i < tempWord.Length - 1; i++)
                tbCalc.Text += tempWord[i];
        }
        private void btnSqrt_Click(object sender, RoutedEventArgs e)
        {
            double ans = 0;
            ans = Math.Sqrt(double.Parse(tbCalc.Text));
            num1 = ans;
            tbCalc.Text = num1.ToString();
            displayAnswer();
        }
        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            switch (ope)
            {
                case 0:
                    num1 += num2;
                    break;
                case 1:
                    num1 -= num2;
                    break;
                case 2:
                    num1 *= num2;
                    break;
                case 3:
                    num1 /= num2;
                    break;
            }

            displayAnswer();
            if (ope > -1)
            {
                tbCalc.Text = num1.ToString();
                ope = -1;
                num2 = 0;
            }
        }
        #endregion

        private void displayAnswer()
        {
            tbAnswer.Text = num1.ToString();

            if (tbCalc.Text.Length > 13)
                tbAnswer.Text = tbAnswer.Text.Substring(0, 13);
        }
    }
}