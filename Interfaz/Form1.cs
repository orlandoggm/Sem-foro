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
            Dictionary<string, Image> norte = new Dictionary<string, Image> { { "Verde", Properties.Resources.VerdeNorte}, { "Amarillo", Properties.Resources.AmarilloNorte }, { "Rojo", Properties.Resources.RojoNorte } };
            Dictionary<string, Image> sur = new Dictionary<string, Image> { { "Verde", Properties.Resources.VerdeSur }, { "Amarillo", Properties.Resources.AmarilloSur }, { "Rojo", Properties.Resources.RojoSur } };
            Dictionary<string, Image> este = new Dictionary<string, Image> { { "Verde", Properties.Resources.VerdeEste }, { "Amarillo", Properties.Resources.AmarilloEste }, { "Rojo", Properties.Resources.RojoEste } };
            Dictionary<string, Image> oeste = new Dictionary<string, Image> { { "Verde", Properties.Resources.VerdeOeste }, { "Amarillo", Properties.Resources.AmarilloOeste }, { "Rojo", Properties.Resources.RojoOeste } };

            Semaforos semaforos = new Semaforos(panelSemaforoNorte, panelSemaforoSur, panelSemaforoEste, panelSemaforoOeste, labelHora);
            semaforos.cambioSemaforos(panelSemaforoNorte, panelSemaforoSur, panelSemaforoEste, panelSemaforoOeste, labelHora, norte, sur, este, oeste);
        }
    }
}
