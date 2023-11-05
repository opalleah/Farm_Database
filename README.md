# Farm Database

## Project Overview
This Farm Database project is part of a school project and was developed using Microsoft Visual Studio. The application is built using C# and Windows Forms with a primary focus on efficient data modeling and user-friendly functionalities.

The Farm Database is designed to help manage and maintain information about livestock and commodity prices on a farm. It provides a comprehensive set of features to assist farmers in their day-to-day operations.

## Functionality

### Data Modeling
- The application establishes a connection to a database.
- It utilizes classes to model table columns and loads table rows as objects in data structures.

### Livestock Data Listing
- The Farm Database displays information about all farm animals and commodity prices in tables with rows and columns.

### Livestock Statistics Reporting
- The application provides various reports:
  - Government tax on livestock.
  - Total profitability or loss for the farm.
  - Average weight of all farm animals.

### Query Farm Livestock
- Users can query farm animals based on different criteria:
  - Query by ID: Retrieve information about a farm animal using its unique ID.
  - Query by Colour: Display statistics based on the entered colour, including the percentage of animals and government tax paid.
  - Query by Type: Provide information about a selected animal type, including livestock produce per day and total water consumption.
  - Query by Weight: Select livestock above a specified weight threshold, calculating average weight, total operation cost, and profitability or loss per day.

### Database Operations
- Farmers can perform various database operations, including:
  - Delete a Row: Allows farmers to remove a record from the database when an animal dies.
  - Insert a New Row: Enables farmers to add new rows to the database tables for new livestock arrivals, generating IDs based on existing IDs.

## Getting Started
To get started with this Farm Database project, you will need Microsoft Visual Studio to open and run the application. Be sure to set up the required database connection before running the project.
