using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfLab2.Input;

public class InputViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    
    private string _name = string.Empty;
    private string _surname = string.Empty;
    private string _email = string.Empty;
    private bool _allFieldsSet = false;
    private DateTime? _birthDate = null;

    public DateTime BirthDate
    {
        get => _birthDate ?? DateTime.Today;
        set
        {
            if (value == _birthDate) return;
            _birthDate = value;
            OnPropertyChanged();
            CheckAllFields();
        }
    }
    
    public string Name
    {
        get => _name;
        set
        {
            if (value == _name) return;
            _name = value ?? throw new ArgumentNullException(nameof(value));
            OnPropertyChanged();
            CheckAllFields();
        }
    }

    public string Surname
    {
        get => _surname;
        set
        {
            if (value == _surname) return;
            _surname = value ?? throw new ArgumentNullException(nameof(value));
            OnPropertyChanged();
            CheckAllFields();
        }
    }

    public string Email
    {
        get => _email;
        set
        {
            if (value == _email) return;
            _email = value ?? throw new ArgumentNullException(nameof(value));
            OnPropertyChanged();
            CheckAllFields();
        }
    }

    public bool AllFieldsSet
    {
        get => _allFieldsSet;
        private set
        {
            _allFieldsSet = value;
            OnPropertyChanged();
        }
    }

    private void CheckAllFields()
    {
        AllFieldsSet = _name != string.Empty && _surname != string.Empty && _email != string.Empty && _birthDate != null;
        System.Diagnostics.Debug.WriteLine(_allFieldsSet);
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}