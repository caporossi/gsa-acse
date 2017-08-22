using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace gsa_acse.caporossi.net
{
    public partial class FormElenco : Form
    {
        DBUtils d = new DBUtils();
        SQLiteConnection con;
        private SQLiteCommand cmd1;
        private SQLiteDataAdapter adp1;
        private SQLiteCommand cmd2;
        DataSet ds;
        private int PageSize = 10;
        private int CurrentPageIndex = 1;
        private int TotalPage = 0;
        private Boolean SoloTessera = false;
        private String TesseraSelezionata = null;
        private String TipoPaccoAssegnato = "";
        private String DataPaccoAssegnato = "";

        public FormElenco()
        {
            Log.Instance.Info("Carico form elenco");
            InitializeComponent();
        }

        public FormElenco(string _ts)
        {
            Log.Instance.Info("Carico form elenco per tessera " + _ts);
            TesseraSelezionata = _ts;
            InitializeComponent();
            //dataGridView1.SelectedRows.Clear();
            //dataGridView1.Rows.OfType<DataGridViewRow>().Where(x => (int)x.Cells["NTessera"].Value == int.Parse(TesseraSelezionata)).ToArray<DataGridViewRow>()[0].Selected = true;

        }

        private void CaricoTutti()
        {
            Log.Instance.Debug("Carico tutti");
            d.setConnection();
            d.OpenConnection();
            con = d.m_dbConnection;
            cmd1 = new SQLiteCommand("Select * from Clienti order by NTessera", con);
            ds = new DataSet();
            adp1 = new SQLiteDataAdapter(cmd1);
            adp1.Fill(ds, "Clienti");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Clienti";

            // WORK IN PAGING FOR DATAGRIDVIEW
            // Get total count of the pages; 
            this.CalculateTotalPages();
            this.dataGridView1.ReadOnly = true;
            // Load the first page of data; 
            this.dataGridView1.DataSource = GetCurrentRecords(1, con);
            lblpage.Text = (CurrentPageIndex.ToString() + "/" + TotalPage.ToString());
            AggiornoTotali();
        }

        private void AggiornoTotali()
        {
            d.setConnection();
            d.OpenConnection();
            con = d.m_dbConnection;
            string sql = "Select COUNT(*) As totale from Carico WHERE DataConsegna = '" + DateTimeSQLite(DateTime.Now) + "'";
            SQLiteCommand cmd = new SQLiteCommand(sql, con);
            SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtTotaliOggi.Text = reader["totale"].ToString();
            }
            reader.Close();
            sql = "Select COUNT(*) As totale from Carico WHERE DataConsegna = '" + DateTimeSQLite(DateTime.Now) + "' AND Pacco='Famiglia'";
            cmd = new SQLiteCommand(sql, con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtFamigliaOggi.Text = reader["totale"].ToString();
            }
            reader.Close();
            sql = "Select COUNT(*) As totale from Carico WHERE DataConsegna = '" + DateTimeSQLite(DateTime.Now) + "' AND Pacco='Singolo'";
            cmd = new SQLiteCommand(sql, con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtSingoliOggi.Text = reader["totale"].ToString();
            }
            reader.Close();
            //d.CloseConnection();
        }

        private void FormElenco_Load(object sender, EventArgs e)
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = this.Text + " gsa-acse " + version.ToString();
            if (!SoloTessera)
            {
                CaricoTutti();
            }
            if (string.IsNullOrEmpty(txtNumeroTessera.Text))
            {
                btnAssegnaPacco.Enabled = false;
                btnScheda.Enabled = false;
            }
        }
        private void CalculateTotalPages()
        {
            int rowCount = ds.Tables["Clienti"].Rows.Count;
            Log.Instance.Debug("Calcolo il numero di pag per " + rowCount.ToString() + " di righe" );
            this.TotalPage = rowCount / PageSize;
            if (rowCount % PageSize > 0) // if remainder is more than  zero 
            {
                this.TotalPage += 1;
            }
        }
        private DataTable GetCurrentRecords(int page, SQLiteConnection con)
        {
            DataTable dt = new DataTable();

            if (page == 1)
            {
                cmd2 = new SQLiteCommand("Select  NTessera,Cognome,Nome,Nazione,Telefono,Pacco,DataUltimoPacco from Clienti  ORDER BY NTessera LIMIT " + PageSize, con);
            }
            else
            {
                int PreviouspageLimit = (page - 1) * PageSize;

                cmd2 = new SQLiteCommand("Select NTessera,Cognome,Nome,Nazione,Telefono,Pacco,DataUltimoPacco from Clienti WHERE NTessera  NOT IN " +
                "(Select NTessera from Clienti ORDER BY NTessera LIMIT " + PreviouspageLimit + " ) LIMIT " + PageSize, con); // +
                //"order by customerid", con);
            }
            try
            {
                // con.Open();
                this.adp1.SelectCommand = cmd2;
                this.adp1.Fill(dt);
                lblpage.Text = (CurrentPageIndex.ToString() + "/" + TotalPage.ToString());
            }
            finally
            {
                con.Close();
            }
            return dt;
        }
        private void btnFirstPAge_Click(object sender, EventArgs e)
        {
            if (!SoloTessera)
            {
                this.CurrentPageIndex = 1;
                this.dataGridView1.DataSource = GetCurrentRecords(this.CurrentPageIndex, con);
            }
        }

        private void btnNxtPage_Click(object sender, EventArgs e)
        {
            if (!SoloTessera)
            {
                if (this.CurrentPageIndex < this.TotalPage)
                {
                    this.CurrentPageIndex++;
                    this.dataGridView1.DataSource = GetCurrentRecords(this.CurrentPageIndex, con);
                }
            }
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (!SoloTessera)
            {
                if (this.CurrentPageIndex > 1)
                {
                    this.CurrentPageIndex--;
                    this.dataGridView1.DataSource = GetCurrentRecords(this.CurrentPageIndex, con);
                }
            }
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            if (!SoloTessera)
            {
                this.CurrentPageIndex = TotalPage;
                this.dataGridView1.DataSource = GetCurrentRecords(this.CurrentPageIndex, con);
            }
        }

 
        private void PopoloCampi(string tessera)
        {
            Log.Instance.Info("popolo cammpi per tessera " + tessera);
            d.OpenConnection();
            con = d.m_dbConnection;
            string sql = "SELECT Clienti.*,Foto.Nomefile FROM Clienti INNER JOIN Foto ON Clienti.NTessera = Foto.NTessera WHERE Clienti.NTessera =" + tessera + ";";
            Log.Instance.Debug(sql);
            cmd1 = new SQLiteCommand(sql, con);
            SQLiteDataReader sqReader = cmd1.ExecuteReader();
            try
            {
                // Always call Read before accessing data.
                while (sqReader.Read())
                {
                    
                    txtNumeroTessera.Text = sqReader["NTessera"].ToString();
                    
                    txtCognome.Text = sqReader["Cognome"].ToString();
                    

                    txtNome.Text = sqReader["Nome"].ToString();
                    

                    txtLuogoNascita.Text = sqReader["LuogoNascita"].ToString();
                    

                    TipoPaccoAssegnato = sqReader["Pacco"].ToString();
                    DataPaccoAssegnato = sqReader["DataUltimoPacco"].ToString();
                    String temp = sqReader["DataNascita"].ToString();

                    if (!string.IsNullOrEmpty(temp))
                    {
                        txtDataNascita.Text = (Convert.ToDateTime(sqReader["DataNascita"].ToString())).ToShortDateString();
                       
                    }
                    else
                    {
                        txtDataNascita.Text = "";
                    }
                    txtNazione.Text = sqReader["Nazione"].ToString();
                   

                    if (sqReader["MF"].ToString() == "M")
                    {
                        rbM.Checked = true;
                        rbF.Checked = false;
                    }
                    else
                    {
                        rbM.Checked = false;
                        rbF.Checked = true;
                    }
                    Image foto = null;
                    try
                    {
                        foto = Image.FromFile(ConfigParam.GetFotoPath() + sqReader["NomeFile"].ToString());
                    }
                    catch (Exception)
                    {
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
            }
            finally
            {
                // always call Close when done reading.
                sqReader.Close();
                //d.CloseConnection();
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            string ntessera = row.Cells["NTessera"].Value.ToString();
            Log.Instance.Debug("Selezionata riga tessera " + ntessera);
            PopoloCampi(ntessera);
            //Assegnocolori();
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
            if (txtDataNascita.Text.Length > 0)
            {
                txtDataNascita.BackColor = System.Drawing.Color.White;
            }
            else
            {
                txtDataNascita.BackColor = System.Drawing.SystemColors.InactiveCaption;
            }
            if (txtLuogoNascita.Text.Length > 0)
            {
                txtLuogoNascita.BackColor = System.Drawing.Color.White;
            }
            else
            {
                txtLuogoNascita.BackColor = System.Drawing.SystemColors.InactiveCaption;
            }
            if (txtNazione.Text.Length > 0)
            {
                txtNazione.BackColor = System.Drawing.Color.White;
            }
            else
            {
                txtNazione.BackColor = System.Drawing.SystemColors.InactiveCaption;
            }

        }

        private void btnTutti_Click(object sender, EventArgs e)
        {
            Log.Instance.Debug("Premuto bottone tutti");
            txtInsertTessera.Text = "";
            txtRicercaNome.Text = "";
            txtRicercaCognome.Text = "";
            SoloTessera = false;
            CaricoTutti();
        }

        private void btnTessera_Click(object sender, EventArgs e)
        {
            txtRicercaNome.Text = "";
            txtRicercaCognome.Text = "";
            Log.Instance.Debug("Premuto bottone tessera numero " + txtInsertTessera.Text);
            if (!String.IsNullOrEmpty(txtInsertTessera.Text))
            {
                int myInt;
                bool isNumerical = int.TryParse(txtInsertTessera.Text, out myInt);
                if (isNumerical)
                {
                    SoloTessera = true;
                    CaricoTessera(txtInsertTessera.Text);
                }
                else
                {
                    SoloTessera = false;
                    CaricoTutti();
                }
            }
            else
            {
                
            }
        }

        private void CaricoTessera(string ntessera)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            d.setConnection();
            d.OpenConnection();
            con = d.m_dbConnection;
            cmd1 = new SQLiteCommand("Select NTessera,Cognome,Nome,Nazione,Telefono,Pacco,DataUltimoPacco  from Clienti WHERE (NTessera =" + ntessera + ")", con);
            ds = new DataSet();
            adp1 = new SQLiteDataAdapter(cmd1);
            adp1.Fill(ds, "Clienti");
            if (ds.Tables[0].Rows.Count == 0)
            {
                CaricoTutti();
            }
            else
            {
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Clienti";
                this.dataGridView1.ReadOnly = true;
                lblpage.Text = ("1/1");
            }

        }

        private void FormElenco_FormClosed(object sender, FormClosedEventArgs e)
        {
            Log.Instance.Info("Chiudo Form elenco e quindi tutta applicazione");
            d.CloseConnection();
            Application.Exit();
        }

        private void btnScheda_Click(object sender, EventArgs e)
        {
            Log.Instance.Info("Click su bottone scheda");
            var fd = new FormDettaglio(txtNumeroTessera.Text);
            fd.Show();
            Hide();
            //Dispose();
        }

        private void btnNuovaScheda_Click(object sender, EventArgs e)
        {
            Log.Instance.Info("Click su bottone Nuova scheda");
            var fd = new FormDettaglio();
            fd.Show();
            Hide();
        }
        private string DateTimeSQLite(DateTime datetime)
        {
            string dateTimeFormat = "{0}-{1}-{2}";
            return string.Format(dateTimeFormat, datetime.Day, datetime.Month, datetime.Year);
        }
        private void btnAssegnaPacco_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TipoPaccoAssegnato))
            {
                if (
                    MessageBox.Show("Manca la Tipologia di Pacco!!", "Dato mancante", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    return;
                }

            }
            if (TipoPaccoGiaAssegnato(DateTime.Now))
            {
                MessageBox.Show("Pacco già Assegnato in data odierna!!", "Pacco giàassegnato", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (txtTesseraRitiroPacco.Text.Length > 0)
            {
                if (!TesseraEsiste(int.Parse(txtTesseraRitiroPacco.Text)))
                {
                    MessageBox.Show(
                        "Tessera inesistente, inserire una tessera valida !!"
                        , "Errore tessera", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                String TempNome = "";
                String TempCognome = "";
                Log.Instance.Info("popolo campi per tessera che ritira" + txtTesseraRitiroPacco.Text);
                d.OpenConnection();
                con = d.m_dbConnection;
                string sql = "SELECT Nome, Cognome FROM Clienti WHERE Clienti.NTessera =" + txtTesseraRitiroPacco.Text +";";
                Log.Instance.Debug(sql);
                cmd1 = new SQLiteCommand(sql, con);
                SQLiteDataReader sqReader = cmd1.ExecuteReader();
                    // Always call Read before accessing data.
                    while (sqReader.Read())
                    {
                        TempNome = sqReader["Nome"].ToString();
                        TempCognome = sqReader["Cognome"].ToString();
                    }
                    sqReader.Close();
                if (MessageBox.Show(
                    "Pacco " + TipoPaccoAssegnato + " ritirato da " + TempNome + " " + TempCognome + " Numero Tessera " +
                    txtTesseraRitiroPacco.Text + " CONFERMARE !!!!"
                    , "Pacco ritirato da altra tessera", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) ==
                    DialogResult.OK)
                {
                    if (MessageBox.Show("Pacco " + TipoPaccoAssegnato + " Assegnato!!", "Pacco assegnato",MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        DBUtils dbutil = new DBUtils();
                        dbutil.setConnection();
                        dbutil.OpenConnection();
                        SQLiteCommand command = dbutil.m_dbConnection.CreateCommand();
                        command.CommandText = "UPDATE Clienti SET " +
                                          "DataUltimoPacco = @DataUltimoPacco " +
                                          "WHERE NTessera = @Ntessera";
                        String DataPacco = DateTimeSQLite(DateTime.Now);
                        command.Parameters.Add(new SQLiteParameter("@DataUltimoPacco", DataPacco));
                        command.Parameters.Add(new SQLiteParameter("@NTessera", int.Parse(txtNumeroTessera.Text)));
                        command.ExecuteNonQuery();
                        string Temp;
                        if (txtTesseraRitiroPacco.Text.Length > 0)
                        {
                            Temp = txtTesseraRitiroPacco.Text;
                        }
                        else
                        {
                            Temp = null;
                        }
                        command.CommandText = "INSERT  into Carico (NTessera,Pacco,DataConsegna,NTesseracheritira)values(" +
                                              txtNumeroTessera.Text + ",'" +
                                              TipoPaccoAssegnato + "','" +
                                              DataPacco + "','" +
                                              Temp +"')";
                        command.ExecuteNonQuery();
                        dbutil.CloseConnection();
                        CaricoTutti();
                    }
                }
            }
            else
            {
                if (
                    MessageBox.Show("Pacco " + TipoPaccoAssegnato + " Assegnato!!", "Pacco assegnato",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    DBUtils dbutil = new DBUtils();
                    dbutil.setConnection();
                    dbutil.OpenConnection();
                    SQLiteCommand command = dbutil.m_dbConnection.CreateCommand();
                    command.CommandText = "UPDATE Clienti SET " +
                                          "DataUltimoPacco = @DataUltimoPacco " +
                                          "WHERE NTessera = @Ntessera";
                    String DataPacco = DateTimeSQLite(DateTime.Now);
                    command.Parameters.Add(new SQLiteParameter("@DataUltimoPacco", DataPacco));
                    command.Parameters.Add(new SQLiteParameter("@NTessera", int.Parse(txtNumeroTessera.Text)));
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT  into Carico (NTessera,Pacco,DataConsegna)values(" +
                                          txtNumeroTessera.Text + ",'" +
                                          TipoPaccoAssegnato + "','" +
                                          DataPacco + "')";
                    command.ExecuteNonQuery();
                    dbutil.CloseConnection();
                }
                CaricoTutti();
            }

           
        }

        private bool TesseraEsiste(int tessera)
        {
            int numerotessere = 0;
            d.setConnection();
            d.OpenConnection();
            con = d.m_dbConnection;
            string sql = "Select COUNT(*) As totale from Clienti WHERE NTessera = " + tessera;
            SQLiteCommand cmd = new SQLiteCommand(sql, con);
            SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                numerotessere = int.Parse(reader["totale"].ToString());
            }
            reader.Close();
            if (numerotessere > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private bool TipoPaccoGiaAssegnato(DateTime now)
        {
            int numeroPacchi = 0;
            d.setConnection();
            d.OpenConnection();
            con = d.m_dbConnection;
            string sql = "Select COUNT(*) As totale from Carico WHERE DataConsegna = '" + DateTimeSQLite(DateTime.Now) + "' AND NTESSERA = " +
            txtNumeroTessera.Text;
            SQLiteCommand cmd = new SQLiteCommand(sql, con);
            SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                numeroPacchi = int.Parse(reader["totale"].ToString());
            }
            reader.Close();
            if (numeroPacchi > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnRicercaCognome_Click(object sender, EventArgs e)
        {
            txtRicercaNome.Text = "";
            txtInsertTessera.Text = "";
            Log.Instance.Debug("Premuto bottone tessera numero " + txtRicercaCognome.Text);
            if (!String.IsNullOrEmpty(txtRicercaCognome.Text))
            {

                SoloTessera = true;
                CaricoTesseraCognome(txtRicercaCognome.Text);
            }
        }

        private void CaricoTesseraCognome(string Cognome)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            d.setConnection();
            d.OpenConnection();
            con = d.m_dbConnection;
            cmd1 = new SQLiteCommand("Select NTessera,Cognome,Nome,Nazione,Telefono,Pacco,DataUltimoPacco  from Clienti WHERE (Cognome = '" + Cognome + "')", con);
            ds = new DataSet();
            adp1 = new SQLiteDataAdapter(cmd1);
            adp1.Fill(ds, "Clienti");
            if (ds.Tables[0].Rows.Count == 0)
            {
                CaricoTutti();
            }
            else
            {
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Clienti";
                this.dataGridView1.ReadOnly = true;
                lblpage.Text = ("1/1");
            }
        }

        private void btnRicercaNome_Click(object sender, EventArgs e)
        {
            txtRicercaCognome.Text = "";
            txtInsertTessera.Text = "";
            Log.Instance.Debug("Premuto bottone tessera Nome " + txtRicercaNome.Text);
            if (!String.IsNullOrEmpty(txtRicercaNome.Text))
            {
                SoloTessera = true;
                CaricoTesseraNome(txtRicercaNome.Text);
            }
        }

        private void CaricoTesseraNome(string Nome)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            d.setConnection();
            d.OpenConnection();
            con = d.m_dbConnection;
            cmd1 = new SQLiteCommand("Select NTessera,Cognome,Nome,Nazione,Telefono,Pacco,DataUltimoPacco  from Clienti WHERE (Nome ='" + Nome + "')", con);
            ds = new DataSet();
            adp1 = new SQLiteDataAdapter(cmd1);
            adp1.Fill(ds, "Clienti");
            if (ds.Tables[0].Rows.Count == 0)
            {
                CaricoTutti();
            }
            else
            {
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Clienti";
                this.dataGridView1.ReadOnly = true;
                lblpage.Text = ("1/1");
            }
        }

        private void FormElenco_Shown(object sender, EventArgs e)
        {
            //Assegnocolori();
        }

        private void txtTesseraRitiroPacco_TextChanged(object sender, EventArgs e)
        {
            int a;
            if (!int.TryParse(txtTesseraRitiroPacco.Text, out a))
            {
                MessageBox.Show("Inserire solamente numeri.");
                txtTesseraRitiroPacco.Clear();
            }
        }
    }
}
