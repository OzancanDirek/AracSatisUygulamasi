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
    public partial class FrmStokGüncelle : Form
    {
        public FrmStokGüncelle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-QD8VUNPD\SQLEXPRESS;Initial Catalog=Galeri;Integrated Security=True;TrustServerCertificate=True;");

        private void TxtListele_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from AracBilgi ", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void TxtGüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("INSERT INTO AracBilgi (Marka, Model, Yıl, KM, Stok) " +
         "VALUES (@p1, @p2, @p3, @p4, @p5)", baglanti);
            komut2.Parameters.AddWithValue("@p1", TxtMarka.Text);
            komut2.Parameters.AddWithValue("@p2", TxtModel.Text);
            komut2.Parameters.AddWithValue("@p3", TxtYıl.Text);
            komut2.Parameters.AddWithValue("@p4", TxtKM.Text);
            komut2.Parameters.AddWithValue("@p5", TxtStok.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show(" Arac Eklendi...");
        }

        private void BtnStokGüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut3 = new SqlCommand("UPDATE AracBilgi SET Stok = @p1 WHERE Model = @p2", baglanti);
            komut3.Parameters.AddWithValue("@p1", int.Parse(TxtStok.Text));  
            komut3.Parameters.AddWithValue("@p2", TxtModel.Text);  

            komut3.ExecuteNonQuery(); 
            baglanti.Close();

            MessageBox.Show("Stok başarıyla güncellendi...");
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut4 = new SqlCommand("DELETE FROM AracBilgi WHERE Marka = @p1 AND Model = @p2 and AracID = @p3", baglanti);
            komut4.Parameters.AddWithValue("@p1", TxtMarka.Text);
            komut4.Parameters.AddWithValue("@p2", TxtModel.Text);
            komut4.Parameters.AddWithValue("@p3", TxtAracID.Text);


            komut4.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Arac Başarıyla Silindi!");



        }
    }
    }
    

