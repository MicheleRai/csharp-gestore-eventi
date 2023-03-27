using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Evento
{
    string? titolo;
    DateOnly data;
    int capienzaMassima;
    int postiPrenotati;
    public Evento(string titolo, string data, int capienzaMassima)
    {
        Titolo = titolo;
        Data = DateOnly.ParseExact(data, "dd/MM/yyyy", null);
        CapienzaMassima = capienzaMassima;
        PostiPrenotati = 0;
    }

    public string? Titolo
    {
        get
        {
            return titolo;
        }

        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                titolo = value;
            }
            else
            {
                throw new ArgumentException("Il campo titolo non può essere vuoto");
            }
        }
    }
    public DateOnly Data
    {
        get => data;
        set
        {
            if (value > DateOnly.FromDateTime(DateTime.Now))
            {
                data = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(value), "La data settata deve essere futura");
            }
        }
    }
    public int CapienzaMassima
    {
        get => capienzaMassima; private set
        {
            if (value > 0)
            {
                capienzaMassima = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(value), "La capienza massima non può essere minore di zero");
            }
        }
    }
    public int PostiPrenotati { get => postiPrenotati; private set => postiPrenotati = value; }

    public void PrenotaPosti(int posti)
    {
        if (DateOnly.FromDateTime(DateTime.Now) > data)
        {
            throw new InvalidOperationException("L'evento è già passato, mi dispiace");
        }
        else if (capienzaMassima < posti || postiPrenotati + posti > capienzaMassima)
        {
            throw new InvalidOperationException("I posti prenotati andrebbero a superare la capienza massima del evento , mi dispiace");
        }
        else
        {
            postiPrenotati += posti;
        }
    }
    public void DisdiciPosti(int posti)
    {
        if (DateOnly.FromDateTime(DateTime.Now) > data)
        {
            throw new InvalidOperationException("L'evento è già passato, mi dispiace");
        }
        else if (capienzaMassima < posti || postiPrenotati - posti < 0)
        {
            throw new InvalidOperationException("Non si possono disdire piu posti di quelli prenotati, mi dispiace");
        }
        else
        {
            postiPrenotati -= posti;
        }
    }

    public override string ToString()
    {
        return $"{data} - {titolo}";
    }
}
