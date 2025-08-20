# Base runtime image (ASP.NET runtime only)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Build image (SDK with compiler & tools)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project file and restore dependencies (better layer caching)
COPY Eventing.Web/*.csproj ./Eventing.Web/
RUN dotnet restore ./Eventing.Web/Eventing.Web.csproj

# Copy everything else and build
COPY . .
RUN dotnet publish ./Eventing.Web/Eventing.Web.csproj -c Release -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Eventing.Web.dll"]
