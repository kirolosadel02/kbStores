# Use the .NET SDK image for building the project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy only the project file and restore dependencies (faster builds)
COPY WebApi.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . . 
WORKDIR /src
RUN dotnet publish -c Release -o /app

# Use the ASP.NET runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "WebApi.dll"]
