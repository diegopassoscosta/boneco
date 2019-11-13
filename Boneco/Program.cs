using System;
using System.Threading;

namespace Boneco
{
    class Program
    {
        public static void Main()
        {
            var th = new Thread(starta);
            th.Start();

        }

        public static void starta()
        {
            Boneco b = new Boneco();
            do
            {
                b.anda();
                Console.WriteLine("Andando----");
                Console.WriteLine(b.informacoes());
                Thread.Sleep(1000);
                if (b.getEnergia() <= 0)
                {
                    do
                    {
                        Console.WriteLine("descansando");
                        b.setEnergia();
                        Console.WriteLine(b.informacoes());
                        Thread.Sleep(500);
                    } while (b.getEnergia() < 10);
                    Console.WriteLine("recuperado... voltando em 3 segundos");
                    Thread.Sleep(3000);
                }
            } while (true);

        }



        class Boneco
        {
            private int distancia = 0;
            private int energia = 10;

            public Boneco()
            {

            }

            public int getEnergia()
            {
                return this.energia;
            }
            public void setEnergia()
            {
                energia = energia + 1;
            }
            public void anda()
            {
                distancia = distancia + 1;
                energia = energia - 1;
            }

            public void descansa()
            {
                energia = energia + 1;
            }

            public string informacoes()
            {
                return "energia: " + energia + "\ndiatancia:" + distancia + "\n";
            }
        }
    }
}
