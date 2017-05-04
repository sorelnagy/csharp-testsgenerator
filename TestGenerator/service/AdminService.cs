using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestGenerator.data.model;
using TestGenerator.DataAccessLayer;

namespace TestGenerator.data.service
{
    class AdminService
    {
        private Boolean testingAddUser = false;
        private Boolean testingReadUser = false;
        private Boolean testingUpdateUser = false;
        private Boolean testingDeleteUser = true;

        public void addUser()
        {
            if (!testingAddUser) return;

            //Test adding a user
            UserDataModel newUser = new UserDataModel("vasilescu","1233456","Vasilescu Patrascu", 1);

            UserDataGateway userGateway = new UserDataGateway();
            userGateway.add(newUser);
            
        }

        public void readUser()
        {
            if (!testingReadUser) return;

            //Test reading a user
            UserDataGateway userGateway = new UserDataGateway();

            UserDataModel user;
            user = userGateway.read(16);


            Console.WriteLine(user.Display_name);


        }


        public void updateUser()
        {
            if (!testingUpdateUser) return;

            //Test reading a user
            UserDataGateway userGateway = new UserDataGateway();


            UserDataModel user;

            user = userGateway.read(16);

            if (user != null) { 
            user.Display_name = "Schimbatul Ion";


            Console.WriteLine(user.Display_name);

            userGateway.update(user);

            } else{
                Console.WriteLine("User not found");
            }

            


        }


        public void deleteUser()
        {
            if (!testingDeleteUser) return;

            //Test reading a user
            UserDataGateway userGateway = new UserDataGateway();
                                  userGateway.delete(16);
           }

    }
       
}
