using ClinicServicenamespace;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicDesctop
{
    /// <summary>
    /// НЕОБХОДИМО ПОДКЛЮЧИТЬ СБОРКУ System.Runtime.Serialization 
    /// </summary>

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonLoadClients_Click(object sender, EventArgs e)
        // Инициализация клиента д.доступа к сервису
        {
            ClinicServiceClient clinicServiceClient = 
                new ClinicServiceClient("http://localhost:5198/", new System.Net.Http.HttpClient());

            ICollection<Client> clients = clinicServiceClient.GetAllAsync().Result;

            listViewClients.Items.Clear();
            foreach (Client client in clients) 
            {
                ListViewItem item = new ListViewItem();
                item.Text = client.ClientId.ToString();
                item.SubItems.Add(new ListViewItem.ListViewSubItem()
                {
                    Text = client.SurName
                });
                item.SubItems.Add(new ListViewItem.ListViewSubItem()
                {
                    Text = client.FirstName
                });
                item.SubItems.Add(new ListViewItem.ListViewSubItem()
                {
                    Text = client.Patronymic
                });

                listViewClients.Items.Add(item);
            }
        }
    }
}
