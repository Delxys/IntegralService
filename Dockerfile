###################################################################################
# Build
###################################################################################

# Base dotnet image for building
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

# Set src directory
WORKDIR /src

# Copy src
COPY ./ .

# Restore
RUN dotnet restore testapp2.sln

# Build
RUN dotnet publish testapp2.sln -c Release -o ./publish --no-restore

###################################################################################
# Prepare and execution
###################################################################################

FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine

# Set app directory
WORKDIR /app

# Add user/group with write permissions to work directory
# RUN adduser -S -D -H -u 1001 -s /sbin/nologin -G root -g user user
RUN addgroup -g 1000 -S user && \
    adduser -u 1000 -S user -G user -h "/app"

# Copy files with default permissions
COPY --from=build /src/publish .
 
# Grant read/write permissions
# RUN chgrp -R 0 /app 
# RUN chmod -R g+rX /app
RUN chmod -s /app

# Set work user
USER user

# Expose app port
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000
ENV ASPNETCORE_ENVIRONMENT=Development 

ENTRYPOINT ["dotnet", "testapp2.dll"]
