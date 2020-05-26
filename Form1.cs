using Medicament;
using Depozit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace FarmacieForms
{
    public partial class Form1 : Form
    {
        Medicine Medicament = new Medicine();
        Deposit Depozit = new Deposit(); 

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void afisareMedicamentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void creareMedicamentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine(e);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            findBtn.Focus();
            handleVisibilityForms("find");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            createEditTitle.Text = "Creare Medicament";
            this.clearCreateForm();
            createBtn.Focus();
            handleVisibilityForms("create");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            handleVisibilityForms("compare");

            // Get medicaments
            string result = Depozit.getMedicamente();

            showCompare1.Text = result;
            showCompare2.Text = result;
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            handleVisibilityForms("create");
            createEditTitle.Text = "Editare Medicament";
            editBtn.Focus();

            this.getMedicament();
            handleVisibilityForms("edit");
        }

        private void cancelCreatebtn_Click(object sender, EventArgs e)
        {
            hideAllForms();
            handleMessageCreate.Visible = false;
        }

        private void saveCreateBtn_Click(object sender, EventArgs e)
        {
            string nume = numeTxt.Text;
            string valabilitate = expTxt.Text;
            string gramaj = gramajTxt.Text;
            string interval = intervalTxt.Text;
            string pret = pretTxt.Text;
            string tinta = tintaTxt.Text;
            string scop = scopTxt.Text;

            if (!handleCreateFormErrors())
            {
                handleMessageCreate.Text = "Ati introdus date invalide!";
                handleMessageCreate.Visible = true;
                handleMessageCreate.ForeColor = Color.DarkRed;
                return;
            }

            Medicament = new Medicine(Int32.Parse(interval), Int32.Parse(gramaj), double.Parse(pret), valabilitate, scop, tinta, nume);

            handleMessageCreate.Text = "Medicamentul a fost salvat cu succes!";
            handleMessageCreate.Visible = true;
            handleMessageCreate.ForeColor = Color.DarkGreen;
        }

        private bool handleCreateFormErrors()
        {
            bool isError = false;
            // Nume
            if (isEmpty(numeTxt.Text) || !Medicament.isValidNume(numeTxt.Text))
            {
                numeLbl.ForeColor = Color.DarkRed;
                isError = true;
            } else
            {
                numeLbl.ForeColor = Color.Black;
            }
            // Valabilitate
            if (isEmpty(expTxt.Text) || !Medicament.isValidValabilitate(expTxt.Text))
            {
                expLbl.ForeColor = Color.DarkRed;
                isError = true;
            } else
            {
                expLbl.ForeColor = Color.Black;
            }
            // Gramaj
            if (isEmpty(gramajTxt.Text) || !Medicament.isValidGramaj(Int32.Parse(gramajTxt.Text)))
            {
                gramajLbl.ForeColor = Color.DarkRed;
                isError = true;
            }
            else
            {
                gramajLbl.ForeColor = Color.Black;
            }
            // interval
            if (isEmpty(intervalTxt.Text) || !Medicament.isValidInterval(Int32.Parse(intervalTxt.Text)))
            {
                intervalLbl.ForeColor = Color.DarkRed;
                isError = true;
            }
            else
            {
                intervalLbl.ForeColor = Color.Black;
            }
            // Pret
            if (isEmpty(pretTxt.Text) || !Medicament.isValidPret(double.Parse(pretTxt.Text)))
            {
                pretLbl.ForeColor = Color.DarkRed;
                isError = true;
            }
            else
            {
                pretLbl.ForeColor = Color.Black;
            }
            // Tinta
            if (isEmpty(tintaTxt.Text) || !Medicament.isValidTinta(tintaTxt.Text))
            {
                tintaLbl.ForeColor = Color.DarkRed;
                isError = true;
            }
            else
            {
                tintaLbl.ForeColor = Color.Black;
            }
            // Scop
            if (isEmpty(scopTxt.Text) || !Medicament.isValidScop(scopTxt.Text))
            {
                scopLbl.ForeColor = Color.DarkRed;
                isError = true;
            }
            else
            {
                scopLbl.ForeColor = Color.Black;
            }

            return !isError;
        }

        private void clearCreateForm()
        {
            numeTxt.Text = "";
            expTxt.Text = "";
            gramajTxt.Text = "";
            intervalTxt.Text = "";
            pretTxt.Text = "";
            tintaTxt.Text = "";
            scopTxt.Text = "";
        }

        private void getMedicament()
        {
            numeTxt.Text = Medicament.getNume();
            expTxt.Text = Medicament.getValabilitate();
            gramajTxt.Text = Medicament.getGramaj().ToString();
            intervalTxt.Text = Medicament.getInterval().ToString();
            pretTxt.Text = Medicament.getPret().ToString();
            tintaTxt.Text = Medicament.getTinta();
            scopTxt.Text = Medicament.getScop();
        }

        private bool isEmpty(string input)
        {
            return input == null || input.Length <= 0;
        }

        private bool isValidInputs(string[] inputs)
        {
            for (int i = 0; i < inputs.GetLength(0); i++)
            {
                if (isEmpty(inputs[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private void resetCreateForm_Click(object sender, EventArgs e)
        {
            clearCreateForm();
        }

        private void handleMessageCreate_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void showBtn_Click(object sender, EventArgs e)
        {
            showMedicament.Text = Medicament.ConvertToString();
            showBtn.Focus();
            handleVisibilityForms("show");
        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            if (convertShowMedicament.Text == "To JSON")
            {
                showMedicament.Text = Medicament.ConvertToJson();
                convertShowMedicament.Text = "To TEXT";
            } else
            {
                showMedicament.Text = Medicament.ConvertToString();
                convertShowMedicament.Text = "To JSON";
            }
        }

        private void label1_Click_3(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            hideAllForms();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            showMedicamentAdd.Text = Medicament.ConvertToString();
            handleVisibilityForms("add");
            addBtn.Focus();
            handleMessageAdd.Visible = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (Medicament == null || !Medicament.isValidMedicament())
            {
                handleMessageAdd.Text = "Medicamentul este invalid!";
                handleMessageAdd.Visible = true;
                handleMessageAdd.ForeColor = Color.DarkRed;
                return;
            }

            if (Depozit.existsMedicament(Medicament.getNume()))
            {
                handleMessageAdd.Text = "Medicamentul exista deja in depozit.";
                handleMessageAdd.Visible = true;
                handleMessageAdd.ForeColor = Color.DarkRed;
                return;
            }

            Depozit.setMedicament(Medicament);
            
            if (Depozit.existsMedicament(Medicament.getNume()))
            {
                handleMessageAdd.Text = "Medicamentul a fost adaugat cu succes!";
                handleMessageAdd.Visible = true;
                handleMessageAdd.ForeColor = Color.DarkGreen;
            } else
            {
                handleMessageAdd.Text = "Ups.. Nu s-a putut adauga medicamentul!";
                handleMessageAdd.Visible = true;
                handleMessageAdd.ForeColor = Color.DarkRed;
            }
        }

        private void handleVisibilityForms(string type)
        {
            hideAllForms();
            switch (type.ToLower())
            {
                case "create":
                case "edit":
                    createForm.Visible = true;
                    break;
                case "show":
                    showForm.Visible = true;
                    break;
                case "add":
                    addForm.Visible = true;
                    break;
                case "showall":
                    showAllForm.Visible = true;
                    break;
                case "find":
                    findForm.Visible = true;
                    break;
                case "delete":
                    deleteForm.Visible = true;
                    break;
                case "compare":
                    compareForm.Visible = true;
                    break;
            }
        }
        private void hideAllForms()
        {
            createForm.Visible = false;
            showForm.Visible = false;
            addForm.Visible = false;
            showAllForm.Visible = false;
            findForm.Visible = false;
            deleteForm.Visible = false;
            compareForm.Visible = false;
        }

        private void showAllBtn_Click(object sender, EventArgs e)
        {
            showAllBtn.Focus();
            showAllMedicamente.Text = Depozit.getMedicamente();
            handleVisibilityForms("showAll");
            handleMessageShowAll.Visible = false;
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (convertShowAllMedicamente.Text == "To JSON")
            {
                showAllMedicamente.Text = Depozit.getMedicamenteAsJSON();
                convertShowAllMedicamente.Text = "To TEXT";
            }
            else
            {
                showAllMedicamente.Text = Depozit.getMedicamente();
                convertShowAllMedicamente.Text = "To JSON";
            }
        }

        private void showAllTitle_Click(object sender, EventArgs e)
        {

        }

        private void showAllForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            hideAllForms();
        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            string result = "";

            if (this.handleFindErrors())
            {
                handleMessageFind.Text = "Valoare incorecta!";
                handleMessageFind.Visible = true;
                return;
            } else
            {
                handleMessageFind.Visible = false;
            }

            if (findNume.Checked)
            {
                result += findMedicamenteByName(findNumeTxt.Text);
            }
            if (findPret.Checked)
            {
                result += findMedicamenteByPrice();
            }
            if (findTinta.Checked)
            {
                result += findMedicamenteByTarget();
            }
            if (findGramaj.Checked)
            {
                result += findMedicamenteByGramaj();
            }
            if (findScop.Checked)
            {
                result += findMedicamenteByScop();
            }

            showFindMedicamente.Text = result;
        }
        private string getFindConvertion(Medicine[] Medicamente, string type)
        {
            bool isJSON = type != "text";
            string result = (isJSON ? "{" : "") + Environment.NewLine;

            if (Medicamente.GetLength(0) == 0)
            {
                handleMessageFind.Visible = true;
                handleMessageFind.Text = "Nu s-au gasit medicamente in depozit.";
                return "Nu s-au gasit medicamente in depozit.";
            }

            for (int i = 0; i < Medicamente.GetLength(0); i++)
            {
                bool isLastItem = i + 1 == Medicamente.GetLength(0);

                if (Medicamente[i] == null)
                {
                    return "Nu s-au gasit medicamente in depozit.";
                }

                if (type == "text")
                {
                    result += Medicamente[i].ConvertToString() + Environment.NewLine;
                }
                else
                {
                    result += Medicamente[i].ConvertToJson() + (isLastItem ? "" : ",") + Environment.NewLine;
                }
            }

            return result + (isJSON ? "}" : "");
        }
        private string findMedicamenteByName(string text, string type = "text")
        {
            Medicine[] Medicamente = Depozit.findMedicamenteByNume(text);

            return getFindConvertion(Medicamente, type);
        }
        private string findMedicamenteByPrice(string type = "text")
        {
            Medicine[] Medicamente = Depozit.findMedicamenteByPret(double.Parse(findPret1.Text), double.Parse(findPret2.Text));

            return getFindConvertion(Medicamente, type);
        }
        private string findMedicamenteByTarget(string type = "text")
        {
            Medicine[] Medicamente = Depozit.findMedicamenteByTinta(findTintaTxt.Text);

            return getFindConvertion(Medicamente, type);
        }
        private string findMedicamenteByGramaj(string type = "text")
        {
            Medicine[] Medicamente = Depozit.findMedicamenteByGramaj(Int32.Parse(findGramaj1.Text), Int32.Parse(findGramaj2.Text));

            return getFindConvertion(Medicamente, type);
        }
        private string findMedicamenteByScop(string type = "text")
        {
            Medicine[] Medicamente = Depozit.findMedicamenteByScop(findScopTxt.Text);

            return getFindConvertion(Medicamente, type);
        }

        private void resetFindForm()
        {
            findNumeTxt.Text = "";
            findPret1.Text = "";
            findPret2.Text = "0";
            findTintaTxt.Text = "";
            findGramaj1.Text = "";
            findGramaj2.Text = "0";
            findScopTxt.Text = "";
            handleMessageFind.Visible = false;
            showFindMedicamente.Text = "";
        }

        private bool handleFindErrors()
        {
            bool isError = false;
            // Nume
            if (findNume.Checked && (isEmpty(findNumeTxt.Text) || !Medicament.isValidNume(findNumeTxt.Text)))
            {
                findNumeLbl.ForeColor = Color.DarkRed;
                isError = true;
            }
            else
            {
                findNumeLbl.ForeColor = Color.Black;
            }
            // Gramaj
            if (
                findGramaj.Checked && (
                    isEmpty(findGramaj1.Text) || !Medicament.isValidGramaj(Int32.Parse(findGramaj1.Text)) || 
                    (Medicament.isValidGramaj(Int32.Parse(findGramaj2.Text)) && Int32.Parse(findGramaj1.Text) > Int32.Parse(findGramaj2.Text))
                )
            )
            {
                findGramajLbl.ForeColor = Color.DarkRed;
                isError = true;
            }
            else
            {
                findGramajLbl.ForeColor = Color.Black;
            }
            // Pret
            if (
                findPret.Checked && (
                    isEmpty(findPret1.Text) || !Medicament.isValidPret(double.Parse(findPret1.Text)) || 
                    (Medicament.isValidPret(double.Parse(findPret1.Text)) && double.Parse(findPret1.Text) > double.Parse(findPret1.Text))
                )
            )
            {
                findPretLbl.ForeColor = Color.DarkRed;
                isError = true;
            }
            else
            {
                findPretLbl.ForeColor = Color.Black;
            }
            // Tinta
            if (findTinta.Checked && (isEmpty(findTintaTxt.Text) || !Medicament.isValidTinta(findTintaTxt.Text)))
            {
                findTintaLbl.ForeColor = Color.DarkRed;
                isError = true;
            }
            else
            {
                findTintaLbl.ForeColor = Color.Black;
            }
            // Scop
            if (findScop.Checked && (isEmpty(findScopTxt.Text) || !Medicament.isValidScop(findScopTxt.Text)))
            {
                findScopLbl.ForeColor = Color.DarkRed;
                isError = true;
            }
            else
            {
                findScopLbl.ForeColor = Color.Black;
            }

            return isError;
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            resetFindForm();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (convertFindBtn.Text == "To JSON")
            {
                showAllMedicamente.Text = Depozit.getMedicamenteAsJSON();
                convertFindBtn.Text = "To TEXT";
            }
            else
            {
                showAllMedicamente.Text = Depozit.getMedicamente();
                convertFindBtn.Text = "To JSON";
            }
            bool isJSON = convertFindBtn.Text == "To JSON";

            string result = isJSON ? "{" : "";

            if (findNume.Checked)
            {
                result += findMedicamenteByName("json");
            }
            if (findPret.Checked)
            {
                result += findMedicamenteByPrice("json");
            }
            if (findTinta.Checked)
            {
                result += findMedicamenteByTarget("json");
            }
            if (findGramaj.Checked)
            {
                result += findMedicamenteByGramaj("json");
            }
            if (findScop.Checked)
            {
                result += findMedicamenteByScop("json");
            }

            showFindMedicamente.Text = result + (isJSON ? "}" : "");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // TODO: Save into a file the Medicaments from deposit.
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            // TODO: Save into a file the Medicament (single one)
        }

        private void button6_Click_2(object sender, EventArgs e)
        {
            deleteNumeTxt.Text = "";
            deleteConfirm.Checked = false;
            showDeleteMedicament.Text = "";
            handleDeleteMessage.Visible = false;
            deleteForm.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!deleteConfirm.Checked)
            {
                deleteConfirm.ForeColor = Color.DarkRed;
                handleDeleteMessage.Visible = true;
                handleDeleteMessage.Text = "Confirmati stergerea medicamentului!";
                return;
            }

            Medicine[] Medicamente = Depozit.findMedicamenteByNume(deleteNumeTxt.Text);
            if (Medicamente.GetLength(0) > 1 && !Depozit.existsMedicament(deleteNumeTxt.Text))
            {
                deleteNumeLbl.ForeColor = Color.DarkRed;
                handleDeleteMessage.Visible = true;
                handleDeleteMessage.Text = "Tastati numele complet al medicamentului.";
                deleteMedicamentBtn.Enabled = false;
                return;
            }

            Depozit.removeMedicament(Medicamente[0].getNume());

            handleDeleteMessage.Visible = true;
            handleDeleteMessage.Text = "Medicamentul a fost sters cu succes!";
            handleDeleteMessage.ForeColor = Color.DarkGreen;

            // Update the list of the medicine
            string result = findMedicamenteByName(deleteNumeTxt.Text);

            showDeleteMedicament.Text = result;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string result;

            if (convertDeleteBtn.Text == "To JSON")
            {
                result = findMedicamenteByName(deleteNumeTxt.Text, "json");
                convertDeleteBtn.Text = "To TEXT";
            }
            else
            {
                result = findMedicamenteByName(deleteNumeTxt.Text);
                convertDeleteBtn.Text = "To JSON";
            }

            if (result.Length == 0)
            {
                handleDeleteMessage.Visible = true;
                handleDeleteMessage.Text = "Nu s-au gasit medicamente.";
                showDeleteMedicament.Text = "Medicamentul cautat nu a fost gasit in depozit. Ati tastat gresit numele?";
                deleteNumeLbl.ForeColor = Color.IndianRed;
            }
            else
            {
                handleDeleteMessage.Visible = false;
                showDeleteMedicament.Text = result;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // DONE: Save before delete
            Medicine[] Medicamente = Depozit.findMedicamenteByNume(deleteNumeTxt.Text);

            if (Medicamente.GetLength(0) > 0 && !Medicamente[0].isValidMedicament())
            {
                handleMessageTypeDelete("Medicamentul este invalid.", Color.DarkRed);
                return;
            }

            string type = convertDeleteBtn.Text == "To JSON" ? "text" : "json";
            string[] name = Medicamente[0].getNume().Split(' ');
            string path = String.Join("_", name);
            string text = type == "text" ? Medicamente[0].ConvertToString() : Medicamente[0].ConvertToJson();

            string result = saveTextToFile(path, text, type);

            switch (result)
            {
                case "exists":
                    handleMessageTypeDelete("Exista deja un fisier cu numele `" + path + "`.", Color.DarkRed);
                    break;
                case "saved":
                    handleMessageTypeDelete("Medicamentul s-a salvat in fisierul `" + path + "`.", Color.DarkGreen);
                    break;
                case "error":
                // break;
                default:
                    handleMessageTypeDelete("Ups... A aparut o eroare!", Color.DarkRed);
                    break;
            }
        }
        private void handleMessageTypeDelete(string text, Color color)



        {
            handleDeleteMessage.Visible = true;
            handleDeleteMessage.Text = text;
            handleDeleteMessage.ForeColor = color;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            handleVisibilityForms("delete");
        }

        private void deleteNumeTxt_TextChanged(object sender, EventArgs e)
        {
            if (deleteNumeTxt.Text.Length == 0)
            {
                deleteNumeLbl.ForeColor = Color.DarkRed;
                handleDeleteMessage.Visible = true;
                handleDeleteMessage.Text = "Tastati numele medicamentului.";
                deleteMedicamentBtn.Enabled = false;
                return;
            }

            if (deleteConfirm.Checked && deleteNumeTxt.Text.Length > 0)
            {
                deleteMedicamentBtn.Enabled = true;
            }
            else
            {
                deleteNumeLbl.ForeColor = Color.Black;
                handleDeleteMessage.Visible = false;
                deleteMedicamentBtn.Enabled = false;
            }

            string result = findMedicamenteByName(deleteNumeTxt.Text);

            if (result.Length == 0)
            {
                handleDeleteMessage.Visible = true;
                handleDeleteMessage.Text = "Nu s-au gasit medicamente.";
                showDeleteMedicament.Text = "Medicamentul cautat nu a fost gasit in depozit. Ati tastat gresit numele?";
                deleteNumeLbl.ForeColor = Color.IndianRed;
            } else
            {
                handleDeleteMessage.Visible = false;
                showDeleteMedicament.Text = result;
            }
        }

        private void deleteConfirm_CheckedChanged(object sender, EventArgs e)
        {
            deleteConfirm.ForeColor = Color.Black;
            if (deleteConfirm.Checked && deleteNumeTxt.Text.Length > 0)
            {
                deleteMedicamentBtn.Enabled = true;
            } else
            {
                deleteMedicamentBtn.Enabled = false;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void compareNume1Txt_TextChanged(object sender, EventArgs e)
        {
            if (compareNume1Txt.Text.Length == 0)
            {
                showCompare1.Text = Depozit.getMedicamente();
                compareNume1Lbl.ForeColor = Color.DarkRed;
                return;
            } else
            {
                showCompare1.Text = findMedicamenteByName(compareNume1Txt.Text);
                return;
            }
        }

        private void compareNume2Txt_TextChanged(object sender, EventArgs e)
        {
            if (compareNume2Txt.Text.Length == 0)
            {
                showCompare2.Text = Depozit.getMedicamente();
                compareNume2Lbl.ForeColor = Color.DarkRed;
                return;
            }
            else
            {
                showCompare2.Text = findMedicamenteByName(compareNume2Txt.Text);
                return;
            }
        }

        private void button1_Click_4(object sender, EventArgs e)
        {
            string saveFileAs = convertFindBtn.Text == "To JSON" ? ".json" : ".txt";

            if (!Medicament.isValidMedicament()) {
                return;
            }

            string path = "./" + Medicament.getNume() + saveFileAs;
            string text = saveFileAs == ".txt" ? Medicament.ConvertToString() : Medicament.ConvertToJson();

            File.WriteAllText(path, text);
        }

        private void button7_Click_3(object sender, EventArgs e)
        {
            resetFindForm();
            findForm.Visible = false;
        }

        private string saveTextToFile(string path, string text, string type = "text")
        {
            string saveFileAs = type == "text" ? ".txt" : ".json";
            string dir = Path.GetDirectoryName(Application.ExecutablePath);
            path = dir + "\\" + path + saveFileAs;

            if (File.Exists(path))
            {
                return "exists";
            }

            File.WriteAllText(path, text);

            return File.Exists(path) ? "saved" : "error";
        }

        private void button1_Click_5(object sender, EventArgs e)
        {
            if (!Medicament.isValidMedicament())
            {
                handleMessageTypeShow("Medicamentul este invalid.", Color.DarkRed);
                return;
            }

            string type = convertShowMedicament.Text == "To JSON" ? "text" : "json";
            string[] name = Medicament.getNume().Split(' ');
            string path = String.Join("_", name);
            string text = type == "text" ? Medicament.ConvertToString() : Medicament.ConvertToJson();

            string result = saveTextToFile(path, text, type);

            switch(result)
            {
                case "exists":
                    handleMessageTypeShow("Exista deja un fisier cu numele `" + path + "`.", Color.DarkRed);
                    break;
                case "saved":
                    handleMessageTypeShow("Medicamentul s-a salvat in fisierul `" +  path + "`.", Color.DarkGreen);
                    break;
                case "error":
                    // break;
                default:
                    handleMessageTypeShow("Ups... A aparut o eroare!", Color.DarkRed);
                    break;
            }
        }
        private void handleMessageTypeShow(string text, Color color) {
            handleMessageShow.Visible = true;
            handleMessageShow.Text = text;
            handleMessageShow.ForeColor = color;
        }
    }
}
