using System;
using System.Collections.Generic;

namespace Maiboroda_Flowers.Models;

public partial class Order
{
    public int Id { get; set; }

    public string CitySender { get; set; }

    public string AddressSender { get; set; }

    public string CityRecipient { get; set; }

    public string AddressRecipient { get; set; }

    public double ProductWeight { get; set; }

    public string DateReceipt { get; set; }
}
