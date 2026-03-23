using System;

public class Gnomo
{
    protected string nombre;
    protected string color;

    public Gnomo(string nombre, string color)
    {
        this.nombre = nombre;
        this.color = color;
    }
}

public class Objeto
{
    private string tipo;
    private double valor;

    public Objeto(string tipo, double valor)
    {
        this.tipo = tipo;
        this.valor = valor;
    }

    public string Tipo => tipo;
    public double Valor => valor;
}

public class GnomoLadron : Gnomo
{
    private string especialidad;

    public GnomoLadron(string nombre, string color, string especialidad) 
        : base(nombre, color)
    {
        this.especialidad = especialidad;
    }

    public bool RobarObjeto(Objeto objeto)
    {
        if (objeto != null)
        {
            Console.WriteLine($"{nombre} ha robado un {objeto.Tipo} de valor {objeto.Valor}.");
            return true;
        }
        return false;
    }
}