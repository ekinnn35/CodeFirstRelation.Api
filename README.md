# CodeFirstRelation API

This project is an **ASP.NET Core Web API** application that creates a database using **Entity Framework Core (EF Core)** with the **Code First** approach. The project includes **User** and **Post** tables with a **one-to-many relationship**.

## 📌 Project Overview
- **User Table:** Contains user information.
- **Post Table:** Contains posts created by users. Each post belongs to a single user.
- **Database Name:** `PatikaCodeFirstDb2`
- **DbContext Class:** `PatikaSecondDbContext`
- **CRUD operations are performed via API.**

---

## 🚀 Installation Steps

### **1️⃣ Clone the Project or Create a New One**

```sh
git clone https://github.com/your_username/CodeFirstRelation.git
cd CodeFirstRelation.Api
```

If you created the project from scratch, you need to install the required packages.

### **2️⃣ Install Required Dependencies**

```sh
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

> 📌 **Note:** If using NuGet Package Manager, install the above packages via **Manage NuGet Packages**.

---

### **3️⃣ Configure Database Connection**
📂 Open **appsettings.json** and add the following connection string:

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=EKIN;Database=PatikaCodeFirstDb2;Trusted_Connection=True;TrustServerCertificate=True"
}
```

📂 Ensure that `DbContext` is registered in **Program.cs**:

```csharp
builder.Services.AddDbContext<PatikaSecondDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```

---

### **4️⃣ Run Migrations and Update Database**

Run the following commands to generate the database schema:

```sh
dotnet ef migrations add InitialCreate
dotnet ef database update
```

✅ **This will create the database and tables (`Users`, `Posts`).**

---

### **5️⃣ API Usage**

#### **User Endpoints**
| HTTP Method | Endpoint | Description |
|------------|---------|-------------|
| **GET** | `/api/User` | Retrieves all users |
| **POST** | `/api/User` | Adds a new user |

#### **Post Endpoints**
| HTTP Method | Endpoint | Description |
|------------|---------|-------------|
| **GET** | `/api/Post` | Retrieves all posts |
| **POST** | `/api/Post` | Adds a new post |


### **📌 Sample API Requests**

**Add a User:**
```json
POST /api/User
{
  "username": "ekin_user",
  "email": "ekin@example.com"
}
```

**Add a Post:**
```json
POST /api/Post
{
  "title": "Code First EF Core",
  "content": "This post is about EF Core.",
  "userId": 1
}
```


### **6️⃣ Troubleshooting**

🔹 If `dotnet ef` command is not working, try:
```sh
dotnet tool install --global dotnet-ef
dotnet tool update --global dotnet-ef
```

🔹 **If a `POST` request succeeds but `GET` does not return data:**
   - Run `SELECT * FROM dbo.Posts;` in SQL Server Management Studio to check if data exists.
   - Ensure that `SaveChanges()` is called.

🔹 If `GET /api/Post` is not returning data, ensure that `Include(p => p.User)` is used:

```csharp
[HttpGet]
public IActionResult GetPosts()
{
    var posts = _context.Posts.Include(p => p.User).ToList();
    return Ok(posts);
}
`
