using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidHeritageFinalProject
{
    [Serializable]
    class Bill
    {
        private string billName;
        private double billAmount;

        public Bill(string billName, double billAmount)
        {
            this.billName = billName;
            this.billAmount = billAmount;
        }

        public string BillName
        {
            get
            {
                return billName;
            }
            set
            {
                billName = value;
            }
        }
        public double BillAmount
        {
            get => billAmount;
            set => billAmount = value;
        }
    }
}
