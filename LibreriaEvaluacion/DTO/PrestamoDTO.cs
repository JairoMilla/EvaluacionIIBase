using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaEvaluacion.DTO
{
    public class PrestamoDTO
    {
        private int id;
        private int monto;
        private static List<PrestamoDTO> list = new List<PrestamoDTO>()
        {
            new PrestamoDTO() { Id = 1, Monto = 50000, montoMasInteres = 55000, montoAtraso =57750 },
            new PrestamoDTO() { Id = 2, Monto = 50000, montoMasInteres = 55000, montoAtraso =57750 },
            new PrestamoDTO() { Id = 3, Monto = 50000, montoMasInteres = 55000, montoAtraso =57750 },
        };
        private int montoMasInteres;
        private int montoAtraso;

        public int Id { get => id; set => id = value; }
        public int Monto { get => monto; set => monto = value; }
        public static List<PrestamoDTO> List { get => list; set => list = value; }

        public int MontoMasInteres { get => montoMasInteres; set => montoMasInteres = value; }
        public int MontoAtraso { get => montoAtraso; set => montoAtraso = value; }

        public static bool Add(PrestamoDTO datos)
        {
            try
            {
                list.Add(datos);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool RemoveAt(int index)
        {
            try
            {
                list.RemoveAt(index);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override string ToString()
        {
            
            return $"Id: {id}, Monto: {monto}, Monto mas el interes: {montoMasInteres}, Monto mas el atraso: {montoAtraso}";
        }
      
    }
}
