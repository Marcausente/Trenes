using System;
using System.Threading;
/*
class Ej2
{
    private static SemaphoreSlim tramoExclusivo = new SemaphoreSlim(1, 1);
    private static int posicionTrenA = 0;
    private static int posicionTrenB = 0;
    static readonly object sincronizacion = new object();

    static void AvanzarTrenA()
    {
        for (int kilometro = 0; kilometro <= 100; kilometro++)
        {
            lock (sincronizacion) // Zona crítica para Tren A
            {
                posicionTrenA = kilometro;
                if (posicionTrenA > 20 && posicionTrenA < 60 && posicionTrenB > 20 && posicionTrenB < 60)
                {
                    Console.WriteLine("El Tren A s'ha aturat per evitar una col·lisió.");
                    return;
                }
            }

            if (kilometro == 20)
            {
                tramoExclusivo.Wait();
            }
            else if (kilometro == 60)
            {
                tramoExclusivo.Release();
            }

            Console.WriteLine($"Tren A: {kilometro} km");
            Thread.Sleep(250);
        }
    }

    static void AvanzarTrenB()
    {
        for (int kilometro = 100; kilometro >= 0; kilometro--)
        {
            lock (sincronizacion) // Zona crítica para Tren B
            {
                posicionTrenB = kilometro;
                if (posicionTrenA > 20 && posicionTrenA < 60 && posicionTrenB > 20 && posicionTrenB < 60)
                {
                    Console.WriteLine("El Tren B s'ha aturat per evitar una col·lisió.");
                    return;
                }
            }

            if (kilometro == 60)
            {
                tramoExclusivo.Wait();
            }
            else if (kilometro == 20)
            {
                tramoExclusivo.Release();
            }

            Console.WriteLine($"\t\t\t\tTren B: {kilometro} km");
            Thread.Sleep(200);
        }
    }

    static void Main(string[] args)
    {
        Thread hiloTrenA = new Thread(AvanzarTrenA);
        Thread hiloTrenB = new Thread(AvanzarTrenB);

        hiloTrenA.Start();
        hiloTrenB.Start();

        hiloTrenA.Join();
        hiloTrenB.Join();

        if (posicionTrenA == 100 && posicionTrenB == 0)
        {
            Console.WriteLine("Els trens han completat el recorregut sense incidents.");
        }
        else
        {
            Console.WriteLine("Els trens s'han aturat per motius de seguretat.");
        }
    }
}
*/