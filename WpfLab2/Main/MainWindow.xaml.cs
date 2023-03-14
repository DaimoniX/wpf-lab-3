using System.Windows;
using WpfLab2.Input;

namespace WpfLab2.Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly PersonViewModel _personViewModel;
        
        public MainWindow()
        {
            DataContext = _personViewModel = new PersonViewModel();
            InitializeComponent();
        }

        private void ShowInputButton_OnClick(object sender, RoutedEventArgs e)
        {
            var inputWindow = new InputWindow();
            inputWindow.Show();
        }
    }
}