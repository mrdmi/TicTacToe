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
        private int player1Wins = 0;
        private int player2Wins = 0;
        private int deadHeat = 0;
        private string score;
        private bool firstMove = true;
        private int counter = 1; 
        public MainWindow()
        {
            InitializeComponent();
            score = player1Wins + " " + deadHeat + " " + player2Wins;
            scoreTextBlock.Text = "score\n" + score;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (TextBlock textBlock in gameField.Children.OfType<TextBlock>())
            {
                textBlock.Text = "";
                counter = 1;
                textBlock.MouseDown += TextBlock_MouseDown;
                textBlock.Foreground = Brushes.Black;
            }

            score = player1Wins + " " + deadHeat + " " + player2Wins;
            player1TextBlock.Text = "player 1";
            player2TextBlock.Text = "player 2";
            scoreTextBlock.Text = "score\n" + score;
            firstMove = !firstMove;
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
                if (CheckWinner()) return;
            }

            counter++;
            if(counter == 10)
            {
                TextBlockEventDisabler(true);
                deadHeat++;
            }
        }

        private bool CheckWinner()
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
                            GetTextBlock(i, j).Foreground = Brushes.Red;
                            GetTextBlock(i, j - 1).Foreground = Brushes.Red;
                            GetTextBlock(i, j - 2).Foreground = Brushes.Red;
                            return true;
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
                            GetTextBlock(j, i).Foreground = Brushes.Red;
                            GetTextBlock(j - 1, i).Foreground = Brushes.Red;
                            GetTextBlock(j - 2, i).Foreground = Brushes.Red;
                            return true;
                        }
                    }
                }
            }

            if (GetTextBlock(1, 0).Text == GetTextBlock(2, 1).Text && 
                GetTextBlock(2, 1).Text == GetTextBlock(3, 2).Text && 
                GetTextBlock(3, 2).Text != "")
            {
                Win();
                GetTextBlock(1, 0).Foreground = Brushes.Red;
                GetTextBlock(2, 1).Foreground = Brushes.Red;
                GetTextBlock(3, 2).Foreground = Brushes.Red;
                return true;
            }
            
            if (GetTextBlock(1, 2).Text == GetTextBlock(2, 1).Text &&
                GetTextBlock(2, 1).Text == GetTextBlock(3, 0).Text &&
                GetTextBlock(3, 0).Text != "")
            {
                Win();
                GetTextBlock(1, 2).Foreground = Brushes.Red;
                GetTextBlock(2, 1).Foreground = Brushes.Red;
                GetTextBlock(3, 0).Foreground = Brushes.Red;
                return true;
            }
            return false;
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
            TextBlockEventDisabler(true);
            if(counter % 2 == 1)
            {
                if (firstMove)
                {
                    player1Wins++;
                }
                else
                {
                    player2Wins++;
                }
            }
            else
            {
                if (firstMove)
                {
                    player2Wins++;
                }
                else
                {
                    player1Wins++;
                }
            }

        }

        private void TextBlockEventDisabler(bool on)
        {
            if (on)
            {
                foreach (TextBlock textBlock in gameField.Children.OfType<TextBlock>())
                {
                    textBlock.MouseDown -= TextBlock_MouseDown;
                }
            }
            else
            {
                foreach (TextBlock textBlock in gameField.Children.OfType<TextBlock>())
                {
                    textBlock.MouseDown += TextBlock_MouseDown;
                }
            }
        }
    }
}
