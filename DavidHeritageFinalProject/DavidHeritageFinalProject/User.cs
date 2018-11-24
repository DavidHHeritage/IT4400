using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidHeritageFinalProject
{
    [Serializable]
    class User : Person
    {
        public User()
        {

        }
        public User(string name, double wage) : base(name, wage)
        {

        }

        private string billName;
        private double billAmount;

        public List<Bill> bills = new List<Bill>();

        public string BillName
        {
            get => billName;
            set => billName = value;
        }
        public double BillAmount
        {
            get => billAmount;
            set => billAmount = value;
        }
    }
}
