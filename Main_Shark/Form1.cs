using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.Sockets;
using System.Net;
using DLl_Profile;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing.Imaging;
using DLL_Screen;

namespace Main_Shark
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ip адрес сервера.
        /// </summary>
        private string IpAdress = "127.0.0.1";
        /// <summary>
        /// Порт сервера.
        /// </summary>
        private int Port = 9000;
        /// <summary>
        /// Кол-во пк пользователей.
        /// </summary>
        private int Count = 0;
        /// <summary>
        /// Список ip пользователей.
        /// </summary>
        private string[] ipUser;
        /// <summary>
        /// Статус трансляции пользователя.
        /// </summary>
        private bool[] IsWork;

        /// <summary>
        /// Объект сервера.
        /// </summary>
        private TcpListener server;
        /// <summary>
        /// Список клиентов.
        /// </summary>
        private TcpClient[] clients = null;
        /// <summary>
        /// Путь до файла.
        /// </summary>
        public string mainPath { get; private set; } = Path.GetDirectoryName(Application.ExecutablePath) + "/Main.key";

        #region UI
        private FlowLayoutPanel flowPanel = null;
        private List<Button> LstbtnStart = new List<Button>();
        private List<Button> LstbtnEnd = new List<Button>();
        private List<PictureBox> Lstpbx = new List<PictureBox>();
        private List<Label> Lstlbx = new List<Label>();
        #endregion

        private Thread threadUsers = null;
        private Thread threadSends = null;

        public static Bitmap creen = null;

        /// <summary>
        /// Сереализация.
        /// </summary>
        /// <param name="inf"></param>
        /// <returns></returns>
        private Byte[] InfoToByte(Info inf)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, inf);
                ms.Flush();
                return ms.ToArray();
            }   
           
        }

        /// <summary>
        /// Сделать скрин.
        /// </summary>
        private MemoryStream CreateSreen()
        {
            creen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            Graphics gr = Graphics.FromImage(creen);
            gr.CopyFromScreen(0, 0, 0, 0, creen.Size);
            Icon cursor = Icon.FromHandle(Cursors.Default.Handle);
            gr.DrawIcon(cursor, new Rectangle(Cursor.Position, cursor.Size));

            //using (MemoryStream ms = new MemoryStream())
            //{
            //    using (Bitmap bmp = creen)
            //    {
            //        bmp.Save(ms, ImageCodecInfo.GetImageEncoders()[1],
            //        new EncoderParameters()
            //        {
            //            Param = new EncoderParameter[]
            //            {
            //                new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L - 30)
            //            }
            //        });
            //    }

            //    return ms;
            //}


            MemoryStream ms = new MemoryStream();

            creen.Save(ms, ImageFormat.Jpeg);

            ms.Position = 0;

            return ms;
        }

        /// <summary>
        /// Чтение из файла.
        /// </summary>
        private void ReadOfFile()
        {
            if (File.Exists(mainPath))
                using (BinaryReader sw = new BinaryReader(File.Open(mainPath, FileMode.Open)))
                {
                    IpAdress = sw.ReadString();
                    Port = int.Parse(sw.ReadString());
                    Count = sw.ReadInt32();

                    ipUser = new string[Count];
                    IsWork = new bool[Count];
                    clients = new TcpClient[Count];
                    for (int i = 0; i < Count; i++)
                    {
                        ipUser[i] = sw.ReadString();
                    }
                }
        }

        /// <summary>
        /// Загрузка.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            ReadOfFile();
            DrawMainMenu();

            threadUsers = new Thread(GetUsers);
            threadUsers.Start();
        }

        /// <summary>
        /// Рисуем главное меню
        /// </summary>
        private void DrawMainMenu()
        {
            if (flowPanel != null)
                this.Controls.Remove(flowPanel);
            flowPanel = new FlowLayoutPanel();
            flowPanel.Dock = DockStyle.Fill;
            flowPanel.AutoScroll = true;

            flowPanel.Controls.Clear();

            for (var i = 0; i < Count; i++)
            {
                var panel = new Panel();
                panel.Size = new Size(440, 200);
                panel.Margin = new Padding(5, 35, 20, 0);
                panel.BorderStyle = BorderStyle.Fixed3D;
                flowPanel.Controls.Add(panel);


                var pb = new PictureBox();
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Size = new Size(240, 130);
                pb.Image = Properties.Resources.NotSignal;
               // pb.BorderStyle = BorderStyle.Fixed3D;
                pb.Location = new Point(5, 35);
                panel.Controls.Add(pb);
                Lstpbx.Add(pb);

                var lb = new Label();
                lb.Text = ipUser[i];
                lb.ForeColor = Color.White;
                lb.Font = new Font("Calibri", 10);
                lb.Dock = DockStyle.Top;
                lb.TextAlign = ContentAlignment.MiddleCenter;
                panel.Controls.Add(lb);
                Lstlbx.Add(lb);

                var btn = new Button();
                //btn.Text = "Включить трансляцию";
                btn.BackgroundImageLayout = ImageLayout.Zoom;
                btn.BackgroundImage = Properties.Resources.Start;
                //btn.FlatAppearance.BorderSize = 0;
                //btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = Color.Orange;
                btn.FlatStyle = FlatStyle.Flat;
                btn.Location = new Point(265, 35);
                btn.Size = new Size(150, 50);
                btn.ForeColor = Color.White;
                btn.Tag = i;
                btn.Font = new Font("Calibri", 12);
                btn.Click += Btn_Click;
                panel.Controls.Add(btn);
                LstbtnStart.Add(btn);


                var btnEnd = new Button();
                // btnEnd.Text = "Выключить трансляцию";
                btnEnd.BackgroundImageLayout = ImageLayout.Zoom;
                btnEnd.BackgroundImage = Properties.Resources.Pause;
                //btnEnd.FlatAppearance.BorderSize = 0;
                btnEnd.FlatAppearance.BorderColor = Color.Orange;
                btnEnd.FlatStyle = FlatStyle.Flat;

                btnEnd.Location = new Point(265, 95);
                btnEnd.Size = new Size(150,50);
                btnEnd.ForeColor = Color.White;
                btnEnd.Tag = i;
                btnEnd.Font = new Font("Calibri", 12);
                btnEnd.Click += BtnEnd_Click;
                panel.Controls.Add(btnEnd);
                LstbtnEnd.Add(btnEnd);

                panel.Controls.Add(btn);


            }
            this.Controls.Add(flowPanel);
        }

        /// <summary>
        /// Остановить трансляцию.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEnd_Click(object sender, EventArgs e)
        {
            int index = (int)(sender as Button).Tag;
            if(clients[index]!= null)
            Lstpbx[index].Image = Properties.Resources.HaveSignal;
            IsWork[index] = false;
        }

        /// <summary>
        /// Начать трансляцию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Click(object sender, EventArgs e)
        {
            int index = (int)(sender as Button).Tag;
            if(clients[index]!= null)
            {
                IsWork[index] = true;
                Lstpbx[index].Image = Properties.Resources.Translate;
            }
            
        }

        /// <summary>
        /// Получить подключение.
        /// </summary>
        private void GetUsers()
        {
            IPAddress iP = IPAddress.Parse(IpAdress);
            server = new TcpListener(iP,Port);
            server.Start();

            TcpClient client = server.AcceptTcpClient();
            string ConnectClient = Convert.ToString(((System.Net.IPEndPoint)client.Client.RemoteEndPoint).Address);

            for (int i = 0; i < ipUser.Length; i++)
            {
                if (ConnectClient == ipUser[i])
                {

                    clients[i] = client;
                    Lstpbx[i].Image = Properties.Resources.HaveSignal;
                }
            }

            if(threadSends == null)
            {
                threadSends = new Thread(SendMessage);
                threadSends.Start();
            }

        }

        /// <summary>
        /// Отправка сообщения.
        /// </summary>
        private void SendMessage()
        {
            try
            {
                while (true)
                {

                    for (int i = 0; i < clients.Length; i++)
                    {
                        if(clients[i] != null)
                        {
                            Info inf = new Info();

                            if (IsWork[i])
                            {
                                
                                inf.Command = "Start";
                                //creen = CaptureScreen.GetDesktopImage();
                                inf.Screen = Image.FromStream(CreateSreen());
                            }
                            else
                            {
                                
                                inf.Command = "Stop";
                            }

                            byte[] byff = InfoToByte(inf);

                            NetworkStream stream = clients[i].GetStream();

                            stream.Write(byff, 0, byff.Length);
                            
                        }

                    }
                    Thread.Sleep(30);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                for (int j = 0; j < clients.Length; j++)
                {
                    if (clients[j] != null)
                        clients[j].Close();
                }
            }
        }

        /// <summary>
        /// Закрытие формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            server?.Stop();
            for (int i = 0; i < clients?.Length; i++)
            {
                clients[i]?.Close();
            }
            threadUsers?.Abort();
            threadSends?.Abort();
        }

        /// <summary>
        /// Открытие настроек.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmProperty_Click(object sender, EventArgs e)
        {
            FormProperty fp = new FormProperty();
            fp.ShowDialog();

            ReadOfFile();
            DrawMainMenu();
        }

        private void BtnOnAll_Click(object sender, EventArgs e)
        {
            if (Count > 0)
            {
                for (int i = 0; i < Count; i++)
                {
                    IsWork[i] = true;
                }
            }
        }

        private void BtnOffAll_Click(object sender, EventArgs e)
        {
            if (Count > 0)
            {
                for (int i = 0; i < Count; i++)
                {
                    IsWork[i] = false;
                }
            }
        }
    }
}
