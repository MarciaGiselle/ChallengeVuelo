using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio
{
    public class VueloServicio
    {
        VuelosEntities ctx = new VuelosEntities();
        public void Crear(Vuelo vuelo)
        {
            ctx.Vuelo.Add(vuelo);
            ctx.SaveChanges();
        }

        public void Modificar(Vuelo v)
        {
            Vuelo vuelo = GetById(v.Id);
            vuelo.LineaAerea = v.LineaAerea;
            vuelo.Numero = v.Numero;
            vuelo.HorarioLlegada = v.HorarioLlegada;
            vuelo.Demorado = v.Demorado;
            ctx.SaveChanges();
        }

        public List<Vuelo> Listar()
        {
            return ctx.Vuelo.OrderBy(v => v.HorarioLlegada).ToList();
        }

        public void Eliminar(int id)
        {
            Vuelo v = GetById(id);
            ctx.Vuelo.Remove(v);
            ctx.SaveChanges();

        }
        public Vuelo GetById(int id)
        {
            return ctx.Vuelo.FirstOrDefault(x => x.Id == id);

        }


    }

}

