using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ProgrammaEventi
{
    string titolo;
    List<Evento> eventi;

    public string Titolo { get => titolo; private set => titolo = value; }

    public ProgrammaEventi(string titolo)
    {
        this.titolo = titolo;
        this.eventi = new List<Evento>();
    }

    public void AggiungiEvento(Evento evento)
    {
        eventi.Add(evento);
    }

    public List<Evento> RicercaPerData(string data)
    {
        var risultatoRicerca = new List<Evento>();
        var dataRicerca = DateOnly.ParseExact(data, "dd/MM/yyyy", null);

        foreach (var evento in eventi)
        {
            if (evento.Data == dataRicerca) 
            {
                risultatoRicerca.Add(evento);
            }
        }
        return risultatoRicerca;
    }

    public int NumeroEventi()
    {
        return eventi.Count;
    }

    public void CancellaEventi()
    {
        eventi.Clear();
    }
    public string EventiFuturi()
    {
        var riga = Environment.NewLine;
        var eventiFuturi = "Eventi previsti: " + riga;
        foreach (var evento in eventi)
        {
            eventiFuturi += evento.ToString() + riga;
        }
        return eventiFuturi;
    }
    public static string StampaLista(List<Evento> lista)
    {
        var riga = Environment.NewLine;
        string risultato = "";
        foreach (var evento in lista)
        {
            risultato += evento.ToString() + riga;
        }
        return risultato;
    }
}
