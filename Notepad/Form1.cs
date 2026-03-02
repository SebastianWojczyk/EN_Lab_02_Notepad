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

namespace Notepad
{
    public partial class Form1 : Form
    {
        private string myFileName;

        private string MyFileName
        {
            get
            {
                return myFileName;
            }
            set
            {
                myFileName = value;
                if (myFileName == "")
                {
                    this.Text = "New file";
                }
                else
                {
                    this.Text = Path.GetFileName(myFileName);
                }
            }
        }

        public Form1()
        {
            //new line
            InitializeComponent();
            MyFileName = "";
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?",
                                "Confirm Quit",
                                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxEditor.Clear();
            //richTextBoxEditor.Text = "";
            MyFileName = "";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileContent = File.ReadAllText(filePath);
                richTextBoxEditor.Text = fileContent;

                MyFileName = filePath;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                File.WriteAllText(filePath, richTextBoxEditor.Text);

                MyFileName = filePath;
            }
        }

        private void fontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            colorDialog.Color = richTextBoxEditor.ForeColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBoxEditor.ForeColor = colorDialog.Color;
            }
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            colorDialog.Color = richTextBoxEditor.BackColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBoxEditor.BackColor = colorDialog.Color;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();

            fontDialog.Font = richTextBoxEditor.Font;

            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBoxEditor.Font = fontDialog.Font;
            }
        }
    }
}
