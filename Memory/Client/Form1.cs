using Microsoft.ML;
using System.IO.Compression;

namespace Client
{
    public partial class Form1 : Form
    {
        string pPath;
        string mPath;
        string aPath;

        bool ctrl = false;

        #region Useless
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Prompt textbox
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //Prompt textbox
        private void richTextBox1_Click(object sender, EventArgs e)
        {
            if (ctrl == false) { richTextBox1.Text = string.Empty; ctrl = true; }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion

        //Browse Button
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Project Files|*.zip";
            fd.Multiselect = false;
            fd.ShowDialog();
            textBox1.Text = fd.FileName;
        }

        //Reset button
        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "Enter your prompt here and press ENTER after it.. 'Predicted Category' and the 'Possible Categories' will appear on the bottom side. After it, the Data will be shown on right side..";
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            pPath = string.Empty;
        }

        //Project Load button
        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox1.Text))
            {
                pPath = textBox1.Text;
                mPath = pPath.Remove(pPath.LastIndexOf("\\") + 1);
            }
            Temp();
            LB();
        }

        //Load categories to the listbox
        void LB()
        {
            var Lines = File.ReadAllLines($"{aPath}categories.txt");
            foreach (var Line in Lines)
            {
                listBox2.Items.Add(Line);
            }
        }

        //Open the Data file
        void OD(string name)
        {
            textBox2.Text = File.ReadAllText($"{aPath}/data/{name}.txt");
        }

        //When Enter pressed
        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Predict(richTextBox1.Text);
            }
        }

        //Predict with the loaded model
        void Predict(string prompt)
        {
            string predictm = string.Empty;

            #region Predicting
            try
            {
                MLContext context = new MLContext();

                var savedModel = context.Model.Load(@$"{aPath}/Model.zip", out DataViewSchema schema);

                var eng = context.Model.CreatePredictionEngine<Input, Output>(savedModel, schema);

                var tahminim = eng.Predict(new Input { startLine = prompt });

                listBox1.Items.Clear();
                listBox1.Items.Add(tahminim.PredictedLabel);
                predictm = tahminim.PredictedLabel;
            }
            catch (Exception ex)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add(pPath);
            }
            #endregion

            #region ReadData
            try
            {
                OD(predictm);
            }
            catch { }

            #endregion
        }

        //Extract the Data.zip file
        void Temp()
        {
            try
            {
                aPath = $"{mPath}/TMP.-.Project/";
                ZipFile.ExtractToDirectory(pPath, aPath);
            }
            catch (Exception ex)
            {
                try
                {
                    Directory.Delete(aPath);
                    ZipFile.ExtractToDirectory(pPath, aPath);
                }
                catch
                {
                    MessageBox.Show("error");
                }
            }

        }

        //At closing
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try { Directory.Delete(aPath, true); }
            catch { }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            OD(listBox2.SelectedItem.ToString());

            listBox1.Items.Clear();
            listBox1.Items.Add(listBox2.SelectedItem.ToString());
        }

        //Warning Button
        private void button4_Click(object sender, EventArgs e)
        {
            string msg = "When you 'Load' your project, a directory named 'TMP.-.Project' will be created in the location where your project.zip file located." +
                "So if you have any folder named like that, move your project file or the folder.. If application stops by an error, delete that file to use application properly.";

            MessageBox.Show(msg);
        }
    }
}