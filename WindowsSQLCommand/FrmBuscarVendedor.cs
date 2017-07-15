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
    public partial class FrmBuscarVendedor : Form
    {
        public String codigo;
        public String nombre;
        public String apellido;
        public String sueldo;
        public String fecha;
        public String tipo_vende;

        String cadenaconexion = "Data Source=.;Initial Catalog=VentasLeon;Integrated Security=SSPI";

        public FrmBuscarVendedor()
        {
            InitializeComponent();
        }

        private void FrmBuscarVendedor_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (rbc.Checked)
            {
                SqlConnection conexionSQL = new SqlConnection(cadenaconexion);
                DataSet dsVendedor = new DataSet();
                SqlDataAdapter daCliente = new SqlDataAdapter("select * from tb_Vendedor where Cod_ven='" + this.txtbuscar.Text + "'", conexionSQL);
               
                conexionSQL.Open();
                daCliente.Fill(dsVendedor);
                dgdatos.DataSource = dsVendedor.Tables[0].DefaultView;
                conexionSQL.Close();
                button2.Enabled = true;
            }

            if (rbn.Checked)
            {
                SqlConnection conexionSQL = new SqlConnection(cadenaconexion);
                DataSet dsVendedor = new DataSet();
                SqlDataAdapter daaCliente = new SqlDataAdapter("select * from tb_Vendedor where nom_ven like'" + this.txtbuscar.Text + "%'", conexionSQL);
                conexionSQL.Open();
                daaCliente.Fill(dsVendedor);
                dgdatos.DataSource = dsVendedor.Tables[0].DefaultView;
                conexionSQL.Close();
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            codigo = Convert.ToString(dgdatos.CurrentRow.Cells[0].Value);
            nombre = Convert.ToString(dgdatos.CurrentRow.Cells[1].Value);
            apellido = Convert.ToString(dgdatos.CurrentRow.Cells[2].Value);
            sueldo = Convert.ToString(dgdatos.CurrentRow.Cells[3].Value);
            fecha = Convert.ToString(dgdatos.CurrentRow.Cells[4].Value);
            tipo_vende = Convert.ToString(dgdatos.CurrentRow.Cells[5].Value);
            
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
