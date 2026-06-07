namespace DV.Indicators
{
	public class IndicatorMainResReader : AIndicatorBrakePressureReader
	{
		public override float GetPressureValue => train.brakeSystem.mainReservoirPressure;
	}
}
