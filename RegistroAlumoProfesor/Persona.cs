using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAlumoProfesor
{
    internal class Persona
    {
        //Atributos de la clase padre
        public string Nombre {  get; set; }
        public string Apellido { get; set; }
        public int Edad {  get; set; }
        // Propiedad que devuelve el tipo de persona
        public string Tipo => this is Alumno ? "ALUMNO" : "PROFESOR";
        //Constructor de la clase padre
        public Persona(string nombre, string apellido, int edad) 
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Edad = edad;
        }
        // Propiedad virtual que será sobrescrita por las clases hijas
        public virtual string CarreraMateria { get; set; }
    }

}
