using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicament
{
    public class Medicine
    {
        // date membre private
        int interval; // Intervalul orar
        int gramaj; // Gramaj
        double pret; // Pret
        string valabilitate; // Data expirarii
        string scop; // Ameliorare durere
        string tinta; // copii, adulti
        string nume; // Numele

        // Constructors
        public Medicine()
        {
            interval = 0;
            gramaj = 0;
            pret = 0;
            valabilitate = "15-01-1970";
            scop = "unknown";
            tinta = "unknown";
            nume = "unknown";
        }
        public Medicine(int _interval, int _gramaj, double _pret, string _valabilitate, string _scop, string _tinta, string _nume)
        {
            setInterval(_interval);
            setGramaj(_gramaj);
            setPret(_pret);
            setValabilitate(_valabilitate);
            setScop(_scop);
            setTinta(_tinta);
            setNume(_nume);
        }

        // Setters
        public void setInterval(int _interval) { interval = isValidInterval(_interval) ? _interval : 0; }
        public void setGramaj(int _gramaj) { gramaj = isValidGramaj(_gramaj) ? _gramaj : 9; }
        public void setPret(double _pret) { pret = isValidPret(_pret) ? _pret : 0; }
        public void setValabilitate(string _valabilitate) { valabilitate = isValidValabilitate(_valabilitate) ? _valabilitate : "15-01-1970"; }
        public void setScop(string _scop) { scop = isValidScop(_scop) ? _scop : "unknown"; }
        public void setTinta(string _tinta) { tinta = isValidTinta(_tinta) ? _tinta : "unknown"; }
        public void setNume(string _nume) { nume = isValidNume(_nume) ? _nume : "undefined"; }

        // Getters
        public int getInterval() { return interval; }
        public int getGramaj() { return gramaj; }
        public double getPret() { return pret; }
        public string getValabilitate() { return valabilitate; }
        public string getScop() { return scop; }
        public string getTinta() { return tinta; }
        public string getNume() { return nume; }

        // Convert to string
        public string ConvertToString()
        {
            string result = "Nume: \t\t" + getNume() + Environment.NewLine +
                            "Gramaj:\t\t" + getGramaj() + " mg" + Environment.NewLine +
                            "Valabilitate: \t" + getValabilitate() + Environment.NewLine +
                            "Scop: \t\t" + getScop() + Environment.NewLine +
                            "Tinta: \t\t" + getTinta() + Environment.NewLine +
                            "Pret: \t\t" + getPret() + " RON" + Environment.NewLine +
                            "Interval orar:\t" + getInterval() + " ore" + Environment.NewLine;
            return result;
        }

        public string ConvertToJson()
        {
            return "{" + Environment.NewLine +
                "\t\"nume\": \"" + getNume() + "\"," + Environment.NewLine +
                "\t\"gramaj\": " + getGramaj() + "," + Environment.NewLine +
                "\t\"valabilitate\": \"" + getValabilitate() + "\"," + Environment.NewLine +
                "\t\"scop\": \"" + getScop() + "\"," + Environment.NewLine +
                "\t\"tinta\": \"" + getTinta() + "\"," + Environment.NewLine +
                "\t\"pret\": " + getPret() + "," + Environment.NewLine +
                "\t\"interval\": " + getInterval() + Environment.NewLine +
            "}";
        }

        // Comparare medicament
        public string Comparare(Medicine M)
        {
            string result = "\nNume: \t\t\t" + nume + "\t\t\t" + M.nume +
                            "\nGramaj: \t\t" + gramaj + " mg\t\t\t" + M.gramaj + " mg" +
                            "\nValabilitate: \t\t" + valabilitate + "\t\t" + M.valabilitate +
                            "\nPret: \t\t\t" + pret + " RON" + "\t\t\t" + M.pret + " RON" +
                            "\nInterval orar:\t" + interval + " ore\t\t\t" + M.interval + " ore" +
                            "\nScop: \t\t\t" + scop + "\t\t\t" + M.scop;
            return result;
        }

        // Parse medicament
        public void parseMedicament(string _medicament)
        {
            string[] lines = _medicament.Split(';');
            for (int i = 0; i < lines.GetLength(0) - 1; i++)
            {
                string[] keyVal = lines[i].Split(':');

                // Nume
                if (keyVal[0].ToLower() == "nume")
                {
                    setNume(keyVal[1].Trim());
                }
                // Gramaj
                if (keyVal[0].ToLower() == "gramaj")
                {
                    setGramaj(Int32.Parse(keyVal[1].Trim().Split(' ')[0]));
                }
                // Valabilitate
                if (keyVal[0].ToLower() == "termen de valablilitate")
                {
                    setValabilitate(keyVal[1].Trim());
                }
                // Scop
                if (keyVal[0].ToLower() == "scop")
                {
                    string scopes = keyVal[1].Trim();
                    setScop(scopes);
                }
                // Tinta
                if (keyVal[0].ToLower() == "tinta")
                {
                    setTinta(keyVal[1].Trim());
                }
                // Pret
                if (keyVal[0].ToLower() == "pret")
                {
                    setPret(Int32.Parse(keyVal[1].Trim().Split(' ')[0]));
                }
                // Interval
                if (keyVal[0].ToLower() == "interval orar de administrare")
                {
                    setInterval(Int32.Parse(keyVal[1].Trim().Split(' ')[0]));
                }
            }

        }

        // Validations
        public bool isValidInterval(int _interval) { return _interval > 0 && _interval <= 24; }
        public bool isValidGramaj(int _gramaj) { return _gramaj > 0; }
        public bool isValidPret(double _pret) { return _pret > 0; }
        public bool isValidValabilitate(string _valabilitate) { return _valabilitate.Length > 0; } // Extract the date time
        public bool isValidScop(string _scop) { return _scop.Length > 0; }
        public bool isValidTinta(string _tinta) { return _tinta.ToLower() == "copii" || _tinta.ToLower() == "adulti"; }
        public bool isValidNume(string _nume) { return _nume.Length > 0; }
        public bool isValidArray(string[] _arr) { return _arr.GetLength(0) > 0; }

        // Utils
        public bool isValidMedicament() { return nume.Length > 0 && nume != "unknown"; }
    }
}
