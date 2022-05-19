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

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private int counter; 
        public MainWindow()
        {
            InitializeComponent();
            SetUp();
        }

        private void SetUp()
        {
            counter = 1;

            foreach (TextBlock textBlock in gameField.Children.OfType<TextBlock>())
            {
                textBlock.Text = "&";
                textBlock.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SetUp();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;

            if (textBlock.Text != "&")
                return;

            if (counter % 2 == 1)
            {
                textBlock.Text = "❌";
            }
            else
            {
                textBlock.Text = "⭕";
            }

            textBlock.Visibility = Visibility.Visible;
            counter++;
        }
    }
}
