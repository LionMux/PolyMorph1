public class AirConditioner
{
    public bool _statusOfConditioner = false;

    public void TurnOnAirConditioner()
    {
        _statusOfConditioner = true;
        Console.WriteLine("Кондиционер включен");
    }

    public void TurnOffAirConditioner()
    {
        _statusOfConditioner = false;
        Console.WriteLine("Кондиционер выключен");
    }

    public void CheckForBatterySave()
    {
        if (_statusOfConditioner == true)
        {
            Console.WriteLine("Так как заряд батареи ниже 20%, то был отключен кондиционер");
            _statusOfConditioner = false;
        }
    }
}