# Library Management System

A simple and secure ASP.NET Core Web API for managing books in a library. Built using Clean Architecture, JWT authentication, and full CRUD support for users and books.

---

##Feature..............................................................................

- ✅ User Registration & Login with JWT
- ✅ Secure password hashing using BCrypt
- ✅ JWT token versioning for invalidation on logout
- ✅ CRUD operations for books
- ✅ Search & pagination support for books
- ✅ Global exception handling middleware
- ✅ Consistent API responses using `ResultModel<T>`
- ✅ Swagger UI with JWT authorization support
- ✅ Seed data on startup (books + test user)

---

## 🧱 Architecture..........................................................................

Follows Clean Architecture with the following layers:

- `Domain`: Entity models
- `Application`: DTOs, interfaces, services
- `Infrastructure`: EF Core + repositories + Unit of Work
- `API`: Controllers, JWT logic, DI setup, middleware

### 🧩 Patterns Used..........................................................................

- Repository + Unit of Work
- DTO and Response Wrappers
- Global Error Handling Middleware
- Dependency Injection
- OpenAPI (Swagger) with JWT Auth

---

## 🛠 Tech Stack...........................................................................

- .NET 6 / ASP.NET Core
- Entity Framework Core
- SQL Server
- BCrypt.Net for hashing
- Swagger / OpenAPI

---

## 🚀 Getting Started......................................................................

### 1. **Clone the Project**
 ✅ git clone https://github.com/YourUsername/LibraryManagementSystem.git
 **NOTE**: Navigate to src/API folder and Open appsettings.Development.json and update the DefaultConnection string to your local SQL Server
        Ensure your SQL Server (e.g. via SSMS) is running before moving to **step 2**
        
### 2. **Navigate to API Folder**
cd LibraryManagementSystem/src/API

### 3. **Running the project**
  -First run command "dotnet restore"
  -Then run command "dotnet run"

from the src/API folder, the following happens automatically:
✅ EF Core Migrations: Any pending migrations are applied to the database.
✅ Seed Data: A test user and 15 books are inserted if not already present.
✅ Swagger UI is launched (for testing the API).

### 4.  **How to Access Swagger**
✅ Once the app is running, the terminal will display output like this:

Now listening on: https://localhost:5163
Now listening on: http://localhost:5164
Application started. Press Ctrl+C to shut down.

✅Copy the HTTPS address shown (e.g., https://localhost:5163) and paste it into your browser.

Then append /swagger to it, like this:
https://localhost:5163/swagger

This will open the Swagger UI where you can explore and test all the API endpoints.
💡 If you're using Postman instead of Swagger, also use this same base URL for your API calls

#### 5.**Configuration**
appsettings.json (src/API/appsettings.Development.json)
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=LibraryDb;Trusted_Connection=True;MultipleActiveResultSets=true"
}
✅ Change to match your local SQL Server setup if needed.

### 6.**Entity Framework**
✅ Migrations are automatically applied on startup.
✅ No need to run dotnet ef database update manually.

### 7.**Seeded Data**
✅ Includes test user + 15 law books for testing endpoints.
✅Test User (Seeded):
Email: testuser@example.com
Password: Password123

### 8. API ENDPOINTS 
POST /api/auth/register – Register a new user

POST /api/auth/login – Login and receive a JWT

POST /api/auth/logout – Logout and rotate token version(This invalidates token so it cant be used again after logout, user will need to log in again)

GET /api/books – Get all books (with search and pagination support) (authentication required)

GET /api/books/{id} – Get a book by ID (authentication required)

POST /api/books – Add a new book (authentication required)

PUT /api/books/{id} – Update a book (authentication required)

DELETE /api/books/{id} – Delete a book (authentication required)


### 9. **NOTE NOTE NOTE NOTE **.........................................................................
✅ dotnet run must be run from the src/API directory.

✅ Ensure to update the connection string in appsettings.Development.json to your own appsetting(SSMS was used)

✅ All error responses are returned in a structured ResultModel<T>.









