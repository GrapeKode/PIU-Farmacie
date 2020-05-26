using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicament;

namespace Depozit
{
    public class Deposit
    {
        // date membre private
        Medicine[] medicamente; // Medicamente
        string[] nume; // Indexare dupa nume
        int[] stoc;       // int[] stoc; // Numarul de produse disponibile
        int index;

        // Constructors
        public Deposit()
        {
            index = 0;
            nume = new string[100];
            nume[0] = "unknown";
            stoc = new int[100];
            stoc[0] = 0;
            medicamente = new Medicine[100];
        }
        public Deposit(Medicine Medicament, int _stoc = 1)
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
            if (existsMedicament(Medicament.getNume()))
            {
                Console.WriteLine("Medicamentul exista deja in depozit.");
                return;
            }

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
        public void removeMedicament(string name)
        {
            int indexMedicament = getIndexMedicament(name);

            if (isEmptyDepozit())
            {
                Console.WriteLine("Depozitul este gol.");
                return;
            }
            if (indexMedicament == -1)
            {
                Console.WriteLine("Medicamentul nu a fost gasit.");
                return;
            }

            for (int i = 0; i <= index; i++)
            {
                if (i > indexMedicament)
                {
                    medicamente[i - 1] = medicamente[i];
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
                result += medicamente[i].ConvertToString() + (i + 1 != index ? "-----------------------------------------------------------------------" : "") + Environment.NewLine;
            }

            return result;
        }

        public string getMedicamenteAsJSON()
        {
            string result = "{" + Environment.NewLine;

            if (isEmptyDepozit())
            {
                return "";
            }

            for (int i = 0; i < index; i++)
            {
                result += medicamente[i].ConvertToJson() + (i + 1 != index ? ",": "") + Environment.NewLine;
            }
            result += "}";

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
        public Medicine[] findMedicamenteByNume(string _nume) {
            Medicine[] result = new Medicine[100];
            int k = 0;

            if (isEmptyDepozit()) {
                result = new Medicine[1];
                return result;
            }

            for (int i = 0; i < index; i++) {
                if (medicamente[i].isValidMedicament()) {
                    if (medicamente[i].getNume().ToLower().Contains(_nume.ToLower())) {
                        result[k] = medicamente[i];
                        k++;
                    }
                }
            }

            Array.Resize(ref result, k);

            return result;
        }
        public Medicine[] findMedicamenteByPret(double pret1, double pret2 = 0) {
            double mPret;
            Medicine[] result = new Medicine[100];
            int k = 0;

            if (isEmptyDepozit()) {
                result = new Medicine[1];
                return result;
            }

            for (int i = 0; i < index; i++) {
                if (medicamente[i].isValidMedicament()) {
                    mPret = medicamente[i].getPret();

                    if (pret2 == 0) {
                        if (mPret == pret1) {
                            result[k] = medicamente[i];
                            k++;
                        }
                    } else {
                        if (mPret >= pret1 && mPret <= pret2) {
                            
                            result[k] = medicamente[i];
                            k++;
                        }
                    }
                }
            }

            Array.Resize(ref result, k);

            return result;
        }
        public Medicine[] findMedicamenteByTinta(string _tinta) {
            Medicine[] result = new Medicine[100];
            int k = 0;

            if (isEmptyDepozit()) {
                result = new Medicine[1];
                return result;
            }

            for (int i = 0; i < index; i++) {
                if (medicamente[i].isValidMedicament()) {
                    if (medicamente[i].getTinta().ToLower() == _tinta.ToLower()) {
                        result[k] = medicamente[i];
                        k++;
                    }
                }
            }

            Array.Resize(ref result, k);

            return result;
        }
        public Medicine[] findMedicamenteByScop(string _scop) {
            Medicine[] result = new Medicine[100];
            int k = 0;

            if (isEmptyDepozit()) {
                result = new Medicine[1];
                return result;
            }

            for (int i = 0; i < index; i++) {
                if (medicamente[i].isValidMedicament()) {
                    if (medicamente[i].getScop().ToLower().Contains(_scop.ToLower())) {
                        result[k] = medicamente[i];
                        k++;
                    }
                }
            }

            Array.Resize(ref result, k);

            return result;
        }
        public Medicine[] findMedicamenteByGramaj(int gramaj1, int gramaj2 = 0) {
            Medicine[] result = new Medicine[100];
            int k = 0;
            int mGramaj;

            if (isEmptyDepozit()) {
                result = new Medicine[1];
                return result;
            }

            for (int i = 0; i < index; i++) {
                if (medicamente[i].isValidMedicament()) {
                    mGramaj = medicamente[i].getGramaj();
                    if (gramaj2 == 0) {
                        if (mGramaj == gramaj1) {
                            result[k] = medicamente[i];
                            k++;
                        }
                    } else {
                        if (mGramaj >= gramaj1 && mGramaj <= gramaj2) {
                            result[k] = medicamente[i];
                            k++;
                        }
                    }
                }
            }

            Array.Resize(ref result, k);

            return result;
        }
        public bool existsMedicament(string _nume) { return getIndexMedicament(_nume) > -1; }

        // Validations
        public bool isEmptyArray(string[] _arr) { return _arr.GetLength(0) > 0; }
        public int getIndexMedicament(string name)
        {
            if (index == 0)
            {
                return -1;
            }

            for (int i = 0; i < index; i++)
            {
                if (medicamente[i].getNume().ToLower() == name.ToLower())
                {
                    return i;
                }
            }

            return -1;
        }

        // Utils
        public bool isEmptyDepozit() { return index == 0; }
    }
}

