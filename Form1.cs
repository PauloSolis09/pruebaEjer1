using System;
using System.Collections.Generic;

class Estudiante
{
    // Definimos las propiedades del estudiante
    public string Nombre;
    public string Apellido;
    public double NotaFinal;

    // Método para calcular la calificación en letras
    public string CalificacionLetra()
    {
        if (NotaFinal >= 90) return "A";
        if (NotaFinal >= 80) return "B";
        if (NotaFinal >= 70) return "C";
        if (NotaFinal >= 60) return "D";
        return "F";
    }
}

class Program
{
    static void Main()
    {
        // Creamos una lista para almacenar los estudiantes
        List<Estudiante> estudiantes = new List<Estudiante>();

        Console.WriteLine("Ingrese los datos de los estudiantes. Escriba 'fin' para terminar.");

        // Bucle para ingresar datos de estudiantes
        while (true)
        {
            Estudiante estudiante = new Estudiante(); // Creamos un nuevo estudiante

            // Ingreso del nombre
            Console.Write("Ingrese el nombre del estudiante (o 'fin' para terminar): ");
            estudiante.Nombre = Console.ReadLine();
            if (estudiante.Nombre.ToLower() == "fin") break; // Salir si se ingresa 'fin'

            // Ingreso del apellido
            Console.Write("Ingrese el apellido del estudiante: ");
            estudiante.Apellido = Console.ReadLine();

            // Ingreso de la nota final
            Console.Write("Ingrese la nota final del estudiante: ");
            estudiante.NotaFinal = double.Parse(Console.ReadLine()); // Asumimos que el ingreso es correcto

            // Agregar el estudiante a la lista
            estudiantes.Add(estudiante);
        }

        // Ordenar estudiantes por nota final usando Merge Sort
        List<Estudiante> estudiantesOrdenados = MergeSort(estudiantes);

        // Mostrar resultados
        Console.WriteLine("\nListado de estudiantes ordenados por nota final:");
        foreach (var est in estudiantesOrdenados)
        {
            Console.WriteLine($"{est.Nombre} {est.Apellido} - Nota: {est.NotaFinal}, Calificación: {est.CalificacionLetra()}");
        }
    }

    // Método para realizar Merge Sort
    static List<Estudiante> MergeSort(List<Estudiante> estudiantes)
    {
        // Si la lista tiene un solo elemento o está vacía, ya está ordenada
        if (estudiantes.Count <= 1)
            return estudiantes;

        // Dividir la lista en dos mitades
        int mid = estudiantes.Count / 2;
        var izquierda = MergeSort(estudiantes.GetRange(0, mid)); // Lado izquierdo
        var derecha = MergeSort(estudiantes.GetRange(mid, estudiantes.Count - mid)); // Lado derecho

        // Fusionar las dos mitades ordenadas
        return Merge(izquierda, derecha);
    }

    // Método para fusionar dos listas ordenadas
    static List<Estudiante> Merge(List<Estudiante> izquierda, List<Estudiante> derecha)
    {
        List<Estudiante> resultado = new List<Estudiante>(); // Lista para almacenar el resultado
        int i = 0, j = 0;

        // Comparar elementos de ambas listas y agregar el menor a la lista resultado
        while (i < izquierda.Count && j < derecha.Count)
        {
            if (izquierda[i].NotaFinal <= derecha[j].NotaFinal)
            {
                resultado.Add(izquierda[i]);
                i++;
            }
            else
            {
                resultado.Add(derecha[j]);
                j++;
            }
        }

        // Agregar elementos restantes de la lista izquierda
        while (i < izquierda.Count)
        {
            resultado.Add(izquierda[i]);
            i++;
        }

        // Agregar elementos restantes de la lista derecha
        while (j < derecha.Count)
        {
            resultado.Add(derecha[j]);
            j++;
        }

        return resultado; // Retornar la lista fusionada
    }
}
