﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.ServiceObject
{
    public class SO_Persona
    {
        /// <summary>
        /// Método que busca algún registro que conincida con el usuario y la contraseña recibida en el parámetro.
        /// </summary>
        /// <param name="usuario">Cadena que representa el usuario que se requiere buscar.</param>
        /// <param name="contrasena">Cadena que representa la contraseña que se requiere buscar.</param>
        /// <returns>Retorna un true si existe un registro con el usuario y la contraseña enviadas a los parámetros, de lo contrario renorna un false.</returns>
        public TBL_PERSONA Login(string usuario, string contrasena)
        {
            //Ejemplo
            try
            {
                //Inicializamos la conexión a la base de datos a través de EntityFramework.
                using (var Contexto = new BD_JDAEntities())
                {
                    //Realizamos la consulta.
                    var persona = (from p in Contexto.TBL_PERSONA
                                     where p.CONTRASENA == contrasena && p.USUARIO == usuario
                                     select p).ToList().FirstOrDefault();

                    //Retornamos el resultado de la consulta.
                    return persona;
                }
            }
            catch (Exception er)
            {
                //Registrar error en base de datos.
                return null;
            }
        }
    }
}
