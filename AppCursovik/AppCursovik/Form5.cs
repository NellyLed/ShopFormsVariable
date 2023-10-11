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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            this.BackColor = Color.MediumAquamarine;//цвет формы 
        }
        public Form5(Form4 f)
        {
            InitializeComponent();
            this.BackColor = Color.MediumAquamarine;//цвет формы 
        }
        public Form5(Form1 f)
        {
            InitializeComponent();
            this.BackColor = Color.MediumAquamarine;//цвет формы 
        }
        public Form5(Form3 f)
        {
            InitializeComponent();
            this.BackColor = Color.MediumAquamarine;//цвет формы 
        }
        public Form5(Form6 f)
        {
            InitializeComponent();
            this.BackColor = Color.MediumAquamarine;//цвет формы 
        }
        public Form5(Form f)
        {
            InitializeComponent();
            this.BackColor = Color.MediumAquamarine;//цвет формы 
        }
        GraphicsPath path = new GraphicsPath();//графический путь 
        WorkCompany d = new WorkCompany();//объект класса WorkCompany 
        private void button1_Click(object sender, EventArgs e)//кнопка "Перейти к способу доставки" 
        {
            Form5 g = new Form5(this);
            Form6 w = new Form6(this);
            w.Show();//открытие 6 формы 
            g.Close();//закрытие 5 формы 
        }
        //кнопка "Перейти к корзине товаров" 
        private void button2_Click(object sender, EventArgs e)
        {
            Form3 h = new Form3(this);
            Form5 f = new Form5(this);
            //проверка на выбор фирмы 
            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked && !radioButton4.Checked)//если не выбрана фирма
{
                d.Five += DisplayMessage;//обработка события 
                d.Button1();//вызов события 
            }
else
            {
                d.Five += DisplayMessage;//обработка события 
                d.Button();//вызов события 
                h.Show();//открытие 3 формы 
                f.Close();//закрытие 5 формы 
            }
        }
        //кнопка "Перейти в главное меню" 
        private void button3_Click(object sender, EventArgs e)
        {
            Form1 j = new Form1(this);
            Form5 h = new Form5(this);
            j.Show();//открытие 1 формы 
            h.Close();//закрытие 5 формы 
        }
        //кнопка "Посмотреть" 
        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;//активируем метод с прорисовкой графических объектов 
            timer1.Start();
            timer1.Interval = 500;
            //ФИРМА TANDEM 
            WorkCompany b = new WorkCompany(8, 5000, 30, 8, 23, "Общество с органиченной ответственностью",
            @"C:\Users\LED\Desktop\1_visual\5_visual\tandem.png");
            //комментарии пользователей 
            string com1 = "Гарантия пол года, отличное железо по хорошей цене.Одно из немногих мест таких мест,где можно получить гарантию";
            string com2 = "Игры летают.Цена как в объявлении.Исправили все бесплатно даже после окончания гарантии."; 
string com3 = "Вежливые ребята продавцы, компьютер собран аккуратно, коробка и чек на месте."; 
string com4 = " Тех. поддержка работает, заботятся о клиентах"; 
b.Click2(radioButton1, listBox1, richTextBox1, richTextBox1, pictureBox1, com1, com2, com3, com4);//вызов метода с выводом характеристик фирмы 1
//ФИРМА КouDo 
WorkCompany b1 = new WorkCompany(10, 1900, 18, 35, 8, "Общество с ограниченной ответственностью",
@"C:\Users\LED\Desktop\1_visual\5_visual\koudo.png");
            //комментарии пользователей 
            string com5 = "Интерфейс сайта неудобный,услуги не были оказаны..."; 
string com6 = "Очень жаль, что на сайте предлагают свои услуги такие горе-специалисты, которые до конца не разбираяются в том деле, за которое берутся"; 
string com7 = "Сайт неплохой";
            string com8 = "Сервис хорош, правда есть недочеты.";
            b1.Click2(radioButton2, listBox1, richTextBox1,richTextBox1, pictureBox1, com5, com6, com7, com8);//вызов метода с выводом характеристик фирмы 2
//ФИРМА Позитив 
WorkCompany n = new WorkCompany(5, 950, 8, 36, 18, "Общество с органиченной ответственностью", @"C:\Users\LED\Desktop\1_visual\5_visual\позитив.png"); 
//комментарии пользователей 
string com9 = "Достоверной информации на сайте не дают, менеджер не отвечает"; 
string com10 = "Не обращайтесь сюда никогда! Цены не соответствуют прейскуранту"; 
string com11 = "Специалисты некомпетентны, устанавливают устаревшие программы и выдают за новые!"; 
string com12 = "У меня осталось неприятное впечатление от работы с этой компанией. Не рекомендую!";
n.Click2(radioButton3, listBox1, richTextBox1, richTextBox1, pictureBox1, com9, com10, com11, com12);//вызов метода с выводом характеристик фирмы 3
//ФИРМА СитиЛино
WorkCompany p = new WorkCompany(8, 3000, 18, 29, 12, "Общество с органиченной ответственностью", @"C:\Users\LED\Desktop\1_visual\5_visual\ситилино.png"); 
//комментарии пользователей 
string com13 = "Не проводят проверку при выдаче. Когда указываешь на проблему обещают, что примут и еще раз все проверят за неделю, но техника, опять же, приходит с поломками."; 
string com14 = "Невозможно вернуть товар или обменять его";
            string com15 = "Без возврата и обмена!Не дают осмотреть технику до оплаты"; 
string com16 = "Долгое обслуживание, не уважают покупателя";
            p.Click2(radioButton4, listBox1, richTextBox1, richTextBox1, pictureBox1, com13, com14, com15, com16);//вызов метода с выводом характеристик фирмы 4
        }
        //кнопка "Узнать стоимость" 
        private void button5_Click(object sender, EventArgs e)
        {
            //ФИРМА TANDEM 
            d.Distribution(textBox1, radioButton1, 15900);//вызов метода с выводом стоимости фирмы 1 
            //ФИРМА КouDo 
            d.Distribution(textBox1, radioButton2, 29900);//вызов метода с выводом стоимости фирмы 2 
            //ФИРМА Позитив 
            d.Distribution(textBox1, radioButton3, 10000);//вызов метода с выводом стоимости фирмы 3 
            //ФИРМА СитиЛино 
            d.Distribution(textBox1, radioButton4, 12900);//вызов метода с выводом стоимости фирмы 4 
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            //линии с координатами:дизайн 
            path.AddLine(75, 75, 70, 70);
            path.AddLine(300, 300, 95, 95);
            path.AddLine(600, 600, 87, 87);
        }
        private static void DisplayMessage(string message)//обработчик событий 
        {
            MessageBox.Show(message);
        }
        private void Form5_Paint(object sender, PaintEventArgs e)
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
