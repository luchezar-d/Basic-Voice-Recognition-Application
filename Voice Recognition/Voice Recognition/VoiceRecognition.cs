using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;

namespace Voice_Recognition
{
    public partial class VoiceRecognition : Form
    {
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();

        public VoiceRecognition()
        {
            InitializeComponent();
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
            btnDisable.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Choices commands = new Choices();
            commands.Add(new string[] {"say hello","print my name","say i am smart","close" });

            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.Append(commands);

            Grammar grammar = new Grammar(gBuilder);

            recEngine.LoadGrammarAsync(grammar);
            recEngine.SetInputToDefaultAudioDevice();

            recEngine.SpeechRecognized += RecEngine_SpeechRecognized;
        }

        private void RecEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                
                case "say hello":
                    MessageBox.Show("Hello Luchezar !");
                    break;
                case "print my name":
                    richTextBox1.Text += "Luchezar";
                    break;
                case "say i am smart":
                    richTextBox1.Text += "Luchezar you are smart";
                    break;
                case "close":
                    Close();
                    break;

            }
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            recEngine.RecognizeAsyncStop();
            btnEnable.Enabled = false;
        }
    }
}
