using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework13
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Building building = new Building();
                Console.Write("Ведите адрес здания: ");
                building.Adress = Console.ReadLine();
                Console.Write("Ведите длину здания в метрах: ");
                building.Length = Convert.ToDouble(Console.ReadLine());
                Console.Write("Ведите ширину здания в метрах: ");
                building.Width = Convert.ToDouble(Console.ReadLine());
                Console.Write("Ведите высоту здания в метрах: ");
                building.Height = Convert.ToDouble(Console.ReadLine());
                
                MultiBuilding multibuilding = new MultiBuilding(building.Adress, building.Length, building.Height, building.Width);
                Console.Write("Ведите количество надземных этажей здания ");
                multibuilding.Floors = Convert.ToInt32(Console.ReadLine());
                multibuilding.GetPrint(building.Adress, building.Length, building.Height, building.Width);
            }
                catch (FormatException)
            {
                Console.WriteLine("Неверный формат ввода.");
                Console.ReadKey();
                return;
            }
        }
    }
    class Building
    {
        public string Adress { get; set; }
        private double length;
        private double width;
        private double height;
        #region
        public double Length
        {
            set
            {
                if (value >= 0)
                {
                    length = value;
                }
                else
                {
                    Console.WriteLine("Длина здания - расстояние между крайними ограждающими конструкциями здания в направлении длинной стороны ");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
            get
            {
                return length;
            }
        }
        public double Width
        {
            set
            {
                if (value >= 0)
                {
                    width = value;
                }
                else
                {
                    Console.WriteLine("Ширина здания - расстояние между крайними ограждающими конструкциями здания в направлении короткой стороны ");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
            get
            {
                return width;
            }
        }

        public double Height
        {
            set
            {
                if (value >= 0)
                {
                    height = value;
                }
                else
                {
                    Console.WriteLine("Высота здания - расстояние от поверхности проезда для пожарных машин " +
                        "до нижней границы открывающегося проема (окна) в наружной стене верхнего (жилого, офисного) " +
                        "этажа (не считая верхнего технического этажа.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
            get
            {
                return height;
            }
            #endregion
        }
        public Building(string Adress, double Length, double Width, double Height)
        {
            this.Adress = Adress;
            Length = length;
            Width = width;
            Height = height;
        }

        public Building()
        {
        }

        public void GetPrint(string Adress, double length, double width, double height)
        {
            Console.Write($"Здание по адресу {Adress} имеет высоту {height}м, длину {length}м и ширину {width}м.");
        }
    }
    sealed class MultiBuilding : Building
    {
        private int floors;

        public int Floors
        {
            set
            {
                if (value >= 0)
                {
                    floors = value;
                }
                else
                {
                    Console.WriteLine("Количество этажей не может быть отрицательным числом.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
            get
            {
                return floors;
            }
        }
        public MultiBuilding(string Adress, double Length, double Width, double Height)
        :base(Adress,Length,Width,Height)
        {
            Floors = floors;
        }
        public void GetPrint(string Adress, double length, double width, double height)
            {
            base.GetPrint(Adress, length, width, height);
        Console.Write($" Здание имеет {floors} этажей.");
        Console.ReadKey();
            }
    }
}
