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
    public partial class FrmAracFiyatları : Form
    {
        public FrmAracFiyatları()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-QD8VUNPD\SQLEXPRESS;Initial Catalog=Galeri;Integrated Security=True;TrustServerCertificate=True;");


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from AracFiyat ", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("UPDATE AracFiyat SET Fiyat = @Fiyat WHERE AracID = @AracID AND Marka = @Marka AND Model = @Model",baglanti);

            komut2.Parameters.AddWithValue("@Fiyat",TxtFiyat.Text);
            komut2.Parameters.AddWithValue("@AracID", TxtAracID.Text);
            komut2.Parameters.AddWithValue("@Marka", TxtMarka.Text);
            komut2.Parameters.AddWithValue("@Model", TxtModel.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Fiyat Güncellendi...");


        }
    }
}
