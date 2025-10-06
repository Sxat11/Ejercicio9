using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio9
{
    class Ordenador
    {
        string nombre; int ram;

        public static bool checkIPs(string ip)
        {
            if (ip == null || ip == "")
                return false;

            string[] partes = ip.Split('.');

            if (partes.Length != 4)
                return false;

            foreach (string parte in partes)
            {
                if (!int.TryParse(parte, out int valor))
                    return false;

                if (valor < 0 || valor > 255)
                    return false;
            }

            return true;
        }

        public Ordenador(string nombre, int ram)
        {
            this.nombre = nombre;
            this.ram = ram;
        }

        public override string ToString()
        {
            return $"Nombre: {nombre}, RAM: {ram}GB";
        }
    }


    
}
