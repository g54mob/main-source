namespace Simulation
{
	public class TactileSwitch : CircuitModel
	{
		protected int positions;

		protected int position;

		private ConductanceStamp_t _conductanceStamp_0_2;

		private ConductanceStamp_t _conductanceStamp_1_3;

		public override int GetLeadCount()
		{
			return 0;
		}

		public void SetPosition(int pos)
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

		public override void RemovePreprocessValues()
		{
		}

		public override void Step()
		{
		}
	}
}
