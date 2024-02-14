using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AndresSerrano_Examen
{
    internal class Biblioteca : Libro
    {
 
        
        public static List<Libro> listaLibros = new List<Libro>();
        // variable
        public static int opcion;
        public static void AgregarLibro() 
        {
            //variable
               Boolean fin = true;
            do
            {
                Console.WriteLine("Ingrese la información del nuevo libro:");
                Console.Write("Código: ");
                int codigo = int.Parse(Console.ReadLine());

                Console.Write("Título: ");
                string titulo = Console.ReadLine();

                Console.Write("Autor: ");
                string autor = Console.ReadLine();

                Console.Write("Fecha de Publicación (YYYY-MM-DD): ");
                DateTime fechaPublicacion = DateTime.Parse(Console.ReadLine());

                Console.Write("Precio: ");
                double precio = double.Parse(Console.ReadLine());

                Console.Write("¿El libor se encuentra Disponible? (s/n): ");
                bool disponible = bool.Parse(Console.ReadLine());
                Console.Write("Desea agregar otro producto? (s/n):");
                string n = Console.ReadLine();
                listaLibros.Add(new Libro
                {
                    Codigo = codigo,
                    Autor = autor,
                    Titulo = titulo,
                    FechaPublicacion = fechaPublicacion,
                    Precio = precio,
                    Disponible = disponible
                });
                if (n.Equals("n")) fin = false;

            } while (fin);

        }
        public static void EliminarLibro() 
        {
            Console.WriteLine("Digite el código del libro que desea borrar");
            int cod = Convert.ToInt32(Console.ReadLine());

            bool existe = false;

            for (int i = 0; i < listaLibros.Count; i++)
            {
                if (cod == listaLibros[i].Codigo)
                {
                    listaLibros.RemoveAt(i);
                    Console.WriteLine($"Libro con código {cod} eliminado exitosamente.");
                    existe = true;
                    break;
                }
            }
        }
        public static void MostrarTodosLibros ()
        {
            Console.WriteLine("Reporte de Productos");
            foreach (var item in listaLibros)
            {
                Console.WriteLine($"Código: {item.Codigo} Titulo :{item.Titulo} Autor: {item.Autor} Fecha de Publicacion: {item.FechaPublicacion} Precio: {item.Precio}");
            }
        }
        
        public static void Menu() 
        {
            do // bucle que se ejecuta almenos una vez 
            {
                Console.WriteLine("--Menú Principal--");
                Console.WriteLine("1. Agregar un libro a la biblioteca.");
                Console.WriteLine("2. Eliminar un libro de la biblioteca.");
                Console.WriteLine("3. Mostrar todos los libros de la biblioteca.");
                Console.WriteLine("4. Buscar libros.");
                Console.WriteLine("5. Mostrar libro de mayor precio.");
                Console.WriteLine("6. Mostrar los tres libros más baratos.");
                Console.WriteLine("7. Buscar libros por inicio del nombre del autor");
                Console.WriteLine("8. Salir del programa");
                Console.WriteLine("Digite una opción...");


                string input = Console.ReadLine();

                if (int.TryParse(input, out opcion))
                {
                    switch (opcion) // condicional que dependiendo de la opcion dada por el usuario muestra diferentes metodos
                    {
                        case 1: AgregarLibro(); break;

                        case 2: EliminarLibro(); break;

                        case 3: MostrarTodosLibros(); break;

                        case 4: BuscarLibros(); break;

                        case 5: Console.WriteLine("opcion 5..."); break;

                        case 6:;  Console.WriteLine("opcion 6...");break;

                        case 7: Console.WriteLine("opcion 7..."); break;

                        case 8:Console.WriteLine("Saliendo..."); break;

                        default: Console.WriteLine("Digite una opción correcta"); break;
                    }
                }
                else
                {
                    Console.WriteLine("La opción ingresada no es válida. Por favor, ingrese un número.");
                }

            } while (opcion != 8);

            static void BuscarLibros()
            {
                int cod = 0;
                Boolean existe = false;
                Console.WriteLine("Digite el código del producto que desea buscar");
                cod = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < listaLibros.Count; i++)
                {
                    if (cod == listaLibros[i].Codigo)
                    {
                        Console.WriteLine("Informacion del libro ");

                        existe = true;
                        break;
                    }
                    if (!existe)
                    {
                        Console.Clear();
                        Console.WriteLine("El libro no existe");
                    }
                }
            }
    }              
    }
}
