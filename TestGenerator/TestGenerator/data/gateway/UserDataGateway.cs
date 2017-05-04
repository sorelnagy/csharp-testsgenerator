using System;
using DatabaseAccess;

using TestGenerator.data.model;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace TestGenerator.DataAccessLayer
{
    class UserDataGateway
    {

        private DatabaseConnection connection;


        public UserDataGateway(){
            this.connection = new DatabaseConnection();
            this.connection.openConnection();
         }


        public Boolean add(UserDataModel user)
        {
     
            string query = "INSERT INTO users (username, password, display_name, access_level) VALUES(@username,@password,@display_name,@access_level)";
            
            if (this.connection.openConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, this.connection.getConnection());

                cmd.Parameters.Add(new MySqlParameter("@username", user.Username));
                cmd.Parameters.Add(new MySqlParameter("@password", user.Password));
                cmd.Parameters.Add(new MySqlParameter("@display_name", user.Display_name));
                cmd.Parameters.Add(new MySqlParameter("@access_level", user.Access_level));

                cmd.ExecuteNonQuery();
                this.connection.closeConnection();

                return true;

            }

            return false;

        }

        //Get the user by user_id
        public UserDataModel read(int userId)
        {

            string query = "SELECT * FROM users WHERE user_id = @user_id  LIMIT 1";
            UserDataModel newUser = null;

            if (this.connection.openConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, this.connection.getConnection());

                cmd.Parameters.Add(new MySqlParameter("@user_id", userId));
                cmd.ExecuteNonQuery();
                
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    newUser = new UserDataModel(Int32.Parse(dataReader["user_id"].ToString()),dataReader["username"].ToString(), dataReader["password"].ToString(), dataReader["display_name"].ToString(), Int32.Parse(dataReader["access_level"].ToString()));
                    Console.WriteLine(newUser.Password.ToString());
                }
                
                this.connection.closeConnection();
            }

            return newUser;

        }

        //Get the yuser by username
        public UserDataModel read(String username)
        {

            string query = "SELECT * FROM users WHERE username = @user_name LIMIT 1";
            UserDataModel newUser = null;

            if (this.connection.openConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, this.connection.getConnection());

                cmd.Parameters.Add(new MySqlParameter("@user_name", username));

                cmd.ExecuteNonQuery();

                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Console.WriteLine(dataReader.Read().ToString());
                    newUser = new UserDataModel(Int32.Parse(dataReader["user_id"].ToString()),dataReader["username"].ToString(), dataReader["password"].ToString(), dataReader["display_name"].ToString(), Int32.Parse(dataReader["access_level"].ToString()));
                }

                this.connection.closeConnection();
            }

            return newUser;

        }

        //Get the yuser by username
        public List<UserDataModel> readAll()
        {

            string query = "SELECT * FROM users";
            List<UserDataModel> usersList = new List<UserDataModel>();
           
                         
            if (this.connection.openConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, this.connection.getConnection());
                cmd.ExecuteNonQuery();

                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Console.WriteLine(dataReader.Read().ToString());
                    usersList.Add(new UserDataModel(Int32.Parse(dataReader["user_id"].ToString()), dataReader["username"].ToString(), dataReader["password"].ToString(), dataReader["display_name"].ToString(), Int32.Parse(dataReader["access_level"].ToString())));
                }

                this.connection.closeConnection();
            }
            
            return usersList;

        }

        //Get the yuser by username
        public Boolean update(UserDataModel user)
        {

            string query = "UPDATE users SET password = @password, display_name = @display_name, access_level = @access_level WHERE user_id = @user_id";
            
            if (this.connection.openConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, this.connection.getConnection());

                cmd.Parameters.Add(new MySqlParameter("@password", user.Password));
                cmd.Parameters.Add(new MySqlParameter("@display_name", user.Display_name));
                cmd.Parameters.Add(new MySqlParameter("@access_level", user.Access_level));
                cmd.Parameters.Add(new MySqlParameter("@user_id", user.User_id));

                cmd.ExecuteNonQuery();
                this.connection.closeConnection();

                return true;
                              
            }

            return false;

        }

        //Get the yuser by username
        public Boolean delete(int userId)
        {

            string query = "DELETE FROM users WHERE user_id = @user_id";

            if (this.connection.openConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, this.connection.getConnection());
                cmd.Parameters.Add(new MySqlParameter("@user_id", userId));

                cmd.ExecuteNonQuery();
                this.connection.closeConnection();

                return true;

            }

            return false;

        }

    }
}
