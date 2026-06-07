using Unity.Burst;

namespace Simulation
{
	public class Memristor : CircuitModel
	{
		private double _dopeWidth;

		private double _totalWidth;

		private double _mobility;

		private double resistance;

		public Circuit.Lead leadIn => null;

		public Circuit.Lead leadOut => null;

		public double r_on { get; set; }

		public double r_off { get; set; }

		public double dopeWidth
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public double totalWidth
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public double mobility
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

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

		public override void MatrixInitialise()
		{
		}

		[BurstCompile(FloatMode = FloatMode.Fast)]
		public override void Step()
		{
		}
	}
}
