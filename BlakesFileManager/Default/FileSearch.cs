using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace Default
{
    public partial class FileSearch : Form
    {
        public FileSearch()
        {
            InitializeComponent();
        }

        private void btnFolderSelect_Click(object sender, EventArgs e)
        {
            try
            {
                //Show the folder dialog & get the folder the user selects
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    tbFolder.Text = folderBrowser.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void selectFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Show the folder dialog & get the folder the user selects
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    tbFolder.Text = folderBrowser.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Reset the menuStrip colors
            menuStrip.ForeColor = Color.Black;
            menuStrip.BackColor = Color.FromName("Control");

            //Reset Status strip & colors
            statusLabel1.ForeColor = Color.Black;
            statusStrip.BackColor = Color.FromName("Control");

            try
            {
                if (tbFolder.Text == "")
                {
                    //Color the menu strip, just for fun
                    menuStrip.BackColor = Color.Red;
                    menuStrip.ForeColor = Color.White;

                    statusStrip.BackColor = Color.Red;
                    statusLabel1.ForeColor = Color.White;
                    statusLabel1.Text = "The Directory Choosen is empty \\ *CHECK Directory Path*";

                    //Tell the user they will be redirected
                    MessageBox.Show("Please select a directory.");

                    //Show the folder dialog & get the folder the user selects
                    if (folderBrowser.ShowDialog() == DialogResult.OK)
                    {
                        tbFolder.Text = folderBrowser.SelectedPath;
                    }
                }

                //Add colums to dgView if they're not already there
                if (dgView.ColumnCount == 0)
                {
                    dgView.Columns.Add("FileName", "File Name");
                    dgView.Columns.Add("PathName", "Path Name");
                    dgView.Columns.Add("FileSize", "File Size");
                    dgView.Columns.Add("Modified", "Modified");
                }

                //If the entries are correct, clear the gridView and start the search
                if (tbFolder.Text.Length > 0 && tbSearch.Text.Length > 0)
                {
                    // Clear the gridView
                    dgView.Rows.Clear();
                    SearchFiles(tbFolder.Text, tbSearch.Text);
                }

                if (dgView.Rows.Count > 0)
                {
                    //Color the menu strip, just for fun
                    menuStrip.BackColor = Color.Green;
                    menuStrip.ForeColor = Color.White;

                    //Update the StatusStrip with the number of files found
                    statusStrip.BackColor = Color.Green;
                    statusLabel1.ForeColor = Color.White;
                    statusLabel1.Text = "Finished - " + dgView.Rows.Count.ToString() + " files found. ";
                }
                else
                {
                    //Color the menu strip, just for fun
                    menuStrip.BackColor = Color.Red;
                    menuStrip.ForeColor = Color.White;

                    statusStrip.BackColor = Color.Red;
                    statusLabel1.ForeColor = Color.White;
                    statusLabel1.Text = "The Directory Choosen is empty \\ *CHECK Directory Path*";
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void SearchFiles(string StartingFolder, string Pattern)
        {
            //Recursion search all of the subdirectories
            //Get the directories and files
            FileInfo fileInfo;

            //Show the current folder being processed
            //Slows things down a bit but shows the user somekind of progress

            statusLabel1.Text = "Searching: " + StartingFolder;
            //Application.DoEvents() forces the program to stop and force push incomplete UI changes
            Application.DoEvents();

            try
            {
                //Add each file to the grid
                foreach (string fileName in Directory.GetFiles(StartingFolder, Pattern))
                {
                    if (fileName.Length < 260)
                    {
                        //Gets all the file information
                        fileInfo = new FileInfo(fileName);
                        //Add information to the dgView
                        dgView.Rows.Add(fileInfo.Name, fileInfo.Directory, fileInfo.Length, fileInfo.LastWriteTime);
                    }
                    else
                    {
                        dgView.Rows.Add(fileName.Substring(fileName.LastIndexOf("\\") + 1), StartingFolder, null, null);
                    }
                }

                //Go to next Directory
                foreach (string dirName in Directory.GetDirectories(StartingFolder))
                {
                    SearchFiles(dirName, Pattern);
                }
            }
            catch (Exception ex)
            {
               // tbErrors.Text = ex.Message + Environment.NewLine + tbErrors.Text;

                statusStrip.BackColor = Color.Red;
                statusLabel1.ForeColor = Color.White;
                statusLabel1.Text = ex.Message;
            }
        }

        

        private void dgView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //If the user double clicks anywhere on a row, open the specified path in Windows Explorer
                DataGridViewRow rowCurrent = dgView.CurrentRow;

                if (rowCurrent.Cells["PathName"].Value != null)
                {
                    Process.Start(rowCurrent.Cells["PathName"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Display a message box with a question and Yes/No buttons
            DialogResult quit = MessageBox.Show("Are you sure you want to quit?", "Quit FileSearch?", MessageBoxButtons.YesNo);

            // If the user says yes
            if (quit == DialogResult.Yes)
            {
                Application.Exit(); //Close Entire application
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Reset the MenuStrip colors
            menuStrip.BackColor = Color.FromName("Control");
            menuStrip.ForeColor = Color.Black;

            //Reset the status Strip colors & text
            statusLabel1.ForeColor = Color.Black;
            statusStrip.BackColor = Color.FromName("Control");
            statusLabel1.Text = "";

            //Clear the text
            tbFolder.Text = "";

            //Reset to default search 
            tbSearch.Text = "*.*";

            //Clear the Data Grid View
            dgView.Rows.Clear();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Display a message box with a question and Yes/No buttons
            DialogResult quit = MessageBox.Show("Are you sure you want to quit?", "Quit FileSearch?", MessageBoxButtons.YesNo);

            // If the user says yes
            if (quit == DialogResult.Yes)
            {
                Application.Exit(); //Close Entire application
            }
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Reset the menuStrip colors
            menuStrip.ForeColor = Color.Black;
            menuStrip.BackColor = Color.FromName("Control");

            //Reset Status strip & colors
            statusLabel1.ForeColor = Color.Black;
            statusStrip.BackColor = Color.FromName("Control");

            try
            {
                if (tbFolder.Text == "")
                {
                    //Color the menu strip, just for fun
                    menuStrip.BackColor = Color.Red;
                    menuStrip.ForeColor = Color.White;

                    statusStrip.BackColor = Color.Red;
                    statusLabel1.ForeColor = Color.White;
                    statusLabel1.Text = "The Directory Choosen is empty \\ *CHECK Directory Path*";

                    //Tell the user they will be redirected
                    MessageBox.Show("Please select a directory.");

                    //Show the folder dialog & get the folder the user selects
                    if (folderBrowser.ShowDialog() == DialogResult.OK)
                    {
                        tbFolder.Text = folderBrowser.SelectedPath;
                    }
                }

                //Add colums to dgView if they're not already there
                if (dgView.ColumnCount == 0)
                {
                    dgView.Columns.Add("FileName", "File Name");
                    dgView.Columns.Add("PathName", "Path Name");
                    dgView.Columns.Add("FileSize", "File Size");
                    dgView.Columns.Add("Modified", "Modified");
                }

                //If the entries are correct, clear the gridView and start the search
                if (tbFolder.Text.Length > 0 && tbSearch.Text.Length > 0)
                {
                    // Clear the gridView
                    dgView.Rows.Clear();
                    SearchFiles(tbFolder.Text, tbSearch.Text);
                }

                if (dgView.Rows.Count > 0)
                {
                    //Color the menu strip, just for fun
                    menuStrip.BackColor = Color.Green;
                    menuStrip.ForeColor = Color.White;

                    //Update the StatusStrip with the number of files found
                    statusStrip.BackColor = Color.Green;
                    statusLabel1.ForeColor = Color.White;
                    statusLabel1.Text = "Finished - " + dgView.Rows.Count.ToString() + " files found. ";
                }
                else
                {
                    //Color the menu strip, just for fun
                    menuStrip.BackColor = Color.Red;
                    menuStrip.ForeColor = Color.White;

                    statusStrip.BackColor = Color.Red;
                    statusLabel1.ForeColor = Color.White;
                    statusLabel1.Text = "The Directory Choosen is empty \\ *CHECK Directory Path*";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Reset the MenuStrip colors
            menuStrip.BackColor = Color.FromName("Control");
            menuStrip.ForeColor = Color.Black;

            //Reset the status Strip colors & text
            statusLabel1.ForeColor = Color.Black;
            statusStrip.BackColor = Color.FromName("Control");
            statusLabel1.Text = "";

            //Clear the text
            tbFolder.Text = "";

            //Reset to default search 
            tbSearch.Text = "*.*";

            //Clear the Data Grid View
            dgView.Rows.Clear();
        }

        private void systemMonitoringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 newForm1 = new Form1();
            newForm1.ShowDialog();
            this.Close();
        }
    }
}
