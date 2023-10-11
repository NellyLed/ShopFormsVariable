using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using ComputerCursovik;

namespace AppCursovik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.MediumAquamarine;//цвет формы 
        }
        public Form1(Form j)
        {
            InitializeComponent();
            this.BackColor = Color.MediumAquamarine;//цвет формы 
        }
        GraphicsPath path = new GraphicsPath();
        private void button1_Click(object sender, EventArgs e)//кнопка "Приобрести" 
        {
            Form1 n = new Form1(this);//лбъект формы 1 
            Form2 h = new Form2(this);//объект формы 2 
            Form3 k = new Form3(this);//объект формы 3 
            Form4 f = new Form4(this);//объект формы 4 
            Form5 l = new Form5(this);//объект формы 5 
            Menus m = new Menus();
            //если выбран 1 radioButton-процессор 
            if (radioButton1.Checked)
            {
                m.One += DisplayMessage;//обработка события One 
                m.Button1();//вызов события 
                h.Show();//открытие формы 2 
                n.Hide();//закрытие формы 1 
            }
            //если выбран 2 radioButton-компоненты компьютера 
            if (radioButton2.Checked)
            {
                m.One += DisplayMessage;//обработка события One 
                m.Button2();//вызов события 
                f.Show();//открытие формы 4 
                n.Hide();//закрытие формы 1 
            }//если выбран 3 radioButton-доставка компонентов компьютера 
            if (radioButton3.Checked)
            {
                m.One += DisplayMessage;//обработка события One 
                m.Button3();//вызов события One 
                l.Show();//открытие формы 5 
                n.Hide();//закрытие формы 1 
            }
            //выбор 4 radioButton-все вышеперечисленное 
            if (radioButton4.Checked)
            {
                m.One += DisplayMessage;//обработка события One 
                m.Button4();//вызов события One 
                h.Show();//открытие формы 2 
                n.Hide();//закрытие формы 1 
            }
            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked && !radioButton4.Checked)//если ни одна фирме не выбрана
{
                m.One += DisplayMessage;//вызов события 
                m.Button();//в зависимости от выбора radiobutton выводится определенное сообщение 
            }
        }

        private void button2_Click(object sender, EventArgs e)//кнопка "Посмотреть"
        {
            timer1.Enabled = true;//активируем метод с прорисовкой графических объектов 
            timer1.Start();
            timer1.Interval = 500;
            if (radioButton1.Checked)//если выбрана фирма 1 
            {
                Menus m6 = new Menus(@"C:\Users\LED\Desktop\1_visual\5_visual\acer проц.jpg", @"C:\Users\LED\Desktop\1_visual\5_visual\apple проц.jpg", @"C:\Users\LED\Desktop\1_visual\5_visual\amd проц.jpg");
                m6.Metod(pictureBox1, pictureBox2, pictureBox3);//вызов метода,выводящего изображение(картинку) в pictureBox 
            }
            if (radioButton2.Checked)//если выбрана фирма 2 
            {
                Menus m7 = new Menus(@"C:\Users\LED\Desktop\1_visual\5_visual\comp 1.jpg", @"C:\Users\LED\Desktop\1_visual\5_visual\comp 2.jpg", @"C:\Users\LED\Desktop\1_visual\5_visual\comp 3.jpg");
                m7.Metod(pictureBox1, pictureBox2, pictureBox3);//вызов метода,выводящего изображение(картинку) в pictureBox 
            }
            if (radioButton3.Checked)//если выбрана фирма 3 
            {
                Menus m8 = new Menus(@"C:\Users\LED\Desktop\1_visual\5_visual\doct 1.jpg", @"C:\Users\LED\Desktop\1_visual\5_visual\doct 2.jpg", @"C:\Users\LED\Desktop\1_visual\5_visual\doct 3.jpg");
                m8.Metod(pictureBox1, pictureBox2, pictureBox3);//вызов метода,выводящего изображение(картинку) в pictureBox 
            }
            if (radioButton4.Checked)//если выбрана фирма 4 
            {
                Menus m9 = new Menus(@"C:\Users\LED\Desktop\1_visual\5_visual\acer проц.jpg", @"C:\Users\LED\Desktop\1_visual\5_visual\comp 1.jpg", @"C:\Users\LED\Desktop\1_visual\5_visual\doct 3.jpg");
                m9.Metod(pictureBox1, pictureBox2, pictureBox3);//вызов метода,выводящего изображение(картинку) в pictureBox 
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //дизайн формы(линии) 
            path.AddLine(75, 75, 70, 70);
            path.AddLine(300, 300, 95, 95);
            path.AddLine(600, 600, 87, 87);
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawPath(new Pen(Color.White), path);//контур линий 
        }
        private static void DisplayMessage(string message)//обработчик события 
        {
            MessageBox.Show(message);
        }
        private void timer1_Tick(object sender, EventArgs e)//прорисовка графических объектов,прямоугольников и кругов 
        {
            Graphics g = this.CreateGraphics();//графический объект 
            Rectangle rec = new Rectangle(409, 409, 250, 250);//область для выведения эллипса 
            Brush b = new HatchBrush(HatchStyle.DiagonalBrick, Color.White, Color.FloralWhite);//штриховая кисть 
            Pen p = new Pen(b, 10);//перо 
            g.DrawEllipse(p, rec);//начинаем рисовать контур эллипса 
            for (int i = 0; i <= 360; i += 10)//цикл со счетчиком 
            {
                LinearGradientBrush bom = new LinearGradientBrush(rec, Color.WhiteSmoke, Color.White, i);//горизонтальный градиент 
                g.FillEllipse(bom, rec);//заливка эллипса градиентом 
            }
            g.Dispose();
            Graphics g1 = this.CreateGraphics();
            for (int i = 0; i < 360; i += 15)//цикл ссо счетчиком 
            {
                Brush b1 = new HatchBrush(HatchStyle.DiagonalBrick, Color.White, Color.WhiteSmoke);
                Pen p1 = new Pen(b1, 10);//перо с толщиной 10 
                g1.DrawRectangle(p1, 50, 50, 248, 248);//рисуем прямоугольник пером с координатами 
                g1.RotateTransform(20);//поворачиваем фигуру на 20 градусов 
            }
            g1.ResetTransform();//возвращаем графический объект в исходное состояние 
            g1.Dispose();
        }
    }
}
