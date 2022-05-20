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

        private int counter = 1; 
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (TextBlock textBlock in gameField.Children.OfType<TextBlock>())
            {
                textBlock.Text = "";
                counter = 1;
                textBlock.MouseDown += TextBlock_MouseDown;
            }
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;

            if (textBlock.Text != "")
                return;

            if (counter % 2 == 1)
            {
                textBlock.Text = "❌";
            }
            else
            {
                textBlock.Text = "⭕";
            }
            if (counter > 4)
            {
                CheckWinner();
            }
            counter++;
        }

        private void CheckWinner()
        {
        string temp = "";

            for (int i = 1; i < 4; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if(j == 0)
                    {
                        temp = GetTextBlock(i, j).Text;
                    }
                    else if(j == 1)
                    {                        
                        if(temp != GetTextBlock(i, j).Text)
                        {
                            break;
                        }
                    }
                    else
                    {
                        if(temp == GetTextBlock(i, j).Text && temp != "")
                        {
                            Win();
                        }
                    }
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    if (j == 1)
                    {
                        temp = GetTextBlock(j, i).Text;
                    }
                    else if (j == 2)
                    {
                        if (temp != GetTextBlock(j, i).Text)
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (temp == GetTextBlock(j, i).Text && temp != "")
                        {
                            Win();
                        }
                    }
                }
            }

            if (GetTextBlock(1,0).Text == GetTextBlock(2, 1).Text && 
                GetTextBlock(2, 1).Text == GetTextBlock(3, 2).Text && 
                GetTextBlock(3, 2).Text != "")
            {
                Win();
            }
            
            if (GetTextBlock(1, 2).Text == GetTextBlock(2, 1).Text &&
                GetTextBlock(2, 1).Text == GetTextBlock(3, 0).Text &&
                GetTextBlock(3, 0).Text != "")
            {
                Win();
            }
        }


        private TextBlock GetTextBlock(int row, int column)
        {
            foreach (TextBlock textBlock in gameField.Children.OfType<TextBlock>())
            {
                if (Grid.GetRow(textBlock) == row
                      &&
                   Grid.GetColumn(textBlock) == column)
                {
                    return textBlock;
                }
            }

            return null;
        }

        private void Win()
        {
            foreach (TextBlock textBlock in gameField.Children.OfType<TextBlock>())
            {
                textBlock.MouseDown -= TextBlock_MouseDown;
            }
        }
    }
}
