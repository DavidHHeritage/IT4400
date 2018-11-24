using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Win32;
namespace DavidHeritageFinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String currentFilePath = "new.budget";
        //private float wage;


        List<Bill> billList = new List<Bill>();
        public double totalBillCost = 0;
        public MainWindow()
        {
            InitializeComponent();
        }


        private void AddBillButton_Click(object sender, RoutedEventArgs e)
        {
            double cost;
            double n;
            try
            {
                string result = CostTextBox.Text;
                if (!(double.TryParse(result, out n)))
                {
                    throw new cost_Exception(string.Format("Cost"));
                }
                else if (n < 0)
                {
                    throw new cost_Exception(string.Format("Cost"));
                }
                cost = double.Parse(CostTextBox.Text.ToString());

                
                Bill bill = new Bill(BillTextBox.Text, cost);
                //bills.Add(mybill);
                billList.Add(bill);

                totalBillCost += cost;

                ListBoxItem billsListBoxItem = new ListBoxItem();

                billsListBoxItem.Content = BillTextBox.Text + "    $" + cost;
                BillsListBox.Items.Add(billsListBoxItem);

                CostTextBox.Text = "";
                BillTextBox.Text = "";

            }
            catch (cost_Exception)
            {
                System.Windows.MessageBox.Show("Cost should have the format ##.## and greater than zero.");
            }

        }
        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            double wage;
            double hours;
            double monthlywage;
            wage = double.Parse(WageTextBox.Text.ToString());
            hours = double.Parse(HoursTextBox.Text.ToString());
            monthlywage = wage * hours * 4;
            User user = new User(UserTextBox.Text, monthlywage);

            Result objResult = new Result();
            objResult.UserLabel.Content = UserTextBox.Text;
            objResult.MonthlyIncomeLabel.Content = monthlywage;
            objResult.TotalBillsLabel.Content = totalBillCost;
            if (monthlywage > totalBillCost)
            {
                objResult.RemaingIncomeLabel.Content = monthlywage - totalBillCost;
                objResult.WeeklyBudgetAllowance.Content = (monthlywage - totalBillCost) / 4;
            }
            else
            {
                objResult.RemaingIncomeLabel.Content = "You cannot afford these bills with this income";
            }
            this.Visibility = Visibility.Hidden;
            objResult.Show();
            
        }

        private void DeleteBillButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Bill selectedBill = billList[BillsListBox.SelectedIndex];
                billList.RemoveAt(BillsListBox.SelectedIndex);
                BillsListBox.Items.RemoveAt(BillsListBox.SelectedIndex);
            }
            catch
            {

            }
        }

        //private void BillListBox_BillAdded(object sender, SelectionChangedEventArgs e)
        //{
        //    try
        //    {
        //        Bill bills = User.bills[BillsListBox.SelectedIndex];


        //    }
        //}


    public class cost_Exception : Exception
        {
            public cost_Exception(string message)
               : base(message)
            {
            }
        }
        //catch(wage_Exception)
        // {

        //}
    
    }
}
