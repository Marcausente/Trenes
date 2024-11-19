using System;
using System.Threading;


// Ejercicio 1 by Gabriel Pérez
class Program
{
    private static SemaphoreSlim viaUnica = new SemaphoreSlim(1, 1);

    static void Tren1()
    {
        for (int km = 0; km <= 100; km++)
        {

            if (km == 20)
            {
                viaUnica.Wait();
            }
            else if (km == 60)
            {
                viaUnica.Release();
            }

            Console.WriteLine($"Tren 1: {km} quilòmetre");
            Thread.Sleep(250);
        }
    }

    static void Tren2()
    {
        for (int km = 100; km >= 0; km--)
        {
            if (km == 60)
            {
                viaUnica.Wait();
            }
            else if (km == 20)
            {
                viaUnica.Release();
            }

            Console.WriteLine($"\t\t\t\tTren 2: quilòmetre {km}");
            Thread.Sleep(200);
        }
    }

    static void Main(string[] args)
    {
        Thread tren1 = new Thread(Tren1);
        Thread tren2 = new Thread(Tren2);

        tren1.Start();
        tren2.Start();

        tren1.Join();
        tren2.Join();

        Console.WriteLine("Els trens han arribat al final del recorregut.");
    }
}

//Ejercicio 2 by Thiago Navarro

/*

using System;
using System.Threading;

class Program
{
    private static SemaphoreSlim viaUnica = new SemaphoreSlim(1, 1);
    private static int tren1Km = 0;
    private static int tren2Km = 0;
    static readonly object locker = new object();

    static void Tren1()
    {
        for (int km = 0; km <= 100; km++)
        {
            lock (locker) //locker del tren 1
            {
                tren1Km = km;
                if (tren1Km > 20 && tren1Km < 60 && tren2Km > 20 && tren2Km < 60) //if que se ejecuta y para a los trenes en caso de que ambos esten en el tramo de via unica a la vec (km21-59)
                {
                    Console.Write("Tren 1 detingut per perill de colisió \n");
                    return;
                }
            }
            if (km == 20)
            {
                viaUnica.Wait();
            }
            else if (km == 60)
            {
                viaUnica.Release();
            }

            Console.WriteLine($"Tren 1: {km} quilòmetre");
            Thread.Sleep(250);
        }
    }

    static void Tren2()
    {

        for (int km = 100; km >= 0; km--)
        {
            lock (locker) //locker del tren 2
            {
                tren2Km = km;
                if (tren1Km > 20 && tren1Km < 60 && tren2Km > 20 && tren2Km < 60)
                {
                    Console.Write("Tren 2 detingut per perill de colisió \n");
                    return;
                }
            }
            if (km == 60)
            {
                viaUnica.Wait();
            }
            else if (km == 20)
            {
                viaUnica.Release();
            }

            Console.WriteLine($"\t\t\t\tTren 2: quilòmetre {km}");
            Thread.Sleep(200);
        }
    }

    static void Main(string[] args)
    {
        Thread tren1 = new Thread(Tren1);
        Thread tren2 = new Thread(Tren2);

        tren1.Start();
        tren2.Start();

        tren1.Join();
        tren2.Join();

        if (tren1Km == 100 && tren2Km == 0) //if que informara si los trenes llegan o no
        {
            Console.WriteLine("Els trens han arribat al final del recorregut.");
        }
        else
        {
            Console.WriteLine("Trens detinguts per seguretat activant els protocols d'incidencies");
        }

    }
}

*/

// Ejercicio 3 by David Correa

/*

using System;
using System.Threading;

class Program
{
    private static SemaphoreSlim viaUnica = new SemaphoreSlim(1, 1);

    static void Tren(string nombreTren, int inicio, int final, int paso, int esperar, int seguir, int retraso)
    {
        for (int km = inicio; km != final; km += paso)
        {
            if (km == esperar)
            {
                viaUnica.Wait();
            }
            else if (km == seguir)
            {
                viaUnica.Release();
            }

            if (paso > 0)
            {
                Console.WriteLine(nombreTren + ": " + km + " quilòmetre");
            }
            else
            {
                Console.WriteLine("\t\t\t\t" + nombreTren + ": " + km + " quilòmetre");
            }

            Thread.Sleep(retraso);
        }

        if (inicio != final)
        {
            if (paso > 0)
            {
                Console.WriteLine(nombreTren + ": " + final + " quilòmetre");
            }
            else
            {
                Console.WriteLine("\t\t\t\t" + nombreTren + ": " + final + " quilòmetre");
            }
        }
    }

    static void Main(string[] args)
    {
        Thread tren1 = new Thread(() => Tren("Tren 1", 0, 100, 1, 20, 60, 250));
        Thread tren2 = new Thread(() => Tren("Tren 2", 100, 0, -1, 60, 20, 200));

        tren1.Start();
        tren2.Start();

        tren1.Join();
        tren2.Join();

        Console.WriteLine("Los trenes han llegado a su destino");
    }
}
*/