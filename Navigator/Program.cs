using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите общую дистанцию (км):");
        int totalDistance = Convert.ToInt32(Console.ReadLine());   

        CarNavigator navigator = new CarNavigator(totalDistance);
        navigator.StartNavigator();
    }
}