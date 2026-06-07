using Unity.Burst;

namespace Simulation
{
	public class FMSource : CircuitModel
	{
		private double freqTimeZero;

		private double lasttime;

		private double funcx;

		public Circuit.Lead leadOut => null;

		public double carrierfreq { get; set; }

		public double signalfreq { get; set; }

		public double maxVoltage { get; set; }

		public double deviation { get; set; }

		public override void Reset()
		{
		}

		public override int GetLeadCount()
		{
			return 0;
		}

		public override void MatrixInitialise()
		{
		}

		[BurstCompile(FloatMode = FloatMode.Fast)]
		public override void Step()
		{
		}

		private double getVoltage(double time)
		{
			return 0.0;
		}

		public override double GetVoltageDelta()
		{
			return 0.0;
		}

		public override bool IsLeadGround(int n1)
		{
			return false;
		}

		public override int GetVoltageSourceCount()
		{
			return 0;
		}
	}
}
