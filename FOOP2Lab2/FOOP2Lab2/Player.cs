using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOP2Lab2
{
    class Player
    {
        private string name;
        private DateTime dateOfBirth;
        private string category;
        private int age;

        #region Accessors
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }

            set
            {
                dateOfBirth = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value;
            }
        }

        #endregion

        public Player(string n, DateTime dob)
        {
            Name = n;
            DateOfBirth = dob;
            Age = ((new DateTime(2018, 8, 31) - DateOfBirth).Days)/365;
            
            Console.WriteLine(Age);
            setCategory(Age);
        }

        private void setCategory(int age)
        {
            if (age <= 10) category = "u10";
            else if (age <= 12) category = "u12";
            else if (age <= 14) category = "u14";
            else if (age <= 16) category = "u16";
            else if (age <= 18) category = "u18";
            else category = "Senior";
        }


        public override string ToString()
        {

            string catText = "";
            if (category == "u10") catText = "UNDER 10";
            else if (category == "u12") catText = "UNDER 12";
            else if (category == "u14") catText = "UNDER 14";
            else if (category == "u16") catText = "UNDER 16";
            else if (category == "u18") catText = "UNDER 18";
            else if (category == "Senior") catText = "Above 18";


            return string.Format("{0}, Age {1} ({2})",Name,Age,catText);
        }
    }
}
