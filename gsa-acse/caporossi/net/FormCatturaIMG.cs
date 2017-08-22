using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Controls;
using AForge.Video;
using AForge.Video.DirectShow;
using gsa_acse.Properties;

namespace gsa_acse.caporossi.net
{
    public partial class FormCatturaIMG : Form
    {
        private FilterInfoCollection webcam;
        private VideoCaptureDevice cam;
        private VideoSourcePlayer vsp;
        public float zoomFactor = 1;
        private Point zoomPosition = new Point(0, 0);
        private bool Makeselection = false;
        private int cropX;
        private int cropY;
        private Pen cropPen;
        private int cropWidth;
        private int cropHeight;
        private string Nomefile;
        private string _NTessera;
        private string VecchiaFoto = null;
        public FormCatturaIMG(string NTessera)
        {
            _NTessera = NTessera;
            InitializeComponent();
        }
        public Form RefToFormDettaglio { get; set; }

        private void FormCatturaIMG_Load(object sender, EventArgs e)
        {
            webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo videoCaptureDevice in webcam)
            {
                comboCam.Items.Add(videoCaptureDevice.Name);
            }
            comboCam.SelectedIndex = 0;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Makeselection = false;
            if (cam!= null && cam.IsRunning)
            {
                cam.Stop();
            }
            cam = new VideoCaptureDevice(webcam[comboCam.SelectedIndex].MonikerString);
            cam.NewFrame+=new NewFrameEventHandler(cam_NewFrame);
            cam.Start();
            btnCattura.Enabled = true;
            btnTaglia.Enabled = true;
        }
        private void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bit = (Bitmap)eventArgs.Frame.Clone();
            pictureCamIMG.Image = bit;
        }

       

        public void Zoom(float zoomFactor, Point zoomPoint)
        {
            this.zoomFactor = zoomFactor;
            this.zoomPosition = zoomPoint;
        }

       

       private void btnCattura_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;

            try
            {
                if (cropWidth < 1)
                {
                    return;
                }
                Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
                //First we define a rectangle with the help of already calculated points
                Bitmap OriginalImage = new Bitmap(pictureCamIMG.Image, pictureCamIMG.Width, pictureCamIMG.Height);
                //Original image
                Bitmap _img = new Bitmap(cropWidth, cropHeight);
                // for cropinfo image
                Graphics g = Graphics.FromImage(_img);
                // create graphics
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                //set image attributes
                g.DrawImage(OriginalImage, 0, 0, rect, GraphicsUnit.Pixel);

                pictureCamIMG.Image = _img;
                Nomefile = System.Guid.NewGuid().ToString() + ".jpg";
                _img.Save(ConfigParam.GetFotoPath() + Nomefile, ImageFormat.Jpeg);
                Scrivifoto2DB();
                cropWidth = 0;
            }
            catch (Exception ex) { }
          
        }

        private void Scrivifoto2DB()
        {
            DBUtils d = new DBUtils();
            d.setConnection();
            d.OpenConnection();
            string selectsql= "Select NomeFile FROM Foto WHERE NTessera = '" + _NTessera + "'";
            SQLiteCommand cmdSelect = new SQLiteCommand(selectsql, d.m_dbConnection);
            var risultatoSelect = cmdSelect.ExecuteScalar(CommandBehavior.CloseConnection);
            string sql = "DELETE FROM Foto WHERE NTessera = '" + _NTessera + "'";
            d.OpenConnection();
            SQLiteCommand cmd = new SQLiteCommand(sql, d.m_dbConnection);
            cmd.ExecuteNonQuery(CommandBehavior.CloseConnection);
            sql = "INSERT INTO Foto (NTessera,NomeFile)VALUES(@nt,@nf)";
            d.OpenConnection();
            SQLiteCommand insertSQL = new SQLiteCommand(sql, d.m_dbConnection);
            insertSQL.Parameters.Add(new SQLiteParameter("@nt", DbType.Int32) { Value = int.Parse(_NTessera)});
            insertSQL.Parameters.Add(new SQLiteParameter("@nf", DbType.String) { Value = Nomefile });
            insertSQL.ExecuteNonQuery(CommandBehavior.CloseConnection);
            d.CloseConnection();
            if (risultatoSelect != null)
            {
                try
                {
                    File.Delete(ConfigParam.GetFotoPath() + risultatoSelect.ToString());
                }
                catch (Exception)
                {
                    VecchiaFoto = risultatoSelect.ToString();
                }


            }
        }

        private void btnChiudi_Click(object sender, EventArgs e)
        {
            if (cam!=null && cam.IsRunning)
            {
                cam.Stop();
            }
            Form fd;
            if (VecchiaFoto != null)
            {
                fd = new FormDettaglio(_NTessera,VecchiaFoto);
            }
            else
            {
                fd = new FormDettaglio(_NTessera);
            }
            fd.Show();
            //this.RefToFormDettaglio.Show();
            this.Dispose();
            this.Hide();
        }

        private void picBox_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
            if (Makeselection)
            {
                try
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        Cursor = Cursors.Cross;
                        cropX = e.X;
                        cropY = e.Y;

                        cropPen = new Pen(Color.Crimson, 1);
                        cropPen.DashStyle = DashStyle.Solid;
                    }
                    pictureCamIMG.Refresh();
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void picBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (Makeselection)
            {
                Cursor = Cursors.Default;
            }
        }

        private void picBox_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
            if (Makeselection)
            {
                pictureCamIMG.Cursor = Cursors.Cross;
                try
                {
                    if (pictureCamIMG.Image == null)
                        return;


                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        pictureCamIMG.Refresh();
                        cropWidth = e.X - cropX;
                        cropHeight = e.Y - cropY;
                        pictureCamIMG.CreateGraphics().DrawRectangle(cropPen, cropX, cropY, cropWidth, cropHeight);
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void picBox_MouseEnter(object sender, EventArgs e)
        {
            pictureCamIMG.Focus();
        }

      
        //private void PictureBoxLocation()
        //{
        //    int _x = 0;
        //    int _y = 0;
        //    if (panel1.Width > picBox.Width)
        //    {
        //        _x = (panel1.Width - picBox.Width) / 2;
        //    }
        //    if (panel1.Height > picBox.Height)
        //    {
        //        _y = (panel1.Height - picBox.Height) / 2;
        //    }
        //    picBox.Location = new Point(_x, _y);
        //    picBox.Refresh();
        //}

        private void btnSeleziona_Click(object sender, EventArgs e)
        {
            cam.Stop();
            Makeselection = true;

        }
    }
}
