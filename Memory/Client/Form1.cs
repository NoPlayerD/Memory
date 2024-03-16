using Microsoft.ML;
using System.IO.Compression;

namespace Client
{
    public partial class Form1 : Form
    {
        string pPath;
        string mPath;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Browse Button
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Project Files|*.zip";
            fd.Multiselect=false;
            fd.ShowDialog();
            textBox1.Text = fd.FileName;
        }

        //Prompt textbox
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //Prompt textbox
        private void richTextBox1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;
        }

        //Reset button
        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "Enter your prompt here and press ENTER after it.. Possible predictions will appear on the side. If you click one of them, then it's data will be shown on the under side, if not; the prediction that has the most score's data will be shown..";
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            listBox1.Items.Clear();
            pPath = string.Empty;
        }

        //Project Load button
        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox1.Text))
            {
                pPath = textBox1.Text;
                mPath = pPath.Remove(pPath.LastIndexOf("\\"));
                MessageBox.Show(mPath);
            }
            //Temp();

        }

        //When Enter pressed
        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Predict();
            }
        }

        //Predict with the loaded model
        void Predict()
        {
            string predictm = string.Empty;
            #region Predicting
            try
            {
                MLContext context = new MLContext();

                var savedModel = context.Model.Load(@$"{pPath}/Model.zip", out DataViewSchema schema);

                var eng = context.Model.CreatePredictionEngine<Input, Output>(savedModel, schema);

                var tahminim = eng.Predict(new Input { startLine = richTextBox1.Text });

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
                textBox2.Text = File.ReadAllText($"{pPath}/data/{predictm}.txt");
            }
            catch { }

            #endregion
        }

        //Extract the Data.zip file
        void Temp()
        {
            try
            {
                ZipFile.ExtractToDirectory($"{pPath}/data.zip", $"{pPath}/data/");
            }
            catch (Exception ex)
            {
                try
                {
                    Directory.Delete($"{pPath}/data/");
                    ZipFile.ExtractToDirectory($"{pPath}/data.zip", $"{pPath}/data/");
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
            try { Directory.Delete($"{pPath}/data", true); }
            catch { }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}