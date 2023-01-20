namespace LaundryApplication.Models
{
    public class CheckoutWithAccount
    {
        private User? _currentUser { get; set; }

        public string _username 
        { 
            get { return (null != _currentUser) ? _currentUser._name : string.Empty; } 
        }

        public double _MensDryCleanTShirtRate { get; set; }
        public double _MensDryCleanJeansRate { get; set; }
        public double _MensDryCleanKurtaRate { get; set; }
        public double _TaxRate { get; set; }

        public CheckoutWithAccount(User user, double MensDryCleanTShirtRate, double MensDryCleanJeansRate, double MensDryCleanKurtaRate, double TaxRate)
        {
            _currentUser = user;
            _MensDryCleanTShirtRate = MensDryCleanTShirtRate;
            _MensDryCleanJeansRate = MensDryCleanJeansRate;
            _MensDryCleanKurtaRate = MensDryCleanKurtaRate;
            _TaxRate = TaxRate;
        }
    }
}
