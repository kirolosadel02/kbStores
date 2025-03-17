# Use the official .NET SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the .NET project file(s)
COPY src/*.csproj ./src/
COPY src/Modules/*/*.csproj ./src/Modules/
COPY src/Shared/*.csproj ./src/Shared/

# Restore dependencies
RUN dotnet restore ./src/kbStores.csproj

# Copy the rest of the application code
COPY src/ ./src/

# Build the application
RUN dotnet publish ./src/kbStores.csproj -c Release -o /app

# Use the official .NET runtime image for running
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app .

# Expose the port the app will run on
EXPOSE 80

# Run the application
ENTRYPOINT ["dotnet", "kbStores.dll"]