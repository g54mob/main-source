using System;
using Unity.Burst;

namespace Simulation
{
	public class OpAmp : CircuitModel
	{
		private Random random;

		private double lastvd;

		private double gain;

		public Circuit.Lead leadNeg => null;

		public Circuit.Lead leadPos => null;

		public Circuit.Lead leadOut => null;

		public double maxOut { get; set; }

		public double minOut { get; set; }

		public OpAmp()
		{
		}

		public OpAmp(bool lowGain)
		{
		}

		public override bool IsNonLinear()
		{
			return false;
		}

		public override int GetLeadCount()
		{
			return 0;
		}

		public override int GetVoltageSourceCount()
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

		private int getRand(int x)
		{
			return 0;
		}

		public override bool leadsAreConnected(int n1, int n2)
		{
			return false;
		}

		public override bool IsLeadGround(int n1)
		{
			return false;
		}

		public override double GetVoltageDelta()
		{
			return 0.0;
		}
	}
}
