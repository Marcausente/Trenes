using System;
using System.Threading;

class Ej1
{
    private static SemaphoreSlim controlAcceso = new SemaphoreSlim(1, 1);

    static void RecorridoTrenA()
    {
        for (int distancia = 0; distancia <= 100; distancia++)
        {
            if (distancia == 25)
            {
                controlAcceso.Wait();
            }
            else if (distancia == 75)
            {
                controlAcceso.Release();
            }

            Console.WriteLine($"Tren A: {distancia} km");
            Thread.Sleep(250);
        }
    }

    static void RecorridoTrenB()
    {
        for (int distancia = 100; distancia >= 0; distancia--)
        {
            if (distancia == 75)
            {
                controlAcceso.Wait();
            }
            else if (distancia == 25)
            {
                controlAcceso.Release();
            }

            Console.WriteLine($"\t\t\t\tTren B: km {distancia}");
            Thread.Sleep(200);
        }
    }

    static void Main(string[] args)
    {
        Thread hiloTrenA = new Thread(RecorridoTrenA);
        Thread hiloTrenB = new Thread(RecorridoTrenB);

        hiloTrenA.Start();
        hiloTrenB.Start();

        hiloTrenA.Join();
        hiloTrenB.Join();

        Console.WriteLine("Ambos trenes han completado sus trayectos.");
    }
}