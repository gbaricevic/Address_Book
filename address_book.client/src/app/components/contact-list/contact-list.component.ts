import { Component, OnInit } from '@angular/core';
import { ContactService, Contact } from '../../services/contact.service';

@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.css']
})
export class ContactListComponent implements OnInit {

  contacts: Contact[] = [];
  isEditMode: boolean = false;
  contactForm: Contact = this.resetForm();

  constructor(private contactService: ContactService) { }

  ngOnInit(): void {
    this.loadContacts();
  }

  loadContacts(): void {
    this.contactService.getContacts().subscribe({
      next: (data: Contact[]) => {
        this.contacts = data;  
        console.log('Contacts loaded:', this.contacts);
      },
      error: (err) => {
        console.error('Error loading contacts:', err);
      }
    });
  }

  createContact(): void {
    this.contactService.createContact(this.contactForm).subscribe({
      next: (newContact) => {
        this.contacts.push(newContact);
        this.resetForm();
      },
      error: (err) => {
        console.error('Error creating contact:', err);
      }
    });
  }

  populateForm(contact: Contact): void {
    this.isEditMode = true;
    this.contactForm = { ...contact };
  }

  updateContact(): void {
    this.contactService.updateContact(this.contactForm).subscribe(updatedContact => {
      const index = this.contacts.findIndex(c => c.telephoneNumber === updatedContact.telephoneNumber);
      if (index !== -1) {
        this.contacts[index] = updatedContact;
      }
      this.resetForm();
    });
  }

  deleteContact(telephoneNumber: string): void {
    this.contactService.deleteContact(telephoneNumber).subscribe(() => {
      this.contacts = this.contacts.filter(contact => contact.telephoneNumber !== telephoneNumber);
    });
  }

  resetForm(): Contact {
    this.isEditMode = false;
    return {
      telephoneNumber: '',
      firstName: '',
      lastName: '',
      country: '',
      city: '',
      street: '',
      streetNumber: ''
    };
  }
}
