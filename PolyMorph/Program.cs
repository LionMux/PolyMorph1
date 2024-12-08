class Program
{
    static void Main(string[] args)
    {
        ElectroCar car = new ElectroCar(5, 50, 145, 10, 5);
        car.Refuel(50);
        car.Move(1000);
        car.TurnOnConditioner();
        Console.WriteLine(car);
        Console.ReadLine();
    }
}