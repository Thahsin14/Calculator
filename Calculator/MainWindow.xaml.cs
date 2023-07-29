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
            float a = float.Parse(secondTopBox), b = float.Parse(topBox);
            Dictionary<string, Func<float, float, float>> functionDictionary = new Dictionary<string, Func<float, float, float>>();
            functionDictionary.Add("*", (a,b) => a * b);
            functionDictionary.Add("/", (a,b) => a / b);
            functionDictionary.Add("-", (a, b) => a - b);
            functionDictionary.Add("+", (a, b) => a + b);

            if(functionDictionary.TryGetValue(whatsChoosen,out var selectedFunction))
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

        private void zeroClick(object sender, RoutedEventArgs e)
        {
            topBox += 0;
            updateTopBox();
        }
        private void oneClick(object sender, RoutedEventArgs e)
        {
            topBox += 1;
            updateTopBox();
        }
        private void twoClick(object sender, RoutedEventArgs e)
        {
            topBox += 2;
            updateTopBox();
        }
        private void threeClick(object sender, RoutedEventArgs e)
        {
            topBox += 3;
            updateTopBox();
        }
        private void fourClick(object sender, RoutedEventArgs e)
        {
            topBox += 4;
            updateTopBox();
        }
        private void fiveClick(object sender, RoutedEventArgs e)
        {
            topBox += 5;
            updateTopBox();
        }
        private void sixClick(object sender, RoutedEventArgs e)
        {
            topBox += 6;
            updateTopBox();
        }
        private void sevenClick(object sender, RoutedEventArgs e)
        {
            topBox += 7;
            updateTopBox();
        }
        private void eightClick(object sender, RoutedEventArgs e)
        {
            topBox += 8;
            updateTopBox();
        }
        private void nineClick(object sender, RoutedEventArgs e)
        {
            topBox += 9;
            updateTopBox();
        }
        private void multiplyClick(object sender, RoutedEventArgs e)
        {
            whatsChoosen = "*";
            onOperation();
        }
        private void divideClick(object sender, RoutedEventArgs e)
        {
            whatsChoosen = "/";
            onOperation();
        }
        private void addClick(object sender, RoutedEventArgs e)
        {
            whatsChoosen = "+";
            onOperation();
        }
        private void minusClick(object sender, RoutedEventArgs e)
        {
            whatsChoosen = "-";
            onOperation();
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
