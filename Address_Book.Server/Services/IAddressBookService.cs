using Address_Book.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
namespace Address_Book.Server.Services
{
    public interface IAddressBookService
    {
        Task<IEnumerable<AdressBook>> GetAddressBookList();
        Task<AdressBook> GetAddressByID(string telephoneNumber);
        Task<AdressBook> CreateAddress(AdressBook address);
        Task UpdateAddress(AdressBook address);
        Task DeleteAddress(AdressBook address);
    }
}
