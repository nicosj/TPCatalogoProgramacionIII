﻿using ConexionDB;
using Dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Catalogo
{
    public partial class frmAddCategoria : Form
    {
        private Categoria categoria = null;
        public frmAddCategoria()
        {
            InitializeComponent();
        }

        //constructor sobrecargado para usar la misma ventana para agregar y modificar//
        public frmAddCategoria(Categoria categoria)
        {
            InitializeComponent();
            this.categoria = categoria;
            Text = "Modificar categoria";
        }



        private void btAceptar_Click(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria();
            DB dB = new DB();
            try
            {
                if (categoria == null)
                {
                    categoria = new Categoria();
                }
                //categoria.Id = int.Parse(txtAddID.Text);
                    categoria.Descripcion = txtAddCategoria.Text;
              // categoria.Id =txtAddID.Text;


                if (categoria.Id != 0)
                {
                    dB.setearConsulta("update Categorias set Descripcion=@Descripcion WHERE Id=@id");
                    dB.setearParametro("@Descripcion", categoria.Descripcion);
                    dB.ejecutarLectura();
                    MessageBox.Show("Categoria modificada correctamente");
                }
                else
                {
                    dB.setearConsulta("insert into Categorias values (@Descripcion)");
                    dB.setearParametro("@Descripcion", categoria.Descripcion);
                    dB.ejecutarLectura();
                    MessageBox.Show("Categoria agregada correctamente");
                    Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAddCategoria_Load(object sender, EventArgs e)
        {
            NegocioCategoria negociocategoria = new NegocioCategoria();
            try
            {
                txtAddID.Text = "Id";
                txtAddCategoria.Text = "Descripcion";

                if (categoria != null)
                {
                    txtAddCategoria.Text = categoria.Descripcion;
                    txtAddID.Text = categoria.Id.ToString();
                }
            }
            catch (Exception ex){
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
