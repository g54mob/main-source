namespace Simulation
{
	public class Potentiometer : CircuitModel
	{
		public double position;

		public double maxOhms;

		private double _r0;

		private double _r1;

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
	}
}
