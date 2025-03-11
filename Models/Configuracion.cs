using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace actualizadorNET.Models
{
    class Configuracion
    {
        public string IPServer { get; set; } = string.Empty;
        public string nameServer { get; set; } = string.Empty;
        public List<CarpetaConfig> Rutas { get; set; } = new List<CarpetaConfig>();
        public int IntervaloPing { get; set; } = 30000; //intervalo en milisegundos
    }

    public class CarpetaConfig
    {
        //ip del servidor
        public string IPServidor { get; set; } = string.Empty;
        //ruta del directorio origen (servidor)
        public string Servidor { get; set; } = string.Empty;
        //ruta del directorio destino (cliente)
        public string Destino { get; set; } = string.Empty;
    }
}
