# Blood Bank Management API

A RESTful API for managing blood bank operations using **ASP.NET Web API**. This project supports CRUD functionality, pagination, search capabilities, and Swagger UI integration.

---

## Getting Started

These instructions will help you set up and run the project locally for development and testing purposes.

---

## Prerequisites

Ensure your system meets the following requirements:

1. **Microsoft Visual Studio 2022** (or later)
   - Download from [Visual Studio](https://visualstudio.microsoft.com/).

2. **.NET 6 SDK** (or later)
   - Download from [.NET Downloads](https://dotnet.microsoft.com/download/dotnet/6.0).

3. API testing tools:
   - **Postman** (download from [Postman](https://www.postman.com/)) or
   - **Swagger UI** (automatically configured with the project).

---

## Installation

1. **Clone the Repository**
   ```bash
   git clone https://github.com/your-username/blood-bank-management.git
   cd blood-bank-management
   ```

2. **Open the Project**
   - Open the `BloodBankManagement.sln` file in **Microsoft Visual Studio**.

3. **Restore Dependencies**
   - Visual Studio will automatically restore dependencies. If not, run:
     ```bash
     dotnet restore
     ```

4. **Build the Solution**
   - Press `Ctrl + Shift + B` or go to **Build > Build Solution**.

5. **Run the Application**
   - Press `F5` or click **Start** to launch the application.

6. **Access Swagger UI**
   - Navigate to `https://localhost:<port>/swagger` in your browser (replace `<port>` with the displayed port in the console).

---

## Project Structure

### Files and Directories

- **Controllers**
  - `BloodBankController.cs`: Handles API endpoints for managing blood bank data.
- **Models**
  - `BloodBankEntry.cs`: Defines the blood bank entity structure.
- **appsettings.json**
  - Contains application-level configuration (e.g., database connection strings).
- **Program.cs**
  - Configures middleware, services, and the application's request pipeline.

---

## Features

1. **CRUD Operations**
   - Add, retrieve, update, and delete blood bank entries.

2. **Pagination**
   - Retrieve entries with efficient page-wise data fetching.

3. **Search**
   - Search for entries by donor name, blood type, or status.

4. **Swagger UI**
   - Test and explore API endpoints through an interactive interface.

---

## API Endpoints

### CRUD Operations

- **Create**: `POST /api/BloodBank`
- **Read All**: `GET /api/BloodBank`
- **Read by ID**: `GET /api/BloodBank/{id}`
- **Update**: `PUT /api/BloodBank/{id}`
- **Delete**: `DELETE /api/BloodBank/{id}`

### Pagination

- Example:
  ```http
  GET /api/BloodBank?page=1&size=10
  ```

### Search

- By donor name:
  ```http
  GET /api/BloodBank/search?donorName=Shrishti Singh
  ```
- By blood type:
  ```http
  GET /api/BloodBank/search?bloodType=A+
  ```

---

## Testing

### Swagger UI

Swagger is preconfigured and accessible at:
```plaintext
https://localhost:<port>/swagger
```

### Postman

Alternatively, you can test endpoints using **Postman**:
1. Import the API routes.
2. Use the sample JSON payloads below for testing.

---

## Sample JSON Payloads

### Create Entry
```json
{
  "donorName": "Shreya Singh",
  "age": 25,
  "bloodType": "O+",
  "contactInfo": "1234567890",
  "quantity": 450,
  "collectionDate": "2024-11-20",
  "expirationDate": "2024-12-20",
  "status": "Available"
}
```

### Update Entry
```json
{
  "donorName": "Amrita Singh",
  "age": 30,
  "bloodType": "A-",
  "contactInfo": "0987654321",
  "quantity": 500,
  "collectionDate": "2024-11-18",
  "expirationDate": "2024-12-18",
  "status": "Unavailable"
}
```

---

