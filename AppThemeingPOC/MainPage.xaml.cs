namespace AppThemeingPOC
{
    using CommunityToolkit.Maui.Views;
    using IconTintIssuesPOC.Controls;

    public partial class MainPage : ContentPage
    {
        private TestPopup testPopup = new(); 

       public MainPage()
        {
            InitializeComponent();
        }

        private void OnPopupButtonClicked(object? sender, EventArgs e)
        {
            //part of this test is reusing the popup to maintain state.  Creating a new one would bypass the issue.
            this.ShowPopup(testPopup);
        }
    }
}
