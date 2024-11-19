using System;
using System.Threading;

class Ej1
{
    private static SemaphoreSlim controlAcceso = new SemaphoreSlim(1, 1);

    static void RecorridoTren1()
    {
        for (int distancia = 0; distancia <= 100; distancia++)
        {
            if (distancia == 20)
            {
                controlAcceso.Wait();
            }
            else if (distancia == 60)
            {
                controlAcceso.Release();
            }

            Console.WriteLine($"Tren 1: {distancia} km");
            Thread.Sleep(250); // Espera 250 ms por kilómetro
        }
    }

    static void RecorridoTren2()
    {
        for (int distancia = 100; distancia >= 0; distancia--)
        {
            if (distancia == 60)
            {
                controlAcceso.Wait();
            }
            else if (distancia == 20)
            {
                controlAcceso.Release();
            }
            Console.WriteLine($"\t\t\t\tTren 2: km {distancia}");
            Thread.Sleep(200); // Espera 200 ms por kilómetro
        }
    }

    static void Main(string[] args)
    {
        Thread hiloTren1 = new Thread(RecorridoTren1);
        Thread hiloTren2 = new Thread(RecorridoTren2);

        hiloTren1.Start();
        hiloTren2.Start();

        hiloTren1.Join();
        hiloTren2.Join();

        Console.WriteLine("Ambos trenes han completado sus trayectos.");
    }
}