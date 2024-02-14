using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndresSerrano_Examen
{
    public class Libro : ILibro
    {
  
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public double Precio { get; set; }
        public bool Disponible { get; set; }
        
        public Libro() { }
        public Libro(int codigo, string titulo, string autor, DateTime fechaPublicacion, double precio, bool disponible)
        {
            Codigo = codigo;
            Titulo = titulo;
            Autor = autor;
            FechaPublicacion = fechaPublicacion;
            Precio = precio;
            Disponible = disponible;

        }


        public void Prestar()
        {
            if (Disponible)
            {
                Console.WriteLine($"El libro '{Titulo}' ha sido prestado.");
                Disponible = false;
            }
            else
            {
                Console.WriteLine($"El libro '{Titulo}' no está disponible para préstamo.");
            }
        }

        public void Devolver()
        {
            if (!Disponible)
            {
                Console.WriteLine($"El libro '{Titulo}' ha sido devuelto.");
                Disponible = true;
            }
            else
            {
                Console.WriteLine($"El libro '{Titulo}' ya está disponible.");
            }
        }

        public void Consultar()
        {
            Console.WriteLine($"Información del libro '{Titulo}':");
            Console.WriteLine($"Código: {Codigo}");
            Console.WriteLine($"Autor: {Autor}");
            Console.WriteLine($"Fecha de Publicación: {FechaPublicacion.ToShortDateString()}");
            Console.WriteLine($"Precio: ${Precio}");
            Console.WriteLine($"Disponible: {(Disponible ? "Sí" : "No")}");
        }
    }

}
