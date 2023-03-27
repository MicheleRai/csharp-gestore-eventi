gestoreEventi();
void gestoreEventi()
{
    Console.WriteLine("Benvenuti nel nostro Gestore Eventi");
    Console.WriteLine("Per piacere inserire titolo della lista di eventi che si vuole andare a creare");
    var titoloLista = Console.ReadLine() ?? "";
    var programmazione = new ProgrammaEventi(titoloLista);
    Console.WriteLine("Inserisca il numero di eventi che si vuole aggiungere alla lista");
    var nEventi = Convert.ToInt32(Console.ReadLine());
    for (int i = 0; i < nEventi; ++i)
    {
        try
        {
            Console.WriteLine($"Sta procedendo all'inserimento dell'evento numero {i + 1}");

            Console.WriteLine("Prego inserisca il titolo dell'evento");
            var titolo = Console.ReadLine() ?? "";

            Console.WriteLine("Prego inserisca la data dell'evento ( gg/mm/yyyy ):");
            var data = Console.ReadLine() ?? "";

            Console.WriteLine("Prego inserisca la capienza massima dell'evento:");
            var capienzaMassima = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Si tratta di una conferenza? ( si / NO )");
            var sceltaConferenza = Console.ReadLine();

            if( sceltaConferenza == "si" || sceltaConferenza == "y" || sceltaConferenza == "s" || sceltaConferenza == "yes")
            {
                Console.WriteLine("Prego inserisca il nome del relatore");
                var relatore = Console.ReadLine() ?? "";

                Console.WriteLine("Prego inserisca il prezzo della conferenza");
                var prezzo = Convert.ToDouble(Console.ReadLine());

                var conferenza = new Conferenza(titolo, data, capienzaMassima, relatore, prezzo);
                programmazione.AggiungiEvento(conferenza);

                Console.WriteLine("Vuole effettuare delle prenotazioni? ( si / NO )");
                var scelta = Console.ReadLine();

                if (scelta == "si" || scelta == "y" || scelta == "s" || scelta == "yes")
                {
                    Console.WriteLine("Prego inserisca il numero di posti che vuole prenotare?");
                    var prenotazioni = Convert.ToInt32(Console.ReadLine());
                    conferenza.PrenotaPosti(prenotazioni);
                    Console.WriteLine($"Il numero di posti prenotati è: {conferenza.PostiPrenotati}");
                    Console.WriteLine($"I posti restanti sono: {conferenza.CapienzaMassima - conferenza.PostiPrenotati} disponibili");
                }
                Console.WriteLine($"I posti restanti sono: {conferenza.Titolo} sono {conferenza.CapienzaMassima - conferenza.PostiPrenotati}");
                Console.WriteLine($"Il numero di posti prenotati è: {conferenza.PostiPrenotati} posti su {conferenza.CapienzaMassima}");
                
                var disdetta = true;

                while (disdetta)
                {
                    Console.WriteLine("Vuole disdire dei posti? ( si / NO )");
                    var scelta1 = Console.ReadLine();
                    if (scelta1 == "si" || scelta1 == "y" || scelta1 == "s" || scelta1 == "yes")
                    {
                        Console.WriteLine("Prego inserisca il numero di posti che vuole disdire?");
                        var disdici = Convert.ToInt32(Console.ReadLine());
                        conferenza.DisdiciPosti(disdici);
                        Console.WriteLine($"Il numero di posti prenotati è: {conferenza.PostiPrenotati}.");
                        Console.WriteLine($"I posti restanti sono: {conferenza.CapienzaMassima - conferenza.PostiPrenotati} disponibili");
                    }
                    else disdetta = false;
                }
            }
            else
            {
                var evento = new Evento(titolo, data, capienzaMassima);

                Console.WriteLine("Vuole effettuare delle prenotazioni? ( si / NO )");
                var scelta2 = Console.ReadLine();
                if(scelta2 == "si" || scelta2 == "y" || scelta2 == "s" || scelta2 == "yes")
                {
                    Console.WriteLine("Prego inserisca il numero di posti che vuole prenotare?");
                    var prenotazioni = Convert.ToInt32(Console.ReadLine());

                    evento.PrenotaPosti(prenotazioni);
                }
                Console.WriteLine($"I posti restanti per l'evento  {evento.Titolo} sono: {evento.CapienzaMassima - evento.PostiPrenotati}");
                Console.WriteLine($"Il numero di posti prenotati è: {evento.PostiPrenotati} posti su {evento.CapienzaMassima}");
                
                var disdetta1 = true;
                while (disdetta1)
                {
                    Console.WriteLine("Vuoi disdire dei posti? ( si / NO )");
                    var scelta3 = Console.ReadLine();
                    if (scelta3 == "si" || scelta3 == "y" || scelta3 == "s" || scelta3 == "yes")
                    {
                        Console.WriteLine("Quanti posti vuoi disdire?");
                        var disdici = Convert.ToInt32(Console.ReadLine());
                        evento.DisdiciPosti(disdici);
                        Console.WriteLine($"Il numero di posti prenotati è: {evento.PostiPrenotati}.");
                        Console.WriteLine($"I posti restanti per l'evento sono: {evento.CapienzaMassima - evento.PostiPrenotati} disponibili");
                    }
                    else disdetta1 = false;
                }
                evento.ToString();
                Console.WriteLine($"Il numero di posti prenotati è: {evento.PostiPrenotati}.");
                Console.WriteLine($"I posti restanti per l'evento sono: {evento.CapienzaMassima - evento.PostiPrenotati} disponibili");

                programmazione.AggiungiEvento(evento);
            }
        }
        catch (Exception ex) 
        { 
            Console.WriteLine(ex.ToString());
            i--;
        }
    }
    Console.WriteLine($"Nella lista {programmazione.Titolo} da te creata sono presenti {programmazione.NumeroEventi()} eventi");
    Console.WriteLine(programmazione.EventiFuturi());
    while (true)
    {
        Console.WriteLine("Inserisci una data da cercare: ( gg/MM/yyyy )");
        var dataRicerca = Console.ReadLine() ?? "";
        var risultatoRicerca = programmazione.RicercaPerData(dataRicerca);
        Console.WriteLine($"Eventi in data {dataRicerca}");
        Console.WriteLine(ProgrammaEventi.StampaLista(risultatoRicerca) != "" ? ProgrammaEventi.StampaLista(risultatoRicerca) : "Non ci sono eventi in questa data");
    }
}
