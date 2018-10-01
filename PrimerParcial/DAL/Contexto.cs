using PrimerParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PrimerParcial.DAL
{
    class Contexto : DbContext
    {
        public DbSet<Vendedores> Vendedore { get; set; }

        public Contexto() : base("ConStr")
        {
        }

    }
}