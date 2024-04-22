using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace OctoCore.Models;

public class Member
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? MiddleName { get; set; }
    public string? Mail { get; set; }
    public string? PhoneNumber { get; set; }
    public DateOnly? Birthday { get; set; }
    public string? School { get; set; }
    public int? ClassNumber { get; set; }
    public char? ClassLetter { get; set; }
    public string? ClothingSize { get; set; }
    public string? FatherPhone { get; set; }
    public string? MotherPhone { get; set; }
    public string? Address { get; set; }
    
    // Create Only (can not be update)
    public string? OctoTeam { get; set; }        // ПК ПЦ КЦ ОЦ
    public string? Direction { get; set; }       // Python, 2D и т.д.
    public string? OctoRank { get; set; }        // искатель, талант и т.д.
    public int Octocoins { get; set; }          // Валюта

    public Member()
    {
        this.FirstName = "DefaultName";
        this.LastName = "DefaultSurname";
        this.Octocoins = 0;
    }

    public Member(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Octocoins = 0;
    }
    
    public Member(string firstName, string lastName, string middleName, string mail, string phoneNumber, 
        DateOnly birthday, string school, int classNumber, char classLetter, string clothingSize, 
        string fatherPhone, string motherPhone, string address, string octoTeam, string direction, 
        string octoRank)
    {
        this.Octocoins = 0;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.MiddleName = middleName;
        this.Mail = mail;
        this.PhoneNumber = phoneNumber;
        this.Birthday = birthday;
        this.School = school;
        this.ClassNumber = classNumber;
        this.ClassLetter = classLetter;
        this.ClothingSize = clothingSize;
        this.FatherPhone = fatherPhone;
        this.MotherPhone = motherPhone;
        this.Address = address;
        this.OctoTeam = octoTeam;
        this.Direction = direction;
        this.OctoRank = octoRank;
    }

    public Member Update(Member memberData)
    {
        return this;
    }
    
    // Update, Delete, Create 
}