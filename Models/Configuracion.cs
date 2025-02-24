using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace actualizadorNET.Models
{
    class Configuracion
    {
        public int IntervaloPing { get; set; } = 30000; //intervalo en milisegundos
        public List<CarpetaConfig> Carpetas { get; set; } = new List<CarpetaConfig>();
    }

    public class CarpetaConfig
    {
        //ruta del directorio origen (servidor)
        public string Servidor { get; set; } = string.Empty;
        //ruta del directorio destino (cliente)
        public string Destino { get; set; } = string.Empty;
    }
}
