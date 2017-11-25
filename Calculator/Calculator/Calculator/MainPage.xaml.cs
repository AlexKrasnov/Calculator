using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace Calculator
{
    public partial class MainPage : PhoneApplicationPage
    {
        private double memory = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TextBlock1.Text == "0" || TextBlock1.Text == "=" || TextBlock1.Text == "+" || TextBlock1.Text == "-" || TextBlock1.Text == "x" || TextBlock1.Text == "÷" || TextBlock1.Text == "^")
                TextBlock1.Text = "";
            TextBlock1.Text += (sender as Button).Content;
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            TextBlock1.Text += "*";
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            TextBlock1.Text += "/";
        }

        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            TextBlock1.Text = "0";
        }

        private void Button_Clear1(object sender, RoutedEventArgs e)
        {
            if (TextBlock1.Text != "0")
            {
                String s = TextBlock1.Text;
                s = s.Substring(0, s.Length - 1);
                TextBlock1.Text = s;
            }
        }

        private void Button_MS(object sender, RoutedEventArgs e)
        {
            int num;
            if (Int32.TryParse(TextBlock1.Text, out num))
                memory = Convert.ToInt32(TextBlock1.Text);
        }

        private void Button_MR(object sender, RoutedEventArgs e)
        {
            TextBlock1.Text = memory.ToString();
        }

        private void Button_MC(object sender, RoutedEventArgs e)
        {
            memory = 0;
        }

        private void Button_MMinus(object sender, RoutedEventArgs e)
        {
            int num;
            if (Int32.TryParse(TextBlock1.Text, out num))
                memory -= Convert.ToInt32(TextBlock1.Text);
        }

        private void Button_MPlus(object sender, RoutedEventArgs e)
        {
            int num;
            if (Int32.TryParse(TextBlock1.Text, out num))
                memory += Convert.ToInt32(TextBlock1.Text);
        }

        private bool BracketsCheck(string str)
        {
            Stack<char> brackets = new Stack<char>();
            str.ToCharArray();

            for (int i = 0; i < str.Length; i++)
                if (str[i] == '(')
                    brackets.Push(str[i]);
                else if (str[i] == ')' && brackets.Count != 0)
                    brackets.Pop();
                else if (brackets.Count == 0 && str[i] == ')')
                    return false;
            return brackets.Count == 0;
        }

        private void Button_Calculate(object sender, RoutedEventArgs e)
        {
            TextBlock1.Text += (sender as Button).Content;
            if (BracketsCheck(TextBlock1.Text))
            {
                TextBlock1.Text = Calculator.Calculate(TextBlock1.Text).ToString();
            }
        }
    }
}