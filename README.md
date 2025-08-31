# Registro de alumno o profesor

## Descripción
Aplicación básica de windows forms en C# para registrar y modificar información de Alumnos y Profesores.  
Permite agregar, modificar y visualizar registros en un DataGridView.

## Funcionalidades
- Agregar Alumnos y Profesores con nombre, apellido, edad y carrera/materia.
- Modificar registros existentes.
- Visualizar todos los registros en una tabla.
- Validación de campos obligatorios.

## Uso
1. Clonar el repositorio.
2. Abrir la solución `.sln` en Visual Studio.
3. Ejecutar el proyecto.
4. Usar los botones "Agregar" y "Modificar" para gestionar los registros.

## Clases principales
- `Persona`: Clase base.
- `Alumno`: Hereda de `Persona`.
- `Profesor`: Hereda de `Persona`.

## Notas
- Se utiliza polimorfismo para manejar Alumnos y Profesores como objetos de tipo `Persona`.
- Los datos se mantienen en memoria (BindingList) y no se guardan en base de datos.