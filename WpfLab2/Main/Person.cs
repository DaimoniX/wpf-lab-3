using System;
using WpfLab2.Zodiac;

namespace WpfLab2.Main;

public class Person
{
    public string Name { private set; get; }
    public string Surname { private set; get; }
    public string Email { private set; get; }
    public DateTime BirthDate { private set; get; }
    
    public bool IsAdult { get; }
    public SunSign SunSign { get; }
    public ChineseSign ChineseSign { get; }
    public bool IsBirthday { get; }

    public Person(string name, string surname, string email, DateTime birthDate)
    {
        Name = name;
        Surname = surname;
        Email = email;
        if (birthDate > DateTime.Today)
            throw new ArgumentException("Invalid birthdate");
        BirthDate = birthDate;
        var today = DateTime.Today;
        IsAdult = (today - birthDate).Days / 365 > 17;
        IsBirthday = today.Day == birthDate.Day && today.Month == birthDate.Month;
        SunSign = ZodiacSign.GetSunSign(birthDate);
        ChineseSign = ZodiacSign.GetChineseSign(birthDate);
    }
    
    public Person(string name, string surname, DateTime birthDate) : this(name, surname, string.Empty, birthDate) {}

    public Person(string name, string surname, string email) : this(name, surname, email, DateTime.Today) {}

    /*
        IsAdult - який повертає true, якщо особа старше 18 років
        SunSign - традиційний західний сонячний знак цієї людини
        ChineseSign - китайський астрологічний знак цієї людини
        IsBirthday – який повертає true, якщо сьогодні день народження людини
    */
}