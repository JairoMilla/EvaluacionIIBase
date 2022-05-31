using LibreriaEvaluacion.DAL;
using LibreriaEvaluacion.DTO;

const string nombreAlumno = "Jairo Milla Tapia";

while (Menu(nombreAlumno))
{
    Console.ReadKey(); // pausa, solicitar la entrada de una tecla
}


static bool Menu(string nombreAlumno)
{ 
    bool continuar = true;

    Console.Clear(); // Limpia la pantalla
    Console.Title = $"Evaluación II: {nombreAlumno}";

    Console.WriteLine("Menú de opciones");
    Console.WriteLine("================");
    Console.WriteLine("1) Listar préstamos");
    Console.WriteLine("2) Agregar préstamo");
    Console.WriteLine("3) Actualizar préstamo");
    Console.WriteLine("4) Eliminar préstamo");
    Console.WriteLine("");
    Console.WriteLine("0) Salir");

    string opcion = Console.ReadLine().Trim(); // " 1 " => "1"

    switch (opcion)
    {
        case "1":
            Console.WriteLine("Listado de préstamos registrados");
            OpcionListar();
            break;
        case "2":
            Console.WriteLine("Insertar un nuevo préstamo");
            OpcionInsertar();
            break;
        case "3":
            Console.WriteLine("Actualizar un préstamo existente");
            OpcionActualizar();
            break;
        case "4":
            Console.WriteLine("Eliminar un préstamo existente");
            OpcionEliminar();
            break;
        case "0":
            Console.WriteLine("Saliendo del programa ...");
            continuar = false;
            break;
        default:
            Console.WriteLine("Opción no válida");
            break;
    }

    return continuar;
}
static void OpcionInsertar()
{
    PrestamoDAL prestamoDal = new PrestamoDAL();
    try
    {
       
        Console.WriteLine("Ingrese ID:");
        int id = int.Parse(Console.ReadLine().Trim());

        Console.WriteLine("Ingrese el monto:");
        int monto = int.Parse(Console.ReadLine().Trim());

        int montomasinteres = ((int)(monto + (monto * 0.1)));

        int montoatraso = ((int)(montomasinteres + (montomasinteres * 0.05)));


       
        PrestamoDTO nuevoPrestamo = new PrestamoDTO()
        {
            Id = id,
            Monto = monto,
            MontoMasInteres = montomasinteres,
            MontoAtraso = montoatraso
        };

        bool resultadoInsertar = prestamoDal.Insertar(nuevoPrestamo); 

        
        if (resultadoInsertar)
        {
            Console.WriteLine($"Se ha insertado un nuevo prestamo con el monto {nuevoPrestamo.Monto} exitosamente");
        }
        else
        {
            Console.WriteLine($"Hubo un error al insertar la prenda {nuevoPrestamo.Monto}");
        }

    }
    catch (Exception ex)
    {
        Console.WriteLine($"Por favor ingrese datos válidos para la nueva prenda");
    }

    Console.ReadKey(); 
}
static void OpcionActualizar()
{

}

static void OpcionEliminar()
{
    PrestamoDAL prestamoDal = new PrestamoDAL();

    Console.WriteLine("Ingrese el ID que desea eliminar:");
    int id = int.Parse(Console.ReadLine().Trim());

    bool resultadoEliminacion = prestamoDal.Eliminar(id); 

    if (resultadoEliminacion)
    {
        Console.WriteLine("Se ha eliminado la prenda");
    }
    else
    {
        Console.WriteLine("No se ha podido eliminar la prenda, revise el ID ingresado");
    }

    Console.ReadKey();
}

static void OpcionListar()
{
    PrestamoDAL prestamoDal = new PrestamoDAL();
    List<PrestamoDTO> datosLista = prestamoDal.Listar();

    foreach (PrestamoDTO dato in datosLista)
    {
        Console.WriteLine(dato.ToString());
    }

    Console.ReadKey();

}
