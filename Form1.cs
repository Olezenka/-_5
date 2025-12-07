using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using РКИСЛР_5.FolderModels;

namespace РКИСЛР_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ModelEF model = new ModelEF();
            dataGridView1.DataSource = model.Student.ToList();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Form2AddData form = new Form2AddData();
            form.Show();
            Hide();
        }
    }
}
