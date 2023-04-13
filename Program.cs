using System.Globalization;
class Program
{
    static string[][] empleados = new string[100][]; // Array de arrays global.
    static int cantidadDeEmpleados = 0; //  Total de empleados creados al momento. Se inicializa con 0.

    static void Main(string[] args)
    {
        //Menu
        bool salir = false;
        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("Menu");
            Console.WriteLine();
            Console.WriteLine("1. Crear empleado");
            Console.WriteLine("2. Ver empleado");
            Console.WriteLine("3. Empleados que son mujeres");
            Console.WriteLine("4. Empleados que poseen licencia");
            Console.WriteLine("5. Empleados que ganan por encima de los 50,000");
            Console.WriteLine("6. Eliminar empleado");

            Console.WriteLine("7. Salir");

            int opcion;
            Console.Write("\nElija una opción: ");
            while (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opcion invalida, por favor utilize otro numero");
            }

            Console.WriteLine();

            switch (opcion)
            {
                case 1:
                    Console.Clear();
                    CrearEmpleado();
                    break;
                case 2:
                    VerEmpleados();
                    Console.Clear(); ;
                    break;
                case 3:
                    EmpleadosQueSonMujeres();
                    Console.Clear();
                    break;
                case 4:
                    EmpleadosConlicencia();
                    Console.Clear();
                    break;
                case 5:
                    EmpleadosPorEncimaDe50000();
                    Console.Clear();
                    break;
                case 6:
                    EliminarEmpleado();
                    Console.Clear();
                    break;
                case 7:
                    salir = true;
                    Console.Clear();
                    Console.WriteLine("Gracias por utilizar nuestro programa de nomina.!");
                    break;
                default:
                    Console.WriteLine("Opcion invalida, por favor elija otra opcion");
                    Console.Clear();
                    break;
            }

            Console.WriteLine();
        }

    }

    static void CrearEmpleado()
    {

        string[] empleado = new string[12]; // Se creó un array empleado para contener los datos de empleados y conectarlo al array global

        // Nombre
        Console.Write("Nombre: ");
        empleado[0] = string.Empty;
        do
        {
            
            empleado[0] = Console.ReadLine().ToUpper();
        }
        while (!empleado[0].All(c => Char.IsLetter(c)));

        // Apelldio

        Console.Write("Apellido: ");
        empleado[1] = string.Empty;
        do
        {
            
            empleado[1] = Console.ReadLine().ToUpper();
        }
        while (!empleado[1].All(c => Char.IsLetter(c)));

        // Edad

        Console.Write("Edad: ");
        int edad;
        while (!int.TryParse(Console.ReadLine(), out edad))
        {
            Console.WriteLine("Edad invalidad, ingrese un numero entero por favor");
            Console.Write("Edad:  ");
        }
        empleado[2] = edad.ToString();

        // Sexo

        Console.Write("Sexo (M o F): ");
        empleado[3] = Console.ReadLine().ToUpper();
        while (empleado[3] != "M" && empleado[3] != "F")
        {
            Console.WriteLine("Sexo invalido, por favor escriba 'M' para masculine y 'F' para femenino");
            Console.Write("Sexo (M o F:  ");
            empleado[3] = Console.ReadLine().ToUpper();
        }

        //Fecha de Nacimiento

        Console.Write("Fecha de nacimiento: ");
        DateOnly fechaNacimiento;
        while (!DateOnly.TryParseExact(Console.ReadLine(), "dd'/'MM'/'yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out fechaNacimiento))
        {
            Console.WriteLine("Fecha de Nacimineto Invalida. Ingrese una fecha valida en formato dd/MM/yyyy: ");
            Console.Write("Fecha de Nacimiento: ");
        }
        empleado[4] = fechaNacimiento.ToString();

        // Poseer licencia 

        Console.Write("Posee Licencia: ");
        bool poseeLicencia;
        while (!bool.TryParse(Console.ReadLine(), out poseeLicencia))
        {
            Console.Write("Ingrese True o False: ");

        }
        empleado[5] = poseeLicencia.ToString();

        // Sueldo Bruto

        Console.Write("Sueldo bruto: ");
        decimal sueldoBruto;


        while (!decimal.TryParse(Console.ReadLine(), out sueldoBruto))
        {
            Console.WriteLine("Sueldo bruto invalido, ingrese un numero entero o decimal, por favor");
            Console.Write("Sueldo Bruto:  ");
        }
        empleado[6] = sueldoBruto.ToString();

        // Tss

        Console.Write("TSS: ");
        decimal tss;
        while (!decimal.TryParse(Console.ReadLine(), out tss))
        {
            Console.WriteLine("Tss invalido, ingrese una cantidad numerica, por favor");
            Console.Write("TSS:  ");
        }

        empleado[7] = tss.ToString();

        // Impuesto sobre la renta 

        Console.Write("Impuesto sobre la renta: ");
        decimal impuestoSobreLaRenta;
        while (!decimal.TryParse(Console.ReadLine(), out impuestoSobreLaRenta))
        {
            Console.WriteLine("Impuesto sobre la renta invalido, ingrese una cantidad numerica, por favor");
            Console.Write("Impuesto sobre la renta:  ");
        }
        empleado[8] = impuestoSobreLaRenta.ToString();


        decimal sueldoNeto;
        sueldoNeto = sueldoBruto - tss - impuestoSobreLaRenta;
        empleado[9] = sueldoNeto.ToString();

        empleados[cantidadDeEmpleados] = empleado; // Agregar el empleado al array de empleados
        cantidadDeEmpleados++;

        Console.WriteLine("\nEmpleado con exito");
        Console.WriteLine("\nPrecione cualquier tecla para volver al menu.");
        Console.ReadKey();
        Console.Clear();
    }

    static void VerEmpleados()

    {
        //Metodo para ver el listado de empleados.
        if (cantidadDeEmpleados == 0)
        {
            Console.WriteLine("No hay empleados creados");
            Console.WriteLine("\nPresione una tecla para volver al menu.");
            Console.ReadKey();
            Console.Clear();
            return;
        }

        Console.WriteLine("Empleados:");

        for (int i = 0; i < cantidadDeEmpleados; i++)
        {
            Console.WriteLine($"\nEmpleado {i + 1}:");
            Console.WriteLine($"Nombre: {empleados[i][0]}");
            Console.WriteLine($"Apellido: {empleados[i][1]}");
            Console.WriteLine($"Edad: {empleados[i][2]}");
            Console.WriteLine($"Sexo: {empleados[i][3]}");
            Console.WriteLine($"Fecha de nacimiento: {empleados[i][4]}");
            Console.WriteLine($"Posee licencia: {empleados[i][5]}");
            Console.WriteLine($"Suledo bruto: {empleados[i][6]}");
            Console.WriteLine($"TSS: {empleados[i][7]}");
            Console.WriteLine($"Impuesto sobre la Renta: {empleados[i][8]}");
            Console.WriteLine();
            Console.WriteLine("------------------------------------Resultado del sueldo------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"Sueldo Neto: {empleados[i][9]}");
            Console.WriteLine();
        }
        Console.WriteLine("\nPresione una tecla para volver al menu.");
        Console.ReadKey();
        Console.Clear();
    }

    static void EmpleadosQueSonMujeres()
    {
        Console.WriteLine("Empleados que son mujeres");

        for (int i = 0; i < cantidadDeEmpleados; i++)
        {
            if (empleados[i][3] == "F")
            {
                Console.WriteLine($"\nEmpleado {i + 1}:");
                Console.WriteLine($"Nombre: {empleados[i][0]}");
                Console.WriteLine($"Apellido: {empleados[i][1]}");
                Console.WriteLine($"Edad: {empleados[i][2]}");
                Console.WriteLine($"Sexo: {empleados[i][3]}");
                Console.WriteLine($"Fecha de nacimiento: {empleados[i][4]}");
                Console.WriteLine($"Posee licencia: {empleados[i][5]}");
                Console.WriteLine($"Suledo bruto: {empleados[i][6]}");
                Console.WriteLine($"TSS: {empleados[i][7]}");
                Console.WriteLine($"Impuesto sobre la Renta: {empleados[i][8]}");
                Console.WriteLine();
                Console.WriteLine("------------------------------------Resultado del sueldo------------------------------------");
                Console.WriteLine();
                Console.WriteLine($"Sueldo Neto: {empleados[i][9]}");
                Console.WriteLine();

                Console.ReadKey();
                Console.Clear();
                
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("No hay empleados femeninos aun.");
                Console.ReadKey();
                Console.Clear();
                return;
            }

        }
    }
    static void EmpleadosConlicencia()
    {

    }

    static void EmpleadosPorEncimaDe50000()
    {  
        
    }
    static void EliminarEmpleado()
    {
       
    }

}
