using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo.ServiceObject;
using Modelo;

namespace GrupoLideri.Models
{
    public static class DataManager
    {
        public static DO_Persona LogIn(string usuario, string contrasena)
        {
            DO_Persona persona = null;

            SO_Persona ServicioPersona = new SO_Persona();

            TBL_PERSONA informacionBD = ServicioPersona.Login(usuario, contrasena);

            if (informacionBD != null)
            {
                persona = new DO_Persona();
                persona.idPersona = informacionBD.ID_PERSONA;
                persona.Nombre = informacionBD.NOMBRE;
                persona.ApellidoMaterno = informacionBD.APELLIDO_MATERNO;
                persona.ApellidoPaterno = informacionBD.APELLIDO_PATERNO;
            }

            return persona;
        }
    }
}