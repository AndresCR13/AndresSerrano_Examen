using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndresSerrano_Examen
{
    internal interface ILibro
    {
        public void Prestar(){}
        public static void Devolver() { }
        public static void Consultar() { }

    }
}
