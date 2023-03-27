using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Conferenza : Evento
{
    string? relatore;
    double prezzo;
    public Conferenza(string titolo, string data, int capienzaMassima, string relatore, double prezzo) : base(titolo, data, capienzaMassima)
    {
        Relatore = relatore;
        Prezzo = prezzo;
    }
    public string Relatore { get; set; }
    public double Prezzo { get => prezzo; set => prezzo = value; }

    public string PrezzoConPunto()
    {
        return prezzo.ToString("0.00");
    }
    public override string ToString()
    {
        return base.ToString() + " - " + relatore + " - " + PrezzoConPunto() + "EURO";
    }
}
