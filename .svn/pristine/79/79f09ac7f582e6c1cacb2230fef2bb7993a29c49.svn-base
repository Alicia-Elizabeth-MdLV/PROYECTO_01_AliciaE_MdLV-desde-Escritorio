using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsSQLCommand
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            SqlConnection cnx = new SqlConnection("server=PC27;DataBase=Northwind;Integrated Security=True");
            cnx.Open();

            SqlCommand comando = new SqlCommand("insert into Region values( ' " + txtIdRegion.Text + "' , '" + txtDescripcion.Text + " '   )", cnx);
            comando.CommandType = CommandType.Text;

            comando.ExecuteNonQuery();

            CargarRegion();

            MessageBox.Show("Registro añadido !!!");

            
        }

        private void Form2_Load(object sender, EventArgs e)
        {


            CargarRegion();


        }


        private void CargarRegion()
        {

            SqlConnection cnx = new SqlConnection("server=PC27;DataBase=Northwind;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("select * from Region", cnx);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgvRegion.DataSource = ds.Tables[0].DefaultView;
        
        
        }



    }
}
