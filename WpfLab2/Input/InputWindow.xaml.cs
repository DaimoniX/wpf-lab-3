using System;
using System.Threading.Tasks;
using System.Windows;
using WpfLab2.Main;

namespace WpfLab2.Input;

public partial class InputWindow : Window
{
    private readonly InputViewModel _inputViewModel;
    public event EventHandler<Person>? OnPersonCreated;
    
    public InputWindow()
    {
        DataContext = _inputViewModel = new InputViewModel();
        InitializeComponent();
    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        if (_inputViewModel.BirthDate is null)
        {
            MessageBox.Show("", "Invalid date", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        
        if (_inputViewModel.BirthDate.Value.IsValidBirthDate())
        {
            if(_inputViewModel.BirthDate.Value.IsBirthdayToday())
                MessageBox.Show("Happy birthday!", "Congratulations", MessageBoxButton.OK, MessageBoxImage.Information);
            try
            {
                var person = await Task.Run(() => _inputViewModel.Calculate());
                OnPersonCreated?.Invoke(this, person);
                OnPersonCreated = null;
                Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Failed to create person", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
        else
        {
            MessageBox.Show("Age cannot be more than 135 or less than 0", "Invalid age", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}