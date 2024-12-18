public class ElectricEngine : EngineBase
{
    public ElectricEngine(int power, int energyCons) : base(power, energyCons) { }
    public void DropPower(int currentValueOfField, int maxValue) // метод который понижает мощность электродвигателя на 30% из-за низкого заряда батареи ( меньше 20% )
    {
        if (currentValueOfField * 100 / maxValue < 20)
        {
            Power *= 0.7d;
            Speed *= 0.7d;
        }
    }

}