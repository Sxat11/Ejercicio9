using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;

namespace Ejercicio9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Ordenador.checkIPs("192.120.000.232"));
            Dictionary<string, Ordenador> redOrdenadores = new Dictionary<string, Ordenador>();
            short opcion;
            short cont = 0;

            do
            {
                Console.WriteLine("1. Añadir ordenador");
                Console.WriteLine("2. Añadir varios equipos");
                Console.WriteLine("3. Elimina un dato");
                Console.WriteLine("4. Muestra de la colección entera");
                Console.WriteLine("5. Muestra de un elemento de la colección");
                Console.WriteLine("6. Salir");
                string opcionT = Console.ReadLine();
                opcion = short.Parse(opcionT);
                switch (opcion)
                {
                    case 1:
                        bool flag = true;
                        string ip;
                        do
                        {
                            Console.WriteLine("Dime su IP");
                            ip = Console.ReadLine();
                            if (Ordenador.checkIPs(ip))
                            {
                                Console.WriteLine("IP correcta");
                                flag = false;

                            }
                            else
                            {
                                Console.WriteLine("IP incorrecta");
                                flag = true;
                            }
                        } while (flag == true);
                        try
                        {

                            Console.WriteLine("Dime su nombre");
                            string nombre = Console.ReadLine();
                            if (nombre == null || nombre == "")
                                throw new ArgumentException("El nombre no puede estar vacío");
                            Console.WriteLine("Dime su RAM");
                            string ramT = Console.ReadLine();
                            int ram = int.Parse(ramT);
                            redOrdenadores.Add(ip, new Ordenador(nombre, ram));
                            Console.WriteLine("Ordenador añadido correctamente");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("La RAM debe ser un número");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Error inesperado: {e.Message}");
                        }
                   
                        break;

                    case 2:
                        Console.WriteLine("Lista de ordenadores que quieres añadir:");
                        string lista = Console.ReadLine();
                        string[] partes = lista.Split(':',',');
                        for (int i = 0; i < partes.Length; i++)
                        {
                            if (i % 2 == 0 && Ordenador.checkIPs(partes[i]))
                            {
                                cont++;
                                string ip2 = partes[i];
                            int ram = int.Parse(partes[i + 1]);
                            redOrdenadores.Add(ip2, new Ordenador("PC" + (cont), ram));
                            Console.WriteLine("Se ha añadido el ordenador " + "PC" + (cont));
                            }
                        }
                        break;

                    case 3:
                        Console.WriteLine("Dime la IP del ordenador que quieres eliminar");
                        string ip3 = Console.ReadLine();
                        if (redOrdenadores.ContainsKey(ip3))
                        {
                            redOrdenadores.Remove(ip3);
                            Console.WriteLine("Ordenador eliminado correctamente");
                        }
                        else
                        {
                            Console.WriteLine("No existe ese ordenador");
                        }
                        break;
                    case 4:
                        foreach (var ipT in redOrdenadores)
                        {
                            Console.WriteLine($"IP: {ipT.Key}");

                        }
                        break;
                    case 5:
                        Console.WriteLine("Dime la IP del ordenador que quieres ver");
                        string ip4 = Console.ReadLine();
                        if (redOrdenadores.ContainsKey(ip4))
                        {
                            Console.WriteLine(redOrdenadores[ip4].ToString()); 
                        }
                        else
                        {
                            Console.WriteLine("No existe ese ordenador");
                        }
                        break;
                    case 6:
                        Console.WriteLine("Adios Mundo");
                        break;
                    default:
                        break;
                }
            } while (opcion != 6);

        }
    }
}
