namespace Simulation
{
	public class LM555Element : Chip
	{
		private const int TRIG = 1;

		private const int OUT = 2;

		private const int RST = 3;

		private const int CTL = 4;

		private const int THRES = 5;

		private const int DIS = 6;

		private const double RESET_VL = 0.5;

		private bool _setOut;

		private bool _output;

		private double _voltageDrop;

		private ConductanceStamp_t _conductanceStamp_DIS_GND;

		private ConductanceStamp_t _conductanceStamp_Vcc_OUT;

		private ConductanceStamp_t _conductanceStamp_GND_OUT;

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

		public override void SetupPins()
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

		public override void InitStep()
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
