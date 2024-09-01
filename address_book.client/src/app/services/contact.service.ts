import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Contact {
  telephoneNumber: string;
  firstName: string;
  lastName: string;
  country: string;
  city: string;
  street: string;
  streetNumber: string;
}

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  private apiUrl = 'http://localhost:7044/api/AddressBook'; // Replace with your .NET API URL

  constructor(private http: HttpClient) { }

  // GET all contacts
  getContacts(): Observable<Contact[]> {
    return this.http.get<Contact[]>(this.apiUrl);
  }

  // GET a contact by telephone number
  getContactByTelephone(telephoneNumber: string): Observable<Contact> {
    return this.http.get<Contact>(`${this.apiUrl}/${telephoneNumber}`);
  }

  // POST create a new contact
  createContact(contact: Contact): Observable<Contact> {
    return this.http.post<Contact>(this.apiUrl, contact);
  }

  // PUT update an existing contact by telephone number
  updateContact(contact: Contact): Observable<Contact> {
    return this.http.put<Contact>(`${this.apiUrl}/${contact.telephoneNumber}`, contact);
  }

  // DELETE a contact by telephone number
  deleteContact(telephoneNumber: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${telephoneNumber}`);
  }
}
