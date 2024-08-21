using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Views;

namespace IconTintIssuesPOC.Controls;

public partial class TestPopup : Popup
{
    public TestPopup()
    {
        InitializeComponent();
    }

    private void OnCloseButtonClicked(object sender, EventArgs e)
    {
        Close();
    }
}

