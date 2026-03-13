void MostrarMenu()
{
    Console.WriteLine("MENÚ\n1:Evaluar nuevo contenido\n2:Mostrar reglas del sistema\n3:Mostrar estadísticas de la sesión\n4:Reiniciar estadísticas\n5:Salir");
}
int optiontipo = 0;
double duracion = 0;
string TipoContenido()
{
    Console.WriteLine("OPCIONES:\n1:Película\n2:Serie\n3:Documental\n4:Evento en vivo");
    Console.WriteLine("Ingrese una opción:");
    Console.WriteLine("Ingrese duración del contenido en minutos:");
    duracion = double.Parse(Console.ReadLine());
    optiontipo = int.Parse(Console.ReadLine());
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
        return "Dato ingresado no válido";
    }
}