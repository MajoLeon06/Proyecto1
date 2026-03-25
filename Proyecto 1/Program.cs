int option;
bool optioncorrecta;
int contenido;
bool contenidocorrecto;
double duracion;
bool duracioncorrecta;
int clasificacion;
bool clasificacioncorrecta;
int hora;
bool horacorrecta;
int produccion = 0;
bool produccioncorrecta;
int evaluados=0; //contador total
int publicados=0; //contador
int rechazados=0; //contador
int revision = 0; //contador
int alto = 0; //contador impacto
int medio = 0; //contador impacto
int bajo = 0; //contador impacto
int impactomayor = 0;
double aprobados;
int cantidad = 0;
bool cantidadcorrecta;
string mayorimpacto;
void IngresarDatos()
{
    do
    {
         Console.Write("Tipo de contenido:\n 1:Película\n 2:Serie\n 3:Documental\n 4:Evento en vivo\nIngresar una opción:");
         contenidocorrecto = int.TryParse(Console.ReadLine(), out contenido);
        if (!contenidocorrecto || contenido < 1 || contenido > 4)
        {
            Console.WriteLine("Dato no válido... intente nuevamente");
        }
        Console.WriteLine();
    } while (!contenidocorrecto || contenido < 1 || contenido > 4);
    do
    {
         Console.Write("Ingrese duración en minutos:");
         duracioncorrecta = double.TryParse(Console.ReadLine(), out duracion);
        if (!duracioncorrecta)
        {
            Console.WriteLine("Dato no válido... intente nuevamente");
        }
        Console.WriteLine();
    } while (!duracioncorrecta);
    do
    {
        Console.Write("Clasificación:\n 1:Todo público\n 2:+13\n 3:+18\nIngresar una opción:");
        clasificacioncorrecta = int.TryParse(Console.ReadLine(), out clasificacion);
        if (!clasificacioncorrecta || clasificacion < 1 || clasificacion > 3)
        {
            Console.WriteLine("Dato no válido... intente nuevamente");
        }
        Console.WriteLine();
    }while(!clasificacioncorrecta || clasificacion<1 || clasificacion>3);
    do
    {
        Console.WriteLine("Ingrese la hora de transmisión programada (0-23):");
        horacorrecta = int.TryParse(Console.ReadLine(), out hora);
        if (!horacorrecta || hora < 0 || hora > 23)
        {
            Console.WriteLine("Dato no válido... intente nuevamente");
        }
        Console.WriteLine();
    } while (!horacorrecta || hora < 0 || hora > 23);
    do
    {
        Console.WriteLine("Ingrese el nivel de producción:\n 1:Bajo\n 2:Medio\n 3:Alto");
        produccioncorrecta = int.TryParse(Console.ReadLine(), out produccion);
        if (!produccioncorrecta || produccion < 1 || produccion > 3)
        {
            Console.WriteLine("Dato no válido... intente nuevamente");
        }
        Console.WriteLine();
    } while (!produccioncorrecta || produccion < 1 || produccion > 3);
    if ((contenido==1 && duracion>=60 && duracion<=180) || (contenido==2 && duracion>=20 && duracion<=90) || (contenido==3 && duracion>=30 && duracion<=120) || (contenido==4 && duracion>=30 && duracion<=240))
    {
        int impacto = Impacto();
        if(impacto==1)
        {
            Console.WriteLine("Impacto alto");
            alto++;
        }
        else if(impacto==2)
        {
            Console.WriteLine("Impacto medio");
            medio++;
        }
        else if (impacto==3)
        {
            Console.WriteLine("Impacto bajo");
            bajo++;
        }
        mayorimpacto = ImpactoMayor(bajo, medio, alto);
        if (impacto != 1)
        {
            

            if ((clasificacion == 1) || (clasificacion == 2 && hora >= 6 && hora <= 22) || (clasificacion == 3 && hora <= 5 && hora >= 22) && (impacto == 2 || impacto == 1))
            {
                Console.WriteLine("Publicar: cumple todas las reglas");
                publicados++;
            }
            else if (impacto == 3)
            {
                Console.WriteLine("Enviar a revisión por impacto alto");
                revision++;
            }
            else
            {
                Console.WriteLine("Publicar con ajustes por modificaciones menores");
                publicados++;
            }
        }
        else
        {
            Console.WriteLine("Enviar a revisión por impacto alto");
            revision++;
        }
    }
    else
    {
        Console.WriteLine("Rechazado, no publicar por incumplir una regla técnica obligatoria");
        rechazados++;
    }
}
string ImpactoMayor(int bajo, int medio, int alto)
{
    if (alto == 0 && medio == 0 && bajo == 0)
    {
        return "No hay datos";
    }
    if (bajo>medio)
    {
        impactomayor = bajo;
    }
    else if(medio>bajo)
    {
        impactomayor = medio;
    }
    else if(medio>alto)
    {
        impactomayor = medio;
    }
    else if(alto>medio)
    {
        impactomayor = alto;
    }
    else if(alto>bajo)
    {
        impactomayor = alto;
    }
    else if(bajo>alto)
    {
        impactomayor = bajo;
    }
    if (impactomayor == bajo)
    {
        return "Impacto bajo";
    }
    else if (impactomayor == medio)
    {
        return "Impacto medio";
    }
    else if (impactomayor == alto)
    {
        return "Impacto alto";
    }
    else if(bajo==alto && alto==medio)
    {
        return "No hay impacto predomintante, todos son iguales";
    }
    return "";
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
double Porcentaje(double aprobados, double evaluados)
{
    return (aprobados * 100) / evaluados;
}

do
{
    Console.Clear();
    do {
    Console.Write("STREAMING\n--MENÚ--\n1:Evaluar nuevo contenido\n2:Mostrar reglas del sistema\n3:Mostrar estadísticas de la sesión\n4:Reiniciar estadísticas\n5:Salir\n");
        Console.Write("Ingrese una opción:");
        optioncorrecta = int.TryParse(Console.ReadLine(), out option);
        if (!optioncorrecta)
        {
            Console.WriteLine("Dato no válido... intente nuevamente");
        }
    } while (!optioncorrecta);
    Console.ReadKey();
        switch (option)
    {
        case 1:
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            do
            {
                Console.Write("Ingrese la cantidad de contenido que desea evaluar:");
                cantidadcorrecta = int.TryParse(Console.ReadLine(), out cantidad);
                if(!cantidadcorrecta)
                {
                    Console.WriteLine("Dato no válido... intente nuevamente");
                }
            }while(!cantidadcorrecta);
            for (int i=1; i<=cantidad; i++)
            {
                Console.Clear();
                IngresarDatos();
                ImpactoMayor(bajo, medio, alto);
                Console.ReadKey();
            }
            evaluados = evaluados + cantidad;
            Console.ReadKey();
            Console.ForegroundColor= ConsoleColor.White;
            break;
        case 2:
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Clear();
            Console.WriteLine("REGLAS DE CLASIFICACIÓN Y HORARIO");
            Console.WriteLine("- El contenido clasificado como Todo Público puede transmitirse en cualquier horario");
            Console.WriteLine("- El contenido clasificado como +13 puede transmitirse entre 6 y 22 horas");
            Console.WriteLine("- El contenido clasificado como +18 puede transmitirse entre 22 y 5 horas");
            Console.WriteLine();
            Console.WriteLine("REGLAS DE DURACIÓN POR TIPO (obligatorias)");
            Console.WriteLine("- Las películas duran entre 60 y 180 minutos");
            Console.WriteLine("- Las series duran entre 20 y 90 minutos");
            Console.WriteLine("- Los documentales duran entre 30 y 120 minutos");
            Console.WriteLine("- Los eventos en vivo duran entre 30 y 240 minutos");
            Console.WriteLine();
            Console.WriteLine("REGLAS DE PRODUCCIÓN");
            Console.WriteLine("- La producción baja solo es válida para clasificación de Todo Público o +13");
            Console.WriteLine("- La producción media o alta es válida para cualquier clasificación");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
            break;
        case 3:
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();
            Console.WriteLine($"Total evaluados: {evaluados}");
            Console.WriteLine($"Publicados: {publicados}");
            Console.WriteLine($"Rechazados: {rechazados}");
            Console.WriteLine($"En revisión: {revision}");
            string funcion = ImpactoMayor(bajo, medio, alto);
            Console.WriteLine($"Impacto predominante: {funcion}");
            double porcentaje = Porcentaje(publicados, evaluados);
            Console.WriteLine($"Porcentaje de aprobación: {porcentaje}");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
            break;
        case 4:
            evaluados = 0;
            publicados = 0;
            rechazados = 0;
            revision = 0;
            impactomayor = 0;
            break;
        case 5:
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.WriteLine("RESUMEN DE LA SESIÓN");
            if(evaluados>0 || publicados>0 ||  rechazados>0 ||  impactomayor>0 || revision>0)
            {
                Console.WriteLine($"Total evaluados: {evaluados}");
                Console.WriteLine($"Publicados: {publicados}");
                Console.WriteLine($"Rechazados: {rechazados}");
                Console.WriteLine($"En revisión: {revision}");
                Console.WriteLine($"Impacto predominante: {impactomayor}");
                double porcentaje2 = Porcentaje(publicados, evaluados);
                Console.WriteLine($"Porcentaje de aprobación: {porcentaje2}%");
            }
            else
            {
                Console.WriteLine("No hay datos disponibles");
            }
            Console.WriteLine();
            Console.WriteLine("GRACIAS POR UTILIZAR NUESTRA PLATAFORMA");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
            break;
        default:
            Console.Clear();
            Console.WriteLine("Opción no válida, intente nuevamente");
            Console.ReadKey();
            break;
    }
} while (option != 5);
