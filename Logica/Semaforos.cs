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
    }
}
