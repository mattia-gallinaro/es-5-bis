using System;

namespace Esercizio
{
    class Temp
    {
        int[] temperature;
        int last;
        public Temp()
        {
            last = 0;
            temperature = new int[1];
        }
        public int verifica()
        {
            try
            {
                int valore = int.Parse(Console.ReadLine());
                return valore;
            }
            catch
            {
                return -1;
            }

        }
        public void setTemp(string temp)
        {
            string[] array = temp.Split(',');
            Array.Resize(ref temperature, array.Length);
            for(int i = 0; i< temperature.Length; i++)
            {
                temperature[i] = Convert.ToInt32(array[i]);
            }
            getLast();
            Array.Sort(temperature);
        }
        public void getLast()
        {
            last = temperature[temperature.Length - 1];
        }
        public int mostraMassimo()
        {
            return temperature[temperature.Length - 1];
        }
        public int mostraMinimo()
        { 
            return temperature[0];
        }
        public int mostraUlitmonumero()
        {
            return last;
        }
        static void Main(string[] args)
        {
            int n = 0;
            string temperaturescritte="";
            Temp t = new Temp();
            int quantità;
            do
            {
                Console.WriteLine("Inserisci quante temperature vuoi inserire");
                quantità = t.verifica();
            }while (quantità < 0);
            for(int i = 0; i < quantità; i++)
            {
                Console.WriteLine("Inserisci la temperatura: ");
                if(temperaturescritte == "")
                {
                    temperaturescritte = Console.ReadLine();
                }
                else
                {
                    temperaturescritte = temperaturescritte + "," + Console.ReadLine();
                }
            }
            t.setTemp(temperaturescritte);
            Console.WriteLine("L'ultima temperatura inserita e' : {0}", Convert.ToString(t.mostraUlitmonumero()));
            Console.WriteLine("La temperatura minima e': {0}",Convert.ToString(t.mostraMinimo()));
            Console.WriteLine("La temperatura massimo e': {0}", Convert.ToString(t.mostraMassimo()));
        }
    }
}
