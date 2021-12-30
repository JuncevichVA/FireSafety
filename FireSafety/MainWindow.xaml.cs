using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.Entity;


namespace FireSafety
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FireSafetyEntities db; //Инициализация БД
        public List<Grafic1> Chardata; // Инициализация  графика
        public FPO fpo = new FPO(); // объект класса
        Object obj = new Object();// объект класса
        Object_values obj_v = new Object_values();// объект класса
        OFP_Limit_Values lim = new OFP_Limit_Values();// объект класса
        Start_Conditions s = new Start_Conditions();// объект класса


        public MainWindow()
        {
            InitializeComponent();
            db = new FireSafetyEntities();
            //загружаем данные о классах
            db.FPO_0_Klas.Load();
            db.FPO_1_Klas.Load();
            db.FPO_2_Klas.Load();
            db.FPO_3_Klas.Load();
            db.FPO_4_Klas.Load();
            db.FPO_5_Klas.Load();
            db.OFP_Limit_Values.Load();
            db.Start_Conditions.Load();
            db.Objects.Load();

            //Для работы с Combobox
            Cb1_3.DisplayMemberPath = "Room_Func";
            Cb1_3.SelectedValuePath = "Id_FPO_1";

            Cb2_3.DisplayMemberPath = "Room_Func";
            Cb2_3.SelectedValuePath = "Id_FPO_2";

            Cb3_3.DisplayMemberPath = "Room_Func";
            Cb3_3.SelectedValuePath = "Id_FPO_3";

            Cb4_3.DisplayMemberPath = "Room_Func";
            Cb4_3.SelectedValuePath = "Id_FPO_4";

            Cb5_3.DisplayMemberPath = "Room_Func";
            Cb5_3.SelectedValuePath = "Id_FPO_5";

            Cb6_3.DisplayMemberPath = "Room_Func";
            Cb6_3.SelectedValuePath = "Id_FPO_0";


            Cb1_4.DisplayMemberPath = "Temperature";
            Cb1_4.SelectedValuePath = "Id_Limit";

            Cb1_4.ItemsSource = db.OFP_Limit_Values.Local.ToBindingList();// устанавливаем привязку к Combobox 
            Cb1_4.SelectionChanged += Link_Edit_Combobox7;
            Dg1_4.ItemsSource = db.OFP_Limit_Values.Local.ToBindingList();

            Dg_BD.ItemsSource = db.Objects.Local.ToBindingList();

        }


 
        double n; // показатель степени, учитывающий изменение массы выгорающего материала во времени; 
        double φ = 0.25; // коэффициент теплопотерь;
        double Al = 0.3; // коэффициент отражения предметов на путях эвакуации
        double lпр = 20; //предельная дальность видимости в дыму
        double h = 1.7; // высота рабочей зоны :
        double η=0.9; // коэффициент полноты сгорания


        //---------------------------------------------------------------------------------------//
        //---------------------------------------------------------------------------------------//
        //-------------------------работа с БД  добавление/удаление------------------------------//


        //---------------------------------------------------------------------------------------//
        //------------ШАГ №2 привязка данных через Combobox  к DataGrid-------------  -----------//

        private void Link_Edit_Combobox1(object sender, SelectionChangedEventArgs e)
        {
            var value = (sender as ComboBox);

            foreach (var a in db.FPO_1_Klas.Local.ToBindingList())
            {
                if (value.SelectedValue == null) { }
                else if ((int)value.SelectedValue == a.Id_FPO_1)
                {
                    fpo.room = a.Room_Func;
                    fpo.Q = a.Low_combustion;
                    fpo.v = a.Fire_Speed;
                    fpo.ψF = a.Burn_Speed;  
                    fpo.Dm = a.Generate_Smoke;
                    fpo.Lo2 = a.Сonsumption_O2;
                    fpo.Lco2 = a.Selection_СО2;
                    fpo.Lco = a.Selection_СО;
                    fpo.Lhcl = a.Selection_HCL;

                    Tbr_0.Text = fpo.room.ToString();
                    Tb1_3.Text = fpo.Q.ToString();
                    Tb2_3.Text = fpo.v.ToString();
                    Tb3_3.Text = fpo.ψF.ToString();
                    Tb5_3.Text = fpo.Dm.ToString();
                    Tb6_3.Text = fpo.Lo2.ToString();
                    Tb7_3.Text = fpo.Lco2.ToString();
                    Tb8_3.Text = fpo.Lco.ToString();
                    Tb9_3.Text = fpo.Lhcl.ToString();
                    
                }
            }

        }
        private void Link_Edit_Combobox2(object sender, SelectionChangedEventArgs e)
        {
            var value = (sender as ComboBox);

            foreach (var a in db.FPO_2_Klas.Local.ToBindingList())
            {
                if (value.SelectedValue == null) { }
                else if ((int)value.SelectedValue == a.Id_FPO_2)
                {
                    fpo.room = a.Room_Func;
                    fpo.Q = a.Low_combustion;
                    fpo.v = a.Fire_Speed;
                    fpo.ψF = a.Burn_Speed;
                    fpo.Dm = a.Generate_Smoke;
                    fpo.Lo2 = a.Сonsumption_O2;
                    fpo.Lco2 = a.Selection_СО2;
                    fpo.Lco = a.Selection_СО;
                    fpo.Lhcl = a.Selection_HCL;

                    Tbr_0.Text = fpo.room.ToString();
                    Tb1_3.Text = fpo.Q.ToString();
                    Tb2_3.Text = fpo.v.ToString();
                    Tb3_3.Text = fpo.ψF.ToString();
                    Tb5_3.Text = fpo.Dm.ToString();
                    Tb6_3.Text = fpo.Lo2.ToString();
                    Tb7_3.Text = fpo.Lco2.ToString();
                    Tb8_3.Text = fpo.Lco.ToString();
                    Tb9_3.Text = fpo.Lhcl.ToString();

                }
            }
        }
        private void Link_Edit_Combobox3(object sender, SelectionChangedEventArgs e)
        {
            var value = (sender as ComboBox);

            foreach (var a in db.FPO_3_Klas.Local.ToBindingList())
            {
                if (value.SelectedValue == null) { }
                else if ((int)value.SelectedValue == a.Id_FPO_3)
                {
                    fpo.room = a.Room_Func;
                    fpo.Q = a.Low_combustion;
                    fpo.v = a.Fire_Speed;
                    fpo.ψF = a.Burn_Speed;
                    fpo.Dm = a.Generate_Smoke;
                    fpo.Lo2 = a.Сonsumption_O2;
                    fpo.Lco2 = a.Selection_СО2;
                    fpo.Lco = a.Selection_СО;
                    fpo.Lhcl = a.Selection_HCL;

                    Tbr_0.Text = fpo.room.ToString();
                    Tb1_3.Text = fpo.Q.ToString();
                    Tb2_3.Text = fpo.v.ToString();
                    Tb3_3.Text = fpo.ψF.ToString();
                    Tb5_3.Text = fpo.Dm.ToString();
                    Tb6_3.Text = fpo.Lo2.ToString();
                    Tb7_3.Text = fpo.Lco2.ToString();
                    Tb8_3.Text = fpo.Lco.ToString();
                    Tb9_3.Text = fpo.Lhcl.ToString();

                }
            }
        }
        private void Link_Edit_Combobox4(object sender, SelectionChangedEventArgs e)
        {
            var value = (sender as ComboBox);

            foreach (var a in db.FPO_4_Klas.Local.ToBindingList())
            {
                if (value.SelectedValue == null) { }
                else if ((int)value.SelectedValue == a.Id_FPO_4)
                {
                    fpo.room = a.Room_Func;
                    fpo.Q = a.Low_combustion;
                    fpo.v = a.Fire_Speed;
                    fpo.ψF = a.Burn_Speed;
                    fpo.Dm = a.Generate_Smoke;
                    fpo.Lo2 = a.Сonsumption_O2;
                    fpo.Lco2 = a.Selection_СО2;
                    fpo.Lco = a.Selection_СО;
                    fpo.Lhcl = a.Selection_HCL;

                    Tbr_0.Text = fpo.room.ToString();
                    Tb1_3.Text = fpo.Q.ToString();
                    Tb2_3.Text = fpo.v.ToString();
                    Tb3_3.Text = fpo.ψF.ToString();
                    Tb5_3.Text = fpo.Dm.ToString();
                    Tb6_3.Text = fpo.Lo2.ToString();
                    Tb7_3.Text = fpo.Lco2.ToString();
                    Tb8_3.Text = fpo.Lco.ToString();
                    Tb9_3.Text = fpo.Lhcl.ToString();

                }
            }
        }
        private void Link_Edit_Combobox5(object sender, SelectionChangedEventArgs e)
        {
            var value = (sender as ComboBox);

            foreach (var a in db.FPO_5_Klas.Local.ToBindingList())
            {
                if (value.SelectedValue == null) { }
                else if ((int)value.SelectedValue == a.Id_FPO_5)
                {
                    fpo.room = a.Room_Func;
                    fpo.Q = a.Low_combustion;
                    fpo.v = a.Fire_Speed;
                    fpo.ψF = a.Burn_Speed;
                    fpo.Dm = a.Generate_Smoke;
                    fpo.Lo2 = a.Сonsumption_O2;
                    fpo.Lco2 = a.Selection_СО2;
                    fpo.Lco = a.Selection_СО;
                    fpo.Lhcl = a.Selection_HCL;

                    Tbr_0.Text = fpo.room.ToString();
                    Tb1_3.Text = fpo.Q.ToString();
                    Tb2_3.Text = fpo.v.ToString();
                    Tb3_3.Text = fpo.ψF.ToString();
                    Tb5_3.Text = fpo.Dm.ToString();
                    Tb6_3.Text = fpo.Lo2.ToString();
                    Tb7_3.Text = fpo.Lco2.ToString();
                    Tb8_3.Text = fpo.Lco.ToString();
                    Tb9_3.Text = fpo.Lhcl.ToString();


                }
            }
        }
        private void Link_Edit_Combobox6(object sender, SelectionChangedEventArgs e)
        {
            var value = (sender as ComboBox);

            foreach (var a in db.FPO_0_Klas.Local.ToBindingList())
            {
                if (value.SelectedValue == null) { }
                else if ((int)value.SelectedValue == a.Id_FPO_0)
                {
                    fpo.room = a.Room_Func;
                    fpo.Q = a.Low_combustion;
                    fpo.v = a.Fire_Speed;
                    fpo.ψF = a.Burn_Speed;
                    fpo.Dm = a.Generate_Smoke;
                    fpo.Lo2 = a.Сonsumption_O2;
                    fpo.Lco2 = a.Selection_СО2;
                    fpo.Lco = a.Selection_СО;
                    fpo.Lhcl = a.Selection_HCL;

                    Tbr_0.Text = fpo.room.ToString();
                    Tb1_3.Text = fpo.Q.ToString();
                    Tb2_3.Text = fpo.v.ToString();
                    Tb3_3.Text = fpo.ψF.ToString();
                    Tb5_3.Text = fpo.Dm.ToString();
                    Tb6_3.Text = fpo.Lo2.ToString();
                    Tb7_3.Text = fpo.Lco2.ToString();
                    Tb8_3.Text = fpo.Lco.ToString();
                    Tb9_3.Text = fpo.Lhcl.ToString();



                }
            }
        }  
        private void Link_Edit_Combobox7(object sender, SelectionChangedEventArgs e)


        {
            var value = (sender as ComboBox);

            foreach (var a in db.OFP_Limit_Values.Local.ToBindingList())
            {
                if (value.SelectedValue == null) { }
                else if ((int)value.SelectedValue == a.Id_Limit)
                {
                    lim.Temperature = a.Temperature;
                    lim.Oxygen_Density = a.Oxygen_Density;
                    lim.CO_Density = a.CO_Density;
                    lim.CO2_Density = a.CO2_Density;
                    lim.HCL_Density = a.HCL_Density;
                    lim.Optical_Density = a.Optical_Density;

                    Tb4_4.Text = lim.Temperature.ToString();
                    Tb5_4.Text = lim.Oxygen_Density.ToString();
                    Tb6_4.Text = lim.CO_Density.ToString();
                    Tb7_4.Text = lim.CO2_Density.ToString();
                    Tb8_4.Text = lim.HCL_Density.ToString();
                    Tb9_4.Text = lim.Optical_Density.ToString();
                }
            }
        }



        //---------------------------------------------------------------------------------------//
        //---------------------------------------------------------------------------------------//
        //-------------------------------------Меню программы------------------------------------//

        // Меню нажатия checkbox 

          //  создание объекта

        private void Start_step1_checkbox(object sender, RoutedEventArgs e) // инициализация
        {
            if ((bool)Cb_m1.IsChecked == true)
            {
                BD_rez.IsEnabled = false;// меню БД( активна )
                Cb_rez_bd.IsChecked = false;
                Step1.Visibility = Visibility.Visible;
                a0_1.Text = "";
                a1_1.Text = "1";
                b1_1.Text = "1";
                h1_1.Text = "1";
                E1_1.Text = "1";
                Ch2_1.IsChecked = false;
                Rb4_2.IsChecked = false;
                Rb5_2.IsChecked = false;
                Rb6_2.IsChecked = false;
                Rb7_2.IsChecked = false;
                Rb8_2.IsChecked = false;
                Rb9_2.IsChecked = false;
                Tb1_3.Text = "";
                Tb2_3.Text = "";
                Tb3_3.Text = "";
                Tb5_3.Text = "";
                Tb6_3.Text = "";
                Tb7_3.Text = "";
                Tb8_3.Text = "";
                Tb9_3.Text = "";
                Rb1_4.IsChecked = false;
                Rb2_4.IsChecked = false;
                Rb3_4.IsChecked = false;
                Tbr_18.Text = "";
                Tbr_17.Text = "";
                Tbr_16.Text = "";
                Tbr_16.Background = Brushes.White;
                otvet.BorderBrush = Brushes.Black;
                Save_BD.Visibility = Visibility.Collapsed;
                Last_menu.Background = Brushes.Silver;
                Ch1_4.IsChecked = false;

            }
        }
        private void Step1_collapsed(object sender, RoutedEventArgs e)
        {
            if ((bool)Cb_m1.IsChecked == false)
            {
                Step1.Visibility = Visibility.Collapsed;
                BD_rez.IsEnabled = true;// меню БД( активна )
            }
        }  // диактивация
        private void BD_rezult_checkbox(object sender, RoutedEventArgs e)
        {
            BD.Visibility = Visibility.Visible;
            add_BD.Visibility = Visibility.Collapsed;
        }
        private void Cb_rez_bd_collapsed(object sender, RoutedEventArgs e)
        {
            if ((bool)Cb_rez_bd.IsChecked == false)
            {
                BD.Visibility = Visibility.Collapsed;
                add_BD.Visibility = Visibility.Visible;


            }
        }  // диактивация




        //---------------------------------------------------------------------------------------//
        //------------------------ФОРМА ШАГА_1_Исходные данные о помещении ----------------------//
        //---------------------------------------------------------------------------------------//

        // шаг 1 привязка Value slidera к Editbox

        private void Slider_ValueChanged2(object sender, RoutedPropertyChangedEventArgs<double> e) //шаг 1
        {
            ((Slider)sender).SelectionEnd = e.NewValue;
        }
        private void Slider_ValueChanged3(object sender, RoutedPropertyChangedEventArgs<double> e)//шаг 1
        {
            ((Slider)sender).SelectionEnd = e.NewValue;
        }
        private void Slider_ValueChanged4(object sender, RoutedPropertyChangedEventArgs<double> e)//шаг 1
        {
            ((Slider)sender).SelectionEnd = e.NewValue;
        }
        private void Slider_ValueChanged1(object sender, RoutedPropertyChangedEventArgs<double> e)//шаг 1
        {
            ((Slider)sender).SelectionEnd = e.NewValue;
        }
        private void Slider_ValueChanged5(object sender, RoutedPropertyChangedEventArgs<double> e) //шаг 1
        {
            ((Slider)sender).SelectionEnd = e.NewValue;
        }
        private void Slider_ValueChanged6(object sender, RoutedPropertyChangedEventArgs<double> e) //шаг 1
        {
            ((Slider)sender).SelectionEnd = e.NewValue;
        }
        private void Slider_ValueChanged7(object sender, RoutedPropertyChangedEventArgs<double> e) //шаг 1
        {
            ((Slider)sender).SelectionEnd = e.NewValue;

        }
        private void Slider_ValueChanged8(object sender, RoutedPropertyChangedEventArgs<double> e) //шаг 1
        {
            ((Slider)sender).SelectionEnd = e.NewValue;
        }


        private void View_start_conditions(object sender, RoutedEventArgs e) // Шаг1 показать начальные условия 
        {
            if ((bool)Ch2_1.IsChecked == true)
            {
                Start_value.Visibility = Visibility.Visible;
                B1_1.Visibility = Visibility.Visible;
            }
        }
        private void Disview_start_conditions(object sender, RoutedEventArgs e) // Шаг1 спрятать начальные условия 
        {
            if ((bool)Ch2_1.IsChecked == false)
            {
                Start_value.Visibility = Visibility.Collapsed;
                B1_1.Visibility = Visibility.Collapsed;
            }

        }


        private void Сhange_start_conditions(object sender, RoutedEventArgs e)// Начальные условия окружающей среды в помещении
        {
            if ((bool)Rb1_1.IsChecked == true)
            {
                Sl5_1.IsEnabled = true;
                Sl6_1.IsEnabled = true;
                Sl7_1.IsEnabled = true;
                Sl8_1.IsEnabled = true;
            }

        }
        private void Fixed_start_conditions(object sender, RoutedEventArgs e)// Начальные условия окружающей среды в помещении
        {
            if ((bool)Rb1_1.IsChecked == false)
            {
                Sl5_1.IsEnabled = false;
                Sl6_1.IsEnabled = false;
                Sl7_1.IsEnabled = false;
                Sl8_1.IsEnabled = false;
                Tb1_1.Text = "1.2041";
                Tb2_1.Text = "20";
                Tb3_1.Text = "0.001168";
                Tb4_1.Text = "0.278";
            }
        }

        private void Rb2_1_Checked_1(object sender, RoutedEventArgs e)
        {

        }
        private void Rb2_1_Unchecked_1(object sender, RoutedEventArgs e)
        {


        }


        private void Step1_Menu(object sender, RoutedEventArgs e)  // переход от Шага 1 к меню
        {
            Step1.Visibility = Visibility.Collapsed; 
            Cb_m1.IsChecked = false; 
        }

        //  Определение геометрических характеристик помещения при нажатии на кнопку и переходим к ШАГУ_2

        
        private void Raschet_geometri_object(object sender, RoutedEventArgs e)  // ОТ шага 1 к шагу 2 (расчет параметров объекта)
        {
            double a = double.Parse(a1_1.Text.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture); // ширина
            double b = double.Parse(b1_1.Text.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture); //длина

            obj.Heihgt__object = double.Parse(h1_1.Text.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture); //высота
            s.Start_Ligting = double.Parse(E1_1.Text.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture); // Освещенность 

            obj.Adress_object1 = a0_1.Text;
         
            obj.Area_object = a * b; // площадь
            obj.Volume_object= obj.Area_object * h;
            obj.Volume_free_object = 0.8 * obj.Area_object * h; //свободный объем
            obj_v.Z = h / obj.Heihgt__object * Math.Exp(1.4 * h / obj.Heihgt__object);  // параметр неравномнрности распределения ОФП
 
            if (a == 0 ||b==0|| obj.Heihgt__object == 0|| η == 0 ) // проверка на заполнение полей данных
            {
                MessageBox.Show(" Параметры не могут быть равны 0 !!!");
            }

            else if (obj.Adress_object1 == "" || a1_1.Text == "" || b1_1.Text == "" || h1_1.Text=="" || E1_1.Text=="") // проверка на заполнение полей данных
            {
                MessageBox.Show(" Адрес объекта не указан !!!");
                a0_1.BorderBrush = Brushes.Red;
            }
            else
            {
                a0_1.BorderBrush = Brushes.White;
                Step1.Visibility = Visibility.Collapsed;  // панель ШАГ 1
                Step2.Visibility = Visibility.Visible;  // панель ШАГ 2
                ШАГ_2.IsEnabled = true;  // поле меню ШАГ 2
                ШАГ_1.IsEnabled = false;  // поле меню ШАГ 2
                ШАГ_1.IsChecked = true; // поле меню ШАГ 1
    
            }
        }

        //---------------------------------------------------------------------------------------//
        //--------------------------------------Конец ШАГА_1-------------------------------------//
        //---------------------------------------------------------------------------------------//




        //---------------------------------------------------------------------------------------//
        //--------------ФОРМА ШАГА_2_  Выберите класс функциональной пожарной опасности ---------//
        //---------------------------------------------------------------------------------------//


        // Привязка БД к ШАГУ_2 Выбор класса функциональной пожарной опасности

        // Определение класса ОФП
        
    
        private void Сhoice_FPO0(object sender, RoutedEventArgs e) //выбор класса пожарной нагрузки
        {

            Dg1_2_1.ItemsSource = db.FPO_0_Klas.Local.ToBindingList(); // Привязка БД к gridy
            Step2_1.Visibility = Visibility.Visible; // панель ШАГ 2_1
            Step2.Visibility = Visibility.Collapsed;
            obj.Room_Func_object = "Ф0";
        }



        private void Step2_Step1(object sender, RoutedEventArgs e)  // переход от Шага1 к шагу2
        {
            Step2.Visibility = Visibility.Collapsed;
            Step1.Visibility = Visibility.Visible;
            ШАГ_1.IsEnabled = true;  
        }



        //+++++++++++++++++++++++++++++++= Алгоритм определения класса ФПО+++++++++++++++++++++++++++++

        private void Algoritm_opredelenia_klass_FPO(object sender, RoutedEventArgs e) // переход от Шага2 к шагу3 
        {
            if ((bool)Rb4_2.IsChecked  == true) //ОФП1
            {
                Cb1_3.Visibility = Visibility.Visible;
                Cb1_3.ItemsSource = db.FPO_1_Klas.Local.ToBindingList();// устанавливаем привязку к кэшу при нажатии radio buton
                Cb1_3.SelectionChanged += Link_Edit_Combobox1;
                Dg1_2_1.ItemsSource = db.FPO_1_Klas.Local.ToBindingList();
                obj.Room_Func_object = "Ф1";

            }
            else if ((bool)Rb5_2.IsChecked   == true)  //ОФП2
            {
                Cb2_3.Visibility = Visibility.Visible;
                Cb2_3.ItemsSource = db.FPO_2_Klas.Local.ToBindingList();// устанавливаем привязку к кэшу при нажатии radio buton
                Cb2_3.SelectionChanged += Link_Edit_Combobox2;
                Dg1_2_1.ItemsSource = db.FPO_2_Klas.Local.ToBindingList();
                obj.Room_Func_object = "Ф2";

            }
            else if ((bool)Rb6_2.IsChecked == true)  //ОФП3
            {
                Cb3_3.Visibility = Visibility.Visible;
                Cb3_3.ItemsSource = db.FPO_3_Klas.Local.ToBindingList();// устанавливаем привязку к кэшу при нажатии radio buton
                Cb3_3.SelectionChanged += Link_Edit_Combobox3;
                Dg1_2_1.ItemsSource = db.FPO_3_Klas.Local.ToBindingList();
                obj.Room_Func_object = "Ф3";
            }
            else if ((bool)Rb7_2.IsChecked == true)  //ОФП4
            {
                Cb4_3.Visibility = Visibility.Visible;
                Cb4_3.ItemsSource = db.FPO_4_Klas.Local.ToBindingList();// устанавливаем привязку к кэшу при нажатии radio buton
                Cb4_3.SelectionChanged += Link_Edit_Combobox4;
                Dg1_2_1.ItemsSource = db.FPO_4_Klas.Local.ToBindingList();
                obj.Room_Func_object = "Ф4";
            }
            else if ((bool)Rb8_2.IsChecked == true)  //ОФП5
            {
                Cb5_3.Visibility = Visibility.Visible;
                Cb5_3.ItemsSource = db.FPO_5_Klas.Local.ToBindingList();// устанавливаем привязку к кэшу при нажатии radio buton
                Cb5_3.SelectionChanged += Link_Edit_Combobox5;
                Dg1_2_1.ItemsSource = db.FPO_5_Klas.Local.ToBindingList();
                obj.Room_Func_object = "Ф5";
            }
            else if ((bool)Rb9_2.IsChecked == true)  //ОФП0
            {
                Сhoice_FPO0(sender, e);
            }


            if (((bool)Rb4_2.IsChecked || (bool)Rb5_2.IsChecked || (bool)Rb6_2.IsChecked || (bool)Rb7_2.IsChecked || (bool)Rb8_2.IsChecked || (bool)Rb9_2.IsChecked) == false)
            {
                MessageBox.Show("Не выбран не один из классов !!!");
            }
            else
            {
                Step2.Visibility = Visibility.Collapsed; // панель ШАГ 2
                Step3.Visibility = Visibility.Visible;// панель ШАГ 3
                ШАГ_3.IsEnabled = true;// меню ШАГ 3 ( активна )
                ШАГ_2.IsChecked = true;// меню ШАГ (галочка на форме)
                Tb1_3.Text = "";
                Tb2_3.Text = "";
                Tb3_3.Text = "";
                Tb5_3.Text = "";
                Tb6_3.Text = "";
                Tb7_3.Text = "";
                Tb8_3.Text = "";
                Tb9_3.Text = "";

            }

        }


        //---------------------------------------------------------------------------------------//
        //--------------------------------------Конец ШАГА_2-------------------------------------//
        //---------------------------------------------------------------------------------------//




        //---------------------------------------------------------------------------------------//
        //---------------------------ФОРМА ШАГА_2_1  Редактирование БД---------------------------//
        //---------------------------------------------------------------------------------------//



        private void Slider_ValueChanged11(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = e.NewValue;
        } // Привязка slider
        private void Slider_ValueChanged12(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = e.NewValue;
        }
        private void Slider_ValueChanged13(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = e.NewValue;
        }
        private void Slider_ValueChanged14(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = e.NewValue;
        }
        private void Slider_ValueChanged15(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = e.NewValue;
        }
        private void Slider_ValueChanged16(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = e.NewValue;
        }
        private void Slider_ValueChanged17(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = e.NewValue;
        }
        private void Slider_ValueChanged18(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = e.NewValue;
        }


        // База данных

        private void StepBD_Step2(object sender, RoutedEventArgs e) // переход от ШагаBD к шагу2
        {
            Step2_1.Visibility = Visibility.Collapsed;
            Step2.Visibility = Visibility.Visible;
            Rb9_2.IsChecked = false;
        }
        private void StepBD_Step3(object sender, RoutedEventArgs e) // переход от ШагаBD к шагу3
        {
            Cb6_3.SelectionChanged += Link_Edit_Combobox6;
            Step2_1.Visibility = Visibility.Collapsed;
            Step3.Visibility = Visibility.Visible;

            Cb6_3.ItemsSource = db.FPO_0_Klas.Local.ToBindingList();// устанавливаем привязку к кэшу при нажатии radio buton
            Cb6_3.Visibility = Visibility.Visible;
            Cb1_3.Visibility = Visibility.Collapsed;
            Cb2_3.Visibility = Visibility.Collapsed;
            Cb3_3.Visibility = Visibility.Collapsed;
            Cb4_3.Visibility = Visibility.Collapsed;
            Cb5_3.Visibility = Visibility.Collapsed;

        }

        // работа с базой данных
        private void Delete_BD_FPO0(object sender, RoutedEventArgs e)
        {
            if (Dg1_2_1.SelectedItems.Count > 0)
            {
                for (int i = 0; i < Dg1_2_1.SelectedItems.Count; i++)
                {
                    MessageBoxResult result = MessageBox.Show("Удалить данные?", "Внимание",
         MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        // Closes the parent form.
                        MessageBox.Show("Объект удален");
                        if (Dg1_2_1.SelectedItems[i] is FPO_0_Klas a)
                        {
                            db.FPO_0_Klas.Remove(a);
                            db.SaveChanges();
                        }
                    }

                }

            }
            else MessageBox.Show("Для удаления выберите строку из списка!!! ");


        } // Удалмть из БД FPO_0
        private void Add_BD_FPO0(object sender, RoutedEventArgs e) // Добавить в БД FPO_0
        {

            if (Nagryzka.Text == "")
            {
                MessageBox.Show(" Имя нагрузки не указано !!!");
                Nagryzka.BorderBrush = Brushes.Red;
            }
            else
            {

                FPO_0_Klas a = new FPO_0_Klas();
                a.Room_Func = Nagryzka.Text;
                a.Low_combustion = double.Parse(Tb1_2_1.Text.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);  // радиус разлитого горючего
                a.Fire_Speed = double.Parse(Tb2_2_1.Text.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);  // радиус разлитого горючего
                a.Burn_Speed = double.Parse(Tb3_2_1.Text.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);  // радиус разлитого горючего
                a.Generate_Smoke = double.Parse(Tb5_2_1.Text.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);  // радиус разлитого горючего
                a.Сonsumption_O2 = double.Parse(Tb6_2_1.Text.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);  // радиус разлитого горючего
                a.Selection_СО2 = double.Parse(Tb7_2_1.Text.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);  // радиус разлитого горючего
                a.Selection_СО = double.Parse(Tb8_2_1.Text.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);  // радиус разлитого горючего
                a.Selection_HCL = double.Parse(Tb9_2_1.Text.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);  // радиус разлитого горючего

                db.FPO_0_Klas.Add(a);
                db.SaveChanges();
                Nagryzka.BorderBrush = Brushes.White;
                Nagryzka.Text = "";
                MessageBox.Show("Новый объект добавлен");


            }

        }


        //---------------------------------------------------------------------------------------//
        //--------------------------------------Конец ШАГА_2_1-----------------------------------//
        //---------------------------------------------------------------------------------------//

            

        //---------------------------------------------------------------------------------------//
        //--------------ФОРМА ШАГА_3_ Выберите типовую пожарную нагрузку из списка --------------//
        //---------------------------------------------------------------------------------------//


        private void Step3_Step2(object sender, RoutedEventArgs e)  // Перейти к ШАГУ_2
        {

            Step3.Visibility = Visibility.Collapsed;
            Step2.Visibility = Visibility.Visible;
            Rb9_2.IsChecked = false;
            Cb1_3.Visibility = Visibility.Collapsed;
            Cb2_3.Visibility = Visibility.Collapsed;
            Cb3_3.Visibility = Visibility.Collapsed;
            Cb4_3.Visibility = Visibility.Collapsed;
            Cb5_3.Visibility = Visibility.Collapsed;
            Cb6_3.Visibility = Visibility.Collapsed;
            Rb4_2.IsChecked = false;
            Rb5_2.IsChecked = false;
            Rb6_2.IsChecked = false;
            Rb7_2.IsChecked = false;
            Rb8_2.IsChecked = false;
            Rb9_2.IsChecked = false;
        }
        private void Step3_Step4(object sender, RoutedEventArgs e)  // Перейти к ШАГУ_4
        {

            if (Tb1_3.Text == "")
            {

                MessageBox.Show(" Выбирите пожарную нагрузку !!!");
            }

            else
            {
                Step3.Visibility = Visibility.Collapsed;
                Step4.Visibility = Visibility.Visible;
                ШАГ_4.IsEnabled = true;
                ШАГ_3.IsChecked = true;
            }

        }


        //---------------------------------------------------------------------------------------//
        //--------------------------------------Конец ШАГА_3-------------------------------------//
        //---------------------------------------------------------------------------------------//



        //---------------------------------------------------------------------------------------//
        //--------------ФОРМА ШАГА_4_ Выберите сценарий горения и введите необходимые данные ----//



        private void Scenari_bern_1(object sender, RoutedEventArgs e) //Горение жидкостей
        {
            Sp1_4.Visibility = Visibility.Visible;
        }
        private void Scenari_bern_2(object sender, RoutedEventArgs e) //Горение вертикальной или горизонтальной поверхности
        {
            Sp2_4.Visibility = Visibility.Visible;
        }
        private void Unfixed_scenari_1(object sender, RoutedEventArgs e)
        {
            Sp1_4.Visibility = Visibility.Collapsed;
            R1_4.Text = "0.1";
        }
        private void Unfixed_scenari_2(object sender, RoutedEventArgs e)
        {
            Sp2_4.Visibility = Visibility.Collapsed;
            R2_4.Text = "0.1";
        }


        private void Step4_Step3(object sender, RoutedEventArgs e) // перейти от шага 4 , к шагу 3
        {
            Step4.Visibility = Visibility.Collapsed;

            Step3.Visibility = Visibility.Visible;

            ШАГ_4.IsEnabled = true;
            ШАГ_3.IsChecked = true;
            // ШАГ_4.IsChecked = true;
        }



        //+++++++++++++++++++++++++++++++= Алгоритм определения сценария пожара +++++++++++++++++++++++++++++

        private void Algoritm_opredelenia_scenari_fire(object sender, RoutedEventArgs e)  // Алгоритм  определения алгоритма пожара
        {
           
         
            if (((bool)Rb3_4.IsChecked || (bool)Rb2_4.IsChecked || (bool)Rb1_4.IsChecked) == false)
            {
                MessageBox.Show("Не выбран сценарий пожара пожара !!!");
                Ch1_4.IsChecked = false;
            }

            else if ((bool)Ch1_4.IsChecked == true)
            {

                Gr1_4.Visibility = Visibility.Visible;
                Border_OFP.Visibility = Visibility.Visible;
                //Размерный параметр А, кг·с - 3, учитывающий удельную массовую скорость выгорания горючего материала и площадь пожара;

                double r = double.Parse(R1_4.Text.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);  // радиус разлитого горючего
                double b2 = double.Parse(R2_4.Text.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);  // перпендикулярный к направлению движения пламени размер зоны горения, м.
                double S2; // площадь разлитого топлива

                if ((bool)Rb1_4.IsChecked && (r > 0) == true) //Для горения легковоспламеняющихся и горючих жидкостей, разлитых на площади F:
                {
                    n = 1.0; // показатель  степени, учитывающий измененение массы
                    S2 = 3.141234 * Math.Pow(r, 2);
                    obj_v.A = S2 * fpo.ψF;
                    // Tb2_R.Text = string.Format(" {0:0.0000}", A);

                }
                else if ((bool)Rb2_4.IsChecked && (b2 > 0) == true) //Для вертикальной или горизонтальной поверхности горения в виде прямоугольника
                {
                    n = 2.0; // показатель  степени, учитывающий измененение массы
                    obj_v.A = fpo.ψF * fpo.v * b2;
                    // Tb2_R.Text = string.Format("{0:0.0000}", A);

                }
                else if ((bool)Rb3_4.IsChecked == true) // Для кругового распространения пламени по поверхности
                {
                    n = 3.0; // показатель  степени, учитывающий измененение массы
                             //А = 1,05 · ψF · v 
                    obj_v.A = 1.05 * fpo.ψF * Math.Pow(fpo.v, 2);
                    // Tb2_R.Text = string.Format(" {0:0.0000}", A);
                }

                Tbr_8.Text = string.Format(" {0:0.00e000}", obj_v.A);  // параметр A


            }


        }
        private void Disview_limit_conditions(object sender, RoutedEventArgs e) // Шаг1 спрятать начальные условия 
        {
            if ((bool)Ch1_4.IsChecked == false)
            {
                Gr1_4.Visibility = Visibility.Collapsed;
                B1_1.Visibility = Visibility.Collapsed;
            }

        }



        // +++++++++++++++++++++++++=Алгоритм определения критического времени пожара +++++++++++++++++++++++++++++++++++

        private void Algoritm_critical_Time(object sender, RoutedEventArgs e)  //перейти от шага 4 , к Результатам
        {
            Chardata = new List<Grafic1>();
            Tbr_18.Text = "";
            Tbr_17.Text = "";
            Tbr_16.Text = "";
            Tbr_16.Background = Brushes.White;
            otvet.BorderBrush = Brushes.Black;

            if (((bool)Rb3_4.IsChecked || (bool)Rb2_4.IsChecked || (bool)Rb1_4.IsChecked) == false)
            {
                MessageBox.Show("Не выбран сценарий пожара пожара !!!");
            }
            else if (Tb5_4.Text == "" || Tb6_4.Text == "" || Tb7_4.Text == "" || Tb8_4.Text == "" || Tb9_4.Text == "" || Ch1_4.IsChecked == false)
            {
                MessageBox.Show("Придельные значения ОФП не выбраны !!!");

            }

            else
            {

              //  Chardata = new List<Grafic1>();

                //Размерный комплекс В, кг, зависящий от теплоты сгорания горючего материала и свободного объема помещения, определяется по формуле: 
                //В = 353 · Ср · Vсвоб / ((1 – φ) · η · fpo.Q))

                s.Specific_Isobaric = double.Parse(Tb3_1.Text.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);

                obj_v.B = 353 * s.Specific_Isobaric * obj.Volume_free_object / ((1 - φ) * η * fpo.Q);

                Tbr_7.Text = string.Format("{0:0.00}", obj_v.B);


                // переменные для проверки условия если Log, является отрицательным числом, то ОФП не представляет опасности. 

                double L1; // по температуре
                double L2; // по дыму
                double L3; // по O2
                double L4; // по С0
                double L5; // по С02
                double L6; // по HCL


                // а) повышенной температуре

                // Критическая продолжительность пожара по повышенной температуре t крТ, с, определяется по формуле [5]: 

                // t_крТ = (B / A · ln(1 + (70 – t0) / ((273 + t0) · Z))1 / n.
                s.Start_Temperature = double.Parse(Tb2_1.Text.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);



                Tbr_5.Text = string.Format("{0:0.00}", obj.Volume_free_object);

                L1 = 1 + ((70 - s.Start_Temperature) / ((273 + s.Start_Temperature) * obj_v.Z));
                if (L1 >= 0)
                {
                    obj_v.T_крТ = Math.Pow(obj_v.B / obj_v.A * Math.Log(L1), 1.0 / n);
                    Tbr_9.Text = string.Format("{0:0.00}", obj_v.T_крТ);

                }
                else
                    Tbr_9.Text = string.Format("не опасно");

                // б) потере видимости
                //  Критическая продолжительность пожара по потере видимости  t крПВ

                //t крПВ = (B / A · ln(1 – V · ln((1, 05 · Al · Е) / (lпр · B · fpo.Dm · Z))-1)1 / n,   
                L2 = 1 / (1 - (obj.Volume_free_object * Math.Log(1.05 * Al * s.Start_Ligting) / (lпр * obj_v.B * fpo.Dm * obj_v.Z)));
                if (L2 >= 0)
                {
                    obj_v.T_крPV = Math.Pow(obj_v.B / obj_v.A * Math.Log(L2), 1.0 / n);
                    Tbr_10.Text = string.Format("{0:0.00}", obj_v.T_крPV);
                }

                else
                    Tbr_10.Text = string.Format("не опасно");

                // в) понижение кислорода

                // Критическая продолжительность пожара по пониженному содержанию кислорода(О2) t крО2, с
                //t крО2 = ((B / A · ln(1 - 0, 044 / ((В · LО2 / V + 0, 27) · Z))-1)1 / n, 

                L3 = 1 / (1 - (0.044 / (((obj_v.B * fpo.Lo2 / obj.Volume_free_object) + 0.27) * obj_v.Z)));
                if (L3 >= 0)
                {
                    obj_v.T_крO2 = Math.Pow(obj_v.B / obj_v.A * Math.Log(L3), 1.0 / n);
                    Tbr_11.Text = string.Format("{0:0.00}", obj_v.T_крO2);
                }
                else
                    Tbr_11.Text = string.Format("не опасно");


                // в) привышение содержание СO

                // Критическая продолжительность пожара по угарному газу(СО),  t крСО 

                // t крСО = ((B / A · ln(1 - V · X / (B · L · Z))-1)1 / n,   


                L4 = 1 / (1 - (obj.Volume_free_object * lim.CO_Density / (obj_v.B * fpo.Lco * obj_v.Z)));
                if (L4 >= 0)
                {
                    obj_v.T_крCO = Math.Pow(obj_v.B / obj_v.A * Math.Log(L4), 1.0 / n);
                    Tbr_12.Text = string.Format("{0:0.00}", obj_v.T_крCO);
                }
                else
                    Tbr_12.Text = string.Format("не опасно");


                // в) привышение содержание СO2

                // Критическая продолжительность пожара по углекислому газу(СО2), t крСО2

                //t_крСО2 = ((B / A · ln(1 - V · X / (B · L · Z))-1)1 / n,   

                L5 = 1 / (1 - (obj.Volume_free_object * lim.CO2_Density / (obj_v.B * fpo.Lco2 * obj_v.Z)));
                if (L5 >= 0)
                {
                    obj_v.T_крТCO2 = Math.Pow(obj_v.B / obj_v.A * Math.Log(L5), 1.0 / n);
                    Tbr_13.Text = string.Format("{0:0.00}", obj_v.T_крТCO2);
                }
                else
                    Tbr_13.Text = string.Format("не опасно");

                // в) привышение содержание HCl
                // Критическая продолжительность пожара по парам хлороводорода(HCl), t крHCl,  

                //t_крHCl = ((B / A · ln(1 - V · X / (B · L · Z))-1)1 /

                L6 = 1 / (1 - (obj.Volume_free_object * lim.HCL_Density / (obj_v.B * fpo.Lhcl * obj_v.Z)));
                if (L6 >= 0)
                {
                    obj_v.T_крHCL = Math.Pow(obj_v.B / obj_v.A * Math.Log(L6), 1.0 / n);
                    Tbr_14.Text = string.Format("{0:0.00}", obj_v.T_крHCL);
                }
                else
                    Tbr_14.Text = string.Format("не опасно");

                // создаем список  и находим  min

                //List<double> Critical = new List<double> { obj_v.T_крТ, obj_v.T_крPV, obj_v.T_крO2, obj_v.T_крCO, obj_v.T_крТCO2, obj_v.T_крHCL };

                List<double> Critical = new List<double> { L1, L2, L3, L4, L5, L6 };

                Critical.RemoveAll(item => item < 1);

                double T_кр_min = Critical[0];
                for (int i = 0; i < Critical.Count; ++i)
                {

                    if (Critical[i] < T_кр_min)
                    {
                        T_кр_min = Critical[i];
                    }
                }
                obj_v.T_кр = Math.Pow(obj_v.B / obj_v.A * Math.Log(T_кр_min), 1.0 / n);



                Tbr_15.Text = string.Format("{0:0.00}", obj_v.T_кр);


                Chardata = new List<Grafic1>()
            {
                new Grafic1 { Value = obj_v.T_крТ, Name = "t_крТ" },
                new Grafic1 { Value = obj_v.T_крPV, Name = "t_крПВ" },
                new Grafic1 { Value = obj_v.T_крO2, Name = "t_крО2" },
                new Grafic1 { Value = obj_v.T_крCO, Name = "t_крСО" },
                new Grafic1 { Value = obj_v.T_крТCO2,Name = "t_крСО2" },
                new Grafic1 { Value = obj_v.T_крHCL, Name ="t_крHCl" }

            };
                ChartOne.ItemsSource = Chardata;
                Tbr_1.Text = obj.Adress_object1; // адрес объекта
                Tbr_2.Text = obj.Room_Func_object; // класс
                Tbr_3.Text = string.Format("{0:0.00}", obj.Area_object);
                Tbr_4.Text = string.Format("{0:0.00}", obj.Volume_object);
                Tbr_5.Text = string.Format("{0:0.00}", obj.Volume_free_object);
                Tbr_6.Text = string.Format("{0:0.00}", obj_v.Z);


                Step4.Visibility = Visibility.Collapsed;
                Result.Visibility = Visibility.Visible;
                Drawing.Visibility = Visibility.Visible;

                ШАГ_5.IsEnabled = true;
                grafick.IsEnabled = true;
                ШАГ_4.IsChecked = true;
                ШАГ_5.IsChecked = true;
                grafick.IsChecked = true;
            }
        }





    private void Slider_ValueChanged9(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = e.NewValue;
        }
        private void Slider_ValueChanged10(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = e.NewValue;
        }


        //---------------------------------------------------------------------------------------//
        //--------------------------------------Конец ШАГА_4-------------------------------------//
        //---------------------------------------------------------------------------------------//



        //---------------------------------------------------------------------------------------//
        //-----------------------------------------Результат ------------------------------------//
        //---------------------------------------------------------------------------------------//


        private void Rezultat_Step4(object sender, RoutedEventArgs e) 
        {
            Result.Visibility = Visibility.Collapsed;

            Step4.Visibility = Visibility.Visible;
            Tbr_9.Text = "";
            Tbr_10.Text = "";
            Tbr_11.Text = "";
            Tbr_12.Text = "";
            Tbr_13.Text = "";
            Tbr_14.Text = "";

            ШАГ_4.IsEnabled = true;
            ШАГ_3.IsChecked = true;
            Ch1_4.IsChecked = false;
            BD.Visibility = Visibility.Collapsed;
            Save_BD.Visibility = Visibility.Collapsed;
            Last_menu.Background = Brushes.Silver;


            // ШАГ_4.IsChecked = true;

        }
        private void Resultat_Menu(object sender, RoutedEventArgs e)
        {
            Drawing.Visibility = Visibility.Collapsed;
            Result.Visibility = Visibility.Collapsed;
            BD.Visibility = Visibility.Collapsed;
            ШАГ_1.IsEnabled = true;
            ШАГ_1.IsChecked = false;
            ШАГ_2.IsEnabled = false;
            ШАГ_2.IsChecked = false;
            ШАГ_3.IsEnabled = false;
            ШАГ_3.IsChecked = false;
            ШАГ_4.IsEnabled = false;
            ШАГ_4.IsChecked = false;
            ШАГ_5.IsEnabled = false;
            ШАГ_5.IsChecked = false;
            grafick.IsEnabled = false;
            grafick.IsChecked = false;
            Cb_m1.IsChecked = false;
            a0_1.Text = "";
        }
        private void Open_BD(object sender, RoutedEventArgs e)
        {
            Drawing.Visibility = Visibility.Collapsed;
            BD.Visibility = Visibility.Visible;

        }
        private void Dg1_2_1_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }


        // Итоговая таблица

        private void Add_BD_Result(object sender, RoutedEventArgs e)
        {
           // Rezultat_Step4(sender, e);
            Object obj1 = new Object();

            obj1.Adress_object1 = Tbr_1.Text;
            obj1.Room_Func_object= Tbr_2.Text;
            obj1.Type_house = Tbr_0.Text;
            obj1.Area_object = obj.Area_object;
            obj1.Volume_object = obj.Volume_object;
            obj1.Volume_free_object = obj.Volume_free_object;
            obj1.Heihgt__object = obj.Heihgt__object;
            obj1.Z_object = Tbr_6.Text;
            obj1.B_object = Tbr_7.Text;
            obj1.A_object = Tbr_8.Text;
            obj1.t_крТ = Tbr_9.Text;
            obj1.t_крPV = Tbr_10.Text;
            obj1.t_крO2 = Tbr_11.Text;
            obj1.t_крТCO2 = Tbr_12.Text;
            obj1.t_крCO = Tbr_13.Text;
            obj1.t_крHCL = Tbr_14.Text;
            obj1.Сonclusion = Tbr_17.Text;
            obj1.t_кр = Tbr_15.Text;
            obj1.t_нб = Tbr_16.Text;

            db.Objects.Add(obj1);
            db.SaveChanges();
            MessageBox.Show("Новый объект добавлен");


        }       
        private void Delete_BD_Result(object sender, RoutedEventArgs e)
        {
            if (Dg_BD.SelectedItems.Count > 0)
            {
                for (int i = 0; i < Dg_BD.SelectedItems.Count; i++)
                {

                    MessageBoxResult result = MessageBox.Show("Удалить данные?", "Внимание",
         MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {

                        // Closes the parent form.
                        MessageBox.Show("Объект удален");
                        if (Dg_BD.SelectedItems[i] is Object a)
                        {
                            db.Objects.Remove(a);
                            db.SaveChanges();

                        }

                    }

                }
                  
            }
            else MessageBox.Show("Для удаления выберите строку из списка!!! ");

        }




        //+++++++++++++++++++++= Алгоритм определения опасности схемы развития пожара +++++++++++++++++++++++++++++==

        private void Algaritm__scheme_fire(object sender, RoutedEventArgs e)
        {
            double m;
            Save_BD.Visibility=Visibility.Visible;
            otvet.BorderBrush = Brushes.Red;
            Last_menu.Background = Brushes.GreenYellow;

            // расчет сгоревшего топлива
            m = obj_v.A * Math.Pow(obj_v.T_кр, n);

                if (m >= obj_v.B) //   сравненние сгоревшего топлива и всего топлива в помещении
            {
                Tbr_17.Text = string.Format("не опасна"); 
                Tbr_18.Text = string.Format("{0:0.000000000}", m);
                MessageBox.Show("Перейдите к ШАГУ 4, и выберите другой сценарий развития пожара, данная схема не опасна!!! ");
               

            }
            else // Происходит расчет необходимого времени 
            {
                Tbr_17.Text = string.Format("опасно");

                //  Итоговое значение необходимого времени эвакуации людей t нб, мин, определяется по формуле[5]: 

                //   t нб = 0,8 · t кр.

                Tbr_18.Text = string.Format("{0:0.000000000}", m);
                obj_v.T_нб = 0.8 * obj_v.T_кр;
                Tbr_16.Background = Brushes.LightGreen;
                Tbr_16.Text = string.Format("{0:0.00}", obj_v.T_нб);

            }
            

        }


        private void BD_Menu(object sender, RoutedEventArgs e)
        {
            BD.Visibility = Visibility.Collapsed;
            Cb_rez_bd.IsChecked = false;

        }

      
    }

    

    //--------------------------------------Конец РЕЗУЛЬТАТЫ---------------------------------//
    //---------------------------------------------------------------------------------------//
    //---------------------------------------------------------------------------------------//
    //--------------ФОРМА DROWING------------------------------------------------------------//

    

}


