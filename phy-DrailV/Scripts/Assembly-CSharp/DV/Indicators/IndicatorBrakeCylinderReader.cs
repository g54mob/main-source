namespace DV.Indicators
{
	public class IndicatorBrakeCylinderReader : AIndicatorBrakePressureReader
	{
		public override float GetPressureValue => train.brakeSystem.brakeCylinderPressure;
	}
}
