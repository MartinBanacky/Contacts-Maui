using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Contacts.Maui.Models
{
    public static class ContactRepository
    {
        public static List<Contact> contacts = new List<Contact>()
        {
            new Contact{ContactId = 1, Name="John Doe", Email="JohnDoe@gmail.com"},
            new Contact{ContactId = 2, Name="Jane Doe", Email="JaneDoe@gmail.com"},
            new Contact{ContactId = 3, Name="Tom Hanks", Email="TomHanks@gmail.com"},
            new Contact{ContactId = 4, Name="Matt Johnson", Email="MattJohnson@gmail.com"}
        };

        public static List<Contact> GetContacts() => contacts;

        public static Contact GetContactById (int ContactId)
        {
            var contact = contacts.FirstOrDefault(x => x.ContactId == ContactId);
            if (contact != null)
            {
                return new Contact
                {
                    ContactId = contact.ContactId,
                    Address = contact.Address,
                    Phone = contact.Phone,
                    Email = contact.Email,
                    Name = contact.Name,
                };
            }
            return null;
        }

        public static void UpdateContact(int ContactId, Contact contact)
        {
            if (ContactId != contact.ContactId) return;

            var contactToUpdate = contacts.FirstOrDefault(x => x.ContactId == ContactId);
            if (contactToUpdate != null)
            {
                //look up AutoMapper

                contactToUpdate.Name = contact.Name;
                contactToUpdate.Email = contact.Email;
                contactToUpdate.Address = contact.Address;
                contactToUpdate.Phone = contact.Phone;
                
                
            }
        }

        public static void AddContact(Contact contact)
        {
            var maxId = contacts.Max(x => x.ContactId);
            contact.ContactId = maxId + 1;
            contacts.Add(contact);
        }

        public static void DeleteContact(int ContactId)
        {
            var contact = contacts.FirstOrDefault( x => x.ContactId == ContactId);
            if(contact != null)
            {
                contacts.Remove(contact);
            }
        }

        public static List<Contact> SearchContacts(string filterText)
        {
            var contacts_h = contacts.Where(x => !string.IsNullOrWhiteSpace(x.Name) && x.Name.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();

            if (contacts_h == null || contacts_h.Count <= 0)
                contacts_h = contacts.Where(x => !string.IsNullOrWhiteSpace(x.Email) && x.Email.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
            else
                return contacts_h;

            if (contacts_h == null || contacts_h.Count <= 0)
                contacts_h = contacts.Where(x => !string.IsNullOrWhiteSpace(x.Phone) && x.Phone.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
            else
                return contacts_h;

            if (contacts_h == null || contacts_h.Count <= 0)
                contacts_h = contacts.Where(x => !string.IsNullOrWhiteSpace(x.Address) && x.Address.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
            else
                return contacts_h;

            return contacts_h;
        }
    }
}
