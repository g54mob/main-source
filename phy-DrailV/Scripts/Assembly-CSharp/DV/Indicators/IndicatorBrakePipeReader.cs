namespace DV.Indicators
{
	public class IndicatorBrakePipeReader : AIndicatorBrakePressureReader
	{
		public override float GetPressureValue => train.brakeSystem.brakePipePressure;
	}
}
