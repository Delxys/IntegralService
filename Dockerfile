# Base dotnet image for building
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

# Set src directory
WORKDIR /src

# Copy src
COPY ./ .

# Restore
RUN dotnet restore testapp2.sln --configfile ./.nuget/nuget.config

# Build
RUN dotnet build testapp2.sln -c Release -o ./publish

# Expose app port
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000

ENTRYPOINT ["dotnet", "testapp2.dll"]