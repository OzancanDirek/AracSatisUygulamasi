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
    public partial class FrmRandevuAl : Form
    {
        public FrmRandevuAl()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-QD8VUNPD\SQLEXPRESS;Initial Catalog=Galeri;Integrated Security=True;TrustServerCertificate=True;");

        private void FrmRandevuAl_Load(object sender, EventArgs e)
        {
            
        }

        private void BtnRandevu_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand dolumu = new SqlCommand("SELECT COUNT(*) FROM Randevular WHERE RandevuTarihi = @p1", baglanti);
            dolumu.Parameters.AddWithValue("@p1", dateTimePickerRandevu.Value);

            int sayi = (int)dolumu.ExecuteScalar();

            if (sayi > 0)
            {
                MessageBox.Show("Bu tarih maalesef Dolu.");
            }
            else
            {

                SqlCommand komut = new SqlCommand("INSERT INTO Randevular (Ad, Soyad, Telefon, Eposta, AracID, RandevuTarihi) " +
                                                  "VALUES (@p1, @p2, @p3, @p4, @p5, @p6)", baglanti);

                komut.Parameters.AddWithValue("@p1", TxtAd.Text);  
                komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
                komut.Parameters.AddWithValue("@p3", TxtTelefon.Text);
                komut.Parameters.AddWithValue("@p4", TxtMail.Text);
                komut.Parameters.AddWithValue("@p5", Convert.ToInt32(TxtAracID.Text)); 
                komut.Parameters.AddWithValue("@p6", dateTimePickerRandevu.Value);

                komut.ExecuteNonQuery();
                MessageBox.Show("Randevunuz Alınmıştır Görüşmek Üzere...");
            }


            baglanti.Close();

        }
    }
}
