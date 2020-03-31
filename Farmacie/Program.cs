using Farmacie;
using Medicament;
using System;

namespace Tema_6
{
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


    static void addMedicament(Medicine M)
    {
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

      Console.WriteLine("This Will be implemented as soon as posible");
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

      M1.parseMedicament(D.findMedicament(nume1));
      M2.parseMedicament(D.findMedicament(nume1));

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

      D.setMedicament(M.ConvertToString(), M.getNume());

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

      Console.WriteLine("This Will be implemented as soon as posible");
    }

    public static void editDepozit(Depozit D, Medicine M)
    {
      Console.Clear();
      Console.WriteLine("Optiunea aleasa: 7. Editare medicament din depozit\n");

      Console.WriteLine("This Will be implemented as soon as posible");
    }

    public static void findDepozit(Depozit D)
    {
      Console.Clear();
      Console.WriteLine("Optiunea aleasa: 8. Cautare medicament in depozit\n");

      Console.WriteLine("This Will be implemented as soon as posible");
    }

    public static void removeDepozit(Depozit D)
    {
      Console.Clear();
      Console.WriteLine("Optiunea aleasa: 9. Stergere medicament din depozit\n");

      Console.WriteLine("This Will be implemented as soon as posible");
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
            addMedicament(M);
            Console.Read();
            break;
          case "2":
            printMedicament(M);
            Console.Read();
            break;
          case "3":
            editMedicament(M);
            Console.Read();
            break;
          case "4":
            comparare(D);
            Console.Read();
            break;
          case "5":
            addDepozit(D, M);
            Console.Read();
            break;
          case "6":
            printDepozit(D);
            Console.Read();
            break;
          case "7":
            editDepozit(D, M);
            Console.Read();
            break;
          case "8":
            findDepozit(D);
            Console.Read();
            break;
          case "9":
            removeDepozit(D);
            Console.Read();
            break;
          case "exit":
          case "stop":
          case "x":
            Console.WriteLine("Programul este pe cale sa se inchida; aceasta actiune va anula toate modificarile aduse. Continuati? (da | NU)");
            if (Console.ReadLine().ToLower() != "da")
            {
              break;
            }
            Environment.Exit(1);
            break;
          default:
            Console.WriteLine("Comanda introdusa nu face parte din meniu.");
            Console.Read();
            break;
        }
      }
    }
  }
}
