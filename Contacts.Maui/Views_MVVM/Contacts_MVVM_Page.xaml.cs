using Contacts.Maui.ViewModels;

namespace Contacts.Maui.Views_MVVM;

public partial class Contacts_MVVM_Page : ContentPage
{
    private readonly ContactsViewModel contacsViewModel;

    public Contacts_MVVM_Page(ContactsViewModel contacsViewModel)
	{
		InitializeComponent();
        this.contacsViewModel = contacsViewModel;

        this.BindingContext = contacsViewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await this.contacsViewModel.LoadContactsAsync();
    }
}