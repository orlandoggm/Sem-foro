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
            Dictionary<string, Image> norte = new Dictionary<string, Image> { { "Verde", Properties.Resources.VerdeNorte }, { "Amarillo", Properties.Resources.AmarilloNorte }, { "Rojo", Properties.Resources.RojoNorte } };
            Dictionary<string, Image> sur = new Dictionary<string, Image> { { "Verde", Properties.Resources.VerdeSur }, { "Amarillo", Properties.Resources.AmarilloSur }, { "Rojo", Properties.Resources.RojoSur } };
            Dictionary<string, Image> este = new Dictionary<string, Image> { { "Verde", Properties.Resources.VerdeEste }, { "Amarillo", Properties.Resources.AmarilloEste }, { "Rojo", Properties.Resources.RojoEste } };
            Dictionary<string, Image> oeste = new Dictionary<string, Image> { { "Verde", Properties.Resources.VerdeOeste }, { "Amarillo", Properties.Resources.AmarilloOeste }, { "Rojo", Properties.Resources.RojoOeste } };

            Semaforos semaforos = new Semaforos(panelSemaforoNorte, panelSemaforoSur, panelSemaforoEste, panelSemaforoOeste, labelHora);
            semaforos.cambioSemaforos(panelSemaforoNorte, panelSemaforoSur, panelSemaforoEste, panelSemaforoOeste, labelHora, norte, sur, este, oeste);

            Queue<Panel> colaCarrosEste = crearCarros(Properties.Resources.CarroEste, -30, 460, 30, 18);
            generarCarros(colaCarrosEste);
        }

        private Queue<Panel> crearCarros(Image imagen, int x, int y, int n, int m)
        {
            Queue<Panel> list = new Queue<Panel>();
            for (int i = 0; i < 10; i++)
            {
                Panel panel = new Panel();
                panel.Visible = false;
                this.Controls.Add(panel);
                panel.BringToFront();
                panel.Size = new Size(n, m);
                panel.BackgroundImage = imagen;
                panel.BackgroundImageLayout = ImageLayout.Stretch;
                panel.BackColor = Color.Transparent;
                panel.Location = new Point(x, y);
                list.Enqueue(panel);
            }
            return list;
        }

        private void generarCarros(Queue<Panel> cola)
        {
            Dictionary<string, Image> este = new Dictionary<string, Image> { { "Verde", Properties.Resources.VerdeEste }, { "Amarillo", Properties.Resources.AmarilloEste }, { "Rojo", Properties.Resources.RojoEste } };
            var timer = new System.Windows.Forms.Timer();
            var rand = new Random();
            int rng;
            int ptr = 0;
            Panel[] carrosActuales = new Panel[5];
            Panel carro;
            timer.Interval = 250;
            timer.Tick += (s, e) =>
            {
                if ((Convert.ToInt16(labelHora.Text) >= 6 && Convert.ToInt16(labelHora.Text) <= 10) || (Convert.ToInt16(labelHora.Text) >= 17 && Convert.ToInt16(labelHora.Text) <= 21))
                {
                    rng = rand.Next(1, 10);
                    if (rng == 1)
                    {
                        
                        if (ptr == 0)
                        {
                            carrosActuales[ptr] = cola.Dequeue();
                            carrosActuales[ptr].Visible = true;
                            ptr++;
                        }
                        else if (ptr !=5 && carrosActuales[ptr-1].Location.X >10)
                        {
                            carrosActuales[ptr] = cola.Dequeue();
                            carrosActuales[ptr].Visible = true;
                            ptr++;
                        }
                    }
                }
                else
                {
                    rng = rand.Next(1, 20);
                    if (rng == 1)
                    {
                        if (ptr != 5)
                        {
                            carrosActuales[ptr] = cola.Dequeue();
                            carrosActuales[ptr].Visible = true;
                            ptr++;
                        }
                    }
                }
                if (carrosActuales[0] != null)
                {
                    if (panelSemaforoEste.BackgroundImage != este["Rojo"])
                    {
                        carrosActuales[0].Location = new Point(carrosActuales[0].Location.X + 10, carrosActuales[0].Location.Y);
                    }
                    else if (carrosActuales[0].Location.X > 190 && panelSemaforoEste.BackgroundImage == Properties.Resources.RojoEste)
                    {
                        carrosActuales[0].Location = new Point(carrosActuales[0].Location.X + 10, carrosActuales[0].Location.Y);
                    }
                  

                    if (carrosActuales[0].Location.X > 675)
                    {
                        carrosActuales[0].Location = new Point(-30, 460);
                        cola.Enqueue(carrosActuales[0]);
                        carrosActuales[0] = carrosActuales[1];
                        carrosActuales[1] = carrosActuales[2];
                        carrosActuales[2] = carrosActuales[3];
                        carrosActuales[3] = carrosActuales[4];
                        carrosActuales[4] = null;
                        ptr--;
                    }
                }
                if (carrosActuales[1] != null)
                {
                    if (panelSemaforoEste.BackgroundImage != este["Rojo"])
                    {
                        carrosActuales[1].Location = new Point(carrosActuales[1].Location.X + 10, carrosActuales[1].Location.Y);
                    }
                    else if (carrosActuales[1].Location.X > 190 && panelSemaforoEste.BackgroundImage == Properties.Resources.RojoEste)
                    {
                        carrosActuales[1].Location = new Point(carrosActuales[1].Location.X + 10, carrosActuales[1].Location.Y);
                    }
                }
                if (carrosActuales[2] != null)
                {
                    if (panelSemaforoEste.BackgroundImage != este["Rojo"])
                    {
                        carrosActuales[2].Location = new Point(carrosActuales[2].Location.X + 10, carrosActuales[2].Location.Y);
                    }
                    else if (carrosActuales[2].Location.X > 190 && panelSemaforoEste.BackgroundImage == Properties.Resources.RojoEste)
                    {
                        carrosActuales[2].Location = new Point(carrosActuales[2].Location.X + 10, carrosActuales[2].Location.Y);
                    }
                }
                if (carrosActuales[3] != null)
                {
                    if (panelSemaforoEste.BackgroundImage != este["Rojo"])
                    {
                        carrosActuales[3].Location = new Point(carrosActuales[3].Location.X + 10, carrosActuales[3].Location.Y);
                    }
                    else if (carrosActuales[3].Location.X > 190 && panelSemaforoEste.BackgroundImage == Properties.Resources.RojoEste)
                    {
                        carrosActuales[3].Location = new Point(carrosActuales[3].Location.X + 10, carrosActuales[3].Location.Y);
                    }
                    
                }
                if (carrosActuales[4] != null)
                {
                    if (panelSemaforoEste.BackgroundImage != este["Rojo"])
                    {
                        carrosActuales[4].Location = new Point(carrosActuales[4].Location.X + 10, carrosActuales[4].Location.Y);
                    }
                    else if (carrosActuales[4].Location.X > 190 && panelSemaforoEste.BackgroundImage == Properties.Resources.RojoEste)
                    {
                        carrosActuales[4].Location = new Point(carrosActuales[4].Location.X + 10, carrosActuales[4].Location.Y);
                    }
                }


            };
            timer.Start();
        }

    }
}
