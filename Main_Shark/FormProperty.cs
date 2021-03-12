using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace Main_Shark
{
    public partial class FormProperty : Form
    {
        public FormProperty()
        {
            InitializeComponent();
        }

        public string mainPath { get; private set; } = Path.GetDirectoryName(Application.ExecutablePath) + "/Main.key";
        private string foreginPath = Path.GetDirectoryName(Application.ExecutablePath) + "/Foregin.key";

        private int cnt = 0;
        private bool IsEdit = false;
        private int numDel = -1;

        private void FormProperty_Load(object sender, EventArgs e)
        {
            ReadOfFile();

            if (File.Exists(mainPath))
                TbxMainPath.Text = mainPath;

            if (File.Exists(foreginPath))
                TbxForeginPath.Text = foreginPath;

            if (TbxIp.Text != "" && TbxPort.Text != "")
                TbxIp.ReadOnly = TbxPort.ReadOnly = true;

        }

        private void ReadOfFile()
        {
            if (File.Exists(mainPath))
                using (BinaryReader sw = new BinaryReader(File.Open(mainPath, FileMode.Open)))
                {
                    TbxIp.Text = sw.ReadString();
                    TbxPort.Text = sw.ReadString();
                    int count = sw.ReadInt32();
                    for (int i = 0; i < count; i++)
                    {
                        string s = sw.ReadString();
                        LstIp.Items.Add(s);
                    }
                }
        }

        private void FormProperty_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (TbxIp.Text != "" && TbxPort.Text != "" && IsEdit)
            {
                var res = MessageBox.Show("Сохранить настройик?", "Сохранение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res == DialogResult.OK)
                {
                    if (TbxIp.Text == "" || !IsCorrectIp(TbxIp.Text))
                    {
                        MessageBox.Show("Не корректный ip адрес.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                    else
                    {
                        SaveFile();
                    }

                }
            }

        }

        private void SaveFile()
        {

            using (BinaryWriter sw = new BinaryWriter(File.Open(mainPath, FileMode.Create)))
            {
                sw.Write(TbxIp.Text);
                sw.Write(TbxPort.Text);
                sw.Write(LstIp.Items.Count);
                for (int i = 0; i < LstIp.Items.Count; i++)
                {
                    sw.Write(LstIp.Items[i].ToString());
                }
            }

            using (BinaryWriter sw = new BinaryWriter(File.Open(foreginPath, FileMode.Create)))
            {
                sw.Write(TbxIp.Text);
                sw.Write(TbxPort.Text);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {

            if (TbxIpUser.Text == "" || !IsCorrectIp(TbxIpUser.Text))
            {
                MessageBox.Show("Не корректный ip адрес.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            for (int i = 0; i < LstIp.Items.Count; i++)
            {
                if (LstIp.Items[i].ToString() == TbxIpUser.Text)
                {
                    MessageBox.Show("Данный ip адрес уже записан.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            IsEdit = true;

            if (BtnAdd.Text != "Добавить")
            {
                LstIp.Items.RemoveAt(numDel);
                LstIp.Items.Insert(numDel, TbxIpUser.Text);
                BtnDelUsers.Enabled = true;
            }
            else
            {
                LstIp.Items.Add(TbxIpUser.Text);
            }

            TbxIpUser.Text = "";

         
        }

        private bool IsCorrectIp(string t)
        {
            string[] values = t.Split('.');

            if (values.Length < 4)
                return false;

            for (int i = 0; i < values.Length; i++)
            {
                int value;
                try
                {
                    value = int.Parse(values[i]);
                }
                catch
                {
                    return false;
                }

                if (value > 255)
                {
                    return false;
                }
            }

            return true;
        }

        private void TbxIpUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            int z = 0;
            for (int i = 0; i < ((TextBox)sender).Text.Length; i++)
            {
                if (((TextBox)sender).Text[i] == '.')
                    z++;
            }
            cnt = z;

            if (!char.IsDigit(e.KeyChar))
                e.Handled = true;

            if (Keys.Back == (Keys)e.KeyChar)
                e.Handled = false;

            if (e.KeyChar == '.' && cnt < 3)
            {
                e.Handled = false;
                cnt++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string name = saveFileDialog1.FileName;

                name = Path.GetDirectoryName(name) + "/Foregin.key";

                using (BinaryWriter sw = new BinaryWriter(File.Open(name, FileMode.Create)))
                {
                    sw.Write(TbxIp.Text);
                    sw.Write(TbxPort.Text);
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            TbxIp.ReadOnly = TbxPort.ReadOnly = false;
            IsEdit = true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (TbxIp.Text == "" || !IsCorrectIp(TbxIp.Text))
            {
                MessageBox.Show("Не корректный ip адрес.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFile();
            TbxIp.ReadOnly = TbxPort.ReadOnly = true;
            IsEdit = false;

            MessageBox.Show("Данные успешно сохранены", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnEditUser_Click(object sender, EventArgs e)
        {

            if(BtnEditUser.Text != "Отмена")
            {
                numDel = LstIp.SelectedIndex;
                if(numDel>-1)
                {
                    TbxIpUser.Text = LstIp.Items[numDel].ToString();
                    BtnEditUser.Text = "Отмена";
                    BtnAdd.Text = "Сохранить";
                    BtnDelUsers.Enabled = false;
                }
            }
            else
            {
                TbxIpUser.Text = "";
                BtnEditUser.Text = "Редактировать";
                BtnAdd.Text = "Добавить";
                BtnDelUsers.Enabled = true;

            }
            
        }

        private void TbxIp_TextChanged(object sender, EventArgs e)
        {
        }

        private void BtnDelUsers_Click(object sender, EventArgs e)
        {
            if (LstIp.SelectedIndex < 0)
                return;

            var a = MessageBox.Show("Удалить выбранный Ip адрес?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(a == DialogResult.Yes)
            {
                LstIp.Items.RemoveAt(LstIp.SelectedIndex);
            }
        }
    }
}
