namespace Simulation
{
	public class ACVoltageSource : Voltage
	{
		public Circuit.Lead leadPos => null;

		public Circuit.Lead leadNeg => null;

		public ACVoltageSource()
			: base(default(WaveType))
		{
		}
	}
}
