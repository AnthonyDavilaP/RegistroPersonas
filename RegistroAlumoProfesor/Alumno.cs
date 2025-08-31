using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAlumoProfesor
{
    internal class Alumno : Persona
    {
        //Atributos de la clase hija
        public string Carrera { get; set; }
        //Constructor de la clase hija
        public Alumno(string nombre, string apellido, int edad, string carrera) : base(nombre, apellido, edad)
        {
            this.Carrera = carrera;
        }
        // Propiedad sobrescrita de la clase padre que devuelve la carrera
        public override string CarreraMateria => Carrera;
       
    }

}
