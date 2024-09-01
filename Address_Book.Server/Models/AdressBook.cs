using System;
using System.Collections.Generic;

namespace Address_Book.Server.Models;

public partial class AdressBook
{
    public string TelephoneNumber { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string StreetNumber { get; set; } = null!;
}
