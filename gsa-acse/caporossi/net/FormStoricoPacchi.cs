using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gsa_acse.caporossi.net
{
    public partial class FormStoricoPacchi : Form
    {
        private String _ntessera;

        public FormStoricoPacchi(String nTessera)
        {
            _ntessera = nTessera;
            InitializeComponent();
            LoadData();
            
        }
        public Form RefToFormDettaglio { get; set; }

        private void LoadData()
        {
            DBUtils d = new DBUtils();
            dgStoricopacchi.DataSource = null;
            dgStoricopacchi.Rows.Clear();
            d.setConnection();
            d.OpenConnection();
            SQLiteConnection con = d.m_dbConnection;
            SQLiteCommand cmd1 =
                new SQLiteCommand(
                    "Select Pacco,Dataconsegna,NTesseraCheRitira from Carico WHERE (NTessera =" + _ntessera + ")", con);
            //DataSet ds = new DataSet();
            SQLiteDataAdapter adp1 = new SQLiteDataAdapter(cmd1);
            //adp1.Fill(ds, "Familiari");
            DataTable table = new DataTable();
            adp1.Fill(table);
            dgStoricopacchi.DataSource = table;
            dgStoricopacchi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgStoricopacchi.ReadOnly = true;
        }

        private void FormStoricoPacchi_Load(object sender, EventArgs e)
        {
            Log.Instance.Info("load Form StoricoPacchi");
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = this.Text + " " + version.ToString();
        }
    }
}
