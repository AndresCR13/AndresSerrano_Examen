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
                string titulo = "";


                while (true)
                {
                    Console.Write("Título: ");
                    titulo = Console.ReadLine();

                    if (int.TryParse(titulo, out _))
                    {
                        // Si se ingresa un número, muestra un mensaje de error.
                        Console.WriteLine("Error: El título no puede ser un número. Intenta nuevamente.");
                    }
                    else if (string.IsNullOrWhiteSpace(titulo))
                    {
                        // Si se deja el espacio en blanco, muestra un mensaje de error.
                        Console.WriteLine("Error: El título no puede estar en blanco. Intenta nuevamente.");
                    }
                    else
                    {
                        // Si la entrada es válida, sale del bucle.
                        break;
                    }
                }

                
                string autor = "";
                while (true)
                {
                    Console.Write("Autor: ");
                    autor = Console.ReadLine();

                    if (int.TryParse(autor, out _))
                    {
                        // Si se ingresa un número, muestra un mensaje de error.
                        Console.WriteLine("Error: El título no puede ser un número. Intenta nuevamente.");
                    }
                    else if (string.IsNullOrWhiteSpace(autor))
                    {
                        // Si se deja el espacio en blanco, muestra un mensaje de error.
                        Console.WriteLine("Error: El título no puede estar en blanco. Intenta nuevamente.");
                    }
                    else
                    {
                        // Si la entrada es válida, sale del bucle.
                        break;
                    }
                }
                Console.Write("Fecha de Publicación (Año-Mes-Dia): ");
                DateTime fechaPublicacion = DateTime.Parse(Console.ReadLine());

                Console.Write("Precio: ");
                double precio = double.Parse(Console.ReadLine());

                Console.Write("¿El libor se encuentra Disponible? (true/false): ");
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

                        case 5: MayorPrecio(); break;

                        case 6:; LibrosBaratos(); break;

                        case 7: BuscarAutor(); break;

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
                bool existe = false;

                Console.WriteLine("Digite el código del libro que desea buscar:");
                cod = Convert.ToInt32(Console.ReadLine());

                foreach (var libro in listaLibros)
                {
                    if (cod == libro.Codigo)
                    {
                        Console.WriteLine($"Información del libro con código {cod}:");
                        Console.WriteLine($"- Título: {libro.Titulo}");
                        Console.WriteLine($"- Autor: {libro.Autor}");
                        Console.WriteLine($"- Fecha de Publicación: {libro.FechaPublicacion.ToShortDateString()}");
                        Console.WriteLine($"- Precio: ${libro.Precio}");
                        Console.WriteLine($"- Disponible: {(libro.Disponible ? "Sí" : "No")}");

                        existe = true;
                        break;
                    }
                    if (!existe)
                    {
                        Console.Clear();
                        Console.WriteLine("El libro no existe en la biblioteca.");
                    }
                } 
            }
            static void MayorPrecio()
            {
                if (listaLibros.Count > 0)
                {
                    var libroMasCaro = listaLibros.OrderByDescending(libro => libro.Precio).First();

                    Console.WriteLine($"Libro más caro:");
                    Console.WriteLine($"- Título: {libroMasCaro.Titulo}");
                    Console.WriteLine($"- Autor: {libroMasCaro.Autor}");
                    Console.WriteLine($"- Fecha de Publicación: {libroMasCaro.FechaPublicacion.ToShortDateString()}");
                    Console.WriteLine($"- Precio: ${libroMasCaro.Precio}");
                    Console.WriteLine($"- Disponible: {(libroMasCaro.Disponible ? "Sí" : "No")}");
                }
                else
                {
                    Console.WriteLine("La biblioteca está vacía. No hay libros disponibles.");
                }
            }
            static void LibrosBaratos()
            {
                if (listaLibros.Count > 0)
                {
                    var tresLibrosMasBaratos = listaLibros.OrderBy(libro => libro.Precio).Take(3).ToList();

                    Console.WriteLine("Los tres libros más baratos son:");
                    foreach (var libro in tresLibrosMasBaratos)
                    {
                        Console.WriteLine($"- Título: {libro.Titulo}");
                        Console.WriteLine($"- Autor: {libro.Autor}");
                        Console.WriteLine($"- Precio: ${libro.Precio}");
                        Console.WriteLine($"- Disponible: {(libro.Disponible ? "Sí" : "No")}");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("La biblioteca está vacía. No hay libros disponibles.");
                }
            }
            static void BuscarAutor()
            {
                Console.WriteLine("Ingrese el inicio del nombre del autor que desea buscar:");
                string inicioAutor = Console.ReadLine();

                bool resultado = false;

                Console.WriteLine($"Resultados de la búsqueda para autores de nombre '{inicioAutor}':");
                foreach (var libro in listaLibros)
                {
                    if (libro.Autor.StartsWith(inicioAutor, StringComparison.OrdinalIgnoreCase))
                    {
                        resultado = true;

                        Console.WriteLine(libro.Titulo);
                        Console.WriteLine($"- Autor: {libro.Autor}");
                        Console.WriteLine($"- Fecha de Publicación: {libro.FechaPublicacion.ToShortDateString()}");
                        Console.WriteLine($"- Precio: ${libro.Precio}");
                        Console.WriteLine($"- Disponible: {(libro.Disponible ? "Sí" : "No")}");
                        Console.WriteLine();
                    }
                }

                if (!resultado)
                {
                    Console.WriteLine($"No se encontraron libros con autores de nombre '{inicioAutor}'.");
                }
            }
        }              
    }
}
