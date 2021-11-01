# Base dotnet image for building
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

# Set src directory
WORKDIR /src

# Copy src
COPY ./ .

# Restore
RUN dotnet restore testapp2.sln

# Build
RUN dotnet build testapp2.sln -c Release -o ./publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine

# Set app directory
WORKDIR /app

# Copy files with default permissions
COPY --from=build /src/publish .

# Expose app port
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000

ENTRYPOINT ["dotnet", "testapp2.dll"]