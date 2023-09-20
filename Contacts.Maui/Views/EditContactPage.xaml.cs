using Contacts.Maui.Models;
using Contacts.UseCases.Interfaces;
using Contact = Contacts.Maui.Models.Contact;

namespace Contacts.Maui.Views;


[QueryProperty(nameof(ContactId),"Id")]//whenever we recieve Id(parameter value) from
									   //previous page we will map this parameter to ContactId property 
public partial class EditContactPage : ContentPage
{
    private CoreBusiness.Contact contact;
    private readonly IViewContactUseCase viewContactUseCase;
    private readonly IEditContactUseCase editContactUseCase;

    public EditContactPage(IViewContactUseCase viewContactUseCase, IEditContactUseCase editContactUseCase)
	{
		InitializeComponent();
        this.viewContactUseCase = viewContactUseCase;
        this.editContactUseCase = editContactUseCase;
    }

	private void btnCancel_Clicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("..");
	}

	public string ContactId
	{
		set
		{
			contact = viewContactUseCase.ExecuteAsync(int.Parse(value)).GetAwaiter().GetResult();
			if (contact != null)
			{
				contactCtrl.Name = contact.Name;
                contactCtrl.Email = contact.Email;
				contactCtrl.Phone = contact.Phone;
                contactCtrl.Address = contact.Address;

            }
			
		}
	}

    private async void btnUpdate_Clicked(object sender, EventArgs e)
    {

		contact.Name = contactCtrl.Name;
		contact.Email = contactCtrl.Email;
		contact.Phone = contactCtrl.Phone;
		contact.Address = contactCtrl.Address;

		await editContactUseCase.ExecuteAsync(contact.ContactId, contact);
        await Shell.Current.GoToAsync("..");
    }

    private void contactCtrl_OnError(object sender, string e)
    {
		DisplayAlert("Error", e, "OK");
    }
}