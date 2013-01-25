using System.IO.IsolatedStorage;

namespace BundledFun
{
    public partial class HighScores
    {
        public static IsolatedStorageSettings AppSettings = IsolatedStorageSettings.ApplicationSettings;

        public HighScores()
        {
            InitializeComponent();
            LoadSettings();
        }

        /*Zapisywanie Ustawień
        public bool SaveSettings()
        {
            try
            {
                if (AppSettings.Contains("Wyn1"))
                    AppSettings["Wyn1"] = ostatni.Text;
                else
                    AppSettings.Add("OstatniNip", ostatni.Text);
                return true;
            }
            catch { return false; }
        }*/


        private void LoadSettings()
        {
            if (AppSettings.Contains("Wyn1"))
            {
                string result = (string)AppSettings["Wyn1"];
                wyn1.Text = result;
            }
            else
                wyn1.Text = string.Empty;

            if (AppSettings.Contains("Wyn2"))
            {
                string result = (string)AppSettings["Wyn2"];
                wyn2.Text = result;
            }
            else
                wyn1.Text = string.Empty;

            if (AppSettings.Contains("Wyn3"))
            {
                string result = (string)AppSettings["Wyn3"];
                wyn3.Text = result;
            }
            else
                wyn1.Text = string.Empty;
        }

    }
}
