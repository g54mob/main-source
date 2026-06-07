namespace Simulation
{
	public class SiliconRectifierModel : CircuitModel
	{
		private static readonly int anode;

		private static readonly int cnode;

		private static readonly int gnode;

		private static readonly int inode;

		public double GateCathodeResistance;

		public double AResistance;

		public double TriggerCurrent;

		public double HoldingCurrent;

		private Diode _diode;

		private double _ia;

		private double _ic;

		private double _ig;

		private double _lastVac;

		private double _lastVag;

		private ConductanceStamp_t _conductanceStamp_anode_inode;

		private double _r;

		public override string GetName()
		{
			return null;
		}

		public override bool IsNonLinear()
		{
			return false;
		}

		public override int GetLeadCount()
		{
			return 0;
		}

		public override void Reset()
		{
		}

		public override void MatrixInitialise()
		{
		}

		public override void DefineMatrixUnknowns()
		{
		}

		public override void GetMatrixPointers()
		{
		}

		public override void Step()
		{
		}

		public override void CalculateCurrent()
		{
		}

		public override void CheckFail()
		{
		}
	}
}
