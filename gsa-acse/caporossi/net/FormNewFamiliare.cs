using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gsa_acse.caporossi.net
{
    public partial class FormNewFamiliare : Form
    {
        private String _ntessera;
        public FormNewFamiliare(string nTessera)
        {
            InitializeComponent();
            LoadData();
            _ntessera = nTessera;
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

        private void btnInserisci_Click(object sender, EventArgs e)
        {
            DBUtils d = new DBUtils();
            d.setConnection();
            d.OpenConnection();
            SQLiteCommand command = d.m_dbConnection.CreateCommand();
            String MF = "M";
            if (rbFamiliareM.Checked == true)
            {
                MF = "M";
            }
            else
            {
                MF = "F";
            }
            int Disabile = 0;
            if (cbFamiliareDisabile.Checked)
            {
                Disabile = 1;
            }
            command.CommandText =
                "INSERT into Familiari (ID_NTessera,Cognome,Nome,MF,Disabile,Nazione,Nazionalita,Rapporto) values " +
                "(" + Int32.Parse(_ntessera) + ",'" +
                txtFamiliareCognome.Text + "','" +
                txtFamiliareNome.Text + "','" +
                MF + "'," +
                Disabile + ",'" +
                cbFamiliareNazione.Text + "','" +
                cbFamiliareNazionalita.Text + "','" +
                cbFamiliareRapporto.Text + "')";
            command.ExecuteNonQuery(); 
            d.CloseConnection();
            this.Close();
        }
    }
}
