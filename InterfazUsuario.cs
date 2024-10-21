using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace POO_PSAM_P10
{
    public class InterfazUsuario
    {
        private List<Opcion> opcionesPrincipal;
        private Menu menuPrincipal;
        private bool dentroMenuPrincipal = true;

        public InterfazUsuario()
        {
            opcionesPrincipal = new List<Opcion>()
        {
            new Opcion("Carrera", Carrera),
            new Opcion("Materia", Materia),
            new Opcion("Grupo", Grupo),
            new Opcion("Maestro", Maestro),
            new Opcion("Alumno", Alumno),
            new Opcion("Salir", Salir),
        };

            menuPrincipal = new Menu("Menú Escuela", opcionesPrincipal);

            while (dentroMenuPrincipal)
            {
                menuPrincipal.MostrarMenu();
                int opcion = menuPrincipal.SeleccionarOpcion();
                opcionesPrincipal[opcion - 1].Action.Invoke();
            }
        }

        public void Carrera()
        {
            bool dentroMenuCarrera = true;

            List<Opcion> opcionesCarrera = new List<Opcion>
        {
            new Opcion("Registrar carrera.", RegistrarCarrera),
            new Opcion("Ver carreras existentes.", () => Console.WriteLine(Escuela.MostrarCarreras())),
            new Opcion("Actualizar carrera existente", ActualizarCarrera),
            new Opcion("Eliminar carrera existente.", () => {
                Console.Write("Ingrese el ID de la carrera que desea eliminar: ");
                Console.WriteLine(Escuela.EliminarCarrera(int.Parse(Console.ReadLine())));
            }),
            new Opcion("Regresar a Menú Principal", () => { dentroMenuCarrera = false; RegresarPrincipal(); })
        };

            Menu menuCarrera = new Menu("Menú de las Carreras", opcionesCarrera);

            while (dentroMenuCarrera)
            {
                menuCarrera.MostrarMenu();
                int opcion = menuCarrera.SeleccionarOpcion();
                Console.WriteLine();
                opcionesCarrera[opcion - 1].Action.Invoke();
                menuCarrera.Continuar();
            }
        }

        public void RegistrarCarrera()
        {
            Console.Write("Ingrese el nombre de la carrera: ");
            string nombreCarrera = Console.ReadLine();

            Console.Write("Ingrese el ID de la carrera: ");
            int idCarrera = int.Parse(Console.ReadLine());

            Carrera carrera = new Carrera(idCarrera, nombreCarrera);
            Escuela.AgregarCarrera(carrera);

            Console.WriteLine("Carrera registrada exitosamente.");
        }

        public void ActualizarCarrera()
        {
            Console.Write("Ingrese el ID de la carrera que desea actualizar: ");
            int idCarrera = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el nuevo nombre de la carrera: ");
            string nuevoNombre = Console.ReadLine();

            Console.Write("Ingrese el nuevo ID de la carrera: ");
            int nuevoIdCarrera = int.Parse(Console.ReadLine());

            Escuela.ActualizarCarrera(idCarrera, nuevoNombre, nuevoIdCarrera);
            Console.WriteLine("Carrera actualizada exitosamente.");
        }

        public void Materia()
        {
            bool dentroMenuMateria = true;

            List<Opcion> opcionesMateria = new List<Opcion>
        {
            new Opcion("Registrar materia.", RegistrarMateria),
            new Opcion("Ver materias existentes.", () => Console.WriteLine(Escuela.MostrarMaterias())),
            new Opcion("Actualizar materia existente", ActualizarMateria),
            new Opcion("Eliminar materia existente.", () => {
                Console.Write("Ingrese el ID de la materia que desea eliminar: ");
                Console.WriteLine(Escuela.EliminarMateria(int.Parse(Console.ReadLine())));
            }),
            new Opcion("Regresar a Menú Principal", () => { dentroMenuMateria = false; RegresarPrincipal(); })
        };

            Menu menuMateria = new Menu("Menú de las Materias", opcionesMateria);

            while (dentroMenuMateria)
            {
                menuMateria.MostrarMenu();
                int opcion = menuMateria.SeleccionarOpcion();
                Console.WriteLine();
                opcionesMateria[opcion - 1].Action.Invoke();
                menuMateria.Continuar();
            }
        }

        public void RegistrarMateria()
        {
            Console.Write("Ingrese el nombre de la materia: ");
            string nombreMateria = Console.ReadLine();

            Console.Write("Ingrese el ID de la materia: ");
            int idMateria = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el número de créditos de la materia: ");
            int numeroCreditos = int.Parse(Console.ReadLine());

            Materia materia = new Materia(idMateria, nombreMateria, numeroCreditos);
            Escuela.AgregarMateria(materia);

            Console.WriteLine("Materia registrada exitosamente.");
        }

        public void ActualizarMateria()
        {
            Console.Write("Ingrese el ID de la materia que desea actualizar: ");
            int idMateria = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el nuevo nombre de la materia: ");
            string nuevoNombre = Console.ReadLine();

            Console.Write("Ingrese el nuevo número de créditos de la materia: ");
            int nuevosCreditos = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el nuevo ID de la materia: ");
            int nuevoIdMateria = int.Parse(Console.ReadLine());

            Escuela.ActualizarMateria(idMateria, nuevoNombre, nuevosCreditos, nuevoIdMateria);
            Console.WriteLine("Materia actualizada exitosamente.");
        }

        public void Grupo()
        {
            bool dentroMenuGrupo = true;

            List<Opcion> opcionesGrupo = new List<Opcion>
        {
            new Opcion("Crear grupo.", RegistrarGrupo),
            new Opcion("Ver grupos existentes.", () => Console.WriteLine(Escuela.MostrarGrupos())),
            new Opcion("Actualizar grupo existente", ActualizarGrupo),
            new Opcion("Eliminar grupo existente.", () => {
                Console.Write("Ingrese el ID del grupo que desea eliminar: ");
                Console.WriteLine(Escuela.EliminarGrupo(int.Parse(Console.ReadLine())));
            }),
            new Opcion("Regresar a Menú Principal", () => { dentroMenuGrupo = false; RegresarPrincipal(); })
        };

            Menu menuGrupo = new Menu("Menú del Grupo", opcionesGrupo);

            while (dentroMenuGrupo)
            {
                menuGrupo.MostrarMenu();
                int opcion = menuGrupo.SeleccionarOpcion();
                Console.WriteLine();
                opcionesGrupo[opcion - 1].Action.Invoke();
                menuGrupo.Continuar();
            }
        }

        public void RegistrarGrupo()
        {
            Console.Write("Ingrese el ID del grupo: ");
            int idGrupo = int.Parse(Console.ReadLine());

            Grupo grupo = new Grupo(idGrupo);
            Escuela.AgregarGrupo(grupo);

            Console.WriteLine("Grupo registrado exitosamente.");
        }

        public void ActualizarGrupo()
        {
            Console.Write("Ingrese el ID del grupo que desea actualizar: ");
            int idGrupo = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el nuevo nombre del grupo: ");
            string nuevoNombre = Console.ReadLine();

            Console.Write("Ingrese el nuevo ID del grupo: ");
            int nuevoIdGrupo = int.Parse(Console.ReadLine());

            Escuela.ActualizarGrupo(idGrupo, nuevoNombre, nuevoIdGrupo);
            Console.WriteLine("Grupo actualizado exitosamente.");
        }

        public void Maestro()
        {
            bool dentroMenuMaestro = true;

            List<Opcion> opcionesMaestro = new List<Opcion>
        {
            new Opcion("Registrar maestro.", RegistrarMaestro),
            new Opcion("Ver maestros existentes.", () => Console.WriteLine(Escuela.MostrarMaestros())),
            new Opcion("Asignar maestro a grupo", () => {
                Console.Write("Ingrese el ID del maestro: ");
                int idMaestro = int.Parse(Console.ReadLine());
                Console.Write("Ingrese el ID del grupo: ");
                int idGrupo = int.Parse(Console.ReadLine());
                Console.WriteLine(Escuela.AsignarMaestroAGrupo(idMaestro, idGrupo));
            }),
            new Opcion("Actualizar maestro existente", ActualizarMaestro),
            new Opcion("Eliminar maestro existente.", () => {
                Console.Write("Ingrese el ID del maestro que desea eliminar: ");
                Console.WriteLine(Escuela.EliminarMaestro(int.Parse(Console.ReadLine())));
            }),
            new Opcion("Regresar a Menú Principal", () => { dentroMenuMaestro = false; RegresarPrincipal(); })
        };

            Menu menuMaestro = new Menu("Menú del Maestro", opcionesMaestro);

            while (dentroMenuMaestro)
            {
                menuMaestro.MostrarMenu();
                int opcion = menuMaestro.SeleccionarOpcion();
                Console.WriteLine();
                opcionesMaestro[opcion - 1].Action.Invoke();
                menuMaestro.Continuar();
            }
        }

        public void RegistrarMaestro()
        {
            Console.Write("Ingrese el ID del maestro: ");
            int idMaestro = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el nombre del maestro: ");
            string nombreMaestro = Console.ReadLine();

            Console.Write("Ingrese el correo del maestro: ");
            string correoMaestro = Console.ReadLine();

            Maestro maestro = new Maestro(idMaestro, nombreMaestro, correoMaestro);
            Escuela.AgregarMaestro(maestro);

            Console.WriteLine("Maestro registrado exitosamente.");
        }

        public void ActualizarMaestro()
        {
            Console.Write("Ingrese el ID del maestro que desea actualizar: ");
            int idMaestro = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el nuevo nombre del maestro: ");
            string nuevoNombre = Console.ReadLine();

            Console.Write("Ingrese el nuevo correo del maestro: ");
            string nuevoCorreo = Console.ReadLine();

            Console.Write("Ingrese el nuevo ID del maestro: ");
            int nuevoIdMaestro = int.Parse(Console.ReadLine());

            Escuela.ActualizarMaestro(idMaestro, nuevoNombre, nuevoCorreo, nuevoIdMaestro);
            Console.WriteLine("Maestro actualizado exitosamente.");
        }

        public void Alumno()
        {
            bool dentroMenuAlumno = true;

            List<Opcion> opcionesAlumno = new List<Opcion>
        {
            new Opcion("Registrar alumno.", RegistrarAlumno),
            new Opcion("Ver alumnos existentes.", () => Console.WriteLine(Escuela.MostrarAlumnos())),
            new Opcion("Asignar alumno a grupo", () => {
                Console.Write("Ingrese el ID del alumno: ");
                int idAlumno = int.Parse(Console.ReadLine());
                Console.Write("Ingrese el ID del grupo: ");
                int idGrupo = int.Parse(Console.ReadLine());
                Console.WriteLine(Escuela.AsignarAlumnoAGrupo(idAlumno, idGrupo));
            }),
            new Opcion("Actualizar alumno existente", ActualizarAlumno),
            new Opcion("Eliminar alumno existente.", () => {
                Console.Write("Ingrese el ID del alumno que desea eliminar: ");
                Console.WriteLine(Escuela.EliminarAlumno(int.Parse(Console.ReadLine())));
            }),
            new Opcion("Regresar a Menú Principal", () => { dentroMenuAlumno = false; RegresarPrincipal(); })
        };

            Menu menuAlumno = new Menu("Menú del Alumno", opcionesAlumno);

            while (dentroMenuAlumno)
            {
                menuAlumno.MostrarMenu();
                int opcion = menuAlumno.SeleccionarOpcion();
                Console.WriteLine();
                opcionesAlumno[opcion - 1].Action.Invoke();
                menuAlumno.Continuar();
            }
        }

        public void RegistrarAlumno()
        {
            Console.Write("Ingrese el ID del alumno: ");
            int idAlumno = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el nombre del alumno: ");
            string nombreAlumno = Console.ReadLine();

            Alumno alumno = new Alumno(idAlumno, nombreAlumno);
            Escuela.AgregarAlumno(alumno);

            Console.WriteLine("Alumno registrado exitosamente.");
        }

        public void ActualizarAlumno()
        {
            Console.Write("Ingrese el ID del alumno que desea actualizar: ");
            int idAlumno = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el nuevo nombre del alumno: ");
            string nuevoNombre = Console.ReadLine();

            Console.Write("Ingrese el nuevo ID del alumno: ");
            int nuevoIdAlumno = int.Parse(Console.ReadLine());

            Escuela.ActualizarAlumno(idAlumno, nuevoNombre, nuevoIdAlumno);
            Console.WriteLine("Alumno actualizado exitosamente.");
        }

        public void Salir()
        {
            Console.WriteLine("Saliendo del programa...");
            dentroMenuPrincipal = false;
        }

        public void RegresarPrincipal()
        {
            dentroMenuPrincipal = true;
        }
    }

}