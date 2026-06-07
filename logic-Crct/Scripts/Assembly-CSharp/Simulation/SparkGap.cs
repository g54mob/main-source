using Unity.Burst;

namespace Simulation
{
	public class SparkGap : CircuitModel
	{
		private double resistance;

		private bool state;

		public Circuit.Lead leadIn => null;

		public Circuit.Lead leadOut => null;

		public double onresistance { get; set; }

		public double offresistance { get; set; }

		public double breakdown { get; set; }

		public double holdcurrent { get; set; }

		public override bool IsNonLinear()
		{
			return false;
		}

		public override void CalculateCurrent()
		{
		}

		public override void Reset()
		{
		}

		public override void InitStep()
		{
		}

		[BurstCompile(FloatMode = FloatMode.Fast)]
		public override void Step()
		{
		}

		public override void MatrixInitialise()
		{
		}
	}
}
