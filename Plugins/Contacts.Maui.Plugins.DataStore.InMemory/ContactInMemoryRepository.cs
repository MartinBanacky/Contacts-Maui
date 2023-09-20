using Contacts.UseCases.PluginInterfaces;
using Contact = Contacts.CoreBusiness.Contact;

namespace Contacts.Maui.Plugins.DataStore.InMemory
{
    // All the code in this file is included in all platforms.
    public class ContactInMemoryRepository : IContactRepository
    {

        public static List<Contact> contacts;
        public ContactInMemoryRepository()
        {
            contacts = new List<Contact>()
            {
                new Contact{ContactId = 1, Name="John Doe", Email="JohnDoe@gmail.com"},
                new Contact{ContactId = 2, Name="Jane Doe", Email="JaneDoe@gmail.com"},
                new Contact{ContactId = 3, Name="Tom Hanks", Email="TomHanks@gmail.com"},
                new Contact{ContactId = 4, Name="Matt Johnson", Email="MattJohnson@gmail.com"}
            };
        }

        public Task AddContactAsync(Contact contact)
        {
            var maxId = contacts.Max(x => x.ContactId);
            contact.ContactId = maxId + 1;
            contacts.Add(contact);

            return Task.CompletedTask;
        }

        public Task DeleteContactAsync(int contactId)
        {
            var contact = contacts.FirstOrDefault(x => x.ContactId == contactId);
            if (contact != null)
            {
                contacts.Remove(contact);
            }
            return Task.CompletedTask; 

        }

        public Task<List<Contact>> GetContactAsync(string filterText)
        {
            if (string.IsNullOrWhiteSpace(filterText))
            {
                return Task.FromResult(contacts);
            }
            var contacts_h = contacts.Where(x => !string.IsNullOrWhiteSpace(x.Name) && x.Name.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();

            if (contacts_h == null || contacts_h.Count <= 0)
                contacts_h = contacts.Where(x => !string.IsNullOrWhiteSpace(x.Email) && x.Email.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
            else
                return Task.FromResult(contacts_h);

            if (contacts_h == null || contacts_h.Count <= 0)
                contacts_h = contacts.Where(x => !string.IsNullOrWhiteSpace(x.Phone) && x.Phone.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
            else
                return Task.FromResult(contacts_h);

            if (contacts_h == null || contacts_h.Count <= 0)
                contacts_h = contacts.Where(x => !string.IsNullOrWhiteSpace(x.Address) && x.Address.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
            else
                return Task.FromResult(contacts_h);

            return Task.FromResult(contacts_h);
        }

        public Task<Contact> GetContactByIdAsync(int contactId)
        {
            var contact = contacts.FirstOrDefault(x => x.ContactId == contactId);
            if (contact != null)
            {
                return Task.FromResult(new Contact
                {
                    ContactId = contact.ContactId,
                    Address = contact.Address,
                    Phone = contact.Phone,
                    Email = contact.Email,
                    Name = contact.Name,
                });
            }
            return null;
        }

        public Task UpdateContactAsync(int contactId, Contact contact)
        {
            if (contactId != contact.ContactId) return Task.CompletedTask;

            var contactToUpdate = contacts.FirstOrDefault(x => x.ContactId == contactId);
            if (contactToUpdate != null)
            {
                //look up AutoMapper

                contactToUpdate.Name = contact.Name;
                contactToUpdate.Email = contact.Email;
                contactToUpdate.Address = contact.Address;
                contactToUpdate.Phone = contact.Phone;
            }
            return Task.CompletedTask;
        }
    }
}