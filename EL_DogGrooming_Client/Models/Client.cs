using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_DogGrooming_Client.Models
{
    class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string DogName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }        

        public override string ToString()
        {
            return "\nId: " + Id + "\nName: " + Name + "\nDog Name: " + DogName + "\nPhone: " + Phone + "\nEmail: " + Email;
        }
    }
}
