using System;

namespace WpfLab2.Input;

public static class DateUtils
{
    public static bool IsBirthdayToday(this DateTime date)
    {
        var now = DateTime.Today;
        return now.Month == date.Month && now.Day == date.Day;
    }
    
    public static bool IsValidBirthDate(this DateTime date)
    {
        var today = DateTime.Today;
        return today <= DateTime.Today && (date - today).Days / 365 < 135;
    }
}