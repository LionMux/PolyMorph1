internal class ElectroCar : Transport
{
    private readonly Battery _battery;
    private readonly ElectricEngine _engine;
    private bool _turnConditioner;

    public bool TurnConditioner
    {
        get
        {
            return _turnConditioner;
        }
        set
        {
            if (value)
            {
                AirConditioner.TurnOnAirConditioner();
            }
            else if (AirConditioner._statusOfConditioner)
            {
                AirConditioner.TurnOffAirConditioner();
            }
        }
    }
    public int NumberOfDoors { get; }
    public AirConditioner AirConditioner { get; }

    protected override EnergySourse EnergySourse => _battery;
    protected override EngineBase Engine => _engine;

    public ElectroCar(int numberOfDoors, int batteryCapacity, int power, int energyCons, int numberOfPlace)
        : base(numberOfPlace)
    {
        NumberOfDoors = numberOfDoors;
        AirConditioner = new AirConditioner();
        _battery = new Battery(batteryCapacity);
        _engine = new ElectricEngine(power, energyCons);
        TurnConditioner = false;
        _battery.OnStopForBattarySafe += AirConditioner.CheckForBatterySave;
    }

    public void TurnOnConditioner()
    {
        TurnConditioner = true;
    }

    public override void Move(int distance)
    {

        if (Engine.Speed <= 0 || EnergySourse.CurrentValueOfField <= 0)
        {
            Console.WriteLine($"{typeof(ElectroCar)} стоит на месте");
            return;
        }
        var requiredFuelCons = Engine.CalculateValueOfConsField(distance);
        double traveledDistance = _engine.GetMaxDistance(distance, _battery.CurrentValueOfField);
        EnergySourse.DecreaseFuel(requiredFuelCons);

        if (EnergySourse.CurrentValueOfField >= requiredFuelCons)
        {
            Console.WriteLine($"{typeof(ElectroCar)} проехал {traveledDistance} км со средней скоростью {Engine.Speed} км/ч.");
            _battery.CheckAmountOfEnergy();
        }
        else
        {
            Console.WriteLine($"{typeof(ElectroCar)} проехал {traveledDistance} км со средней скоростью {Engine.Speed} км/ч и остановился, так как потратил все топливо.");
            EnergySourse.SetZeroFuel(); // все топливо израсходовано
        }
        //AirConditioner.CheckForBatterySave();

        //if (_battery.EmergencyStopForBatterySave)
        //{
        //    _engine.DropPower(EnergySourse.CurrentValueOfField, EnergySourse.MaxValue);
        //}
    }

    public override string ToString()
    {
        return $"Тип транспорта - {typeof(ElectroCar)}, максимальная скорость - {Engine.MaxSpeed}, количество дверей - {NumberOfDoors}, Емкость батареи - {EnergySourse.MaxValue} кВт*ч";
    }
}