using System;
using System.Threading;

class CarNavigator
{
    private int totalDistance;
    private double distanceTraveled;
    private double averageSpeed;
    private double currentSpeed;
    private int timeElapsed;

    public CarNavigator(int totalDistance)
    {
        this.totalDistance = totalDistance;
    }

    public void StartNavigator()
    {
        Thread carThread = new Thread(Car);
        Thread navigatorThread = new Thread(Navigator);

        carThread.Start();
        navigatorThread.Start();

        carThread.Join();
        navigatorThread.Join();
    }

    private void Car()
    {
        Random random = new Random();
        while (distanceTraveled < totalDistance)
        {
            Thread.Sleep(1000);
            timeElapsed++;

            if (timeElapsed == 1)
            {
                currentSpeed = random.Next(10, 21); 
            }
            else
            {
                currentSpeed = random.Next(45, 56); 
            }

            distanceTraveled += currentSpeed / 3600;
            averageSpeed = distanceTraveled / timeElapsed * 3600;
        }
    }

    private void Navigator()
    {
        while (distanceTraveled < totalDistance)
        {
            Thread.Sleep(1000);

            int remainingDistance = (int)Math.Round((totalDistance - distanceTraveled) * 1000); 
            int remainingTime = (int)Math.Round((totalDistance - distanceTraveled) / (averageSpeed / 3600) / 60); 

            Console.WriteLine("Текущая скорость: {0} км/ч", (int)Math.Round(currentSpeed));
            Console.WriteLine("Средняя скорость: {0} км/ч", (int)Math.Round(averageSpeed));
            Console.WriteLine("Остаток маршрута: {0} м", remainingDistance);
            Console.WriteLine("Оставшееся время: {0} мин", remainingTime);
            Console.WriteLine();
        }
    }
}
