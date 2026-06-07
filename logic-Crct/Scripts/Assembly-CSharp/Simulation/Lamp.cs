using Unity.Burst;

namespace Simulation
{
	public class Lamp : CircuitModel
	{
		public static readonly double roomTemp;

		private double resistance;

		public Circuit.Lead leadIn => null;

		public Circuit.Lead leadOut => null;

		public double temp { get; private set; }

		public double nom_pow { get; set; }

		public double nom_v { get; set; }

		public double warmTime { get; set; }

		public double coolTime { get; set; }

		public override void Reset()
		{
		}

		public override void CalculateCurrent()
		{
		}

		public override void MatrixInitialise()
		{
		}

		public override bool IsNonLinear()
		{
			return false;
		}

		public override void InitStep()
		{
		}

		[BurstCompile(FloatMode = FloatMode.Fast)]
		public override void Step()
		{
		}
	}
}
