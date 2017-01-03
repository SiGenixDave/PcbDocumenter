using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PCB_Documenter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            cBoxPCBThickness.SelectedIndex = 1;
            cBoxLayers.SelectedIndex = 1;
            cBoxName.SelectedIndex = 0;
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox3.Visible = false;

            DataGridUpdate();
        }

        private void buttonSelectInputFolder_Click(object sender, EventArgs e)
        {
            // Look in this folder and all subfolders for files
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtInputDirectory.Text = folderBrowserDialog1.SelectedPath;
                txtOutputDirectory.Text = txtInputDirectory.Text + @"\Deliverables";
            }
        }

        private void buttonSelectOutputFolder_Click(object sender, EventArgs e)
        {
            // Copy all output files here
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtOutputDirectory.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        // Screens are actually visible group boxes
        private UInt16 activeScreen = 1;

        private const UInt16 lastScreen = 3;

        private void buttonNext_Click(object sender, EventArgs e)
        {
            switch (activeScreen)
            {
                case 1:
                    // Verify all information has been added to the text and combo boxes
                    if (ValidateInfo() == false)
                    {
                        return;
                    }
                    break;
            }

            // Enable / Disable the screen buttons based on the current screen
            buttonBack.Enabled = true;
            if (activeScreen + 1 <= lastScreen)
            {
                activeScreen++;
            }
            if (activeScreen == lastScreen)
            {
                buttonNext.Enabled = false;

                //Update the list with the included files
                UpdateDataGridItems();

                DataGridUpdate();
            }
            SetActiveScreen();
        }

        private Boolean ValidateInfo()
        {
            if ((cBoxName.Text == "") || (txtPhoneOffice.Text == "") || (txtPhoneCell.Text == "") ||
                 (txtEmail.Text == "") || (txtPCBTitle.Text == "") ||
                 (txtRevision.Text == "") || (txtX.Text == "") || (txtY.Text == "") ||
                 (cBoxPCBThickness.Text == "") || (cBoxLayers.Text == "") || (cBoxPCBThickness.Text == "") ||
                 (txtInputDirectory.Text == "") || (txtOutputDirectory.Text == ""))
            {
                MessageBox.Show("Please fill all info");
                return false;
            }
            return true;
        }

        private void UpdateDataGridItems()
        {
            datagridItems.Clear();

            foreach (ListViewItem l in listViewInclude.Items)
            {
                UpdatedFiles uf = new UpdatedFiles();

                Char[] splitIt = { '.' };
                String[] trimmedPrefix = l.SubItems[0].Text.Split(splitIt);

                uf.Name = txtPCBPartNumber.Text + "-" + txtRevision.Text + "." + trimmedPrefix[1];
                uf.Name = uf.Name.ToUpper();
                uf.Description = l.SubItems[2].Text;

                uf.OriginalDirectory = l.SubItems[1].Text;
                uf.OriginalFileName = l.SubItems[0].Text;

                datagridItems.Add(uf);
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            buttonNext.Enabled = true;
            if (activeScreen - 1 >= 1)
            {
                activeScreen--;
            }
            if (activeScreen == 1)
            {
                buttonBack.Enabled = false;
            }
            SetActiveScreen();
        }

        private void SetActiveScreen()
        {
            switch (activeScreen)
            {
                case 1:
                    groupBox1.Visible = true;
                    groupBox2.Visible = false;
                    groupBox3.Visible = false;
                    break;

                case 2:
                    groupBox1.Visible = false;
                    groupBox2.Visible = true;
                    groupBox3.Visible = false;
                    PopulateListBoxes();
                    break;

                case 3:
                    groupBox1.Visible = false;
                    groupBox2.Visible = false;
                    groupBox3.Visible = true;
                    break;

                default:
                    break;
            }
        }

        private void cBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 index = cBoxName.SelectedIndex;

            txtEmail.Text = contact[index].email;
            txtPhoneOffice.Text = contact[index].phoneOffice;
            txtPhoneCell.Text = contact[index].phoneCell;
        }

        private struct ContactInfo
        {
            public String name;
            public String phoneOffice;
            public String phoneCell;
            public String email;
        }

        private ContactInfo[] contact = new ContactInfo[]
        {
            new ContactInfo
            {
                name = "Tom Schneider",
                phoneOffice = "(412) 380-7572 x25",
                phoneCell = "(724) 462-5219",
                email = "tschneider@sigenix.com",
            },

            new ContactInfo
            {
                name = "Nik Shaffer",
                phoneOffice = "(412) 380-7572 x32",
                phoneCell = "(412) 862-6157",
                email = "nshaffer@sigenix.com",
            },

            new ContactInfo
            {
                name = "Jerry Joseph",
                phoneOffice = "(412) 380-7572 x23",
                phoneCell = "(610) 393-8818",
                email = "jjoseph@sigenix.com",
            },
        };

        private struct FileDescription
        {
            public String type;
            public String description;
        }

        private FileDescription[] file = new FileDescription[]
        {
            new FileDescription { type = "*.gtl",                   description = "Top Copper"},
            new FileDescription { type = "*.gbl",                   description = "Bottom Copper"},
            new FileDescription { type = "*.g1",                    description = "Inner Signal Layer 1"},
            new FileDescription { type = "*.g2",                    description = "Inner Signal Layer 2"},
            new FileDescription { type = "*.g3",                    description = "Inner Signal Layer 3"},
            new FileDescription { type = "*.g4",                    description = "Inner Signal Layer 4"},
            new FileDescription { type = "*.g5",                    description = "Inner Signal Layer 5"},
            new FileDescription { type = "*.g6",                    description = "Inner Signal Layer 6"},
            new FileDescription { type = "*.g7",                    description = "Inner Signal Layer 7"},
            new FileDescription { type = "*.g8",                    description = "Inner Signal Layer 8"},
            new FileDescription { type = "*.gp1",                   description = "Inner Plane Layer 1"},
            new FileDescription { type = "*.gp2",                   description = "Inner Plane Layer 2"},
            new FileDescription { type = "*.gp3",                   description = "Inner Plane Layer 3"},
            new FileDescription { type = "*.gp4",                   description = "Inner Plane Layer 4"},
            new FileDescription { type = "*.gp5",                   description = "Inner Plane Layer 5"},
            new FileDescription { type = "*.gp6",                   description = "Inner Plane Layer 6"},
            new FileDescription { type = "*.gp7",                   description = "Inner Plane Layer 7"},
            new FileDescription { type = "*.gp8",                   description = "Inner Plane Layer 8"},
            new FileDescription { type = "*.gto",                   description = "Top Silkscreen"},
            new FileDescription { type = "*.gbo",                   description = "Bottom Silkscreen"},
            new FileDescription { type = "*.gts",                   description = "Top Soldermask"},
            new FileDescription { type = "*.gbs",                   description = "Bottom Soldermask"},
            new FileDescription { type = "*.gtp",                   description = "Top Paste"},
            new FileDescription { type = "*.gbp",                   description = "Bottom Paste"},
            new FileDescription { type = "*.gko",                   description = "Board outline"},
            new FileDescription { type = "NC Drill.TXT",            description = "RS-274X Drill Data"},
            new FileDescription { type = "NC Drill-RoundHoles.TXT", description = "RS-274X Drill Data"},
            new FileDescription { type = "NC Drill-SlotHoles.TXT",  description = "RS-274X Slot Data"},
            new FileDescription { type = "*.gd1",                   description = "Drill drawing"},
            new FileDescription { type = "*.ipc",                   description = "IPC-356 netlist"},
            new FileDescription { type = "Pick and Place*.txt",     description = "Pick and Place file"},
            new FileDescription { type = "*Artwork*.pdf",           description = "Artwork Drawing"},
            new FileDescription { type = "*.zip",                   description = "ODB++ Archive"},
        };

        // Screen 2
        private String dir = "";

        private void PopulateListBoxes()
        {
            // Don't repopulate if input directory hasn't changed
            if (dir == txtInputDirectory.Text)
            {
                return;
            }

            dir = txtInputDirectory.Text;

            List<String> includedListFile = new List<String>();

            // Populate the included file listview
            foreach (FileDescription f in file)
            {
                String[] files = System.IO.Directory.GetFiles(dir, f.type, SearchOption.AllDirectories).Where(fileName => !fileName.Contains("Deliverables")).Select(fileName => Path.GetFileName(fileName)).ToArray();
                String[] dirs = System.IO.Directory.GetFiles(dir, f.type, SearchOption.AllDirectories).Where(fileName => !fileName.Contains("Deliverables")).Select(fileName => Path.GetDirectoryName(fileName)).ToArray();

                for (UInt16 i = 0; i < files.Length; i++)
                {
                    ListViewItem lvi = new ListViewItem(files[i]);
                    lvi.SubItems.Add(dirs[i]);
                    lvi.SubItems.Add(f.description);
                    listViewInclude.Items.Add(lvi);

                    includedListFile.Add(files[i]);
                }
            }

            String[] xfiles = System.IO.Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories).Select(fileName => Path.GetFileName(fileName)).ToArray();
            String[] xdirs = System.IO.Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories).Select(fileName => Path.GetDirectoryName(fileName)).ToArray();

            for (UInt16 i = 0; i < xfiles.Length; i++)
            {
                if (includedListFile.Contains(xfiles[i]) == false)
                {
                    ListViewItem lvi = new ListViewItem(xfiles[i]);
                    lvi.SubItems.Add(xdirs[i]);
                    lvi.SubItems.Add("Unknown File Type");
                    listViewExclude.Items.Add(lvi);
                }
            }
        }

        private void buttonExclude_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in listViewInclude.SelectedItems)
            {
                listViewInclude.Items.Remove(eachItem);
                listViewExclude.Items.Add(eachItem);
            }
        }

        private void buttonInclude_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in listViewExclude.SelectedItems)
            {
                listViewExclude.Items.Remove(eachItem);
                listViewInclude.Items.Add(eachItem);
            }
        }

        // Intercept "Double Click" key that allows selected item to be moved from one listview to another
        private void listViewInclude_DoubleClick(object sender, EventArgs e)
        {
            buttonExclude_Click(sender, e);
        }

        private void listViewExclude_DoubleClick(object sender, EventArgs e)
        {
            buttonInclude_Click(sender, e);
        }

        // Intercept "Enter" key that allows selected items to be moved from one listview to another
        private void listViewExclude_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                buttonInclude_Click(sender, null);
            }
        }

        private void listViewInclude_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                buttonExclude_Click(sender, null);
            }
        }

        // Screen #3
        private List<UpdatedFiles> datagridItems = new List<UpdatedFiles>();

        private BindingSource bs;

        private void DataGridUpdate()
        {
            bs = new BindingSource(datagridItems, string.Empty);
            dataGridView1.DataSource = bs;
            // Hide the original directory and filename, no need to see that
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
        }

        private void buttonMoveRowUp_Click(object sender, EventArgs e)
        {
            int position = bs.Position;
            if (position == 0) return;  // already at top

            bs.RaiseListChangedEvents = false;

            UpdatedFiles current = (UpdatedFiles)bs.Current;
            bs.Remove(current);

            position--;

            bs.Insert(position, current);
            bs.Position = position;

            bs.RaiseListChangedEvents = true;
            bs.ResetBindings(false);
        }

        private void buttonMoveRowDown_Click(object sender, EventArgs e)
        {
            int position = bs.Position;
            if (position == bs.Count - 1) return;  // already at bottom

            bs.RaiseListChangedEvents = false;

            UpdatedFiles current = (UpdatedFiles)bs.Current;
            bs.Remove(current);

            position++;

            bs.Insert(position, current);
            bs.Position = position;

            bs.RaiseListChangedEvents = true;
            bs.ResetBindings(false);
        }

        public class UpdatedFiles
        {
            public String Name { get; set; }

            public String Description { get; set; }

            public String OriginalDirectory { get; set; }

            public String OriginalFileName { get; set; }
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            CreatePCBFabDirectory();
            CopyIncludedPCBFabFiles();
            CreateReadMePCBFabFile();
            ZipPCBFabFIles();
        }

        private void ZipPCBFabFIles()
        {
            String[] sevenZipLocation = { @"C:\Program Files (x86)\7-Zip\7z.exe", @"C:\Program Files\7-Zip\7z.exe" };

            foreach (String s in sevenZipLocation)
            {
                try
                {
                    System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(s);
                    psi.WorkingDirectory = txtOutputDirectory.Text + "\\PCBFab";
                    psi.Arguments = "a PCBFab.zip *.*";
                    System.Diagnostics.Process p = System.Diagnostics.Process.Start(psi);
                    // Wait for the file zip to complete before continuing
                    p.WaitForExit();
                    break;
                }
                catch
                {
                }
            }

            String o = txtOutputDirectory.Text + "\\PCBFab\\PCBFab.zip";
            String n = txtOutputDirectory.Text + "\\" + txtPCBPartNumber.Text.ToUpper() + "-" + txtRevision.Text.ToUpper() + " PCB FAB.zip";
            System.IO.File.Copy(o, n, true);

            o = txtOutputDirectory.Text + "\\PCBFab\\ReadMe.txt";
            n = txtOutputDirectory.Text + "\\ReadMe.txt";
            System.IO.File.Copy(o, n, true);

            System.Diagnostics.Process np = System.Diagnostics.Process.Start("notepad.exe", txtOutputDirectory.Text + "\\ReadMe.txt");

            String path = txtOutputDirectory.Text + "\\PCBFab";
            // Delete the directory.
            System.IO.Directory.Delete(path, true);
        }

        private void CreatePCBFabDirectory()
        {
            String path = txtOutputDirectory.Text + "\\PCBFab";
            // Determine whether the directory exists.
            if (System.IO.Directory.Exists(path))
            {
                // Delete the directory.
                System.IO.Directory.Delete(path, true);
            }

            System.IO.Directory.CreateDirectory(path);
        }

        private void CopyIncludedPCBFabFiles()
        {
            List<String> origFiles = new List<string>();
            List<String> newFiles = new List<string>();
            UInt16 i = 0;

            foreach (ListViewItem l in listViewInclude.Items)
            {
                // Dir                                       //Filename
                String o = dataGridView1.Rows[i].Cells[2].Value + "\\" + dataGridView1.Rows[i].Cells[3].Value;
                String n = txtOutputDirectory.Text + "\\PCBFab\\" + dataGridView1.Rows[i].Cells[0].Value;

                if (n.Contains(".TXT") == true)
                {
                    if (n.StartsWith("NC Drill.") || n.StartsWith("NC Drill-RoundHoles."))
                    {
                        n = n.Replace(".TXT", ".NCD");
                    }
                    else if (n.StartsWith("NC Drill-SlottedHoles."))
                    {
                        n = n.Replace(".TXT", ".NCS");
                    }
                }

                System.Diagnostics.Debug.Print(o);
                System.Diagnostics.Debug.Print(n);
                System.IO.File.Copy(o, n, true);

                i++;
            }
        }

        private void CreateReadMePCBFabFile()
        {
            using (StreamWriter file = File.CreateText(txtOutputDirectory.Text + "\\PCBFab\\Readme.txt"))
            {
                file.WriteLine("CONTACT: " + cBoxName.Text);
                file.WriteLine("COMPANY: SIGENIX, INC.");
                file.WriteLine("         100 SANDUNE DRIVE");
                file.WriteLine("         PITTSBURGH, PA 15239");
                file.WriteLine("");
                file.WriteLine("PHONE:   " + txtPhoneOffice.Text + " (WORK)");
                file.WriteLine("         " + txtPhoneCell.Text + " (MOBILE)");
                file.WriteLine("FAX:     (412) 380-7573");
                file.WriteLine("EMAIL:   " + txtEmail.Text);
                file.WriteLine("");
                file.WriteLine("TITLE:   " + txtPCBTitle.Text);
                file.WriteLine("P.N.:    " + txtPCBPartNumber.Text);
                file.WriteLine("REV:     " + txtRevision.Text);
                file.WriteLine("DATE:    " + DateTime.Today.ToString("MM/dd/yyyy"));
                file.WriteLine("----------------------------------------------------------");
                file.WriteLine("");
                file.WriteLine("REFER TO ARTWORK DRAWING FOR MATERIAL SPECIFICATIONS AND LAYER STACKUP");
                file.WriteLine("");
                file.WriteLine("PCB DIMENSIONS:  " + txtX.Text + "\"" + " x " + txtY.Text + "\"");
                file.WriteLine("PCB THICKNESS:   " + cBoxPCBThickness.Text);
                file.WriteLine("");
                file.WriteLine("----------------------------------------------------------");
                file.WriteLine("");
                file.WriteLine("FABRCATION DATA INCLUDED IN ZIP FILE:");
                file.WriteLine("");
                file.WriteLine("FILE                            DESCRIPTION");
                file.WriteLine("==================              ==============================");
                file.WriteLine("");

                Int16 i = 0;
                foreach (ListViewItem l in listViewInclude.Items)
                {
                    String n = dataGridView1.Rows[i].Cells[0].Value.ToString().PadRight(32) + dataGridView1.Rows[i].Cells[1].Value.ToString();
                    if (n.Contains(".TXT") == true)
                    {
                        n = n.Replace(".TXT", ".PNP");
                    }
                    file.WriteLine(n);
                    i++;
                }

                file.WriteLine("");
                file.WriteLine("");
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ValidateInfo() == false)
            {
                return;
            }
            else
            {
                saveFileDialog1.ShowDialog();
            }
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Get file name.
            string name = saveFileDialog1.FileName;

            PCBSettings pcb = new PCBSettings();

            SaveParams(pcb);

            XMLInterface.SerializeToXML(pcb, name);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    PCBSettings pcb = XMLInterface.DeserializeFromXML(file);
                    OpenParams(pcb);
                }
                catch (IOException)
                {
                    MessageBox.Show("Invalid PCB Documenter file");
                }
            }
        }

        private void SaveParams(PCBSettings aPCB)
        {
            aPCB.PCBThickness = cBoxPCBThickness.Text;
            aPCB.dimX = txtX.Text;
            aPCB.dimY = txtY.Text;
            aPCB.inputFolder = txtInputDirectory.Text;
            aPCB.layerCount = cBoxLayers.Text;
            aPCB.name = cBoxName.Text;
            aPCB.outputFolder = txtOutputDirectory.Text;
            aPCB.pcbPartNumber = txtPCBPartNumber.Text;
            aPCB.pcbRevision = txtRevision.Text;
            aPCB.pcbTitle = txtPCBTitle.Text;
            aPCB.phoneCell = txtPhoneCell.Text;
            aPCB.phoneOffice = txtPhoneOffice.Text;
        }

        private void OpenParams(PCBSettings aPCB)
        {
            cBoxPCBThickness.Text = aPCB.PCBThickness;
            txtX.Text = aPCB.dimX;
            txtY.Text = aPCB.dimY;
            txtInputDirectory.Text = aPCB.inputFolder;
            cBoxLayers.Text = aPCB.layerCount;
            cBoxName.Text = aPCB.name;
            txtOutputDirectory.Text = aPCB.outputFolder;
            txtPCBPartNumber.Text = aPCB.pcbPartNumber;
            txtRevision.Text = aPCB.pcbRevision;
            txtPCBTitle.Text = aPCB.pcbTitle;
            txtPhoneCell.Text = aPCB.phoneCell;
            txtPhoneOffice.Text = aPCB.phoneOffice;
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }
    }
}