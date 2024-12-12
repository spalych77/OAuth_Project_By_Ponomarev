using System;
using System.Diagnostics;
using System.Windows.Forms;
using CefSharp;
using CefSharp.DevTools.Debugger;
using CefSharp.WinForms;
using static System.Net.WebRequestMethods;

namespace OAuthProject
{
    public partial class MainWindow : Form
    {
        private ChromiumWebBrowser chromiumWebBrowser1;

        string[] ids = { "b2f5f6de66814a9d80d9551c0351d3a9",
                         "591987820589-1or64e5qm243s6gr7j375sgampfnrur0.apps.googleusercontent.com",
                         "px5iKaxmv1KewvhjDU"
                       };

        string[] redirects = { "https://disk.yandex.ru/client/disk",
                               "https://www.google.ru/drive/",
                               "https://www.bybit.com" 
                             };

        string[] apiURL = { "https://cloud-api.yandex.net/v1/disk/resources/files?oauth_token=",
                            "https://www.googleapis.com/drive/v3/files?access_token=",
                            "https://www.bybit.com?access_token="
                          };

        string[] auths = { "https://oauth.yandex.ru/authorize?response_type=token&client_id=",
                           "https://accounts.google.com/o/oauth2/auth?response_type=token&client_id=",
                           "https://www.bybit.com/login?client_id="
                         };
        public MainWindow()
        {
            InitializeComponent();
            InitializeChromium();
            ShowCloudSelectionDialog();
        }

        private void InitializeChromium()
        {
            CefSettings cefset = new CefSettings();
            cefset.CefCommandLineArgs.Add("disable-web-security", "2");
            cefset.CefCommandLineArgs.Add("allow-running-insecure-content", "1");
            Cef.Initialize(cefset);

            // Создаем экземпляр ChromiumWebBrowser и добавляем его на форму
            chromiumWebBrowser1 = new ChromiumWebBrowser("https://www.example.com");
            chromiumWebBrowser1.Dock = DockStyle.Fill;
            this.Controls.Add(chromiumWebBrowser1);
        }

        private void ShowCloudSelectionDialog()
        {
            var cloudSelectionForm = new CloudSelectionForm();
            if (cloudSelectionForm.ShowDialog() == DialogResult.OK)
            {
                if (cloudSelectionForm.SelectedCloud == "Yandex")
                {
                    ShowUpAuth(ids[0], redirects[0], auths[0]);
                }
                else if (cloudSelectionForm.SelectedCloud == "Google")
                {
                    ShowUpAuth(ids[1], redirects[1] + "&scope=https://www.googleapis.com/auth/drive.readonly", auths[1]);
                }
                else if (cloudSelectionForm.SelectedCloud == "Bybit")
                {
                    ShowUpAuth(ids[2], redirects[2], auths[2]);
                }
            }
        }

        private void ShowUpAuth(string id, string redirect, string auth)
        {
            string url = $"{auth}{id}&redirect_uri={redirect}";
            chromiumWebBrowser1.Load(url);
        }

        private void ChromeBrowser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            if (e.Url.Contains("access_token="))
            {
                string token = ExtractAccessToken(e.Url);
                if (!string.IsNullOrEmpty(token))
                {
                    if (e.Url.StartsWith("https://oauth.yandex.ru"))
                    {
                        LoadAPI(apiURL[0], token);
                    }
                    else if (e.Url.StartsWith("https://accounts.google.com"))
                    {
                        LoadAPI(apiURL[1], token);
                    }
                    else if (e.Url.StartsWith("https://www.bybit.com"))
                    {
                        LoadAPI(apiURL[2], token);
                    }
                }
            }
        }

        private string ExtractAccessToken(string url)
        {
            var tokenIndex = url.IndexOf("access_token=");
            if (tokenIndex != -1)
            {
                var token = url.Substring(tokenIndex + "access_token=".Length);
                return token.Split('&')[0];
            }
            return string.Empty;
        }

        private void LoadAPI(string APIurl, string accessToken)
        {
            string apiRequest = APIurl + accessToken;
            chromiumWebBrowser1.Load(apiRequest);
        }
    }
}
