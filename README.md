# kbStores - Full Stack Application

This repository contains a **Flutter frontend**, a **.NET Core backend**, and required **database services (SQL Server, Redis)** running in Docker.

## 🛠 Prerequisites
Ensure you have the following installed on your system:
- [Docker](https://www.docker.com/get-started)
- [Docker Compose](https://docs.docker.com/compose/install/)

## 🚀 How to Start the Application

### 1️⃣ Clone the Repository
```sh
git clone https://github.com/your-repo/kbStores.git
cd kbStores
```

### 2️⃣ Start the Application with Docker
```sh
docker-compose up --build
```
This will:
- Build and start the **frontend** (Flutter)
- Build and start the **backend** (.NET Core Web API)
- Start **SQL Server** and **Redis**

### 3️⃣ Access the Application
- **Frontend**: http://localhost:5000
- **Backend Swagger UI**: http://localhost:8081/swagger/index.html
- **Database (SQL Server)**: localhost:1433

## 📡 API Connection in Flutter

Inside your Flutter app, ensure API calls use the backend container name (`backend`) instead of `localhost`:
```dart
const String baseUrl = 'http://backend:8081';
```
> ⚠️ **Do not use** `http://localhost:8081` inside the Flutter container, as `localhost` refers to the Flutter container itself.

## 🐳 Useful Docker Commands
- **Start the containers**: `docker-compose up -d`
- **Stop the containers**: `docker-compose down`
- **View logs**: `docker logs -f kbstores-backend-1`
- **Check running containers**: `docker ps`

## 🛠 Troubleshooting
### 1️⃣ Swagger UI is not accessible
- Check backend logs:
  ```sh
  docker logs -f kbstores-backend-1
  ```
- Verify that the backend is listening on `0.0.0.0:8081`
- Try restarting: `docker-compose restart backend`

### 2️⃣ Flutter Cannot Connect to the Backend
- Ensure you are using `http://backend:8081` instead of `http://localhost:8081`
- Try running inside the Flutter container:
  ```sh
  docker exec -it kbstores-frontend-1 sh
  curl http://backend:8081/swagger/index.html
  ```
  If this returns Swagger HTML, the connection is working!

## 📜 License
This project is licensed under the MIT License.

## 📞 Support
For issues, please open a GitHub issue or contact the maintainers.

