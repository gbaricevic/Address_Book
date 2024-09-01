using Address_Book.Server.Models;
using Address_Book.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Address_Book.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressBookController : ControllerBase
    {
        private readonly IAddressBookService _addressBookService;

        public AddressBookController(IAddressBookService addressBookService)
        {
            _addressBookService = addressBookService;
        }

        // GET method: api/AddressBook
        [HttpGet]
        public async Task<IEnumerable<AdressBook>> Get()
        {
            return await _addressBookService.GetAddressBookList();
        }

        // GET: api/Players/5
        [HttpGet("{telephoneNumber}")]
        public async Task<ActionResult<AdressBook>> Get(string telephoneNumber)
        {
            var addressBook = await _addressBookService.GetAddressByID(telephoneNumber);

            if (addressBook == null)
            {
                return NotFound();
            }

            return Ok(addressBook);
        }

        // POST method: api/AddressBook
        [HttpPost]
        public async Task<ActionResult<AdressBook>> Post(AdressBook adressBook)
        {
            await _addressBookService.CreateAddress(adressBook);

            return CreatedAtAction("Post", new { telephoneNumber = adressBook.TelephoneNumber }, adressBook);
        }

        // PUT: api/AddressBook
        [HttpPut("{telephoneNumber}")]
        public async Task<IActionResult> Put(string telephoneNumber, AdressBook adressBook)
        {
            if (telephoneNumber != adressBook.TelephoneNumber)
            {
                return BadRequest("Invalid telephone number");
            }

            await _addressBookService.UpdateAddress(adressBook);

            return NoContent();
        }

        // DELETE: api/AddressBook
        [HttpDelete("{telephoneNumber}")]
        public async Task<IActionResult> Delete(string telephoneNumber)
        {
            

            var addressBook = await _addressBookService.GetAddressByID(telephoneNumber);
            if (addressBook == null)
            {
                return NotFound();
            }

            await _addressBookService.DeleteAddress(addressBook);

            return NoContent();
        }
    }
}