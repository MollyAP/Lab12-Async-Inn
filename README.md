# Async Inn Management System

**Author**: Mollemira Porphura
**Version**: 1.0.0

## Overview
The Async Inn Management System is a web application that facilitates hotel management. It allows users to view, create, update, and delete hotel information, room details, and amenities. This application is built as an assignment for a 401 Level class, focusing on integrating a database schema and creating API routes using .NET Core.

## Getting Started
To build this app on your own machine and get it running, follow these steps:

1. Clone the repository from GitHub.
2. Ensure you have .NET Core SDK installed on your machine.
3. Set up the connection string in the `appsettings.json` file to point to your local database.
4. Open the project in your preferred Integrated Development Environment (IDE).
5. Build the project to restore NuGet packages and resolve dependencies.
6. Run migrations to create the database schema and seed data using the following commands in the terminal:

dotnet ef migrations add InitialMigration
dotnet ef database update

7. Run the application using `dotnet run` command in the terminal.

## Example
Once the application is up and running, you can use tools like Postman to interact with the API routes. For example:
- To get all hotels, make a GET request to `https://localhost:port/api/hotels`
- To create a new hotel, make a POST request to `https://localhost:port/api/hotels` with the required data in the request body.
- To update an existing hotel, make a PUT request to `https://localhost:port/api/hotels/{id}` with the updated data in the request body.
- To delete a hotel, make a DELETE request to `https://localhost:port/api/hotels/{id}`.

## Architecture
The Async Inn Management System is built using the following technologies:
- ASP.NET Core: A cross-platform, high-performance framework for building modern, cloud-based, and internet-connected applications.
- Entity Framework Core: An Object-Relational Mapping (ORM) framework for .NET Core used for database interaction.
- C#: The programming language used for the back-end logic and API routes.
- Razor Pages: Used for building user interfaces in the future phases of the project.


## Change Log

01-01-2023 4:59pm - Initial project setup, added database models, and created DbContext.

02-01-2023 2:30pm - Added migrations and seeded data for hotels, rooms, and amenities.

03-01-2023 9:45am - Implemented Hotel API controller with CRUD operations.

04-01-2023 5:20pm - Implemented Room API controller with CRUD operations.

05-01-2023 10:15am - Implemented Amenity API controller with CRUD operations.

06-01-2023 3:00pm - Completed API endpoints for all three entities. Application is functional and ready for testing.
