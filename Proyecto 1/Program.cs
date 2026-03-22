int option;
int contenido;
bool contenidocorrecto;
double duracion;
bool duracioncorrecta;
int clasificacion;
bool clasificacioncorrecta;
int hora;
bool horacorrecta;
int produccion;
bool produccioncorrecta;
int evaluados; //contador total
int publicados; //contador
int rechazados; //contador
int revision; //contador
int alto; //contador impacto
int medio; //contador impacto
int bajo; //contador impacto
int impactomayor = 0;
double aprobados;
int IngresarDatos()
{
    do
    {
         Console.Write("Tipo de contenido:\n 1:Película\n 2:Serie\n 3:Documental\n 4:Evento en vivo\nIngresar una opción:");
         contenidocorrecto = int.TryParse(Console.ReadLine(), out contenido);
        if (!contenidocorrecto || contenido < 1 || contenido > 4)
        {
            Console.WriteLine("Dato no válido... intente nuevamente");
        }
    } while (!contenidocorrecto || contenido < 1 || contenido > 4);
    do
    {
         Console.Write("Ingrese duración en minutos:");
         duracioncorrecta = double.TryParse(Console.ReadLine(), out duracion);
        if (!duracioncorrecta)
        {
            Console.WriteLine("Dato no válido... intente nuevamente");
        }
    } while (!duracioncorrecta);
    do
    {
        Console.Write("Clasificación:\n 1:Todo público\n 2:+13\n 3:+18\nIngresar una opción:");
        clasificacioncorrecta = int.TryParse(Console.ReadLine(), out clasificacion);
        if (!clasificacioncorrecta || clasificacion < 1 || clasificacion > 3)
        {
            Console.WriteLine("Dato no válido... intente nuevamente");
        }
    }while(!clasificacioncorrecta || clasificacion<1 || clasificacion>3);
    do
    {
        Console.WriteLine("Ingrese la hora de transmisión programada (0-23):");
        horacorrecta = int.TryParse(Console.ReadLine(), out hora);
        if (!horacorrecta || hora < 0 || hora > 23)
        {
            Console.WriteLine("Dato no válido... intente nuevamente");
        }
    } while (!horacorrecta || hora < 0 || hora > 23);
    do
    {
        Console.WriteLine("Ingrese el nivel de producción:\n 1:Bajo\n 2:Medio\n 3:Alto");
        produccioncorrecta = int.TryParse(Console.ReadLine(), out produccion);
        if (!produccioncorrecta || produccion < 1 || produccion > 3)
        {
            Console.WriteLine("Dato no válido... intente nuevamente");
        }
    } while (!produccioncorrecta || produccion < 1 || produccion > 3);
    if ((contenido==1 && duracion>=60 && duracion<=180) || (contenido==2 && duracion>=20 && duracion<=90) || (contenido==3 && duracion>=30 && duracion<=120) || (contenido==4 && duracion>=30 && duracion<=240))
    {
        if((clasificacion==1) || (clasificacion==2 && hora>=6 && hora<=22) || (clasificacion==3 && hora<=5 && hora>=22))
        {
            Console.WriteLine("Publicar");
            publicados++;
        }
        else
        {
            Console.WriteLine("Revisar el contenido");
            revision++;
        }
    }
    else
    {
        Console.WriteLine("Rechazado, no publicar");
        rechazados++;
    }
}
int Impacto()
{
    if(produccion==3 || duracion>120 || (hora>=20 && hora<=23))
    {
        return 1; //impacto alto
        alto++;
    }
    else if (produccion==2 || (duracion>=60 && duracion<=120))
    {
        return 2; //impacto medio
        medio++;
    }
    else if (produccion==1 || duracion<60)
    {
        return 3; //impacto bajo
        bajo++;
    }
    return 0;
}