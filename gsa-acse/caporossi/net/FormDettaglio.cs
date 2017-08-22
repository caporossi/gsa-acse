using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gsa_acse.caporossi.net
{
    public partial class FormDettaglio : Form
    {
        private bool _nuovatessera = false;
        private string _NTessera;
        private string _NomeFoto = null;
        private int _IDFamiliareSelect;

        public FormDettaglio(string NTessera, string VecchiaFoto)
        {
            Log.Instance.Info("Apro Form dettaglio per scheda " + NTessera + " e vecchiafoto " + VecchiaFoto);
            _NTessera = NTessera;
            InitializeComponent();
            try
            {
                if (File.Exists(ConfigParam.GetFotoPath() + VecchiaFoto))
                {
                    pictureFoto.Image?.Dispose();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    FileInfo f = new FileInfo(ConfigParam.GetFotoPath() + VecchiaFoto);
                    f.Delete();
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error(ex, "Errore in caricamento form Dettaglio");
            }
            LoadData();
        }

        public FormDettaglio(string NTessera)
        {
            Log.Instance.Info("Apro Form dettaglio per scheda " + NTessera);
            _NTessera = NTessera;
            InitializeComponent();
            LoadData();
        }

        public FormDettaglio()
        {
            Log.Instance.Info("Apro Form dettaglio per scheda Nuova");
            _nuovatessera = true;
            InitializeComponent();
            LoadData();
            txtNumeroTessera.Enabled = true;
            btnCattura.Enabled = false;
            btnElimina.Enabled = false;
            int temp = RecuperoTessera();
            _NTessera = temp.ToString();
            //_NTessera = NTessera;
            txtNumeroTessera.Text = _NTessera;
        }

        private int  RecuperoTessera()
        {
            int risultato = 0;
            DBUtils d = new DBUtils();
            d.setConnection();
            d.OpenConnection();
            string sql = "SELECT MAX(Ntessera) as ID FROM Clienti";
            SQLiteCommand cmd = new SQLiteCommand(sql, d.m_dbConnection);
            SQLiteDataReader reader;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                var t = reader["ID"];
                if (t == DBNull.Value)
                {
                    risultato = 0;
                }
                else
                {
                    risultato = int.Parse(reader["ID"].ToString());
                }
            }
            reader.Close();
            d.CloseConnection();
            return risultato + 1;
        }

        private void LoadData()
        {
            DBUtils d = new DBUtils();
            d.setConnection();
            d.OpenConnection();
            string strCmd = "select id, Name from Countries";
            SQLiteCommand cmd = null;
            SQLiteDataAdapter da = null;
            DataSet ds = null;
            try
            {

                cmd = new SQLiteCommand(strCmd, d.m_dbConnection);
                da = new SQLiteDataAdapter(strCmd, d.m_dbConnection);
                ds = new DataSet();
                da.Fill(ds);
                cbNazionalita.DataSource = ds.Tables[0];
                cbNazionalita.DisplayMember = "Name";
                cbNazionalita.ValueMember = "Name";
                cbNazionalita.Enabled = true;
                cbNazionalita.SelectedIndex = -1;
                cmd.ExecuteNonQuery();

                cmd = new SQLiteCommand(strCmd, d.m_dbConnection);
                da = new SQLiteDataAdapter(strCmd, d.m_dbConnection);
                ds = new DataSet();
                da.Fill(ds);
                cbNazione.DataSource = ds.Tables[0];
                cbNazione.DisplayMember = "Name";
                cbNazione.ValueMember = "Name";
                cbNazione.Enabled = true;
                cbNazione.SelectedIndex = -1;
                cmd.ExecuteNonQuery();

                cmd = new SQLiteCommand(strCmd, d.m_dbConnection);
                da = new SQLiteDataAdapter(strCmd, d.m_dbConnection);
                ds = new DataSet();
                da.Fill(ds);
                cbFamiliareNazionalita.DataSource = ds.Tables[0];
                cbFamiliareNazionalita.DisplayMember = "Name";
                cbFamiliareNazionalita.ValueMember = "Name";
                cbFamiliareNazionalita.Enabled = true;
                cbFamiliareNazionalita.SelectedIndex = -1;
                cmd.ExecuteNonQuery();

                cmd = new SQLiteCommand(strCmd, d.m_dbConnection);
                da = new SQLiteDataAdapter(strCmd, d.m_dbConnection);
                ds = new DataSet();
                da.Fill(ds);
                cbFamiliareNazione.DataSource = ds.Tables[0];
                cbFamiliareNazione.DisplayMember = "Name";
                cbFamiliareNazione.ValueMember = "Name";
                cbFamiliareNazione.Enabled = true;
                cbFamiliareNazione.SelectedIndex = -1;
                cmd.ExecuteNonQuery();

                strCmd = "select id, Tipo from Religioni";
                cmd = new SQLiteCommand(strCmd, d.m_dbConnection);
                da = new SQLiteDataAdapter(strCmd, d.m_dbConnection);
                ds = new DataSet();
                da.Fill(ds);
                cbReligione.DataSource = ds.Tables[0];
                cbReligione.DisplayMember = "Tipo";
                cbReligione.ValueMember = "Tipo";
                cbReligione.Enabled = true;
                cbReligione.SelectedIndex = -1;
                cmd.ExecuteNonQuery();
                    
                strCmd = "select id, Descrizione from Parentela";
                cmd = new SQLiteCommand(strCmd, d.m_dbConnection);
                da = new SQLiteDataAdapter(strCmd, d.m_dbConnection);
                ds = new DataSet();
                da.Fill(ds);
                cbFamiliareRapporto.DataSource = ds.Tables[0];
                cbFamiliareRapporto.DisplayMember = "Descrizione";
                cbFamiliareRapporto.ValueMember = "Descrizione";
                cbFamiliareRapporto.Enabled = true;
                cbFamiliareRapporto.SelectedIndex = -1;
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Log.Instance.Error(ex, "Errore durante il popolamento dei dati dal DB");
            }
            d.CloseConnection();
        }

        private void btnCattura_Click(object sender, EventArgs e)
        {
            Log.Instance.Debug("Click s bottone Cattura img");
            var fImage = new FormCatturaIMG(_NTessera);
            fImage.RefToFormDettaglio = this;
            fImage.Show();
            this.Hide();
            this.Dispose();
            //this.Visible = false;

        }

        private void aggiornaContenuto()
        {
            DBUtils d = new DBUtils();
            d.setConnection();
            d.OpenConnection();
            string sql =
                "SELECT Clienti.*,Foto.Nomefile FROM Clienti INNER JOIN Foto ON Clienti.NTessera = Foto.NTessera WHERE Clienti.NTessera =" +
                _NTessera + ";";
            SQLiteCommand cmd = new SQLiteCommand(sql, d.m_dbConnection);
            SQLiteDataReader reader;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtNumeroTessera.Text = reader["NTessera"].ToString();
                txtCognome.Text = reader["Cognome"].ToString();
                txtNome.Text = reader["Nome"].ToString();
                txtLuogoNascita.Text = reader["LuogoNascita"].ToString();
                String temp = reader["DataNascita"].ToString();
                if (!string.IsNullOrEmpty(temp))
                {
                    dateTime.Value = Convert.ToDateTime(reader["DataNascita"].ToString());
                }
                else
                {
                    dateTime.Value = dateTime.MinDate;
                }
                if (reader["MF"].ToString() == "M")
                {
                    rbM.Checked = true;
                    rbF.Checked = false;
                }
                else
                {
                    rbM.Checked = false;
                    rbF.Checked = true;
                }
                cbNazione.SelectedIndex = cbNazione.FindStringExact(reader["Nazione"].ToString());
                cbNazionalita.SelectedIndex = cbNazionalita.FindStringExact(reader["Nazionalita"].ToString());
                cbReligione.SelectedIndex = cbReligione.FindStringExact(reader["Religione"].ToString());
                if (reader["StatoCivile"].ToString() == "Celibe/Nubile")
                {
                    rbCelibe.Checked = true;
                }
                else if (reader["StatoCivile"].ToString() == "Coniugato/a")
                {
                    rbConiugato.Checked = true;
                }
                else if (reader["StatoCivile"].ToString() == "Separato/a")
                {
                    rbSeparato.Checked = true;
                }
                else if (reader["StatoCivile"].ToString() == "Convivente")
                {
                    rbConvivente.Checked = true;
                }
                else if (reader["StatoCivile"].ToString() == "Vedovo/a")
                {
                    rbVedovo.Checked = true;
                }
                else if (reader["StatoCivile"].ToString() == "Divorziato/a")
                {
                    rbDivorziato.Checked = true;
                }
                txtDocumento.Text = reader["Documento"].ToString();
                txtCodiceFiscale.Text = reader["CF"].ToString();
                txtCitta.Text = reader["DimoraCitta"].ToString();
                txtVia.Text = reader["DimoraVia"].ToString();
                txtNumero.Text = reader["DimoraCivico"].ToString();
                txtTelefono.Text = reader["Telefono"].ToString();
                if (reader.IsDBNull(reader.GetOrdinal("Disabile")))
                {
                    chkDisabile.Checked = false;
                }
                else if(reader.GetInt32(reader.GetOrdinal("Disabile")) == 1)
                {
                    chkDisabile.Checked = true;
                }
                if (reader.IsDBNull(reader.GetOrdinal("ISEE")))
                {
                    chkISEE.Checked = false;
                }
                else if (reader.GetInt32(reader.GetOrdinal("ISEE")) == 1)
                {
                    chkISEE.Checked = true;
                }
                DateTime Dt = new DateTime();
                DateTime newDt;
                if (reader.IsDBNull(reader.GetOrdinal("ISEEAnno")))
                {
                    newDt = DateTime.Now;
                }
                else
                {
                    newDt = new DateTime(int.Parse(reader["ISEEAnno"].ToString()), Dt.Month, Dt.Day);
                }
                dtISEE.Value = newDt;
                txtReddito.Text = reader["ISEEReddito"].ToString();
                if (reader.IsDBNull(reader.GetOrdinal("PermSoggiorno")))
                {
                    chkPermSoggiorno.Checked = false;
                    dtEmissionePermSogg.Enabled = false;
                    dtScadenzaPermSogg.Enabled = false;
                }
                else if (reader.GetInt32(reader.GetOrdinal("PermSoggiorno")) == 1)
                {
                    chkPermSoggiorno.Checked = true;
                    dtEmissionePermSogg.Enabled = true;
                    dtScadenzaPermSogg.Enabled = true;
                }
                if (reader.IsDBNull(reader.GetOrdinal("EmissionePermSoggiorno")))
                {
                    dtEmissionePermSogg.Value = dtEmissionePermSogg.MinDate;
                }
                else
                {
                    dtEmissionePermSogg.Value = Convert.ToDateTime(reader["EmissionePermSoggiorno"].ToString());
                }
                if (reader.IsDBNull(reader.GetOrdinal("ScadenzaPermSoggiorno")))
                {
                    dtScadenzaPermSogg.Value = dtScadenzaPermSogg.MinDate;
                }
                else
                {
                    dtScadenzaPermSogg.Value = new DateTime(int.Parse(reader["ScadenzaPermSoggiorno"].ToString()),Dt.Month, Dt.Day);
                }
                //dtScadenzaPermSogg.Value = newDt;
                if (reader["Pacco"].ToString() == "Singolo")
                {
                    rbSingolo.Checked = true;
                }
                else if (reader["Pacco"].ToString() == "Famiglia")
                {
                    rbFamiglia.Checked = true;
                }
                txtNote.Text = reader["Nota"].ToString();
                Image foto = null;
                try
                {
                    _NomeFoto = reader["NomeFile"].ToString();
                    foto = Image.FromFile(ConfigParam.GetFotoPath() + _NomeFoto);
                }
                catch (Exception ex)
                {
                    Log.Instance.Error(ex, "Errore durante il recupero della foto");
                    foto = null;
                }
                finally
                {
                    pictureFoto.Image = null;
                    if (foto != null)
                    {
                        pictureFoto.Image = new Bitmap(foto);
                    }
                    else
                    {
                        pictureFoto.Image = null;
                    }

                }

            }

            d.CloseConnection();
            CaricoFamiliari();
        }

        private void CaricoFamiliari()
        {
            DBUtils d = new DBUtils();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            d.setConnection();
            d.OpenConnection();
            SQLiteConnection con = d.m_dbConnection;
            SQLiteCommand cmd1 =
                new SQLiteCommand(
                    "Select ID,Cognome,Nome,MF,Disabile,Nazione,Nazionalita,Rapporto from Familiari WHERE (ID_NTessera =" +
                    txtNumeroTessera.Text + ")", con);
            //DataSet ds = new DataSet();
            SQLiteDataAdapter adp1 = new SQLiteDataAdapter(cmd1);
            //adp1.Fill(ds, "Familiari");
            DataTable table = new DataTable();
            adp1.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.ReadOnly = true;
        }


        //funzione in cui mi carico i contenuti del form
        private void FormDettaglio_Shown(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_NTessera))
            {
                aggiornaContenuto();
            }
            ContoAllegati();
            //Assegnocolori();
        }

        private void ContoAllegati()
        {
            string allegatiPath = ConfigParam.GetAllegatiPath();
            if (!Directory.Exists(allegatiPath + _NTessera))
            {
                lblallegati.Text += " 0";
            }
            else
            {
                lblallegati.Text += " " + Directory.GetFiles(allegatiPath + _NTessera).Length;
            }
        }
         
        private void Assegnocolori()
        {
            if (txtNumeroTessera.Text.Length > 0)
            {
                txtNumeroTessera.BackColor = System.Drawing.Color.White;

            }
            else
            {
                txtNumeroTessera.BackColor = System.Drawing.SystemColors.InactiveCaption;
            }
            if (txtCognome.Text.Length > 0)
            {
                txtCognome.BackColor = System.Drawing.Color.White;
            }
            else
            {
                txtCognome.BackColor = System.Drawing.SystemColors.InactiveCaption;
            }
            if (txtNome.Text.Length > 0)
            {
                txtNome.BackColor = System.Drawing.Color.White;
            }
            else
            {
                txtNome.BackColor = System.Drawing.SystemColors.InactiveCaption;
            }
            if (txtLuogoNascita.Text.Length > 0)
            {
                txtLuogoNascita.BackColor = System.Drawing.Color.White;

            }
            else
            {
                txtLuogoNascita.BackColor = System.Drawing.SystemColors.InactiveCaption;
            }
            if (cbNazionalita.Text.Length > 0)
            {
                cbNazionalita.BackColor = System.Drawing.Color.White;

            }
            else
            {
                cbNazionalita.BackColor = System.Drawing.SystemColors.InactiveCaption;
            }
            if (cbNazione.Text.Length > 0)
            {
                cbNazione.BackColor = System.Drawing.Color.White;

            }
            else
            {
                cbNazione.BackColor = System.Drawing.SystemColors.InactiveCaption;
            }
            if (cbReligione.Text.Length > 0)
            {
                cbReligione.BackColor = System.Drawing.Color.White;

            }
            else
            {
                cbReligione.BackColor = System.Drawing.SystemColors.InactiveCaption;
            }
            if (txtDocumento.Text.Length > 0)
            {
                txtDocumento.BackColor = System.Drawing.Color.White;

            }
            else
            {
                txtDocumento.BackColor = System.Drawing.SystemColors.InactiveCaption;
            }
            if (txtCodiceFiscale.Text.Length > 0)
            {
                txtCodiceFiscale.BackColor = System.Drawing.Color.White;

            }
            else
            {
                txtCodiceFiscale.BackColor = System.Drawing.SystemColors.InactiveCaption;
            }
            if (txtCitta.Text.Length > 0)
            {
                txtCitta.BackColor = System.Drawing.Color.White;

            }
            else
            {
                txtCitta.BackColor = System.Drawing.SystemColors.InactiveCaption;
            }
            if (txtVia.Text.Length > 0)
            {
                txtVia.BackColor = System.Drawing.Color.White;

            }
            else
            {
                txtVia.BackColor = System.Drawing.SystemColors.InactiveCaption;
            }
            if (txtNumero.Text.Length > 0)
            {
                txtNumero.BackColor = System.Drawing.Color.White;

            }
            else
            {
                txtNumero.BackColor = System.Drawing.SystemColors.InactiveCaption;
            }
            if (txtTelefono.Text.Length > 0)
            {
                txtTelefono.BackColor = System.Drawing.Color.White;

            }
            else
            {
                txtTelefono.BackColor = System.Drawing.SystemColors.InactiveCaption;
            }
            if (txtReddito.Text.Length > 0)
            {
                txtReddito.BackColor = System.Drawing.Color.White;

            }
            else
            {
                txtReddito.BackColor = System.Drawing.SystemColors.InactiveCaption;
            }
            if (txtNote.Text.Length > 0)
            {
                txtNote.BackColor = System.Drawing.Color.White;

            }
            else
            {
                txtNote.BackColor = System.Drawing.SystemColors.InactiveCaption;
            }


        }


        private void btnE_Click(object sender, EventArgs e)
        {
            FormElenco f = new FormElenco(txtNumeroTessera.Text);
            f.Show();
            this.Hide();
        }

        private string DateTimeSQLite(DateTime datetime)
        {
            string dateTimeFormat = "{0}-{1}-{2}";
            return string.Format(dateTimeFormat, datetime.Day, datetime.Month, datetime.Year);
        }

        private void btnSC_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCodiceFiscale.Text))
            {
                //controllo se è di 16 caratteri
                if (txtCodiceFiscale.Text.Length == 16)
                {
                    if (!CodiceFiscale.VerificaCodiceFiscale(txtCodiceFiscale.Text))
                    {
                        if (MessageBox.Show("Il Codice Fiscale inserito non è valido!!!", "Errore CF",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            return;
                        }
                    }
                }
                else
                {
                    if (MessageBox.Show("Il Codice Fiscale deve essere vuoto o di 16 caratteri!!!", "Errore CF",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        return;
                    }
                }
            }
            if (_nuovatessera)
            {
                bool unica = checkntesseraUnique();
                if (!unica)
                {
                    MessageBox.Show("Il numero di tessera è gia stato assegnato", "Cambiare tessera?",
                        MessageBoxButtons.OKCancel);
                    return;
                }

            }
            String Cognome = txtCognome.Text;
            String Nome = txtNome.Text;
            String MF = "M";
            if (rbM.Checked == true)
            {
                MF = "M";
            }
            else
            {
                MF = "F";
            }
            String LuogoNascita = txtLuogoNascita.Text;
            String DataNascita = DateTimeSQLite(dateTime.Value);
            String NomeFile = null;
            if (_NomeFoto != null)
            {
                NomeFile = _NomeFoto;
            }
            String Nazione = cbNazione.Text;
            String Nazionalita = cbNazionalita.Text;
            String Religione = cbReligione.Text;
            String StatoCivile = null;
            if (rbCelibe.Checked == true)
            {
                StatoCivile = "Celibe/Nubile";
            }
            else if (rbConiugato.Checked == true)
            {
                StatoCivile = "Coniugato/a";
            }
            else if (rbSeparato.Checked == true)
            {
                StatoCivile = "Separato/a";
            }
            else if (rbConvivente.Checked == true)
            {
                StatoCivile = "Convivente";
            }
            else if (rbVedovo.Checked == true)
            {
                StatoCivile = "Vedovo/a";
            }
            else if (rbDivorziato.Checked == true)
            {
                StatoCivile = "Divorziato/a";
            }
            String Documento = txtDocumento.Text;
            String CF = txtCodiceFiscale.Text;
            String DimoraCitta = txtCitta.Text;
            String DimoraVia = txtVia.Text;
            String DimoraCivico = txtNumero.Text;
            String Telefono = txtTelefono.Text;
            int Disabile = 0;
            if (chkDisabile.Checked)
            {
                Disabile = 1;
            }
            int ISEE = 0;
            if (chkISEE.Checked)
            {
                ISEE = 1;
            }
            String ISEEAnno = dtISEE.Text;
            String ISEEReddito = txtReddito.Text;
            int Permsoggiorno = 0;
            String DataEmissionePermsoggiorno;
            String DataScadenzaPermessoSoggiorno;
            if (chkPermSoggiorno.Checked)
            {
                Permsoggiorno = 1;
                DataEmissionePermsoggiorno = DateTimeSQLite(dtEmissionePermSogg.Value);
                DataScadenzaPermessoSoggiorno = DateTimeSQLite(dtScadenzaPermSogg.Value);
            }
            else
            {
                Permsoggiorno = 0;
                DataEmissionePermsoggiorno = DateTimeSQLite(dtEmissionePermSogg.MinDate); ;
                DataScadenzaPermessoSoggiorno = DateTimeSQLite(dtScadenzaPermSogg.MinDate); ;
            }
            String Pacco = null;
            if (rbSingolo.Checked == true)
            {
                Pacco = "Singolo";
            }
            else if (rbFamiglia.Checked == true)
            {
                Pacco = "Famiglia";
            }
            String Nota = txtNote.Text;
            DBUtils d = new DBUtils();
            d.setConnection();
            d.OpenConnection();
            SQLiteCommand command = d.m_dbConnection.CreateCommand();
            if (_nuovatessera)
            {
                command.CommandText = "INSERT INTO Clienti(NTessera," +
                                      "Cognome," +
                                      "Nome," +
                                      "MF," +
                                      "LuogoNascita," +
                                      "DataNascita," +
                                      "Nazione," +
                                      "Nazionalita," +
                                      "Religione," +
                                      "StatoCivile," +
                                      "Documento," +
                                      "CF," +
                                      "DimoraCitta," +
                                      "DimoraVia," +
                                      "DimoraCivico, " +
                                      "Telefono, " +
                                      "Disabile, " +
                                      "ISEE, " +
                                      "ISEEAnno, " +
                                      "ISEEReddito, " +
                                      "Permsoggiorno," +
                                      "EmissionePermsoggiorno," +
                                      "ScadenzaPermessoSoggiorno," +
                                      "Pacco, " +
                                      "Nota )" +
                                      "values ( " +
                                      "@NTessera," +
                                      "@Cognome, " +
                                      "@Nome, " +
                                      "@MF, " +
                                      "@LuogoNascita, " +
                                      "@DataNascita, " +
                                      "@Nazione, " +
                                      "@Nazionalita, " +
                                      "@religione, " +
                                      "@StatoCivile, " +
                                      "@Documento, " +
                                      "@CF," +
                                      "@DimoraCitta, " +
                                      "@DimoraVia, " +
                                      "@DimoraCivico, " +
                                      "@Telefono, " +
                                      "@Disabile, " +
                                      "@ISEE, " +
                                      "@ISEEAnno, " +
                                      "@ISEEReddito, " +
                                      "@Permsoggiorno," +
                                      "@EmissionePermsoggiorno," +
                                      "@ScadenzaPermessoSoggiorno," +
                                      "@Pacco, " +
                                      "@Nota )";

            }
            else
            {
                command.CommandText = "UPDATE Clienti SET " +
                                  "Cognome = @Cognome, " +
                                  "Nome = @Nome, " +
                                  "MF = @MF, " +
                                  "LuogoNascita = @LuogoNascita, " +
                                  "DataNascita = @DataNascita, " +
                                  "Nazione = @Nazione, " +
                                  "Nazionalita = @Nazionalita, " +
                                  "Religione = @religione, " +
                                  "StatoCivile = @StatoCivile, " +
                                  "Documento = @Documento, " +
                                  "CF = @CF," +
                                  "DimoraCitta = @DimoraCitta, " +
                                  "DimoraVia = @DimoraVia, " +
                                  "DimoraCivico = @DimoraCivico, " +
                                  "Telefono = @Telefono, " +
                                  "Disabile = @Disabile, " +
                                  "ISEE = @ISEE, " +
                                  "ISEEAnno = @ISEEAnno, " +
                                  "ISEEReddito = @ISEEReddito, " +
                                  "Permsoggiorno = @Permsoggiorno," +
                                  "EmissionePermsoggiorno = @EmissionePermsoggiorno," +
                                  "ScadenzaPermessoSoggiorno = @ScadenzaPermessoSoggiorno," +
                                  "Pacco = @Pacco, " +
                                  "Nota = @Nota " +
                                  "WHERE NTessera = @Ntessera";
            }
            
            command.Parameters.Add(new SQLiteParameter("@Cognome", Cognome));
            command.Parameters.Add(new SQLiteParameter("@Nome", Nome));
            command.Parameters.Add(new SQLiteParameter("@MF", MF));
            command.Parameters.Add(new SQLiteParameter("@LuogoNascita", LuogoNascita));
            command.Parameters.Add(new SQLiteParameter("@DataNascita", DataNascita));
            command.Parameters.Add(new SQLiteParameter("@Nazione", Nazione));
            command.Parameters.Add(new SQLiteParameter("@Nazionalita", Nazionalita));
            command.Parameters.Add(new SQLiteParameter("@Religione", Religione));
            command.Parameters.Add(new SQLiteParameter("@Statocivile", StatoCivile));
            command.Parameters.Add(new SQLiteParameter("@Documento", Documento));
            command.Parameters.Add(new SQLiteParameter("@CF", CF));
            command.Parameters.Add(new SQLiteParameter("@DimoraCitta", DimoraCitta));
            command.Parameters.Add(new SQLiteParameter("@DimoraVia", DimoraVia));
            command.Parameters.Add(new SQLiteParameter("@DimoraCivico", DimoraCivico));
            command.Parameters.Add(new SQLiteParameter("@Telefono", Telefono));
            command.Parameters.Add(new SQLiteParameter("@Disabile", Disabile));
            command.Parameters.Add(new SQLiteParameter("@ISEE", ISEE));
            command.Parameters.Add(new SQLiteParameter("@ISEEAnno", ISEEAnno));
            command.Parameters.Add(new SQLiteParameter("@ISEEReddito", ISEEReddito));
            command.Parameters.Add(new SQLiteParameter("@Permsoggiorno", Permsoggiorno));
            command.Parameters.Add(new SQLiteParameter("@EmissionePermsoggiorno", DataEmissionePermsoggiorno));
            command.Parameters.Add(new SQLiteParameter("@ScadenzaPermessoSoggiorno", DataScadenzaPermessoSoggiorno));
            command.Parameters.Add(new SQLiteParameter("@Pacco", Pacco));
            command.Parameters.Add(new SQLiteParameter("@Nota", Nota));
            command.Parameters.Add(new SQLiteParameter("@NTessera", txtNumeroTessera.Text));
            command.ExecuteNonQuery();
            if (_nuovatessera)
            {
                command.CommandText = "INSERT INTO Foto(NTessera," +
                                      "NomeFile)" +
                                      " values ( " +
                                      "@NTessera," +
                                      "@NomeFile)";
            }
            else
            {
                command.CommandText = "UPDATE Foto SET NomeFile = @NomeFile WHERE NTessera = @Ntessera";
            }
            command.Parameters.Add(new SQLiteParameter("@NomeFile", NomeFile));
            command.Parameters.Add(new SQLiteParameter("@NTessera", txtNumeroTessera.Text));
            command.ExecuteNonQuery();
            d.CloseConnection();
            FormElenco f = new FormElenco(txtNumeroTessera.Text);
            f.Show();
            this.Hide();
        }

        private bool checkntesseraUnique()
        {
            bool risultato = false;
            DBUtils d = new DBUtils();
            d.setConnection();
            d.OpenConnection();
            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Clienti WHERE NTESSERA = " + txtNumeroTessera.Text, d.m_dbConnection);
            SQLiteDataReader reader;
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                risultato=  false;
            }
            else
            {
                risultato = true;
            }
            reader.Close();
            d.CloseConnection();
            return risultato;
        }

        private void FormDettaglio_Load(object sender, EventArgs e)
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = this.Text + " gsa-acse " + version.ToString();
        }

        private void btnElimina_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show("Confermare di voler cancellare questa Utente" + Environment.NewLine + "Attenzione tutti i dati relativi a questa scheda saranno cancellati!!!", "Cancellare?",
                    MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Log.Instance.Info("Cancello tutti i dati relaivi alla tessera " + _NTessera);
                DBUtils d = new DBUtils();
                d.setConnection();
                d.OpenConnection();
                SQLiteCommand command = d.m_dbConnection.CreateCommand();
                command.CommandText = "Delete from Familiari where ID_NTessera = " + _NTessera;
                command.ExecuteNonQuery();
                CancelloFoto(_NTessera);
                Cancellaallegati(_NTessera);
                command.CommandText = "Delete from Foto where NTessera = " + _NTessera;
                command.ExecuteNonQuery();
                command.CommandText = "Delete from Clienti where NTessera = " + _NTessera;
                command.ExecuteNonQuery();
                d.CloseConnection();
                FormElenco f = new FormElenco();
                f.Show();
                this.Close();
            }
        }

        private void Cancellaallegati(string nTessera)
        {
            if (Directory.Exists(ConfigParam.GetAllegatiPath() + nTessera))
            {
                Directory.Delete(ConfigParam.GetAllegatiPath() + nTessera,true);
            }
        }

        private void CancelloFoto(string nTessera)
        {
            String VecchiaFoto = "";
            DBUtils d = new DBUtils();
            d.setConnection();
            d.OpenConnection();
            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM FOTO WHERE NTESSERA = " + nTessera, d.m_dbConnection);
            SQLiteDataReader reader;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                VecchiaFoto = reader["Nomefile"].ToString();
            }
            reader.Close();
            d.CloseConnection();

            if (File.Exists(ConfigParam.GetFotoPath() + VecchiaFoto))
            {
                pictureFoto.Image = null;
                pictureFoto.Image?.Dispose();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                FileInfo f = new FileInfo(ConfigParam.GetFotoPath() + VecchiaFoto);
                f.Delete();
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            string id = row.Cells["ID"].Value.ToString();
            _IDFamiliareSelect = int.Parse(id);
            Log.Instance.Debug("Selezionata riga tessera familiare" + id);
            PopoloCampiFamiliare(id);
        }

        private void PopoloCampiFamiliare(string id)
        {
            Log.Instance.Info("popolo cammpi per tessera familiare " + id);
            DBUtils d = new DBUtils();
            d.setConnection();
            d.OpenConnection();
            SQLiteConnection con = d.m_dbConnection;
            string sql = "SELECT * from Familiari where id =" + id;
            Log.Instance.Debug(sql);
            SQLiteCommand cmd1 = new SQLiteCommand(sql, con);
            SQLiteDataReader sqReader = cmd1.ExecuteReader();
            try
            {
                // Always call Read before accessing data.
                while (sqReader.Read())
                {
                    txtFamiliareCognome.Text = sqReader["Cognome"].ToString();
                    txtFamiliareNome.Text = sqReader["Nome"].ToString();
                    if (sqReader["MF"].ToString() == "M")
                    {
                        rbFamiliareM.Checked = true;
                        rbFamiliareF.Checked = false;
                    }
                    else
                    {
                        rbFamiliareM.Checked = false;
                        rbFamiliareF.Checked = true;
                    }
                    if (sqReader.GetInt32(sqReader.GetOrdinal("Disabile")) == 1)
                    {
                        cbFamiliareDisabile.Checked = true;
                    }
                    else
                    {
                        cbFamiliareDisabile.Checked = false;
                    }
                    cbFamiliareNazione.SelectedIndex = cbFamiliareNazione.FindStringExact(sqReader["Nazione"].ToString());
                    cbFamiliareNazionalita.SelectedIndex = cbFamiliareNazionalita.FindStringExact(sqReader["Nazionalita"].ToString());
                    cbFamiliareRapporto.SelectedIndex = cbFamiliareRapporto.FindStringExact(sqReader["Rapporto"].ToString());
                }
            }
            finally
            {
                // always call Close when done reading.
                sqReader.Close();
            }
        }

        private void btnFamiliareSalva_Click(object sender, EventArgs e)
        {
            DBUtils d = new DBUtils();
            d.setConnection();
            d.OpenConnection();
            SQLiteCommand command = d.m_dbConnection.CreateCommand();
            command.CommandText = "UPDATE Familiari SET " +
                                  "Cognome = @Cognome, " +
                                  "Nome = @Nome, " +
                                  "MF = @MF, " +
                                  "Disabile = @Disabile, " +
                                  "Nazione = @Nazione, " +
                                  "Nazionalita = @Nazionalita, " +
                                  "Rapporto = @Rapporto " +
                                  "WHERE ID = " + _IDFamiliareSelect;
            command.Parameters.Add(new SQLiteParameter("@Cognome", txtFamiliareCognome.Text));
            command.Parameters.Add(new SQLiteParameter("@Nome", txtFamiliareNome.Text));
            String MF = "M";
            if (rbFamiliareM.Checked == true)
            {
                MF = "M";
            }
            else
            {
                MF = "F";
            }
            command.Parameters.Add(new SQLiteParameter("@MF", MF));
            int Disabile = 0;
            if (cbFamiliareDisabile.Checked)
            {
                Disabile = 1;
            }
            command.Parameters.Add(new SQLiteParameter("@Disabile", Disabile));
            command.Parameters.Add(new SQLiteParameter("@Nazione", cbFamiliareNazione.Text));
            command.Parameters.Add(new SQLiteParameter("@Nazionalita", cbFamiliareNazionalita.Text));
            command.Parameters.Add(new SQLiteParameter("@Rapporto", cbFamiliareRapporto.Text));
            command.ExecuteNonQuery();
            d.CloseConnection();
            CaricoFamiliari();
        }

        private void btnFamiliareNuovo_Click(object sender, EventArgs e)
        {
            FormNewFamiliare formNewFamiliare = new FormNewFamiliare(_NTessera);
            formNewFamiliare.FormClosing += new FormClosingEventHandler(ChildFormClosing);
            formNewFamiliare.Show();
        }

        private void ChildFormClosing(object sender, FormClosingEventArgs e)
        {
            CaricoFamiliari();
        }

        private void btnFamiliareElimina_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show("Confermare di voler cancellare questa Familiare", "Cancellare?",
                    MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DBUtils d = new DBUtils();
                d.setConnection();
                d.OpenConnection();
                SQLiteCommand command = d.m_dbConnection.CreateCommand();
                command.CommandText = "DELETE FROM Familiari WHERE ID = " + _IDFamiliareSelect;
                command.ExecuteNonQuery();
                d.CloseConnection();
                CaricoFamiliari();
            }
        }

        private void chkPermSoggiorno_CheckStateChanged(object sender, EventArgs e)
        {
            if(chkPermSoggiorno.Checked)
            {
                dtScadenzaPermSogg.Enabled = true;
                dtEmissionePermSogg.Enabled = true;
            }
            else
            {
                dtScadenzaPermSogg.Enabled = false;
                dtEmissionePermSogg.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkfolderExist(_NTessera))
            {
                StartProcess(ConfigParam.GetAllegatiPath() + _NTessera);
            }
        }
        private void StartProcess(string path)
        {
            ProcessStartInfo StartInformation = new ProcessStartInfo();

            StartInformation.FileName = path;

            Process process = Process.Start(StartInformation);

            //process.EnableRaisingEvents = true;
        }
        public bool checkfolderExist(String numeroTessera)
        {
            try
            {
                string allegatiPath = ConfigParam.GetAllegatiPath();
                if (Directory.Exists(allegatiPath + numeroTessera))
                {

                }
                else
                {
                    Directory.CreateDirectory(allegatiPath + numeroTessera);
                }
            }
            catch (Exception)
            {

                return false;
            }
           

            return true;
        }

        private void btnStorico_Click(object sender, EventArgs e)
        {
            Log.Instance.Debug("Click su bottone Storico Pacchi img");
            var fPacchi = new FormStoricoPacchi(_NTessera);
            fPacchi.RefToFormDettaglio = this;
            fPacchi.Show();
        }
    }
}
