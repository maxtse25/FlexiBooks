# FlexiBooks

**FlexiBooks** is a modular, full-stack ERP system built with **ASP.NET Core**, **Entity Framework Core**, and **React + TypeScript**. Designed to simulate real-world SME workflows, it provides core features such as client management, invoicing, and product catalog handling. The backend is deployed to **Microsoft Azure** and uses **GitHub Actions** for CI/CD automation.

---

## 🚀 Features

- 🌐 ASP.NET Core Web API backend with clean architecture and CQRS
- 🧾 Client, Product, and Invoice management
- 🔐 Secure role-based authentication (JWT)
- 📦 React + TypeScript frontend (WIP)
- ☁️ Azure App Service deployment
- 🔄 CI/CD with GitHub Actions
- 🧪 Unit and integration test coverage

---

## 🧱 Tech Stack

**Backend:**
- .NET 8, ASP.NET Core Web API
- Entity Framework Core
- MediatR, AutoMapper
- SQL Server (LocalDB or Azure SQL)

**Frontend (Planned):**
- React + TypeScript
- Axios, React Router, Material UI

**DevOps & Infra:**
- Microsoft Azure (App Services, SQL)
- GitHub Actions
- Docker (optional)

---

## 🛠️ Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/maxtse25/FlexiBooks.git
cd FlexiBooks
```

### 2. Setup the Backend
- Open the solution in Visual Studio.
- Configure your connection string in appsettings.json:
```
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=FlexiBooksDB;Trusted_Connection=True;"
}
```
- Apply EF Core migrations:
```
dotnet ef database update
```
- Run the project (F5 or dotnet run).

### 3. (Optional) Setup Frontend
```
cd frontend/flexibooks-ui
npm install
npm start
```

## 📁 Project Structure
```
FlexiBooks/
├── Controllers/           # API Controllers
├── Models/                # Domain Entities (Client, Invoice, etc.)
├── DTOs/                  # Data Transfer Objects
├── Data/                  # EF DbContext and Migrations
├── Services/              # Business Logic
├── Program.cs             # App entry and middleware config
├── appsettings.json       # Configs (DB, JWT, etc.)
└── README.md              # You're here!
```

## 📌 To Do
- Implement full frontend UI
- Add JWT Auth with refresh tokens
- Export invoice as PDF
- Integrate email notifications via SendGrid
- Extend to support payments and transaction logging

## 📄 License
This project is licensed under the MIT License.