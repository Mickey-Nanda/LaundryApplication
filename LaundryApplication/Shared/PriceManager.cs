namespace LaundryApplication.Shared
{
    // Singleton to provide current pricing info from the business
    public class PriceManager : IPricing
    {
        public double getMensDryCleanTShirtRate() { return 100;  }
        public double getMensDryCleanJeansRate() { return 120; }
        public double getMensDryCleanKurtaRate() { return 50; }
        public double getTaxRate() { return 0.1; }
    }
}
