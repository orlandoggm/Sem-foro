using System.Security.Cryptography;
using System.Windows.Forms.PropertyGridInternal;

namespace Logica
{
    public class Semaforos : Horario
    {
        //Atributos del sistema de semáforos, cada atributo corresponde a un panel con un correspondiente semáforo
        private Panel semaforoNorte;
        private Panel semaforoSur;
        private Panel semaforoEste;
        private Panel semaforoOeste;

        //Método constructor, al crear un objeto inicia el método del reloj
        public Semaforos(Panel semaforoNorte, Panel semaforoSur, Panel semaforoEste, Panel semaforoOeste, Label hora)
        {
            this.semaforoNorte = semaforoNorte;
            this.semaforoSur = semaforoSur;
            this.semaforoEste = semaforoEste;
            this.semaforoOeste = semaforoOeste;
            this.hora = hora;

            cambioHorario(hora);
        }

        //Método para el cambio automático de los semáforos
        public void cambioSemaforos(Panel semaforoNorte, Panel semaforoSur, Panel semaforoEste, Panel semaforoOeste, Label hora, Dictionary<string, Image> norte, Dictionary<string, Image> sur, Dictionary<string, Image> este, Dictionary<string, Image> oeste)
        {
            //Diferentes intervalos para las diferentes horas del día (horas con y sin tráfico)
            int verdeLargo = 40000;
            int verdeCorto = 25000;
            int amarillo = 3000;
            semaforoEste.Tag = "Verde";
            semaforoNorte.Tag = "Rojo";
            semaforoOeste.Tag = "Verde";
            semaforoSur.Tag = "Rojo";

            int estado = 0; // 0: EO verde, 1: EO amarillo, 2: NS verde, 3: NS amarillo

            var timer = new System.Windows.Forms.Timer();

            timer.Tick += (s, e) =>
            {
                int horaActual;
                int.TryParse(hora.Text, out horaActual);

                //función que permite utilizar el intervalo de tiempo de semaforos correspondiente segun la hora del día
                int intervalo = ((horaActual >= 6 && horaActual <= 10) ||
                                 (horaActual >= 17 && horaActual <= 21))
                                ? verdeLargo
                                : verdeCorto;

                //Switch de decisión para el cambio de estado de los semáforos, toma como parámetro el estado actual, mismo que cambia con cada iteración del timer
                switch (estado)
                {
                    case 0:
                        // Este/Oeste verde
                        semaforoNorte.BackgroundImage = norte["Rojo"];
                        semaforoNorte.Tag = "Rojo";
                        semaforoSur.BackgroundImage = sur["Rojo"];
                        semaforoSur.Tag = "Rojo";
                        semaforoEste.BackgroundImage = este["Verde"];
                        semaforoEste.Tag = "Verde";
                        semaforoOeste.BackgroundImage = oeste["Verde"];
                        semaforoOeste.Tag = "Verde";

                        timer.Interval = intervalo;
                        //se vuelve estado 1 para que en la siguiente iteración vaya al siguiente caso
                        estado = 1;
                        break;

                    case 1:
                        // Este/Oeste amarillo
                        semaforoNorte.BackgroundImage = norte["Rojo"];
                        semaforoNorte.Tag = "Rojo";
                        semaforoSur.BackgroundImage = sur["Rojo"];
                        semaforoSur.Tag = "Rojo";
                        semaforoEste.BackgroundImage = este["Amarillo"];
                        semaforoEste.Tag = "Amarillo";
                        semaforoOeste.BackgroundImage = oeste["Amarillo"];
                        semaforoOeste.Tag = "Amarillo";

                        timer.Interval = amarillo;
                        //se vuelve estado 2 para que en la siguiente iteración vaya al siguiente caso
                        estado = 2;
                        break;

                    case 2:
                        // Norte/Sur verde
                        semaforoNorte.BackgroundImage = norte["Verde"];
                        semaforoNorte.Tag = "Verde";
                        semaforoSur.BackgroundImage = sur["Verde"];
                        semaforoSur.Tag = "Verde";
                        semaforoEste.BackgroundImage = este["Rojo"];
                        semaforoEste.Tag = "Rojo";
                        semaforoOeste.BackgroundImage = oeste["Rojo"];
                        semaforoOeste.Tag = "Rojo";

                        timer.Interval = intervalo;
                        //se vuelve estado 3 para que en la siguiente iteración vaya al siguiente caso
                        estado = 3;
                        break;

                    case 3:
                        // Norte/Sur amarillo
                        semaforoNorte.BackgroundImage = norte["Amarillo"];
                        semaforoNorte.Tag = "Amarillo";
                        semaforoSur.BackgroundImage = sur["Amarillo"];
                        semaforoNorte.Tag = "Amarillo";
                        semaforoEste.BackgroundImage = este["Rojo"];
                        semaforoEste.Tag = "Rojo";
                        semaforoOeste.BackgroundImage = oeste["Rojo"];
                        semaforoOeste.Tag = "Rojo";

                        timer.Interval = amarillo;
                        //se vuelve estado 0 para que en la siguiente iteración regrese al primer caso y reinicie el sistema
                        estado = 0;
                        break;
                }
            };

            // Estado inicial (opcional, para que no espere el primer tick)
            semaforoNorte.BackgroundImage = norte["Rojo"];
            semaforoSur.BackgroundImage = sur["Rojo"];
            semaforoEste.BackgroundImage = este["Verde"];
            semaforoOeste.BackgroundImage = oeste["Verde"];

            timer.Start();
        }
    }
}
