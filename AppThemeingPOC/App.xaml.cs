using AppThemeingPOC.Resources.Themes;

namespace AppThemeingPOC
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            GetSavedTheme();

            MainPage = new AppShell();
        }


        private void GetSavedTheme()
        {
            string activeTheme = Preferences.Default.Get("POCActiveTheme", nameof(LightTheme));

            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;

            if (mergedDictionaries != null)
            {
                mergedDictionaries.Clear();

                mergedDictionaries.Add(GetThemeResourceDictionary(activeTheme));
            }
        }

        private ResourceDictionary GetThemeResourceDictionary(string themeName)
        {
            ResourceDictionary themeDictionary = new LightTheme();

            switch (themeName)
            {
                case nameof(LightTheme):
                    themeDictionary = new LightTheme();
                    break;
                case nameof(DarkTheme):
                    themeDictionary = new DarkTheme();
                    break;
                case nameof(HiResTheme):
                    themeDictionary = new HiResTheme();
                    break;
                case nameof(OtherTheme):
                    themeDictionary = new OtherTheme();
                    break;
            }

            return themeDictionary;
        }


    }
}
