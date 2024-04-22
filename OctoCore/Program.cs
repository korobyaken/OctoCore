using System.Security.Policy;
using System.Text.Json;
using OctoCore.Models;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddA

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/Members", () =>
{
    List<Member> members;
    using (ApplicationContext db = new ApplicationContext())
    {
        members = db.Members.ToList();
    }

    return JsonSerializer.Serialize(members);
}).WithOpenApi();

app.MapGet("/Members/{id}", (int id) =>
{
    Member member;
    using (ApplicationContext db = new ApplicationContext())
    {
        member = db.Members.Find(id);
    }
    if(member != null)
        return Results.Json(member);
    return Results.NotFound(new {message = "Member not found"});
}).WithOpenApi();

app.MapGet("/Members/new", () =>
{
    Member member = new Member();
    using (ApplicationContext db = new ApplicationContext())
    {
        db.Members.Add(member);
        db.SaveChanges();
    }
    return member;
}).WithOpenApi();

app.MapDelete("/Members/{id}", (int id) =>
{
    Member member;
    using (ApplicationContext db = new ApplicationContext())
    {
        member = db.Members.Find(id);
        if(member == null)
            return Results.NotFound(new {message = "Member not found"});
        db.Members.Remove(member);
        db.SaveChanges();
        return Results.Json(member);
    }
}).WithOpenApi();

app.MapPost("/Members", (Member member) =>
{
    using (ApplicationContext db = new ApplicationContext())
    {
        db.Members.Add(member);
        db.SaveChanges();
    }
    return member;
}).WithOpenApi();

app.MapPut("/Members", (Member memberData) =>
{
    Member member;
    using (ApplicationContext db = new ApplicationContext())
    {
        member = db.Members.Find(memberData.Id);
        if(member == null)
            return Results.NotFound(new {message = "Member not found"});
        member.FirstName = memberData.FirstName;
        member.LastName = memberData.LastName;
        member.MiddleName = memberData.MiddleName;
        member.Mail = memberData.Mail;
        member.PhoneNumber = memberData.PhoneNumber;
        member.Birthday = memberData.Birthday;
        member.School = memberData.School;
        member.ClassNumber = memberData.ClassNumber;
        member.ClassLetter = memberData.ClassLetter;
        member.ClothingSize = memberData.ClothingSize;
        member.FatherPhone = memberData.FatherPhone;
        member.MotherPhone = memberData.MotherPhone;
        member.Address = memberData.Address;
        db.SaveChanges();
    }

    return Results.Json(member);
}).WithOpenApi();


app.Run();