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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            SqlConnection cnx = new SqlConnection("server=PC06;DataBase=Northwind;Integrated Security=True");
            cnx.Open();
            SqlCommand comando = new SqlCommand("SELECT * FROM CUSTOMERS", cnx);
            comando.CommandType = CommandType.Text;

            SqlDataReader dr = comando.ExecuteReader();

            while (dr.Read())
            {

                lstClientes.Items.Add(dr.GetString(0) + "  -- " + dr.GetString(1));

            }
            cnx.Close();




        }
    }
}
