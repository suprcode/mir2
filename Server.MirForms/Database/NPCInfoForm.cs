﻿using Server.MirDatabase;
using Server.MirEnvir;

namespace Server
{
    public partial class NpcInfoForm : Form
    {
        public string NpcListPath = Path.Combine(Settings.ExportPath, "NpcList.csv");

        public Envir Envir => SMain.EditEnvir;

        private List<NpcInfo> _selectedNpcInfos;

        public NpcInfoForm()
        {
            InitializeComponent();

            for (int i = 0; i < Envir.MapInfoList.Count; i++) MapComboBox.Items.Add(Envir.MapInfoList[i]);

            if (ConquestHidden_combo.Items.Count != Envir.ConquestInfoList.Count)
            {
                ConquestHidden_combo.Items.Clear();

                ConquestHidden_combo.Items.Add("");
                for (int i = 0; i < Envir.ConquestInfoList.Count; i++)
                {
                    ConquestHidden_combo.Items.Add(Envir.ConquestInfoList[i]);
                }
            }

            UpdateInterface();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Envir.CreateNpcInfo();
            UpdateInterface();
        }
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (_selectedNpcInfos.Count == 0) return;

            if (MessageBox.Show("Are you sure you want to remove the selected Npcs?", "Remove Npcs?", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            for (int i = 0; i < _selectedNpcInfos.Count; i++) Envir.Remove(_selectedNpcInfos[i]);

            if (Envir.NpcInfoList.Count == 0) Envir.NpcIndex = 0;

            UpdateInterface();
        }

        private void UpdateInterface()
        {
            if (NpcInfoListBox.Items.Count != Envir.NpcInfoList.Count)
            {
                NpcInfoListBox.Items.Clear();

                for (int i = 0; i < Envir.NpcInfoList.Count; i++)
                    NpcInfoListBox.Items.Add(Envir.NpcInfoList[i]);
            }

            _selectedNpcInfos = NpcInfoListBox.SelectedItems.Cast<NpcInfo>().ToList();

            if (_selectedNpcInfos.Count == 0)
            {
                tabPage1.Enabled = false;
                tabPage2.Enabled = false;
                NpcIndexTextBox.Text = string.Empty;
                NFileNameTextBox.Text = string.Empty;
                NNameTextBox.Text = string.Empty;
                NXTextBox.Text = string.Empty;
                NYTextBox.Text = string.Empty;
                NImageTextBox.Text = string.Empty;
                NRateTextBox.Text = string.Empty;
                MapComboBox.SelectedItem = null;
                MinLev_textbox.Text = string.Empty;
                MaxLev_textbox.Text = string.Empty;
                Class_combo.Text = string.Empty;
                ConquestHidden_combo.SelectedIndex = -1;
                Day_combo.Text = string.Empty;
                TimeVisible_checkbox.Checked = false;
                StartHour_combo.Text = string.Empty;
                EndHour_combo.Text = string.Empty;
                StartMin_num.Value = 0;
                EndMin_num.Value = 1;
                Flag_textbox.Text = string.Empty;
                ShowBigMapCheckBox.Checked = false;
                BigMapIconTextBox.Text = string.Empty;
                ConquestVisible_checkbox.Checked = true;
                return;
            }

            NpcInfo info = _selectedNpcInfos[0];

            tabPage1.Enabled = true;
            tabPage2.Enabled = true;

            NpcIndexTextBox.Text = info.Index.ToString();
            NFileNameTextBox.Text = info.FileName;
            NNameTextBox.Text = info.Name;
            NXTextBox.Text = info.Location.X.ToString();
            NYTextBox.Text = info.Location.Y.ToString();
            NImageTextBox.Text = info.Image.ToString();
            NRateTextBox.Text = info.Rate.ToString();
            MapComboBox.SelectedItem = Envir.MapInfoList.FirstOrDefault(x => x.Index == info.MapIndex);
            MinLev_textbox.Text = info.MinLev.ToString();
            MaxLev_textbox.Text = info.MaxLev.ToString();
            Class_combo.Text = info.ClassRequired;
            ConquestHidden_combo.SelectedItem = Envir.ConquestInfoList.FirstOrDefault(x => x.Index == info.Conquest);
            Day_combo.Text = info.DayofWeek;
            TimeVisible_checkbox.Checked = info.TimeVisible;
            StartHour_combo.Text = info.HourStart.ToString();
            EndHour_combo.Text = info.HourEnd.ToString();
            StartMin_num.Value = info.MinuteStart;
            EndMin_num.Value = info.MinuteEnd;
            Flag_textbox.Text = info.FlagNeeded.ToString();
            ShowBigMapCheckBox.Checked = info.ShowOnBigMap;
            BigMapIconTextBox.Text = info.BigMapIcon.ToString();
            TeleportToCheckBox.Checked = info.CanTeleportTo;
            ConquestVisible_checkbox.Checked = info.ConquestVisible;
            LoadImage(info.Image);


            for (int i = 1; i < _selectedNpcInfos.Count; i++)
            {
                info = _selectedNpcInfos[i];

                if (NFileNameTextBox.Text != info.FileName) NFileNameTextBox.Text = string.Empty;
                if (NNameTextBox.Text != info.Name) NNameTextBox.Text = string.Empty;
                if (NXTextBox.Text != info.Location.X.ToString()) NXTextBox.Text = string.Empty;

                if (NYTextBox.Text != info.Location.Y.ToString()) NYTextBox.Text = string.Empty;
                if (NImageTextBox.Text != info.Image.ToString()) NImageTextBox.Text = string.Empty;
                if (NRateTextBox.Text != info.Rate.ToString()) NRateTextBox.Text = string.Empty;
                if (BigMapIconTextBox.Text != info.BigMapIcon.ToString()) BigMapIconTextBox.Text = string.Empty;
            }
        }

        private void RefreshNpcList()
        {
            NpcInfoListBox.SelectedIndexChanged -= NpcInfoListBox_SelectedIndexChanged;

            List<bool> selected = new List<bool>();

            for (int i = 0; i < NpcInfoListBox.Items.Count; i++) selected.Add(NpcInfoListBox.GetSelected(i));
            NpcInfoListBox.Items.Clear();

            for (int i = 0; i < Envir.NpcInfoList.Count; i++) NpcInfoListBox.Items.Add(Envir.NpcInfoList[i]);
            for (int i = 0; i < selected.Count; i++) NpcInfoListBox.SetSelected(i, selected[i]);

            NpcInfoListBox.SelectedIndexChanged += NpcInfoListBox_SelectedIndexChanged;
        }

        private void NpcInfoListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_selectedNpcInfos.Count > 0)
            {
                NpcInfo info = _selectedNpcInfos[0];
                LoadImage(info.Image);
            }
            else
            {
                LoadImage(0);
            }

            UpdateInterface();

        }
        private void LoadImage(ushort imageValue)
        {
            string filename = $"{imageValue}.bmp";
            string imagePath = Path.Combine(Environment.CurrentDirectory, "Envir", "Previews", "Npc", filename);

            if (File.Exists(imagePath))
            {
                using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    NpcPreview.Image = Image.FromStream(fs);
                }
            }
            else
            {
                NpcPreview.Image = null;
            }
        }

        private void NFileNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ActiveControl != sender) return;

            for (int i = 0; i < _selectedNpcInfos.Count; i++)
                _selectedNpcInfos[i].FileName = ActiveControl.Text;

            RefreshNpcList();
        }
        private void NNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ActiveControl != sender) return;

            for (int i = 0; i < _selectedNpcInfos.Count; i++)
                _selectedNpcInfos[i].Name = ActiveControl.Text;
        }
        private void NXTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ActiveControl != sender) return;

            int temp;

            if (!int.TryParse(ActiveControl.Text, out temp))
            {
                ActiveControl.BackColor = Color.Red;
                return;
            }
            ActiveControl.BackColor = SystemColors.Window;


            for (int i = 0; i < _selectedNpcInfos.Count; i++)
                _selectedNpcInfos[i].Location.X = temp;

            RefreshNpcList();
        }
        private void NYTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ActiveControl != sender) return;

            int temp;

            if (!int.TryParse(ActiveControl.Text, out temp))
            {
                ActiveControl.BackColor = Color.Red;
                return;
            }
            ActiveControl.BackColor = SystemColors.Window;


            for (int i = 0; i < _selectedNpcInfos.Count; i++)
                _selectedNpcInfos[i].Location.Y = temp;

            RefreshNpcList();
        }
        private void NImageTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ActiveControl != sender) return;

            ushort temp;

            if (!ushort.TryParse(ActiveControl.Text, out temp))
            {
                ActiveControl.BackColor = Color.Red;
                return;
            }
            ActiveControl.BackColor = SystemColors.Window;


            for (int i = 0; i < _selectedNpcInfos.Count; i++)
                _selectedNpcInfos[i].Image = temp;

            LoadImage(temp);
        }
        private void NRateTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ActiveControl != sender) return;

            ushort temp;

            if (!ushort.TryParse(ActiveControl.Text, out temp))
            {
                ActiveControl.BackColor = Color.Red;
                return;
            }
            ActiveControl.BackColor = SystemColors.Window;


            for (int i = 0; i < _selectedNpcInfos.Count; i++)
                _selectedNpcInfos[i].Rate = temp;
        }

        private void MapComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActiveControl != sender) return;

            for (int i = 0; i < _selectedNpcInfos.Count; i++)
            {
                MapInfo temp = (MapInfo)MapComboBox.SelectedItem;
                _selectedNpcInfos[i].MapIndex = temp.Index;
            }

        }

        private void NpcInfoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Envir.SaveDB();
        }




        private void PasteMButton_Click(object sender, EventArgs e)
        {
            string data = Clipboard.GetText();

            if (!data.StartsWith("Npc", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Cannot Paste, Copied data is not Npc Information.");
                return;
            }


            string[] npcs = data.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);


            //for (int i = 1; i < npcs.Length; i++)
            //    NpcInfo.FromText(npcs[i]);

            UpdateInterface();
        }

        private void ExportAllButton_Click(object sender, EventArgs e)
        {
            ExportNpcs(Envir.NpcInfoList);
        }

        private void ExportSelected_Click(object sender, EventArgs e)
        {
            var list = NpcInfoListBox.SelectedItems.Cast<NpcInfo>().ToList();

            ExportNpcs(list);
        }

        public void ExportNpcs(List<NpcInfo> Npcs)
        {
            if (Npcs.Count == 0) return;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Path.Combine(Application.StartupPath, "Exports");
            sfd.Filter = "CSV File|*.csv";
            sfd.ShowDialog();

            if (sfd.FileName == string.Empty) return;

            using (StreamWriter sw = File.AppendText(sfd.FileNames[0]))
            {
                for (int j = 0; j < Npcs.Count; j++)
                {
                    sw.WriteLine(Npcs[j].ToText());
                }
            }
            MessageBox.Show("Npc Export complete");
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            string Path = string.Empty;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV File|*.csv";
            ofd.ShowDialog();

            if (ofd.FileName == string.Empty) return;

            Path = ofd.FileName;

            string data;
            using (var sr = new StreamReader(Path))
            {
                data = sr.ReadToEnd();
            }

            var npcs = data.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var m in npcs)
            {
                try
                {
                    NpcInfo.FromText(m);
                }
                catch { }
            }

            UpdateInterface();
            MessageBox.Show("Npc Import complete");
        }

        private void OpenNButton_Click(object sender, EventArgs e)
        {
            if (NFileNameTextBox.Text == string.Empty) return;

            var scriptPath = Path.Combine(Settings.NpcPath, NFileNameTextBox.Text + ".txt");

            if (File.Exists(scriptPath))
            {
                Shared.Helpers.FileIO.OpenScript(scriptPath, true);
            }

            else
            {
                Directory.CreateDirectory(Path.GetDirectoryName(scriptPath));
                File.Create(scriptPath).Close();
                Shared.Helpers.FileIO.OpenScript(scriptPath, true);
            }
        }

        private void MinLev_textbox_TextChanged(object sender, EventArgs e)
        {
            if (ActiveControl != sender) return;

            short temp;

            if (!short.TryParse(ActiveControl.Text, out temp))
            {
                ActiveControl.BackColor = Color.Red;
                return;
            }
            ActiveControl.BackColor = SystemColors.Window;


            for (int i = 0; i < _selectedNpcInfos.Count; i++)
                _selectedNpcInfos[i].MinLev = temp;
        }

        private void HourShow_textbox_TextChanged(object sender, EventArgs e)
        {
            if (ActiveControl != sender) return;

            byte temp;

            if (!byte.TryParse(ActiveControl.Text, out temp))
            {
                ActiveControl.BackColor = Color.Red;
                return;
            }
            ActiveControl.BackColor = SystemColors.Window;


            for (int i = 0; i < _selectedNpcInfos.Count; i++)
                _selectedNpcInfos[i].HourStart = temp;
        }

        private void MinutesShow_textbox_TextChanged(object sender, EventArgs e)
        {
            if (ActiveControl != sender) return;

            byte temp;

            if (!byte.TryParse(ActiveControl.Text, out temp))
            {
                ActiveControl.BackColor = Color.Red;
                return;
            }
            ActiveControl.BackColor = SystemColors.Window;


            for (int i = 0; i < _selectedNpcInfos.Count; i++)
                _selectedNpcInfos[i].MinuteStart = temp;
        }

        private void Class_textbox_TextChanged(object sender, EventArgs e)
        {
            if (ActiveControl != sender) return;

            for (int i = 0; i < _selectedNpcInfos.Count; i++)
                _selectedNpcInfos[i].ClassRequired = ActiveControl.Text;
        }

        private void CopyMButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Envir.Now.DayOfWeek.ToString());
        }

        private void MaxLev_textbox_TextChanged(object sender, EventArgs e)
        {
            if (ActiveControl != sender) return;

            short temp;

            if (!short.TryParse(ActiveControl.Text, out temp))
            {
                ActiveControl.BackColor = Color.Red;
                return;
            }
            ActiveControl.BackColor = SystemColors.Window;


            for (int i = 0; i < _selectedNpcInfos.Count; i++)
                _selectedNpcInfos[i].MaxLev = temp;
        }

        private void Class_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActiveControl != sender) return;
            string temp = ActiveControl.Text;


            for (int i = 0; i < _selectedNpcInfos.Count; i++)
                _selectedNpcInfos[i].ClassRequired = temp;
        }

        private void Day_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActiveControl != sender) return;
            string temp = ActiveControl.Text;


            for (int i = 0; i < _selectedNpcInfos.Count; i++)
                _selectedNpcInfos[i].DayofWeek = temp;
        }

        private void TimeVisible_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < _selectedNpcInfos.Count; i++)
                _selectedNpcInfos[i].TimeVisible = TimeVisible_checkbox.Checked;
        }

        private void StartHour_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActiveControl != sender) return;

            byte temp;

            if (!byte.TryParse(ActiveControl.Text, out temp))
            {
                ActiveControl.BackColor = Color.Red;
                return;
            }
            ActiveControl.BackColor = SystemColors.Window;

            for (int i = 0; i < _selectedNpcInfos.Count; i++)
                _selectedNpcInfos[i].HourStart = temp;
        }

        private void EndHour_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActiveControl != sender) return;

            byte temp;

            if (!byte.TryParse(ActiveControl.Text, out temp))
            {
                ActiveControl.BackColor = Color.Red;
                return;
            }
            ActiveControl.BackColor = SystemColors.Window;

            for (int i = 0; i < _selectedNpcInfos.Count; i++)
                _selectedNpcInfos[i].HourEnd = temp;
        }

        private void StartMin_num_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < _selectedNpcInfos.Count; i++)
                _selectedNpcInfos[i].MinuteStart = (byte)StartMin_num.Value;
        }

        private void EndMin_num_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < _selectedNpcInfos.Count; i++)
                _selectedNpcInfos[i].MinuteEnd = (byte)EndMin_num.Value;
        }

        private void Flag_textbox_TextChanged(object sender, EventArgs e)
        {
            if (ActiveControl != sender) return;

            int temp;

            if (!int.TryParse(ActiveControl.Text, out temp))
            {
                ActiveControl.BackColor = Color.Red;
                return;
            }
            ActiveControl.BackColor = SystemColors.Window;

            for (int i = 0; i < _selectedNpcInfos.Count; i++)
                _selectedNpcInfos[i].FlagNeeded = temp;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            MessageBox.Show(Envir.Now.TimeOfDay.ToString());
        }

        private void NpcInfoForm_Load(object sender, EventArgs e)
        {

        }

        private void ConquestHidden_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActiveControl != sender) return;

            int conquestIndex = 0;

            if (ConquestHidden_combo.SelectedItem is ConquestInfo conquestInfo)
            {
                conquestIndex = conquestInfo.Index;
            }

            for (int i = 0; i < _selectedNpcInfos.Count; i++)
                _selectedNpcInfos[i].Conquest = conquestIndex;
        }

        private void ShowBigMapCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ActiveControl != sender) return;

            for (int i = 0; i < _selectedNpcInfos.Count; i++)
                _selectedNpcInfos[i].ShowOnBigMap = ShowBigMapCheckBox.Checked;
        }

        private void BigMapIconTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ActiveControl != sender) return;

            int temp;

            if (!int.TryParse(ActiveControl.Text, out temp))
            {
                ActiveControl.BackColor = Color.Red;
                return;
            }
            ActiveControl.BackColor = SystemColors.Window;


            for (int i = 0; i < _selectedNpcInfos.Count; i++)
                _selectedNpcInfos[i].BigMapIcon = temp;
        }

        private void TeleportToCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ActiveControl != sender) return;

            for (int i = 0; i < _selectedNpcInfos.Count; i++)
                _selectedNpcInfos[i].CanTeleportTo = TeleportToCheckBox.Checked;
        }

        private void ConquestVisible_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (ActiveControl != sender) return;

            for (int i = 0; i < _selectedNpcInfos.Count; i++)
                _selectedNpcInfos[i].ConquestVisible = ConquestVisible_checkbox.Checked;
        }
    }
}
