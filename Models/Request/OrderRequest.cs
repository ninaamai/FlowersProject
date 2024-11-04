namespace Maiboroda_Flowers.Models.Request
{
    public class OrderRequest
    {
        public int Id { get; set; }

        public string CitySender { get; set; }

        public string AddressSender { get; set; }

        public string CityRecipient { get; set; } 

        public string AddressRecipient { get; set; }

        public double ProductWeight { get; set; }

        public string DateReceipt { get; set; }
    }
}
