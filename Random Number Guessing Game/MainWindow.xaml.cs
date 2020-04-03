using System;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace Random_Number_Guessing_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public readonly Random random = new Random();
        public ViewModel viewModel = new ViewModel();

        const int MIN_NUMBER = 1;
        const int MAX_NUMBER = 101;
        const string OUTPUT_FILE = "GuessResults.txt";
        const string APPDATA_PATH = "GuessResults";

        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void TextBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            e.Handled = (e.Key < Key.D0 || (e.Key > Key.D9 && e.Key < Key.NumPad0) || e.Key > Key.NumPad9)
                       && (e.Key != Key.Back) && (e.Key != Key.Delete) &&
                       (e.Key != Key.Left) && (e.Key != Key.Right);
        }

        public void PLAY_Click(object sender, RoutedEventArgs e)
        {
            viewModel.RandomNumber = random.Next(MIN_NUMBER, MAX_NUMBER).ToString();
            Dragon.Opacity = 0;
            Dragon_Eye.Opacity = 1;
            Enter_Number.IsEnabled = true;
            Enter_Number.Opacity = 1;
            GuessedNumber.IsEnabled = true;
            GuessedNumber.Opacity = 1;
            Submit.IsEnabled = true;
            Submit.Opacity = 1;
            PlayAgain.IsEnabled = true;
            PlayAgain.Opacity = 1;
            GiveUp.IsEnabled = true;
            GiveUp.Opacity = 1;
            Previous_Numbers.IsEnabled = true;
            Previous_Numbers.Opacity = 1;
            Display_Data.IsEnabled = true;
            Display_Data.Opacity = 1;
            PLAY.IsEnabled = false;
            PLAY.Opacity = 0;
            Story.IsEnabled = false;
            Story.Opacity = 0;
            Rules.IsEnabled = false;
            Rules.Opacity = 0;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string filecontent = string.Empty;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullPath = Path.Combine(path, APPDATA_PATH);
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }
            fullPath = Path.Combine(fullPath, OUTPUT_FILE);
            try {
            if (int.Parse(viewModel.UserGuess) > int.Parse(viewModel.RandomNumber))
            {
                MessageBox.Show("Too high, try again");
                filecontent += viewModel.UserGuess + ",";
            }
            else if (int.Parse(viewModel.UserGuess) < int.Parse(viewModel.RandomNumber))
            {
                MessageBox.Show("Too low, try again");
                filecontent += viewModel.UserGuess + ",";
            }
            else
            {
                MessageBox.Show("Congrats!");
                filecontent += "Congrats!! The random number is: " + viewModel.RandomNumber + "\n";
            }
            }
            catch
            {
                MessageBox.Show("Invalid Number");
            }

            File.AppendAllText(fullPath, filecontent);
            viewModel.TextRead += viewModel.UserGuess + "\n";
        }

        private void GiveUp_Click(object sender, RoutedEventArgs e)
        {
            GuessedNumber.IsEnabled = false;
            Submit.IsEnabled = false;
            GiveUp.IsEnabled = false;
            MessageBox.Show(viewModel.RandomNumber);
        }

        private void PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            viewModel.RandomNumber = random.Next(MIN_NUMBER, MAX_NUMBER).ToString();
            Dragon.Opacity = 1;
            Dragon_Eye.Opacity = 0;
            Enter_Number.IsEnabled = false;
            Enter_Number.Opacity = 0;
            GuessedNumber.IsEnabled = false;
            GuessedNumber.Opacity = 0;
            Submit.IsEnabled = false;
            Submit.Opacity = 0;
            PlayAgain.IsEnabled = false;
            PlayAgain.Opacity = 0;
            GiveUp.IsEnabled = false;
            GiveUp.Opacity = 0;
            Previous_Numbers.IsEnabled = false;
            Previous_Numbers.Opacity = 0;
            Display_Data.IsEnabled = false;
            Display_Data.Opacity = 0;
            PLAY.IsEnabled = true;
            PLAY.Opacity = 1;
            Story.IsEnabled = true;
            Story.Opacity = 1;
            Rules.IsEnabled = true;
            Rules.Opacity = 1;
        }

        private void Story_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new Story();
        }

        private void Rules_Click(object sender, RoutedEventArgs e)
        {
           this.Content = new Rules();
        }
    }
}
