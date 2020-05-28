using Medicament;
using System;

namespace Farmacie
{
    public class Depozit
    {
        // date membre private
        Medicine[] medicamente; // Medicamente
        string[] nume; // Indexare dupa nume
        int[] stoc;       // int[] stoc; // Numarul de produse disponibile
        int index;

        // Constructors
        public Depozit()
        {
            index = 0;
            nume = new string[100];
            nume[0] = "unknown";
            stoc = new int[100];
            stoc[0] = 0; 
            medicamente = new Medicine[100];
        }
        public Depozit(Medicine Medicament, int _stoc = 1)
        {
            medicamente = new Medicine[100];
            medicamente[0] = Medicament;
            nume = new string[100];
            nume[0] = Medicament.getNume().ToLower();
            stoc[0] = _stoc;
            index = 1;
        }

        // Setters
        public void setMedicament(Medicine Medicament, int _stoc = 1)
        {
            medicamente[index] = Medicament;
            nume[index] = Medicament.getNume().ToLower();
            stoc[index] = _stoc;
            index += 1;
        }
        public void editMedicament(Medicine Medicament, int _stoc = 1) 
        {
            string _nume = Medicament.getNume();
            int editIndex = getIndexMedicament(_nume);
            if (editIndex == -1)
            {
                Console.WriteLine("Medicamentul nu a fost gasit.");
            }
            else
            {
                medicamente[editIndex] = Medicament;
                nume[editIndex] = _nume.ToLower();
                stoc[editIndex] = _stoc;
                Console.WriteLine("Medicamentul [" + _nume + "] a fost editat cu succes.");
            }
        }
        public void removeMedicament(string name) {
            int indexMedicament = getIndexMedicament(name);

            if (isEmptyDepozit()) {
                Console.WriteLine("Depozitul este gol.");
                return;
            }
            if (indexMedicament == -1) {
                Console.WriteLine("Medicamentul nu a fost gasit.");
                return;
            }

            for (int i = 0; i <= index; i++) {
                if (i > indexMedicament) {
                    medicamente[i-1] = medicamente[i];
                }
            }

            nume[index] = "unknown";
            index--;

            Console.WriteLine("Medicamentul a fost sters cu succes.");
        }

        // Getters
        public string getMedicamente()
        {
            string result = "\n";

            if (isEmptyDepozit())
            {
                return "Depozitul este gol.";
            }

            for (int i = 0; i < index; i++)
            {
                result += medicamente[i].ConvertToString() + (i + 1 != index ? "\n\n---------------------------------------------------------\n\n" : "\n\n");
            }

            return result;
        }
        public string getNumeMedicamente()
        {
            string result = "";
            if (isEmptyDepozit())
            {
                return "Depozitul este gol.";
            }
            for (int i = 0; i < index; i++)
            {
                result += nume[i] + (i + 1 < index ? ", " : "");
            }
            return result;
        }
        public int getTotalMedicamente() { return index; }
        public Medicine findMedicament(string _nume) 
        {
            int findIndex = getIndexMedicament(_nume);
            if (findIndex == -1)
            {
                return new Medicine();
            }

            return medicamente[findIndex];
        }
        public bool existsMedicament(string _nume) { return getIndexMedicament(_nume) > -1; }

        // Validations
        private bool isEmptyArray(string[] _arr) { return _arr.GetLength(0) > 0; }
        private int getIndexMedicament(string name) {
            if (index == 0) {
                return -1;
            }
            
            for (int i = 0; i < index; i++) {
                if (medicamente[i].getNume().ToLower() == name.ToLower()) {
                    return i;
                }
            }

            return -1;
        }

        // Utils
        public bool isEmptyDepozit() { return index == 0; }
    }
}
