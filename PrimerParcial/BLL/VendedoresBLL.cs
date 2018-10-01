using PrimerParcial.DAL;
using PrimerParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial.BLL
{
    class VendedoresBLL
    {
        public static bool Guardar(Vendedores vendedores)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Vendedore.Add(vendedores) != null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        public static bool Modificar(Vendedores vendedores)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(vendedores).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                Vendedores vendedores = contexto.Vendedore.Find(id);
                contexto.Vendedore.Remove(vendedores);
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        public static Vendedores Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Vendedores vendedores = new Vendedores();
            try
            {
                vendedores = contexto.Vendedore.Find(id);
                contexto.Dispose();

            }
            catch (Exception)
            {
                throw;
            }
            return vendedores;
        }
        public static List<Vendedores> GetList(Expression<Func<Vendedores, bool>> expression)
        {
            List<Vendedores> vendedores = new List<Vendedores>();
            Contexto contexto = new Contexto();
            try
            {
                vendedores = contexto.Vendedore.Where(expression).ToList();
                contexto.Dispose();

            }
            catch (Exception)
            {
                throw;
            }
            return vendedores;
        }
    }
}