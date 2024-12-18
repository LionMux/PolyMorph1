﻿public class Battery : EnergySourse
{
    //public bool EmergencyStopForBatterySave { get; private set; } = false;

    public const int SaveBateryModeValue = 20;

    public Battery(int maxValue) : base(maxValue) { } // maxValue - величина измеряющаяся в кВт*ч, максимальный объем батареи

    public delegate void StopForBattarySafe();

    public event StopForBattarySafe? OnStopForBattarySafe;

    // ValueOfField - величина измеряющаяся в кВт*ч, количество энергии за один заряд
    protected override void OnOverloaded(int valueOfField)
    {
        Console.WriteLine($"Батарея заряжена на 100% "); ;
    }

    protected override void OnCharging(int valueOfField)
    {
        Console.WriteLine($"Текущее колличество заряда батареи {CurrentValueOfFieldP} %");
        base.OnCharging(valueOfField);
    }
    public override void CheckAmountOfEnergy()
    {
        Console.WriteLine($"Оставшийся заряд батареи {CurrentValueOfFieldP} % ");
        OnCurrentValueOfFieldChanged();
    }

    protected override void OnCurrentValueOfFieldChanged()
    {
        if (CurrentValueOfFieldP < SaveBateryModeValue)
        {
            //EmergencyStopForBatterySave = true;
            OnStopForBattarySafe?.Invoke();
        }
    }
}