// Thunderstore Mod Manager - Main application window
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ThunderstoreModManager
{
    public class MainForm : Form
    {
        private readonly ListView _modList;
        private readonly ComboBox _gameSelector;
        private readonly ComboBox _profileSelector;
        private readonly Button _installButton;
        private readonly Button _launchButton;
        private readonly TextBox _searchBox;
        private readonly Label _statusLabel;

        public MainForm()
        {
            Text = "Thunderstore Mod Manager";
            Size = new Size(960, 640);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(24, 24, 27);
            ForeColor = Color.FromArgb(240, 240, 245);

            _gameSelector = new ComboBox
            {
                Location = new Point(12, 12),
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            _profileSelector = new ComboBox
            {
                Location = new Point(220, 12),
                Width = 160,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            _searchBox = new TextBox
            {
                Location = new Point(390, 12),
                Width = 250,
                PlaceholderText = "Search mods..."
            };

            _installButton = new Button
            {
                Text = "Install",
                Location = new Point(650, 10),
                Width = 90
            };

            _launchButton = new Button
            {
                Text = "Launch Game",
                Location = new Point(750, 10),
                Width = 110
            };

            _modList = new ListView
            {
                Location = new Point(12, 50),
                Size = new Size(920, 500),
                View = View.Details,
                FullRowSelect = true,
                GridLines = false
            };
            _modList.Columns.Add("Mod", 300);
            _modList.Columns.Add("Version", 100);
            _modList.Columns.Add("Author", 150);
            _modList.Columns.Add("Downloads", 100);
            _modList.Columns.Add("Status", 80);

            _statusLabel = new Label
            {
                Location = new Point(12, 560),
                Width = 920,
                ForeColor = Color.FromArgb(140, 140, 150)
            };

            Controls.AddRange(new Control[]
            {
                _gameSelector, _profileSelector, _searchBox,
                _installButton, _launchButton, _modList, _statusLabel
            });
        }
    }
}
