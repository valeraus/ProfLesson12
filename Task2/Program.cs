using System;
using System.Threading;

namespace Task2
{
    /*
    Перетворіть приклад блокування подій таким чином, щоб замість ручної обробки використовувалася автоматична обробка.
     */
    class ManualEventDemo
    {
        static void Main()
        {
            var auto = new AutoResetEvent(false);

            var thread = new Work("1", auto);
            Console.WriteLine("Основной поток ожидает событие.\n");

            auto.WaitOne();
            Console.WriteLine("\nОсновной поток получил уведомление о событии от первого потока.\n");

            thread = new Work("2", auto);
            Console.WriteLine("Основной поток ожидает событие.\n");

            auto.WaitOne();
            Console.WriteLine("\nОсновной поток получил уведомление о событии от второго потока.");

            // Delay.
            Console.ReadKey();
        }
    }
}
