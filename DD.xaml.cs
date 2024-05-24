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
using System;
using System.Collections.Generic;
using System.IO;

namespace практика
{
    /// <summary>
    /// Логика взаимодействия для DD.xaml
    /// </summary>
    public partial class DD : Page
    {
        private int[,] _numbers;
        private int _width, _height;
        private int _currentNumber;
        private int _penalty;
        private bool _isHintShown;
        private string _recordsFile = "records.txt";
        private List<(int width, int height, int penalty, string player)> _records;

        public DD()
        {
            InitializeComponent();
            LoadRecords();
            NewGame();
        }

        private void NewGame()
        {
            _width = new Random().Next(5, 11);
            _height = new Random().Next(5, 11);
            _numbers = new int[_width, _height];
            SetupGrid();
            _currentNumber = 0;
            _penalty = 0;
            _isHintShown = false;
            UpdateUI();
        }

        private void SetupGrid()
        {
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var col = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            if (_numbers[col, row] == _currentNumber)
            {
                button.Content = _numbers[col, row].ToString();
                button.Foreground = Brushes.White;
                _currentNumber++;
                if (_currentNumber == _width * _height)
                {
                    MessageBox.Show($"Congratulations! You completed the game with {_penalty} penalty points.");
                    SaveRecord();
                    NewGame();
                }
                else if (_currentNumber == 1)
                {
                    ShowHint();
                }
                else
                {
                    ShowHint();
                }
            }
            else
            {
                _penalty++;
                UpdateUI();
            }
        }

        private void ShowHint()
        {
          
        }

        private void UpdateUI()
        {
           
        }

        private void BtnNewGame_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
        }

        private void SaveRecord()
        {
           
        }

        private void LoadRecords()
        {
           
               
        }

        private void SaveRecords()
        {
           
        }

        private string GetPlayerName()
        {
            var playerName = Microsoft.VisualBasic.Interaction.InputBox("Enter your name:", "Player Name", "", -1, -1);
            return string.IsNullOrWhiteSpace(playerName) ? "Anonymous" : playerName;
        }
    }

    public static class Extensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            var rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
    
