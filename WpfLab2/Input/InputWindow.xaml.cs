using System;
using System.Windows;

namespace WpfLab2.Input;

public partial class InputWindow : Window
{
    private readonly InputViewModel _inputViewModel;
    
    public InputWindow()
    {
        DataContext = _inputViewModel = new InputViewModel();
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (_inputViewModel.BirthDate.IsValidBirthDate())
        {
            if(_inputViewModel.BirthDate.IsBirthdayToday())
                MessageBox.Show("Happy birthday!", "Congratulations", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
        else
        {
            MessageBox.Show("Age cannot be more than 135 or less than 0", "Invalid age", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}