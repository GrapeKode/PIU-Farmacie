using System;

namespace Medicament
{
    public class Medicine
    {
        // date membre private
        int interval; // Intervalul orar
        int gramaj; // Gramaj
        double pret; // Pret
        string valabilitate; // Data expirarii
        string[] scop; // Ameliorare durere
        string tinta; // copii, adulti
        string nume; // Numele

        // Constructors
        public Medicine()
        {
            interval = 0;
            gramaj = 0;
            pret = 0;
            valabilitate = "15-01-1970";
            scop = new string[1];
            scop[0] = "unknown";
            tinta = "unknown";
            nume = "unknown";
        }
        public Medicine(int _interval, int _gramaj, double _pret, string _valabilitate, string[] _scop, string _tinta, string _nume)
        {
            setInterval(_interval);
            setGramaj(_gramaj);
            setPret(_pret);
            setValabilitate(_valabilitate);
            setScop(_scop, _scop.GetLength(0));
            setTinta(_tinta);
            setNume(_nume);
        }

        // Setters
        public void setInterval(int _interval) { interval = isValidInterval(_interval) ? _interval : 0; }
        public void setGramaj(int _gramaj) { gramaj = isValidGramaj(_gramaj) ? _gramaj : 9; }
        public void setPret(double _pret) { pret = isValidPret(_pret) ? _pret : 0; }
        public void setValabilitate(string _valabilitate) { valabilitate = isValidValabilitate(_valabilitate) ? _valabilitate : "15-01-1970"; }
        public void setScop(string[] _scop, int len)
        {
            scop = new string[len];
            for (int i = 0; i < len; i++)
            {
                if (isValidScop(_scop[i]))
                {
                    scop[i] = _scop[i];
                }
                else
                {
                    i--;
                }
            }
        }
        public void setTinta(string _tinta) { tinta = isValidTinta(_tinta) ? _tinta : "unknown"; }
        public void setNume(string _nume) { nume = isValidNume(_nume) ? _nume : "undefined"; }

        // Getters
        public int getInterval() { return interval; }
        public int getGramaj() { return gramaj; }
        public double getPret() { return pret; }
        public string getValabilitate() { return valabilitate; }
        public string getScop(string[] _scop)
        {
            string result = "";
            if (isValidArray(_scop))
            {
                for (int i = 0; i < _scop.GetLength(0); i++)
                {
                    result += _scop[i] + (i + 1 == _scop.GetLength(0) ? "" : ", ");
                }
            }
            return isValidScop(result) ? result : "undefined";
        }
        public string getTinta() { return tinta; }
        public string getNume() { return nume; }

        // Convert to string
        public string ConvertToString()
        {
            string result = "Nume: \t\t\t\t" + nume + ";\n" +
                            "Gramaj: \t\t\t" + gramaj + " mg;\n" +
                            "Termen de valabilitate: \t" + valabilitate + ";\n" +
                            "Scop: \t\t\t\t" + getScop(scop) + ";\n" +
                            "Tinta: \t\t\t\t" + tinta + ";\n" +
                            "Pret: \t\t\t\t" + pret + " RON" + ";\n" +
                            "Interval orar de administrare:\t" + interval + " ore;";
            return result;
        }

        // Comparare medicament
        public string Comparare(Medicine M)
        {
            string result = "\nNume: \t\t\t\t" + nume + "\t\t\t" + M.nume +
                            "\nGramaj: \t\t\t" + gramaj + " mg\t\t\t" + M.gramaj + " mg" +
                            "\nValabilitate: \t\t\t" + valabilitate + "\t\t" + M.valabilitate +
                            "\nPret: \t\t\t\t" + pret + " RON" + "\t\t\t" + M.pret + " RON" +
                            "\nInterval orar de administrare:\t" + interval + " ore\t\t\t" + M.interval + " ore" +
                            "\nScop: \t\t\t\t" + getScop(scop) + "\t\t\t" + getScop(M.scop);
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
                    string[] scopes = keyVal[1].Trim().Split(',');
                    setScop(scopes, scopes.GetLength(0));
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
        private bool isValidInterval(int _interval) { return _interval > 0; }
        private bool isValidGramaj(int _gramaj) { return _gramaj > 0; }
        private bool isValidPret(double _pret) { return _pret > 0; }
        private bool isValidValabilitate(string _valabilitate) { return _valabilitate.Length > 0; } // Extract the date time
        private bool isValidScop(string _scop) { return scop.Length > 0; }
        private bool isValidTinta(string _tinta) { return _tinta == "copii" || _tinta == "adulti"; }
        private bool isValidNume(string _nume) { return _nume.Length > 0; }
        private bool isValidArray(string[] _arr) { return _arr.GetLength(0) > 0; }

        // Utils
        public bool isValidMedicament() { return nume.Length > 0 && nume != "unknown"; }
    }
}
