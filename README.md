🔗 URL Shortening Service – ASP.NET Core Web API
This project is a lightweight, production-style URL shortening service, built using ASP.NET Core Web API, Entity Framework Core, and a Clean Architecture pattern.

It showcases real-world API design, separation of concerns, secure redirection, and tracking statistics.

✅ Features
Shorten Long URLs with optional expiration dates

Redirect users from a short code to the original long URL

Track Stats – View click count, creation time, and expiration

Built with Clean Architecture (Domain, Application, Infrastructure, API)

RESTful API – Designed for easy testing in Postman or Swagger

SQL Server as the database (via Entity Framework Core)

📦 API Endpoints
🔹 POST /api/shorten – Shorten a URL
Request:
{
  "longUrl": "string"
}
Response:
{
  "success": true,
  "message": "Url Was Successfully Shortened.",
  "data": {
    "shortUrl": "https://yourdomain.com/odC8ruA"
  },
  "errors": null,
  "statusCode": 200,
  "totalCount": 0
}


🔹 GET /api/{shortUrl} – Redirect(NOTE REDIRECT WILL ONLY WORK IF TESTED ON POSTMAN NOT SWAGGER.............)
Redirects to the original long URL


🔹 GET /api/stats/{shortUrl} – View Statistics
Response:
{
  "success": true,
  "message": "Stats Retrieved Succesfully.",
  "data": {
    "accessCount": 4
  },
  "errors": null,
  "statusCode": 200
}

🚀 How to Run the Project
🧰 Prerequisites
.NET 6 SDK
SQL Server (LocalDB or Full SQL)
Postman or Swagger (for testing APIs)


📂 Setup Instructions
Clone the Repository
git clone https://github.com/your-username/UrlShorteningService.git
cd UrlShorteningService
Configure Database
Open appsettings.Development.json
Update the connection string:
"ConnectionStrings": {
  "DefaultConnection": "your-sqlserver-connection-string"
}
Apply Migrations & Run
dotnet ef database update
dotnet run
Test the Endpoints
Open Swagger: https://localhost:5001/swagger
Or use Postman

📁 Project Architecture

/Src
 ├── API            // Controllers, DTOs, Dependency Injection
 ├── Application    // Interfaces, DTOs, Services
 ├── Domain         // Entities 
 └── Infrastructure // EF Core, Repositories, Migrations

 
💡 What This Project Demonstrates
Clean separation of concerns

Generating unique short codes

Asynchronous DB operations with EF Core

Proper use of middleware and routing

Stateless, RESTful API structure

Real-world URL handling 
