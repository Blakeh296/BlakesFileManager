using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Default.Classes;
using TagLib;
using Ionic.Zip;
using System.IO;

namespace Default
{
    public partial class Form1 : Form
    {
        bool monitorActive;
        Queue<string> fileQ = new Queue<string>();
        DateTime lastSearchTime;
        int fileCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            btnStartStop.Visible = false;
            btnGetFolder.BackColor = Color.Red;
            btnGetFolder.ForeColor = Color.White;
        }

        private void fileSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Hide this form
            this.Hide();
            //Create the FileSearch Form object
            FileSearch formFileSearch = new FileSearch();
            //Display the form
            formFileSearch.ShowDialog();
            //Close this form
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string addedFolder;

            try
            {
                errorProvider.Clear(); //Clear all errors if they havent been already

                btnAdd.ForeColor = Color.Black;
                btnAdd.BackColor = Color.FromName("Control");

                if (tbArchiveFolder.Text.Length > 0)
                {
                    btnStartStop.Visible = true;
                }
                else
                {
                    btnGetFolder.ForeColor = Color.White;
                    btnGetFolder.BackColor = Color.Red;
                }
                //If the user has selected a folder, add it to the list box if it isn't already
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    //set our string equal to the selected item 'File Path'
                    addedFolder = folderBrowserDialog.SelectedPath;
                    //IF the ListBox doesn't contain the file path
                    if (!lbMonitoredFolders.Items.Contains(addedFolder))
                    {
                        //Add the file path to the ListBox
                        lbMonitoredFolders.Items.Add(addedFolder);
                        statusStrip1.BackColor = Color.Green;
                        statusStrip1.ForeColor = Color.White;
                        toolStripStatusLabel1.Text = "ADDED : " + addedFolder;
                    }
                    else
                    {
                        //Highlight the already existing entry
                        lbMonitoredFolders.SelectedItem = lbMonitoredFolders.Items[lbMonitoredFolders.Items.IndexOf(addedFolder)];
                    }

                    pictureBox2.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ...");
            }
        }
      
        private void btnRemove_Click(object sender, EventArgs e)
        {
            string filePath;

            try
            {
                //If a ListBox item is selected
                if(lbMonitoredFolders.SelectedItem != null)
                {
                    //Grab file path for use on line 119
                    filePath = lbMonitoredFolders.SelectedItem.ToString();
                    //Remove the item
                    lbMonitoredFolders.Items.Remove(lbMonitoredFolders.SelectedItem);

                    //Change the notifying statusstrip color 
                    statusStrip1.BackColor = Color.Red;
                    statusStrip1.ForeColor = Color.White;
                    //Write to the user that the file path was removed
                    toolStripStatusLabel1.Text = "REMOVED : " + filePath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ...");
            }
        }

        private void btnGetFolder_Click(object sender, EventArgs e)
        {
            string filePath; //File path

            try
            {
                //Get rid of the color to the button
                btnGetFolder.BackColor = Color.FromName("Control");
                btnGetFolder.ForeColor = Color.Black;

                errorProvider.Clear(); //Clear all errors if the program hasn't already

                //If none of the required fields are null, then switch the button color to green
                if (lbMonitoredFolders.Items.Count > 0)
                {
                    btnStartStop.Visible = true;
                }
                else
                {
                    //Change the color of the button to show the user they need to pick a file
                    btnAdd.ForeColor = Color.White;
                    btnAdd.BackColor = Color.Red;
                }

                //If the user selects a folder & clicks okay
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    //Make the TextBox equal to the file path the user picked
                    tbArchiveFolder.Text = folderBrowserDialog.SelectedPath;
                    filePath = folderBrowserDialog.SelectedPath;
                    pictureBox1.Visible = true;

                    //Change the color and text of the status strip to notify the user
                    statusStrip1.BackColor = Color.Green;
                    statusStrip1.ForeColor = Color.White;
                    toolStripStatusLabel1.Text = "NEW Archive : " + filePath ;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ...");
            }
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            bool readyToMonitor = true;

            try
            {
                //if TextBox text length is Greater than 0, readyToMonitor == TRUE
                readyToMonitor = (tbArchiveFolder.Text.Length > 0);
                //if the Directory in tbArchiveFolder exists readyToMonitor == TRUE
                readyToMonitor = Directory.Exists(tbArchiveFolder.Text);
                //readyToMonitor == true if the list box has at least one item
                readyToMonitor = lbMonitoredFolders.Items.Count > 0;


                //IF readyToMonitor == TRUE
                if (readyToMonitor)
                {                       //If the color of the button = green or in off position
                    if (btnStartStop.BackColor == Color.Green)
                    {
                        //Monitoring will be set to on
                        //Change colors of the menustrip to notify the user
                        menuStrip1.BackColor = Color.Green;
                        menuStrip1.ForeColor = Color.White;
                        statusStrip1.BackColor = Color.Green;
                        statusStrip1.ForeColor = Color.White;
                        btnStartStop.ForeColor = Color.White;
                        btnStartStop.BackColor = Color.Red;
                        btnStartStop.Text = "Stop Monitoring";
                        toolStripStatusLabel1.Text = "Monitoring ON ...";
                        toolStripStatusLabel2.Text = "";
                        timer.Enabled = true;
                        lastSearchTime = DateTime.Now;
                    }
                    else
                    {
                        //Monitoring will be set to off

                        menuStrip1.BackColor = Color.FromName("Control");
                        menuStrip1.ForeColor = Color.Black;
                        statusStrip1.ForeColor = Color.Black;
                        statusStrip1.BackColor = Color.FromName("Control");
                        btnStartStop.ForeColor = Color.White;
                        btnStartStop.BackColor = Color.Green;
                        toolStripStatusLabel1.Text = "Monitoring OFF ...";
                        toolStripStatusLabel2.Text = "";
                        btnStartStop.Text = "Start Monitoring";
                        timer.Enabled = false;
                        monitorActive = false;
                    }
                }
                else
                {
                   if (tbArchiveFolder.Text.Length == 0 && lbMonitoredFolders.Items.Count == 0)
                    {
                        menuStrip1.ForeColor = Color.White;
                        menuStrip1.BackColor = Color.Red;
                        statusStrip1.ForeColor = Color.White;
                        statusStrip1.BackColor = Color.Red;
                        toolStripStatusLabel1.Text = "* Please select a Archive Folder * /";
                        toolStripStatusLabel2.Text = "/ * Pick at least one Folder to monitor *";
                        errorProvider.SetError(btnAdd, "Click to pick a file to Monitor ...");
                        errorProvider.SetError(btnGetFolder, "Click to pick a archive folder ...");
                        pictureBox1.Visible = false;
                        pictureBox2.Visible = false;
                    }
                   else if (!Directory.Exists(tbArchiveFolder.Text))
                    {
                        menuStrip1.ForeColor = Color.White;
                        menuStrip1.BackColor = Color.Red;
                        statusStrip1.ForeColor = Color.White;
                        statusStrip1.BackColor = Color.Red;
                        toolStripStatusLabel1.Text = "* I'm sorry, the Archive folder selected does not exist *";
                        toolStripStatusLabel2.Text = "";
                    }
                   else if (lbMonitoredFolders.Items.Count == 0)
                    {
                        menuStrip1.ForeColor = Color.White;
                        menuStrip1.BackColor = Color.Red;
                        statusStrip1.ForeColor = Color.White;
                        statusStrip1.BackColor = Color.Red;
                        toolStripStatusLabel1.Text = "* Pick at least One folder to monitor *";
                        toolStripStatusLabel2.Text = "";
                        errorProvider.SetError(btnAdd, "Click to pick a file to Monitor ...");
                        pictureBox2.Visible = false;
                    }
                   else if (tbArchiveFolder.Text.Length == 0)
                    {
                        menuStrip1.ForeColor = Color.White;
                        menuStrip1.BackColor = Color.Red;
                        statusStrip1.ForeColor = Color.White;
                        statusStrip1.BackColor = Color.Red;
                        toolStripStatusLabel1.Text = "* Please select a Archive Folder *";
                        toolStripStatusLabel2.Text = "";
                        pictureBox1.Visible = false;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ...");
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //Turn off to allow for however much time the Archive proccess takes
            timer.Enabled = false;
            GetFilesToArchive();

            //Reactivate the timer if the user has not turned off monitoring
            lastSearchTime = DateTime.Now;
            timer.Enabled = monitorActive;
            Application.DoEvents();
        }
        
        private void GetFilesToArchive()
        {
            try
            {
                //For each string item in the list box
                foreach(string monitoredPath in lbMonitoredFolders.Items)
                {
                    ScanFolder(monitoredPath); //Scanfolder on that path
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ...");
            }
        }

        private void ScanFolder(string StartingFolder)
        {
            DateTime fileWriteTime;

            try
            {
                //Add each file to the queue if its not already
                foreach (string fileName in Directory.GetFiles(StartingFolder))
                {
                    //Get the last write time on the file
                    fileWriteTime = System.IO.File.GetLastWriteTime(fileName);

                    //If the write time is newer than last search time
                    if(fileWriteTime > lastSearchTime)
                    {
                        //If the Queue does not contain the path
                        if(!fileQ.Contains(fileName))
                        {
                            //Add the path to Q
                            fileQ.Enqueue(fileName);
                        }
                    }
                }

                //Go to the next Directory
                foreach (string dirName in Directory.GetDirectories(StartingFolder))
                {
                    ScanFolder(dirName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ...");
            }
        }

        private void setArchiveFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath;

            try
            {
                //Get rid of the color to the button
                btnGetFolder.BackColor = Color.FromName("Control");
                btnGetFolder.ForeColor = Color.Black;

                errorProvider.Clear();

                //If none of the required fields are null, then switch the button color to green
                if (lbMonitoredFolders.Items.Count > 0)
                {
                    btnStartStop.Visible = true; // Enable this if conditions are met
                }
                else
                {
                    //Change the color of the button to show the user they need to pick a file
                    btnAdd.ForeColor = Color.White;
                    btnAdd.BackColor = Color.Red;
                }

                //If the user selects a folder & clicks okay
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    //Make the TextBox equal to the file path the user picked
                    tbArchiveFolder.Text = folderBrowserDialog.SelectedPath;
                    //Grab the file path for line 366
                    filePath = folderBrowserDialog.SelectedPath;
                    pictureBox1.Visible = true;

                    //Change the color and text of the status strip to notify the user
                    statusStrip1.BackColor = Color.Green;
                    statusStrip1.ForeColor = Color.White;
                    //Notify the user with a message containing the file path
                    toolStripStatusLabel1.Text = "NEW Archive : " + filePath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ...");
            }
        }

        private void addFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string addedFolder; //Will be used to grap specific file path

            try
            {
                errorProvider.Clear(); //Take away existing errors if they havent been already

                //Set the button colors back to default
                btnAdd.ForeColor = Color.Black;
                btnAdd.BackColor = Color.FromName("Control");

                if (tbArchiveFolder.Text.Length > 0)
                {
                    btnStartStop.Visible = true; //Enable the button
                }
                else
                {
                    //Change the color of the button to notify the user what they should do next
                    btnGetFolder.ForeColor = Color.White;
                    btnGetFolder.BackColor = Color.Red;
                }

                //If the user has selected a folder, add it to the list box if it isn't already
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    //set our string equal to the selected item 'File Path'
                    addedFolder = folderBrowserDialog.SelectedPath;
                    //IF the ListBox doesn't contain the file path
                    if (!lbMonitoredFolders.Items.Contains(addedFolder))
                    {
                        //Add the file path to the ListBox
                        lbMonitoredFolders.Items.Add(addedFolder);
                        statusStrip1.BackColor = Color.Green;
                        statusStrip1.ForeColor = Color.White;
                        toolStripStatusLabel1.Text = "ADDED : " + addedFolder;
                    }
                    else
                    {
                        //Highlight the already existing entry
                        lbMonitoredFolders.SelectedItem = lbMonitoredFolders.Items[lbMonitoredFolders.Items.IndexOf(addedFolder)];
                    }

                    //Display picture box
                    pictureBox2.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ...");
            }
        }

        private void removeFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath; // We will use this to grab the file path to display to the user

            try
            {
                //If a ListBox item is selected
                if (lbMonitoredFolders.SelectedItem != null)
                {
                    //Grab the file path to display for the user in line 442
                    filePath = lbMonitoredFolders.SelectedItem.ToString();
                    //Remove the item
                    lbMonitoredFolders.Items.Remove(lbMonitoredFolders.SelectedItem);

                    //Change the color of the status strip
                    statusStrip1.BackColor = Color.Red;
                    statusStrip1.ForeColor = Color.White;
                    //Notify the user of this change
                    toolStripStatusLabel1.Text = "REMOVED : " + filePath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ...");
            }
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Hide this form
            this.Hide();
            //Running in the background
            //Create the object for the same form
            Form1 sameForm = new Form1();
            //Display the new form
            sameForm.ShowDialog();
            //Close this page
            this.Close();
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //DialogResault variable will save the resault from a message box with buttons
            DialogResult quit = MessageBox.Show("Are you sure you want to Quit?", "Are you sure?", MessageBoxButtons.YesNo);

            //Then compare DialogResault against DialogResault.Yes
            if (quit == DialogResult.Yes)
            {
                Application.Exit(); //Close Everything
            }
        }
    }
}
