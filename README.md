# SSO Service

This repository contains a Single Sign-On (SSO) service enabling centralized authentication for multiple applications. The service is built using **ASP.NET Core** and is designed for scalability, security, and extensibility.

## Features

- **JWT-based Authentication**
  - Stateless, secure authentication using JSON Web Tokens stored in cookies.
- **Cross-Application Authentication**
  - Allows users to sign in once and access all associated applications.
- **Role-Based Access Control (RBAC)**
  - Includes user roles in JWT for enforcing permissions at the service level.

## Technology Stack

- **Backend**: ASP.NET Core
- **Database**: MongoDB (via MongoDB Atlas or local deployment)
- **Authentication**: JWT

## Setup Instructions

### Prerequisites

- .NET 8.0 or later
- MongoDB (local or cloud-hosted)
- Postman or a similar API client for testing

### Running Locally

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/your-username/sso-service.git
   cd sso-service
   ```

2. **Set Up Configuration**:
   - Create an `appsettings.Development.json` file in the `SSOService` project folder with the following structure:
     ```json
     {
       "Jwt": {
         "Key": "your-secret-key",
         "Issuer": "https://sso.example.com",
         "Audience": "example.com"
       },
       "MongoDB": {
         "ConnectionString": "mongodb://localhost:27017",
         "Database": "SSOService"
       },
       "Cookie": {
         "Domain": "localhost"
       }
     }
     ```

3. **Restore Dependencies**:
   ```bash
   dotnet restore
   ```

4. **Run the Application**:
   ```bash
   dotnet run
   ```
   - The service will be available at `https://localhost:44361`.

5. **Testing**:
   - Use Postman to test the API endpoints (see [API Documentation](#api-documentation) below).

### API Documentation

#### **POST /api/users/register**
Register a new user.

- **Request Body**:
  ```json
  {
    "username": "testuser",
    "email": "testuser@example.com",
    "password": "securepassword"
  }
  ```
- **Response**:
  ```json
  {
    "statusCode": 200,
    "message": "User registered successfully."
  }
  ```

#### **POST /api/users/login**
Authenticate a user and issue a JWT.

- **Request Body**:
  ```json
  {
    "email": "testuser@example.com",
    "password": "securepassword"
  }
  ```
- **Response**:
  - The JWT is returned in a secure, HTTP-only cookie named `AuthToken`.

