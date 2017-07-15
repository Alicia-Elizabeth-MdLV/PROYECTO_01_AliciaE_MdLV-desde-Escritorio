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
    public partial class FormVendedor : Form
    {
        public FormVendedor()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormVendedor_Load(object sender, EventArgs e)
        {
            SqlConnection conexsql = new SqlConnection("Data Source=.;Initial Catalog=VentasLeon;Integrated Security=SSPI");
            txtCodigo.Enabled = false;
            txtNombre.Enabled = false;
            txtApellidos.Enabled = false;
            dtpFecha.Enabled = false;
            txtTipoVEndedor.Enabled = false;
           // btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            lbl1.Text = "Nuevo";
            txtCodigo.Enabled = true;
            txtNombre.Enabled = true;
            txtApellidos.Enabled = true;
            dtpFecha.Enabled = true;
            txtTipoVEndedor.Enabled = true;
            // btnNuevo.Enabled = false;
            btnEditar.Enabled = true;
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;

           
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtSueldo.Text= "";
            dtpFecha.Text = "";
            txtTipoVEndedor.Text = "";
           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
           
            btnNuevo.Enabled = true;
            lbl1.Text = "";
            txtCodigo.Enabled = false;
            txtNombre.Enabled = false;
            txtApellidos.Enabled = false;
            dtpFecha.Enabled = false;
            txtTipoVEndedor.Enabled = false;
            // btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            lbl1.Text = "Editar";
            btnGrabar.Enabled = true;
            btnNuevo.Enabled = false;
            txtCodigo.Enabled = true;
            txtNombre.Enabled = true;
            txtApellidos.Enabled = true;
            dtpFecha.Enabled = true;
            txtTipoVEndedor.Enabled = true;
            // btnNuevo.Enabled = false;
            btnEditar.Enabled = true;
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
            
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("nooooooooooooooooooooooooooooooooooooooooooooo");
                return;
            }
            String conexion = "Data Source=.;Initial Catalog=VentasLeon;Integrated Security=SSPI";

            if(lbl1.Text=="Nuevo")
            {
                //SqlConnection conexsql = new SqlConnection(conexion);//"Data Source=.;Initial Catalog=VentasLeon;Integrated Security=SSPI");
                SqlDataAdapter da = new SqlDataAdapter("Insert into Tb_Vendedor (cod_ven,nom_ven,ape_ven,sue_ven,fec_ing,tip_ven) values ('" + txtCodigo.Text + "','" + txtNombre.Text + "','" + txtApellidos.Text + "','" + txtSueldo.Text + "','" + DateTime.Parse(dtpFecha.Text).ToString("yyyy/MM/dd") + "','" + txtTipoVEndedor.Text + "')", conexion);
                DataSet ds = new DataSet();
                da.Fill(ds);
                MessageBox.Show("El Ingreso fue un Exito");
            }

            if(lbl1.Text=="Editar")
            {
               // SqlConnection conexsql = new SqlConnection("Data Source=.;Initial Catalog=VentasLeon;Integrated Security=SSPI");
                SqlDataAdapter da = new SqlDataAdapter("update dbo.tb_vendedor SET nom_ven='" + txtNombre.Text + "',ape_ven='" + txtApellidos.Text + "',sue_ven='" + txtSueldo.Text + "',fec_ing='" + DateTime.Parse(dtpFecha.Text).ToString("yyyy/MM/dd") + "',tip_ven='" + txtTipoVEndedor.Text + "'where Cod_ven = '" + txtCodigo.Text + "' ", conexion);
                DataSet ds = new DataSet();
                da.Fill(ds);
                
                btnNuevo.Enabled = true;
                btnEditar.Enabled = true;
                btnGrabar.Enabled = false;
                btnCancelar.Enabled = false;
                dtpFecha.Enabled = false;

                MessageBox.Show("Exito al actualizar Datos");


            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarVendedor objeto = new FrmBuscarVendedor();
            objeto.ShowDialog();
            txtCodigo.Text = objeto.codigo;
            txtNombre.Text = objeto.nombre;
            txtApellidos.Text = objeto.apellido;
            txtSueldo.Text = objeto.sueldo;
            dtpFecha.Text = objeto.fecha;
            txtTipoVEndedor.Text = objeto.tipo_vende;
           

            btnEditar.Enabled = true;
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
