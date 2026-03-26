using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Visible = true;
            textBox3.Visible = false;
            label1.Text = "Введите стороны A и B";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Visible = true;
            textBox3.Visible = true;
            label1.Text = "Введите стороны A, B и C";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Visible = false;
            textBox3.Visible = false;
            label1.Text = "Введите радиус R";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Pen pen = new Pen(Color.Red, 3);

            double a = 0, b = 0, c = 0; // Объявляем переменные один раз здесь

            try
            {
                // Считываем первое число (нужно для всех фигур)
                if (!double.TryParse(textBox1.Text, out a)) throw new Exception();

                if (radioButton1.Checked) // ПРЯМОУГОЛЬНИК
                {
                    b = double.Parse(textBox2.Text);
                    if (a <= 0 || b <= 0) { MessageBox.Show("Некорректный ввод"); return; }

                    label1.Text = $"Площадь прямоугольника: {a * b:F2}";

                    // Масштабирование и центрирование
                    float scale = (float)Math.Min((pictureBox1.Width * 0.8) / a, (pictureBox1.Height * 0.8) / b);
                    float w = (float)a * scale;
                    float h = (float)b * scale;
                    g.DrawRectangle(pen, (pictureBox1.Width - w) / 2, (pictureBox1.Height - h) / 2, w, h);
                }
                else if (radioButton2.Checked) // ТРЕУГОЛЬНИК
                {
                    b = double.Parse(textBox2.Text);
                    c = double.Parse(textBox3.Text);

                    if (a <= 0 || b <= 0 || c <= 0) { MessageBox.Show("Некорректный ввод"); return; }
                    if (a + b <= c || a + c <= b || b + c <= a) { MessageBox.Show("Вычисление невозможно"); return; }

                    double p = (a + b + c) / 2;
                    double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                    label1.Text = $"Площадь треугольника: {s:F2}";

                    // Геометрия координат для рисования (c - основание)
                    double x3 = (c * c + a * a - b * b) / (2 * c);
                    double y3 = Math.Sqrt(Math.Max(0, a * a - x3 * x3));

                    float scale = (float)Math.Min((pictureBox1.Width * 0.7) / c, (pictureBox1.Height * 0.7) / y3);
                    float offsetX = (pictureBox1.Width - (float)c * scale) / 2;
                    float offsetY = (pictureBox1.Height + (float)y3 * scale) / 2;

                    PointF p1 = new PointF(offsetX, offsetY);
                    PointF p2 = new PointF(offsetX + (float)c * scale, offsetY);
                    PointF p3 = new PointF(offsetX + (float)x3 * scale, offsetY - (float)y3 * scale);
                    g.DrawPolygon(pen, new PointF[] { p1, p2, p3 });
                }
                else if (radioButton3.Checked) // КРУГ
                {
                    if (a <= 0) { MessageBox.Show("Некорректный ввод"); return; }
                    label1.Text = $"Площадь круга: {Math.PI * a * a:F2}";

                    float scale = (float)Math.Min((pictureBox1.Width * 0.8) / (a * 2), (pictureBox1.Height * 0.8) / (a * 2));
                    float d = (float)(a * 2 * scale);
                    g.DrawEllipse(pen, (pictureBox1.Width - d) / 2, (pictureBox1.Height - d) / 2, d, d);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка! Введите числовые значения во все активные поля.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
