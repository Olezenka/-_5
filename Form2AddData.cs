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
    public partial class Form2AddData : Form
    {
        public Form2AddData()
        {
            InitializeComponent();
        }

        private void Form2AddData_Load(object sender, EventArgs e)
        {

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxName.Text) || String.IsNullOrWhiteSpace(textBoxGroup.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены");
                return;
            }
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Добавьте изображение");
                return;
            }
            ModelEF model = new ModelEF();
            Student student = new Student();
            student.Name = textBoxName.Text;
            student.Group_ = textBoxGroup.Text;
            byte[] bImg = (byte[])new ImageConverter().ConvertTo(pictureBox1.Image, typeof(byte[]));
            student.Photo = bImg;
            model.Student.Add(student);
            try
            {
                model.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Сохранено");
            textBoxName.Text = "";
            textBoxGroup.Text = "";
            pictureBox1.Image = null;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Выберите фото студента";
            ofd.Filter = "Файлы JPG, PNG|*.jpg;*.png|Все файлы (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
                pictureBox1.Image = Image.FromFile(ofd.FileName);
        }
    }
}
