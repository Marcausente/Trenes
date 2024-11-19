using System;
using System.Threading;

/*
class Ej3
{
    private static SemaphoreSlim accesoVia = new SemaphoreSlim(1, 1);

    static void SimularRecorrido(string tren, int inicio, int destino, int avance, int puntoControl, int liberarControl, int pausa)
    {
        for (int posicion = inicio; posicion != destino; posicion += avance)
        {
            if (posicion == puntoControl)
            {
                accesoVia.Wait(); // Tren entra en la sección restringida
            }
            else if (posicion == liberarControl)
            {
                accesoVia.Release(); // Tren libera la sección restringida
            }

            if (avance > 0)
            {
                Console.WriteLine($"{tren} está en el kilómetro: {posicion}");
            }
            else
            {
                Console.WriteLine($"\t\t\t\t{tren} está en el kilómetro: {posicion}");
            }

            Thread.Sleep(pausa);
        }

        if (inicio != destino)
        {
            if (avance > 0)
            {
                Console.WriteLine($"{tren} ha llegado al kilómetro final: {destino}");
            }
            else
            {
                Console.WriteLine($"\t\t\t\t{tren} ha llegado al kilómetro final: {destino}");
            }
        }
    }

    static void Main(string[] args)
    {
        Thread hiloTren1 = new Thread(() => SimularRecorrido("Expreso 1", 0, 100, 1, 20, 60, 250));
        Thread hiloTren2 = new Thread(() => SimularRecorrido("Expreso 2", 100, 0, -1, 60, 20, 200));

        hiloTren1.Start();
        hiloTren2.Start();

        hiloTren1.Join();
        hiloTren2.Join();

        Console.WriteLine("Ambos trenes han completado sus recorridos.");
    }
}
*/