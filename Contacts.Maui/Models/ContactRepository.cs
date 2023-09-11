using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Maui.Models
{
    public static class ContactRepository
    {
        public static List<Contact> _contacts = new List<Contact>()
        {
            new Contact{ContactId = 1, name="John Doe", email="JohnDoe@gmail.com"},
            new Contact{ContactId = 2, name="Jane Doe", email="JaneDoe@gmail.com"},
            new Contact{ContactId = 3, name="Tom Hanks", email="TomHanks@gmail.com"},
            new Contact{ContactId = 4, name="Matt Johnson", email="MattJohnson@gmail.com"}
        };

        public static List<Contact> GetContacts() => _contacts;

        public static Contact GetContactById (int ContactId)
        {
            return _contacts.FirstOrDefault(x => x.ContactId == ContactId);
        }
    }
}
