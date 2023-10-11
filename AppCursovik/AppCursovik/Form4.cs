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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            this.BackColor = Color.MediumAquamarine;//цвет формы 
        }
        public Form4(Form3 f)
        {
            InitializeComponent();
            this.BackColor = Color.MediumAquamarine;//цвет формы 
        }
        public Form4(Form f1)
        {
            InitializeComponent();
            this.BackColor = Color.MediumAquamarine;//цвет формы 
        }
        GraphicsPath path = new GraphicsPath();//графический путь 
        Computer q = new Computer();//объект класса Computer 
        private void button1_Click(object sender, EventArgs e)//кнопка "Перейти в корзину товаров" 
        {
            Form3 j = new Form3(this);
            Form4 h = new Form4(this);
            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked && !radioButton4.Checked)//если не выбрана фирма
            {
                q.Four += DisplayMessage;//обработка события Four 
                q.Button1();//вызов события Four 
            }
            else
            {
                q.Four += DisplayMessage;//обработка события Four 
                q.Button();//вызов события Four 
                j.Show();//открыть форму 3 
                h.Close();//закрыть форму 4 
            }
        }
        private static void DisplayMessage(string message)//обработчик событий 
        {
            MessageBox.Show(message);
        }
        //кнопка "Перейти к выбору фирмы,занимающейся сборкой компьютера" 
        private void button2_Click(object sender, EventArgs e)
        {
            Form5 g = new Form5(this);
            Form4 h1 = new Form4(this);
            g.Show();//открыть форму 5 
            h1.Close();//закрыть форму 4 
        }
        //кнопка "Перейти в главное меню" 
        private void button3_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4(this);
            Form1 j = new Form1(this);
            j.Show();//открыть форму 1 
            f.Close();//закрыть форму 4 
        }

        //кнопка "Посмотреть" 
        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;//активируем метод с прорисовкой графических объектов 
            timer1.Start();
            timer1.Interval = 500;
            //ФИРМА AMD 
            Computer c = new Computer("SSD AMD Radeon 240Gb", "Gigabyte GV-R55XTGAMING OC-4GD", "Gigabyte GA - B250M - DS3H", "TP - LINK UE200", 
            "Thermaltake LT - 650P(черный)", "DVD-ROM Hitachi-LG DH18NS61", " HP Slim S01-aF0009ur", "AMD FreeSync", "AMD High Definition Audio Device", "AMD DDR3 4Gb 1600MHz 240 - pin", @"C:\Users\LED\Desktop\1_visual\5_visual\amd.jpg"); 
            //комментарии пользователей 
            string comment1 = "Диски подошли, качеством остался доволен, работает все отлично.Всем рекомендую"; 
            string comment2 = "Купил катушку зажигания компании AMD, поставил, все летает";
            c.Click2(radioButton1, listBox1, richTextBox1, pictureBox1, textBox1, comment1, comment2);//вызов метода с выводом характеристик фирмы, ее отзывов и логотипа
             //ФИРМА Acer 
             Computer c1 = new Computer("Toshiba L200 2.5 HDWJ105EZSTA", "Asus GeForce GT 1030 PH-GT1030-2G", "ASRock 760GM - HDV", " ACER 19V 3.42A 5.5X1.7ММ OEM", "ACER 19V 2.37A 45W 5.5X1.7MM", 
             "Acer LC.EXD0A.003", "Acer Veriton ES2710G", "Acer Nitro VG242YPbmiipx", "Palmexx USB Sound Adapter 7.1 Channel",
             "Acer U30512AAUIQ652AW20", @"C:\Users\LED\Desktop\1_visual\5_visual\acer.jpg");
            //комментарии пользователей 
            string comment3 = "Нулевая производительность. Переключить язык - задача на минуту."; 
string comment4 = "Экран четкий,справляется со всеми задачами,крепление прочное."; 
c1.Click2(radioButton2, listBox1, richTextBox1, pictureBox1, textBox1, comment3, comment4);//вызов метода с выводом характеристик фирмы, ее отзывов и логотипа
             //ФИРМА Apple 
             Computer c2 = new Computer("Apple A1355 Time Capsule Wi-Fi", "Apple ATI Radeon HD 4870", "Apple iMac 27 A1419", "Apple MD836ZM / A", "Apple MagSafe 2 85W", "Apple USB SuperDrive", 
             "Apple Mac mini Core i5 1.4 GHz", "Apple Pro Display XDR", "Apple Lightning - mini jack 3.5 (MMX62ZM/A)", "Apple DDR4 SO - DIMM 16 ГБ", @"C:\Users\LED\Desktop\1_visual\5_visual\apple.jpg"); 
             //комментарии пользователей 
             string comment5 = "Компактный, мышь работает,звук хороший";
            string comment6 = "Часто приходится менять батарейку на мышке";
            c2.Click2(radioButton3, listBox1, richTextBox1, pictureBox1, textBox1, comment5, comment6);//вызов метода с выводом характеристик фирмы, ее отзывов и логотипа
             //ФИРМА Samsung 
             Computer c3 = new Computer("SSD-накопитель Samsung 860 EVO", "MSI GeForce GT 710 1GB Silent LowProfile", "Samsung Galaxy S7 Edge G935F", "Samsung EP - TA800", 
             "Samsung AD-9019S", "Toshiba Samsung Storage Technology SE-506CB Black", "HP Slim S01-aF0012ur 28R03EA", "Samsung S24F350FHI black / LS24F350FHIXCI / ", "Samsung USB Type C", "Samsung[M378A5244CB0 - CRC] 4 ГБ", @"C:\Users\LED\Desktop\1_visual\5_visual\samsung_2.jpg"); 
             //комментарии пользователей 
             string comment7 = "Комплектация так себе, модель наушников не совсем современна";
            string comment8 = "Аккумулятор на долго хватает, экран широкий, камера четкая,быстрая зарядка";
            c3.Click2(radioButton4, listBox1, richTextBox1, pictureBox1, textBox1, comment7, comment8);//вызов метода с выводомхарактеристик фирмы,ее отзывов и логотипа 
        }
        //кнопка "Узнать стоимость" 
        private void button5_Click(object sender, EventArgs e)
        {
            //фирма AMD 
            List<int> Fon = new List<int>();//коллекция с типом int 
            Computer v = new Computer(2499, 16599, 5299, 690, 3890, 1199, 17990, 6950, 390, 2599);
            v.Click4(Fon);//вызов метода с определением стоимости всех компонентов компьютера 
            if (radioButton1.Checked)//если выбрана 1 фирма 
            {
                v.Click3(listBox1, listBox2);//вызов метода с определением цены компонента компьютера для 1 фирмы 
            }
            v.Distribution(textBox1, radioButton1);//вызов метода с выводом цены компонента компьютера для 1 фирмы 
            //фирма Acer 
            List<int> Ren = new List<int>();
            Computer v1 = new Computer(2670, 6709, 4100, 490, 495, 2100, 46000, 17900, 450, 5131);
            v1.Click4(Ren);//вызов метода с определением стоимости всех компонентов компьютера 
            if (radioButton2.Checked)//если выбрана 2 фирма 
            {
                v1.Click3(listBox1, listBox2);//вызов метода с определением цены компонента компьютера для 2 фирмы 
            }
            v1.Distribution(textBox1, radioButton2);//вызов метода с выводом цены компонента компьютера для 2 фирмы 
            //фирма Apple 
            List<int> Ten = new List<int>();
            Computer v2 = new Computer(3752, 3920, 19000, 990, 3990, 7900, 29981, 20990, 790, 40000);
            v2.Click4(Ten);//вызов метода с определением стоимости всех компонентов компьютера 
            if (radioButton3.Checked)//если выбрана 3 фирма 
            {
                v2.Click3(listBox1, listBox2);//вызов метода с определением цены компонента компьютера для 3 фирмы 
            }
            v2.Distribution(textBox1, radioButton3);//вызов метода с выводом цены компонента компьютера для 3 фирмы 
            //фирма Samsung 
            List<int> Lir = new List<int>();
            Computer v3 = new Computer(3699, 3300, 3851, 1999, 690, 4199, 29990, 8790, 443, 1550);
            v3.Click4(Lir);//вызов метода с определением стоимости всех компонентов компьютера 
            if (radioButton4.Checked)//если выбрана 4 фирма 
            {
                v3.Click3(listBox1, listBox2);//вызов метода с определением цены компонента компьютера для 4 фирмы 
            }
            v3.Distribution(textBox1, radioButton4);//вызов метода с выводом цены компонента компьютера для 4 фирмы 
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            //линии с координатами:дизайн 
            path.AddLine(75, 75, 70, 70);
            path.AddLine(300, 300, 95, 95);
            path.AddLine(600, 600, 87, 87);
        }
        private void Form4_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawPath(new Pen(Color.White), path);//контур линий 
        }
        //прорисовка графических объектов,прямоугольников и кругов 
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
