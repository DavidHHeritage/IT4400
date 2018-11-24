using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidHeritageFinalProject
{
    [Serializable]
    abstract class Person
    {
        private string name;
        private double wage;

        public Person()
        {

        }
        protected Person(string name, double wage)
        {
            this.name = name;
            this.wage = wage;
        }

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
        public double Wage
        {
            get
            {
                return wage;
            }
            set
            {
                wage = value;
            }
        }
    }
}
