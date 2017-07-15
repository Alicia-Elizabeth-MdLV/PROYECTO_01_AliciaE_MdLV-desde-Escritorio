using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsSQLCommand
{
    public partial class FrmFactura : Form
    {
        public FrmFactura()
        {
            InitializeComponent();
        }
        DataTable TblDet;
        DataRow Rw;

        private void btnbuscarcliente_Click(object sender, EventArgs e)
        {
            FrmBuscar objeto = new FrmBuscar();
            objeto.ShowDialog();
            txtcliente.Text = objeto.contacto;
            txtruc.Text = objeto.ruc;
            txtdireccion.Text = objeto.direccion;
        }

        private void txtbuscarpro_Click(object sender, EventArgs e)
        {
            FrmBuscarProducto objeto = new FrmBuscarProducto();
            objeto.ShowDialog();
            txtproducto.Text = objeto.desc_pro;
            txtprecio.Text = objeto.pre_pro;
           // txtcantidad.Text = objeto.stk_min;
           
            //btneditar.Enabled = true;
        }

        private void txtruc_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnagregar_Click(object sender, EventArgs e)
        {


            Rw = TblDet.NewRow();
            //Rw = Me.XCodProdG.Trim;
            Rw[0] = Convert.ToInt64(txtcantidad.Text);
            Rw[1] = txtproducto.Text;
            Rw[2] = Convert.ToDouble(txtprecio.Text);
            Rw[3] = Convert.ToDouble(Rw[0]) * Convert.ToDouble(Rw[2]);

            TblDet.Rows.Add(Rw);
            TblDet.AcceptChanges();
            TotalValores();




            //dataGridView1.Rows.Add(Text,textBox1.Tex…
            //dgdatos.Rows.Add(Text, txtproducto.Text);
            //DataTable dt = dgdatos.DataSource; //cargamos la tabla que ya tenemos
            //DataRow row = dt.NewRow(); //creas un registro
            //row["Nombre"] = "Guillermo"; //Le añadres un valor
            //row["Apellido"] = "Salazar";
            //dt.Rows.Add(row); //añades el registro a la tabla
            //dgdatos.DataSource = dt; //añades la tabla al datagrid
            //dgdatos.Update(); //actualizas

            DataTable dt = new DataTable(); //creas una tabla
            dt.Columns.Add("CANT"); //le creas las columnas
            dt.Columns.Add("PRODUCTO");
            dt.Columns.Add("PRECIO-UNI");
            dt.Columns.Add("PRECIO-T");
            DataRow row = dt.NewRow(); //creas un registro
            row["CANT"] = txtcantidad.Text;//"txtcantidad.text"; //Le añadres un valor
            row["PRODUCTO"] = txtproducto.Text;//"Salazar";
            row["PRECIO-UNI"] = txtprecio.Text;
            row["PRECIO-T"] = txttotal.Text;
            dt.Rows.Add(row); //añades el registro a la tabla
            dgdatos.DataSource = dt; //añades la tabla al datagrid
            dgdatos.Update(); //actualizas
        }

            private void TotalValores()
        {
             double Xtotal;
            Xtotal = Convert.ToDouble(((TblDet.Compute("Sum(Importe)", null) == DBNull.Value) ? 0 : TblDet.Compute("Sum(Importe)", null)));
            txtsubtotal.Text = Xtotal.ToString();
             txtigv.Text = (Xtotal * 0.18).ToString();
            txttotal.Text = (Xtotal + (Xtotal * 0.18)).ToString("0.##");

}


        

        private void FrmFactura_Load(object sender, EventArgs e)
        {


            DataSet Ds = new DataSet();
            TblDet = Ds.Tables.Add();
            TblDet.Columns.Add("Cantidad", Type.GetType("System.Int32"));
            TblDet.Columns.Add("Descripcion", Type.GetType("System.String"));
            //TblDet.Columns.Add("Codigo", Type.GetType("System.String"));
            TblDet.Columns.Add("P. Unitario", Type.GetType("System.Double"));
            TblDet.Columns.Add("Importe", Type.GetType("System.Double"));
            //Ds.Tables[0].PrimaryKey = new DataColumn[] { Ds.Tables[0].Columns["Codigo"] };
            dgdatos.DataSource = TblDet;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
