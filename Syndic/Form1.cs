using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace Syndic
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        SqlConnection cnx = new SqlConnection("Data Source=.;Initial Catalog=BDSyndic;User ID=sa;password=qwerty");
        
        BindingSource bs = new BindingSource();
        DataTable dtAppartement=new DataTable();
        DataTable dtPaiement=new DataTable();
        DataTable dtTaches=new DataTable();
        string typePaiement = "espece";
        private void frmMain_Load(object sender, EventArgs e)
        {
            btnEnregistrer.BackColor = Color.FromArgb(1, 227, 174);
            btnAjouterPaiement.BackColor = Color.FromArgb(1, 227, 174);
            btnAjouterTache.BackColor = Color.FromArgb(1, 227, 174);
            btnSaveTaches.BackColor = Color.FromArgb(1, 227, 174);
            btnModifier.BackColor = Color.FromArgb(238, 238, 238);
            btnSupprimer.BackColor = Color.FromArgb(238, 238, 238);
            pnlForm.Panel1.BackColor = Color.FromArgb(255, 213, 0);
            pnlPaiement.Panel1.BackColor = Color.FromArgb(241, 168, 30);
            pnlTaches.Panel1.BackColor = Color.FromArgb(239, 113, 41);
            pnlConsultation.Panel1.BackColor = Color.FromArgb(217, 75, 40);
            this.BackColor = Color.FromArgb(238, 238, 238);


            SqlDataAdapter daAppartement = new SqlDataAdapter("select * from Appartement", cnx);
            SqlDataAdapter daPaiement = new SqlDataAdapter("select * from Paiement", cnx);
            daAppartement.Fill(dtAppartement);
            daPaiement.Fill(dtPaiement);

            bs.DataSource = dtAppartement;
            txtNumImmeuble.DataBindings.Add("text",bs,"NumImmeuble") ;
            txtNumApp.DataBindings.Add("text", bs, "NumAppartement");
            txtCIN.DataBindings.Add("text", bs, "CIN");
            txtNom.DataBindings.Add("text", bs, "nom_Propriétaire");
            txtPrenom.DataBindings.Add("text", bs, "prenom");
            txtTelFix.DataBindings.Add("text", bs, "tel");
            txtEmail.DataBindings.Add("text", bs, "email");
            txtFraisSyndic.DataBindings.Add("text", bs, "fraisSyndic");
            txtSolde.DataBindings.Add("text", bs, "solde");

            
            try
            {
                SqlCommand cmd = new SqlCommand("select distinct NumImmeuble from Appartement", cnx);
                cnx.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cmbNumImmeuble.Items.Add(dr[0]);
                    cmbNumImmeubleTache.Items.Add(dr[0]);
                    cmbNumImmeubleC.Items.Add(dr[0]);
                }
                
            }
            catch { }
            finally { cnx.Close(); }

            pnlConsultation.Visible = false;
            pnlForm.Visible = true;
            pnlPaiement.Visible = false;
            pnlTaches.Visible = false;
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle Bounds = new Rectangle(0, 0, btnEnregistrer.Width, btnEnregistrer.Height);
            int CornerRadius = 5;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(Bounds.X, Bounds.Y, CornerRadius, CornerRadius, 180, 90);
            path.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y, CornerRadius, CornerRadius, 270, 90);
            path.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
            path.AddArc(Bounds.X, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
            path.CloseAllFigures();

            btnEnregistrer.Region = new Region(path);
            btnModifier.Region = new Region(path);
            btnSupprimer.Region = new Region(path);
            btnAjouterTache.Region = new Region(path);
            btnSaveTaches.Region = new Region(path);
        }

        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            Rectangle Bounds = new Rectangle(0, 0, this.Width, this.Height);
            int CornerRadius = 20;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(Bounds.X, Bounds.Y, CornerRadius, CornerRadius, 180, 90);
            path.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y, CornerRadius, CornerRadius, 270, 90);
            path.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
            path.AddArc(Bounds.X, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
            path.CloseAllFigures();

            this.Region = new Region(path);
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush l = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(5, 117, 230), Color.FromArgb(2, 27, 121), 30F);
            e.Graphics.FillRectangle(l, this.ClientRectangle);
        }
        

        private void button1_Paint_1(object sender, PaintEventArgs e)
        {
            Rectangle Bounds = new Rectangle(0, 0, btnNext.Width, btnNext.Height);
            int CornerRadius = 50;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(Bounds.X, Bounds.Y, CornerRadius, CornerRadius, 180, 90);
            path.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y, CornerRadius, CornerRadius, 270, 90);
            path.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
            path.AddArc(Bounds.X, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
            path.CloseAllFigures();

            btnNext.Region = new Region(path);
            btnPrevious.Region = new Region(path);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bs.MoveNext();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            bs.MovePrevious();
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (btnEnregistrer.Text == "Vider")
            {
                bs.AddNew();
                btnEnregistrer.Text = "Enregistre";
                txtNumImmeuble.Text = "";
                txtNumApp.Text = "";
                txtCIN.Text = "";
                txtNom.Text = "";
                txtPrenom.Text = "";
                txtTelFix.Text = "";
                txtEmail.Text = "";
                txtFraisSyndic.Text = "";
                txtSolde.Text = "";
            }
            else
            {
                try
                {
                    SqlCommand cm = new SqlCommand("insert into appartement values(" + txtNumImmeuble.Text + "," + txtNumApp.Text + ",'" + txtCIN.Text + "','" + txtNom.Text + "','" + txtPrenom.Text + "','" + txtTelFix.Text + "','" + txtEmail.Text + "'," + txtFraisSyndic.Text + "," + txtSolde.Text + ")", cnx);
                    cnx.Open();
                    cm.ExecuteNonQuery();
                    btnEnregistrer.Text = "Vider";
                    dtAppartement.Rows.Add(new string[] { txtNumImmeuble.Text, txtNumApp.Text, txtCIN.Text, txtNom.Text, txtPrenom.Text, txtTelFix.Text, txtEmail.Text, txtFraisSyndic.Text, txtSolde.Text });
                    MessageBox.Show("Appartement Ajoute", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    cnx.Close();
                }
            }
        }

        private void pnlForm_Paint(object sender, PaintEventArgs e)
        {
            Rectangle Bounds = new Rectangle(0, 0, pnlForm.Width, pnlForm.Height);
            int CornerRadius = 20;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(Bounds.X, Bounds.Y, CornerRadius, CornerRadius, 180, 90);
            path.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y, CornerRadius, CornerRadius, 270, 90);
            path.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
            path.AddArc(Bounds.X, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
            path.CloseAllFigures();

            pnlForm.Region = new Region(path);
            pnlPaiement.Region = new Region(path);
            pnlTaches.Region = new Region(path);
            pnlConsultation.Region = new Region(path);
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("update appartement set CIN='" + txtCIN.Text + "',nom_Propriétaire='" + txtNom.Text + "',prenom='" + txtPrenom.Text + "',tel='" + txtTelFix.Text + "',email='" + txtEmail.Text + "',fraisSyndic=" + txtFraisSyndic.Text + ",solde=" + txtSolde.Text + " where numImmeuble=" + txtNumImmeuble.Text + " and numAppartement=" + txtNumApp.Text, cnx);
                cnx.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Appartement Modifie", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cnx.Close();
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("delete appartement where numImmeuble=" + txtNumImmeuble.Text + " and numAppartement=" + txtNumApp.Text, cnx);
                cnx.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Appartement Supprime", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bs.RemoveCurrent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cnx.Close();
            }
        }

        private void rdoEspece_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCheque.Checked)
            {
                typePaiement = "cheque";
                label14.Text = "Code Cheque";
                label14.Visible = true;
                txtCodePaiement.Visible = true;
                txtCodePaiement.Text = "";
            }
            else if (rdoEspece.Checked)
            {
                typePaiement = "espece";
                label14.Visible = false;
                txtCodePaiement.Visible = false;
                txtCodePaiement.Text = "0";
            }
            else if (rdoVirement.Checked)
            {
                typePaiement = "virement";
                label14.Text = "Code Virement";
                label14.Visible = true;
                txtCodePaiement.Visible = true;
                txtCodePaiement.Text = "";
            }
        }

        private void btnAjouterPaiement_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into paiement values(" + cmbNumImmeuble.Text + "," + cmbNumApp.Text + ",getdate(),'" + typePaiement + "','" + txtMontant.Text + "','"+txtCodePaiement.Text+"')", cnx);
                cnx.Open();
                cmd.ExecuteNonQuery();
                if(MessageBox.Show("Voulez vous imprimer le recu ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    frmRapport f = new frmRapport();
                    f.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cnx.Close();
            }
        }

        private void cmbNumImmeuble_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbNumApp.Items.Clear();
                SqlCommand cmd = new SqlCommand("select distinct NumAppartement from Appartement where numImmeuble="+cmbNumImmeuble.Text, cnx);
                cnx.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cmbNumApp.Items.Add(dr[0]);
                }

            }
            catch { }
            finally { cnx.Close(); }
        }
        

        private void btnAjouterTache_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into taches values(" + cmbNumImmeubleTache.Text + ",NULL,'" + txtNomTache.Text + "'," + txtFraisTache.Text + ")", cnx);
                cnx.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Tache Ajoute", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cnx.Close();
            }
        }
        SqlDataAdapter da;
        SqlCommandBuilder cb = new SqlCommandBuilder();
        DataSet ds;
        private void cmbNumImmeubleTache_SelectedIndexChanged(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("select * from taches where numImmeuble=" + cmbNumImmeubleTache.Text, cnx);
            ds = new DataSet();
            da.Fill(ds, "t");
            dgvTaches.DataSource = ds.Tables["t"];
            cb.DataAdapter = da;
        }

        private void btnSaveTaches_Click(object sender, EventArgs e)
        {
            try
            {
                da.InsertCommand = cb.GetInsertCommand();
                da.UpdateCommand = cb.GetUpdateCommand();
                da.DeleteCommand = cb.GetDeleteCommand();
                da.Update(ds, "t");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbNumImmeubleC_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbNUmAppartementC.Items.Clear();
                SqlCommand cmd = new SqlCommand("select distinct NumAppartement from Appartement where numImmeuble=" + cmbNumImmeubleC.Text, cnx);
                cnx.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cmbNUmAppartementC.Items.Add(dr[0]);
                }

            }
            catch { }
            finally { cnx.Close(); }
            SqlDataAdapter dat = new SqlDataAdapter("select * from taches where numImmeuble=" + cmbNumImmeubleC.Text, cnx);
            ds = new DataSet();
            dat.Fill(ds, "ta");
            dgvTacheC.DataSource = ds.Tables["ta"];
            dat = new SqlDataAdapter("select * from appartement where numImmeuble=" + cmbNumImmeubleC.Text, cnx);
            dat.Fill(ds, "ap");
            dgvAppartement.DataSource = ds.Tables["ap"];
        }

        private void cmbNUmAppartementC_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter dat = new SqlDataAdapter("select datePaiment.* from Paiement join datePaiment on datePaiment.NumPaiment=Paiement.NumPaiement where numImmeuble=" + cmbNumImmeubleC.Text+" and numAppartement="+cmbNUmAppartementC.Text, cnx);
            ds = new DataSet();
            dat.Fill(ds, "ta");
            dgvPaiementC.DataSource = ds.Tables["ta"];

            dat = new SqlDataAdapter("select * from appartement where numImmeuble=" + cmbNumImmeubleC.Text + " and numAppartement=" + cmbNUmAppartementC.Text, cnx);
            dat.Fill(ds, "ap");
            dgvAppartement.DataSource = ds.Tables["ap"];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlConsultation.Visible = false;
            pnlForm.Visible = true;
            pnlPaiement.Visible = false;
            pnlTaches.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlConsultation.Visible = false;
            pnlForm.Visible = false;
            pnlPaiement.Visible = true;
            pnlTaches.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pnlConsultation.Visible = false;
            pnlForm.Visible = false;
            pnlPaiement.Visible = false;
            pnlTaches.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pnlConsultation.Visible = true;
            pnlForm.Visible = false;
            pnlPaiement.Visible = false;
            pnlTaches.Visible = false;
        }
    }
}
