using System.Security.Cryptography;
using System.Windows.Forms.PropertyGridInternal;

namespace Logica
{
    public class Semaforos : Horario
    {
        private Panel semaforoNorte;
        private Panel semaforoSur;
        private string estadoSemaforoSur = "Rojo";
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
            int verdeLargo = 13000;
            int verdeCorto = 8300;
            int amarillo = 1000;
            int intervalo = verdeLargo;
            bool rep1 = false;
            bool rep2 = false;
            bool rep3 = false;
            bool rep4 = false;
            var t1 = new System.Windows.Forms.Timer();
            var t2 = new System.Windows.Forms.Timer();
            var t3 = new System.Windows.Forms.Timer();
            var t4 = new System.Windows.Forms.Timer();
            t1.Interval = intervalo;
            t1.Tick += (s, e) =>
            {
                if (rep1)
                {
                    t2.Start();
                    t1.Stop();
                }
                semaforoNorte.BackgroundImage = norte["Rojo"];
                semaforoSur.BackgroundImage = sur["Rojo"];
                semaforoEste.BackgroundImage = este["Verde"];
                semaforoOeste.BackgroundImage = oeste["Verde"];
                rep1 = true;
            };
            t2.Interval = amarillo;
            t2.Tick += (s, e) =>
            {
                if (rep2)
                {
                    t3.Start();
                    t2.Stop();
                }
                semaforoNorte.BackgroundImage = norte["Rojo"];
                semaforoSur.BackgroundImage = sur["Rojo"];
                semaforoEste.BackgroundImage = este["Amarillo"];
                semaforoOeste.BackgroundImage = oeste["Amarillo"];
                rep2 = true;
            };
            t3.Interval = intervalo;
            t3.Tick += (s, e) =>
            {
                if (rep3)
                {
                    t4.Start();
                    t3.Stop();
                }
                semaforoNorte.BackgroundImage = norte["Verde"];
                semaforoSur.BackgroundImage = sur["Verde"];
                semaforoEste.BackgroundImage = este["Rojo"];
                semaforoOeste.BackgroundImage = oeste["Rojo"];
                rep3 = true;
            };
            t4.Interval = amarillo;
            t4.Tick += (s, e) =>
            {
                if (rep4)
                {
                    rep1 = false;
                    rep2 = false;
                    rep3 = false;
                    rep4 = false;
                    if ((Convert.ToInt16(hora.Text) >= 6 && Convert.ToInt16(hora.Text) <= 10) || (Convert.ToInt16(hora.Text) >= 17 && Convert.ToInt16(hora.Text) <= 21))
                    {
                        intervalo = verdeLargo;
                    }
                    else
                    {
                        intervalo = verdeCorto;
                    }
                    t1.Start();
                    t4.Stop();
                }
                semaforoNorte.BackgroundImage = norte["Amarillo"];
                semaforoSur.BackgroundImage = sur["Amarillo"];
                semaforoEste.BackgroundImage = este["Rojo"];
                semaforoOeste.BackgroundImage = oeste["Rojo"];
                rep4 = true;
            };
            t1.Start();
        }
    }
}
