using System.Data.OleDb;
using System.Xml;

namespace Farm_Database
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

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
                string query = "SELECT * FROM Cow WHERE ID = ? UNION ALL " +
                               "SELECT * FROM Sheep WHERE ID = ? UNION ALL " +
                               "SELECT * FROM Goat WHERE ID = ?";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    // Bind the ID parameter to each SELECT statement
                    command.Parameters.AddWithValue("@ID1", id);
                    command.Parameters.AddWithValue("@ID2", id);
                    command.Parameters.AddWithValue("@ID3", id);

                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        // Check if a record with the given ID exists
                        if (reader.Read())
                        {
                            // Determine the animal type based on the table being queried
                            string animalType = "";

                            if (reader["ID"] != DBNull.Value)
                            {
                                // Determine the animal type based on the table name
                                if (reader.GetName(0).Contains("Cow"))
                                {
                                    animalType = "Cow";
                                }
                                else if (reader.GetName(0).Contains("Sheep"))
                                {
                                    animalType = "Sheep";
                                }
                                else if (reader.GetName(0).Contains("Goat"))
                                {
                                    animalType = "Goat";
                                }
                            }

                            // Retrieve and display animal information
                            double water = (double)reader["Water"];
                            double cost = (double)reader["Cost"];
                            double weight = (double)reader["Weight"];
                            string colour = (string)reader["Colour"];
                            double milk = (double)reader["Milk"];

                            // Display the information in the TextBox
                            txtAnimalInfo.Text = $"Animal Type: {animalType}\r\n" +
                                                 $"Water: {water}\r\n" +
                                                 $"Cost: {cost}\r\n" +
                                                 $"Weight: {weight}\r\n" +
                                                 $"Colour: {colour}\r\n" +
                                                 $"Milk: {milk}";
                            lblMessage.Text = ""; // Clear any previous messages

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

                                    // Calculate tax and profitability for each animal and update totals
                                    double taxPerAnimal = water * 0.02; // Example tax calculation
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
                            double taxPerAnimal = waterPerAnimal * 0.02; // Example tax calculation

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

            // Establish a connection to the database (replace connection string with your own)
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=FarmData.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
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
                            double milk = (double)reader["Milk"];

                            // Calculate cost, profit/loss for each animal, and update totals
                            double costPerDay = cost; // Example cost calculation
                            double profitLossPerDay = milk - cost; // Example profit/loss calculation

                            totalWeight += weight;
                            totalCostPerDay += costPerDay;
                            totalProfitLossPerDay += profitLossPerDay;
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
            // Get the selected table name from the ComboBox or RadioButton group
            string tableName = AnimalCombo.SelectedItem.ToString(); // Replace with your UI element

            // Get all livestock information from the TextBoxes or input controls
            double water = double.Parse(txtAWater.Text); // Replace with your UI element
            double cost = double.Parse(txtACost.Text); // Replace with your UI element
            double weight = double.Parse(txtAWeight.Text); // Replace with your UI element
            string color = txtAColour.Text; // Replace with your UI element

            // Generate a new unique ID based on existing IDs in the database
            int newID = GenerateUniqueID(tableName);

            if (newID > 0)
            {
                // Insert the new record into the selected database table
                InsertAnimal(tableName, newID, water, cost, weight, color);
                lblMessage.Text = "New livestock record has been added.";
            }
            else
            {
                lblMessage.Text = "Error generating a unique ID.";
            }
        }

        // Method to insert the new record into the specified table
        private void InsertAnimal(string tableName, int id, double water, double cost, double weight, string color)
        {
            // Establish a connection to the database (replace connection string with your own)
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=FarmData.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                // Insert the new record into the specified table
                string query = $"INSERT INTO {tableName} (ID, Water, Cost, Weight, Colour) " +
                               $"VALUES (?, ?, ?, ?, ?)";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@Water", water);
                    command.Parameters.AddWithValue("@Cost", cost);
                    command.Parameters.AddWithValue("@Weight", weight);
                    command.Parameters.AddWithValue("@Colour", color);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Record successfully inserted, display it in the TextBox
                        string insertedRecord = $"ID: {id}\r\n" +
                                                $"Water: {water}\r\n" +
                                                $"Cost: {cost}\r\n" +
                                                $"Weight: {weight}\r\n" +
                                                $"Colour: {color}";
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




        // Method to generate a new unique ID based on existing IDs in the specified table
        private int GenerateUniqueID(string tableName)
        {
            int newID = 1; // Initialize with a default value

            // Establish a connection to the database (replace connection string with your own)
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=FarmData.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                // Query the maximum ID value from the specified table
                string query = $"SELECT MAX(ID) FROM {tableName}";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        // If there are existing records, increment the maximum ID value
                        newID = Convert.ToInt32(result) + 1;

                    }
                }

                connection.Close();
            }

            return newID;
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            // Get the ID, selected attribute, and new value from the UI elements
            int id = int.Parse(textBox1.Text);
            string attributeName = InsertCombo.SelectedItem.ToString();
            double newValue = double.Parse(textBox2.Text);

            // Determine the table name based on the selected attribute
            string tableName = GetTableNameFromAttributeName(attributeName);

            if (tableName == null)
            {
                lblMessage.Text = "Invalid attribute.";
                return;
            }

            // Construct the SQL update query
            string query = $"UPDATE {tableName} SET {attributeName} = ? WHERE ID = ?";

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