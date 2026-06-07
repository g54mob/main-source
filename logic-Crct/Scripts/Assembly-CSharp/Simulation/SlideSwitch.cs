namespace Simulation
{
	public class SlideSwitch : CircuitModel
	{
		protected int positions;

		protected int position;

		private ConductanceStamp_t _conductanceStamp_0_1;

		private ConductanceStamp_t _conductanceStamp_0_2;

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

		public void SetPosition(int pos)
		{
		}
	}
}
