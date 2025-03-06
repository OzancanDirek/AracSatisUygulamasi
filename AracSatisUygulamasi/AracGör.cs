using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AracSatisUygulamasi
{
    public partial class FrmAracGor : Form
    {
        public FrmAracGor()
        {
            InitializeComponent();

        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-QD8VUNPD\SQLEXPRESS;Initial Catalog=Galeri;Integrated Security=True;TrustServerCertificate=True;");
       

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from AracBilgi ", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
           
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select * from AracBilgi where Marka = @p1", baglanti);
            komut2.Parameters.AddWithValue("p1",TxtMarka.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void TxtKaydet_Click(object sender, EventArgs e)
        {
          

        }
    }
    }

