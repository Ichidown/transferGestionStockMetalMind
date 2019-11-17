using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace transferGestionStockMetalMind
{
    public partial class Form1 : Form
    {
        public String[] months ={"Janvier", "février", "mars", "avril", "mai", "juin", "juillet", "août", "septembre", "octobre", "novembre", "décembre" };
        String codeChantier;
        FolderBrowserDialog FileBrowser = new FolderBrowserDialog();
        String WriteCommand, DeleateCommand;
        int InsertCount;
        OleDbConnection SourceConnectionHandler,TargetConnectionHandler,DeleteConnectionHandler;
        OleDbCommand GetDataQuery,insertCommand,ClearDataQuery;
        DataTable ResultSet;

        private String[] codes = new String[50];

        public Form1()
        {
            InitializeComponent();
            initialiseData();
        }
        



        // Main Code ----------------------------------------------------------------

        private void initialiseData()
        {
            for (int j = 0; j < months.Length; j++)
            {
                // populate Ui
                MonthsComboBoxStart.Items.Add(months[j]);
                MonthsComboBoxEnd.Items.Add(months[j]);
                Label MonthLabel = new Label();
                MonthLabel.Text = "* " + months[j];
                MonthsListView.Items.Add(months[j]);

                // properties check
                if (Properties.Settings.Default.MonthsDone == null)
                    Properties.Settings.Default.MonthsDone = new bool[12];
                // color Ui depending on months done
                if (Properties.Settings.Default.MonthsDone[j])
                    MonthsListView.Items[j].ForeColor = Color.Green;
                else
                    MonthsListView.Items[j].ForeColor = Color.Red;
            }
        }

        private void TransferData(String MMFilePath, String codeChantier, String Month)
        {

            //Console.WriteLine(Month);
            SourceConnectionHandler = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+ MMFilePath + ";Extended Properties=dBASE IV;User ID=Admin;Password=;");
            ResultSet = new DataTable();

            // Open the connection, and if open successfully, you can try to query it
            SourceConnectionHandler.Open();
            // collect TargetFolder relevant DATA from Source Folder
            if (SourceConnectionHandler.State == ConnectionState.Open)
            {
                GetDataQuery = new OleDbCommand("select * from FMVT.DBF WHERE CTC='93" + codeChantier + "00' AND COP='S' AND DMV LIKE '__" + Month + "%' ; ", SourceConnectionHandler);
                //GetDataQuery = new OleDbCommand("select * from FMVT.DBF WHERE SUBSTR (CTC, 0, 2) = '93' AND SUBSTRING (CTC, 2, 5) LIKE '" + codeChantier + "' AND COP='S' AND DMV LIKE '__" + Month + "%' ; ", SourceConnectionHandler);
                new OleDbDataAdapter(GetDataQuery).Fill(ResultSet);
                SourceConnectionHandler.Close();
            }

            InsertCount = 0;
            if (ResultSet.Rows.Count > 0) // if found any relevant data to transfer
            {

                // deleate related data from current folder (to avoid duplication)
                DeleteConnectionHandler = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ChantierPathTxt.Text + "\\" + codeChantier + ";Extended Properties=dBASE IV;User ID=Admin;Password=;");
                ClearDataQuery = new OleDbCommand("DELETE from FMVT.DBF WHERE CTC='93" + codeChantier + "00' AND COP='E' AND DMV LIKE '__" + Month + "%' ; ", DeleteConnectionHandler);
                DeleteConnectionHandler.Open();
                if (DeleteConnectionHandler.State == ConnectionState.Open)
                {
                    try {ClearDataQuery.ExecuteNonQuery();}
                    catch (Exception e){
                        ShowFatalErrorMessage("Veuillez quitter tout les fichier .dbf ouvert : "+e.Message);
                    }
                    finally { DeleteConnectionHandler.Close();}
                }


                // get data from MetalMind file related to current folder
                TargetConnectionHandler = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ChantierPathTxt.Text + "\\" + codeChantier + ";Extended Properties=dBASE IV;User ID=Admin;Password=;");
                foreach (DataRow row in ResultSet.Rows) 
                {
                    WriteCommand = "INSERT INTO FMVT.DBF ( COP, NBON , CART, DMV, QMV, PMV, CTC, CCF, IMP ) VALUES ( 'R', ? , ?, ?, ?, ?, ?, ?, ? ); ";

                    insertCommand = new OleDbCommand(WriteCommand, TargetConnectionHandler);
                    insertCommand.Parameters.Add("NBON", OleDbType.Char).Value = row["NBON"];
                    insertCommand.Parameters.Add("CART", OleDbType.Char).Value = row["CART"];
                    insertCommand.Parameters.Add("DMV", OleDbType.Char).Value = row["DMV"];
                    insertCommand.Parameters.Add("QMV", OleDbType.Double).Value = row["QMV"];
                    insertCommand.Parameters.Add("PMV", OleDbType.Double).Value = row["PMV"];
                    insertCommand.Parameters.Add("CTC", OleDbType.Char).Value = row["CTC"];
                    insertCommand.Parameters.Add("CCF", OleDbType.Char).Value = row["CCF"];
                    insertCommand.Parameters.Add("IMP", OleDbType.Char).Value = row["IMP"];

                    TargetConnectionHandler.Open();
                    if (TargetConnectionHandler.State == ConnectionState.Open)
                    {
                        try{
                            insertCommand.ExecuteNonQuery();
                            InsertCount++;
                        }
                        catch (Exception e) {
                            ShowMessage("Erreur d'ecriture : "+ insertCommand.CommandText + "            "+ codeChantier+
                     "  NBON "+ row["NBON"]+
                     "  CART "+ row["CART"]+
                     "  DMV "+ row["DMV"]+
                     "  QMV "+ row["QMV"]+
                     "  PMV "+ row["PMV"]+
                     "  CTC "+ row["CTC"]+
                     "  CCF "+ row["CCF"]+
                     "  IMP "+ row["IMP"]
                            );
                        }
                        finally{ TargetConnectionHandler.Close(); }
                    }
                }
                
            }
            PushToConsole("Chantier '" + codeChantier + "' fini avec " + InsertCount + " Insertion au mois de " + Int32.Parse(Month) );
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            

        }




        // User Events --------------------------------------------------------------

        private void MMBtn_Click(object sender, EventArgs e)
        {
            MMPathTxt.Text = OpenFileBrowser("Choisissez le chemin du dossier MetalMind");
        }

        private void ChantierBtn_Click(object sender, EventArgs e)
        {
            ChantierPathTxt.Text = OpenFileBrowser("Choisissez le chemin des dossiers chantier");
        }

        private void TransferBtn_Click(object sender, EventArgs e)
        {
            // form validation
            if (MMPathTxt.Text == "" || ChantierPathTxt.Text == "")
            {
                ShowMessage("veillez selectionner les repertoires");
            }
            else if (MonthsComboBoxStart.SelectedIndex == -1 || MonthsComboBoxEnd.SelectedIndex == -1)
            {
                ShowMessage("veillez selectionner les dates");
            }
            else if (MonthsComboBoxStart.SelectedIndex > MonthsComboBoxEnd.SelectedIndex)
            {
                ShowMessage("veillez rectifier la selection des dates");
            }
            else
            {
                if (File.Exists(@MMPathTxt.Text + "\\FMVT.DBF"))// if MetalMind file exist
                {
                    setInputEnabled(false);//disable input

                    // foreach folder Name == nom chantier
                    foreach (string folderPath in Directory.GetDirectories(@ChantierPathTxt.Text))
                    {
                        codeChantier = folderPath.Remove(0, folderPath.LastIndexOf("\\") + 1);// get folder name
                        //Console.WriteLine();
                        if (File.Exists(folderPath + "\\FMVT.DBF")) // if ChantierX file exist
                        {
                            //Console.WriteLine(MonthsComboBoxEnd.SelectedIndex - MonthsComboBoxStart.SelectedIndex + 1);
                            if (MonthsComboBoxStart.SelectedIndex != MonthsComboBoxEnd.SelectedIndex)
                            for (int m = MonthsComboBoxStart.SelectedIndex+1; m < MonthsComboBoxEnd.SelectedIndex+2; m++)
                            {
                                //Console.WriteLine(m);
                                
                                if(m < 10)
                                    TransferData(@MMPathTxt.Text, codeChantier, '0' + m.ToString()); // all this to add to numbers less than 10 a '0'
                                else
                                    TransferData(@MMPathTxt.Text, codeChantier, m.ToString()); // all this to add to numbers less than 10 a '0'
                                

                                //TransferData(@MMPathTxt.Text, codeChantier, m < 10 ? ('0' + m.ToString()) : (m.ToString())); // all this to add to numbers less than 10 a '0'
                                Properties.Settings.Default.MonthsDone[m-1] = true;
                                MonthsListView.Items[m-1].ForeColor = Color.Green;
                            }
                            else
                            {
                                //Console.WriteLine(MonthsComboBoxStart.SelectedIndex+1);
                                
                                if(MonthsComboBoxStart.SelectedIndex + 1 < 10)
                                    TransferData(@MMPathTxt.Text, codeChantier, '0' + (MonthsComboBoxStart.SelectedIndex + 1).ToString()); // all this to add to numbers less than 10 a '0'
                                else
                                    TransferData(@MMPathTxt.Text, codeChantier, (MonthsComboBoxStart.SelectedIndex + 1).ToString()); // all this to add to numbers less than 10 a '0'
                                

                                //TransferData(@MMPathTxt.Text, codeChantier, m < 10 ? ('0' + m.ToString()) : (m.ToString())); // all this to add to numbers less than 10 a '0'
                                Properties.Settings.Default.MonthsDone[MonthsComboBoxStart.SelectedIndex ] = true;
                                MonthsListView.Items[MonthsComboBoxStart.SelectedIndex].ForeColor = Color.Green;
                            }
                        }
                        else
                        {
                            PushToConsole("Fichier FMVT du Chantier/dossier \"" + codeChantier + "\" inexistant");
                        }
                    }
                    Properties.Settings.Default.Save();
                    setInputEnabled(true);//enable input
                }
                else
                {
                    ShowMessage("Fichier MetalMind inexistant");
                }
            }
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            if (ShowConfirmatiomMessage("Êtes-vous sûr de vouloir reinitialiser ?",""))
            {
                for (int i = 0; i < Properties.Settings.Default.MonthsDone.Length; i++)
                {
                    Properties.Settings.Default.MonthsDone[i] = false;
                    MonthsListView.Items[i].ForeColor = Color.Red;
                }
                Properties.Settings.Default.Save();
            }
        }




        // UI -----------------------------------------------------------------------

        // Show Msg in pop up
        private void ShowMessage(String message, String title = "Erreur")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowFatalErrorMessage(String message, String title = "Erreur")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }

        // Show confirmation Msg in pop up
        private bool ShowConfirmatiomMessage(String message, String title = "Erreur")
        {
            if (MessageBox.Show(message, title,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                return true;
            else
                return false;
        }

        // Print int console
        private void PushToConsole(String message)
        {
            ConsoleListBox.Items.Add(message);
        }

        // Show file browser
        private String OpenFileBrowser(String description, String initialPath = "C:\\")
        {
            FileBrowser.SelectedPath = @initialPath;
            FileBrowser.Description = description;
            if (FileBrowser.ShowDialog() == DialogResult.OK)
            {
                return FileBrowser.SelectedPath;
            }
            else
            {
                return "";
            }
        }

        // Enable or disable input
        private void setInputEnabled(bool isEnabled)
        {
            MonthsComboBoxStart.Enabled = isEnabled;
            MonthsComboBoxEnd.Enabled = isEnabled;
            MMBtn.Enabled = isEnabled;
            ChantierBtn.Enabled = isEnabled;
            TransferBtn.Enabled = isEnabled;
            resetBtn.Enabled = isEnabled;
        }
    }
}
