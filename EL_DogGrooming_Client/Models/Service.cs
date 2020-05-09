using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_DogGrooming_Client.Models
{

    public class Service
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    

        public override string ToString()
        {
            return "\nCode: " + Code + "\nDescription: " + Description + "\nPrice: " + Price;
        }

    }
}