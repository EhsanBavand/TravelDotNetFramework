using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace Day09Travel
{
    public partial class AddTravelDialog : Window

    {
        //List<Travel> travel = new List<Travel>();
        private Travel currTravel;

        public AddTravelDialog(Window parent)
        {
            //, Travel __currTravel = null
            //currTravel = __currTravel;

            InitializeComponent();
            this.Owner = parent;
            if(currTravel != null)
            {
                lblID.Content = currTravel.Id + "";
                tbDestination.Text = currTravel.Destination;
                tbName.Text = currTravel.TravellerName;
                tbPassportNo.Text = currTravel.TravellerPassport;
                dpDep.Text = currTravel.DepartureDate .ToString();
                dpReturn.Text = currTravel.ReturnDate.ToString();
                cbxMethodTravel.Text = currTravel.MethodOfTravel.ToString();

            }
        }

        private void btnAddTrip_Click(object sender, RoutedEventArgs e)
        {
            //Travel currTravel = new Travel();

            string destination = tbDestination.Text;
            string name = tbName.Text;
            string passportNo = tbPassportNo.Text;
            DateTime departure = DateTime.Parse(dpDep.Text);
            DateTime returnDate = DateTime.Parse(dpDep.Text);
            if(returnDate.Date < departure.Date)
            {
                MessageBox.Show("Invalid Return Date. Needs to be after Departure");
                return;
            }
            string methodOfTravelStr = cbxMethodTravel.Text;
            Travel.TravelEnum methodOfTravel;
            if (!Enum.TryParse<Travel.TravelEnum>(methodOfTravelStr, out methodOfTravel))
            {
                throw new InvalidCastException("Enum value invalid: " + methodOfTravelStr);
            }

            try
            {
                if(currTravel == null)
                {
                    Travel t = new Travel(destination, name, passportNo, departure, returnDate,  methodOfTravel);
                    Globals.db.AddTraveller(t);
                }
                else
                {
                    currTravel.Destination = destination;
                    currTravel.TravellerName = name;
                    currTravel.TravellerPassport = passportNo;
                    currTravel.DepartureDate = departure;
                    currTravel.ReturnDate = returnDate;
                    currTravel.MethodOfTravel = methodOfTravel;
                    

                }
                this.DialogResult = true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(this, ex.Message, "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
