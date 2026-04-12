using System.Security.Cryptography;
using System.Windows.Forms.PropertyGridInternal;

namespace Logica
{
    public class Semaforos : Horario
    {
        private Panel semaforoNorte;
        private Panel semaforoSur;
        private Panel semaforoEste;
        private Panel semaforoOeste;

        public Semaforos(Panel semaforoNorte, Panel semaforoSur, Panel semaforoEste, Panel semaforoOeste, Label hora)
        {
            this.semaforoNorte = semaforoNorte;
            this.semaforoSur = semaforoSur;
            this.semaforoEste = semaforoEste;
            this.semaforoOeste = semaforoOeste;
            this.hora = hora;

            cambioHorario(hora);
        }

        public void cambioSemaforos(Panel semaforoNorte, Panel semaforoSur, Panel semaforoEste, Panel semaforoOeste, Label hora, Dictionary<string, Image> norte, Dictionary<string, Image> sur, Dictionary<string, Image> este, Dictionary<string, Image> oeste)
        {
            int verdeLargo = 40000;
            int verdeCorto = 25000;
            int amarillo = 3000;

            int estado = 0; // 0: EO verde, 1: EO amarillo, 2: NS verde, 3: NS amarillo

            var timer = new System.Windows.Forms.Timer();

            timer.Tick += (s, e) =>
            {
                int horaActual = 0;
                int.TryParse(hora.Text, out horaActual);

                int intervalo = ((horaActual >= 6 && horaActual <= 10) ||
                                 (horaActual >= 17 && horaActual <= 21))
                                ? verdeLargo
                                : verdeCorto;

                switch (estado)
                {
                    case 0:
                        // Este/Oeste verde
                        semaforoNorte.BackgroundImage = norte["Rojo"];
                        semaforoSur.BackgroundImage = sur["Rojo"];
                        semaforoEste.BackgroundImage = este["Verde"];
                        semaforoOeste.BackgroundImage = oeste["Verde"];

                        timer.Interval = intervalo;
                        estado = 1;
                        break;

                    case 1:
                        // Este/Oeste amarillo
                        semaforoNorte.BackgroundImage = norte["Rojo"];
                        semaforoSur.BackgroundImage = sur["Rojo"];
                        semaforoEste.BackgroundImage = este["Amarillo"];
                        semaforoOeste.BackgroundImage = oeste["Amarillo"];

                        timer.Interval = amarillo;
                        estado = 2;
                        break;

                    case 2:
                        // Norte/Sur verde
                        semaforoNorte.BackgroundImage = norte["Verde"];
                        semaforoSur.BackgroundImage = sur["Verde"];
                        semaforoEste.BackgroundImage = este["Rojo"];
                        semaforoOeste.BackgroundImage = oeste["Rojo"];

                        timer.Interval = intervalo;
                        estado = 3;
                        break;

                    case 3:
                        // Norte/Sur amarillo
                        semaforoNorte.BackgroundImage = norte["Amarillo"];
                        semaforoSur.BackgroundImage = sur["Amarillo"];
                        semaforoEste.BackgroundImage = este["Rojo"];
                        semaforoOeste.BackgroundImage = oeste["Rojo"];

                        timer.Interval = amarillo;
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
