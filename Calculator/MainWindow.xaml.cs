using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string topBox { get; set; } = "";
        public string secondTopBox { get; set; } = "";
        public string whatsChoosen { get; set; } = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void updateTopBox()
        {
            oldResult.Text = secondTopBox;
            calcResult.Text = topBox;
            currentOperation.Text = whatsChoosen;
        }

        private void myResult()
        {
            if (!(secondTopBox == "" || secondTopBox == null || whatsChoosen == "" || whatsChoosen == null))
            {


                float a = float.Parse(secondTopBox), b = float.Parse(topBox);
                Dictionary<string, Func<float, float, float>> functionDictionary = new Dictionary<string, Func<float, float, float>>();
                functionDictionary.Add("*", (a, b) => a * b);
                functionDictionary.Add("/", (a, b) => a / b);
                functionDictionary.Add("-", (a, b) => a - b);
                functionDictionary.Add("+", (a, b) => a + b);

                if (functionDictionary.TryGetValue(whatsChoosen, out var selectedFunction))
                {
                    float result = selectedFunction(a, b);
                    clearAll();
                    topBox = result.ToString();
                    updateTopBox();
                }
                else
                {
                    MessageBox.Show("Something went wrong!");
                }
            }
        }

        private void clearAll()
        {
            topBox = secondTopBox = whatsChoosen = "";
            updateTopBox();
        }
        private void onOperation()
        {
            secondTopBox = topBox;
            topBox = "";
            updateTopBox();
        }
        private void buttonClicked(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            switch(clickedButton.Name)
            {
                case "zero":
                    topBox += 0;
                    break;
                case "one":
                    topBox += 1;
                    break;
                case "two":
                    topBox += 2;
                    break;
                case "three":
                    topBox += 3;
                    break;
                case "four":
                    topBox += 4;
                    break;
                case "five":
                    topBox += 5;
                    break;
                case "six":
                    topBox += 6;
                    break;
                case "seven":
                    topBox += 7;
                    break;
                case "eight":
                    topBox += 8;
                    break;
                case "nine":
                    topBox += 9;
                    break;
                case "comma":
                    topBox += ",";
                    break;

                case "deletePrevious":
                    topBox = topBox.Substring(0, topBox.Length - 1);
                    break;
                case "multiply":
                    whatsChoosen = "*";
                    onOperation();
                    break;
                case "divide":
                    whatsChoosen = "/";
                    onOperation();
                    break;
                case "plus":
                    whatsChoosen = "+";
                    onOperation();
                    break;
                case "minus":
                    whatsChoosen = "-";
                    onOperation();
                    break;
            }
            updateTopBox();
        }

        private void myResultClick(object sender, RoutedEventArgs e)
        {
            myResult();
        }
        private void clearAllClick(object sender, RoutedEventArgs e)
        {
            clearAll();
        }

    }
}
