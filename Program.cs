using Farmacie;
using Medicament;
using System;
using System.Collections.Specialized;

namespace Tema_6
{//
    class MainClass
    {
        static void addNume(Medicine M)
        {
            string nume; // Numele
            Console.Write("Introduceti numele medicamentului: ");
            nume = Console.ReadLine();
            M.setNume(nume);
        }
        static void addGramaj(Medicine M)
        {
            int gramaj; // Gramaj
            Console.Write("Introduceti gramajul medicamentului: ");
            gramaj = Int32.Parse(Console.ReadLine());
            M.setGramaj(gramaj);
        }
        static void addInterval(Medicine M)
        {
            int interval; // Intervalul orar
            Console.Write("Intervalul orar de administrare: ");
            interval = Int32.Parse(Console.ReadLine());
            M.setInterval(interval);
        }
        static void addPret(Medicine M)
        {
            double pret; // Pret
            Console.Write("Pret: ");
            pret = Double.Parse(Console.ReadLine());
            M.setPret(pret);
        }
        static void addValabilitate(Medicine M)
        {
            string valabilitate; // Data expirarii
            Console.Write("Termenul de valabilitate (15-0-1997): ");
            valabilitate = Console.ReadLine();
            M.setValabilitate(valabilitate);
        }
        static void addTinta(Medicine M)
        {
            string tinta; // copii, adulti
            Console.Write("Tinta (copii | adulti): ");
            tinta = Console.ReadLine();
            M.setTinta(tinta);
        }
        static void addScop(Medicine M)
        {
            int scopLen = -1;
            string[] scop = new string[5]; // Ameliorare durere
            Console.WriteLine("Beneficii:");
            Console.Write("Introduceti numarul de beneficii (0 - 5):");
            while (scopLen == -1)
            {
                scopLen = Int32.Parse(Console.ReadLine());
                if (scopLen > 5 || scopLen < 0)
                {
                    Console.Write("Introduceti un numar cuprins intre 0 si 5 inclusiv: ");
                    scopLen = -1;
                }
            }
            Console.WriteLine("Introduceti beneficiile aduse");
            for (int i = 0; i < scopLen; i++)
            {
                Console.Write("Beneficiul[" + (i + 1) + "]: ");
                scop[i] = Console.ReadLine();
            }
            M.setScop(scop, scopLen);
        }

        // Main functions
        static Medicine addMedicament(Medicine M)
        {
            M = new Medicine();

            Console.Clear();
            Console.WriteLine("Optiunea aleasa: 1. Creare medicament\n");

            // Nume
            addNume(M);
            // Gramaj
            addGramaj(M);
            // Interval
            addInterval(M);
            // Pret
            addPret(M);
            // Valabilitate
            addValabilitate(M);
            // Tinta
            addTinta(M);
            // Scop
            addScop(M);

            Console.WriteLine("Medicament adaugat cu succes.");
            return M;
        }
        public static void printMedicament(Medicine M)
        {
            Console.Clear();
            Console.WriteLine("Optiunea aleasa: 2. Afisare medicament\n");

            Console.WriteLine(M.ConvertToString());
        }
        public static void editMedicament(Medicine M)
        {
            Console.Clear();
            Console.WriteLine("Optiunea aleasa: 3. Editare medicament\n");
            System.Console.WriteLine("INFO: Modificarea i se va face si medicamentului din depozit.\n\n");

            Console.WriteLine(
                "1. Editeaza numele\n" +
                "2. Editeaza gramajul\n" +
                "3. Editeaza intervalul orar de administrare\n" +
                "4. Editeaza pretul\n" +
                "5. Editeaza termenul de valabilitate\n" +
                "6. Editeaza tinta (copii/adulti)\n" + 
                "7. Editeaza scopul\n" +
                "X. Ierire din modul editare\n\n" +
                "Alegeti optiunea: "
            );
            string opt = Console.ReadLine();

            switch(opt.ToUpper())
            {
                case "1":
                    addNume(M);
                    break;
                case "2":
                    addGramaj(M);
                    break;
                case "3":
                    addInterval(M);
                    break;
                case "4":
                    addPret(M);
                    break;
                case "5":
                    addValabilitate(M);
                    break;
                case "6":
                    addTinta(M);
                    break;
                case "7":
                    addScop(M);
                    break;
                case "QUIT":
                case "EXIT":
                case "X":
                    return;
                default:
                    Console.WriteLine("Optiune invalida!");
                    break;
            }

            editMedicament(M);
        }
        static void comparare(Depozit D)
        {
            Console.Clear();
            Console.WriteLine("Optiunea aleasa: 4. Comparare medicamente");
            Console.WriteLine("INFO: Aceasta optiune este valabila doar pentru medicamentele aflate in depozit.\n\n");

            if (D.isEmptyDepozit())
            {
                Console.WriteLine("Depozitul este gol. Adaugati medicamente mai intai.");
                return;
            }

            Console.WriteLine("In depozit sunt (" + D.getTotalMedicamente() + ") medicamente:\n[" + D.getNumeMedicamente() + "]");
            Console.WriteLine("\nIntroduceti numele celor doua medicamente: ");

            string nume1 = Console.ReadLine(), nume2 = Console.ReadLine();

            if (!D.existsMedicament(nume1))
            {
                Console.WriteLine("Medicamentul `" + nume1 + "` nu exista");
            }
            if (!D.existsMedicament(nume2))
            {
                Console.WriteLine("Medicamentul `" + nume2 + "` nu exista");
            }

            Console.WriteLine("Medicamentele alese: `" + nume1 + "` si `" + nume2 + "`");

            Medicine M1 = new Medicine();
            Medicine M2 = new Medicine();

            M1 = D.findMedicament(nume1);
            M2 = D.findMedicament(nume2);

            Console.WriteLine("Comparatie:");
            Console.WriteLine(M1.Comparare(M2));
        }
        public static void addDepozit(Depozit D, Medicine M)
        {
            Console.Clear();
            Console.WriteLine("Optiunea aleasa: 5. Adaugare in depozit\n");

            if (!M.isValidMedicament())
            {
                Console.WriteLine("Creati un medicament inainte de-al depozita.");
                return;
            }

            D.setMedicament(M);

            if (!D.existsMedicament(M.getNume()))
            {
                Console.WriteLine("Oh... Ceva n-a mers bine.");
                return;
            }
            Console.WriteLine("Medicamentul `" + M.getNume() + "` a fost adaugat cu succes.");
        }

        public static void printDepozit(Depozit D)
        {
            Console.Clear();
            Console.WriteLine("Optiunea aleasa: 6. Afisare medicamentele din depozit\n");

            Console.WriteLine(D.getMedicamente());
        }

        public static void editDepozit(Depozit D, Medicine M)
        {
            Console.Clear();
            Console.WriteLine("Optiunea aleasa: 7. Editare medicament din depozit\n");

            if (D.isEmptyDepozit()) {
                Console.WriteLine("Depozitul este gol.");
                return;
            }
            if (M.isValidMedicament() && !D.existsMedicament(M.getNume())) {
                Console.WriteLine("Aveti un medicament nesalvat. Doriti sa continuati? (y/N): ");
                string moveOn = Console.ReadLine();

                switch(moveOn.ToUpper()) {
                    case "DA":
                    case "D":
                    case "YES":
                    case "Y":
                        break;
                    default:
                        return;
                }
            }

            Console.WriteLine(
                "Medicamente disponibile [" + D.getNumeMedicamente() + "]\n" +
                "Introduceti numele medicamentului pentru editare: "
            );
            string name = Console.ReadLine();

            if (!D.existsMedicament(name)) {
                Console.WriteLine("Medicamentul {0} nu a fost gasit.", name);
                return;
            }

            Medicine editM = new Medicine();
            editM = D.findMedicament(name);
            editMedicament(editM);
            D.editMedicament(editM);
            Console.WriteLine("Editat -----------------------------------------\n{0}", editM.ConvertToString());
        }

        public static void findDepozit(Depozit D)
        {
            Console.Clear();
            Console.WriteLine("Optiunea aleasa: 8. Cautare medicament in depozit\n");

            Console.WriteLine("Introduceti numele medicamentului: ");
            string name = Console.ReadLine();

            Medicine M = D.findMedicament(name);

            if (!D.existsMedicament(M.getNume())) {
                System.Console.WriteLine("Medicamentul nu a fost gasit.");
                return;
            }

            System.Console.WriteLine("Medicamentul a fost gasit:\n\n" + M.ConvertToString());
        }

        public static void removeDepozit(Depozit D)
        {
            Console.Clear();
            Console.WriteLine("Optiunea aleasa: 9. Stergere medicament din depozit\n");

            System.Console.WriteLine("Introduceti numele medicamentului: ");
            string name = System.Console.ReadLine();

            D.removeMedicament(name);
        }

        static void Main(string[] args)
        {
            // Depozit + Medicament
            Depozit D = new Depozit();
            Medicine M = new Medicine();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Alegeti optiune (1-9):");
                Console.Write(
                  "1. Creare medicament;                 \n" +
                  "2. Afisare medicament;                \n" +
                  "3. Editare medicament;                \n" +
                  "4. Comparare medicamente;             \n" +
                  "5. Adaugare in depozit;               \n" +
                  "6. Afisare medicamentele din depozit; \n" +
                  "7. Editare medicament din depozit;    \n" +
                  "8. Cautare medicament in depozit      \n" +
                  "9. Stergere medicament din depozit    \n" +
                  "x. Exit                               \n"
                );

                Console.Write("\nAlegeti optiunea: ");

                switch (Console.ReadLine().ToLower())
                {
                    case "1":
                        // Console.Clear();
                        M = addMedicament(M);
                        Console.ReadLine();
                        break;
                    case "2":
                        // Console.Clear();
                        Console.WriteLine("ENTERED INTO PRINT_MEDICAMENT");
                        printMedicament(M);
                        Console.ReadLine();
                        break;
                    case "3":
                        // Console.Clear();
                        editMedicament(M);
                        Console.ReadLine();
                        break;
                    case "4":
                        // Console.Clear();
                        comparare(D);
                        Console.ReadLine();
                        break;
                    case "5":
                        // Console.Clear();
                        addDepozit(D, M);
                        Console.ReadLine();
                        break;
                    case "6":
                        // Console.Clear();
                        printDepozit(D);
                        Console.ReadLine();
                        break;
                    case "7":
                        // Console.Clear();
                        editDepozit(D, M);
                        Console.ReadLine();
                        break;
                    case "8":
                        // Console.Clear();
                        findDepozit(D);
                        Console.ReadLine();
                        break;
                    case "9":
                        // Console.Clear();
                        removeDepozit(D);
                        Console.ReadLine();
                        break;
                    case "exit":
                    case "stop":
                    case "x":
                        Console.Clear();
                        Console.WriteLine("Programul este pe cale sa se inchida; aceasta actiune va anula toate modificarile aduse. Continuati? (da | NU)");
                        if (Console.ReadLine().ToLower() != "da")
                        {
                            break;
                        }
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Comanda introdusa nu face parte din meniu.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
