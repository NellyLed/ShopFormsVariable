using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComputerCursovik;//ссылка на библиотеку 
using System.Drawing.Drawing2D;
namespace AppCursovik
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.BackColor = Color.MediumAquamarine;//цвет формы 
        }
        public Form2(Form1 f)
        {
            InitializeComponent();
            this.BackColor = Color.MediumAquamarine;//цвет формы 
        }
        public Form2(Form f)
        {
            InitializeComponent();
            this.BackColor = Color.MediumAquamarine;//цвет формы 
        }
        GraphicsPath path = new GraphicsPath();//графический путь 
        private void button1_Click(object sender, EventArgs e)//кнопка "Перейти на страницу с корзиной товара" 
        {
            Form3 j = new Form3(this);
            Form2 k = new Form2(this);
            ProcessorOne p1 = new ProcessorOne(textBox1.Text, Convert.ToDouble(textBox2.Text), Convert.ToDecimal(textBox3.Text),
            Convert.ToInt32(textBox4.Text)); //объект класса ProcessorOne с вводом пользователем характеристик процессора 
            p1.Two += DisplayMessage;//обработка события Two 
            p1.StampCheck();//вызов события-проверка допустимости значений 
            p1.FrequencyCheck();//вызов события-проверка допустимости значений 
            p1.KeshCheck();//вызов события-проверка допустимости значений 
            p1.CostCheck();//вызов события-проверка допустимости значений 
            p1.Conclusion(textBox1, textBox2, textBox3, textBox4);//проверка 
            MotherBoardOne p3 = new MotherBoardOne(textBox1.Text, Convert.ToDouble(textBox2.Text), Convert.ToDecimal(textBox3.Text),
            Convert.ToInt32(textBox4.Text),
            Convert.ToDouble(textBox5.Text), Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox7.Text), textBox8.Text,
            Convert.ToInt32(textBox9.Text));
            p3.Three += DisplayMessage1;//обработка события Three 
            p3.RamCheck();//вызов события-проверка допустимости значений 
            p3.Conclusion(textBox5, textBox6, textBox7, textBox8, textBox9);//вызов события-проверка допустимости значений 
            if (textBox5.Text == " " && textBox6.Text == " " && textBox7.Text == " " && textBox8.Text == " " && textBox9.Text == " ")//если текстовые блоки пустые
{
                p3.Conc();//вызов события Three 
            }
else
            {
                p3.Conclusion();//вызов события Three 
                j.Show();//открыть форму 3 
                k.Close();//закрыть форму 2 
            }
        }
        private static void DisplayMessage(object sender, FourEventArgs e)//обработчик события с дополнительным описанием 
        {
            MessageBox.Show(String.Format("Оповещение:{0}", e.Message));
        }
        private static void DisplayMessage1(string message)//обработчик события 
        {
            MessageBox.Show(message);
        }
        private void button2_Click(object sender, EventArgs e)//кнопка "Перейти в главное меню" 
        {
            Form2 f = new Form2(this);
            Form1 h = new Form1(this);
            h.Show();//открыть форму 1f.Close();//закрыть форму 2 
        }

        private void button3_Click(object sender, EventArgs e)//кнопка "Посмотреть" 
        {
            timer1.Enabled = true;//активируем метод с прорисовкой графических объектовtimer1.Start(); 
            timer1.Interval = 500;
            //ФИРМА AMD 
            Processor p = new Processor("AMD Ryzen 3 3100 AM4 100 - 000000284 OEM", 1.6, 16, 8199);
            p.List(listBox1);//вызов метода с заполнением 1 части списка основными типами 1 процессора 
            MotherBoard p2 = new MotherBoard("AMD Ryzen 3 3100 AM4 100 - 000000284 OEM", 1.6, 16, 8199, 4, 4, 8, "Matisse", 64);
            p2.List(listBox1);//вызов метода с заполнением 1 списка стандартными характеристиками 1 процессора 
            //ФИРМА Acer 
            Processor m = new Processor("Acer 9400F", 4.1, 9, 11999);
            m.List(listBox2);//вызов метода с заполнением 1 части списка основными типами 2 процессора 
            MotherBoard m1 = new MotherBoard("Acer 9400F", 4.1, 9, 11999, 4, 6, 6, "Coffee Lake R", 64);
            m1.List(listBox2);//вызов метода с заполнением 1 списка стандартными характеристиками 2 процессора 
                              //ФИРМА Apple 
            Processor k = new Processor("Mac mini Apple M1", 6.1, 8, 74990);
            k.List(listBox3);//вызов метода с заполнением 1 части списка основными типами 3 процессора 
            MotherBoard k1 = new MotherBoard("Mac mini Apple M1", 6.1, 8, 74990, 8, 8, 16, "Mac OS X", 128);
            k1.List(listBox3);//вызов метода с заполнением 1 списка стандартными характеристиками 3 процессора 
                              //ФИРМА Samsung 
            Processor n = new Processor("Samsung CP30 VME 10 _ dpram Rev 001 03 I/O Board", 1.86, 5, 18234);
            n.List(listBox4);//вызов метода с заполнением 1 части списка основными типами 4 процессора 
            MotherBoard n1 = new MotherBoard("Samsung CP30 VME 10 _ dpram Rev 001 03 I/O Board", 1.86, 5, 18234, 4, 3, 4, "Samsung R20", 64); 
            n1.List(listBox4);//вызов метода с заполнением 1 списка стандартными характеристиками 4 процессора 
        } 

        private void Form2_Load(object sender, EventArgs e)
        {
            //линии с координатами:дизайн 
            path.AddLine(75, 75, 70, 70);
            path.AddLine(300, 300, 95, 95);
            path.AddLine(600, 600, 87, 87);
        }
        private void timer1_Tick(object sender, EventArgs e)//загрузка 
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
        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawPath(new Pen(Color.White), path);//контур линий 
        }
    }
}
