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

            Queue<Panel> pilaCarrosOeste = crearCarros(Properties.Resources.CarroOeste, -30, 460, 30, 18);
            Panel[] carrosVisiblesOeste = new Panel[5];
        }

        private Queue<Panel> crearCarros(Image imagen, int x, int y, int n, int m)
        {
            Queue<Panel> list = new Queue<Panel>();
            for (int i = 0; i<10; i++)
            {
                Panel panel = new Panel();
                panel.Visible = false;
                this.Controls.Add(panel);
                panel.BringToFront();
                panel.Size = new Size(n, m);
                panel.BackgroundImage = imagen;
                panel.BackgroundImageLayout = ImageLayout.Stretch;
                panel.BackColor = Color.Transparent;
                panel.Location = new Point(x,y);
                list.Enqueue(panel);
            }
            return list;
        }

        private void moverCarros(Queue<Panel> cola, Panel[] carros)
        {
            if ((Convert.ToInt16(labelHora.Text) >= 6 && Convert.ToInt16(labelHora.Text) <= 10) || (Convert.ToInt16(labelHora.Text) >= 17 && Convert.ToInt16(labelHora.Text) <= 21))
            {

            }
        }
    }
}
