using System;
using Task1;
using Task2;

namespace Lab3CSharp
{
    public class Program
    {
        public static void Task1()
        {
            Date[] dates =
            [
                new Date(5, 1, 2022),
                new Date(15, 3, 2022),
                new Date(25, 12, 2021),
                new Date(10, 9, 2023)
            ];

            Console.WriteLine("Before sort: ");
            foreach (var date in dates)
            {
                date.PrintDateInMonthFormat();
            }
            Console.WriteLine();

            Array.Sort(
                dates,
                (x, y) =>
                {
                    if (x.Year != y.Year)
                        return x.Year.CompareTo(y.Year);
                    if (x.Month != y.Month)
                        return x.Month.CompareTo(y.Month);
                    return x.Day.CompareTo(y.Day);
                }
            );
            Console.WriteLine("After sort :");
            foreach (var date in dates)
            {
                date.PrintDateInMonthFormat();
            }
            Console.WriteLine();
            foreach (var date in dates)
            {
                date.PrintDateInDotFormat();
            }

            Console.WriteLine();
            int maxDays = 0;
            for (int i = 0; i < dates.Length - 1; i++)
            {
                for (int j = i + 1; j < dates.Length; j++)
                {
                    int days = Date.DaysBetweenDates(dates[i], dates[j]);
                    Console.WriteLine(
                        $"Days between {dates[i].Day}.{dates[i].Month}.{dates[i].Year} and {dates[j].Day}.{dates[j].Month}.{dates[j].Year}: {days}"
                    );
                    if (days > maxDays)
                    {
                        maxDays = days;
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Maximum number of days between dates: {maxDays}");
        }

        public static void Task2()
        {
            List<Document> documents = new List<Document>();

            documents.Add(
                new Invoice(
                    "INV123",
                    DateTime.Now,
                    1000.50m,
                    "Seller1",
                    "Buyer1",
                    "Goods description"
                )
            );
            documents.Add(new Receipt("REC456", DateTime.Now, 500.75m, "Payer1"));
            documents.Add(
                new Waybill(
                    "WAY789",
                    DateTime.Now,
                    1200.30m,
                    "Sender1",
                    "Receiver1",
                    new List<string> { "Item1", "Item2", "Item3" }
                )
            );

            foreach (var document in documents)
            {
                document.Show();
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Lab 3 CSharp");

            while (true)
            {
                Console.WriteLine("=========================================================");
                Console.WriteLine("Select a task:");
                Console.WriteLine("1. Task 1");
                Console.WriteLine("2. Task 2");
                Console.WriteLine("3. Exit");
                Console.WriteLine("=========================================================");
                Console.Write("Enter your choice >>> ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Task1();
                        break;

                    case "2":
                        Task2();
                        break;

                    case "3":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }
    }
}
