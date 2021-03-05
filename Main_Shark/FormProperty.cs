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

        public string mainPath { get;private set;} = Path.GetDirectoryName(Application.ExecutablePath) + "/Main.key";
        private string foreginPath = Path.GetDirectoryName(Application.ExecutablePath) + "/Foregin.key";

        private int cnt = 0;

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
            if(File.Exists(mainPath))
            using (BinaryReader sw = new BinaryReader(File.Open(mainPath, FileMode.Open)))
            {
                TbxIp.Text = sw.ReadString();
                TbxPort.Text = sw.ReadString();
                int count = sw.ReadInt32();
                for (int i = 0; i < count; i++)
                {
                    DgvIp.Rows.Add(sw.ReadString());
                }
            }
        }

        private void FormProperty_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(TbxIp.Text == "" || !IsCorrectIp(TbxIp.Text))
            {
                MessageBox.Show("Некорректный ip адрес", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }

            try
            {
                int port = int.Parse(TbxPort.Text);
            }
            catch
            {
                MessageBox.Show("Некорректный порт", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }


            SaveFile();
        }

        private void SaveFile()
        {

            using (BinaryWriter sw = new BinaryWriter(File.Open(mainPath, FileMode.Create)))
            {
                sw.Write(TbxIp.Text);
                sw.Write(TbxPort.Text);
                sw.Write(DgvIp.RowCount);
                for (int i = 0; i < DgvIp.RowCount; i++)
                {
                    sw.Write(DgvIp.Rows[i].Cells[0].Value.ToString());
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
            if(TbxIpUser.Text == "" || !IsCorrectIp(TbxIpUser.Text ) || cnt != 4)
            {
                MessageBox.Show("Не корректный ip адрес.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            for (int i = 0; i < DgvIp.RowCount; i++)
            {
                if(DgvIp.Rows[i].Cells[0].Value.ToString() == TbxIpUser.Text)
                {
                    MessageBox.Show("Данный ip адрес уже записан.","Внимание",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }
            }

            DgvIp.Rows.Add(TbxIpUser.Text);
        }

        private bool IsCorrectIp(string t)
        {
            string[] values = t.Split('.');

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
            for (int i = 0; i < TbxIpUser.Text.Length; i++)
            {
                if (TbxIpUser.Text[i] == '.')
                    z++;
            }
            cnt = z;

            if (!char.IsDigit(e.KeyChar))
                e.Handled = true;

            if (Keys.Back == (Keys)e.KeyChar)
                e.Handled = false;

            if(e.KeyChar == '.' && cnt < 3)
            {
                e.Handled = false;
                cnt++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
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
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveFile();
            TbxIp.ReadOnly = TbxPort.ReadOnly = true;
        }
    }
}
