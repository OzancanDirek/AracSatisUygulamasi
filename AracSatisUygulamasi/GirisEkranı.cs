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
    public partial class GirisEkranı : Form
    {

        public GirisEkranı()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-QD8VUNPD\SQLEXPRESS;Initial Catalog=Galeri;Integrated Security=True;TrustServerCertificate=True;");

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select Count(*) from Musteriler where Telefon = @p1", baglanti);
            komut.Parameters.AddWithValue("@p1",TxtTelefonGiris.Text);
            int sonuc = (int)komut.ExecuteScalar(); 

            if(sonuc > 0)
            {
                MessageBox.Show("Giris Basarili Hosgeldiniz...");
                this.Hide();
                AnaSayfa fr2 = new AnaSayfa();
                fr2.ShowDialog();
                this.Show();

                
            }
            else
            {
                MessageBox.Show("Böyle Bir Kullanıcı Bulunamadı");
            }
            baglanti.Close();
            

        }
    }
}
