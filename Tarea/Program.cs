using System;

public class Vehiculo
{
    public string Modelo { get; set; }
    public double PrecioPorDia { get; set; }

    
    public Vehiculo(string modelo, double precioPorDia)
    {
        Modelo = modelo;
        PrecioPorDia = precioPorDia;
    }

    public void MostrarInformacion()
    {
        Console.WriteLine($"Modelo: {Modelo}, Precio por día: {PrecioPorDia}");
    }
}

public class Descuento
{
    public double PorcentajeDescuento { get; set; }

    public Descuento(double porcentajeDescuento)
    {
        PorcentajeDescuento = porcentajeDescuento;
    }

    public double AplicarDescuento(double precio)
    {
        return precio - (precio * (PorcentajeDescuento / 100));
    }
}

public static class ExtensionesVehiculo
{
    public static string FormatearInformacion(this Vehiculo vehiculo)
    {
        return ($"Vehículo: {vehiculo.Modelo}, Precio por día: {vehiculo.PrecioPorDia}");
    }

    public static double CalcularReserva(Vehiculo vehiculo, int dias, Descuento descuento)
    {
        double precioConDescuento = descuento.AplicarDescuento(vehiculo.PrecioPorDia);
        return precioConDescuento * dias;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ingresa el modelo del vehículo: ");
        string modelo = Console.ReadLine();

        Console.WriteLine("Ingresa el precio por día del vehículo: ");
        double precioPorDia = Convert.ToDouble(Console.ReadLine());

        Vehiculo vehiculo = new Vehiculo(modelo, precioPorDia);

        Console.WriteLine("Ingresa el porcentaje de descuento (0-100): ");
        double porcentajeDescuento = Convert.ToDouble(Console.ReadLine());

        Descuento descuento = new Descuento(porcentajeDescuento);

        Console.WriteLine("Ingresa la cantidad de días de la reserva: ");
        int dias = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine(vehiculo.FormatearInformacion());

        double totalReserva = ExtensionesVehiculo.CalcularReserva(vehiculo, dias, descuento);

        Console.WriteLine($"Total de la reserva para {dias} días con un {porcentajeDescuento}% de descuento: {totalReserva}");
    }
}
