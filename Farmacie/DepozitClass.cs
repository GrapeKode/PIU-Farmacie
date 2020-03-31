using System;

namespace Farmacie
{
  public class Depozit
  {
    // date membre private
    string[] medicamente; // Medicamente convertite la string
    string[] nume; // Indexare dupa nume
    // int[] stoc; // Numarul de produse disponibile
    int index;

    // Constructors
    public Depozit()
    {
      index = 0;
      nume = new string[100];
      nume[0] = "unknown";
      medicamente = new string[100];
      medicamente[0] = "unknown";

    }
    public Depozit(string _medicament, string _nume)
    {
      medicamente = new string[100];
      medicamente[0] = _medicament;
      nume = new string[100];
      nume[0] = _nume.ToLower();
      index = 1;
    }

    // Setters
    public void setMedicament(string _medicament, string _nume)
    {
      medicamente[index] = _medicament;
      nume[index] = _nume.ToLower();
      index += 1;
    }
    public void editMedicament(string _medicament, string _nume) // Edit medicament
    {
      int editIndex = findNume(_nume);
      if (editIndex == -1)
      {
        Console.WriteLine("Medicamentul nu a fost gasit.");
      }
      else
      {
        medicamente[editIndex] = _medicament;
        nume[editIndex] = _nume.ToLower();
        Console.WriteLine("Medicamentul [" + _nume + "] a fost adaugat cu succes.");
      }
    }

    // Getters
    public string getMedicamente() {
      string result = "\n";

      if (isEmptyDepozit())
      {
        return "undefined";
      }

      for (int i = 0; i < index; i++)
      {
        result += medicamente[i] + (i + 1 != index ? "\n\n---------------------------------------------------------\n\n" : "\n\n");
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
    public string findMedicament(string _nume) // Find medicament
    {
      int findIndex = findNume(_nume);
      if (findIndex == -1)
      {
        return "Medicamentul [" + _nume + "] nu a fost gasit.";
      }

      return medicamente[findIndex];
    }
    public bool existsMedicament(string _nume) { return findNume(_nume) > -1; }

    // Validations
    private bool isEmptyArray(string[] _arr) { return _arr.GetLength(0) > 0; }
    private int findNume(string _nume)
    {
      if (!isEmptyArray(nume))
      {
        return -1;
      }
      for (int i = 0; i < nume.Length; i++)
      {
        if (nume[i] == _nume.ToLower())
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
