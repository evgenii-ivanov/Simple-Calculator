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
using NCalc;

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private bool _isFail;

        public MainWindow()
        {
            InitializeComponent();
            _isFail = true;
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            if (btn == null)
                return;
            string btnValue = btn.Content.ToString();
            if (String.IsNullOrEmpty(btnValue))
                return;
            switch (btnValue)
            {
                case "C":
                    TextBoxMain.Text = "0";
                    _isFail = true;
                    break;
                case "=":
                    try
                    {
                        NCalc.Expression exp = new NCalc.Expression(TextBoxMain.Text);
                        TextBoxMain.Text = exp.Evaluate().ToString();
                    }
                    catch
                    {
                        TextBoxMain.Text = "Error";
                        _isFail = true;
                    }
                    break;
                default:
                    if (_isFail)
                    {
                        TextBoxMain.Text = "";
                        _isFail = false;
                    }
                    TextBoxMain.Text += btnValue;
                    break;
            }
        }
    }
}
