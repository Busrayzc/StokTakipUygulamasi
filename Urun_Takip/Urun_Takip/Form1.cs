using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Urun_Takip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection
        ("Data Source = localhost; Initial Catalog = UrunTakip; Integrated Security = True; TrustServerCertificate = True");
        private void btnListele_Click(object sender, EventArgs e)
        {
            
            SqlCommand sqlCommand = new SqlCommand("select * from TblKategori", baglanti);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sqlcommand2 = new SqlCommand("insert into TblKategori (Ad) Values (@p1)", baglanti);
            sqlcommand2.Parameters.AddWithValue("@p1", textBox1.Text);
            sqlcommand2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategoriniz başarılı bir şekilde eklendi.");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sqlcommand3 = new SqlCommand("delete from TblKategori where ID=@p1", baglanti);
            sqlcommand3.Parameters.AddWithValue("@p1", textBox2.Text);
            sqlcommand3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategori silme işlemi başarılı bir şekilde gerçekleşti.");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sqlcommand4 = new SqlCommand("update TblKategori set Ad = @p1 where ID=@p2",baglanti);
            sqlcommand4.Parameters.AddWithValue("@p1", textBox1.Text);
            sqlcommand4.Parameters.AddWithValue("@p2", textBox2.Text);
            sqlcommand4.ExecuteNonQuery();
;            baglanti.Close();
            MessageBox.Show("Kategori güncelleme işlemi başarılı bir şekilde gerçekleşti.");
            
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand5 = new SqlCommand("select * from TblKategori where Ad=@p1", baglanti);
            sqlCommand5.Parameters.AddWithValue("@p1", textBox1.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand5);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
//Data Source=localhost;Initial Catalog=UrunTakip;Integrated Security=True;Trust Server Certificate=True
