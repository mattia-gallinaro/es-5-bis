//nickname: matgal
//Data: 13/10/2021
/*Consegna: Dopo aver acquisito da tastiera una serie di dati relativi alla misurazione della temperatura di una
* certa città, scrivere il codice di un programma(OOP) in C# che determini e visualizzi la temperatura
* più bassa e quella più alta. */
using System;

namespace Esercizio
{
    //la classe
    class Temp
    {
        int[] temperature;
        int last;
        //il costruttore inizializza le variabili last e l'array temperature
        public Temp()
        {
            last = 0;
            temperature = new int[1];
        }
        //controlla che il valore che l'utente inserisce da tastiera sia un numero e ritorna la temperatura o -1
        public int VerificaQuantità()
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
        //controlla che il valore che l'utente inserisce da tastiera sia un numero e ritorna false se non lo è, true se è una variabile numerica
        public bool VerificaTemperatura(string quantità)
        {
            try
            {
                int controllo = int.Parse(quantità);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //aggiunge gli elementi presenti nel array ricevuto e li inserisce dentro l'array temperature convertendoli in interi e dopo riordina l'array 
        public void SetTemp(string temp)
        {
            string[] array = temp.Split(',');
            Array.Resize(ref temperature, array.Length);
            for(int i = 0; i< temperature.Length; i++)
            {
                temperature[i] = Convert.ToInt32(array[i]);
            }
            GetLast();
            Array.Sort(temperature);
        }
        //assegna alla variabile last l'ultimo valore dell'array temperature prima che esso sia riordinato
        public void GetLast()
        {
            last = temperature[temperature.Length - 1];
        }
        //ritorna l'ultimo valore dell'array ordinato temperature
        public int MostraMassimo()
        {
            return temperature[temperature.Length - 1];
        }
        //ritorna il primo valore dell'array ordinato temperature
        public int MostraMinimo()
        { 
            return temperature[0];
        }
        //ritorna il valore della varibile last
        public int MostraUlitmonumero()
        {
            return last;
        }
        //chiede quante temperature l'utente vuole inserire, controlla che possa essere convertito in intero,
        //dopo l'utente inserisce la temperature che vengono controllate affinchè siano solo valori numerici e la aggiugne alla variabile temperaturescritte
        //manda la stringa che verrà divisa in un array con il metodo Split e dopo mostra i tre valori specificati
        static void Main(string[] args)
        {
            int n = 0;
            string temperaturescritte="";
            string temperatura;
            Temp t = new Temp();
            int quantità;
            do
            {
                Console.WriteLine("Inserisci quante temperature vuoi inserire");
                quantità = t.Verifica();
            }while (quantità < 0);
            for(int i = 0; i < quantità; i++)
            {
                Console.WriteLine("Inserisci la temperatura: ");
                do
                {
                    temperatura = Console.ReadLine();
                } while (!t.VerificaTemperatura(temperatura));
                if(temperaturescritte == "")
                {
                    temperaturescritte = temperatura;
                }
                else
                {
                    
                    temperaturescritte = temperaturescritte + "," + temperatura;
                }
            }
            t.SetTemp(temperaturescritte);
            Console.WriteLine("L'ultima temperatura inserita e' : {0}", Convert.ToString(t.MostraUlitmonumero()));
            Console.WriteLine("La temperatura minima e': {0}",Convert.ToString(t.MostraMinimo()));
            Console.WriteLine("La temperatura massimo e': {0}", Convert.ToString(t.MostraMassimo()));
        }
    }
}
