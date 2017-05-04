using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGenerator.data.model
{
    class UserDataModel
    {
        private int user_id;
        private String username;
        private String password;
        private String display_name;
        private int access_level;

        public UserDataModel(Int32 user_id, String username, String password, String display_name, int access_level)
        {
            this.User_id = user_id;
            this.Username = username;
            this.Password = password;
            this.Display_name = display_name;
            this.Access_level = access_level;

        }

        public UserDataModel(String username, String password, String display_name, int access_level)
        {
            this.Username = username;
            this.Password = password;
            this.Display_name = display_name;
            this.Access_level = access_level;

        }

        public int User_id
        {
            get
            {
                return user_id;
            }

            set
            {
                user_id = value;
            }
        }

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string Display_name
        {
            get
            {
                return display_name;
            }

            set
            {
                display_name = value;
            }
        }

        public int Access_level
        {
            get
            {
                return access_level;
            }

            set
            {
                access_level = value;
            }
        }



    }
}
