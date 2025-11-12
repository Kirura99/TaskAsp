# TaskAsp — Simple CRUD Website (ASP.NET Core MVC + EF Core)

A small web application for managing **clients**, **products**, and **orders**.  
Built as a test assignment using **ASP.NET Core MVC** and **Entity Framework Core (SQLite)**.

# Features

Full **CRUD** for:
  -  Clients 
  -  Products 
  -  Orders
    
Validatio with DataAnnotations and client-side scripts
LINQ
Cascade delete  when a client is deleted, all their orders are removed
MVC architecture

**Technologies**
C# / .NET 9
ASP.NET Core MVC
Entity Framework Core (SQLite)
LINQ
Bootstrap 5
jQuery Validate (client-side form validation)

HOW TO RUN:
git clone https://github.com/yourusername/TaskAsp.git
cd TaskAsp
dotnet restore
dotnet ef migrations add Init
dotnet ef database update
dotnet run

<img width="1645" height="561" alt="image" src="https://github.com/user-attachments/assets/267dfd58-5e50-49a6-b528-1db221292904" />

<img width="1637" height="763" alt="image" src="https://github.com/user-attachments/assets/42252047-ec22-40e9-b1ec-6e0d3ec66a04" />

<img width="1632" height="598" alt="image" src="https://github.com/user-attachments/assets/134a252d-7119-464a-94c6-cd526046bd6f" />
