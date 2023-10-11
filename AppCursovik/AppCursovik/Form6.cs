using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComputerCursovik;
using System.Drawing.Drawing2D;
namespace AppCursovik
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            this.BackColor = Color.MediumAquamarine;//цвет формы 
        }
        public Form6(Form f)
        {
            InitializeComponent();
            this.BackColor = Color.MediumAquamarine;//цвет формы 
        }
        public Form6(Form1 f)
        {
            InitializeComponent();
            this.BackColor = Color.MediumAquamarine;//цвет формы 
        }
        GraphicsPath path = new GraphicsPath();
        DeliveryComponent h = new DeliveryComponent();
        private void Form6_Load(object sender, EventArgs e)
        {
            path.AddLine(75, 75, 70, 70);//координаты линий:декорация 
            path.AddLine(300, 300, 95, 95);//координаты линий:декорация 
            path.AddLine(600, 600, 87, 87);//координаты линий:декорация 
        }
        //кнопка "Перейти к корзине товаров"
        private void button1_Click(object sender, EventArgs e)
        {
            Form3 d = new Form3(this);
            Form6 k = new Form6(this);
            //проверка на выбор фирмы 
            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked && !radioButton4.Checked)//если не выбрана фирма
{
                h.Six += DisplayMessage;//обработка события 
                h.Button();//вызвать событие 
            }
else
            {
                h.Six += DisplayMessage;//обработка события 
                h.Button1();//вызвать событие 
                d.Show();//открыть форму 3 
                k.Close();//закрыть форму 6 
            }
        }
        //кнопка "Перейти в главное меню"
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 j = new Form1(this);
            Form6 h = new Form6(this);
            j.Show();//открыть форму 1 
            h.Close();//закрыть форму 6 
        }
        private static void DisplayMessage(string message)//обработчик события 
        {
            MessageBox.Show(message);
        }
        //кнопка "Посмотреть" 
        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;//активируем метод с прорисовкой графических объектов 
            timer1.Start();
            timer1.Interval = 500;
            //ФИРМА HYPERPCOM 
            DeliveryComponent d = new DeliveryComponent(10, 2590, 145, 19, 10, "Общество с органиченной ответственностью", 36,
            "возможна", 25, 56, 88, " 8(800) 775 - 82 - 35", 700, 1000, 2900, 5500, @"C:\Users\LED\Desktop\1_visual\5_visual\hypercom.png");
            d.Six += DisplayMessage;//обработка события 
            //комментарии пользователей 
            string commen1 = "Плохая сборка, завышенные цены"; 
string commen2 = "хороший ассортимент и сборка, простой интерфейс и регистрация";
            string commen3 = "Профессиональный подход, но высокие цены. Не испытывали никаких неудобств"; 
string commen4 = "Переплата за воздух, скудный выбор";
            d.Fon(comboBox1, radioButton1);//вызвать событие 
            d.Click2(radioButton1, listBox1, richTextBox1, richTextBox2, pictureBox1, commen1, commen2, commen3, commen4);//метод, выводящий в списке характеристики фирмы
            //фирма MERLIONA 
            DeliveryComponent j = new DeliveryComponent(7, 7028, 52, 79, 22, "Общество с ограниченной ответственностью", 12,
            "невозможна", 30, 64, 176, "+7 (495) 981-84-84", 890, 1100, 2600, 5100, @"C:\Users\LED\Desktop\1_visual\5_visual\merliona.png");
            j.Six += DisplayMessage;//обработка события 
            //комментарии пользователей 
            string reviews1 = "Халатное отношение к проблемам клиентов"; 
string reviews2 = "Сбор информации!";
            string reviews3 = "Не решили проблему!";
string reviews4 = "Грубые менеджеры"; 
j.Fon(comboBox1, radioButton2);//вызвать событие 
            j.Click2(radioButton2, listBox1, richTextBox1, richTextBox2, pictureBox1, reviews1, reviews2, reviews3, reviews4);//метод, выводящий в списке характеристики фирмы
            //ФИРМА АСКОНTOM 
            DeliveryComponent g2 = new DeliveryComponent(12, 8912, 37, 78, 31, "Общество с ограниченной ответственностью", 36,
            "невозможна", 40, 72, 123, "+7 351-21-71-516", 920, 1300, 2500, 4300, @"C:\Users\LED\Desktop\1_visual\5_visual\ackontom.png");
            g2.Six += DisplayMessage;//обработка события 
            //комментарии пользователей 
            string rev1 = "Нет гарантии, общение только через электронную почту, некачественный товар!"; 
string rev2 = "Хороший товар, постоянные акции и бонусы.";
            string rev3 = "Некачественные материалы";
            string rev4 = "Навязчивый сервис, высокие цены";
            g2.Fon(comboBox1, radioButton3);//вызвать событие 
            g2.Click2(radioButton3, listBox1, richTextBox1, richTextBox2, pictureBox1, rev1, rev2, rev3, rev4);//метод, выводящий в списке характеристики фирмы
//ФИРМА TEXEN
DeliveryComponent k = new DeliveryComponent(7, 912, 29, 35, 3, "Общество с ограниченной ответственностью", 24,
"возможна", 40, 62, 92, "8 (495) 651-99-99", 820, 1500, 3400, 4600, @"C:\Users\LED\Desktop\1_visual\5_visual\texen.png");
            k.Six += DisplayMessage;//обработка события 
            //комментарии пользователей 
            string r1 = "Заказ пришел не целым.Отсутствовала батарейка в изделии, на письмо не отреагировали.Не рекомендую";
           string r2 = "Отличная компания.Хорошие цены.Кратчайшие сроки доставки товара."; 
string r3 = "Хороший ассортимент, адекватные цены!!!";
            string r4 = "Магазин для профессионалов,весь материал по отличной цене"; 
k.Fon(comboBox1, radioButton4);//вызвать событие 
            k.Click2(radioButton4, listBox1, richTextBox1, richTextBox2, pictureBox1, r1, r2, r3, r4);//метод, выводящий в списке характеристики фирмы
        }
        //кнопка "Узнать цену" 
        private void button4_Click(object sender, EventArgs e)
        {
            DeliveryComponent n = new DeliveryComponent();
            //ФИРМА HYPERPCOM 
            if (radioButton1.Checked)//если выбрана 1 фирма 
            {
                n.Click7(listBox2, radioButton1, listBox1, textBox1, comboBox1, 590, 800, 2300, 5100, 900, 1500, 3000, 7000, 1200, 1900,
                3200, 7500, 1500, 1800, 3300, 6400);//вызов метода с выводом цены 
            }
            //фирма MERLIONA 
            if (radioButton2.Checked)//если выбрана 2 фирма 
            {
                n.Click7(listBox2, radioButton2, listBox1, textBox1, comboBox1, 690, 900, 2200, 4100, 1900, 2100, 4200, 7200, 900, 1600,
                3400, 7700, 1800, 2400, 3200, 6300);//вызов метода с выводом цены 
            }
            //ФИРМА АСКОНTOM 
            if (radioButton3.Checked)//если выбрана 3 фирма 
            {
                n.Click7(listBox2, radioButton3, listBox1, textBox1, comboBox1, 490, 800, 2590, 5300, 1700, 2800, 4100, 7100, 920, 1900,
                3600, 7900, 900, 2100, 3800, 6700);//вызов метода с выводом цены 
            }
            //фирма TEXEN 
            if (radioButton4.Checked)//если выбрана 4 фирма 
            {
                n.Click7(listBox2, radioButton4, listBox1, textBox1, comboBox1, 560, 790, 1000, 2490, 780, 990, 1260, 2400, 900, 1490, 2100,
                3400, 1100, 1800, 2500, 3600);//вызов метода с выводом цены 
            }
        }
        //кнопка "Список городов"
        private void button5_Click(object sender, EventArgs e)
        {
            //сформировать список городов в comboBox 
            DeliveryComponent h = new DeliveryComponent();
            h.CityChance(comboBox1, "Нижний Новгород", "Москва", "Стамбул", "Хельсинки");
        }
        private void Form6_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawPath(new Pen(Color.White), path);//контур линий 
        }
        private void timer1_Tick(object sender, EventArgs e)
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
                    Brush b1 = new HatchBrush(HatchStyle.DiagonalBrick, Color.White, Color.WhiteSmoke);//штриховая кисть 
                    Pen p1 = new Pen(b1, 10);//перо с толщиной 10 
                    g1.DrawRectangle(p1, 50, 50, 248, 248);//рисуем прямоугольник пером с координатами 
                    g1.RotateTransform(20);//поворачиваем фигуру на 20 градусов 
                }
                g1.ResetTransform();//возвращаем графический объект в исходное состояние 
                g1.Dispose();
            }
        
    }
}
