using Contacts.Maui.Models;
using Contacts.Maui.Views.Controls;
using Contact = Contacts.Maui.Models.Contact;

namespace Contacts.Maui.Views;


[QueryProperty(nameof(ContactId),"Id")]//whenever we recieve Id(parameter value) from
									   //previous page we will map this parameter to ContactId property 
public partial class EditContactPage : ContentPage
{
    private Contact contact;

    public EditContactPage()
	{
		InitializeComponent();
	}

	private void btnCancel_Clicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("..");
	}

	public string ContactId
	{
		set
		{
			contact = ContactRepository.GetContactById(int.Parse(value));
			if (contact != null)
			{
				contactCtrl.Name = contact.Name;
                contactCtrl.Email = contact.Email;
				contactCtrl.Phone = contact.Phone;
                contactCtrl.Address = contact.Address;

            }
			
		}
	}

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {

		contact.Name = contactCtrl.Name;
		contact.Email = contactCtrl.Address;
		contact.Phone = contactCtrl.Phone;
		contact.Address = contactCtrl.Address;

		ContactRepository.UpdateContact(contact.ContactId, contact);

        Shell.Current.GoToAsync("..");
    }

    private void contactCtrl_OnError(object sender, string e)
    {
		DisplayAlert("Error", e, "OK");
    }
}