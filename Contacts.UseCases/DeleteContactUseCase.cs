using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contacts.UseCases.Interfaces;
using Contacts.UseCases.PluginInterfaces;

namespace Contacts.UseCases
{
    public class DeleteContactUseCase : IDeleteContactUseCase
    {
        private readonly IContactRepository contactRepository;

        public DeleteContactUseCase(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        public async Task ExecuteAsync(int contactId)
        {
            await this.contactRepository.DeleteContactAsync(contactId);
        }
    }
}
