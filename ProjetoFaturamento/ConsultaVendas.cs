using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace ProjetoFaturamento
{
    public partial class ConsultaVendas : Form
    {
        DataTable dbdataset;
        int cont = 31;
        Cliente cad = new Cliente();
        float precototal;
        public String mensagem = "";
        Conexao conexao = new Conexao();
        DataTable dt = new DataTable();
        public ConsultaVendas()
        {
            InitializeComponent();
        }

        private void vendaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.vendaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bdFaturaDataSet2);

        }

        private void ConsultaVendas_Load(object sender, EventArgs e)
        {
            
            // TODO: esta linha de código carrega dados na tabela 'bdFaturaDataSet2.Venda'. Você pode movê-la ou removê-la conforme necessário.
            this.vendaTableAdapter.Fill(this.bdFaturaDataSet2.Venda);
            //textBox2.Text = vendaDataGridView.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDouble(i.Cells[valor.Name].Value ?? 0)).ToString("##.00");
            Somatorio();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Faturamento faturamento = new Faturamento();
            faturamento.Show();
            this.Hide();
        }

        private void btnDash_Click(object sender, EventArgs e)
        {
            Menu abrir = new Menu();
            abrir.Show();
            this.Hide();
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            Faturamento abrir = new Faturamento();
            abrir.Show();
            this.Hide();
        }

        private void btnCadCli_Click(object sender, EventArgs e)
        {
            CadastroCliente abrir = new CadastroCliente();
            abrir.Show();
            this.Hide();
        }

        private void btnSair_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CadastroProduto abrir = new CadastroProduto();
            abrir.Show();
            this.Hide();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BindingSource vbs = new BindingSource();
            vbs.DataSource = vendaDataGridView.DataSource;
            vbs.Filter = "data_compra LIKE '%"+textBox1.Text+"%'";
            vendaDataGridView.DataSource = vbs;
        }

        public void Somatorio()
        {
            //vendaDataGridView.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDouble(i.Cells["valor"].Value)).ToString("N2");
            
            //this.textBox2.Text = vendaDataGridView.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells[1].Value ?? 0)).ToString();
            
        }

        private void textBox2_MouseMove(object sender, MouseEventArgs e)
        {
            this.textBox2.Text = vendaDataGridView.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells[1].Value ?? 0)).ToString("C");
        }
    }
    }
