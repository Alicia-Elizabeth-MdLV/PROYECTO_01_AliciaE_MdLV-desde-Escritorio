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
    public partial class FrmBuscar : Form
    {
       public String codigo ;
       public String razon;
       public String direccion;
       public String telefono;
       public String ruc;
       public String cod_dis;
       public String fcha_reg;
       public String tip_cli;
       public String contacto;
        
        String cadenaconexion = "Data Source=.;Initial Catalog=VentasLeon;Integrated Security=SSPI";

        public FrmBuscar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (rbc.Checked)
            //{
                SqlConnection conexionSQL = new SqlConnection(cadenaconexion);
                DataSet dsCliente = new DataSet();
               
                SqlDataAdapter daCliente = new SqlDataAdapter("select * from tb_cliente where Cod_cli='" + this.txtbuscar.Text + "'", conexionSQL);
                SqlDataAdapter daaCliente = new SqlDataAdapter("select * from tb_cliente where Contacto like'" + this.txtbuscar.Text + "%'", conexionSQL);
                conexionSQL.Open();
                daCliente.Fill(dsCliente);
                daaCliente.Fill(dsCliente);
                dgdatos.DataSource = dsCliente.Tables[0].DefaultView;
                conexionSQL.Close();
                button2.Enabled = true;
            //}
            //if (rbk.Checked)
            //{
            //    SqlConnection conexionSQL = new SqlConnection(cadenaconexion);
            //    DataSet dsCliente = new DataSet();
            //    SqlDataAdapter daCliente = new SqlDataAdapter("select * from tb_cliente where Contacto='" + this.txtbuscar.Text + "'", conexionSQL);
            //    conexionSQL.Open();
            //    daCliente.Fill(dsCliente);
            //    dgdatos.DataSource = dsCliente.Tables[0].DefaultView;
            //    conexionSQL.Close();
            //    button2.Enabled = true;
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            codigo = Convert.ToString(dgdatos.CurrentRow.Cells[0].Value);
            razon = Convert.ToString(dgdatos.CurrentRow.Cells[1].Value);
            direccion = Convert.ToString(dgdatos.CurrentRow.Cells[2].Value);
            telefono = Convert.ToString(dgdatos.CurrentRow.Cells[3].Value);
            ruc = Convert.ToString(dgdatos.CurrentRow.Cells[4].Value);
            cod_dis = Convert.ToString(dgdatos.CurrentRow.Cells[5].Value);
            fcha_reg = Convert.ToString(dgdatos.CurrentRow.Cells[6].Value);
            tip_cli = Convert.ToString(dgdatos.CurrentRow.Cells[7].Value);
            contacto = Convert.ToString(dgdatos.CurrentRow.Cells[8].Value);
            this.Close();


        }

        private void FrmBuscar_Load(object sender, EventArgs e)
        {
          button2.Enabled = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtbuscar_KeyDown(object sender, KeyEventArgs e)
        {
        }
        
        private void button2_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void txtbuscar_KeyUp(object sender, KeyEventArgs e)
        {
            //if (txtbuscar.Text == "")
            //{
            //    button2.Enabled = false;
            //}
            //else
            //{
            //    button2.Enabled = true;
            //}
        }
    }
}
