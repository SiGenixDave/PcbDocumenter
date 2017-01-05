using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PCB_Documenter
{
    public partial class Form1 : Form
    {
        private enum ActiveScreen
        {
            HOME,
            PCB_FILE_SELECTION,
            PCB_DOC_GEN,
            ASSEMBLY_FILE_SELECTION,
            ASSEMBLY_DOC_GEN,
        }

        // Screens are actually visible group boxes
        private ActiveScreen m_ActiveScreen = ActiveScreen.HOME;

        private ActiveScreen[] m_ValidScreens;
        private UInt16 m_ActiveScreenIndex;
        private String m_OutputDirectory;
        private Boolean m_PcbDocGen = false;
        private Boolean m_AssemblyDocGen = false;

        public Form1()
        {
            InitializeComponent();

            cBoxPCBThickness.SelectedIndex = 1;
            cBoxLayers.SelectedIndex = 1;
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox3.Visible = false;

            ManageCheckGroupBox(cBoxPCB, groupBox4);
            ManageCheckGroupBox(cBoxAssembly, groupBox5);

            PopulateNameDropBox();

            DataGridUpdate();
        }

        private void PopulateNameDropBox()
        {
            foreach (ContactInfo c in m_ContactInfo)
            {
                dropBoxName.Items.Add(c.name);
            }
            dropBoxName.SelectedIndex = 0;
        }

        private void buttonSelectInputFolder_Click(object sender, EventArgs e)
        {
            // Look in this folder and all sub-folders for files
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtInputDirectory.Text = folderBrowserDialog1.SelectedPath;
                m_OutputDirectory = txtInputDirectory.Text + @"\Deliverables";
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (CheckDocGeneration())
            {
                SetNextScreen();
            }
        }

        private Boolean CheckDocGeneration()
        {
            DialogResult diagResult;
            if ((!m_PcbDocGen) && (m_ActiveScreen == ActiveScreen.PCB_DOC_GEN))
            {
                diagResult = MessageBox.Show("You are attempting to leave the PCB Document Generator Screen without having generated the PCB package. Do you still wish to leave this screen?",
                    "Doc Gen Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (diagResult == System.Windows.Forms.DialogResult.No)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            if ((!m_AssemblyDocGen) && (m_ActiveScreen == ActiveScreen.ASSEMBLY_DOC_GEN))
            {
                diagResult = MessageBox.Show("You are attempting to leave the Assembly Document Generator Screen without having generated the Assembly package. Do you still wish to leave this screen?",
                    "Doc Gen Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (diagResult == System.Windows.Forms.DialogResult.No)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            return true;
        }

        private void SetNextScreen()
        {
            // Handle the home screen
            if (m_ActiveScreen == ActiveScreen.HOME)
            {
                // Verify all information has been added to the text and combo boxes
                if (ValidateInfo() == false)
                {
                    return;
                }

                m_ActiveScreenIndex = 0;
                if (cBoxPCB.Checked)
                {
                    m_ValidScreens = new ActiveScreen[]
                                    { ActiveScreen.HOME,
                                      ActiveScreen.PCB_FILE_SELECTION,
                                      ActiveScreen.PCB_DOC_GEN };
                }

                if (cBoxAssembly.Checked)
                {
                    if (cBoxPCB.Checked)
                    {
                        m_ValidScreens = new ActiveScreen[]
                                    { ActiveScreen.HOME,
                                      ActiveScreen.PCB_FILE_SELECTION,
                                      ActiveScreen.PCB_DOC_GEN,
                                      ActiveScreen.ASSEMBLY_FILE_SELECTION,
                                      ActiveScreen.ASSEMBLY_DOC_GEN };
                    }
                    else
                    {
                        m_ValidScreens = new ActiveScreen[]
                                    { ActiveScreen.HOME,
                                      ActiveScreen.ASSEMBLY_FILE_SELECTION,
                                      ActiveScreen.ASSEMBLY_DOC_GEN };
                    }
                }
            }

            // Enable the "Back" button since we may be moving forward
            buttonBack.Enabled = true;
            m_ActiveScreenIndex++;
            if (m_ActiveScreenIndex >= m_ValidScreens.Length - 1)
            {
                buttonNext.Enabled = false;
            }

            m_ActiveScreen = m_ValidScreens[m_ActiveScreenIndex];

            if ((m_ActiveScreen == ActiveScreen.PCB_DOC_GEN) ||
                (m_ActiveScreen == ActiveScreen.ASSEMBLY_DOC_GEN))
            {
                // Update the list with the included files
                UpdateDataGridItems();
                DataGridUpdate();
            }

            SetActiveScreen();
        }

        private Boolean ValidateInfo()
        {
            if (!cBoxPCB.Checked && !cBoxAssembly.Checked)
            {
                MessageBox.Show("At least 1 package (PCB/Assembly) must be selected");
                return false;
            }

            if (cBoxPCB.Checked)
            {
                if ((txtPCBTitle.Text == "") || (txtPCBRevision.Text == "") || (txtPCBPartNumber.Text == ""))
                {
                    MessageBox.Show("Please fill all info for PCB");
                    return false;
                }
            }

            if (cBoxAssembly.Checked)
            {
                if ((txtAssemblyTitle.Text == "") || (txtAssemblyRevision.Text == "") || (txtAssemblyPartNumber.Text == ""))
                {
                    MessageBox.Show("Please fill all info for Assembly");
                    return false;
                }
            }

            if ((dropBoxName.Text == "") || (txtPhoneOffice.Text == "") || (txtPhoneCell.Text == "") ||
                 (txtEmail.Text == "") || (txtX.Text == "") || (txtY.Text == "") ||
                 (cBoxPCBThickness.Text == "") || (cBoxLayers.Text == "") || (cBoxPCBThickness.Text == "") ||
                 (txtInputDirectory.Text == ""))
            {
                MessageBox.Show("Please fill all info");
                return false;
            }

            // Verify directory is valid (User might hand edit the text box instead of navigate to the directory)
            if (!System.IO.Directory.Exists(txtInputDirectory.Text))
            {
                MessageBox.Show("Design Input Directory does not exist. Please select a valid input directory");
                return false;
            }

            return true;
        }

        private void UpdateDataGridItems()
        {
            m_DatagridItems.Clear();

            foreach (ListViewItem l in listViewInclude.Items)
            {
                UpdatedFiles uf = new UpdatedFiles();

                Char[] splitIt = { '.' };
                String[] prefixExtension = l.SubItems[0].Text.Split(splitIt);

                HandleSpecialPcbFilenames(prefixExtension);

                if (m_ActiveScreen == ActiveScreen.PCB_DOC_GEN)
                {
                    uf.Name = txtPCBPartNumber.Text + "-" + txtPCBRevision.Text + "." + prefixExtension[1];
                }
                else
                {
                    String appendPrefix = "";
                    String prefix = prefixExtension[0].ToUpper();
                    String ext = prefixExtension[1].ToUpper();
                    if ((prefix == "BILL OF MATERIALS") && (ext == "XLS"))
                    {
                        appendPrefix = " BOM";
                    }
                    else if ((prefix == "SCHEMATIC PRINTS") && (ext == "PDF"))
                    {
                        appendPrefix = " SCH";
                    }
                    if (ext == "ZIP")
                    {
                        // Intentionally don't rename
                        uf.Name = prefix + "." + ext;
                    }
                    else
                    {
                        uf.Name = txtAssemblyPartNumber.Text + "-" + txtAssemblyRevision.Text + appendPrefix + "." + prefixExtension[1];
                    }
                }
                uf.Name = uf.Name.ToUpper();
                uf.Description = l.SubItems[2].Text;

                uf.OriginalDirectory = l.SubItems[1].Text;
                uf.OriginalFileName = l.SubItems[0].Text;

                m_DatagridItems.Add(uf);
            }
        }

        private void HandleSpecialPcbFilenames(String[] fileName)
        {
            String prefix = fileName[0].ToUpper();
            String ext = fileName[1].ToUpper();

            String[,] pcbSpecialNames = new String[,]
            {
                { "NC DRILL" , "TXT", "NCD" },
                { "NC DRILL-ROUNDHOLES" , "TXT", "NCD"},
                { "NC DRILL-SLOTHOLES" , "TXT", "NCS"},
                { "PICK AND PLACE" , "TXT", "PNP"},
            };

            for (UInt16 i = 0; i < pcbSpecialNames.GetLength(0); i++)
            {
                // If the file name matches the a "special" file, the extension needs
                // to be changed
                if ((prefix == pcbSpecialNames[i, 0]) && (ext == pcbSpecialNames[i, 1]))
                {
                    fileName[1] = pcbSpecialNames[i, 2];
                    return;
                }
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (!CheckDocGeneration())
            {
                return;
            }
            buttonNext.Enabled = true;
            m_ActiveScreenIndex--;
            if (m_ActiveScreenIndex == 0)
            {
                buttonBack.Enabled = false;
            }
            m_ActiveScreen = m_ValidScreens[m_ActiveScreenIndex];
            SetActiveScreen();
        }

        private void SetActiveScreen()
        {
            switch (m_ActiveScreen)
            {
                case ActiveScreen.HOME:
                    groupBox1.Visible = true;
                    groupBox2.Visible = false;
                    groupBox3.Visible = false;
                    break;

                case ActiveScreen.PCB_FILE_SELECTION:
                case ActiveScreen.ASSEMBLY_FILE_SELECTION:
                    groupBox1.Visible = false;
                    groupBox2.Visible = true;
                    groupBox3.Visible = false;
                    if (m_ActiveScreen == ActiveScreen.PCB_FILE_SELECTION)
                    {
                        groupBox2.Text = "PCB File Selection";
                        PopulateListBoxes(m_PcbFileDescription);
                    }
                    else
                    {
                        groupBox2.Text = "Assembly File Selection";
                        PopulateListBoxes(m_AssemblyFileDescription);
                    }
                    break;

                case ActiveScreen.PCB_DOC_GEN:
                case ActiveScreen.ASSEMBLY_DOC_GEN:
                    groupBox1.Visible = false;
                    groupBox2.Visible = false;
                    groupBox3.Visible = true;
                    if (m_ActiveScreen == ActiveScreen.PCB_DOC_GEN)
                    {
                        groupBox3.Text = "PCB Document Generation";
                    }
                    else
                    {
                        groupBox3.Text = "Assembly Document Generation";
                    }
                    break;

                default:
                    break;
            }
        }

        private void dropBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 index = dropBoxName.SelectedIndex;

            txtEmail.Text = m_ContactInfo[index].email;
            txtPhoneOffice.Text = m_ContactInfo[index].phoneOffice;
            txtPhoneCell.Text = m_ContactInfo[index].phoneCell;
        }

        private struct ContactInfo
        {
            public String name;
            public String phoneOffice;
            public String phoneCell;
            public String email;
        }

        private ContactInfo[] m_ContactInfo = new ContactInfo[]
        {
            new ContactInfo
            {
                name = "Tom Schneider",
                phoneOffice = "(412) 380-7572",
                phoneCell = "(724) 462-5219",
                email = "tschneider@sigenix.com",
            },

            new ContactInfo
            {
                name = "Nik Shaffer",
                phoneOffice = "(412) 380-7572",
                phoneCell = "(412) 862-6157",
                email = "nshaffer@sigenix.com",
            },

            new ContactInfo
            {
                name = "Jerry Joseph",
                phoneOffice = "(412) 380-7572",
                phoneCell = "(724) 771-6749",
                email = "jjoseph@sigenix.com",
            },
        };

        private struct FileDescription
        {
            public String type;
            public String description;
        }

        private FileDescription[] m_PcbFileDescription = new FileDescription[]
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
            new FileDescription { type = "*.g9",                    description = "Inner Signal Layer 9"},
            new FileDescription { type = "*.g10",                    description = "Inner Signal Layer 10"},
            new FileDescription { type = "*.g11",                    description = "Inner Signal Layer 11"},
            new FileDescription { type = "*.g12",                    description = "Inner Signal Layer 12"},
            new FileDescription { type = "*.g13",                    description = "Inner Signal Layer 13"},
            new FileDescription { type = "*.g14",                    description = "Inner Signal Layer 14"},
            new FileDescription { type = "*.g15",                    description = "Inner Signal Layer 15"},
            new FileDescription { type = "*.g16",                    description = "Inner Signal Layer 16"},
            new FileDescription { type = "*.gp1",                   description = "Inner Plane Layer 1"},
            new FileDescription { type = "*.gp2",                   description = "Inner Plane Layer 2"},
            new FileDescription { type = "*.gp3",                   description = "Inner Plane Layer 3"},
            new FileDescription { type = "*.gp4",                   description = "Inner Plane Layer 4"},
            new FileDescription { type = "*.gp5",                   description = "Inner Plane Layer 5"},
            new FileDescription { type = "*.gp6",                   description = "Inner Plane Layer 6"},
            new FileDescription { type = "*.gp7",                   description = "Inner Plane Layer 7"},
            new FileDescription { type = "*.gp8",                   description = "Inner Plane Layer 8"},
            new FileDescription { type = "*.gp9",                   description = "Inner Plane Layer 9"},
            new FileDescription { type = "*.gp10",                   description = "Inner Plane Layer 10"},
            new FileDescription { type = "*.gp11",                   description = "Inner Plane Layer 11"},
            new FileDescription { type = "*.gp12",                   description = "Inner Plane Layer 12"},
            new FileDescription { type = "*.gp13",                   description = "Inner Plane Layer 13"},
            new FileDescription { type = "*.gp14",                   description = "Inner Plane Layer 14"},
            new FileDescription { type = "*.gp15",                   description = "Inner Plane Layer 15"},
            new FileDescription { type = "*.gp16",                   description = "Inner Plane Layer 16"},
            new FileDescription { type = "*.gd1",                   description = "Drill Drawing (Through Holes)"},
            new FileDescription { type = "*.gd2",                   description = "Drill Drawing (Layer Pair 2)"},
            new FileDescription { type = "*.gd3",                   description = "Drill Drawing (Layer Pair 3)"},
            new FileDescription { type = "*.gd4",                   description = "Drill Drawing (Layer Pair 4)"},
            new FileDescription { type = "*.gd5",                   description = "Drill Drawing (Layer Pair 5)"},
            new FileDescription { type = "*.gd6",                   description = "Drill Drawing (Layer Pair 6)"},
            new FileDescription { type = "*.gd7",                   description = "Drill Drawing (Layer Pair 7)"},
            new FileDescription { type = "*.gd8",                   description = "Drill Drawing (Layer Pair 8)"},
            new FileDescription { type = "*.gd9",                   description = "Drill Drawing (Layer Pair 9)"},
            new FileDescription { type = "*.gd10",                   description = "Drill Drawing (Layer Pair 10)"},
            new FileDescription { type = "*.gd11",                   description = "Drill Drawing (Layer Pair 11)"},
            new FileDescription { type = "*.gd12",                   description = "Drill Drawing (Layer Pair 12)"},
            new FileDescription { type = "*.gd13",                   description = "Drill Drawing (Layer Pair 13)"},
            new FileDescription { type = "*.gd14",                   description = "Drill Drawing (Layer Pair 14)"},
            new FileDescription { type = "*.gd15",                   description = "Drill Drawing (Layer Pair 15)"},
            new FileDescription { type = "*.gd16",                   description = "Drill Drawing (Layer Pair 16)"},
            new FileDescription { type = "*.tx1",                   description = "RS-274X Drill Data (Layer Pair 2)"},
            new FileDescription { type = "*.tx2",                   description = "RS-274X Drill Data (Layer Pair 3)"},
            new FileDescription { type = "*.tx3",                   description = "RS-274X Drill Data (Layer Pair 4)"},
            new FileDescription { type = "*.tx4",                   description = "RS-274X Drill Data (Layer Pair 5)"},
            new FileDescription { type = "*.tx5",                   description = "RS-274X Drill Data (Layer Pair 6)"},
            new FileDescription { type = "*.tx6",                   description = "RS-274X Drill Data (Layer Pair 7)"},
            new FileDescription { type = "*.tx7",                   description = "RS-274X Drill Data (Layer Pair 8)"},
            new FileDescription { type = "*.tx8",                   description = "RS-274X Drill Data (Layer Pair 9)"},
            new FileDescription { type = "*.tx9",                   description = "RS-274X Drill Data (Layer Pair 10)"},
            new FileDescription { type = "*.tx10",                   description = "RS-274X Drill Data (Layer Pair 11)"},
            new FileDescription { type = "*.tx11",                   description = "RS-274X Drill Data (Layer Pair 12)"},
            new FileDescription { type = "*.tx12",                   description = "RS-274X Drill Data (Layer Pair 13)"},
            new FileDescription { type = "*.tx13",                   description = "RS-274X Drill Data (Layer Pair 14)"},
            new FileDescription { type = "*.tx14",                   description = "RS-274X Drill Data (Layer Pair 15)"},
            new FileDescription { type = "*.tx15",                   description = "RS-274X Drill Data (Layer Pair 16)"},
            new FileDescription { type = "*.tx16",                   description = "RS-274X Drill Data (Layer Pair 17)"},
            new FileDescription { type = "*.gto",                   description = "Top Silkscreen"},
            new FileDescription { type = "*.gbo",                   description = "Bottom Silkscreen"},
            new FileDescription { type = "*.gts",                   description = "Top Soldermask"},
            new FileDescription { type = "*.gbs",                   description = "Bottom Soldermask"},
            new FileDescription { type = "*.gtp",                   description = "Top Paste"},
            new FileDescription { type = "*.gbp",                   description = "Bottom Paste"},
            new FileDescription { type = "*.gko",                   description = "Board outline"},
            new FileDescription { type = "NC Drill.TXT",            description = "RS-274X Drill Data (Through Holes)"},
            new FileDescription { type = "NC Drill-RoundHoles.TXT", description = "RS-274X Drill Data (Through Holes)"},
            new FileDescription { type = "NC Drill-SlotHoles.TXT",  description = "RS-274X Slot Data"},
            new FileDescription { type = "*.ipc",                   description = "IPC-356 netlist"},
            new FileDescription { type = "Pick and Place*.txt",     description = "Pick and Place File"},
            new FileDescription { type = "*Artwork*.pdf",           description = "Artwork Drawing"},
            new FileDescription { type = "*.zip",                   description = "ODB++ Archive"},
        };

        private FileDescription[] m_AssemblyFileDescription = new FileDescription[]
        {
            new FileDescription { type = "*PCB FAB.zip",            description = "PCB Fabrication Data"},
            new FileDescription { type = "Schematic Prints.PDF",    description = "Schematic"},
            new FileDescription { type = "Assembly Drawings.PDF",   description = "Assembly Drawing"},
            new FileDescription { type = "Bill of Materials.XLS",   description = "Bill of Materials"},
        };

        private void ManageCheckGroupBox(CheckBox chk, GroupBox grp)
        {
            // Make sure the CheckBox isn't in the GroupBox.
            // This will only happen the first time.
            if (chk.Parent == grp)
            {
                // "Re-Parent" the CheckBox so it's not in the GroupBox.
                grp.Parent.Controls.Add(chk);

                // Adjust the CheckBox's location.
                chk.Location = new Point(
                    chk.Left + grp.Left,
                    chk.Top + grp.Top);

                // Move the CheckBox to the top of the stacking order.
                chk.BringToFront();
            }

            // Enable or disable the GroupBox.
            grp.Enabled = chk.Checked;
        }

        // Screen 2
        private void PopulateListBoxes(FileDescription[] fileDescription)
        {
            String directory = txtInputDirectory.Text;

            List<String> includedListFile = new List<String>();

            listViewInclude.Items.Clear();

            // Populate the included m_PcbFileDescription listview
            foreach (FileDescription f in fileDescription)
            {
                List<String> fileList = new List<string>();
                String[] files;
                String[] dirs;

                if (f.type == "*PCB FAB.zip")
                {
                    files = System.IO.Directory.GetFiles(directory, f.type, SearchOption.AllDirectories).Select(fileName => Path.GetFileName(fileName)).ToArray();
                    dirs = System.IO.Directory.GetFiles(directory, f.type, SearchOption.AllDirectories).Select(fileName => Path.GetDirectoryName(fileName)).ToArray();
                }
                else
                {
                    files = System.IO.Directory.GetFiles(directory, f.type, SearchOption.AllDirectories).Where(fileName => !fileName.Contains("Deliverables")).Select(fileName => Path.GetFileName(fileName)).ToArray();
                    dirs = System.IO.Directory.GetFiles(directory, f.type, SearchOption.AllDirectories).Where(fileName => !fileName.Contains("Deliverables")).Select(fileName => Path.GetDirectoryName(fileName)).ToArray();
                }

                String filterUpperCase = f.type.ToUpper();
                Int32 dotIndex = filterUpperCase.LastIndexOf(".");
                String extension = filterUpperCase.Substring(dotIndex + 1);
                for (UInt16 i = 0; i < files.Length; i++)
                {
                    Char[] splitIt = { '.' };
                    String[] prefixExtension = files[i].ToUpper().Split(splitIt);
                    if (prefixExtension[1] == extension)
                    {
                        fileList.Add(files[i]);
                    }
                }

                for (UInt16 i = 0; i < fileList.Count; i++)
                {
                    ListViewItem lvi = new ListViewItem(fileList[i]);
                    lvi.SubItems.Add(dirs[i]);
                    lvi.SubItems.Add(f.description);
                    listViewInclude.Items.Add(lvi);

                    includedListFile.Add(files[i]);
                }
            }

            String[] xfiles = System.IO.Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories).Select(fileName => Path.GetFileName(fileName)).ToArray();
            String[] xdirs = System.IO.Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories).Select(fileName => Path.GetDirectoryName(fileName)).ToArray();

            for (UInt16 i = 0; i < xfiles.Length; i++)
            {
                if (!includedListFile.Contains(xfiles[i]))
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
        private List<UpdatedFiles> m_DatagridItems = new List<UpdatedFiles>();

        private BindingSource m_BindingSource;

        private void DataGridUpdate()
        {
            m_BindingSource = new BindingSource(m_DatagridItems, string.Empty);
            dataGridView1.DataSource = m_BindingSource;
            // Hide the original directory and filename, no need to see that
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
        }

        private void buttonMoveRowUp_Click(object sender, EventArgs e)
        {
            int position = m_BindingSource.Position;
            if (position == 0) return;  // already at top

            m_BindingSource.RaiseListChangedEvents = false;

            UpdatedFiles current = (UpdatedFiles)m_BindingSource.Current;
            m_BindingSource.Remove(current);

            position--;

            m_BindingSource.Insert(position, current);
            m_BindingSource.Position = position;

            m_BindingSource.RaiseListChangedEvents = true;
            m_BindingSource.ResetBindings(false);
        }

        private void buttonMoveRowDown_Click(object sender, EventArgs e)
        {
            int position = m_BindingSource.Position;
            if (position == m_BindingSource.Count - 1) return;  // already at bottom

            m_BindingSource.RaiseListChangedEvents = false;

            UpdatedFiles current = (UpdatedFiles)m_BindingSource.Current;
            m_BindingSource.Remove(current);

            position++;

            m_BindingSource.Insert(position, current);
            m_BindingSource.Position = position;

            m_BindingSource.RaiseListChangedEvents = true;
            m_BindingSource.ResetBindings(false);
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
            if (m_ActiveScreen == ActiveScreen.PCB_DOC_GEN)
            {
                m_PcbDocGen = true;
            }
            else if (m_ActiveScreen == ActiveScreen.ASSEMBLY_DOC_GEN)
            {
                m_AssemblyDocGen = true;
            }
            CreateDocGenDirectory();
            CopyRequiredFiles();
            CreateReadMeFile();
            ZipFiles();
        }

        private void ZipFiles()
        {
            String[] sevenZipLocation = { @"C:\Program Files (x86)\7-Zip\7z.exe", @"C:\Program Files\7-Zip\7z.exe" };

            foreach (String s in sevenZipLocation)
            {
                try
                {
                    System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(s);
                    psi.WorkingDirectory = m_OutputDirectory + "\\DocGen";
                    psi.Arguments = "a Files.zip *.*";
                    System.Diagnostics.Process p = System.Diagnostics.Process.Start(psi);
                    // Wait for the m_PcbFileDescription zip to complete before continuing
                    p.WaitForExit();
                    break;
                }
                catch
                {
                }
            }

            String o = m_OutputDirectory + "\\DocGen\\Files.zip";
            String n;
            if (m_ActiveScreen == ActiveScreen.PCB_DOC_GEN)
            {
                n = m_OutputDirectory + "\\" + txtPCBPartNumber.Text.ToUpper() + "-" + txtPCBRevision.Text.ToUpper() + " PCB FAB.zip";
            }
            else
            {
                n = m_OutputDirectory + "\\" + txtAssemblyPartNumber.Text.ToUpper() + "-" + txtAssemblyRevision.Text.ToUpper() + " ASSY PKG.zip";
            }
            System.IO.File.Copy(o, n, true);

            System.Diagnostics.Process np = System.Diagnostics.Process.Start("notepad.exe", m_OutputDirectory + "\\DocGen\\ReadMe.txt");
            System.Threading.Thread.Sleep(500);

            String path = m_OutputDirectory + "\\DocGen";
            // Delete the directory.
            System.IO.Directory.Delete(path, true);
        }

        private void CreateDocGenDirectory()
        {
            String path = m_OutputDirectory + "\\DocGen";
            // Determine whether the directory exists.
            if (System.IO.Directory.Exists(path))
            {
                // Delete the directory.
                System.IO.Directory.Delete(path, true);
            }

            System.IO.Directory.CreateDirectory(path);
        }

        private void CopyRequiredFiles()
        {
            List<String> origFiles = new List<string>();
            List<String> newFiles = new List<string>();
            UInt16 i = 0;

            foreach (ListViewItem l in listViewInclude.Items)
            {
                // Dir                                       //Filename
                String o = dataGridView1.Rows[i].Cells[2].Value + "\\" + dataGridView1.Rows[i].Cells[3].Value;
                String n = m_OutputDirectory + "\\DocGen\\" + dataGridView1.Rows[i].Cells[0].Value;

                System.IO.File.Copy(o, n, true);

                i++;
            }
        }

        private void CreateReadMeFile()
        {
            using (StreamWriter file = File.CreateText(m_OutputDirectory + "\\DocGen\\Readme.txt"))
            {
                file.WriteLine("CONTACT: " + dropBoxName.Text);
                file.WriteLine("COMPANY: SIGENIX, INC.");
                file.WriteLine("         100 SANDUNE DRIVE");
                file.WriteLine("         PITTSBURGH, PA 15239");
                file.WriteLine("");
                file.WriteLine("PHONE:   " + txtPhoneOffice.Text + " (WORK)");
                file.WriteLine("         " + txtPhoneCell.Text + " (MOBILE)");
                file.WriteLine("FAX:     (412) 380-7573");
                file.WriteLine("EMAIL:   " + txtEmail.Text);
                file.WriteLine("");
                if (m_ActiveScreen == ActiveScreen.PCB_DOC_GEN)
                {
                    file.WriteLine("TITLE:   " + txtPCBTitle.Text);
                    file.WriteLine("P.N.:    " + txtPCBPartNumber.Text);
                    file.WriteLine("REV:     " + txtPCBRevision.Text);
                }
                else
                {
                    file.WriteLine("TITLE:   " + txtAssemblyTitle.Text);
                    file.WriteLine("P.N.:    " + txtAssemblyPartNumber.Text);
                    file.WriteLine("REV:     " + txtAssemblyRevision.Text);
                }

                DateTime dateTime = DateTime.Now;

                file.WriteLine("DATE:    " + dateTime.ToString("MMM-dd-yyyy"));
                file.WriteLine("TIME:    " + dateTime.ToString("HH:mm:ss"));
                file.WriteLine("----------------------------------------------------------");
                file.WriteLine("");
                file.WriteLine("REFER TO ARTWORK DRAWING FOR MATERIAL SPECIFICATIONS AND LAYER STACKUP");
                file.WriteLine("");
                file.WriteLine("PCB DIMENSIONS:  " + txtX.Text + "\"" + " x " + txtY.Text + "\"");
                file.WriteLine("PCB THICKNESS:   " + cBoxPCBThickness.Text);
                file.WriteLine("");
                file.WriteLine("----------------------------------------------------------");
                file.WriteLine("");
                if (m_ActiveScreen == ActiveScreen.PCB_DOC_GEN)
                {
                    file.WriteLine("FABRCATION DATA INCLUDED IN ZIP FILE:");
                }
                else
                {
                    file.WriteLine("ASSEMBLY DATA INCLUDED IN ZIP FILE:");
                }
                file.WriteLine("");
                file.WriteLine("FILE                            DESCRIPTION");
                file.WriteLine("==================              ==============================");
                file.WriteLine("");

                Int16 i = 0;
                foreach (ListViewItem l in listViewInclude.Items)
                {
                    String n = dataGridView1.Rows[i].Cells[0].Value.ToString().PadRight(32) + dataGridView1.Rows[i].Cells[1].Value.ToString();
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
            // Get m_PcbFileDescription name.
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
                    MessageBox.Show("Invalid PCB Documenter m_PcbFileDescription");
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
            aPCB.name = dropBoxName.Text;
            aPCB.outputFolder = m_OutputDirectory;
            aPCB.pcbEnabled = cBoxPCB.Checked.ToString(); ;
            aPCB.pcbPartNumber = txtPCBPartNumber.Text;
            aPCB.pcbRevision = txtPCBRevision.Text;
            aPCB.pcbTitle = txtPCBTitle.Text;
            aPCB.assemblyEnabled = cBoxAssembly.Checked.ToString();
            aPCB.assemblyPartNumber = txtAssemblyPartNumber.Text;
            aPCB.assemblyRevision = txtAssemblyRevision.Text;
            aPCB.assemblyTitle = txtAssemblyTitle.Text;
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
            dropBoxName.Text = aPCB.name;
            m_OutputDirectory = aPCB.outputFolder;
            txtPCBPartNumber.Text = aPCB.pcbPartNumber;
            txtPCBRevision.Text = aPCB.pcbRevision;
            txtPCBTitle.Text = aPCB.pcbTitle;
            txtAssemblyPartNumber.Text = aPCB.assemblyPartNumber;
            txtAssemblyRevision.Text = aPCB.assemblyRevision;
            txtAssemblyTitle.Text = aPCB.assemblyTitle;
            txtPhoneCell.Text = aPCB.phoneCell;
            txtPhoneOffice.Text = aPCB.phoneOffice;

            if (aPCB.pcbEnabled == "True")
            {
                cBoxPCB.Checked = true;
            }
            else
            {
                cBoxPCB.Checked = false;
            }

            if (aPCB.assemblyEnabled == "True")
            {
                cBoxAssembly.Checked = true;
            }
            else
            {
                cBoxAssembly.Checked = false;
            }
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

        private void cBoxPCB_CheckedChanged(object sender, EventArgs e)
        {
            ManageCheckGroupBox(cBoxPCB, groupBox4);
        }

        private void cBoxAssembly_CheckedChanged(object sender, EventArgs e)
        {
            ManageCheckGroupBox(cBoxAssembly, groupBox5);
        }

        private void txtInputDirectory_TextChanged(object sender, EventArgs e)
        {
            m_OutputDirectory = txtInputDirectory.Text + @"\Deliverables";
        }
    }
}