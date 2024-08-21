using AppThemeingPOC.Resources.Themes;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace AppThemeingPOC.Views;

public partial class ThemeController : ContentView
{
	public ThemeController()
	{
		InitializeComponent();

        ActiveThemeLabel.Text = $"Currently Active Theme is {Preferences.Default.Get("POCActiveTheme", nameof(LightTheme))}";
    }

    private void OnLightThemeClicked(object? sender, EventArgs e)
    {
        Preferences.Default.Set("POCActiveTheme", nameof(LightTheme));
        ThemeChangeWarningLabel.IsVisible = true;
        ThemeChangeWarningLabel.Text = $"Restart the Application to make {nameof(LightTheme)} active.";
        RestartForThemeChanges();
    }

    private void OnDarkThemeClicked(object? sender, EventArgs e)
    {
        Preferences.Default.Set("POCActiveTheme", nameof(DarkTheme));
        ThemeChangeWarningLabel.IsVisible = true;
        ThemeChangeWarningLabel.Text = $"Restart the Application to make {nameof(DarkTheme)} active.";
        RestartForThemeChanges();
    }

    private void OnHiResThemeClicked(object? sender, EventArgs e)
    {
        Preferences.Default.Set("POCActiveTheme", nameof(HiResTheme));
        ThemeChangeWarningLabel.IsVisible = true;
        ThemeChangeWarningLabel.Text = $"Restart the Application to make {nameof(HiResTheme)} active.";
        RestartForThemeChanges();
    }

    private void OnOtherThemeClicked(object? sender, EventArgs e)
    {
        Preferences.Default.Set("POCActiveTheme", nameof(OtherTheme));
        ThemeChangeWarningLabel.IsVisible = true;
        ThemeChangeWarningLabel.Text = $"Restart the Application to make {nameof(OtherTheme)} active.";
        RestartForThemeChanges();
    }

    private void RestartForThemeChanges()
    {
        if (AutoRestartCheckBox.IsChecked == false)
        {
            return;
        }

        var filename = Process.GetCurrentProcess().MainModule.FileName;
        // Start a new instance of the application
        Process.Start(filename);
        //kill the old one
        Microsoft.Maui.Controls.Application.Current.Quit();
    }
}