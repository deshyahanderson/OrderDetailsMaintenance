using OrderDetailsMaintenance.Models.DataLayer;

namespace OrderDetailsMaintenance
{
    public partial class frmCustomerMaintenance : Form
    {

        private NorthwindContext _context = new NorthwindContext();
        private Customer _currentCustomer;

        //Deshyah Anderson
        public frmCustomerMaintenance()
        {
            InitializeComponent();
        }

        //Deshyah Anderson
        private void frmCustomerMaintenance_Load(object sender, EventArgs e)
        {

        }

        //Deshyah Anderson
        private void btnFind_Click(object sender, EventArgs e)
        {
            string searchId = txtCustomerId.Text.Trim();

            _currentCustomer = _context.Customers.Find(searchId);

            if (_currentCustomer != null)
            {
                txtContact.Text = _currentCustomer.ContactName;
                txtAddress.Text = _currentCustomer.Address;
                txtCity.Text = _currentCustomer.City;
                txtCountry.Text = _currentCustomer.Country;
            }
            else
            {
                txtContact.Clear();
                txtAddress.Clear();
                txtCity.Clear();
                txtCountry.Clear();

                MessageBox.Show("No customer found with ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Deshyah Anderson
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_currentCustomer != null)
            {
                _currentCustomer.ContactName = txtContact.Text; 
                _currentCustomer.Address = txtAddress.Text;
                _currentCustomer.City = txtCity.Text;
                _currentCustomer.Country = txtCountry.Text;

                _context.Customers.Update(_currentCustomer);
                _context.SaveChanges();

                MessageBox.Show("Customer record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please find a customer first before saving changes.", "Action Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        //Deshyah Anderson
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}