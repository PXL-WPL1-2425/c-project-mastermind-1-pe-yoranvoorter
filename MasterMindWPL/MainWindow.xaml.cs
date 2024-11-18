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
using System.Windows.Threading;

namespace MasterMindWPL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<Color, string> _availableColors = new Dictionary<Color, string>();
        List<string> _code = new List<string>();
        int _attempts;
        private DispatcherTimer _timer = new DispatcherTimer();
        int _tick = 0;

        public MainWindow()
        {
            InitializeComponent();
            _attempts = 0;
            _timer.Interval = TimeSpan.FromSeconds(10);
            _timer.Tick += (s,o) =>
            {
                _tick++;
                if (_tick == 10)
                {
                    StopCountdown();
                    _tick = 0;
                }
            };

            AddColorsToDictionary();
            FillComboBoxes();
            GenerateRandomCode();
            this.Title = this.Title + $" poging {_attempts}";
            foreach (string code in _code)
            {
                txtDebug.Text = txtDebug.Text + $" {code}";
            }
        }

        /// <summary>
        /// toggles the debug mode. In debug mode, the color code will be shown.
        /// </summary>
        public void ToggleDebug()
        {
            if (txtDebug.Visibility == Visibility.Hidden)
            {
                txtDebug.Visibility = Visibility.Visible;
            }
            else
            {
                txtDebug.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Starts the timer countdown.
        /// </summary>
        public void StartCountdown()
        {
            _timer.Start();
        }

        /// <summary>
        /// Brings the timer countdown to a stop.
        /// </summary>
        public void StopCountdown()
        {
            _timer.Stop();
            _attempts += 1;
            this.Title = $" poging {_attempts}";
        }

        public void AddColorsToDictionary()
        {
            _availableColors.Clear();
            _availableColors.Add(Colors.Red, "Red");
            _availableColors.Add(Colors.Blue, "Blue");
            _availableColors.Add(Colors.Green, "Green");
            _availableColors.Add(Colors.Yellow, "Yellow");
            _availableColors.Add(Colors.Orange, "Orange");
            _availableColors.Add(Colors.White, "White");
        }

        public void GenerateRandomCode()
        {
            Random rand = new Random();
            for (int i = 0; i < 4; i++)
            {
                int j = rand.Next(0,4);
                _code.Add(_availableColors.ElementAt(j).Value);
            }
            StartCountdown();
        }

        public void FillComboBoxes()
        {
            foreach (KeyValuePair<Color, string> color in _availableColors)
            {
                cboColors1.Items.Add(color.Value);
                cboColors2.Items.Add(color.Value);
                cboColors3.Items.Add(color.Value);
                cboColors4.Items.Add(color.Value);
            }
        }

        private void cboColors1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Color color = _availableColors.FirstOrDefault(x => x.Value == cboColors1.SelectedItem).Key;
            ellipseColor1.Fill = new SolidColorBrush(color);
        }

        private void cboColors2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Color color = _availableColors.FirstOrDefault(x => x.Value == cboColors2.SelectedItem).Key;
            ellipseColor2.Fill = new SolidColorBrush(color);
        }

        private void cboColors3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Color color = _availableColors.FirstOrDefault(x => x.Value == cboColors3.SelectedItem).Key;
            ellipseColor3.Fill = new SolidColorBrush(color);
        }

        private void cboColors4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Color color = _availableColors.FirstOrDefault(x => x.Value == cboColors4.SelectedItem).Key;
            ellipseColor4.Fill = new SolidColorBrush(color);
        }

        private void btnCheckCode_Click(object sender, RoutedEventArgs e)
        {
            _attempts += 1;
            this.Title = $" poging {_attempts}";
            StartCountdown();

            if (_code[0] == cboColors1.SelectedItem)
            {
                ellipseColor1.Stroke = new SolidColorBrush(Colors.DarkRed);
            }
            else if (_code.Contains(cboColors1.SelectedItem))
            {
                ellipseColor1.Stroke = new SolidColorBrush(Colors.Wheat);
            }
            else
            {
                ellipseColor1.Stroke = null;
            }

            if (_code[1] == cboColors2.SelectedItem)
            {
                ellipseColor2.Stroke = new SolidColorBrush(Colors.DarkRed);
            }
            else if (_code.Contains(cboColors2.SelectedItem))
            {
                ellipseColor2.Stroke = new SolidColorBrush(Colors.Wheat);
            }
            else
            {
                ellipseColor2.Stroke = null;
            }

            if (_code[2] == cboColors3.SelectedItem)
            {
                ellipseColor3.Stroke = new SolidColorBrush(Colors.DarkRed);
            }
            else if (_code.Contains(cboColors3.SelectedItem))
            {
                ellipseColor3.Stroke = new SolidColorBrush(Colors.Wheat);
            }
            else
            {
                ellipseColor3.Stroke = null;
            }

            if (_code[3] == cboColors4.SelectedItem)
            {
                ellipseColor4.Stroke = new SolidColorBrush(Colors.DarkRed);
            }
            else if (_code.Contains(cboColors4.SelectedItem))
            {
                ellipseColor4.Stroke = new SolidColorBrush(Colors.Wheat);
            }
            else
            {
                ellipseColor4.Stroke = null;
            }
        }
    }
}
