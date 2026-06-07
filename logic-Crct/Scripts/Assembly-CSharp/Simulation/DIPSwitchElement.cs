namespace Simulation
{
	public class DIPSwitchElement : CircuitModel
	{
		private struct Pair
		{
			public int x;

			public int y;
		}

		public bool[] Positions;

		private DipswitchSize _switchSize;

		private Pair[] _pairs;

		private int _pairCount;

		private ConductanceStamp_t[] _conductanceStamps;

		public DIPSwitchElement(DipswitchSize size, BaseComponent comp)
		{
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

		public override void GetMatrixPointers()
		{
		}

		public override void Step()
		{
		}
	}
}
