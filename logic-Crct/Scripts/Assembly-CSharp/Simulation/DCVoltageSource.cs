namespace Simulation
{
	public class DCVoltageSource : Voltage
	{
		public Circuit.Lead leadPos => null;

		public Circuit.Lead leadNeg => null;

		public DCVoltageSource()
			: base(default(WaveType))
		{
		}
	}
}
