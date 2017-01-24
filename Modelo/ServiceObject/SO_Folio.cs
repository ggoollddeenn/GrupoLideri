using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.ServiceObject
{
    public class SO_Folio
    {
        /// <summary>
        /// Método que inserta un objeto de tipo TBL_Folios en la tabla.
        /// </summary>
        /// <param name="folio">Objeto de tipo TBL_Folios que se quiere insertar.</param>
        /// <returns>Retorna un true si se ejecutó de manera correcta, un false si hubo algun problema.</returns>
        public bool InsertFolio(TBL_FOLIOS folio)
        {
            try
            {
                //Inicializamos la conexión a través de EntityFramework.
                using (var Contexto = new BD_JDAEntities())
                {
                    //Agregamos el objeto a la tabla TBL_FOLIOS.
                    Contexto.TBL_FOLIOS.Add(folio);

                    //Guardamos los cambios y el resultado nos indicará el numero de elementos afectados en la base de datos.
                    int registros = Contexto.SaveChanges();

                    //Retornamos el valor resultante de la comparanción.
                    return registros > 0;
                }
            }
            catch (Exception er)
            {
                // Registrar error en BD  con er.InnerException.ToString();
                return false;
            }
                
        }
    }
}
