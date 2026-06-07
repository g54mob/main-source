namespace Simulation
{
	public class _74HC245Element : _74HCBase
	{
		private int DIR;

		private int A1;

		private int A2;

		private int A3;

		private int A4;

		private int A5;

		private int A6;

		private int A7;

		private int A8;

		private int B8;

		private int B7;

		private int B6;

		private int B5;

		private int B4;

		private int B3;

		private int B2;

		private int B1;

		private int EN;

		private Pin[] outputPins;

		private ConductanceStamp_t[] _conductanceStamps_On;

		private ConductanceStamp_t[] _conductanceStamps_Off;

		private double _r;

		private const double HIGH_IMPEDANCE = 6250000.0;

		public override string GetName()
		{
			return null;
		}

		public override void SetupPins()
		{
		}

		public override int GetLeadCount()
		{
			return 0;
		}

		public override void MatrixInitialise()
		{
		}

		public override void InitStep()
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

		public override void ExecuteLogic()
		{
		}
	}
}
