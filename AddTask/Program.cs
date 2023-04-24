using System;
using System.IO;
using System.Threading;

namespace AddTask
{
    /*
    Створіть Semaphore, який здійснює контроль доступу до ресурсу з декількох потоків. 
    Організуйте впорядкований вивід інформації про отримання доступу до спеціального * .log файлу.
     */
    internal class Program
    {
        private static Semaphore pool;

        private static void Work(object number)
        {
            pool.WaitOne();

            File.AppendAllText("log.txt", string.Format("Поток {0} занял слот семафора.", number));
            Thread.Sleep(1000);
            File.AppendAllText("log.txt", string.Format("Поток {0} -----> освободил слот.", number));

            pool.Release();
        }

        public static void Main()
        {
            pool = new Semaphore(1, 4);

            for (int i = 1; i <= 8; i++)
            {
                Thread thread = new Thread(new ParameterizedThreadStart(Work));
                thread.Start(i);
            }

            // Задержка.
            Console.ReadKey();
        }
    }
}
