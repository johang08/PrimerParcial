using PrimerParcial.BLL;
using PrimerParcial.DAL;
using PrimerParcial.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimerParcial.UI
{
    public partial class Registro : Form
    {
        private readonly object errorProvider1;

        public Registro()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            IDnumericUpDown.Value = 0;
            NombretextBox.Text = string.Empty;
            RetenciontextBox.Text = string.Empty;
            RetenciontextBox.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private Vendedores LlenarClase()
        {
            Vendedores vendedores = new Vendedores();

            vendedores.IDVen = Convert.ToInt32(IDnumericUpDown.Value);
            vendedores.Nombre = NombretextBox.Text;
            vendedores.Sueldo = Convert.ToDecimal(SueldotextBox.Text);
            vendedores.Retencion = Convert.ToDecimal(RetenciontextBox.Text);
            vendedores.Total = Convert.ToDecimal(PorcientoRetenciontextBox.Text);
            vendedores.Fecha = dateTimePicker1.Value;

            return vendedores;
        }
        private bool Validar()
        {
            bool paso = true;
            if (RetenciontextBox.Text == string.Empty)
            {
                errorProvider2.SetError(RetenciontextBox, "Campo no puede estar en 0");
                paso = false;
            }
            if (RetenciontextBox.Text == string.Empty)
            {
                errorProvider2.SetError(RetenciontextBox, "Campo no puede estar en 0");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(NombretextBox.Text))
            {
                errorProvider2.SetError(NombretextBox, "Campo Vacio");
                paso = false;
            }
            return paso;
        }
        private bool EstaEnLaBaseDeDatos()
        {
            Vendedores vendedores = VendedoresBLL.Buscar((int)IDnumericUpDown.Value);
            return (vendedores != null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            errorProvider2.Clear();
            bool paso = false;
            Vendedores vendedores;
            Contexto contexto = new Contexto();

            if (!Validar())
                return;
            vendedores = LlenarClase();
            try
            {
                if (IDnumericUpDown.Value == 0)
                    paso = VendedoresBLL.Guardar(vendedores);
                else
                {
                    if (!EstaEnLaBaseDeDatos())
                    {
                        MessageBox.Show("No se puede modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    paso = VendedoresBLL.Modificar(vendedores);
                }
                if (paso)
                {
                    MessageBox.Show("Se Guardo Exitosamente", "Imformacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("No se Gurdo!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            errorProvider2.Clear();
            int id;

            int.TryParse(IDnumericUpDown.Text, out id);
            if (VendedoresBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Limpiar();
            errorProvider2.SetError(IDnumericUpDown, "no se puede eliminar");


        }
        private void LlenarCampo(Vendedores vendedores)
        {

            IDnumericUpDown.Value = vendedores.IDVen;
            NombretextBox.Text = vendedores.Nombre;
            SueldotextBox.Text = Convert.ToString(vendedores.Sueldo);
            RetenciontextBox.Text  = Convert.ToString(vendedores.Retencion);
            PorcientoRetenciontextBox.Text = Convert.ToString(vendedores.Total);
            dateTimePicker1.Value = vendedores.Fecha;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            errorProvider2.Clear();
            int id;
            Vendedores vendedores = new Vendedores();
            int.TryParse(IDnumericUpDown.Text, out id);

            vendedores = VendedoresBLL.Buscar(id);

            if (vendedores != null)
            {
                LlenarCampo(vendedores);
                MessageBox.Show("Encotrado");


            }
            else
            {
                MessageBox.Show("No Exite");
            }






        }



        private void SueldonumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            decimal sueldo = Convert.ToDecimal(RetenciontextBox.Text);
            decimal porciento = Convert.ToDecimal(PorcientoRetenciontextBox.Text);
            porciento /= 100;
            decimal retencion = porciento * sueldo;

            PorcientoRetenciontextBox.Text = Convert.ToString(retencion);
        }

        private void RetencionnumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            decimal sueldo = Convert.ToDecimal(RetenciontextBox.Text);
            decimal porciento = Convert.ToDecimal(PorcientoRetenciontextBox.Text);
            porciento /= 100;
            decimal retencion = porciento * sueldo;

            PorcientoRetenciontextBox.Text = Convert.ToString(retencion);

        }
    }

}


