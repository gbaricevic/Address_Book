using Address_Book.Server.Data;
using Address_Book.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Numerics;


namespace Address_Book.Server.Services
{
    public class AddressBookService:IAddressBookService
    {
         
        private readonly AddressBookDatabaseContext _context;

        public AddressBookService(AddressBookDatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AdressBook>> GetAddressBookList()
        {
            return await _context.AdressBooks
                .ToListAsync();
        }

        public async Task<AdressBook> GetAddressByID(string telephoneNumber)
        {
            return await _context.AdressBooks
                
                .FirstOrDefaultAsync(x => x.TelephoneNumber == telephoneNumber);
        }

        public async Task<AdressBook> CreateAddress(AdressBook address)
        {
            _context.AdressBooks.Add(address);
            await _context.SaveChangesAsync();
            return address;
        }
        public async Task UpdateAddress(AdressBook address)
        {
            _context.AdressBooks.Update(address);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAddress(AdressBook address)
        {
            _context.AdressBooks.Remove(address);
            await _context.SaveChangesAsync();
        }
    }
}
