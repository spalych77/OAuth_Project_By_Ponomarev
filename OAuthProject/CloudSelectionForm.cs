using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OAuthProject
{
    public partial class CloudSelectionForm : Form
    {
        public string SelectedCloud { get; private set; }

        public CloudSelectionForm()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            yandexBtn.Click += (sender, e) => {
                                                SelectedCloud = "Yandex";
                                                this.DialogResult = DialogResult.OK;
                                              };
            googleBtn.Click += (sender, e) => {
                SelectedCloud = "Google";
                this.DialogResult = DialogResult.OK;
            };
            bybitBtn.Click += (sender, e) => {
                SelectedCloud = "Bybit";
                this.DialogResult = DialogResult.OK;
            };

            this.Controls.Add(yandexBtn);
            this.Controls.Add(googleBtn);
            this.Controls.Add(bybitBtn);
        }

    }
}
