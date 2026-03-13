void MostrarMenu()
{
    Console.WriteLine("MENÚ\n1:Evaluar nuevo contenido\n2:Mostrar reglas del sistema\n3:Mostrar estadísticas de la sesión\n4:Reiniciar estadísticas\n5:Salir");
}
int optiontipo = 0;
double duracion = 0;
int optionhora = 0;
string TipoContenido()
{
    Console.WriteLine("OPCIONES:\n1:Película\n2:Serie\n3:Documental\n4:Evento en vivo");
    Console.WriteLine("Ingrese una opción:");
    optiontipo = int.Parse(Console.ReadLine());
    Console.WriteLine("Ingrese duración del contenido en minutos:");
    duracion = double.Parse(Console.ReadLine());
    if(optiontipo>=1 && optiontipo<=4 && duracion>0)
    {
        if ((optiontipo==1 && (duracion>=60 && duracion<=180)) || (optiontipo==2 && (duracion>=20 && duracion<=90)) || (optiontipo==3 && (duracion>=30 && duracion<=120)) || (optiontipo==4 && (duracion>=30 && duracion<=240)))
        {
            return "Válido";
        }
        else
        {
            return "No cumple con las reglas";
        }
    }
    else
    {
        return "No válido";
    }
}
string ClasificacionHora()
{
    Console.WriteLine("CLASIFICACIÓN:\n1:Todo público\n2:+13\n3:+18");
    Console.WriteLine("Ingrese opción:");
    optionhora = int.Parse(Console.ReadLine());
    if (optionhora >= 1 && optionhora <= 3)
    {
        Console.WriteLine("Ingrese hora programada de transmisión:");
        int hora = int.Parse(Console.ReadLine());
        if ((hora >= 0 && hora <= 24) && (optionhora >= 1 && optionhora <= 3))
        {
            if (optionhora == 1 || (optionhora == 2 && (hora >= 6 && hora <= 22)) || (optionhora == 3 && (hora >= 22 || hora <= 5)))
            {
                return "Válido";
            }
            else
            {
                return "No cumple con las reglas, realizar ajustes";
            }
        }
        else
        {
            return "No válido";
        }
    }
    else
    {
        return "Dato ingresado no válido";
    }
    
}
int opnivel = 0;
string Produccion(int optionhora)
{
    Console.WriteLine("Ingrese nivel de producción:\n1:Bajo\n2:Medio\n3:Alto");
    opnivel = int.Parse(Console.ReadLine());
    if (((optionhora==1 || optionhora==2) && opnivel==1) || (opnivel==2 || opnivel==3))
    {
        return "Válido";
    }
    else
    {
        return "No válido";
    }
}