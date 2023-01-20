namespace LaundryApplication.Models
{
    public class CheckoutModel
    {
        private User? _currentUser { get; set; }

        public string _username
        {
            get { return (null != _currentUser) ? _currentUser._name : string.Empty; }
        }

        public int _TotalTShirts { get; }
        public int _TotalJeans { get; }
        public int _TotalKurtas { get; }
        public double _TShirtCost { get; }
        public double _JeanCost { get; }
        public double _KurtaCost { get; }
        public double _subtotal { get; }
        public double _tax { get; }
        public double _totalAmt { get; }

        public CheckoutModel(User user, int TShirtCount, int JeansCount, int KurtaCount, double TShirtCost, double JeansCost, double KurtaCost, double subtotal, double taxRate)
        {
            _currentUser = user;

            _TotalTShirts = TShirtCount;
            _TotalJeans = JeansCount;
            _TotalKurtas = KurtaCount;
            _TShirtCost = TShirtCost;
            _JeanCost = JeansCost;
            _KurtaCost = KurtaCost;
            _subtotal = subtotal;

            _tax = subtotal * taxRate;
            _totalAmt = subtotal + _tax;
        }
    }
}
