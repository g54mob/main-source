using System.Runtime.CompilerServices;

namespace Simulation
{
	public class MOSFET : CircuitModel
	{
		private const int SOURCE = 1;

		private const int DRAIN = 2;

		private const int GATE = 0;

		private double _threshold;

		public bool IsPnp;

		private double _lastV1;

		private double _lastV2;

		private double _ids;

		private int _mode;

		private double _gm;

		private double[] _vs;

		public double Threshold
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public MOSFET()
		{
		}

		public MOSFET(bool isPNP)
		{
		}

		public virtual double GetDefaultThreshold()
		{
			return 0.0;
		}

		public virtual double GetBeta()
		{
			return 0.0;
		}

		public override string GetName()
		{
			return null;
		}

		public override bool IsNonLinear()
		{
			return false;
		}

		public override void Reset()
		{
		}

		public override double getCurrent()
		{
			return 0.0;
		}

		public override int GetLeadCount()
		{
			return 0;
		}

		public override void MatrixInitialise()
		{
		}

		public override void DefineMatrixUnknowns()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override void Step()
		{
		}

		public string getState()
		{
			return null;
		}

		public override double GetVoltageDelta()
		{
			return 0.0;
		}

		public override bool leadsAreConnected(int n1, int n2)
		{
			return false;
		}
	}
}
