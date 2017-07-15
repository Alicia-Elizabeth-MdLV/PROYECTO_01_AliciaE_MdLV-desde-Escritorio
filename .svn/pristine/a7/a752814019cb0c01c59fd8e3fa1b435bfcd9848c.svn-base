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
    public partial class FrmBuscarProducto : Form
    {
        public String codigo;
        public String desc_pro;
        public String pre_pro;
        public String stk_act;
        public String stk_min;
        public String uni_med;
        public String lin_pro;
        public String importado;
        

        String cadenaconexion = "Data Source=.;Initial Catalog=VentasLeon;Integrated Security=SSPI";

        public FrmBuscarProducto()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            SqlConnection conexionSQL = new SqlConnection(cadenaconexion);
            DataSet dsProducto = new DataSet();

            SqlDataAdapter daProducto = new SqlDataAdapter("select * from tb_Producto where Cod_pro='" + this.txtbuscar.Text + "'", conexionSQL);
            SqlDataAdapter daaProducto = new SqlDataAdapter("select * from tb_Producto where Des_pro like'" + this.txtbuscar.Text + "%'", conexionSQL);
            conexionSQL.Open();
            daProducto.Fill(dsProducto);
            daaProducto.Fill(dsProducto);
            dgdatos.DataSource = dsProducto.Tables[0].DefaultView;
            conexionSQL.Close();
           btnaceptar.Enabled = true;
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            codigo = Convert.ToString(dgdatos.CurrentRow.Cells[0].Value);
            desc_pro = Convert.ToString(dgdatos.CurrentRow.Cells[1].Value);
            pre_pro = Convert.ToString(dgdatos.CurrentRow.Cells[2].Value);
            stk_act = Convert.ToString(dgdatos.CurrentRow.Cells[3].Value);
            stk_min = Convert.ToString(dgdatos.CurrentRow.Cells[4].Value);
            uni_med = Convert.ToString(dgdatos.CurrentRow.Cells[5].Value);
            lin_pro = Convert.ToString(dgdatos.CurrentRow.Cells[6].Value);
            importado = Convert.ToString(dgdatos.CurrentRow.Cells[7].Value);

            this.Close();
        }
    }
}
