using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Horario
    {
        protected Label hora;

        //Se crea un timer que se con un intervalo de 20 segundos por iteración
        protected void cambioHorario(Label hora)
        {
            //Se crea un timer que se con un intervalo de 20 segundos por iteración
            var t = new System.Windows.Forms.Timer();
            t.Interval = 20000;
            t.Tick += (s, e) =>
            {
                //Cada iteración aumenta en 1 al reloj hasta un máximo de 24 
                hora.Text = Convert.ToString((Convert.ToInt16(hora.Text)) + 1);
                if(hora.Text == "24")
                {
                    hora.Text = "0";
                }
            };
            t.Start();
        }
            
    }
}
