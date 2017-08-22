using System;
using System.Data.SQLite;
using System.Reflection;
using System.Windows.Forms;

namespace gsa_acse.caporossi.net
{
    public partial class FormLogin : Form
    {
        
        public FormLogin()
        {
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsername.Text) && !string.IsNullOrEmpty(txtPassword.Text))
            {
                Log.Instance.Info("login per utente " + txtUsername.Text);
                DBUtils d = new DBUtils();
                d.setConnection();
                d.OpenConnection();
                string sql = "SELECT COUNT(*) FROM Utenti WHERE username = '" + txtUsername.Text + "' AND password = '" + txtPassword.Text + "'";
                SQLiteCommand command = new SQLiteCommand(sql, d.m_dbConnection);
                
                int i = Convert.ToInt32(command.ExecuteScalar());
                d.CloseConnection();
                if (i > 0)
                {
                    Log.Instance.Info("Utente trovato");
                    this.Hide();
                    FormElenco f = new FormElenco();
                    f.Show();
                }
                else
                {
                    Log.Instance.Info("Username o Password non presenti nel DB");
                    MessageBox.Show("Username o Password non presenti nel DB","Attenzione",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                Log.Instance.Info("Stringa vuota Inserire Username e Password");
                MessageBox.Show("Inserire Username e Password", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            Log.Instance.Info("load FormLogin");
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = this.Text + " " + version.ToString();
        }
    }
}
