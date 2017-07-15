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
    public partial class FrmCliente : Form
    {
        
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            cboDistrito.Enabled = false;
            dtpFechaReg.Enabled = false;

            SqlConnection conexsql = new SqlConnection("Data Source=.;Initial Catalog=VentasLeon;Integrated Security=SSPI");
            DataSet dsdistrito = new DataSet();
            SqlDataAdapter daCategorias = new SqlDataAdapter("Select * From Tb_Distrito", conexsql);
            daCategorias.Fill(dsdistrito);
            cboDistrito.DataSource = dsdistrito.Tables[0];
            cboDistrito.DisplayMember = "Nom_dis";
            cboDistrito.ValueMember = "Cod_dis";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            habilitar(true);
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            lbl1.Text = "Nuevo";
            cboDistrito.Enabled = true;
            dtpFechaReg.Enabled = true;
       
        }
      public  void habilitar(Boolean estado)
        {
            txtCodigo.Enabled = estado;
            txtRazonSocial.Enabled = estado;
            TxtDireccion.Enabled = estado;
            txtTelefono.Enabled = estado;
            txtRuc.Enabled = estado;
            txtTipoCliente.Enabled = estado;
            txtContacto.Enabled = estado;
            
            btnEditar.Enabled = estado;
            btnGrabar.Enabled = estado;
            btnCancelar.Enabled = estado;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            habilitar(false);
            btnNuevo.Enabled = true;
            lbl1.Text = "";
            cboDistrito.Enabled = false;
            dtpFechaReg.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscar objeto = new FrmBuscar();
            objeto.ShowDialog();
            txtCodigo.Text = objeto.codigo;
            txtRazonSocial.Text = objeto.razon;
            TxtDireccion.Text=objeto.direccion;
            txtTelefono.Text=objeto.telefono;
            txtRuc.Text=objeto.ruc;
            cboDistrito.Text=objeto.cod_dis;
            dtpFechaReg.Text=objeto.fcha_reg;
            txtTipoCliente.Text=objeto.tip_cli;
            txtContacto.Text = objeto.contacto;
            
            btnEditar.Enabled = true;


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            lbl1.Text = "Editar";
            btnGrabar.Enabled = true;
            btnNuevo.Enabled = false;

            txtRazonSocial.Enabled = true;
            TxtDireccion.Enabled = true;
            txtTelefono.Enabled = true;
            txtRuc.Enabled = true;
            cboDistrito.Enabled = true;
            dtpFechaReg.Enabled = true;
            txtTipoCliente.Enabled = true;
            txtContacto.Enabled = true;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("nooooooooooooooooooooooooooooooooooooooooooooo");
                return;
            }
            
            String cadenaconexion = "Data Source=.;Initial Catalog=VentasLeon;Integrated Security=SSPI";

           
           
            if (lbl1.Text == "Nuevo")
            {

                SqlDataAdapter da = new SqlDataAdapter("insert into Tb_Cliente (Cod_cli,Raz_soc_cli,Dir_cli,Tel_cli,Ruc_cli,Cod_dis,Fec_reg,Tip_cli,Contacto) values('" + txtCodigo.Text + "','" + txtRazonSocial.Text + "','" + TxtDireccion.Text + "','" + txtTelefono.Text + "','" + txtRuc.Text + "','" + cboDistrito.SelectedValue + "','" + DateTime.Parse(dtpFechaReg.Text).ToString("yyyy/MM/dd") + "','" + txtTipoCliente.Text + "','" + txtContacto.Text + "')", cadenaconexion);
                DataSet ds = new DataSet();
                da.Fill(ds);
                MessageBox.Show("Se Ingresó Correcta");
            }

           

            if (lbl1.Text == "Editar")
            {
                SqlConnection conec = new SqlConnection(cadenaconexion);
                SqlDataAdapter da = new SqlDataAdapter("update dbo.Tb_Cliente SET Raz_soc_cli = '" + txtRazonSocial.Text + "',Dir_cli='" + TxtDireccion.Text + "',Tel_cli='" + txtTelefono.Text + "',Ruc_cli='" + txtRuc.Text + "',Cod_dis='" + cboDistrito.SelectedValue + "',Fec_reg='" + DateTime.Parse(dtpFechaReg.Text).ToString("yyyy/MM/dd") + "',Tip_cli='" + txtTipoCliente.Text + "',Contacto= '" + txtContacto.Text + "' where Cod_cli = '" + txtCodigo.Text + "'", conec);
                DataSet ds = new DataSet();
                da.Fill(ds);

                habilitar(false);
                MessageBox.Show("Se Actualizó..!");
                btnNuevo.Enabled = true;
                btnEditar.Enabled = true;
                btnGrabar.Enabled = false;
                btnCancelar.Enabled = false;
                cboDistrito.Enabled = false;
                dtpFechaReg.Enabled = false;
                
            }
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnCancelar.Enabled = false;
            btnGrabar.Enabled = false;
        }

        private void dtpFechaReg_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            SqlConnection conec = new SqlConnection("Data Source=.;Initial Catalog=VentasLeon;Integrated Security=SSPI");
            SqlDataAdapter da = new SqlDataAdapter("delete from dbo.Tb_Cliente where Cod_cli = '" + this.txtCodigo.Text + "'", conec);
            DataSet ds = new DataSet();
            da.Fill(ds);

            
            txtCodigo.Text = "";
            txtRazonSocial.Text = "";
            TxtDireccion.Text = "";
            txtTelefono.Text = "";
            txtRuc.Text = "";
            txtTipoCliente.Text = "";
            txtTipoCliente.Text = "";
            txtContacto.Text = "";
            cboDistrito.Text = "";
            MessageBox.Show("Borro..!");
        }

    }
}
