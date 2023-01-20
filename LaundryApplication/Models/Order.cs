namespace LaundryApplication.Models
{
    public class Order
    {
        public int TShirts { get; set; }

        // prices kept with order for historical purposes
        public double MensDryCleanTShirtPrice { get; set; }
        public int Jeans { get; set; }
        public double MensDryCleanJeansPrice { get; set; }
        public int Kurtas { get; set; }
        public double MensDryCleanKurtasPrice { get; set; }

        // tax rate kept with order for historical purposes
        public double TaxRate { get; set; }

        public double DeliveryCharge { get; set; }

        public double ItemTotal { get; set; }

        public double TaxTotal { get; set; }

        public double TotalAmount { get; set; }

        public string? UserPhone { get; set; }
    }
}
