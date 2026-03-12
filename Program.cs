/*
Gestione Rubrica
Programma da console per salvare contatti.

Funzioni possibili:
- Aggiungere contatto (nome + numero)
- Visualizzare contatti
- Cercare contatto
- Eliminare contatto
- Menu con scelta numerica

Esempio menu:

1 - Aggiungi contatto
2 - Mostra contatti
3 - Cerca contatto
4 - Elimina contatto
0 - Esci

Concetti usati:

List
cicli
metodi
condizioni
*/

using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Dataflow;

class Contatto
{
    private string? nome;
    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }

    private string? numero;
    public string Numero
    {
        get { return numero; }
        set { numero = value; }
    }

    public void Assegna()
    {
        do
        {
            Console.Write("Inserire nome del contatto: ");
            Nome = Console.ReadLine() ?? "";
            Console.Write("Inserire numero del contatto: ");
            Numero = Console.ReadLine() ?? "";
            if (Nome.Equals("") || Numero.Equals(""))
            {
                Console.WriteLine("Numero o nome non inseriti correttamente");
            }
        } while (Nome.Equals("") || Numero.Equals(""));
    }

    public override string ToString()
    {
        return $"{Nome}: {Numero}";
    }
}

class Program
{
    static void AggiungiContatto(List<Contatto> rubrica, Contatto contatto)
    {
        rubrica.Add(contatto);
        Console.WriteLine("Contatto aggiunto");
    }

    static string Ricerca(List<Contatto> rubrica, string nome)
    {
        return rubrica.FindIndex(x => x.Nome.Equals(nome)) + 1 + " - " + rubrica.Find(x => x.Nome.Equals(nome)).ToString();
    }
    static void Main()
    {
        int scelta = 1;
        List<Contatto> rubrica = new();// List<Contatto>();
        while (scelta > 0)
        {
            Console.WriteLine("MENU");
            Console.WriteLine("1 - Aggiungi contatto");
            Console.WriteLine("2 - Mostra contatti");
            Console.WriteLine("3 - Cerca contatto");
            Console.WriteLine("4 - Elimina contatto");
            Console.WriteLine("5 - Elimina rubrica");
            Console.WriteLine("Minore di 0 incluso - Esci");

            if (!int.TryParse(Console.ReadLine(), out scelta))
            {
                scelta = -1;
            }
            Console.Clear();
            switch (scelta)
            {
                case 1:
                    Contatto contatto = new();
                    contatto.Assegna();
                    AggiungiContatto(rubrica, contatto);
                    break;
                case 2:
                    if (rubrica.Count <= 0)
                    {
                        Console.WriteLine("Non ci sono contatti in rubrica");
                    }
                    else
                    {
                        int i = 0;
                        foreach (Contatto cont in rubrica)
                        {
                            i++;
                            Console.WriteLine($"{i} - {cont.Nome}: {cont.Numero}");
                        }
                    }
                    break;
                case 3:
                    Console.Write("Inserire il nome da cercare: ");
                    Console.WriteLine("Il nome cercato si trova in posizione " + Ricerca(rubrica, Console.ReadLine() ?? ""));
                    break;

                case <= 0:
                    Console.WriteLine("Uscita dal programma");
                    break;
                default:
                    Console.WriteLine("Scelta non valida. Rieffettuare la scelta.");
                    break;
            }
            Console.ReadLine();
            Console.Clear();
        }
    }
}