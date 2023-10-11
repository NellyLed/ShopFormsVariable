using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ComputerCursovik
{
    public class Menus//РЕАЛИЗАЦИЯ ПЕРВОГО ОКНА ФОРМЫ:ГЛАВНОЕ МЕНЮ
    {
        public Menus() { }
        public string Foto { get; set; }//для реализации 1 картинки
        public string Foto1 { get; set; }//для реализации 2 картинки
        public string Foto2 { get; set; }//для реализации 2 картинки
        public Menus(string foto, string foto1, string foto2) { Foto = foto; Foto1 = foto1; Foto2 = foto2; }//конструктор,использующийся для инициализации пути для вывода изображений
        //событие
        public delegate void MenuHandler(string message);
        public event MenuHandler One;
        public void Picture(PictureBox box)//для реализации 1 картинки
        {
            Graphics g = Graphics.FromHwnd(box.Handle);
            g.DrawImage(Image.FromFile(this.Foto), new Rectangle(0, 0, box.Width, box.Height));
        }
        public void Picture1(PictureBox b1)//для реализации 2 картинки
        {
            Graphics g = Graphics.FromHwnd(b1.Handle);
            g.DrawImage(Image.FromFile(this.Foto1), new Rectangle(0, 0, b1.Width, b1.Height));
        }
        public void Picture2(PictureBox b2)//для реализации 3 картинки
        {
            Graphics g = Graphics.FromHwnd(b2.Handle);
            g.DrawImage(Image.FromFile(this.Foto2), new Rectangle(0, 0, b2.Width, b2.Height));
        }
//выбор и кнопка
public void Metod(PictureBox c, PictureBox c1, PictureBox c2)//метод, использующийся для вывода трех изображений
{
Picture(c);
        Picture1(c1);
        Picture2(c2);
    }
    public void Button()//метод, использующийся для выполнения действия в кнопке "Приобрести" и фиксации соответствующего события
{
One.Invoke($"Извините,вы не выбрали товар(услугу)!\n");
}
public void Button1()//метод для фиксации события
{
One.Invoke($"Вы выбрали покупку процессора и можете перейти на страницу с корзиной товаров.Если вы хотите " +
$"приобрести что-нибудь еще из перечисленного, то на следующей странице будут видны соответствующие переходы\n");
}
public void Button2()//метод для фиксации события
{
One.Invoke($"Вы выбрали покупку компонентов компьютера и можете перейти на страницу с корзиной товаров.Если вы хотите " +
$"приобрести что-нибудь еще из перечисленного, то на следующей странице будут видны соответствующие переходы\n");
}
public void Button3()//метод для фиксации события
{
One.Invoke($"Вы выбрали услугу:Сборка компьютера и можете перейти на следующую страницу.Если вы хотите " +
$"приобрести что-нибудь еще из перечисленного, то на следующей странице будут видны соответствующие переходы\n");
}
public void Button4()//метод для фиксации события
{
One.Invoke($"Вы выбрали весь перечень товаров и услуг и можете перейти на следующую страницу\n");
}
}
public class FourEventArgs //класс для выведения события с дополнительным описанием
{
    public string Message { get; }//сообщение
   public string Stamp { get; set; }//изменение типа марки процессора
    public double Frequency { get; set; }//изменение объема тактовой частоты
    public decimal Kesh { get; set; }//изменение объема КЭШа
    public int Cost { get; set; }//изменение стоимости процессора
    public FourEventArgs(string message, string stamp) { Message = message; Stamp = stamp; }
    public FourEventArgs(string message, double frequency) { Message = message; Frequency = frequency; }
    public FourEventArgs(string message, decimal kesh) { Message = message; Kesh = kesh; }
    public FourEventArgs(string message, int cost) { Message = message; Cost = cost; }
}
public class Processor //РЕАЛИЗАЦИЯ ВТОРОГО ОКНА ФОРМЫ:ХАРАКТЕРИСТИКИ ПРОЦЕССОРА
{
    public string stamp;//тип марки процессора
    public double frequency;//объем тактовой частоты
    public decimal kesh;//объем оперативной памяти
    public int cost;//стоимость процессора
    public virtual string Stamp { get; set; }//свойство для инициализации типа марки процессора
    public virtual double Frequency { get; set; }//свойство для инициализации объема тактовой частоты процессора
public virtual decimal Kesh { get; set; }//свойство для инициализации объема КЭШа процессора
public virtual int Cost { get; set; }//свойство для инициализации стоимости процессора
public Processor(string stamp, double frequency, decimal kesh, int cost) { Stamp = stamp; Frequency = frequency; Kesh = kesh; Cost =
    cost; }
public Processor(int cost) { Cost = cost; }
public Processor(string stamp) { Stamp = stamp; }
public Processor() { }
public virtual void List(ListBox b)//для составления листа основных характеристик процессора
{
b.Items.Insert(0, "Тип марки процессора=" + this.Stamp);
b.Items.Insert(1, "Объем тактовой частоты=" + this.Frequency + " " + "Гб");
b.Items.Insert(2, "Объем КЭШа=" + this.Kesh + " " + "Гб");
b.Items.Insert(3, "Стоимость процессора=" + this.Cost + " " + "руб");
}
}
public class ProcessorOne : Processor
{
    public delegate void ProcessorHandler(object sender, FourEventArgs e);
    public event ProcessorHandler Two;
    public override string Stamp//ПЕРЕОПРЕДЕЛЕНИЕ СВОЙСТВА КЛАССА Processor
{
get { return stamp; }
set { this.stamp = value; }
}
public void StampCheck()//проверка свойства класса,передающего тип марки процессора, после инициализации-допустимости значений полей, фиксация соответствующего события
{
if (stamp.GetTypeCode() == TypeCode.String)
{ Two.Invoke(this, new FourEventArgs("Введенное значение типа марки процессора соответствует допустимому", this.Stamp)); }
else { Two.Invoke(this, new FourEventArgs("Введенное значение типа марки процессора не соответствует допустимому", this.Stamp)); }
}
public override double Frequency//ПЕРЕОПРЕДЕЛЕНИЕ СВОЙСТВА КЛАССА Processor
{
get
{ return frequency; }
set
{ this.frequency = value; }
}
public void FrequencyCheck()//проверка свойства класса,передающего объем тактовой частоты, после инициализации-допустимости значений полей, фиксация соответствующего события
{
if (frequency.GetTypeCode() == TypeCode.Double)
{ Two.Invoke(this, new FourEventArgs("Введенное значение объема тактовой частоты соответствует допустимому", this.Frequency)); }
else { Two.Invoke(this, new FourEventArgs("Введенное значение объема тактовой частоты не соответствует допустимому", this.Frequency)); }
}
public override decimal Kesh //ПЕРЕОПРЕДЕЛЕНИЕ СВОЙСТВА КЛАССА Processor
{
get
{ return kesh; }
set{ this.kesh = value; }
}
public void KeshCheck()//проверка свойства класса,передающего объем КЭШа, после инициализации-допустимости значений полей, фиксация соответствующего события
{
if (kesh.GetTypeCode() == TypeCode.Decimal)
{ Two.Invoke(this, new FourEventArgs("Введенное значение объема КЭШа соответствует допустимому", this.Kesh)); }
else { Two.Invoke(this, new FourEventArgs("Введенное значение объема КЭШа не соответствует допустимому", this.Kesh)); }
}
public override int Cost//ПЕРЕОПРЕДЕЛЕНИЕ СВОЙСТВА КЛАССА Processor
{
get
{ return cost; }
set{ this.cost = value; }
}
public void CostCheck()//проверка свойства класса,передающего стоимость процессора, после инициализации-допустимости значений полей, фиксирование соответствующего события
{
if (cost.GetTypeCode() == TypeCode.Int32)
{ Two.Invoke(this, new FourEventArgs("Введенное значение стоимости процессора соответствует допустимому", this.Cost)); }
else { Two.Invoke(this, new FourEventArgs("Введенное значение стоимости процессора не соответствует допустимому", this.Cost)); }
}
public ProcessorOne() { }
//конструктор
public ProcessorOne(string stamp, double frequency, decimal kesh, int cost) : base(stamp, frequency, kesh, cost) { }
public void Conclusion(TextBox b1, TextBox b2, TextBox b3, TextBox b4)//если нажата кнопка перехода на страницу с корзиной товаров
{
    //если текстовый блок №1 пустой и не содержит значение марки процессора
    if (b1.Text == " ")
        Two.Invoke(this, new FourEventArgs("Введите значение типа марки процессора из предложенных!", this.Stamp));
    //если текстовый блок №2 пустой и не содержит значение объема тактовой частоты
    if (b2.Text == " ")//если текстовый блок №2 пустой и не содержит значение объема тактовой частоты
        Two.Invoke(this, new FourEventArgs("Введите значение объема тактовой частоты из предложенных!", this.Frequency));
    //если текстовый блок №3 пустой и не содержит значение объема КЭШа
    if (b3.Text == " ")
        Two.Invoke(this, new FourEventArgs("Введите значение объема КЭШа из предложенных!", this.Kesh));
    //если текстовый блок №4 пустой и не содержит значение стоимости процессора
    if (b4.Text == " ")
        Two.Invoke(this, new FourEventArgs("Введите значение стоимости процессора!", this.Cost));
    //если все текстовые блоки пустые и не содержат соответствующие значения
    if (b1.Text != " " && b2.Text != " " && b3.Text != " " && b4.Text != " ")
        Two.Invoke(this, new FourEventArgs("Вы ввели основные характеристики процессора из предложенных", this.Stamp));//фиксирование события
    else
    {
        Two.Invoke(this, new FourEventArgs("Введите основные характеристики процессора из предложенных", this.Stamp));
    }
}
}
public class MotherBoard : ProcessorOne
{
    //РЕАЛИЗАЦИЯ ВТОРОГО ОКНА ФОРМЫ:ДОПОЛНИТЕЛЬНЫЕ ХАРАКТЕРИСТИКИ ПРОЦЕССОРА
    public double ram;//объем оперативной памяти
    public int core;//количество ядер
    public int threads;//количество потоков
    public string socket;//гнездо процессора
    public int rate;//разрядность вычислений процессора
    public virtual double Ram { get;set; } //свойство для инициализации типа объема оперативной памяти процессора
    public virtual int Core { get; set; }//свойство для инициализации количества ядер
    public virtual int Threads { get; set; }//свойство для инициализации количества потоков
    public virtual string Socket { get; set; }//свойство для инициализации гнезда процессора
    public virtual int Rate { get; set; }//свойство для инициализации разрядности вычислений процессора
    public MotherBoard():base() { }
    public MotherBoard(string stamp, double frequency, decimal kesh, int cost, double ram, int core, int threads, string socket, int rate) : base(stamp, frequency, kesh, cost)
    { Ram = ram; Core = core; Threads = threads; Socket = socket; Rate = rate; }
    public override void List(ListBox b)//ПЕРЕОПРЕДЕЛЕНИЕ МЕТОДА КЛАССА Processor,вывод стандартных характеристик процессора
    {
b.Items.Insert(4, "Объем оперативной памяти=" + this.Ram + " " + "Гб");
b.Items.Insert(5, "Количество ядер=" + this.Core);
b.Items.Insert(6, "Количество потоков=" + this.Threads);
b.Items.Insert(7, "Гнездо процессора=" + this.Socket);
b.Items.Insert(8, "Разрядность вычислений процессора=" + this.Rate + " " + "bit");
}
}
    public class MotherBoardOne : MotherBoard
    {
        public delegate void MotherBoardHandler(string message);
        public event MotherBoardHandler Three;
        public override double Ram//ПЕРЕОПРЕДЕЛЕНИЕ СВОЙСТВА В КЛАССЕ MotherBoard
        {
            get { return ram; }
            set { this.ram = value; }
        }
        public void RamCheck()//проверка свойства класса,передающего объем оперативной памяти процессора, после инициализации-допустимости значений полей, фиксирование соответствующего события
        {
            if (ram.GetTypeCode() == TypeCode.Double)
            { Three.Invoke($"Введенное значение объема оперативной памяти соответствует допустимому"); }
            else { Three.Invoke($"Введенное значение объема оперативной памяти не соответствует допустимому"); }
        }
        public override int Core//ПЕРЕОПРЕДЕЛЕНИЕ СВОЙСТВА В КЛАССЕ MotherBoard
        {
            get { return core; }
            set { this.core = value; }
        }
        public override int Threads//ПЕРЕОПРЕДЕЛЕНИЕ СВОЙСТВА В КЛАССЕ MotherBoard
        {
            get { return threads; }
            set { this.threads = value; }
        }
        public override string Socket//ПЕРЕОПРЕДЕЛЕНИЕ СВОЙСТВА В КЛАССЕ MotherBoard
        {
            get { return socket; }
            set { this.socket = value; }
        }
        public override int Rate//ПЕРЕОПРЕДЕЛЕНИЕ СВОЙСТВА В КЛАССЕ MotherBoard
        {
            get { return rate; }
            set { this.rate = value; }
        }
        public MotherBoardOne(string stamp, double frequency, decimal kesh, int cost, double ram, int core, int threads, string socket, int rate) : base(stamp, frequency, kesh, cost, ram, core, threads, socket, rate) { }
        //для перехода на корзину с покупками
        public void Conclusion(TextBox b5, TextBox b6, TextBox b7, TextBox b8, TextBox b9)//ПЕРЕГРУЖЕННЫЙ МЕТОД КЛАССА ProcessorOne,фиксирование событий о стандартных характеристиках процессора
        {
            //если текстовый блок с объемом оперативной памяти процессора пустой
            if (b5.Text == " ")
                Three.Invoke($"Введите значение объема оперативной памяти процессора!");
            //если текстовый блок с количеством ядер процессора пустой
            if (b6.Text == " ")
                Three.Invoke($"Введите количество ядер процессора!");
            //если текстовый блок с количеством потоков процессора пустой
            if (b7.Text == " ")
                Three.Invoke($"Введите количество потоков процессора!");
            //если текстовый блок с наименованием гнезда процессора пустой
            if (b8.Text == " ")
                Three.Invoke($"Введите наименование гнезда процессора!");
            //если текстовый блок с разрядностью вычислений процессора пустой
            if (b9.Text == " ")
                Three.Invoke($"Введите значение разрядности вычислений процессора!");
        }
        public void Conclusion()//фиксирование событий о выводе стандартных характеристиках процессора
        {
            Three.Invoke($"Вы ввели стандартные характеристики процессора");
        }
        public void Conc()
        {
            Three.Invoke($"Введите стандартные характеристики процессора");//фиксирование события производится если не были введены стандартные характеристики процессора
        }
    }
public class ShoppingCart : MotherBoardOne
{
    public Processor Processor { get; set; }//цвет процессора
    public string Country { get; set; }//наименование страны,в которой производился процессор
    public int Guarantee { get; set; }// срок гарантии с момента приобретения прцессора
    public int Price { get; set; }//скидка на цену процессора
    public DateTime Date { get; set; }//дата производства процессора
    public string Comp1 { get; set; }//наименование товара-процессор
    //конструктор с определением характеристик процессора
    public ShoppingCart(string stamp, double frequency, decimal ram, int cost, double ram1, int core, int threads, string socket, int rate, string
    country, int guarantee, int price, DateTime date, Processor processor,string comp1) : base(stamp, frequency, ram, cost, ram1, core, threads, socket, rate) { Country = country;
Guarantee = guarantee; Price = price; Date = date; Processor = processor;Comp1 = comp1; }
public void Text(RichTextBox b1)//вывод дополнительной информации о процессоре
{
b1.Clear();
b1.Text += String.Format("Данный тип марки процессора изготовлен в стране:{0}\n", this.Country);
b1.Text += String.Format("Срок гарантии процессора данного типа марки составляет {0} месяцев\n", this.Guarantee);
b1.Text += String.Format("Цвет процессора:{0}", this.Processor);
b1.Text += String.Format("Дата производства данного типа марки процесора:{0}\n", this.Date.ToShortDateString());
b1.Text += String.Format("Скидка в {0}% на цену данного типа марки процессора ожидается весной следующего года\n", this.Price);
}
//вывод списка с характеристиками процессора при удалении 2 окна
public void List(ListBox b1, ListBox b)//ПЕРЕГРУЗКА МЕТОДА КЛАССА MotherBoard
{
    if (b1.Items.Count != 0)//если список №2 заполнен
    {
        b1.Items.Clear();//удали содержимое 2 списка-его характеристики
    }
    b.Items.Insert(0, Comp1);//первый элемент листа-значение Comp1-наименование товара(услуги)
}
public void List(ListBox b1, ListBox b, RichTextBox c)//ПЕРЕГРУЗКА МЕТОДА КЛАССА MotherBoard
{
    int index = b.FindString(Comp1);//индекс,содержащий значение Comp1-наименование товара(услуги)
    if (b.SelectedIndex == index)//если выбран индекс, содержащий значение товара(услуги)(в нашем случае слово "Процессор")
    {
    //заполнение 2 списка элементами компьютера
    b1.Items.Clear();
    b1.Items.Insert(0, "Тип марки процессора=" + this.Stamp);
    b1.Items.Insert(1, "Объем тактовой частоты=" + this.Frequency + " " + "Гб");
    b1.Items.Insert(2, "Объем КЭШа=" + this.Kesh + " " + "Гб");
    b1.Items.Insert(3, "Стоимость процессора=" + this.Cost + " " + "руб");
    b1.Items.Insert(4, "Объем оперативной памяти=" + this.Ram + " " + "Гб");
    b1.Items.Insert(5, "Количество ядер=" + this.Core);
    b1.Items.Insert(6, "Количество потоков=" + this.Threads);
    b1.Items.Insert(7, "Гнездо процессора=" + this.Socket);
    b1.Items.Insert(8, "Разрядность вычислений процессора=" + this.Rate + " " + "bit");
    Text(c);//введи в текстовом поле дополнительную информацию о процессоре
     }
}
public void List(ListBox b2, ListBox b, TextBox v)
{
    int index = b.FindString(Comp1);//индекс,содержащий значение Comp1-наименование товара(услуги)
    if (b.SelectedIndex == index)//если выбран индекс, содержащий значение Comp1-наименование товара(услуги)
    {
        b2.Items.Clear();//очистить 3 список перед добавлением цены процессора
        b2.Items.Insert(0, this.Cost);//добавить в 3 список цену за процессор
    }
}
public void Choice(TextBox z, string Firm, ListBox b1, ListBox b)//организация выбора фирмы,продающей процессор, и вывод соответствующих товаров(услуг),которые выбрал клиент
  {
if(z.Text==Firm)//если текстовое поле содержит наименование фирмы
{
    List(b1, b);//вывод цены,характеристик при обозначении названия выбранной фирмы
}
}
public void Text1(TextBox c)//итоговая сумма,которую должен заплатить клиент-элемент TextBox
{
    if (c.Text == " ")//если текстовый блок пустой
        c.Text = Convert.ToString(Cost);//ввести цену процессора
    else
    {
        c.Clear();//очистить текстовый блок перед добавлением цены процессора
        c.Text = Convert.ToString(Cost);
    }
}
}
public class Shop1 : Computer//РЕАЛИЗАЦИЯ 3 ОКНА:КОМПОНЕНТЫ КОМПЬЮТЕРА
{
    public List<int> Comp = new List<int>();
    public Computer Computer { get; set; }//наименование процессора, с которым совпадают компоненты компьютера
//конструктор,определяющий цену компонентов процессора
public Shop1(int harddrive, int videocard, int motherboard, int networkdapter, int powersupply, int floppydrive, int systemunit, int monitor, int soundadapter, int modul):base(harddrive, videocard, motherboard, networkdapter, powersupply, floppydrive, systemunit, monitor, soundadapter, modul) { }
//конструктор,определяющий модель компонентов процессора и дополнить информацию о фирме:ОТНОШЕНИЕ МЕЖДУ КЛАССАМИ Computer и Shop1-КОМПОЗИЦИЯ
public Shop1(string harddrive1, string videocard1, string motherboard1, string networkdapter1, string powersupply1, string
floppydrive1, string systemunit1, string monitor1, string soundadapter1, string modul1, string fim, string country1, int guarantee1, int price1, DateTime date1, string installment, int credit, string name, string component) : base(harddrive1, videocard1, motherboard1, networkdapter1, powersupply1, floppydrive1, systemunit1, monitor1, soundadapter1, modul1, fim) {
    Country1 = country1; Guarantee1 = guarantee1;Price1 = price1; Date1 = date1; Installment = installment; Credit = credit; new Computer(name); Component = component;
}
public string Country1 { get; set; }//наименование страны,в которой производились компоненты компьютера
public int Guarantee1 { get; set; }// срок гарантии с момента приобретения компонентов компьютера
public int Price1 { get; set; }//скидка на приобретение комплекта компонентов компьютера
public DateTime Date1 { get; set; }//дата производства компонентов компьютера
public string Installment { get; set; }//можно ли взять комплект компонентов компьютера в рассрочку
public int Credit { get; set; }//процент кредита
 public string Component { get; set; }//наименование товара(услуги),которую клиент хочет приобрести
public void Check1(RichTextBox c) //дополнительная информация о компонентах компьютера
 {
c.Clear();//очистить richTextBox1 перед добавлением информации
c.Text += String.Format("Данный комплект компонентов компьютера изготовлен в стране:{0}\n", this.Country1); c.Text += String.Format("Срок гарантии с момента приобретения компонентов компьютера составляет {0} месяцев\n", this.Guarantee1); c.Text += String.Format("Наименование подходящего процессора:{0}", this.Computer);
c.Text += String.Format("Дата производства компонентов компьютера :{0}\n", this.Price1); c.Text += String.Format("Скидка в {0}% на цену данного комплекта компонентов компьютера ожидается зимой следующего года\n", this.Date1.ToShortDateString()); c.Text += String.Format("Получение рассрочки:{0}", this.Installment); c.Text += String.Format("Процент кредита:{0} при его оформлении", this.Credit);
}
public void Click2(ListBox v, ListBox v1)//ПЕРЕГРУЖЕННЫЙ МЕТОД КЛАССА Computer
   {
if (v1.Items.Count != 0)//если 2 список заполнен
{
    v1.Items.Clear();//очистим список с характеристиками товара(услуги) перед добавлением характеристики нового товара(услуги)
}
v.Items.Insert(0, Component);//добавим в 1 список значение Component-компоненты компьютера
  }
public void Click2(ListBox v, RichTextBox z, ListBox v1)//ПЕРЕГРУЖЕННЫЙ МЕТОД КЛАССА Computer
  {
int index = v.FindString(Component);//индекс,содержащий значение Component
if (v.SelectedIndex == index)//если выбран индекс, содержащий значение Component
{
    Clock(v1);//добавим элементы коллекции в лист с характеристиками товаров(услуг)
    Check1(z);//введи в текстовом поле информацию о компонентах компьютера
  }
}
public void Click(ListBox v1, ListBox v2)//для введения цены компонентов компьютера в 3 список
{
    if (v1.SelectedIndex == 0)//если выбрать 1 элемент во 2 списке
           { v2.Items.Clear();//очистить список перед добавлением в него элементов
             v2.Items.Insert(0, Harddrive);//1 элемент 3 списка = элемент с ценой компонентов компьютера
            }
        if (v1.SelectedIndex == 1)//если выбрать 2 элемент во 2 списке
       { v2.Items.Clear(); 
        v2.Items.Insert(0, Videocard);
}
if (v1.SelectedIndex == 2)//если выбрать 3 элемент во 2 списке
    { v2.Items.Clear(); 
                    v2.Items.Insert(0, MotherBoard);
}
if (v1.SelectedIndex == 3)//если выбрать 4 элемент во 2 списке
  { v2.Items.Clear(); v2.Items.Insert(0, Networkdapter);
}
if (v1.SelectedIndex == 4)//если выбрать 5 элемент во 2 списке
  { v2.Items.Clear(); v2.Items.Insert(0, Powersupply);
}
if (v1.SelectedIndex == 5)//если выбрать 6 элемент во 2 списке
  { v2.Items.Clear(); v2.Items.Insert(0, Floppydrive);
}
if (v1.SelectedIndex == 6)//если выбрать 7 элемент во 2 списке
 { v2.Items.Clear(); v2.Items.Insert(0, Systemunit);
}
if (v1.SelectedIndex == 7)//если выбрать 8 элемент во 2 списке
 { v2.Items.Clear(); v2.Items.Insert(0, Monitor);
}
if (v1.SelectedIndex == 8)//если выбрать 9 элемент во 2 списке
  { v2.Items.Clear(); v2.Items.Insert(0, Soundadapter);
}
if (v1.SelectedIndex == 9)//если выбрать 10 элемент во 2 списке
 { v2.Items.Clear(); v2.Items.Insert(0, Modul);
}
}
public void Choice(TextBox c, string Firm, ListBox v, ListBox v1)//ввести характеристики компонентов компьютера для соответствующей фирмы
{
if (c.Text == Firm)//если текстовое поле содержит наименование искомой фирмы
Click2(v, v1);//вызываем метод внесения в 1 список наименования выбранного клиентом товара(услуги)
}
public void Distribution(TextBox z)//ПЕРЕГРУЗКА МЕТОДА КЛАССА Computer,вывод цены за все компоненты компьютера 
{ 
if (z.Text == " ")//если текстовое поле пустое
    z.Text += Convert.ToString(Click4(Comp));//вывод суммы заказа
else
{
    z.Clear();//очистить текстовое поле
    z.Text += Convert.ToString(Click4(Comp));//вывод суммы заказа
    }
}
}
public class Shop2 : WorkCompany//РЕАЛИЗАЦИЯ 3 ФОРМЫ:ФИРМА,ОРГАНИЗУЮЩАЯ СБОРКУ КОМПЬЮТЕРА
{
    public WorkCompany WorkCompany { get; set; }//город,в котором собирается компьютер
    public ProcessorOne ProcessorOne { get; set; }//АССОЦИАЦИЯ,QR-код фирмы
   //конструктор,определяющий характеристики фирмы:ОТОНОШЕНИЕ МЕЖДУ КЛАССАМИ WorkCompany и Shop2-АГРЕГАЦИЯ
    public Shop2(int experience, int quantity, int positive, int denial, int time, string forma, string fot, int amount, int term, string country2, int
    guarantee2, string price2, DateTime contract, WorkCompany work, string comp2) : base(experience, quantity, positive, denial, time, forma, fot)
    { Amount = amount; Term = term; Country2 = country2; Guarantee2 = guarantee2; Price2 = price2; Contract = contract; WorkCompany = work; Comp2 = comp2; }
    public Shop2() : base() { }//фирма по сборке компьютера
     public int Amount { get; set; }//сумма, затраченная фирмой на сборку компьютера
     public int Term { get; set; }//срок, в течение которого фирма должна организовать сборку компьютера
   public string Country2 { get; set; }//наименование страны,в которой осуществлялась сборка компонентов компьютера
    public int Guarantee2 { get; set; }// срок гарантии с момента оформления договора на осуществление сборки компонентов компьютера
    public string Price2 { get; set; }//скидка на осуществление сборки компонентов компьютера
     public DateTime Contract { get; set; }//дата заключения договора о сборке компьютера
     public string Comp2 { get; set; }//наименование товара(услуги)
    public void Click2(ListBox v, ListBox v1)//ПЕРЕГРУЖЕННЫЙ МЕТОД КЛАССА WorkCompany,ввод в 1 список товар(услугу),которую выбрал клиент
     {
if (v1.Items.Count != 0)//если список 2 заполнен
{ v1.Items.Clear();//список 2 очищается перед добавлением характеристик фирмы,занимающейся сборкой компьютера
 }
 v.Items.Insert(0, Comp2);//добавить в первый список характеристики фирмы,занимающейся сборкой компьютера
 }
public void Click2(ListBox v, ListBox v1, RichTextBox z, ListBox v2, int sum)//введение во 2 список характеристик фирмы
    {
        int index = v.FindString(Comp2);//индекс, содержащий значение товара(услуги), в нашем случае "Сборка компьютера"
        if (v.SelectedIndex == index)//если выбран индекс, содержащий значение товара(услуги)
        {
            //вызовем метод,добавляющий элементы коллекции в лист с характеристиками товаров(услуг)
            Click8(v1);
            Checkod(z);//введи в текстовом поле дополнительную информацию о сборке компонентов компьютера
            }
        }
        public void Ckok(ListBox b2, ListBox b, int sum)//
        {
            int index = b.FindString(Comp2);//индекс, содержащий значение WorkCompany
            if (b.SelectedIndex == index)//если выбран индекс, содержащий значение WorkCompany
            {
                b2.Items.Clear();//очисти список 3
                b2.Items.Insert(0, sum);//добавь в 3 список цену за услуги фирмы
            }
        }
        public void Choice2(TextBox z, string Firm, ListBox b1, ListBox b)//вывод товаров(услуг),которые предлагает выбранная клиентом фирма
        {
if (z.Text == Firm)//если текстовое поле равно названию выбранной фирмы
        {
            Click2(b, b1);//вывод данных о фирме и стоимости сборки компьютера
          }
        }
        //дополнительная информация о товаре(услуге)
        public void Checkod(RichTextBox c)
        {
            c.Clear();//очистить richTextBox перед введением информации
            c.Text += String.Format("Величина суммы,затраченной фирмой на сборку компьютера:{0}", this.Amount); 
           c.Text += String.Format("Срок,в течение которого фирма должна организовать сборку компьютера:{0}", this.Term); 
           c.Text += String.Format("Страна, в которой осуществлялась сборка компьютера:{0}", this.Country2); 
          c.Text += String.Format("Сборка компьютера предоставляется в городе:{0}", this.WorkCompany); 
         c.Text += String.Format("Срок гарантии с момента оформления договора на осуществление сборки компонентов компьютера составляет {0}месяцев\n", this.Guarantee2);
         c.Text += String.Format("QR - код фирмы: {0} ", this.ProcessorOne);
     c.Text += String.Format("Скидка в {0}% на цену сборки компонентов компьютера ожидается осенью следующего года", this.Price2);
                c.Text += String.Format("Дата заключения договора о сборке компонентов компьютера: { 0}\n", this.Contract.ToShortDateString());
        }
        public void Distribution(TextBox v, int sum)//ПЕРЕГРУЖЕННЫЙ МЕТОД КЛАССА WorkCompany, вывод цены на сборку компьютера
       {
            if (v.Text == " ")//если текстовый блок пустой
                v.Text = Convert.ToString(sum);//введи цену за сборку компьютера
            else
            {
                v.Clear();//очисти текстовый блок
                v.Text = Convert.ToString(sum);
            }
        }
    }
    public class Shop3 : DeliveryComponent//РЕАЛИЗАЦИЯ 3 ОКНА:ФИРМА,ОРГАНИЗУЮЩАЯ ДОСТАВКУ КОМПОНЕНТОВ КОМПЬЮТЕРА
    {
        public delegate void Shop3Handler(string message);
        public event Shop3Handler Seven;
        public Shop3() : base() { }
        public DeliveryComponent DeliveryComponent { get; set; }//наименование фирмы по доставке компьютера
         //конструктор для определения способов доставки компонентов компьютера-КОМПОЗИЦИЯ
        public Shop3(int experience, int quantity, int positive, int denial, int time, string forma, int guarantee, string ret, int partner, int city, int office, string phone, int oneway, int twoway, int threeway, int fourway, string fok, string deliv, string comp3, int quantitycity, string timer, int price3, string return1, int experience1, string notification, DateTime contract1, string delivery, string
        delivery1, string delivery2, string delivery3) : base(experience, quantity, positive, denial, time, forma, guarantee, ret, partner, city, office, phone, oneway, twoway, threeway, fourway, fok)
        {
            Comp3 = comp3; DeliveryComponent = new
DeliveryComponent(deliv); QuantityCity = quantitycity; Timer = timer; Price3 = price3; Return1 = return1; Experience1 = experience1;
            Notification = notification; Contract1 = contract1; Delivery = delivery; Delivery1 = delivery1; Delivery2 = delivery2; Delivery3 =
            delivery3;
        }
        public int QuantityCity { get; set; }//количество городов,в которые осуществляется доставка
        public string Timer { get; set; }//среднее время доставки
        public int Price3 { get; set; }//скидка на второй заказ
       public string Return1 { get; set; }//возврат полной стоимости в случае нарушения целостности упаковки
        public int Experience1 { get; set; }//количество раз пользования клиентами данного способа доставки
        public string Notification { get; set; }//форма оповещения(уведомления)о доставке товара
       public DateTime Contract1 { get; set; }//дата заключения договора о доставке компьютера
        public string Delivery { get; set; }//наименование 1 способа доставки
        public string Delivery1 { get; set; }//наименование 2 способа доставки
        public string Delivery2 { get; set; }//наименование 3 способа доставки
        public string Delivery3 { get; set; }//наименование 4 способа доставки
        public string Comp3 { get; set; }//наименование товара(услуги)
        public void Click2(ListBox v, ListBox v1)//ПЕРЕГРУЖЕННЫЙ МЕТОД КЛАССА Shop3,вывод наименования выбранного клиентом товара(услуги)
        {
            if (v1.Items.Count != 0)//если список 2 заполнен
            {
                v1.Items.Clear();//список 2 сделать пустым
            }
            v.Items.Insert(0, Comp3);//в 1 лист добавить значение товара(услуги)
        }
        public void Click(ListBox v, ListBox v1)//вывод характеристик фирмы по доставке компьютера
           {
int index = v.FindString(Comp3);//индекс,содержащий значение товара(услуги)
if (v.SelectedIndex == index)//если выбран индекс,содержащий значение выбранного клиентом товара(услуги)
{
Click9(v1); //ввод в список элементов,содержащих способы доставки в конкретном городе
        }
    }
    public void Click2(ListBox v1, ListBox v2, RichTextBox z, TextBox z1)//вывод цены по способу доставки компьютера в зависимости от города
    {
if (v1.SelectedIndex == 0)//если выбрать 1 элемент во 2 списке
     { v2.Items.Clear();//очистить 2 список перед добавлением цены способа доставки
v2.Items.Insert(0, OneWay);//добавить во 2 список цену за 1 способ доставки в 1 город
z.Clear();
Information(z);//вводится дополнительная информация о 1 способе доставки в 1 город
    Distribution(z1, OneWay);//вводится цена за доставку 1 способа доставки в 1 город
}
if (v1.SelectedIndex == 1)//если выбрать 2 элемент во 2 списке
       { v2.Items.Clear(); v2.Items.Insert(0, TwoWay);//добавить во 2 список цену за 2 способ доставки в 2 город
    z.Clear();
But(z);//вводится дополнительная информация о 2 способе доставки во 2 город
Distribution(z1, TwoWay);//вводится цена за доставку 2 способа доставки во 2 город
}
if (v1.SelectedIndex == 2)//если выбрать 3 элемент во 2 списке
    { v2.Items.Clear(); v2.Items.Insert(0, ThreeWay);//добавить во 2 список цену за 3 способ доставки в 3 город
    z.Clear();
Butt(z);//вводится дополнительная информация о 3 способе доставки в 3 город
Distribution(z1, ThreeWay);//вводится цена за доставку 3 способа доставки в 3 город
}
if (v1.SelectedIndex == 3)//если выбрать 4 элемент во 2 списке
{ v2.Items.Clear(); v2.Items.Insert(0, FourWay);//добавить во 2 список цену за 4 способ доставки в 4 город
    z.Clear();
Information3(z);//вводится дополнительная информация о 4 способе доставки в 4 город
Distribution(z1, FourWay);//вводится цена за доставку 4 способа доставки в 4 город
}
}
public void Choice3(TextBox z, string Firm, ListBox b, ListBox b1)//метод,выводящий соответствующий товар(услугу),которую выбрал клиент
{
if (z.Text == Firm)//если текстовый блок содержит названию фирмы по доставке компьютера,которую выбрал клиент
    {
Click2(b, b1);//вывод характеристик фирмы
}
}
public void Distribution(TextBox z, int sum)//ПЕРЕГРУЖЕННЫЙ МЕТОД КЛАССА DeliveryComponent вывод стоимости доставки в конкретный город
{
if(z.Text==" ")//если текстовый блок пустой
z.Text += Convert.ToString(sum);//выводится стоимость доставки в городе
else
{
    z.Clear();//очистить текстовый блок
    z.Text += Convert.ToString(sum);
}
}
public override void Information(RichTextBox q)//ПЕРЕОПРЕДЕЛЕННЫЙ МЕТОД КЛАССА DeliveryComponent,вывод дополнительной информации о 1 способе доставки
{
q.Clear();//очистить richTextBox перед добавлением информации о 1 способе доставки
q.Text += String.Format("Имеется {0} городов, в которые осуществляется {1}", this.QuantityCity, this.Delivery);
q.Text += String.Format("Среднее время {0} составляет {1}", this.Delivery, this.Timer);
q.Text += String.Format("Скидка {0}% на использование {1} ожидается весной следующего года", this.Price3, this.Delivery);
q.Text += String.Format("Возможность возврата полной стоимости в случае нарушения целостности упаковки:{0}", this.Return1);
q.Text += String.Format("Адрес организации:{0}", this.DeliveryComponent);
q.Text += String.Format("Количество раз пользования данной услугой:{0} равно {1}", this.Delivery, this.Experience1);
q.Text += String.Format("Форма оповещения(уведомления) о {0}:{1}", this.Delivery, this.Notification);
q.Text += String.Format("Дата заключения договора об услуге {0}:{1}", this.Delivery, this.Contract1.ToShortDateString());
}
public void But(RichTextBox v)//ПЕРЕГРУЖЕННЫЙ МЕТОД КЛАССА DeliveryComponent , вывод информации о 2 способе доставки
{
    v.Clear();//очистить richTextBox перед добавлением информации о 2 способе доставки
    v.Text += String.Format("Имеется {0} городов, в которые осуществляется {1}", this.QuantityCity, this.Delivery1); v.Text += String.Format("Среднее время {0} составляет {1}", this.Delivery1, this.Timer); v.Text += String.Format("Скидка {0}% на использование {1} ожидается весной следующего года", this.Price3, this.Delivery1); v.Text += String.Format("Возможность возврата полной стоимости в случае нарушения целостности упаковки:{0}", this.Return1); v.Text += String.Format("Адрес организации:{0}", this.DeliveryComponent); v.Text += String.Format("Количество раз пользования данной услугой:{0} равно {1}", this.Delivery1, this.Experience1); v.Text += String.Format("Форма оповещения(уведомления) о {0}:{1}", this.Delivery1, this.Notification); v.Text += String.Format("Дата заключения договора об услуге {0}:{1}", this.Delivery1, this.Contract1.ToShortDateString());
}
public void Butt(RichTextBox z)//ПЕРЕГРУЖЕННЫЙ МЕТОД КЛАССА DeliveryComponent , вывод информации о 3 способе доставки
{
    z.Clear();//очистить richTextBox перед добавлением информации о 3 способе доставки
    z.Text += String.Format("Имеется {0} городов, в которые осуществляется {1}", this.QuantityCity, this.Delivery2); z.Text += String.Format("Среднее время {0} составляет {1}", this.Delivery2, this.Timer); z.Text += String.Format("Скидка {0}% на использование {1} ожидается весной следующего года", this.Price3, this.Delivery2); z.Text += String.Format("Возможность возврата полной стоимости в случае нарушения целостности упаковки:{0}", this.Return1); z.Text += String.Format("Адрес организации:{0}", this.DeliveryComponent); z.Text += String.Format("Количество раз пользования данной услугой:{0} равно {1}", this.Delivery2, this.Experience1); z.Text += String.Format("Форма оповещения(уведомления) о {0}:{1}", this.Delivery2, this.Notification); z.Text += String.Format("Дата заключения договора об услуге {0}:{1}", this.Delivery2, this.Contract1.ToShortDateString());
}
public void Information3(RichTextBox c)//вывод информации о 4 способе доставки
{
    c.Clear();//очистить richTextBox перед добавлением информации о 4 способе доставки
    c.Text += String.Format("Имеется {0} городов, в которые осуществляется {1}", this.QuantityCity, this.Delivery3); c.Text += String.Format("Среднее время {0} составляет {1}", this.Delivery3, this.Timer); c.Text += String.Format("Скидка {0}% на использование {1} ожидается весной следующего года", this.Price3, this.Delivery3); c.Text += String.Format("Возможность возврата полной стоимости в случае нарушения целостности упаковки:{0}", this.Return1); c.Text += String.Format("Адрес организации:{0}", this.DeliveryComponent); c.Text += String.Format("Количество раз пользования данной услугой:{0} равно {1}", this.Delivery3, this.Experience1); c.Text += String.Format("Форма оповещения(уведомления) о {0}:{1}", this.Delivery3, this.Notification); c.Text += String.Format("Дата заключения договора об услуге {0}:{1}", this.Delivery3, this.Contract1.ToShortDateString());
}
public void Check1(TextBox c, TextBox c1, TextBox c2, TextBox c3, TextBox c4)//метод, использующийся для подсчета общей суммы покупки товара(услуги)
{
    //ВЫБОР ОДНОГО ТОВАРА(УСЛУГИ)
    if (c.Text != " " && c1.Text == " " && c2.Text == " " && c3.Text == " ")//если первый текстовый блок заполнен, а три другие пустые
            {
        c4.Clear();//очистить текстовый блок для выведения итоговой суммы
    int sum1 = Convert.ToInt32(c.Text);//переведем значение первого текстового блока в тип данных int
    int sum = sum1;//приравняем целочисленное значение sum1 к значению int sum
    c4.Text = Convert.ToString(sum);//переведем значение int sum в тип данных string для инициализации текстового блока, использующегося для выведения итоговой суммы
}
if (c.Text == " " && c1.Text != " " && c2.Text == " " && c3.Text == " ")//если второй текстовый блок заполнен, а три другие пустые
      {
    c4.Clear();
int sum2 = Convert.ToInt32(c1.Text);
int sum3 = sum2; c4.Text = Convert.ToString(sum3);
}
if (c.Text == " " && c1.Text == " " && c2.Text != " " && c3.Text == " ") //если третий текстовый блок заполнен, а три другие пустые
       {
    c4.Clear();
int sum4 = Convert.ToInt32(c2.Text);
int sum5 = sum4; c4.Text = Convert.ToString(sum5);
}
if (c.Text == " " && c1.Text == " " && c2.Text == " " && c3.Text != " ")//если 4 текстовый блок заполнен, а три другие пустые
      {
    c4.Clear();
int sum6 = Convert.ToInt32(c3.Text);
int sum7 = sum6; c4.Text = Convert.ToString(sum7);
}
//ВЫБОР ДВУХ ТОВАРОВ ИЛИ ДВУХ УСЛУГ
if (c.Text != " " & c1.Text != " " && c2.Text == " " && c3.Text == " ")//если 1 и 2 текстовый блок заполнен, а два другие пустые
      {
    c4.Clear();//очистить текстовый блок для выведения итоговой суммы
int sum8 = Convert.ToInt32(c.Text);//переведем значение первого текстового блока в тип данных int
int sum9 = Convert.ToInt32(c1.Text);//переведем значение второго текстового блока в тип данных int
int sum10 = sum8 + sum9;//приравняем целочисленное значение sum1 к сумме целочисленных значений sum8 и sum9
c4.Text = Convert.ToString(sum10);//переведем значение int sum10 в тип данных string для инициализации текстового блока, использующегося для выведения итоговой суммы
}
if (c.Text != " " && c1.Text == " " && c2.Text != " " && c3.Text == " ")//если 1 и 3 текстовый блок заполнен,а два другие пустые
    {
    c4.Clear();
int sum11 = Convert.ToInt32(c.Text);
int sum12 = Convert.ToInt32(c2.Text);
int sum13 = sum11 + sum12; c4.Text = Convert.ToString(sum13);
}
if (c.Text != " " && c1.Text == " " && c2.Text == " " && c3.Text != " ")//если 1 и 4 текстовый блок заполнен,а два другие пустые
    {
    c4.Clear();
int sum14 = Convert.ToInt32(c.Text);
int sum15 = Convert.ToInt32(c3.Text);
int sum16 = sum14 + sum15; c4.Text = Convert.ToString(sum16);
}
if (c.Text == " " && c1.Text != " " && c2.Text != " " && c3.Text == " ")//если 2 и 3 текстовый блок заполнен,а два другие пустые
    {
    c4.Clear();
int sum17 = Convert.ToInt32(c1.Text);
int sum18 = Convert.ToInt32(c2.Text);
int sum19 = sum17 + sum18; c4.Text = Convert.ToString(sum19);
}
if (c.Text == " " && c1.Text != " " && c2.Text == " " && c3.Text != " ")//если 2 и 4 текстовый блок заполнен,а два другие пустые
     {
    c4.Clear();
int sum20 = Convert.ToInt32(c1.Text);
int sum21 = Convert.ToInt32(c3.Text);
int sum22 = sum20 + sum21; c4.Text = Convert.ToString(sum22);
}
if (c.Text == " " && c1.Text == " " && c2.Text != " " && c3.Text != " ")//если 3 и 4 текстовый блок заполнен,а два другие пустые
      {
    c4.Clear();
int sum23 = Convert.ToInt32(c2.Text);
int sum24 = Convert.ToInt32(c3.Text);
int sum25 = sum23 + sum24; c4.Text = Convert.ToString(sum25);
}
//ВЫБОР ТРЕХ ТОВАРОВ(УСЛУГ)
if (c.Text != " " && c1.Text != " " && c2.Text != " " && c3.Text == " ")//если 1, 2 и 3 текстовые блоки заполнены,а один пустой
{
    c4.Clear();//очистить текстовый блок для выведения итоговой суммы
    int sum26 = Convert.ToInt32(c.Text);//переведем значение первого текстового блока в тип данных int
    int sum27 = Convert.ToInt32(c1.Text);//переведем значение второго текстового блока в тип данных int
    int sum28 = Convert.ToInt32(c2.Text);//переведем значение третьего текстового блока в тип данных int
    int sum29 = sum26 + sum27 + sum28;//приравняем целочисленное значение sum29 к сумме целочисленных значений sum26,sum27 и sum28
c4.Text = Convert.ToString(sum29);//переведем значение int sum29 в тип данных string для инициализации текстового блока, использующегося для выведения итоговой суммы
}
if (c.Text != " " && c1.Text == " " && c2.Text != " " && c3.Text != " ")//если 1, 3 и 4 текстовые блоки заполнены,а один пустой
{
    c4.Clear();
    int sum30 = Convert.ToInt32(c.Text);
    int sum31 = Convert.ToInt32(c2.Text);
    int sum32 = Convert.ToInt32(c3.Text);
    int sum33 = sum30 + sum31 + sum32; c4.Text = Convert.ToString(sum33);
}
if (c.Text != " " && c1.Text != " " && c2.Text == " " && c3.Text != " ")//если 1, 2 и 4 текстовые блоки заполнены,а один пустой
{
    c4.Clear();
    int sum34 = Convert.ToInt32(c.Text);
    int sum35 = Convert.ToInt32(c1.Text);
    int sum36 = Convert.ToInt32(c3.Text);
    int sum37 = sum34 + sum35 + sum36; c4.Text = Convert.ToString(sum37);
}
if (c.Text == " " && c1.Text != " " && c2.Text != " " && c3.Text != " ")//если 1, 2 и 3 текстовые блоки заполнены,а один пустой
{
    c4.Clear();
    int sum38 = Convert.ToInt32(c1.Text);
    int sum39 = Convert.ToInt32(c2.Text);
    int sum40 = Convert.ToInt32(c3.Text);
    int sum41 = sum38 + sum39 + sum40; c4.Text = Convert.ToString(sum41);
}
//ВЫБОР ЧЕТЫРЕХ ТОВАРОВ(УСЛУГ)
if (c.Text != " " && c1.Text != " " && c2.Text != " " && c3.Text != " ")//если 1, 2,3 и 4 текстовые блоки заполнены
{
    c4.Clear();//очистить текстовый блок для выведения итоговой суммы
    int sum42 = Convert.ToInt32(c.Text);//переведем значение первого текстового блока в тип данных int
    int sum43 = Convert.ToInt32(c1.Text);//переведем значение второго текстового блока в тип данных int
    int sum49 = Convert.ToInt32(c2.Text);//переведем значение третьего текстового блока в тип данных int
    int sum45 = Convert.ToInt32(c3.Text);//переведем значение четвертого текстового блока в тип данных int
    int sum46 = sum42 + sum43 + sum49 + sum45;//приравняем целочисленное значение sum46 к сумме целочисленных значений sum42, sum43, sum49 и sum45
c4.Text = Convert.ToString(sum46);//переведем значение int sum46 в тип данных string для инициализации текстового блока, использующегося для выведения итоговой суммы
}
}
public void Ret()//метод для фиксирования события
 {
Seven.Invoke($"Спасибо, что выбрали нас!");
}
}
public abstract class New //АБСТРАКТНЫЙ КЛАСС для 5 и 6 окна
   {
public abstract void Click2(RadioButton c, ListBox v, RichTextBox z, RichTextBox z2, PictureBox q, string h1, string h2, string h3, string
h4);
//абстрактный член(метод), использующийся для выбора фирмы, продающей компоненты компьютера
public abstract void Distribution(TextBox z, RadioButton c,int sum);//метод для выведения информации о стоимости сборки компьютера(5 окно), информация о стоимости услуги по доставке компонентов(6 окно)
public abstract void Button();//метод, использующийся для фиксации события
public abstract void Button1();//метод,использующийся для фиксации события
public int Experience { get; set; }//свойство, применяющееся для инициализации стажа работников
public int Quantity { get; set; }//свойство, применяющееся для инициализации количества работников в фирме
public int Positive { get; set; }//свойство, применяющееся для инициализации количества положительных отзывов о работе фирмы
public int Denial { get; set; }//свойство, применяющееся для инициализации количества отрицательных отзывов о работе фирмы
public int Time { get; set; }//свойство, применяющееся для инициализации времени работы компании(фирмы)
public string Forma { get; set; }//свойство, применяющееся для инициализации формы организации фирмы
//конструктор для реализации 5 и 6 окон
public New(int experience, int quantity, int positive, int denial, int time, string forma)
{
    Experience = experience; Quantity = quantity;
    Positive = positive; Denial = denial; Time = time; Forma = forma;
}
public New() { }//пустой конструктор
}
public interface IComputer//ИНТЕРФЕЙС,использующийся для 4 и 5 окна
 {
void Graphity(PictureBox e);//логотип фирмы
void Button();//событие
void Button1();//событие
  }
public class Computer : IModification, IComputer//РЕАЛИЗАЦИЯ ЧЕТВЕРТОГО ОКНА:ПРИОБРЕТЕНИЕ КОМПОНЕНТОВ КОМПЬЮТЕРА, ПРИМЕНЕНИЕ ДВУХ ИНТЕРФЕЙСОВ
{
    //событие
    public delegate void ComputerHandler(string message);
    public event ComputerHandler Four;
    public string Fim { get; set; }//свойство для инициализации изображений
    public Computer(string harddrive1) { Harddrive1 = harddrive1; }//конструктор
    List<int> Comp = new List<int>();
//конструктор для определения цены компонентов компьютера в фирме
public Computer(int harddrive,int videocard,int motherboard,int networkdapter,int powersupply,int floppydrive,int systemunit,int monitor,int soundadapter,int modul)
{ Harddrive = harddrive;Videocard = videocard;MotherBoard = motherboard;Networkdapter = networkdapter;Powersupply =
powersupply;Floppydrive = floppydrive;
Systemunit = systemunit;Monitor = monitor;Soundadapter = soundadapter;Modul = modul; }
public Computer() { }//пустой конструктор
public int Harddrive { get; set; }//свойство, применяющееся для инициализации цены на жесткий диск
 public int Videocard { get; set; }//свойство, применяющееся для инициализации цены на видеокарту
public int MotherBoard { get; set; }//свойство, применяющееся для инициализации цены на материнскую плату
public int Networkdapter { get; set; }//свойство, применяющееся для инициализации цены на сетевой адаптер
public int Powersupply { get; set; }//свойство, применяющееся для инициализации цены на блок питания
 public int Floppydrive { get; set; }//свойство, применяющееся для инициализации цены на дисковод
public int Systemunit { get; set; }//свойство, применяющееся для инициализации цены на системный блок
 public int Monitor { get; set; }//свойство, применяющееся для инициализации цены на монитор
public int Soundadapter { get; set; }//свойство, применяющееся для инициализации цены на звуковой адаптер
public int Modul { get; set; }//свойство, применяющееся для инициализации цены на модули ОЗУ(оперативно-запоминающие устройства)
public string Harddrive1 { get; set; }//свойство, применяющееся для инициализации модели жесткого диска
 public string Videocard1 { get; set; }//свойство, применяющееся для инициализации модели видеокарты
public string MotherBoard1 { get; set; }//свойство, применяющееся для инициализации модели материнской платы
public string Networkdapter1 { get; set; }//свойство, применяющееся для инициализации модели сетевого адаптера
 public string Powersupply1 { get; set; }//свойство, применяющееся для инициализации модели блока питания
 public string Floppydrive1 { get; set; }//свойство, применяющееся для инициализации модели дисковода
 public string Systemunit1 { get; set; }//свойство, применяющееся для инициализации модели системного блока
 public string Monitor1 { get; set; }//свойство, применяющееся для инициализации модели монитора
public string Soundadapter1 { get; set; }//свойство, применяющееся для инициализации модели звукового адаптера
public string Modul1 { get; set; }//свойство, применяющееся для инициализации типа модуля ОЗУ(оперативно-запоминающие устройства)
//конструктор для определения модели компонентов компьютера
public Computer(string harddrive1,string videocard1,string motherboard1,string networkdapter1,string powersupply1,string
floppydrive1,string systemunit1,string monitor1,string soundadapter1,string modul1,string fim)
{
    Harddrive1 = harddrive1; Videocard1 = videocard1; MotherBoard1 = motherboard1; Networkdapter1 = networkdapter1; Powersupply1 =
       powersupply1; Floppydrive1 = floppydrive1; Systemunit1 = systemunit1;
    Monitor1 = monitor1; Soundadapter1 = soundadapter1; Modul1 = modul1; Fim = fim;
}
public void Click2(RadioButton c, ListBox v, RichTextBox z, PictureBox q, TextBox z1, string h1, string h2)//метод, использующийся для выведения характеристик фирмы по продаже компонентов компьютера,отзывов фирмы и логотипа фирмы
{
    if (c.Checked)//если выбрана фирма
    { v.Items.Clear();//очищается лист 1
        v.Items.Insert(0, "Жесткий диск модели" + " " + this.Harddrive1);//1 индекс листа 1-жесткий диск модели+значение Harddrive1
    v.Items.Insert(1, "Видеокарта модели" + " " + this.Videocard1);//2 индекс листа 1
    v.Items.Insert(2, "Материнская плата модели" + " " + this.MotherBoard1);//3 индекс 1 листа
 v.Items.Insert(3, "Сетевой адаптер модели" + " " + this.Networkdapter1);//4 индекс 1 листа
 v.Items.Insert(4, "Блок питания модели" + " " + this.Powersupply1);//5 индекс 1 листа
 v.Items.Insert(5, "Дисковод модели" + " " + this.Floppydrive1);//6 индекс 1 листа
  v.Items.Insert(6, "Системный блок модели" + " " + this.Systemunit1);//7 индекс 1 листа
  v.Items.Insert(7, "Монитор модели" + " " + this.Monitor1);//8 индекс 1 листа
  v.Items.Insert(8, "Звуковой адаптер модели" + " " + this.Soundadapter1);//9 индекс 1 листа
 v.Items.Insert(9, "Модули ОЗУ типа" + " " + this.Modul1);//10 индекс 1 листа
//вывод логотипа фирмы
Graphity(q);
//отзывы фирмы
    z.Clear(); z.Text += String.Format(h1);//1 отзыв
    z.Text += String.Format(h2);//2 отзыв
}
}
public void Clock(ListBox v)//метод, использующийся для выбора фирмы, продающей компоненты компьютера, в 3 окне:корзине товаров
{
    v.Items.Clear();//очистить 1 лист
      v.Items.Insert(0, "Жесткий диск модели" + " " + this.Harddrive1); 
   v.Items.Insert(1, "Видеокарта модели" + " " + this.Videocard1); 
v.Items.Insert(2, "Материнская плата модели" + " " + this.MotherBoard1);
 v.Items.Insert(3, "Сетевой адаптер модели" + " " + this.Networkdapter1);
v.Items.Insert(4, "Блок питания модели" + " " + this.Powersupply1);
v.Items.Insert(5, "Дисковод модели" + " " + this.Floppydrive1); 
 v.Items.Insert(6, "Системный блок модели" + " " + this.Systemunit1);
  v.Items.Insert(7, "Монитор модели" + " " + this.Monitor1); 
 v.Items.Insert(8, "Звуковой адаптер модели" + " " + this.Soundadapter1); 
v.Items.Insert(9, "Модули ОЗУ типа" + " " + this.Modul1);
}
public void Click3(ListBox v, ListBox v1)//метод, использующийся для вывода цены компонентов компьютера
 {
if (v.SelectedIndex == 0)//если выбран 1 элемент списка в 1 списке
{ v1.Items.Clear();//очистить 2 список
  v1.Items.Insert(0, Harddrive);//добавить во 2 список 1 элемент-свойство Harddrive(цену на жесткий диск)
}
if (v.SelectedIndex == 1)//если выбран 2 элемент списка
  { v1.Items.Clear(); //очистить 2 список
  v1.Items.Insert(0, Videocard);//добавить во 2 список 2 элемент-свойство Videocard(модель видеокарты)
}
if (v.SelectedIndex == 2)//если выбран 3 элемент списка
 { v1.Items.Clear(); 
 v1.Items.Insert(0, MotherBoard);
}
if (v.SelectedIndex == 3)//если выбран 4 элемент списка
  { v1.Items.Clear();
 v1.Items.Insert(0, Networkdapter);
}
if (v.SelectedIndex == 4)//если выбран 5 элемент списка
  { v1.Items.Clear(); 
    v1.Items.Insert(0, Powersupply);
}
if (v.SelectedIndex == 5)//если выбран 6 элемент списка
{
    v1.Items.Clear();
   v1.Items.Insert(0, Floppydrive);
}
if (v.SelectedIndex == 6)//если выбран 7 элемент списка
 { v1.Items.Clear();
   v1.Items.Insert(0, Systemunit);
}
if (v.SelectedIndex == 7)//если выбран 8 элемент списка
  { v1.Items.Clear(); 
    v1.Items.Insert(0, Monitor);
}
if (v.SelectedIndex == 8)//если выбран 9 элемент списка
  { v1.Items.Clear(); 
    v1.Items.Insert(0, Soundadapter);
}
if (v.SelectedIndex == 9)//если выбран 10 элемент списка
  { v1.Items.Clear(); 
    v1.Items.Insert(0, Modul);
}
}
public int Click4(List<int> Price31)//метод для определения цены стоимости компонентов компьютера
  {
Price31.Insert(0, Harddrive);//в 1 элемент коллекции вводится свойство Harddrive(цена жесткого диска)
Price31.Insert(1, Videocard);
Price31.Insert(2, MotherBoard);
Price31.Insert(3, Networkdapter);
Price31.Insert(4, Powersupply);
Price31.Insert(5, Floppydrive);
Price31.Insert(6, Systemunit);
Price31.Insert(7, Monitor);
Price31.Insert(8, Soundadapter);
Price31.Insert(9, Modul);
this.Comp = Price31;//пустая коллекция Comp заполняется коллекцией, содержащей цену компонентов компьютера-Price31
return Convert.ToInt32(Comp.Sum());//вывод стоимости всех компонентов компьютера путем сложения стоимости каждого компонента компьютера
  }
public void Distribution(TextBox z, RadioButton c)//метод, использующийся для выведения общей суммы компонентов
 {
if (c.Checked)//если выбрана фирма
    {
    if (z.Text == " ")//если текстовый блок пустой
        z.Text = Convert.ToString(Click4(this.Comp));//в текстовый блок выводится сумма компонентов компьютера
    else
    {
        z.Clear();//текстовый блок очищается
        z.Text = Convert.ToString(Click4(this.Comp));
    }
}
}
public virtual void Button()//метод, использующийся для фиксирования события и дальнейшего переопределения
  {
Four.Invoke($"Вы выбрали фирму,продающую компоненты компьютера, и можете перейти на страницу с корзиной товаров.Чтобы определиться с фирмой, занимающейся сборкой компьютера перейдите на 5 страницу");
}
public void Button1()//метод, использующийся для фиксирования события
  {
Four.Invoke($"Извините,вы не выбрали фирму,продающую компоненты компьютера и не можете перейти на страницу с корзиной товаров");
}
public void Graphity(PictureBox b2)//метод, использующийся для выведения логотипа фирмы
{
    Graphics g1 = Graphics.FromHwnd(b2.Handle);
    g1.DrawImage(Image.FromFile(this.Fim), new Rectangle(0, 0, b2.Width, b2.Height));
}
}
public interface IModification//ИНТЕРФЕЙС для реализации 4 окна
  { void Click2(RadioButton c, ListBox v, RichTextBox z, PictureBox q, TextBox z1, string h1, string h2);//метод, использующийся для выведения характеристик фирмы по сборке компьютера
  void Click3(ListBox v, ListBox v1);//метод, использующийся для вывода общей стоимости сборки компьютера
 void Distribution(TextBox z,RadioButton c);//метод,использующийся для выведения информации о стоимости компонентов
  }
public class WorkCompany : New, IComputer//РЕАЛИЗАЦИЯ 5 ОКНА:ВЫБОР ФИРМЫ,ОСУЩЕСТВЛЯЮЩЕЙ СБОРКУ КОМПЬЮТЕРА., ПРИМЕНЕНИЕ АБСТРАКТНОГО КЛАССА И ИНТЕРФЕЙСА
{
    //событие
    public delegate void WorkCompanyHandler(string message);
    public event WorkCompanyHandler Five;
    public string Fot { get; set; }//свойство, показывающее путь к изображению, которое нужно вывести
    public List<string> Camp = new List<string>();//коллекция типа string
    public WorkCompany() { }//пустой конструктор
    public WorkCompany(string forma) { Forma = forma; }
    //конструктор для определения характеристик фирмы
    public WorkCompany(int experience, int quantity, int positive, int denial, int time, string forma, string fot) : base(experience, quantity, positive, denial, time, forma) { Fot = fot; }
    public override void Click2(RadioButton c, ListBox v, RichTextBox z, RichTextBox z2, PictureBox q, string h1, string h2, string h3, string
    h4)//метод,использующийся для вывода характеристик фирмы
    {
        if (c.Checked)//если выбрана фирма
        { v.Items.Clear();//1 список очищается
       v.Items.Insert(0, "Средний стаж сотрудников:" + this.Experience + " " + "лет");//1 индекс списка-Средний стаж сотрудников + свойство Experience(опыт работников) + лет 
       v.Items.Insert(1, "Общее количество сотрудников:" + this.Quantity + " " + "человек");//2 индекс списка
      v.Items.Insert(2, "Количество положительных отзывов:" + this.Positive);//3 индекс списка
      v.Items.Insert(3, "Количество отрицательных отзывов:" + this.Denial);//4 индекс списка
    v.Items.Insert(4, "Время работы фирмы на рынке" + this.Time + " " + "лет");//5 индекс списка
      v.Items.Insert(5, "Форма организации:" + this.Forma);//6 индекс списка
      //вывод логотипа фирмы
      Graphity(q);
      //отзывы фирмы
        z.Clear();//очищается richTextBox перед введением дополнительной информации
        z.Text += String.Format(h1);//1 отзыв фирмы
        z.Text += String.Format(h2);//2 отзыв фирмы
        z.Text += String.Format(h3);//3 отзыв фирмы
        z.Text += String.Format(h4);//4 отзыв фирмы
    }
}
public void Click8(ListBox v)//метод, использующийся для заполнения коллекции характеристиками фирмы в 3 окне:корзина товаров
{
    v.Items.Clear();//очистить список перед добавлением характеристик фирмы
    v.Items.Insert(0, "Средний стаж сотрудников:" + this.Experience + " " + "лет"); 
    v.Items.Insert(1, "Общее количество сотрудников:" + this.Quantity + " " + "человек"); 
    v.Items.Insert(2, "Количество положительных отзывов:" + this.Positive);
 v.Items.Insert(3, "Количество отрицательных отзывов:" + this.Denial);
  v.Items.Insert(4, "Время работы фирмы на рынке" + this.Time + " " + "лет"); 
   v.Items.Insert(5, "Форма организации:" + this.Forma);
}
public void Graphity(PictureBox b3)//метод,использующийся для выведения логотипа фирмы через picturebox
{
    Graphics g = Graphics.FromHwnd(b3.Handle);
    g.DrawImage(Image.FromFile(this.Fot), new Rectangle(0, 0, b3.Width, b3.Height));
}
public override void Button1()//метод, использующийся для фиксации события
   {
Five.Invoke($"Извините, вы не выбрали фирму, собирающую компоненты компьютера и не можете перейти на страницу с корзиной товаров");
}
public override void Button()//метод, использующийся для фиксации события
   {
Five.Invoke($"Вы выбрали фирму,организующую сборку компьютера, и можете перейти на страницу с корзиной товаров.Чтобы определиться с фирмой, занимающейся доставкой готово компьютера перейдите на 6 страницу ");
}
public override void Distribution(TextBox z, RadioButton c, int sum)//метод,использующийся для выведения информации о стоимости услуг фирмы по сборке компьютеров
   {
if (c.Checked)//если выбрана фирма
  {
if (z.Text == " ")//если блок пустой
    z.Text = Convert.ToString(sum);//вывод цены, соответствующей требованиям фирмы
else
{
    z.Clear();//очистить текстовый блок перед добавлением цены на услуги фирмы
    z.Text = Convert.ToString(sum);
}
}
}
}
public class DeliveryComponent : New//РЕАЛИЗАЦИЯ 6 ОКНА:ВЫБОР ФИРМЫ,ЗАНИМАЮЩЕЙСЯ ДОСТАВКОЙ КОМПЬЮТЕРА, ПРИМЕНЕНИЕ АБСТРАКТНОГО КЛАССА
{
    //событие
    public delegate void DeliveryComponentHandler(string message);
    public event DeliveryComponentHandler Six;
    public DeliveryComponent(string ret) : base() { Return = ret; }//конструктор для использования отношения КОМПОЗИЦИЯ
    public Menus Menus { get => default; set { } }//АССОЦИАЦИЯ,свойство, использующееся для выведения QR-кода фирмы
    public string Fok { get; set; }//свойство, использующееся для выведения изображения
    public int Guarantee { get; set; }//свойство, использующееся для инициализации гарантии перевозки
    public string Return { get; set; }//свойство, использующееся для выведения возврата стоимости в случае порчи целостности  компьютера при перевозке
    public int Partner { get; set; }//свойство, использующееся для выведения количества партнеров фирмы
    public int City { get; set; }//свойство, использующееся для выведения количества городов для доставки
    public int Office { get; set; } //свойство, использующееся для выведения количества офисов фирмы
    public string Phone { get; set; }//свойство, использующееся для выведения телефона фирмы
    public int OneWay { get; set; }//свойство, использующееся для выведения цены фирмы за 1 способ перевозки-доставка до двери
    public int TwoWay { get; set; }//свойство, использующееся для выведения цены фирмы за 2 способ перевозки-доставка по городу
    public int ThreeWay { get; set; }//свойство, использующееся для выведения цены фирмы за 3 способ перевозки-доставка по стране
   public int FourWay { get; set; }//свойство, использующееся для выведения цены за 4 способ перевозки-доставка по миру
    //конструктор для определения способа перевозки компонентов компьютера и описания характеристик фирмы
    public DeliveryComponent(int experience, int quantity, int positive, int denial, int time, string forma, int guarantee, string ret, int partner, int city, int office, string phone, int oneway, int twoway, int threeway, int fourway, string fok)
    : base(experience, quantity, positive, denial, time, forma)
    {
        Guarantee = guarantee; Return = ret; Partner = partner; City = city; Office =
office; Phone = phone; OneWay = oneway; TwoWay = twoway; ThreeWay = threeway; FourWay = fourway; Fok = fok;
    }
    public DeliveryComponent() { }//пустой конструктор
    public override void Click2(RadioButton c, ListBox v, RichTextBox z, RichTextBox z2, PictureBox q, string h1, string h2, string h3, string
    h4)
  //метод для выведения характеристик фирмы,занимающейся доставкой компьютера
  {
if (c.Checked)//если выбрана фирма
 { v.Items.Clear();//1 список очищается
   v.Items.Insert(0, "Доставка до двери:" + this.OneWay + " " + "руб");//1 индекс списка-Доставка до двери+свойство Oneway(цена за 1 способ доставки)+руб
v.Items.Insert(1, "Доставка по городу:" + this.TwoWay + " " + "руб");//2 индекс списка
v.Items.Insert(2, "Доставка по стране:" + this.ThreeWay + " " + "руб");//3 индекс списка
v.Items.Insert(3, "Доставка по миру:" + this.FourWay + " " + "руб");//4 индекс списка
//вывод логотипа фирмы
Graphity(q);
 //отзывы фирмы
    z.Clear();//очищается richTextBox для введения отзывов
z.Text += String.Format(h1);//1 отзвы
z.Text += String.Format(h2);//2 отзыв
z.Text += String.Format(h3);//3 отзыв
z.Text += String.Format(h4);//4 отзыв
//метод для выведения информации о фирме,организующей доставку компонентов компьютера
Information(z2);
}
}
public void Click9(ListBox v)//для заполнения коллекции характеристиками фирмы в окне 3:корзина товаров
  { v.Items.Clear(); v.Items.Insert(0, "Доставка до двери:" + this.OneWay + " " + "руб"); v.Items.Insert(1, "Доставка по городу:" + this.TwoWay + " " + "руб"); v.Items.Insert(2, "Доставка по стране:" + this.ThreeWay + " " + "руб"); v.Items.Insert(3, "Доставка по миру:" + this.FourWay + " " + "руб");
}
public void CityChance(ComboBox combo, string one, string two, string three, string four)//метод, использующийся для заполнения списка comboBox названиями городов
  {
combo.Items.Insert(0, one);//1 индекс списка-название 1 города
combo.Items.Insert(1, two);//2 индекс списка-название 2 города
combo.Items.Insert(2, three);//3 индекс списка-название 3 города
combo.Items.Insert(3, four);//4 индекс списка-название 4 города
 }
public void Fon(ComboBox combo, RadioButton c)//метод, применяющийся для фиксации события
{
if (c.Checked && combo.Items.Count == 0)//если выбрана фирма,но не выбран город доставки
{
    Six.Invoke($"Извините,вы не выбрали город доставки!");
}
}
//метод, использующийся для определения цены доставки в зависимости от города
public void Click7(ListBox v1,RadioButton c,ListBox v,TextBox m,ComboBox combo,int sum,int sum1,int sum2,int sum3,int com,int com1,int com2,int com3,int fin,int fin1,int fin2,int fin3,int g,int g1,int g2,int g3)
{
    //1 город
    if (v.SelectedIndex == 0 && combo.SelectedIndex == 0)//если выбрана 1 доставка в 1 списке и выбран 1 город
    {
        v1.Items.Clear();//очистить лист до заполнения в него цен за доставку
        v1.Items.Insert(0, sum);//1 индекс 2 списка-цена за доставку к двери
       Distribution(m, c, sum);//метод,использующийся для выведения общей сумма покупки:цена доставки
    }
    if (v.SelectedIndex == 1 && combo.SelectedIndex == 0)//если выбрана 2 доставка в 1 списке и выбран 1 город
    {
        v1.Items.Clear();//список 2 очищается
        v1.Items.Insert(0, sum1);//1 индекс 2 списка-цена за доставку по городу
        Distribution(m, c, sum1);//метод, использующийся для выведения общей суммы покупки:цена доставки
    }
    if (v.SelectedIndex == 2 && combo.SelectedIndex == 0)//если выбрана 3 доставка в 1 списке и выбран 1 город
    {
        v1.Items.Clear();//список 2 очищается
        v1.Items.Insert(0,sum2);//1 индекс 2 списка-цена за доставку по стране
        Distribution(m, c, sum2);//метод, использующийся для выведения общей суммы покупки:цена доставки
    }
    if (v.SelectedIndex == 3 && combo.SelectedIndex == 0)//если выбрана 4 доставка в 1 списке и выбран 1 город
    {
        v1.Items.Clear();//список 2 очищается
        v1.Items.Insert(0,sum3);//1 индекс 2 списка-цена за доставку по миру
        Distribution(m, c, sum3);//метод, использующийся для выведения общей суммы покупки:цена доставки
    }
    //2 город
    if (v.SelectedIndex == 0 && combo.SelectedIndex == 1)//если выбрана 1 доставка в 1 списке и выбран 2 город
    {
        v1.Items.Clear(); 
        v1.Items.Insert(0, com);//1 индекс 2 списка-цена за доставку к двери
        Distribution(m, c, com);
    }
    if (v.SelectedIndex == 1 && combo.SelectedIndex == 1)//если выбрана 2 доставка в 1 списке и выбран 2 город
    {
        v1.Items.Clear();
        v1.Items.Insert(0, com1);//1 индекс 2 списка-цена за доставку по городу
        Distribution(m, c, com1);
    }
    if (v.SelectedIndex == 2 && combo.SelectedIndex == 1)//если выбрана 3 доставка в 1 списке и выбран 2 город
    {
        v1.Items.Clear(); 
        v1.Items.Insert(0, com2);//1 индекс 2 списка-цена за доставку по стране
        Distribution(m, c, com2);
    }
    if (v.SelectedIndex == 3 && combo.SelectedIndex == 1)//если выбрана 4 доставка в 1 списке и выбран 2 город
    {
        v1.Items.Clear();
        v1.Items.Insert(0, com3);//1 индекс 2 списка-цена за доставку по миру
        Distribution(m, c, com3);
    }
    //3 город
    if (v.SelectedIndex == 0 && combo.SelectedIndex == 2)//если выбрана 1 доставка в 1 списке и выбран 3 город
    {
        v1.Items.Clear();
        v1.Items.Insert(0, fin);//1 индекс 2 списка-цена за доставку к двери
        Distribution(m, c, fin);
    }
    if (v.SelectedIndex == 1 && combo.SelectedIndex == 2)//если выбрана 2 доставка в 1 списке и выбран 3 город
    {
        v1.Items.Clear(); 
       v1.Items.Insert(0, fin1);//1 индекс 2 списка-цена за доставку по городу
        Distribution(m, c, fin1);
    }
    if (v.SelectedIndex == 2 && combo.SelectedIndex == 2)//если выбрана 3 доставка в 1 списке и выбран 3 город
    {
        v1.Items.Clear(); 
        v1.Items.Insert(0, fin2);//1 индекс 2 списка-цена за доставку по стране
        Distribution(m, c, fin2);
    }
    if (v.SelectedIndex == 3 && combo.SelectedIndex == 2)//если выбрана 4 доставка в 1 списке и выбран 3 город
    {
        v1.Items.Clear(); 
        v1.Items.Insert(0, fin3);//1 индекс 2 списка-цена за доставку по миру
        Distribution(m, c, fin3);
    }
    //4 город
    if (v.SelectedIndex == 0 && combo.SelectedIndex == 3)//если выбрана 1 доставка в 1 списке и выбран 4 город
    {
        v1.Items.Clear();
        v1.Items.Insert(0, g);//1 индекс 2 списка-цена за доставку к двери
        Distribution(m, c, g);
    }
    if (v.SelectedIndex == 1 && combo.SelectedIndex == 3)//если выбрана 2 доставка в 1 списке и выбран 4 город
    {
        v1.Items.Clear(); 
        v1.Items.Insert(0, g1);//1 индекс 2 списка-цена за доставку по городу
        Distribution(m, c, g1);
    }
    if (v.SelectedIndex == 2 && combo.SelectedIndex == 3)//если выбрана 3 доставка в 1 списке и выбран 4 город
    {
        v1.Items.Clear(); 
        v1.Items.Insert(0, g2);//1 индекс 2 списка-цена за доставку по миру
        Distribution(m, c, g2);
    }
    if (v.SelectedIndex == 3 && combo.SelectedIndex == 3)//если выбрана 4 доставка в 1 списке и выбран 4 город
    {
        v1.Items.Clear();
        v1.Items.Insert(0, g2);//1 индекс 2 списка-цена за доставку по миру
        Distribution(m, c, g3);
    }
}
public void Graphity(PictureBox e)//метод, использующийся для выведения логтипа фирмы
{
    Graphics g = Graphics.FromHwnd(e.Handle);
    g.DrawImage(Image.FromFile(this.Fok), new Rectangle(0, 0, e.Width, e.Height));
}
public override void Distribution(TextBox z, RadioButton c, int sum)//метод, использующийся для выведения стоимости услуги
{
    if (c.Checked)//если выбрана фирма
      {
        if (z.Text == " ")//если текстовый блок пустой
            z.Text = Convert.ToString(sum);//в текстовый блок выводится общая стоимость услуг фирмы
}
else
{
    z.Clear();//очистить текстовый блок
    z.Text = Convert.ToString(sum);
}
}
public virtual void Information(RichTextBox q)//метод с выведением информации о фирме-поставщике
  {
q.Clear();
q.Text += String.Format("Стаж работников: {0}", this.Experience);
q.Text += String.Format("Количество работников: {0}", this.Quantity);
q.Text += String.Format("Количество положительных отзывов: {0}", this.Positive);
q.Text += String.Format("Количество отрицательных отзывов: {0}", this.Denial);
q.Text += String.Format("Время работы:{0}", this.Time);
q.Text += String.Format("Форма организации: {0}", this.Forma);
q.Text += String.Format("Гарантия: {0} месяцев", this.Guarantee);
q.Text += String.Format("Возврат стоимости в случае нарушения целостности товара:{0}", this.Return);
q.Text += String.Format("QR-код фирмы:{0}", this.Menus);
q.Text += String.Format("Количество партнеров: {0}", this.Partner);
q.Text += String.Format("Количество городов для доставки: {0}", this.City);
q.Text += String.Format("Количество офисов: {0}", this.Office);
q.Text += String.Format("Телефон: {0}", this.Phone);
}
public override void Button1()//метод с фиксацией события
  {
Six.Invoke($"Вы выбрали фирму,организующую доставку компонентов компьютера, и можете перейти на страницу с корзиной товаров");
}
public override void Button()//метод с фиксацией события
 {
Six.Invoke($"Извините, вы не выбрали фирму, организующую доставку компонентов компьютера, и не можете перейти на страницу с корзиной товаров");
}
}
}

