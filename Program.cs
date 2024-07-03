using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexandrenkoTicket10 // Александренко Михаил 31ИС
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool ML = false; int MasLenght = 0;
            while (ML == false)
            {
                try
                {
                    Console.Write("Введите размерность массива (int): ");
                    MasLenght = Convert.ToInt32(Console.ReadLine());
                    ML = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Содежание не соответсвует требованиям");
                }
            }

            bool SB = false; int sebes = 0;
            while (SB == false)
            {
                try
                {
                    Console.Write("Введите себестоимость (int): ");
                    sebes = Convert.ToInt32(Console.ReadLine());
                    SB = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Содежание не соответсвует требованиям");
                }
            }

            int[] PriceMass = new int[MasLenght]; // Цена
            int[] RespondMass = new int[MasLenght]; // Кол-во
            int[] DemandMass = new int[MasLenght]; // Спрос
            int[] ProfitMass = new int[MasLenght]; // Прибыль

            for (int i = 0; i < MasLenght; i++)
            {
                Console.Write($"Введите цену {i+1}: ");
                PriceMass[i] = Convert.ToInt32(Console.ReadLine());
            }

            for (int i = 0; i < MasLenght; i++)
            {
                Console.Write($"Введите кол-во респондентов для  {PriceMass[i]}: ");
                RespondMass[i] = Convert.ToInt32(Console.ReadLine());
            }

            // Заполнение массива
            for (int i = 0; i < MasLenght; i++)
            {
                DemandMass[i] = 0;
            }


            // Спрос
            for (int i = MasLenght; i >= 0; i--)
            {
                for (int j = i; j < MasLenght; j++)
                {
                    DemandMass[i] += RespondMass[j];
                }
            }

            // Прибыль
            for (int i = 0; i < MasLenght; i++)
            {
                ProfitMass[i] = (PriceMass[i] - sebes) * DemandMass[i];
            }


            // Вывод
            Console.Write("Цена:                ");
            for (int i = 0; i < MasLenght; i++)
            {
                Console.Write(PriceMass[i] + " ");
            }
            Console.Write("\nКол-во респондентов: ");
            for (int i = 0; i < MasLenght; i++)
            {
                Console.Write(RespondMass[i] + " ");
            }
            Console.Write("\nСпрос:               ");
            for (int i = 0; i < MasLenght; i++)
            {
                Console.Write(DemandMass[i] + " ");
            }
            Console.Write("\nПрибыль:             ");
            for (int i = 0; i < MasLenght; i++)
            {
                Console.Write(ProfitMass[i] + " ");
            }

            int SEBcounter = 0;

            for (int i = 0; i < MasLenght; i++)
            {
                if (PriceMass[i] < sebes)
                    SEBcounter++;
            }

            

            int Profit = 0, PPrice = 0, Demand = 0;

            for (int i = 0; i < MasLenght; i++)
            {
                if (ProfitMass[i] > Profit)
                {
                    Profit = ProfitMass[i];
                    PPrice = PriceMass[i];
                    Demand = DemandMass[i];
                }
            }
            Console.WriteLine($"Количество значений ниже себестоимости:    |{SEBcounter}");
            Console.WriteLine($"Максимальная прибыль:                      |{Profit}");
            Console.WriteLine($"Цена, обеспечивающая максимальную прибыль: |{PPrice}");
            Console.WriteLine($"Спрос на товар для оптимальной цены:       |{Demand}");
            Console.WriteLine("Работу выполнил студент: Александренко Михаил Владимирович");
            Console.WriteLine("Группа: 31ИС");

            Console.ReadLine();
        }

    }
}
