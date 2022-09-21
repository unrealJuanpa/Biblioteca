using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BLL;
namespace WinUI
{
    public partial class Form1 : Form
    {
        ClassLogica Logica = new ClassLogica();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void Listar()
        {
            dataGridView1.DataSource = Logica.ListarEditoriales();
            dataGridView1.Refresh();
        }//Fin Listar
        private void button1_Click(object sender, EventArgs e)
        {
            Listar();
            button2.Enabled = true;
            button3.Enabled = false;
            button4.Enabled = false;
            groupBox1.Enabled = false;
            label6.Text = "Total editoriales: " + Logica.TotalEditoriales().ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            button2.Enabled = false;
            button3.Enabled = true;
            label4.Visible = false;
            comboBox1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string respuesta = "";
            respuesta = Logica.NuevaEditorial(textBox1.Text, textBox2.Text);
            if (respuesta.Contains("Error"))
                MessageBox.Show(respuesta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(respuesta, "Grabo editorial", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            groupBox1.Enabled = true;
            label4.Visible = true;
            comboBox1.Visible = true;
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            if (Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value) == 0)
                comboBox1.SelectedIndex = 1;
            else
                comboBox1.SelectedIndex = 0;
            label5.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            button4.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool estado;
            if (comboBox1.SelectedIndex == 0)
                estado = true;
            else
                estado = false;
            string respuesta;
            int ID = Convert.ToInt32(label5.Text);
            respuesta = Logica.ActulizaEditorial(textBox1.Text, textBox2.Text, estado, ID);
            if (respuesta.Contains("Error"))
                MessageBox.Show(respuesta, "Error al actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(respuesta, "Editorial actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Logica.BuscaPorPais(textBox3.Text);
            dataGridView1.Refresh();
        }
    }
}
