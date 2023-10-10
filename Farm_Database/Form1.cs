using System;
using System.Data.OleDb;
using System.Windows.Forms;
using Waher.Script.Constants;

namespace Farm_Database
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private OleDbConnection connection;
        
        private void btn_QueryId_Click(object sender, EventArgs e)
        {
            // Get the entered ID from the TextBox
            int id = int.Parse(txtID.Text);

            // Establish a connection to the database (replace connection string with your own)
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=FarmData.accdb;";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                // Query the database for the animal with the specified ID from all three tables
                string query = "SELECT * FROM Cow WHERE ID = ? " +
                               "UNION ALL SELECT * FROM Sheep WHERE ID = ? " +
                               "UNION ALL SELECT * FROM Goat WHERE ID = ?";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    // Bind the ID parameter to each SELECT statement
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@ID1", id);
                    command.Parameters.AddWithValue("@ID2", id);

                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        // Check if a record with the given ID exists
                        if (reader.Read())
                        {
                            // Determine the animal type based on the ID
                            int animalId = (int)reader["ID"];
                            string animalType = GetAnimalTypeFromId(animalId);

                            // Retrieve and display animal information
                            double water = (double)reader["Water"];
                            double cost = (double)reader["Cost"];
                            double weight = (double)reader["Weight"];
                            string colour = (string)reader["Colour"];
                            double characteristicValue = (double)reader["Milk"];

                            // Display the information in the TextBox
                            txtAnimalInfo.Text = $"Animal Type: {animalType}\r\n" +
                                                 $"Water: {water}\r\n" +
                                                 $"Cost: {cost}\r\n" +
                                                 $"Weight: {weight}\r\n" +
                                                 $"Colour: {colour}\r\n" +
                                                 $"Characteristic: {characteristicValue}";

                            lblMessage.Text = ""; // Clear any previous messages

                            // Set the label with the correct animal type
                            lblAnimalInfo.Text = $"Type: {animalType}\r\n";
                        }
                        else
                        {
                            // No record found with the given ID
                            txtAnimalInfo.Text = ""; // Clear the information TextBox
                            lblMessage.Text = "ID doesn't exist."; // Display appropriate message
                        }
                    }

                }

                connection.Close();
            }
        }

        private string GetAnimalTypeFromId(int id)
        {
            if (id >= 1000 && id < 2000)
            {
                return "Cow";
            }
            else if (id >= 2000 && id < 3000)
            {
                return "Goat";
            }
            else if (id >= 3000 && id < 4000)
            {
                return "Sheep";
            }

            // Default to an empty string if the ID doesn't match expected ranges
            return "";
        }


        private void btn_QueryColour_Click(object sender, EventArgs e)
        {
            // Get the entered color from the TextBox
            string colorToQuery = txtColour.Text.Trim(); // Assuming txtColour is a TextBox for color input.

            if (!string.IsNullOrEmpty(colorToQuery))
            {
                // Establish a connection to the database (replace connection string with your own)
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=FarmData.accdb;";
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // Query the database for animals with the specified color from all three tables
                    string query = $"SELECT * FROM Cow WHERE Colour = ? UNION ALL " +
                                   $"SELECT * FROM Sheep WHERE Colour = ? UNION ALL " +
                                   $"SELECT * FROM Goat WHERE Colour = ?";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        // Bind the color parameter to each SELECT statement
                        command.Parameters.AddWithValue("@Colour1", colorToQuery);
                        command.Parameters.AddWithValue("@Colour2", colorToQuery);
                        command.Parameters.AddWithValue("@Colour3", colorToQuery);

                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            // Check if any records match the entered color
                            if (reader.HasRows)
                            {
                                // Initialize variables to calculate percentage, tax, and profitability
                                int totalAnimals = 0;
                                double totalTax = 0.0;
                                double totalProfitLoss = 0.0;

                                while (reader.Read())
                                {
                                    // Process each matching record
                                    totalAnimals++;

                                    // Retrieve other relevant data for tax and profitability calculation
                                    double water = (double)reader["Water"];
                                    double cost = (double)reader["Cost"];
                                    double milk = (double)reader["Milk"];
                                    double weight = (double)reader["Weight"];

                                    // Calculate tax and profitability for each animal and update totals
                                    double taxPerAnimal = weight * 0.02; // Example tax calculation
                                    double profitLossPerAnimal = milk - cost; // Example profit/loss calculation

                                    totalTax += taxPerAnimal;
                                    totalProfitLoss += profitLossPerAnimal;
                                }

                                // Calculate percentage of animals
                                int totalNumberOfAnimals = GetTotalNumberOfAnimals(connection); // Call the function to get total number of animals

                                double percentage = (double)totalAnimals / totalNumberOfAnimals * 100.0;

                                // Display the results
                                txtAnimalInfo.Text = $"Percentage of {colorToQuery} animals: {percentage:F2}%\r\n" +
                                                     $"Total Government Tax per Day: ${totalTax:F2}\r\n" +
                                                     $"Total Profit/Loss per Day: ${totalProfitLoss:F2}";
                                lblMessage.Text = ""; // Clear any previous messages
                            }
                            else
                            {
                                // No records found with the given color
                                txtAnimalInfo.Text = ""; // Clear the information TextBox
                                lblMessage.Text = "No animals found with the entered color."; // Display appropriate message
                            }
                        }
                    }

                    connection.Close();
                }
            }
            else
            {
                // Empty color input
                txtAnimalInfo.Text = ""; // Clear the information TextBox
                lblMessage.Text = "Please enter a valid color."; // Display appropriate message
            }
        }

        // Function to retrieve the total number of animals from all three tables
        private int GetTotalNumberOfAnimals(OleDbConnection connection)
        {
            int totalAnimals = 0;

            // Query each table and sum the counts
            string query = "SELECT COUNT(*) FROM Cow UNION ALL " +
                           "SELECT COUNT(*) FROM Sheep UNION ALL " +
                           "SELECT COUNT(*) FROM Goat";

            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        totalAnimals += (int)reader[0];
                    }
                }
            }

            return totalAnimals;
        }

        private void btn_QueryType_Click(object sender, EventArgs e)
        {
            // Get the entered animal type from the TextBox (e.g., "cow", "goat", or "sheep")
            string animalType = txtType.Text.Trim().ToLower(); // Convert to lowercase for case-insensitive comparison

            // Establish a connection to the database (replace connection string with your own)
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=FarmData.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                double totalProducePerDay = 0.0;
                double totalWaterConsumedPerDay = 0.0;
                double totalTaxPerDay = 0.0;

                // Determine the table name based on the entered animal type
                string tableName = "";
                switch (animalType)
                {
                    case "cow":
                        tableName = "Cow";
                        break;
                    case "goat":
                        tableName = "Goat";
                        break;
                    case "sheep":
                        tableName = "Sheep";
                        break;
                    default:
                        // Invalid animal type
                        txtAnimalInfo.Text = ""; // Clear the information TextBox
                        lblMessage.Text = "Invalid animal type entered."; // Display appropriate message
                        connection.Close();
                        return;
                }

                // Query the database for animals of the specified type
                string query = $"SELECT * FROM {tableName}";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Retrieve relevant data for calculation
                            double producePerAnimal = 0.0;
                            double waterPerAnimal = 0.0;

                            // Determine produce and water consumption based on the animal type
                            if (tableName == "Cow" || tableName == "Goat")
                            {
                                producePerAnimal = (double)reader["Milk"];
                            }
                            else if (tableName == "Sheep")
                            {
                                producePerAnimal = (double)reader["Wool"];
                            }

                            waterPerAnimal = (double)reader["Water"];
                            double weight = (double)reader["Weight"];

                            // Calculate tax based on weight (replace 0.02 with your actual tax rate)
                            double taxPerAnimal = weight * 0.02;

                            // Update the totals
                            totalProducePerDay += producePerAnimal;
                            totalWaterConsumedPerDay += waterPerAnimal;
                            totalTaxPerDay += taxPerAnimal;
                        }
                    }
                }

                // Display the calculated information in the TextBox
                txtAnimalInfo.Text = $"Amount of {animalType} produce per day: {totalProducePerDay:F2}\r\n" +
                                     $"Total water amount consumed per day: {totalWaterConsumedPerDay:F2}\r\n" +
                                     $"Total government tax per day: {totalTaxPerDay:F2}";
                lblMessage.Text = ""; // Clear any previous messages

                connection.Close();
            }
        }

        private void btn_QueryWeight_Click(object sender, EventArgs e)
        {
            // Get the entered weight threshold from the TextBox
            double weightThreshold;

            if (!double.TryParse(txtWeight.Text, out weightThreshold) || weightThreshold <= 0)
            {
                // Invalid or non-positive weight threshold
                txtAnimalInfo.Text = ""; // Clear the information TextBox
                lblMessage.Text = "Please enter a valid positive weight threshold."; // Display appropriate message
                return;
            }

            // Declare the tableName variable
            string tableName = "";

            // Establish a connection to the database (replace connection string with your own)
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=FarmData.accdb;";
            using (connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                double totalWeight = 0.0;
                double totalCostPerDay = 0.0;
                double totalProfitLossPerDay = 0.0;
                int numberOfAnimalsAboveThreshold = 0;

                // Query the database for animals above the specified weight threshold from all three tables
                string query = $"SELECT * FROM Cow WHERE Weight > ? UNION ALL " +
                               $"SELECT * FROM Sheep WHERE Weight > ? UNION ALL " +
                               $"SELECT * FROM Goat WHERE Weight > ?";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    // Bind the weight threshold parameter to each SELECT statement
                    command.Parameters.AddWithValue("@Weight1", weightThreshold);
                    command.Parameters.AddWithValue("@Weight2", weightThreshold);
                    command.Parameters.AddWithValue("@Weight3", weightThreshold);

                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Retrieve relevant data for calculation
                            double weight = (double)reader["Weight"];
                            double cost = (double)reader["Cost"];
                            double water = (double)reader["Water"];
                            double producePerAnimal = (double)reader["Milk"];

     

                            if (tableName == "Cow" || tableName == "Goat")
                            {
                                producePerAnimal = (double)reader["Milk"];
                            }
                            else if (tableName == "Sheep")
                            {
                                producePerAnimal = (double)reader["Wool"];
                            }

                            // Calculate tax based on weight
                            double taxPerAnimal = weight * 0.02;
                            double waterPrice = water * 1.4;

                            // Calculate total cost for each animal
                            double totalCostPerAnimal = waterPrice + cost + taxPerAnimal;

                            // Hardcoded product costs
                            double productCost = (tableName == "Cow") ? 3.4 : ((tableName == "Goat") ? 4.55 : 3.2);

                            // Calculate profit/loss for each animal
                            double profitLossPerAnimal = (producePerAnimal * productCost) - totalCostPerAnimal;


                            // Update the totals
                            totalWeight += weight;
                            totalCostPerDay += totalCostPerAnimal;
                            totalProfitLossPerDay += profitLossPerAnimal;
                            numberOfAnimalsAboveThreshold++;
                        }

                    }
                }

                if (numberOfAnimalsAboveThreshold > 0)
                {
                    // Calculate average weight
                    double averageWeight = totalWeight / numberOfAnimalsAboveThreshold;

                    // Display the calculated information in the TextBox
                    txtAnimalInfo.Text = $"Average Weight of Animals Above Threshold: {averageWeight:F2}\r\n" +
                                         $"Total Operation Cost per Day: ${totalCostPerDay:F2}\r\n" +
                                         $"Total Profit/Loss per Day: ${totalProfitLossPerDay:F2}";
                    lblMessage.Text = ""; // Clear any previous messages
                }
                else
                {
                    // No animals found above the entered threshold
                    txtAnimalInfo.Text = ""; // Clear the information TextBox
                    lblMessage.Text = "No animals found above the entered weight threshold."; // Display appropriate message
                }

                connection.Close();
            }
        }

        private double GetProductCostFromCommodityTable(string animalType, string productType)
        {
            // Hardcoded values
            double goatMilkCost = 4.55;
            double cowMilkCost = 3.4;
            double sheepWoolCost = 3.2;

            // Use a switch statement to determine the product cost based on the product type
            switch (productType)
            {
                case "Milk":
                    return (animalType == "Goat") ? goatMilkCost : cowMilkCost;
                case "Wool":
                    return sheepWoolCost;
                default:
                    return 0.0; // Default to 0 for unknown product types
            }
        }






        private void btn_Delete_Click(object sender, EventArgs e)
        {
            // Get the entered ID from the TextBox
            int id;
            if (!int.TryParse(txtDeleteID.Text, out id))
            {
                lblMessage.Text = "Please enter a valid ID.";
                return;
            }

            // Check if the "Confirm Deletion" radio button is checked
            if (!radioConfirmDeletion.Checked)
            {
                lblMessage.Text = "Please confirm the deletion by checking the 'Confirm Deletion' radio button.";
                return;
            }

            // Call the DeleteAnimal method to delete the animal from the database
            DeleteAnimal(id);
        }


        private void DeleteAnimal(int id)
        {
            // Establish a connection to the database (replace connection string with your own)
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=FarmData.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                // Delete the animal record from the Cow table
                string cowQuery = "DELETE FROM Cow WHERE ID = ?";
                using (OleDbCommand cowCommand = new OleDbCommand(cowQuery, connection))
                {
                    cowCommand.Parameters.AddWithValue("@ID", id);

                    int cowRowsAffected = cowCommand.ExecuteNonQuery();

                    // Delete the animal record from the Goat table
                    string goatQuery = "DELETE FROM Goat WHERE ID = ?";
                    using (OleDbCommand goatCommand = new OleDbCommand(goatQuery, connection))
                    {
                        goatCommand.Parameters.AddWithValue("@ID", id);

                        int goatRowsAffected = goatCommand.ExecuteNonQuery();

                        // Delete the animal record from the Sheep table
                        string sheepQuery = "DELETE FROM Sheep WHERE ID = ?";
                        using (OleDbCommand sheepCommand = new OleDbCommand(sheepQuery, connection))
                        {
                            sheepCommand.Parameters.AddWithValue("@ID", id);

                            int sheepRowsAffected = sheepCommand.ExecuteNonQuery();

                            if (cowRowsAffected > 0 || goatRowsAffected > 0 || sheepRowsAffected > 0)
                            {
                                // Record successfully deleted from at least one table
                                lblMessage.Text = $"Animal with ID {id} has been deleted.";
                            }
                            else
                            {
                                // No record found with the given ID in any table
                                lblMessage.Text = $"No animal found with ID {id}.";
                            }
                        }
                    }
                }

                connection.Close();
            }
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            // Get the selected table name from the ComboBox
            string tableName = AnimalCombo.SelectedItem.ToString();

            // Get all livestock information from the TextBoxes or input controls
            double water = double.Parse(txtAWater.Text);
            double cost = double.Parse(txtACost.Text);
            double weight = double.Parse(txtAWeight.Text);
            string color = txtAColour.Text;
            double characteristicValue = double.Parse(txtACharacteristic.Text);

            // Generate a new unique ID based on existing IDs in the database
            int newID = GenerateUniqueID(tableName);

            if (newID > 0)
            {
                // Insert the new record into the selected database table
                InsertAnimal(tableName, newID, water, cost, weight, color, characteristicValue);
                lblMessage.Text = "New livestock record has been added.";
            }
            else
            {
                lblMessage.Text = "Error generating a unique ID.";
            }
        }

        // Method to insert the new record into the specified table
        private void InsertAnimal(string tableName, int id, double water, double cost, double weight, string color, double characteristicValue)
        {
            // Establish a connection to the database (replace connection string with your own)
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=FarmData.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                // Insert the new record into the specified table
                string query = $"INSERT INTO {tableName} (ID, Water, Cost, Weight, Colour, {GetCharacteristicColumnName(tableName)}) " +
               $"VALUES (?, ?, ?, ?, ?, ?)";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@Water", water);
                    command.Parameters.AddWithValue("@Cost", cost);
                    command.Parameters.AddWithValue("@Weight", weight);
                    command.Parameters.AddWithValue("@Colour", color);
                    command.Parameters.AddWithValue("@Characteristic", characteristicValue);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Record successfully inserted, display it in the TextBox
                        string insertedRecord = $"ID: {id}\r\n" +
                                                $"Water: {water}\r\n" +
                                                $"Cost: {cost}\r\n" +
                                                $"Weight: {weight}\r\n" +
                                                $"Colour: {color}\r\n" +
                                                $"Characteristic: {characteristicValue}";
                        txtAnimalInfo.Text = "New livestock record added:\r\n" + insertedRecord;
                        lblMessage.Text = "Record successfully inserted.";
                    }
                    else
                    {
                        // Error occurred during insertion
                        lblMessage.Text = "Error inserting the new record.";
                    }
                }

                connection.Close();
            }
        }
        // Method to get the characteristic column name based on the animal type
        private string GetCharacteristicColumnName(string tableName)
        {
            if (tableName.Contains("Cow") || tableName.Contains("Goat"))
            {
                return "Milk";
            }
            else if (tableName.Contains("Sheep"))
            {
                return "Wool";
            }

            // Handle the case where the animal type is unknown
            throw new InvalidOperationException("Unknown animal type");
        }


        // Method to check if an ID is already used in the specified table
        private bool IsIDUsed(int id, string tableName)
        {
            try
            {
                // Establish a connection to the database (replace connection string with your own)
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=FarmData.accdb;";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // Execute the query to check if the ID exists in the table
                    string query = $"SELECT COUNT(*) FROM {tableName} WHERE ID = {id}";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (log, display an error message, etc.)
                Console.WriteLine($"Error checking if ID is used: {ex.Message}");
                return false; // For simplicity, return false in case of an exception
            }
        }



        // Method to find the nearest unused ID in a given range
        private int FindNearestUnusedID(int baseID, int maxID, string tableName)
        {
            for (int i = baseID; i <= maxID + 1; i++)
            {
                // Check if the ID is already used in the specified table
                if (!IsIDUsed(i, tableName))
                {
                    return i;
                }
            }

            // This should not happen in normal circumstances, handle it as needed
            throw new Exception("Unable to find a unique ID.");
        }


        // Method to generate a new unique ID based on existing IDs in the specified table
        private int GenerateUniqueID(string tableName)
        {
            int baseID = 0;

            // Determine the base ID based on the type of animal
            if (tableName.Contains("Cow"))
            {
                baseID = 1000;
            }
            else if (tableName.Contains("Goat"))
            {
                baseID = 2000;
            }
            else if (tableName.Contains("Sheep"))
            {
                baseID = 3000;
            }

            // Use the baseID in the loop to find the nearest unused ID
            int newID = FindNearestUnusedID(baseID, baseID + 999, tableName);
            return newID;
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            // Get the ID, selected attribute, and new value from the UI elements
            int id = int.Parse(textBox1.Text);
            string attributeName = InsertCombo.SelectedItem as string;

            // Determine the table name and column name based on the selected attribute
            string tableName = GetTableNameFromAttributeName(attributeName);
            string columnName = GetColumnNameFromAttributeName(attributeName);

            if (tableName == null || columnName == null)
            {
                lblMessage.Text = "Invalid attribute.";
                return;
            }

            double newValue = double.Parse(textBox2.Text);

            // Construct the SQL update query
            string query = $"UPDATE {tableName} SET {columnName} = ? WHERE ID = ?";

            // Connect to the database and execute the update query
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=FarmData.accdb";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NewValue", newValue);
                    command.Parameters.AddWithValue("@ID", id);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Record successfully updated
                        lblMessage.Text = "Record updated successfully.";
                    }
                    else
                    {
                        // No record found with the given ID
                        lblMessage.Text = "No record found with the provided ID.";
                    }
                }

                connection.Close();
            }
        }

        // Method to get the column name based on the attribute name
        private string GetColumnNameFromAttributeName(string attributeName)
        {
            switch (attributeName)
            {
                case "Water":
                    return "Water";
                case "Weight":
                    return "Weight";
                case "Colour":
                    return "Colour";
                case "Cost":
                    return "Cost";
                case "Produce":
                    // Determine the characteristic column based on the animal type
                    string tableName = GetTableNameFromAttributeName(attributeName);
                    return GetCharacteristicColumnName(tableName);
                default:
                    return null; // Invalid attribute
            }
        }

        // Method to get the table name from the attribute name
        private string GetTableNameFromAttributeName(string attributeName)
        {
            switch (attributeName)
            {
                case "Water":
                case "Cost":
                case "Weight":
                case "Colour":
                case "Produce":
                    return "Cow"; // You can choose any table name here since all attributes are in all tables.
                default:
                    return null; // Invalid attribute
            }
        }

    }
}

