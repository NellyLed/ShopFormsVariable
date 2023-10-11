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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.BackColor = Color.MediumAquamarine;//цвет формы 
        }
        public Form3(Form2 f)
        {
            InitializeComponent();
            this.BackColor = Color.MediumAquamarine;//цвет формы 
        }
        public Form3(Form1 f)
        {
            InitializeComponent();
            this.BackColor = Color.MediumAquamarine;//цвет формы 
        }
        public Form3(Form4 f)
        {
            InitializeComponent();
            this.BackColor = Color.MediumAquamarine;//цвет формы 
        }
        public Form3(Form f)
        {
            InitializeComponent();
            this.BackColor = Color.MediumAquamarine;//цвет формы 
        }
        GraphicsPath path = new GraphicsPath();//графический путь 
       
        Computer q2 = new Computer();
        private void button1_Click(object sender, EventArgs e)//кнопка "Оплатить" 
        {
            Shop3 n = new Shop3();//обхект класса Shop3 
            n.Seven += DisplayMessage;//обработка события Seven 
            n.Check1(textBox1, textBox8, textBox9, textBox10, textBox11);//вызов метода с суммированием значений в текстовых блоках  для выведения итоговой суммы в другом textBox
            n.Ret();//вызов события Seven 
        }

        private static void DisplayMessage(string message)//обработка события 
        {
            MessageBox.Show(message);
        }
        private void button2_Click(object sender, EventArgs e)//кнопка "Перейти к рассмотрению компонентов компьютера" 
        {
            Form3 s = new Form3(this);
            Form4 a = new Form4(this);
            a.Show();//открытие формы 4 
            s.Close();//закрытие формы 3 
        }

        private void button3_Click(object sender, EventArgs e)//кнопка "Перейти в главное меню" 
        {
            Form1 f = new Form1(this);
            Form3 h = new Form3(this);
            f.Show();//открытие формы 1 
            h.Close();//закрытие формы 3 
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
        private void Form3_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawPath(new Pen(Color.White), path);//контур линий 
        }
        private void button4_Click(object sender, EventArgs e)//кнопка "Посчитать отдельно"
        {
            timer1.Enabled = true;//активируем метод с прорисовкой графических объектов 
            timer1.Start();
            timer1.Interval = 500;
            //ФИРМА,ПРОДАЮЩАЯ ПРОЦЕССОР 
            //фирма AMD 
          
            ShoppingCart n3 = new ShoppingCart("AMD Ryzen 3 3100 AM4 100 - 000000284 OEM", 1.6, 16, 8199, 4, 4, 8, "Matisse", 64,
            "Малайзия", 12, 5, new DateTime(2020 / 11 / 05), new Processor("Белый"), "Процессор");
            n3.Choice(textBox2, "AMD", listBox2, listBox1);
            //вызов метода с выведением наименования "Процессор" в 1 списке 
            //фирма Acer 
            ShoppingCart p2 = new ShoppingCart("Acer 9400F", 4.1, 9, 11999, 4, 6, 6, "Coffee Lake R", 64, "Вьетнам", 36, 8, new
            DateTime(2019 / 09 / 12), new Processor("Синий"), "Процессор");
            p2.Choice(textBox2, "Acer", listBox2, listBox1);
            //вызов метода с выведением наименования "Процессор" в 1 списке 
            //фирма Apple 
            ShoppingCart k2 = new ShoppingCart("Mac mini Apple M1", 6.1, 8, 74990, 8, 8, 16, "Mac OS X", 128, "Китай", 12, 6, new
            DateTime(2020 / 04 / 09), new Processor("Серебристый"), "Процессор");
            k2.Choice(textBox2, "Apple", listBox2, listBox1);
            //вызов метода с выведением наименования "Процессор" в 1 списке 
            //фирма Samsung 
            ShoppingCart m2 = new ShoppingCart("Samsung CP30 VME 10 _ dpram Rev 001 03 I/O Board", 1.86, 5, 18234, 4, 3, 4, "Samsung  R20", 64, "США", 24, 4, new DateTime(2018 / 12 / 15), new Processor("Синий"),"Процессор"); 
            m2.Choice(textBox2, "Samsung", listBox2, listBox1);
            //вызов метода с выведением наименования "Процессор" в 1 списке 
            //ФИРМА,ПРОДАЮЩАЯ КОМПОНЕНТЫ КОМПЬЮТЕРА 
            //фирма AMD 
            Shop1 c2 = new Shop1("SSD AMD Radeon 240Gb", "Gigabyte GV-R55XTGAMING OC-4GD", "Gigabyte GA-B250M-DS3H",
            "TP-LINK UE200", "Thermaltake LT - 650P(черный)", "DVD-ROM Hitachi-LG DH18NS61", " HP Slim S01-aF0009ur", "AMD FreeSync", "AMD High Definition Audio Device", 
            "AMD DDR3 4Gb 1600MHz 240-pin", @"C:\Users\LED\Desktop\1_visual\5_visual\amd.jpg", "Малайзия", 12, 5, new
            DateTime(2020 / 11 / 05), "возможна", 6, "AMD", "Компоненты компьютера");
            c2.Choice(textBox3, "AMD", listBox1, listBox2);
           //вызов метода с выведением наименования "Компоненты компьютера" в 1 списке
            //фирма Acer 
            Shop1 r = new Shop1("Toshiba L200 2.5 HDWJ105EZSTA", "Asus GeForce GT 1030 PH-GT1030-2G", "ASRock 760GM-HDV", "ACER 19V 3.42A 5.5X1.7ММ OEM", "ACER 19V 2.37A 45W 5.5X1.7MM", "Acer LC.EXD0A.003", "Acer Veriton ES2710G", "Acer Nitro VG242YPbmiipx", "Palmexx USB Sound Adapter 7.1 Channel", 
            "Acer U30512AAUIQ652AW20", @"C:\Users\LED\Desktop\1_visual\5_visual\acer.jpg", "Вьетнам", 36, 8, new DateTime(2019
            / 09 / 12), "невозможна", 9, "Acer", "Компоненты компьютера");
            r.Choice(textBox3, "Acer", listBox1, listBox2);
            //вызов метода с выведением наименования "Компоненты компьютера" в 1 списке
            //фирма Apple 
            Shop1 w = new Shop1("Apple A1355 Time Capsule Wi-Fi", "Apple ATI Radeon HD 4870", "Apple iMac 27 A1419", "Apple MD836ZM / A", "Apple MagSafe 2 85W", "Apple USB SuperDrive", "Apple Mac mini Core i5 1.4 GHz", "Apple Pro Display XDR", "Apple Lightning - mini jack 3.5(MMX62ZM / A)", "Apple DDR4 SO - DIMM 16 ГБ", @"C:\Users\LED\Desktop\1_visual\5_visual\apple.jpg", "Китай", 12, 6, new DateTime(2020 / 04 / 09), "невозможна", 8, "Intel","Компоненты компьютера");
            w.Choice(textBox3, "Apple", listBox1, listBox2);//вызов метода с выведением наименования "Компоненты компьютера" в 1 списке
            //фирма Samsung 
            Shop1 s = new Shop1("SSD-накопитель Samsung 860 EVO", "MSI GeForce GT 710 1GB Silent LowProfile", "Samsung Galaxy S7 Edge G935F", "Samsung EP - TA800", "Samsung AD - 9019S", "Toshiba Samsung Storage Technology SE - 506CB Black", "HP Slim S01 - aF0012ur 28R03EA", "Samsung S24F350FHI black / LS24F350FHIXCI / ", "Samsung USB Type C", 
            "Samsung [M378A5244CB0-CRC] 4 ГБ", @"C:\Users\LED\Desktop\1_visual\5_visual\samsung_2.jpg", "США", 24, 4, new
            DateTime(2018 / 12 / 15), "возможно", 4, "Samsung", "Компоненты компьютера");
            s.Choice(textBox3, "Samsung", listBox1, listBox2);//вызов метода с выведением наименования "Компоненты компьютера" в 1 списке
            //ФИРМА,ОРГАНИЗУЮЩАЯ СБОРКУ КОМПОНЕНТОВ КОМПЬЮТЕРА 
            //фирма TANDEM 
            Shop2 b = new Shop2(8, 5000, 30, 8, 23, "Общество с органиченной ответственностью", @"C:\Users\LED\Desktop\1_visual\5_visual\tandem.png", 11900, 2, "Россия", 2, "два дня", new DateTime(2020 / 11 / 20), new WorkCompany("Севастополь"), "Сборка компьютера");
            b.Choice2(textBox4, "TANDEM", listBox2, listBox1);//вызов метода с выведением наименования "Сборка компьютера" в 1 списке
            //фирма YouDo 
            Shop2 b3 = new Shop2(10, 1900, 18, 35, 8, "Общество с ограниченной ответственностью", @"C:\Users\LED\Desktop\1_visual\5_visual\koudo.png", 25000, 3, "Китай", 4, "5 дней", new DateTime(2019 / 10 / 16), new WorkCompany("Калининград"), "Сборка компьютера");
            b3.Choice2(textBox4, "KouDo", listBox2, listBox1);//вызов метода с выведением наименования "Сборка компьютера" в 1 списке
                //фирма Позитив 
            Shop2 l1 = new Shop2(5, 950, 8, 36, 18, "Общество с органиченной ответственностью", @"C:\Users\LED\Desktop\1_visual\5_visual\позитив.png", 7000, 1, "Россия", 2, "8 дней", new DateTime(2020 / 06 / 16), new WorkCompany("Москва"), "Сборка компьютера");
            l1.Choice2(textBox4, "Позитив", listBox2, listBox1);//вызов метода с выведением наименования "Сборка компьютера" в 1 списке
            //фирма Ситилинк 
            Shop2 d1 = new Shop2(8, 3000, 18, 29, 12, "Общество с органиченной ответственностью", @"C:\Users\LED\Desktop\1_visual\5_visual\ситилино.png", 10000, 4, "Белоруссия", 1, "3 дня", new DateTime(2019 / 01 / 25), new WorkCompany("Киров"), "Сборка компьютера");
            d1.Choice2(textBox4, "СитиЛино", listBox2, listBox1);//вызов метода с выведением наименования "Сборка компьютера" в  1 списке
            //ФИРМА,ОРГАНИЗУЮЩАЯ ДОСТАВКУ КОМПОНЕНТОВ КОМПЬЮТЕРА 
            //фирма HYPERPCOM
            Shop3 p1 = new Shop3(10, 2590, 145, 19, 10, "Общество с органиченной ответственностью", 36, "возможна", 25, 56, 88, " 8(800) 775 - 82 - 35", 700, 1000, 2900, 5500, @"C:\Users\LED\Desktop\1_visual\5_visual\hypercom.png", "г.Новосибирск","Доставка компьютера", 
            30, "1  день",2,"возможен",505,"SMS - оповещение",new DateTime(2020 / 11 / 14), "доставка к двери","доставка по городу","доставка по стране","доставка по миру"); 
            p1.Choice3(textBox5, "HYPERPCOM", listBox1, listBox2);//вызов метода с выведением наименования "Доставка компьютера" в 1  списке
            //фирма MERLIONA 
            Shop3 s3 = new Shop3(7, 7028, 52, 79, 22, "Общество с ограниченной ответственностью", 12, "невозможна", 30, 64, 176, "+7 (495) 981 - 84 - 84", 890, 1100, 2600, 5100, @"C:\Users\LED\Desktop\1_visual\5_visual\merliona.png", "г.Хабаровск", "Доставка компьютера", 
            50, "3 дня", 5, "невозможен", 300, "почтовое сообщение", new DateTime(2019 / 10 / 28), "доставка к двери", "доставка по городу","доставка по стране","доставка по миру"); 
            s3.Choice3(textBox5, "MERLIONA", listBox1, listBox2);//вызов метода с выведением наименования "Доставка компьютера" в 1  списке
            //фирма АСКОНTOM 
            Shop3 s5 = new Shop3(12, 8912, 37, 78, 31, "Общество с ограниченной ответственностью", 36, "невозможна", 40, 72, 123, "+7 351 - 21 - 71 - 516", 920, 1300, 2500, 4300, @"C:\Users\LED\Desktop\1_visual\5_visual\ackontom.png", "г.Стамбул","Доставка компьютера", 
            25, "3 дня", 3, "возможен", 600, "SMS-оповещение", new DateTime(2020 / 07 / 01), "доставка к двери", "доставка по городу", "доставка по стране","доставка по миру"); 
            s5.Choice3(textBox5, "АСКОНTOM", listBox1, listBox2);//вызов метода с выведением наименования "Доставка компьютера" в 1  списке
            //фирма TEXEN
            Shop3 s7 = new Shop3(7, 912, 29, 35, 3, "Общество с ограниченной ответственностью", 24, "возможна", 40, 62, 92, "8 (495)  651 - 99 - 99", 820, 1500, 3400, 4600, @"C:\Users\LED\Desktop\1_visual\5_visual\texen.png", "г.Кишинев", "Доставка компьютера", 
            70, "5 дней", 6, "невозможен", 400, "почтовое сообщение", new DateTime(2019 / 02 / 05), "доставка к двери", "доставка по городу","доставка по стране","доставка по миру"); 
            s7.Choice3(textBox5, "TEXEN", listBox1, listBox2);//вызов метода с выведением наименования "Доставка компьютера" в 1 списке
        }

        private void button5_Click(object sender, EventArgs e)//кнопка "Узнать цену" 
        {
            //ФИРМА,ПРОДАЮЩАЯ ПРОЦЕССОР 
            //фирма AMD 
            if (textBox2.Text == "AMD")//если текстовое поле textBox2 содержит наименование фирмы AMD 
            {
                ShoppingCart n3 = new ShoppingCart("AMD Ryzen 3 3100 AM4 100 - 000000284 OEM", 1.6, 16, 8199, 4, 4, 8, "Matisse", 64,
                "Малайзия", 12, 5, new DateTime(2020 / 11 / 05), new Processor("Белый"), "Процессор");
                n3.List(listBox3, listBox1, textBox1);//вызов метода с выведением стоимости процессора 1 в список 3 
                n3.Text1(textBox1);//вызов метода с выведением стоимости процессора 1 в текстовое поле textBox1 
            }
            if (textBox2.Text == "Acer")//если текстовое поле textBox2 содержит наименование фирмы Acer 
            {
                ShoppingCart p2 = new ShoppingCart("Acer 9400F", 4.1, 9, 11999, 4, 6, 6, "Coffee Lake R", 64, "Вьетнам", 36, 8,
                new DateTime(2019 / 09 / 12), new Processor("Синий"), "Процессор");
                p2.List(listBox3, listBox1, textBox1);//вызов метода с выведением стоимости процессора 2 в список 3 
                p2.Text1(textBox1);//вызов метода с выведением стоимости процессора 2 в текстовое поле textBox1 
            }
            if (textBox2.Text == "Apple")//если текстовое поле textBox2 содержит наименование фирмы Apple 
            {
                ShoppingCart k2 = new ShoppingCart("Mac mini Apple M1", 6.1, 8, 74990, 8, 8, 16, "Mac OS X", 128, "Китай", 12, 6, new
                DateTime(2020 / 04 / 09), new Processor("Серебристый"), "Процессор");
                k2.List(listBox3, listBox1, textBox1);//вызов метода с выведением стоимости процессора 3 в список 3 
                k2.Text1(textBox1);//вызов метода с выведением стоимости процессора 3 в текстовое поле textBox1 
            }
            if (textBox2.Text == "Samsung")//если текстовое поле textBox2 содержит наименование фирмы Samsung 
            {
                ShoppingCart m2 = new ShoppingCart("Samsung CP30 VME 10 _ dpram Rev 001 03 I/O Board", 1.86, 5, 18234, 4, 3, 4,
                "Samsung R20", 64, "США", 24, 4, new DateTime(2018 / 12 / 15), new Processor("Синий"), "Процессор");
                m2.List(listBox3, listBox1, textBox1);//вызов метода с выведением стоимости процессора 4 в список 3 
                m2.Text1(textBox1);//вызов метода с выведением стоимости процессора 4 в текстовое поле textBox1
              } 
                 //ФИРМА,ПРОДАЮЩАЯ КОМПОНЕНТЫ КОМПЬЮТЕРА 
                 //фирма AMD 
                if (textBox3.Text == "AMD")//если текстовое поле textBox3 содержит наименование фирмы AMD 
                {
                    Computer r = new Computer(2499, 16599, 5299, 690, 3890, 1199, 17990, 6950, 390, 2599);
                    List<int> Lok = new List<int>();
                    r.Click4(Lok);//вызов метода с определением суммы компонентов компьютера фирмы 1 
                    Shop1 c3 = new Shop1(2499, 16599, 5299, 690, 3890, 1199, 17990, 6950, 390, 2599);
                    c3.Click(listBox2, listBox3);//вызов метода с выведением стоимости каждого компонента компьютера фирмы 1 в списке 3 
                    c3.Distribution(textBox8);//вызов метода с выведением стоимости компонентов компьютера фирмы 1 в текстовое поле textBox8
                }
                //фирма Acer 
                if (textBox3.Text == "Acer")//если текстовое поле textBox3 содержит наименование фирмы Acer 
                {
                    Computer r1 = new Computer(2670, 6709, 4100, 490, 495, 2100, 46000, 17900, 450, 5131);
                    List<int> Lok1 = new List<int>();
                    r1.Click4(Lok1);//вызов метода с определением суммы компонентов компьютера фирмы 2 
                    Shop1 c4 = new Shop1(2670, 6709, 4100, 490, 495, 2100, 46000, 17900, 450, 5131);
                    c4.Click(listBox2, listBox3);//вызов метода с выведением стоимости каждого компонента компьютера фирмы 2 в списке 3 
                    c4.Distribution(textBox8);//вызов метода с выведением стоимости компонентов компьютера фирмы 2 в текстовое поле textBox8
                }
                //фирма Apple 
                if (textBox3.Text == "Apple")//если текстовое поле textBox3 содержит наименование фирмы Apple 
                {
                    Computer f = new Computer(3752, 3920, 19000, 990, 3990, 7900, 29981, 20990, 790, 40000);
                    List<int> Lok2 = new List<int>();
                    f.Click4(Lok2);//вызов метода с определением суммы компонентов компьютера фирмы 3 
                    Shop1 w1 = new Shop1(3752, 3920, 19000, 990, 3990, 7900, 29981, 20990, 790, 40000);
                    w1.Click(listBox2, listBox3);//вызов метода с выведением стоимости каждого компонента компьютера фирмы 3 в списке 3 
                    w1.Distribution(textBox8);//вызов метода с выведением стоимости компонентов компьютера фирмы 3 в текстовое поле textBox8
                }
                //фирма Samsung 
                if (textBox3.Text == "Samsung")//если текстовое поле textBox3 содержит наименование фирмы Samsung 
                {
                    Computer g = new Computer(3699, 3300, 3851, 1999, 690, 4199, 29990, 8790, 443, 1550);
                    List<int> Lok3 = new List<int>();
                    g.Click4(Lok3);//вызов метода с определением суммы компонентов компьютера фирмы 4 
                    Shop1 s1 = new Shop1(3699, 3300, 3851, 1999, 690, 4199, 29990, 8790, 443, 1550);
                    s1.Click(listBox2, listBox3);//вызов метода с выведением стоимости каждого компонента компьютера фирмы 4 в списке 3 
                    s1.Distribution(textBox8);//вызов метода с выведением стоимости компонентов компьютера фирмы 4 в текстовое поле textBox8
                }
                //ФИРМА,ОРГАНИЗУЮЩАЯ СБОРКУ КОМПЬЮТЕРА 
                //фирма TANDEM 
                if (textBox4.Text == "TANDEM")//если текстовое поле textBox4 содержит наименование фирмы TANDEM 
                {
                    Shop2 b = new Shop2(8, 5000, 30, 8, 23, "Общество с органиченной ответственностью", @"C:\Users\LED\Desktop\1_visual\5_visual\tandem.png", 11900, 2, "Россия", 2, "два дня", new DateTime(2020 / 11 / 20), new WorkCompany("Севастополь"), "Сборка компьютера");
                    b.Ckok(listBox3, listBox1, 15900);//вызов метода с выведением стоимости сборки компьютера в фирме 1 в список 3 
                    b.Distribution(textBox9, 15900);//вызов метода с выведением стоимости сборки компьютера в фирме 1 в текстовом поле textBox9
                }
                //фирма YouDo 
                if (textBox4.Text == "KouDo")//если текстовое поле textBox4 содержит наименование фирмы KouDo 
                {
                    Shop2 b3 = new Shop2(10, 1900, 18, 35, 8, "Общество с ограниченной ответственностью", @"C:\Users\LED\Desktop\1_visual\5_visual\koudo.png", 25000, 3, "Китай", 4, "5 дней", new DateTime(2019 / 10 / 16), new WorkCompany("Калининград"), "Сборка компьютера"); 
                    b3.Ckok(listBox3, listBox1, 29900);//вызов метода с выведением стоимости сборки компьютера в фирме 2 в список 3 
                    b3.Distribution(textBox9, 29900);//вызов метода с выведением стоимости сборки компьютера в фирме 2 в текстовом поле textBox9
                }
                //фирма Позитив 
                if (textBox4.Text == "Позитив")//если текстовое поле textBox4 содержит наименование фирмы Позитив 
                {
                    Shop2 l1 = new Shop2(5, 950, 8, 36, 18, "Общество с органиченной ответственностью", @"C:\Users\LED\Desktop\1_visual\5_visual\позитив.png", 7000, 1, "Россия", 2, "8 дней", new DateTime(2020 / 06 / 16), new WorkCompany("Москва"), "Сборка компьютера");
                    l1.Ckok(listBox3, listBox1, 10000);//вызов метода с выведением стоимости сборки компьютера в фирме 3 в список 3 
                    l1.Distribution(textBox9, 10000);//вызов метода с выведением стоимости сборки компьютера в фирме 3 в текстовом поле textBox9
                }
                //фирма Ситилинк 
                if (textBox4.Text == "СитиЛино")//если текстовое поле textBox4 содержит наименование фирмы Ситилино
                {
                    Shop2 d1 = new Shop2(8, 3000, 18, 29, 12, "Общество с органиченной ответственностью", @"C:\Users\LED\Desktop\1_visual\5_visual\ситилино.png", 10000, 4, "Белоруссия", 1, "3 дня", new DateTime(2019 / 01 / 25), new WorkCompany("Киров"), "Сборка компьютера"); 
                   d1.Ckok(listBox3, listBox1, 12900);//вызов метода с выведением стоимости сборки компьютера в фирме 4 в список 3 
                    d1.Distribution(textBox9, 12900);//вызов метода с выведением стоимости сборки компьютера в фирме 4 в текстовом поле textBox9
                }
                //ФИРМА,ОРГАНИЗУЮЩАЯ ДОСТАВКУ КОМПОНЕНТОВ КОМПЬЮТЕРА 
                //фирма HYPERPC 
                if (textBox5.Text == "HYPERPCOM")//если текстовое поле textBox5 содержит наименование фирмы HYPERPC 
                {
                    Shop3 p1 = new Shop3(10, 2590, 145, 19, 10, "Общество с органиченной ответственностью", 36, "возможна", 25, 56, 88, " 8(800) 775 - 82 - 35", 700, 1000, 2900, 5500, @"C:\Users\LED\Desktop\1_visual\5_visual\hypercom.png", "г.Новосибирск", "Доставка компьютера", 
                    30, "1 день", 2, "возможен", 505, "SMS-оповещение", new DateTime(2020 / 11 / 14), "доставка к двери", "доставка по городу",
                    "доставка по стране", "доставка по миру");
                    p1.Click2(listBox2, listBox3, richTextBox1, textBox10);//вызов метода с выведением цены на каждый способ доставки компьютера в список 3, дополнительной информации о фирме 1 и стоимости доставки компьютера в textBox10
                }
                //фирма MERLION 
                if (textBox5.Text == "MERLIONA")//если текстовое поле textBox5 содержит наименование фирмы MERLION 
                {
                    Shop3 s3 = new Shop3(7, 7028, 52, 79, 22, "Общество с ограниченной ответственностью", 12, "невозможна", 30, 64, 176,
                    "+7 (495) 981-84-84", 890, 1100, 2600, 5100, @"C:\Users\LED\Desktop\1_visual\5_visual\merliona.png", "г.Хабаровск", "Доставка компьютера", 
                    50, "3 дня", 5, "невозможен", 300, "почтовое сообщение", new DateTime(2019 / 10 / 28), "доставка к двери", "доставка по городу", "доставка по стране", "доставка по миру"); 
                    s3.Click2(listBox2, listBox3, richTextBox1, textBox10);//вызов метода с выведением цены на каждый способ доставки компьютера в список 3, дополнительной информации о фирме 2 и стоимости доставки компьютера в textBox10
                }
                //фирма АСКОНTOM 
                if (textBox5.Text == "АСКОНTOM")//если текстовое поле textBox5 содержит наименование фирмы ACKOH 
                {
                    Shop3 s5 = new Shop3(12, 8912, 37, 78, 31, "Общество с ограниченной ответственностью", 36, "невозможна", 40, 72, 123,
                    "+7 351-21-71-516", 920, 1300, 2500, 4300, @"C:\Users\LED\Desktop\1_visual\5_visual\ackontom.png", "г.Стамбул", "Доставка компьютера",
                    25, "3 дня", 3, "возможен", 600, "SMS-оповещение", new DateTime(2020 / 07 / 01), "доставка к двери", "доставка по городу", "доставка по стране", "доставка по миру");
                    s5.Click2(listBox2, listBox3, richTextBox1, textBox10);//вызов метода с выведением цены на каждый способ доставки компьютера в список 3, дополнительной информации о фирме 3 и стоимости доставки компьютера в textBox10
                }
                //фирма TEXEN
                if (textBox5.Text == "TEXEN")//если текстовое поле textBox5 содержит наименование фирмы TEXENERGO 
                {
                    Shop3 s7 = new Shop3(7, 912, 29, 35, 3, "Общество с ограниченной ответственностью", 24, "возможна", 40, 62, 92, "8 (495) 651 - 99 - 99", 820, 1500, 3400, 4600, @"C:\Users\LED\Desktop\1_visual\5_visual\texen.png", "г.Кишинев", "Доставка компьютера", 
                    70, "5 дней", 6, "невозможен", 400, "почтовое сообщение", new DateTime(2019 / 02 / 05), "доставка к двери", "доставка по городу", "доставка по стране", "доставка по миру"); 
                    s7.Click2(listBox2, listBox3, richTextBox1, textBox10);//вызов метода с выведением цены на каждый способ доставки компьютера в список 3, дополнительной информации о фирме 4 и стоимости доставки компьютера в textBox10
                }
            }

        private void Form3_Load(object sender, EventArgs e)
        {
            //дизайн формы(линии) 
            path.AddLine(75, 75, 70, 70);
            path.AddLine(300, 300, 95, 95);
            path.AddLine(600, 600, 87, 87);
        }

        private void button6_Click(object sender, EventArgs e)//кнопка "Посмотреть характеристики" 
            {
                //ФИРМА,ПРОДАЮЩАЯ ПРОЦЕССОР 
                //фирма AMD 
                if (textBox2.Text == "AMD")//если текстовое поле textBox2 содержит наименование фирмы AMD 
                {
                    ShoppingCart n3 = new ShoppingCart("AMD Ryzen 3 3100 AM4 100 - 000000284 OEM", 1.6, 16, 8199, 4, 4, 8, "Matisse", 64,
                    "Малайзия", 12, 5, new DateTime(2020 / 11 / 05), new Processor("Белый"), "Процессор");
                    n3.List(listBox2, listBox1, richTextBox1);//вызов метода с выведением характеристик процессора 1 
                }
                //фирма Acer 
                if (textBox2.Text == "Acer")//если текстовое поле textBox2 содержит наименование фирмы Acer 
                {
                    ShoppingCart p2 = new ShoppingCart("Acer 9400F", 4.1, 9, 11999, 4, 6, 6, "Coffee Lake R", 64, "Вьетнам", 36, 8,
                    new DateTime(2019 / 09 / 12), new Processor("Синий"), "Процессор");
                    p2.List(listBox2, listBox1, richTextBox1);//вызов метода с выведением характеристик процессора 2 
                }
                //фирма Apple 
                if (textBox2.Text == "Apple")//если текстовое поле textBox2 содержит наименование фирмы Apple 
                {
                    ShoppingCart k2 = new ShoppingCart("Mac mini Apple M1", 6.1, 8, 74990, 8, 8, 16, "Mac OS X", 128, "Китай", 12, 6, new DateTime(2020 / 04 / 09), new Processor("Серебристый"), "Процессор");
                    k2.List(listBox2, listBox1, richTextBox1);//вызов метода с выведением характеристик процессора 3 
                }
                //фирма Samsung 
                if (textBox2.Text == "Samsung")//если текстовое поле textBox2 содержит наименование фирмы Samsung 
                {
                    ShoppingCart m2 = new ShoppingCart("Samsung CP30 VME 10 _ dpram Rev 001 03 I/O Board", 1.86, 5, 18234, 4, 3, 4,
                    "Samsung R20", 64, "США", 24, 4, new DateTime(2018 / 12 / 15), new Processor("Синий"), "Процессор");
                    m2.List(listBox2, listBox1, richTextBox1);//вызов метода с выведением характеристик процессора 4 
                }
                //ФИРМА,ПРОДАЮЩАЯ КОМПОНЕНТЫ КОМПЬЮТЕРА 
                //фирма AMD 
                if (textBox3.Text == "AMD")//если текстовое поле textBox3 содержит наименование фирмы AMD 
                {
                    Shop1 c2 = new Shop1("SSD AMD Radeon 240Gb", "Gigabyte GV-R55XTGAMING OC-4GD", "Gigabyte GA-B250M-DS3H",
                    "TP-LINK UE200", "Thermaltake LT - 650P(черный)", "DVD-ROM Hitachi-LG DH18NS61", " HP Slim S01-aF0009ur", "AMD FreeSync", "AMD High Definition Audio Device", 
                    "AMD DDR3 4Gb 1600MHz 240-pin", @"C:\Users\LED\Desktop\1_visual\5_visual\amd.jpg", "Малайзия", 12, 5, new
                    DateTime(2020 / 11 / 05), "возможна", 6, "AMD", "Компоненты компьютера");
                    c2.Click2(listBox1, richTextBox1, listBox2);//вызов метода с выведением характеристик фирмы 1,продающей компоненты компьютера
                }
                //фирма Acer 
                if (textBox3.Text == "Acer")//если текстовое поле textBox3 содержит наименование фирмы Acer 
                {
                    Shop1 r = new Shop1("Toshiba L200 2.5 HDWJ105EZSTA", "Asus GeForce GT 1030 PH-GT1030-2G", "ASRock 760GM - HDV", " ACER 19V 3.42A 5.5X1.7ММ OEM", "ACER 19V 2.37A 45W 5.5X1.7MM", "Acer LC.EXD0A.003", "Acer Veriton ES2710G", 
                    "Acer Nitro VG242YPbmiipx", "Palmexx USB Sound Adapter 7.1 Channel",
                    "Acer U30512AAUIQ652AW20", @"C:\Users\LED\Desktop\1_visual\5_visual\acer.jpg", "Вьетнам", 36, 8, new DateTime(2019
                    / 09 / 12), "невозможна", 9, "Acer", "Компоненты компьютера");
                    r.Click2(listBox1, richTextBox1, listBox2);//вызов метода с выведением характеристик фирмы 2,продающей компоненты компьютера
                }
                //фирма Apple 
                if (textBox3.Text == "Apple")//если текстовое поле textBox3 содержит наименование фирмы Apple 
                {
                    Shop1 w = new Shop1("Apple A1355 Time Capsule Wi-Fi", "Apple ATI Radeon HD 4870", "Apple iMac 27 A1419", "Apple MD836ZM / A", "Apple MagSafe 2 85W", "Apple USB SuperDrive", "Apple Mac mini Core i5 1.4 GHz", "Apple Pro Display XDR", "Apple Lightning - mini jack 3.5(MMX62ZM / A)", "Apple DDR4 SO - DIMM 16 ГБ",
                    @"C:\Users\LED\Desktop\1_visual\5_visual\apple.jpg", "Китай", 12, 6, new DateTime(2020 / 04 / 09), "невозможна", 8,
                    "Intel", "Компоненты компьютера");
                    w.Click2(listBox1, richTextBox1, listBox2);//вызов метода с выведением характеристик фирмы 3,продающей компоненты компьютера
                }
                //фирма Samsung 
                if (textBox3.Text == "Samsung")//если текстовое поле textBox3 содержит наименование фирмы Samsung 
                {
                    Shop1 s = new Shop1("SSD-накопитель Samsung 860 EVO", "MSI GeForce GT 710 1GB Silent LowProfile", "Samsung Galaxy S7 Edge G935F", "Samsung EP - TA800", "Samsung AD - 9019S", "Toshiba Samsung Storage Technology SE - 506CB Black", "HP Slim S01 - aF0012ur 28R03EA", "Samsung S24F350FHI black / LS24F350FHIXCI / ", "Samsung USB Type C", 
                    "Samsung [M378A5244CB0-CRC] 4 ГБ", @"C:\Users\LED\Desktop\1_visual\5_visual\samsung_2.jpg", "США", 24, 4, new
                    DateTime(2018 / 12 / 15), "возможно", 4, "Samsung", "Компоненты компьютера");
                    s.Click2(listBox1, richTextBox1, listBox2);//вызов метода с выведением характеристик фирмы 4,продающей компоненты компьютера
                }
                //ФИРМА,ОРГАНИЗУЮЩАЯ СБОРКУ КОМПЬЮТЕРА 
                //фирма TANDEM 
                if (textBox4.Text == "TANDEM")//если текстовое поле textBox4 содержит наименование фирмы TANDEM 
                {
                    Shop2 b = new Shop2(8, 5000, 30, 8, 23, "Общество с органиченной ответственностью", @"C:\Users\LED\Desktop\1_visual\5_visual\tandem.png", 11900, 2, "Россия", 2, "два дня", new DateTime(2020 / 11 / 20), new WorkCompany("Севастополь"), "Сборка компьютера");
                    b.Click2(listBox1, listBox2, richTextBox1, listBox3, 15900);//вызов метода с выведением характеристик фирмы 1,организующей сборку компьютера
                }
                //фирма КouDo 
                if (textBox4.Text == "KouDo")//если текстовое поле textBox4 содержит наименование фирмы YouDo 
                {
                    Shop2 b3 = new Shop2(10, 1900, 18, 35, 8, "Общество с ограниченной ответственностью", @"C:\Users\LED\Desktop\1_visual\5_visual\koudo.png", 25000, 3, "Китай", 4, "5 дней", new DateTime(2019 / 10 / 16), new WorkCompany("Калининград"), "Сборка компьютера"); 
                    b3.Click2(listBox1, listBox2, richTextBox1, listBox3, 29900);//вызов метода с выведением характеристик фирмы 2,организующей сборку компьютера
                }
                //фирма Позитив 
                if (textBox4.Text == "Позитив")//если текстовое поле textBox4 содержит наименование фирмы Позитив 
                {
                    Shop2 l1 = new Shop2(5, 950, 8, 36, 18, "Общество с органиченной ответственностью", @"C:\Users\LED\Desktop\1_visual\5_visual\позитив.png", 7000, 1, "Россия", 2, "8 дней", new DateTime(2020 / 06 / 16), new WorkCompany("Москва"), "Сборка компьютера");
                    l1.Click2(listBox1, listBox2, richTextBox1, listBox3, 10000);//вызов метода с выведением характеристик фирмы 3,организующей сборку компьютера
                }
                //фирма Ситилино
                if (textBox4.Text == "СитиЛино")//если текстовое поле textBox4 содержит наименование фирмы Ситилинк 
                {
                    Shop2 d1 = new Shop2(8, 3000, 18, 29, 12, "Общество с органиченной ответственностью", @"C:\Users\LED\Desktop\1_visual\5_visual\ситилино.png", 10000, 4, "Белоруссия", 1, "3 дня", new DateTime(2019 / 01 / 25), new WorkCompany("Киров"), "Сборка компьютера"); 
                    d1.Click2(listBox1, listBox2, richTextBox1, listBox3, 12900);//вызов метода с выведением характеристик фирмы 4,организующей сборку компьютера
                }
                //ФИРМА,ОРГАНИЗУЮЩАЯ ДОСТАВКУ КОМПОНЕНТОВ КОМПЬЮТЕРА 
                //фирма HYPERPCOM 
                if (textBox5.Text == "HYPERPCOM")//если текстовое поле textBox5 содержит наименование фирмы HYPERPC 
                {
                    Shop3 p1 = new Shop3(10, 2590, 145, 19, 10, "Общество с органиченной ответственностью", 36, "возможна", 25, 56, 88, " 8(800) 775 - 82 - 35", 700, 1000, 2900, 5500, @"C:\Users\LED\Desktop\1_visual\5_visual\hypercom.png", "г.Новосибирск", "Доставка компьютера",
                    30, "1 день", 2, "возможен", 505, "SMS-оповещение", new DateTime(2020 / 11 / 14), "доставка к двери", "доставка по городу",
                    "доставка по стране", "доставка по миру");
                    p1.Click(listBox1, listBox2);//вызов метода с выведением характеристик фирмы 1,организующей доставку компьютера 
                }
                //фирма MERLIONA 
                if (textBox5.Text == "MERLIONA")//если текстовое поле textBox5 содержит наименование фирмы MERLION 
                {
                    Shop3 s3 = new Shop3(7, 7028, 52, 79, 22, "Общество с ограниченной ответственностью", 12, "невозможна", 30, 64, 176,
                    "+7 (495) 981-84-84", 890, 1100, 2600, 5100, @"C:\Users\LED\Desktop\1_visual\5_visual\merliona.png", "г.Хабаровск", "Доставка компьютера",
                    50, "3 дня", 5, "невозможен", 300, "почтовое сообщение", new DateTime(2019 / 10 / 28), "доставка к двери", "доставка по городу", "доставка по стране", "доставка по миру"); 
                    s3.Click(listBox1, listBox2);//вызов метода с выведением характеристик фирмы 2,организующей доставку компьютера 
                }
                //фирма АСКОНTOM 
                if (textBox5.Text == "АСКОНTOM")//если текстовое поле textBox5 содержит наименование фирмы ACKOH 
                {
                    Shop3 s5 = new Shop3(12, 8912, 37, 78, 31, "Общество с ограниченной ответственностью", 36, "невозможна", 40, 72, 123,
                    "+7 351-21-71-516", 920, 1300, 2500, 4300, @"C:\Users\LED\Desktop\1_visual\5_visual\ackontom.png", "г.Стамбул", "Доставка компьютера",
                    25, "3 дня", 3, "возможен", 600, "SMS-оповещение", new DateTime(2020 / 07 / 01), "доставка к двери", "доставка по городу",
                    "доставка по стране", "доставка по миру");
                    s5.Click(listBox1, listBox2);//вызов метода с выведением характеристик фирмы 3,организующей доставку компьютера 
                }
                //фирма TEXEN
                if (textBox5.Text == "TEXEN")//если текстовое поле textBox5 содержит наименование фирмы TEXENERGO 
                {
                    Shop3 s7 = new Shop3(7, 912, 29, 35, 3, "Общество с ограниченной ответственностью", 24, "возможна", 40, 62, 92, "8 (495) 651 - 99 - 99", 820, 1500, 3400, 4600, @"C:\Users\LED\Desktop\1_visual\5_visual\texen.png", "г.Кишинев", "Доставка компьютера", 
                    70, "5 дней", 6, "невозможен", 400, "почтовое сообщение", new DateTime(2019 / 02 / 05), "доставка к двери", "доставка по городу", "доставка по стране", "доставка по миру"); 
                    s7.Click(listBox1, listBox2);//вызов метода с выведением характеристик фирмы 4,организующей доставку компьютера 
                }
            }

        private void button7_Click(object sender, EventArgs e)//кнопка "Очистить товар(услугу)" 
            {
                listBox1.Items.Clear();//очистить лист 1 
                listBox2.Items.Clear();//очистить лист 2 
                listBox3.Items.Clear();//очистить лист 3 
                richTextBox1.Clear();//очистить окно для введения информации о фирме-richTextBox1 
                textBox1.Clear();//очистить текстовый блок для выведения стоимости процессора 
                textBox8.Clear();//очистить текстовый блок для выведения стоимости компонентов компьютера 
                textBox9.Clear();//очистить текстовый блок для выведения стоимости сборки компьютера 
                textBox10.Clear();//очистить текстовый блок для выведения стоимости доставки компьютера 
                textBox11.Clear();//очистить текстовый блок для выведения итоговой стоимости 
            }
    }
}
