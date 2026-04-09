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
        protected void cambioHorario(Label hora)
        {
            var t = new System.Windows.Forms.Timer();
            t.Interval = 1000;
            t.Tick += (s, e) =>
            {
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
