using Unity.Burst;

namespace Simulation
{
	public class AntennaInput : VoltageInput
	{
		private double fmphase;

		public override void MatrixInitialise()
		{
		}

		[BurstCompile(FloatMode = FloatMode.Fast)]
		public override void Step()
		{
		}

		protected override double GetVoltage()
		{
			return 0.0;
		}
	}
}
