using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа переводит в радианы угол, находящийся в диапазоне [0, 360].");
            Console.WriteLine("Угол задается градусами, минутами, секундами.");
            Console.WriteLine();

            ushort gradus = 0;
            byte min = 0;
            byte sec = 0;
            bool er;

            do
            {
                try
                {
                    Console.Write("Введите положительное целочисленное значение градусов в диапазоне [0, 360]: ");
                    ushort gradus1 = Convert.ToUInt16(Console.ReadLine());
                    er = false;
                    gradus = gradus1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                    er = true;
                }
            }
            while (er != false);
            Console.WriteLine();

            if (gradus != 360)
            {
                do
                {
                    try
                    {
                        Console.Write("Введите положительное целочисленное значение угловых минут в диапазоне [0, 60): ");
                        byte min1 = Convert.ToByte(Console.ReadLine());
                        er = false;
                        min = min1;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                        er = true;
                    }
                }
                while (er != false);
                Console.WriteLine();

                do
                {
                    try
                    {
                        Console.Write("Введите положительное целочисленное значение угловых секунд в диапазоне [0, 60): ");
                        byte sec1 = Convert.ToByte(Console.ReadLine());
                        er = false;
                        sec = sec1;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                        er = true;
                    }
                }
                while (er != false);
            }

            Angle angle = new Angle(gradus, min, sec);
            angle.ToRadians();
            Console.ReadKey();
        }
    }

    class Angle
    {
        ushort gradus;
        byte min;
        byte sec;

        public ushort Gradus
        {
            set
            {
                if (value > 360)
                {
                    Console.WriteLine();
                    Console.WriteLine("Значение градусов должно быть не более 360. Присвоено значение по умолчанию 359");
                    gradus = 359;
                }
                else
                {
                    gradus = value;
                }
            }
            get
            {
                return gradus;
            }
        }

        public byte Min
        {
            set
            {
                if (value > 59)
                {
                    Console.WriteLine();
                    Console.WriteLine("Значение минут должно быть не более 59. Присвоено значение по умолчанию 59");
                    min = 59;
                }
                else
                {
                    min = value;
                }
            }
            get
            {
                return min;
            }
        }

        public byte Sec
        {
            set
            {
                if (value > 59)
                {
                    Console.WriteLine();
                    Console.WriteLine("Значение секунд должно быть не более 59. Присвоено значение по умолчанию 59");
                    sec = 59;
                }
                else
                {
                    sec = value;
                }
            }
            get
            {
                return sec;
            }
        }

        public Angle()
        {
            gradus = 0;
            min = 0;
            sec = 0;
        }

        public Angle(ushort gradus)
        {
            Gradus = gradus;
            min = 0;
            sec = 0;
        }

        public Angle(ushort gradus, byte min)
        {
            Gradus = gradus;
            Min = min;
            sec = 0;
        }

        public Angle(ushort gradus, byte min, byte sec)
        {
            Gradus = gradus;
            Min = min;
            Sec = sec;
        }

        public void ToRadians()
        {
            double rad = Math.Round((Math.PI * gradus / 180 + Math.PI * min / 10800 + Math.PI * sec / 648000), 5);
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("Угол {0} градусов {1} минут {2} секунд = {3} радиан", gradus, min, sec, rad);
        }
    }
}


// Второй вариант программы.
//
// В этом варианте проверка вводимых значений проводится до передачи их в класс и, соответственно,
// в классе нет необходимости делать проверку свойств (допустимого диапазона, например), организованы только автосвойства.
//
// Мне кажется логичнее проводить проверку каждого вводимого параметра до передачи его в класс,
// иначе сначала вне класса проверяется Exception, а в классе - диапазон допустимых значений.
//
// А как организовать повторное введение параметра, если он, например, вне класса прошел проверку Exception, был передан в экземпляр класса,
// но в классе не прошел проверку диапазона допустимых значений, я не могу придумать ¯\_(ツ)_/¯
//
//
//
// 
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Task_10
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Программа переводит в радианы угол, находящийся в диапазоне [0, 360].");
//            Console.WriteLine("Угол задается градусами, минутами, секундами.");
//            Console.WriteLine();

//            ushort gradus = 0;
//            byte min = 0;
//            byte sec = 0;
//            bool er;

//            do
//            {
//                try
//                {
//                    Console.Write("Введите положительное целочисленное значение градусов в диапазоне [0, 360]: ");
//                    ushort gradus1 = Convert.ToUInt16(Console.ReadLine());
//                    er = false;
//                    gradus = gradus1;
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine(ex.Message);
//                    Console.WriteLine();
//                    er = true;
//                }
//                finally
//                {
//                    if (gradus > 360 || gradus < 0)
//                    {
//                        Console.WriteLine("Значение градусов должно быть в диапазоне [0, 360].");
//                        Console.WriteLine();
//                        gradus = 0;
//                        er = true;
//                    }
//                }
//            }
//            while (er != false);
//            Console.WriteLine();

//            if (gradus != 360)
//            {
//                do
//                {
//                    try
//                    {
//                        Console.Write("Введите положительное целочисленное значение угловых минут в диапазоне [0, 60): ");
//                        byte min1 = Convert.ToByte(Console.ReadLine());
//                        er = false;
//                        min = min1;
//                    }
//                    catch (Exception ex)
//                    {
//                        Console.WriteLine(ex.Message);
//                        Console.WriteLine();
//                        er = true;
//                    }
//                    finally
//                    {
//                        if (min > 59 || min < 0)
//                        {
//                            Console.WriteLine("Значение минут должно быть в диапазоне [0, 60).");
//                            Console.WriteLine();
//                            min = 0;
//                            er = true;
//                        }
//                    }
//                }
//                while (er != false);
//                Console.WriteLine();

//                do
//                {
//                    try
//                    {
//                        Console.Write("Введите положительное целочисленное значение угловых секунд в диапазоне [0, 60): ");
//                        byte sec1 = Convert.ToByte(Console.ReadLine());
//                        er = false;
//                        sec = sec1;
//                    }
//                    catch (Exception ex)
//                    {
//                        Console.WriteLine(ex.Message);
//                        Console.WriteLine();
//                        er = true;
//                    }
//                    finally
//                    {
//                        if (sec > 59 || sec < 0)
//                        {
//                            Console.WriteLine("Значение секунд должно быть в диапазоне [0, 60).");
//                            Console.WriteLine();
//                            sec = 0;
//                            er = true;
//                        }
//                    }
//                }
//                while (er != false);
//            }

//            Angle angle = new Angle(gradus, min, sec);
//            angle.ToRadians();
//            Console.ReadKey();
//        }
//    }
//    class Angle
//    {
//        public ushort gradus { get; set; }
//        public byte min { get; set; }
//        public byte sec { get; set; }


//        public Angle()
//        {
//            gradus = 0;
//            min = 0;
//            sec = 0;
//        }

//        public Angle(ushort gradus)
//        {
//            this.gradus = gradus;
//            min = 0;
//            sec = 0;
//        }

//        public Angle(ushort gradus, byte min)
//        {
//            this.gradus = gradus;
//            this.min = min;
//            sec = 0;
//        }


//        public Angle(ushort gradus, byte min, byte sec)
//        {
//            this.gradus = gradus;
//            this.min = min;
//            this.sec = sec;
//        }

//        public void ToRadians()
//        {
//            double rad = Math.Round((Math.PI * gradus / 180 + Math.PI * min / 10800 + Math.PI * sec / 648000), 5);
//            Console.WriteLine();
//            Console.WriteLine("--------------------------------------------------------------------");
//            Console.WriteLine("Угол {0} градусов {1} минут {2} секунд = {3} радиан", gradus, min, sec, rad);
//        }
//    }
//}
