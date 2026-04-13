using Logica;

namespace Interfaz
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        //Método para que al hacer click en el boton iniciar se inicializen todos los métodos que dan lógica a todo el sistema, incluyendo el de carros
        private void buttonIniciar_Click(object sender, EventArgs e)
        {
            //No permite que se vuelva a presionar el boton iniciar
            buttonIniciar.Enabled = false;
            //Diccionarios con las imagenes de cada estado de cada semáforo
            Dictionary<string, Image> norte = new Dictionary<string, Image> { { "Verde", Properties.Resources.VerdeNorte }, { "Amarillo", Properties.Resources.AmarilloNorte }, { "Rojo", Properties.Resources.RojoNorte } };
            Dictionary<string, Image> sur = new Dictionary<string, Image> { { "Verde", Properties.Resources.VerdeSur }, { "Amarillo", Properties.Resources.AmarilloSur }, { "Rojo", Properties.Resources.RojoSur } };
            Dictionary<string, Image> este = new Dictionary<string, Image> { { "Verde", Properties.Resources.VerdeEste }, { "Amarillo", Properties.Resources.AmarilloEste }, { "Rojo", Properties.Resources.RojoEste } };
            Dictionary<string, Image> oeste = new Dictionary<string, Image> { { "Verde", Properties.Resources.VerdeOeste }, { "Amarillo", Properties.Resources.AmarilloOeste }, { "Rojo", Properties.Resources.RojoOeste } };

            //Se inicializa el método para que funcionen  los semáforos
            Semaforos semaforos = new Semaforos(panelSemaforoNorte, panelSemaforoSur, panelSemaforoEste, panelSemaforoOeste, labelHora);
            semaforos.cambioSemaforos(panelSemaforoNorte, panelSemaforoSur, panelSemaforoEste, panelSemaforoOeste, labelHora, norte, sur, este, oeste);

            //Se crean las colas con los carros de cada dirección
            Queue<Panel> colaCarrosNorte = crearCarros(Properties.Resources.CarroNorte, 363, 833, 18, 30);
            Queue<Panel> colaCarrosSur = crearCarros(Properties.Resources.CarroSur, 288, 66, 18, 30);
            Queue<Panel> colaCarrosEste = crearCarros(Properties.Resources.CarroEste, -30, 460, 30, 18);
            Queue<Panel> colaCarrosOeste = crearCarros(Properties.Resources.CarroOeste, 714, 380, 30, 18);

            //Se utiliza el método de la lógica del movimiento de los carros
            generarCarrosNorte(colaCarrosNorte);
            generarCarrosSur(colaCarrosSur);
            generarCarrosEste(colaCarrosEste);
            generarCarrosOeste(colaCarrosOeste);
        }

        //Método para crear la cola con los 10 carros
        private Queue<Panel> crearCarros(Image imagen, int x, int y, int n, int m)
        {
            Queue<Panel> list = new Queue<Panel>();
            //ciclo for que crea las 10 instancias con cada panel (donde se almacenan los carros)
            for (int i = 0; i < 10; i++)
            {
                Panel panel = new Panel();
                panel.Visible = false;
                this.Controls.Add(panel);
                panel.BringToFront();
                panel.Size = new Size(n, m);
                panel.BackgroundImage = imagen;
                panel.BackgroundImageLayout = ImageLayout.Stretch;
                panel.BackColor = Color.FromArgb(64,64,64);
                panel.Location = new Point(x, y);
                list.Enqueue(panel);
            }
            return list;
        }

        //Método que da lógica a los carros, hay un método igual para cada dirección en el sistema pero solo se muestra esta para evitar exceso de código en el documento
        private void generarCarrosNorte(Queue<Panel> cola)
        {
            var timer = new System.Windows.Forms.Timer();
            var rand = new Random();
            int rng;
            int ptr = 0;
            //Panel con los carros visibles en pantalla
            Panel[] carrosActuales = new Panel[5];
            timer.Interval = 50;
            timer.Tick += (s, e) =>
            {
                //Inicio de parte de código donde se pasan los carros de la cola de espera al arreglo con los carros visibles
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
                        else if (ptr != 5 && carrosActuales[ptr - 1].Location.Y < 793)
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
                //Fin de esa parte de código

                
                if (carrosActuales[0] != null)
                {
                    //Inicio de código que mueve el carro en la posición 1 del arreglo dependiendo el estado del semáforo
                    if (panelSemaforoNorte.Tag.ToString() == "Verde")
                    {
                        carrosActuales[0].Location = new Point(carrosActuales[0].Location.X, carrosActuales[0].Location.Y - 10);
                    }
                    else if (carrosActuales[0].Location.Y < 553 && panelSemaforoNorte.Tag.ToString() == "Amarillo")
                    {
                        carrosActuales[0].Location = new Point(carrosActuales[0].Location.X, carrosActuales[0].Location.Y - 10);
                    }
                    else if (carrosActuales[0].Location.Y > 553 && panelSemaforoNorte.Tag.ToString() == "Amarillo")
                    {
                        carrosActuales[0].Location = new Point(carrosActuales[0].Location.X, carrosActuales[0].Location.Y - 10);
                    }
                    else if (carrosActuales[0].Location.Y < 553 && panelSemaforoNorte.Tag.ToString() == "Rojo")
                    {
                        carrosActuales[0].Location = new Point(carrosActuales[0].Location.X, carrosActuales[0].Location.Y - 10);
                    }
                    else if (carrosActuales[0].Location.Y > 553 && panelSemaforoNorte.Tag.ToString() == "Rojo")
                    {
                        carrosActuales[0].Location = new Point(carrosActuales[0].Location.X, carrosActuales[0].Location.Y - 10);
                    }
                    //Fin de esa parte de código

                    //Inicio de código que regresa a cada carro a la cola de espera una vez sale de pantalla
                    if (carrosActuales[0].Location.Y < 68)
                    {
                        carrosActuales[0].Location = new Point(363, 833);
                        cola.Enqueue(carrosActuales[0]);
                        carrosActuales[0] = carrosActuales[1];
                        carrosActuales[1] = carrosActuales[2];
                        carrosActuales[2] = carrosActuales[3];
                        carrosActuales[3] = carrosActuales[4];
                        carrosActuales[4] = null;
                        ptr--;
                    }
                    //Fin de esa parte de código
                }

                if (carrosActuales[1] != null)
                {
                    //Inicio de código que mueve el carro en la posición 2 del arreglo dependiendo el estado del semáforo
                    if (panelSemaforoNorte.Tag.ToString() == "Verde")
                    {
                        carrosActuales[1].Location = new Point(carrosActuales[1].Location.X, carrosActuales[1].Location.Y - 10);
                    }
                    else if (carrosActuales[1].Location.Y < 553 && panelSemaforoNorte.Tag.ToString() == "Amarillo")
                    {
                        carrosActuales[1].Location = new Point(carrosActuales[1].Location.X, carrosActuales[1].Location.Y - 10);
                    }
                    else if (carrosActuales[1].Location.Y > 553 && panelSemaforoNorte.Tag.ToString() == "Amarillo")
                    {
                        if (!(panelSemaforoNorte.Tag.ToString() == "Amarillo" && carrosActuales[1].Location.Y - 40 == carrosActuales[0].Location.Y))
                        {
                            carrosActuales[1].Location = new Point(carrosActuales[1].Location.X, carrosActuales[1].Location.Y - 10);
                        }
                    }
                    else if (carrosActuales[1].Location.Y < 553 && panelSemaforoNorte.Tag.ToString() == "Rojo")
                    {
                        carrosActuales[1].Location = new Point(carrosActuales[1].Location.X, carrosActuales[1].Location.Y - 10);
                    }
                    else if (carrosActuales[1].Location.Y > 553 && panelSemaforoNorte.Tag.ToString() == "Rojo")
                    {
                        if (!(panelSemaforoNorte.Tag.ToString() == "Rojo" && carrosActuales[1].Location.Y - 40 == carrosActuales[0].Location.Y))
                        {
                            carrosActuales[1].Location = new Point(carrosActuales[1].Location.X, carrosActuales[1].Location.Y - 10);
                        }
                    }
                    //Fin de esa parte de código
                }
                if (carrosActuales[2] != null)
                {
                    //Inicio de código que mueve el carro en la posición 3 del arreglo dependiendo el estado del semáforo
                    if (panelSemaforoNorte.Tag.ToString() == "Verde")
                    {
                        carrosActuales[2].Location = new Point(carrosActuales[2].Location.X, carrosActuales[2].Location.Y - 10);
                    }
                    else if (carrosActuales[2].Location.Y < 553 && panelSemaforoNorte.Tag.ToString() == "Amarillo")
                    {
                        carrosActuales[2].Location = new Point(carrosActuales[2].Location.X, carrosActuales[2].Location.Y - 10);
                    }
                    else if (carrosActuales[2].Location.Y > 553 && panelSemaforoNorte.Tag.ToString() == "Amarillo")
                    {
                        if (!(panelSemaforoNorte.Tag.ToString() == "Amarillo" && carrosActuales[2].Location.Y - 40 == carrosActuales[1].Location.Y))
                        {
                            carrosActuales[2].Location = new Point(carrosActuales[2].Location.X, carrosActuales[2].Location.Y - 10);
                        }
                    }
                    else if (carrosActuales[2].Location.Y < 553 && panelSemaforoNorte.Tag.ToString() == "Rojo")
                    {
                        carrosActuales[2].Location = new Point(carrosActuales[2].Location.X, carrosActuales[2].Location.Y - 10);
                    }
                    else if (carrosActuales[2].Location.Y > 553 && panelSemaforoNorte.Tag.ToString() == "Rojo")
                    {
                        if (!(panelSemaforoNorte.Tag.ToString() == "Rojo" && carrosActuales[2].Location.Y - 40 == carrosActuales[1].Location.Y))
                        {
                            carrosActuales[2].Location = new Point(carrosActuales[2].Location.X, carrosActuales[2].Location.Y - 10);
                        }
                    }
                    //Fin de esa parte de código
                }
                if (carrosActuales[3] != null)
                {
                    //Inicio de código que mueve el carro en la posición 4 del arreglo dependiendo el estado del semáforo
                    if (panelSemaforoNorte.Tag.ToString() == "Verde")
                    {
                        carrosActuales[3].Location = new Point(carrosActuales[3].Location.X, carrosActuales[3].Location.Y - 10);
                    }
                    else if (carrosActuales[3].Location.Y < 553 && panelSemaforoNorte.Tag.ToString() == "Amarillo")
                    {
                        carrosActuales[3].Location = new Point(carrosActuales[3].Location.X, carrosActuales[3].Location.Y - 10);
                    }
                    else if (carrosActuales[3].Location.Y > 553 && panelSemaforoNorte.Tag.ToString() == "Amarillo")
                    {
                        if (!(panelSemaforoNorte.Tag.ToString() == "Amarillo" && carrosActuales[3].Location.Y - 40 == carrosActuales[2].Location.Y))
                        {
                            carrosActuales[3].Location = new Point(carrosActuales[3].Location.X, carrosActuales[3].Location.Y - 10);
                        }
                    }
                    else if (carrosActuales[3].Location.Y < 553 && panelSemaforoNorte.Tag.ToString() == "Rojo")
                    {
                        carrosActuales[3].Location = new Point(carrosActuales[3].Location.X, carrosActuales[3].Location.Y - 10);
                    }
                    else if (carrosActuales[3].Location.Y > 553 && panelSemaforoNorte.Tag.ToString() == "Rojo")
                    {
                        if (!(panelSemaforoNorte.Tag.ToString() == "Rojo" && carrosActuales[3].Location.Y - 40 == carrosActuales[2].Location.Y))
                        {
                            carrosActuales[3].Location = new Point(carrosActuales[3].Location.X, carrosActuales[3].Location.Y - 10);
                        }
                    }
                    //Fin de esa parte de código
                }
                if (carrosActuales[4] != null)
                {
                    //Inicio de código que mueve el carro en la posición 5 del arreglo dependiendo el estado del semáforo
                    if (panelSemaforoNorte.Tag.ToString() == "Verde")
                    {
                        carrosActuales[4].Location = new Point(carrosActuales[4].Location.X, carrosActuales[4].Location.Y - 10);
                    }
                    else if (carrosActuales[4].Location.Y < 553 && panelSemaforoNorte.Tag.ToString() == "Amarillo")
                    {
                        carrosActuales[4].Location = new Point(carrosActuales[4].Location.X, carrosActuales[4].Location.Y - 10);
                    }
                    else if (carrosActuales[4].Location.Y > 553 && panelSemaforoNorte.Tag.ToString() == "Amarillo")
                    {
                        if (!(panelSemaforoNorte.Tag.ToString() == "Amarillo" && carrosActuales[4].Location.Y - 40 == carrosActuales[3].Location.Y))
                        {
                            carrosActuales[4].Location = new Point(carrosActuales[4].Location.X, carrosActuales[4].Location.Y - 10);
                        }

                    }
                    else if (carrosActuales[4].Location.Y < 553 && panelSemaforoNorte.Tag.ToString() == "Rojo")
                    {
                        carrosActuales[4].Location = new Point(carrosActuales[4].Location.X, carrosActuales[4].Location.Y - 10);
                    }
                    else if (carrosActuales[4].Location.Y > 553 && panelSemaforoNorte.Tag.ToString() == "Rojo")
                    {
                        if (!(panelSemaforoNorte.Tag.ToString() == "Rojo" && carrosActuales[4].Location.Y - 40 == carrosActuales[3].Location.Y))
                        {
                            carrosActuales[4].Location = new Point(carrosActuales[4].Location.X, carrosActuales[4].Location.Y - 10);
                        }

                    }
                    //Fin de esa parte de código
                }
            };
            timer.Start();
        }

        private void generarCarrosSur(Queue<Panel> cola)
        {
            var timer = new System.Windows.Forms.Timer();
            var rand = new Random();
            int rng;
            int ptr = 0;
            Panel[] carrosActuales = new Panel[5];
            timer.Interval = 50;
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
                        else if (ptr != 5 && carrosActuales[ptr - 1].Location.Y > 106)
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
                    if (panelSemaforoSur.Tag.ToString() == "Verde")
                    {
                        carrosActuales[0].Location = new Point(carrosActuales[0].Location.X, carrosActuales[0].Location.Y + 10);
                    }
                    else if (carrosActuales[0].Location.Y > 276 && panelSemaforoSur.Tag.ToString() == "Amarillo")
                    {
                        carrosActuales[0].Location = new Point(carrosActuales[0].Location.X, carrosActuales[0].Location.Y + 10);
                    }
                    else if (carrosActuales[0].Location.Y < 276 && panelSemaforoSur.Tag.ToString() == "Amarillo")
                    {
                        carrosActuales[0].Location = new Point(carrosActuales[0].Location.X, carrosActuales[0].Location.Y + 10);
                    }
                    else if (carrosActuales[0].Location.Y > 276 && panelSemaforoSur.Tag.ToString() == "Rojo")
                    {
                        carrosActuales[0].Location = new Point(carrosActuales[0].Location.X, carrosActuales[0].Location.Y + 10);
                    }
                    else if (carrosActuales[0].Location.Y < 276 && panelSemaforoSur.Tag.ToString() == "Rojo")
                    {
                        carrosActuales[0].Location = new Point(carrosActuales[0].Location.X, carrosActuales[0].Location.Y + 10);
                    }


                    if (carrosActuales[0].Location.Y > 806)
                    {
                        carrosActuales[0].Location = new Point(288, 66);
                        carrosActuales[0].Visible = false;
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
                    if (panelSemaforoSur.Tag.ToString() == "Verde")
                    {
                        carrosActuales[1].Location = new Point(carrosActuales[1].Location.X, carrosActuales[1].Location.Y + 10);
                    }
                    else if (carrosActuales[1].Location.Y > 276 && panelSemaforoSur.Tag.ToString() == "Amarillo")
                    {
                        carrosActuales[1].Location = new Point(carrosActuales[1].Location.X, carrosActuales[1].Location.Y + 10);
                    }
                    else if (carrosActuales[1].Location.Y < 276 && panelSemaforoSur.Tag.ToString() == "Amarillo")
                    {
                        if (!(panelSemaforoSur.Tag.ToString() == "Amarillo" && carrosActuales[1].Location.Y + 40 == carrosActuales[0].Location.Y))
                        {
                            carrosActuales[1].Location = new Point(carrosActuales[1].Location.X, carrosActuales[1].Location.Y + 10);
                        }
                    }
                    else if (carrosActuales[1].Location.Y > 276 && panelSemaforoSur.Tag.ToString() == "Rojo")
                    {
                        carrosActuales[1].Location = new Point(carrosActuales[1].Location.X, carrosActuales[1].Location.Y + 10);
                    }
                    else if (carrosActuales[1].Location.Y < 276 && panelSemaforoSur.Tag.ToString() == "Rojo")
                    {
                        if (!(panelSemaforoSur.Tag.ToString() == "Rojo" && carrosActuales[1].Location.Y + 40 == carrosActuales[0].Location.Y))
                        {
                            carrosActuales[1].Location = new Point(carrosActuales[1].Location.X, carrosActuales[1].Location.Y + 10);
                        }
                    }



                }
                if (carrosActuales[2] != null)
                {
                    if (panelSemaforoSur.Tag.ToString() == "Verde")
                    {
                        carrosActuales[2].Location = new Point(carrosActuales[2].Location.X, carrosActuales[2].Location.Y + 10);
                    }
                    else if (carrosActuales[2].Location.Y > 276 && panelSemaforoSur.Tag.ToString() == "Amarillo")
                    {
                        carrosActuales[2].Location = new Point(carrosActuales[2].Location.X, carrosActuales[2].Location.Y + 10);
                    }
                    else if (carrosActuales[2].Location.Y < 276 && panelSemaforoSur.Tag.ToString() == "Amarillo")
                    {
                        if (!(panelSemaforoSur.Tag.ToString() == "Amarillo" && carrosActuales[2].Location.Y + 40 == carrosActuales[1].Location.Y))
                        {
                            carrosActuales[2].Location = new Point(carrosActuales[2].Location.X, carrosActuales[2].Location.Y + 10);
                        }
                    }
                    else if (carrosActuales[2].Location.Y > 276 && panelSemaforoSur.Tag.ToString() == "Rojo")
                    {
                        carrosActuales[2].Location = new Point(carrosActuales[2].Location.X, carrosActuales[2].Location.Y + 10);
                    }
                    else if (carrosActuales[2].Location.Y < 276 && panelSemaforoSur.Tag.ToString() == "Rojo")
                    {
                        if (!(panelSemaforoSur.Tag.ToString() == "Rojo" && carrosActuales[2].Location.Y + 40 == carrosActuales[1].Location.Y))
                        {
                            carrosActuales[2].Location = new Point(carrosActuales[2].Location.X, carrosActuales[2].Location.Y + 10);
                        }
                    }

                }
                if (carrosActuales[3] != null)
                {
                    if (panelSemaforoSur.Tag.ToString() == "Verde")
                    {
                        carrosActuales[3].Location = new Point(carrosActuales[3].Location.X, carrosActuales[3].Location.Y + 10);
                    }
                    else if (carrosActuales[3].Location.Y > 276 && panelSemaforoSur.Tag.ToString() == "Amarillo")
                    {
                        carrosActuales[3].Location = new Point(carrosActuales[3].Location.X, carrosActuales[3].Location.Y + 10);
                    }
                    else if (carrosActuales[3].Location.Y < 276 && panelSemaforoSur.Tag.ToString() == "Amarillo")
                    {
                        if (!(panelSemaforoSur.Tag.ToString() == "Amarillo" && carrosActuales[3].Location.Y + 40 == carrosActuales[2].Location.Y))
                        {
                            carrosActuales[3].Location = new Point(carrosActuales[3].Location.X, carrosActuales[3].Location.Y + 10);
                        }
                    }
                    else if (carrosActuales[3].Location.Y > 276 && panelSemaforoSur.Tag.ToString() == "Rojo")
                    {
                        carrosActuales[3].Location = new Point(carrosActuales[3].Location.X, carrosActuales[3].Location.Y + 10);
                    }
                    else if (carrosActuales[3].Location.Y < 276 && panelSemaforoSur.Tag.ToString() == "Rojo")
                    {
                        if (!(panelSemaforoSur.Tag.ToString() == "Rojo" && carrosActuales[3].Location.Y + 40 == carrosActuales[2].Location.Y))
                        {
                            carrosActuales[3].Location = new Point(carrosActuales[3].Location.X, carrosActuales[3].Location.Y + 10);
                        }
                    }

                }
                if (carrosActuales[4] != null)
                {
                    if (panelSemaforoSur.Tag.ToString() == "Verde")
                    {
                        carrosActuales[4].Location = new Point(carrosActuales[4].Location.X, carrosActuales[4].Location.Y + 10);
                    }
                    else if (carrosActuales[4].Location.Y > 276 && panelSemaforoSur.Tag.ToString() == "Amarillo")
                    {
                        carrosActuales[4].Location = new Point(carrosActuales[4].Location.X, carrosActuales[4].Location.Y + 10);
                    }
                    else if (carrosActuales[4].Location.Y < 276 && panelSemaforoSur.Tag.ToString() == "Amarillo")
                    {
                        if (!(panelSemaforoSur.Tag.ToString() == "Amarillo" && carrosActuales[4].Location.Y + 40 == carrosActuales[3].Location.Y))
                        {
                            carrosActuales[4].Location = new Point(carrosActuales[4].Location.X, carrosActuales[4].Location.Y + 10);
                        }

                    }
                    else if (carrosActuales[4].Location.Y > 276 && panelSemaforoSur.Tag.ToString() == "Rojo")
                    {
                        carrosActuales[4].Location = new Point(carrosActuales[4].Location.X, carrosActuales[4].Location.Y + 10);
                    }
                    else if (carrosActuales[4].Location.Y < 276 && panelSemaforoSur.Tag.ToString() == "Rojo")
                    {
                        if (!(panelSemaforoSur.Tag.ToString() == "Rojo" && carrosActuales[4].Location.Y + 40 == carrosActuales[3].Location.Y))
                        {
                            carrosActuales[4].Location = new Point(carrosActuales[4].Location.X, carrosActuales[4].Location.Y + 10);
                        }

                    }
                }
            };
            timer.Start();
        }

        private void generarCarrosEste(Queue<Panel> cola)
        {
            var timer = new System.Windows.Forms.Timer();
            var rand = new Random();
            int rng;
            int ptr = 0;
            Panel[] carrosActuales = new Panel[5];
            timer.Interval = 50;
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
                        else if (ptr != 5 && carrosActuales[ptr - 1].Location.X > 10)
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
                    if (panelSemaforoEste.Tag.ToString() == "Verde")
                    {
                        carrosActuales[0].Location = new Point(carrosActuales[0].Location.X + 10, carrosActuales[0].Location.Y);
                    }
                    else if (carrosActuales[0].Location.X > 180 && panelSemaforoEste.Tag.ToString() == "Amarillo")
                    {
                        carrosActuales[0].Location = new Point(carrosActuales[0].Location.X + 10, carrosActuales[0].Location.Y);
                    }
                    else if (carrosActuales[0].Location.X < 180 && panelSemaforoEste.Tag.ToString() == "Amarillo")
                    {
                        carrosActuales[0].Location = new Point(carrosActuales[0].Location.X + 10, carrosActuales[0].Location.Y);
                    }
                    else if (carrosActuales[0].Location.X > 180 && panelSemaforoEste.Tag.ToString() == "Rojo")
                    {
                        carrosActuales[0].Location = new Point(carrosActuales[0].Location.X + 10, carrosActuales[0].Location.Y);
                    }
                    else if (carrosActuales[0].Location.X < 180 && panelSemaforoEste.Tag.ToString() == "Rojo")
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
                    if (panelSemaforoEste.Tag.ToString() == "Verde")
                    {
                        carrosActuales[1].Location = new Point(carrosActuales[1].Location.X + 10, carrosActuales[1].Location.Y);
                    }
                    else if (carrosActuales[1].Location.X > 180 && panelSemaforoEste.Tag.ToString() == "Amarillo")
                    {
                        carrosActuales[1].Location = new Point(carrosActuales[1].Location.X + 10, carrosActuales[1].Location.Y);
                    }
                    else if (carrosActuales[1].Location.X < 180 && panelSemaforoEste.Tag.ToString() == "Amarillo")
                    {
                        if (!(panelSemaforoEste.Tag.ToString() == "Amarillo" && carrosActuales[1].Location.X + 40 == carrosActuales[0].Location.X))
                        {
                            carrosActuales[1].Location = new Point(carrosActuales[1].Location.X + 10, carrosActuales[1].Location.Y);
                        }
                    }
                    else if (carrosActuales[1].Location.X > 180 && panelSemaforoEste.Tag.ToString() == "Rojo")
                    {
                        carrosActuales[1].Location = new Point(carrosActuales[1].Location.X + 10, carrosActuales[1].Location.Y);
                    }
                    else if (carrosActuales[1].Location.X < 180 && panelSemaforoEste.Tag.ToString() == "Rojo")
                    {
                        if (!(panelSemaforoEste.Tag.ToString() == "Rojo" && carrosActuales[1].Location.X + 40 == carrosActuales[0].Location.X))
                        {
                            carrosActuales[1].Location = new Point(carrosActuales[1].Location.X + 10, carrosActuales[1].Location.Y);
                        }
                    }



                }
                if (carrosActuales[2] != null)
                {
                    if (panelSemaforoEste.Tag.ToString() == "Verde")
                    {
                        carrosActuales[2].Location = new Point(carrosActuales[2].Location.X + 10, carrosActuales[2].Location.Y);
                    }
                    else if (carrosActuales[2].Location.X > 180 && panelSemaforoEste.Tag.ToString() == "Amarillo")
                    {
                        carrosActuales[2].Location = new Point(carrosActuales[2].Location.X + 10, carrosActuales[2].Location.Y);
                    }
                    else if (carrosActuales[2].Location.X < 180 && panelSemaforoEste.Tag.ToString() == "Amarillo")
                    {
                        if (!(panelSemaforoEste.Tag.ToString() == "Amarillo" && carrosActuales[2].Location.X + 40 == carrosActuales[1].Location.X))
                        {
                            carrosActuales[2].Location = new Point(carrosActuales[2].Location.X + 10, carrosActuales[2].Location.Y);
                        }
                    }
                    else if (carrosActuales[2].Location.X > 180 && panelSemaforoEste.Tag.ToString() == "Rojo")
                    {
                        carrosActuales[2].Location = new Point(carrosActuales[2].Location.X + 10, carrosActuales[2].Location.Y);
                    }
                    else if (carrosActuales[2].Location.X < 180 && panelSemaforoEste.Tag.ToString() == "Rojo")
                    {
                        if (!(panelSemaforoEste.Tag.ToString() == "Rojo" && carrosActuales[2].Location.X + 40 == carrosActuales[1].Location.X))
                        {
                            carrosActuales[2].Location = new Point(carrosActuales[2].Location.X + 10, carrosActuales[2].Location.Y);
                        }
                    }

                }
                if (carrosActuales[3] != null)
                {
                    if (panelSemaforoEste.Tag.ToString() == "Verde")
                    {
                        carrosActuales[3].Location = new Point(carrosActuales[3].Location.X + 10, carrosActuales[3].Location.Y);
                    }
                    else if (carrosActuales[3].Location.X > 180 && panelSemaforoEste.Tag.ToString() == "Amarillo")
                    {
                        carrosActuales[3].Location = new Point(carrosActuales[3].Location.X + 10, carrosActuales[3].Location.Y);
                    }
                    else if (carrosActuales[3].Location.X < 180 && panelSemaforoEste.Tag.ToString() == "Amarillo")
                    {
                        if (!(panelSemaforoEste.Tag.ToString() == "Amarillo" && carrosActuales[3].Location.X + 40 == carrosActuales[2].Location.X))
                        {
                            carrosActuales[3].Location = new Point(carrosActuales[3].Location.X + 10, carrosActuales[3].Location.Y);
                        }
                    }
                    else if (carrosActuales[3].Location.X > 180 && panelSemaforoEste.Tag.ToString() == "Rojo")
                    {
                        carrosActuales[3].Location = new Point(carrosActuales[3].Location.X + 10, carrosActuales[3].Location.Y);
                    }
                    else if (carrosActuales[3].Location.X < 180 && panelSemaforoEste.Tag.ToString() == "Rojo")
                    {
                        if (!(panelSemaforoEste.Tag.ToString() == "Rojo" && carrosActuales[3].Location.X + 40 == carrosActuales[2].Location.X))
                        {
                            carrosActuales[3].Location = new Point(carrosActuales[3].Location.X + 10, carrosActuales[3].Location.Y);
                        }
                    }

                }
                if (carrosActuales[4] != null)
                {
                    if (panelSemaforoEste.Tag.ToString() == "Verde")
                    {
                        carrosActuales[4].Location = new Point(carrosActuales[4].Location.X + 10, carrosActuales[4].Location.Y);
                    }
                    else if (carrosActuales[4].Location.X > 180 && panelSemaforoEste.Tag.ToString() == "Amarillo")
                    {
                        carrosActuales[4].Location = new Point(carrosActuales[4].Location.X + 10, carrosActuales[4].Location.Y);
                    }
                    else if (carrosActuales[4].Location.X < 180 && panelSemaforoEste.Tag.ToString() == "Amarillo")
                    {
                        if (!(panelSemaforoEste.Tag.ToString() == "Amarillo" && carrosActuales[4].Location.X + 40 == carrosActuales[3].Location.X))
                        {
                            carrosActuales[4].Location = new Point(carrosActuales[4].Location.X + 10, carrosActuales[4].Location.Y);
                        }

                    }
                    else if (carrosActuales[4].Location.X > 180 && panelSemaforoEste.Tag.ToString() == "Rojo")
                    {
                        carrosActuales[4].Location = new Point(carrosActuales[4].Location.X + 10, carrosActuales[4].Location.Y);
                    }
                    else if (carrosActuales[4].Location.X < 180 && panelSemaforoEste.Tag.ToString() == "Rojo")
                    {
                        if (!(panelSemaforoEste.Tag.ToString() == "Rojo" && carrosActuales[4].Location.X + 40 == carrosActuales[3].Location.X))
                        {
                            carrosActuales[4].Location = new Point(carrosActuales[4].Location.X + 10, carrosActuales[4].Location.Y);
                        }

                    }
                }


            };
            timer.Start();
        }

        private void generarCarrosOeste(Queue<Panel> cola)
        {
            var timer = new System.Windows.Forms.Timer();
            var rand = new Random();
            int rng;
            int ptr = 0;
            Panel[] carrosActuales = new Panel[5];
            timer.Interval = 50;
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
                        else if (ptr != 5 && carrosActuales[ptr - 1].Location.X < 674)
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
                    if (panelSemaforoOeste.Tag.ToString() == "Verde")
                    {
                        carrosActuales[0].Location = new Point(carrosActuales[0].Location.X - 10, carrosActuales[0].Location.Y);
                    }
                    else if (carrosActuales[0].Location.X < 454 && panelSemaforoOeste.Tag.ToString() == "Amarillo")
                    {
                        carrosActuales[0].Location = new Point(carrosActuales[0].Location.X - 10, carrosActuales[0].Location.Y);
                    }
                    else if (carrosActuales[0].Location.X > 454 && panelSemaforoOeste.Tag.ToString() == "Amarillo")
                    {
                        carrosActuales[0].Location = new Point(carrosActuales[0].Location.X - 10, carrosActuales[0].Location.Y);
                    }
                    else if (carrosActuales[0].Location.X < 454 && panelSemaforoOeste.Tag.ToString() == "Rojo")
                    {
                        carrosActuales[0].Location = new Point(carrosActuales[0].Location.X - 10, carrosActuales[0].Location.Y);
                    }
                    else if (carrosActuales[0].Location.X > 454 && panelSemaforoOeste.Tag.ToString() == "Rojo")
                    {
                        carrosActuales[0].Location = new Point(carrosActuales[0].Location.X - 10, carrosActuales[0].Location.Y);
                    }


                    if (carrosActuales[0].Location.X < -30)
                    {
                        carrosActuales[0].Location = new Point(714, 380);
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
                    if (panelSemaforoOeste.Tag.ToString() == "Verde")
                    {
                        carrosActuales[1].Location = new Point(carrosActuales[1].Location.X - 10, carrosActuales[1].Location.Y);
                    }
                    else if (carrosActuales[1].Location.X < 454 && panelSemaforoOeste.Tag.ToString() == "Amarillo")
                    {
                        carrosActuales[1].Location = new Point(carrosActuales[1].Location.X - 10, carrosActuales[1].Location.Y);
                    }
                    else if (carrosActuales[1].Location.X > 454 && panelSemaforoOeste.Tag.ToString() == "Amarillo")
                    {
                        if (!(panelSemaforoOeste.Tag.ToString() == "Amarillo" && carrosActuales[1].Location.X - 40 == carrosActuales[0].Location.X))
                        {
                            carrosActuales[1].Location = new Point(carrosActuales[1].Location.X - 10, carrosActuales[1].Location.Y);
                        }
                    }
                    else if (carrosActuales[1].Location.X < 454 && panelSemaforoOeste.Tag.ToString() == "Rojo")
                    {
                        carrosActuales[1].Location = new Point(carrosActuales[1].Location.X - 10, carrosActuales[1].Location.Y);
                    }
                    else if (carrosActuales[1].Location.X > 454 && panelSemaforoOeste.Tag.ToString() == "Rojo")
                    {
                        if (!(panelSemaforoOeste.Tag.ToString() == "Rojo" && carrosActuales[1].Location.X - 40 == carrosActuales[0].Location.X))
                        {
                            carrosActuales[1].Location = new Point(carrosActuales[1].Location.X - 10, carrosActuales[1].Location.Y);
                        }
                    }



                }
                if (carrosActuales[2] != null)
                {
                    if (panelSemaforoOeste.Tag.ToString() == "Verde")
                    {
                        carrosActuales[2].Location = new Point(carrosActuales[2].Location.X - 10, carrosActuales[2].Location.Y);
                    }
                    else if (carrosActuales[2].Location.X < 454 && panelSemaforoOeste.Tag.ToString() == "Amarillo")
                    {
                        carrosActuales[2].Location = new Point(carrosActuales[2].Location.X - 10, carrosActuales[2].Location.Y);
                    }
                    else if (carrosActuales[2].Location.X > 454 && panelSemaforoOeste.Tag.ToString() == "Amarillo")
                    {
                        if (!(panelSemaforoOeste.Tag.ToString() == "Amarillo" && carrosActuales[2].Location.X - 40 == carrosActuales[1].Location.X))
                        {
                            carrosActuales[2].Location = new Point(carrosActuales[2].Location.X - 10, carrosActuales[2].Location.Y);
                        }
                    }
                    else if (carrosActuales[2].Location.X < 454 && panelSemaforoOeste.Tag.ToString() == "Rojo")
                    {
                        carrosActuales[2].Location = new Point(carrosActuales[2].Location.X - 10, carrosActuales[2].Location.Y);
                    }
                    else if (carrosActuales[2].Location.X > 454 && panelSemaforoOeste.Tag.ToString() == "Rojo")
                    {
                        if (!(panelSemaforoOeste.Tag.ToString() == "Rojo" && carrosActuales[2].Location.X - 40 == carrosActuales[1].Location.X))
                        {
                            carrosActuales[2].Location = new Point(carrosActuales[2].Location.X - 10, carrosActuales[2].Location.Y);
                        }
                    }

                }
                if (carrosActuales[3] != null)
                {
                    if (panelSemaforoOeste.Tag.ToString() == "Verde")
                    {
                        carrosActuales[3].Location = new Point(carrosActuales[3].Location.X - 10, carrosActuales[3].Location.Y);
                    }
                    else if (carrosActuales[3].Location.X < 454 && panelSemaforoOeste.Tag.ToString() == "Amarillo")
                    {
                        carrosActuales[3].Location = new Point(carrosActuales[3].Location.X - 10, carrosActuales[3].Location.Y);
                    }
                    else if (carrosActuales[3].Location.X > 454 && panelSemaforoOeste.Tag.ToString() == "Amarillo")
                    {
                        if (!(panelSemaforoOeste.Tag.ToString() == "Amarillo" && carrosActuales[3].Location.X - 40 == carrosActuales[2].Location.X))
                        {
                            carrosActuales[3].Location = new Point(carrosActuales[3].Location.X - 10, carrosActuales[3].Location.Y);
                        }
                    }
                    else if (carrosActuales[3].Location.X < 454 && panelSemaforoOeste.Tag.ToString() == "Rojo")
                    {
                        carrosActuales[3].Location = new Point(carrosActuales[3].Location.X - 10, carrosActuales[3].Location.Y);
                    }
                    else if (carrosActuales[3].Location.X > 454 && panelSemaforoOeste.Tag.ToString() == "Rojo")
                    {
                        if (!(panelSemaforoOeste.Tag.ToString() == "Rojo" && carrosActuales[3].Location.X - 40 == carrosActuales[2].Location.X))
                        {
                            carrosActuales[3].Location = new Point(carrosActuales[3].Location.X - 10, carrosActuales[3].Location.Y);
                        }
                    }

                }
                if (carrosActuales[4] != null)
                {
                    if (panelSemaforoOeste.Tag.ToString() == "Verde")
                    {
                        carrosActuales[4].Location = new Point(carrosActuales[4].Location.X - 10, carrosActuales[4].Location.Y);
                    }
                    else if (carrosActuales[4].Location.X < 454 && panelSemaforoOeste.Tag.ToString() == "Amarillo")
                    {
                        carrosActuales[4].Location = new Point(carrosActuales[4].Location.X - 10, carrosActuales[4].Location.Y);
                    }
                    else if (carrosActuales[4].Location.X > 454 && panelSemaforoOeste.Tag.ToString() == "Amarillo")
                    {
                        if (!(panelSemaforoOeste.Tag.ToString() == "Amarillo" && carrosActuales[4].Location.X - 40 == carrosActuales[3].Location.X))
                        {
                            carrosActuales[4].Location = new Point(carrosActuales[4].Location.X - 10, carrosActuales[4].Location.Y);
                        }
                    }
                    else if (carrosActuales[4].Location.X < 454 && panelSemaforoOeste.Tag.ToString() == "Rojo")
                    {
                        carrosActuales[4].Location = new Point(carrosActuales[4].Location.X - 10, carrosActuales[4].Location.Y);
                    }
                    else if (carrosActuales[4].Location.X > 454 && panelSemaforoOeste.Tag.ToString() == "Rojo")
                    {
                        if (!(panelSemaforoOeste.Tag.ToString() == "Rojo" && carrosActuales[4].Location.X - 40 == carrosActuales[3].Location.X))
                        {
                            carrosActuales[4].Location = new Point(carrosActuales[4].Location.X - 10, carrosActuales[4].Location.Y);
                        }
                    }
                }


            };
            timer.Start();
        }

    }
}
