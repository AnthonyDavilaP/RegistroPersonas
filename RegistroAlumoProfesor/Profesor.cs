using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAlumoProfesor
{
    internal class Profesor : Persona
    {
        //Atributos de la clase hija 
        public string Materia { get; set; }
        //Constructor de la clase hija
        public Profesor(string nombre, string apellido, int edad, string materia) : base(nombre, apellido, edad)
        {
            this.Materia = materia;
        }
        // Propiedad sobrescrita de la clase padre que devuelve la materia
        public override string CarreraMateria => Materia;
    }
}
