using Logica;

namespace Interfaz
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonIniciar_Click(object sender, EventArgs e)
        {
            buttonIniciar.Enabled = false;
            Semaforos semaforos = new Semaforos(panelSemaforoNorte, panelSemaforoSur, panelSemaforoEste, panelSemaforoOeste, labelHora);
        }
    }
}
