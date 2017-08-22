using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gsa_acse.caporossi.net
{
    class DBUtils
    {

        public SQLiteConnection m_dbConnection = null;

        public void setConnection()
        {
            SQLiteConnectionStringBuilder conString = new SQLiteConnectionStringBuilder();
            conString.DataSource = ConfigParam.GetDBPath();
            conString.DefaultTimeout = 5000;
            conString.SyncMode = SynchronizationModes.Off;
            conString.JournalMode = SQLiteJournalModeEnum.Memory;
            conString.PageSize = 65536;
            conString.CacheSize = 16777216;
            conString.FailIfMissing = false;
            conString.ReadOnly = false;
            conString.Pooling = true;
            conString.Version = 3;
            m_dbConnection = new SQLiteConnection(conString.ConnectionString);
           
        }

        public void OpenConnection()
        {
            if (m_dbConnection.State != ConnectionState.Open)
            {
                Log.Instance.Info("Aperta connessione con il DB");
                m_dbConnection.Open();
            }
            
        }
        public void CloseConnection()
        {
            Log.Instance.Info("Chiusa connessione con il DB");
            //if (m_dbConnection.State == c ConnectionState.Open)
            //{
            m_dbConnection.Close();
                m_dbConnection.Dispose();
            //}

        }
        public string DateTimeSQLite(DateTime datetime)
        {
            string dateTimeFormat = "{0}-{1}-{2} {3}:{4}:{5}.{6}";
            return string.Format(dateTimeFormat, datetime.Year, datetime.Month, datetime.Day, datetime.Hour, datetime.Minute, datetime.Second, datetime.Millisecond);
        }
    }
}
