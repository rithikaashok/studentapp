# Use the ASP.NET Core runtime as the base image for the final stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY ReactAspCRUDBackend.csproj .
RUN dotnet restore

# Copy everything else and build the application
COPY . .
RUN dotnet build -c Release -o /app/build

# Publish the application
RUN dotnet publish -c Release -o /app/publish

# Use the base image for the final stage and copy the published app
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

# Set the entry point for the container
ENTRYPOINT ["dotnet", "ReactAspCRUDBackend.dll"]
