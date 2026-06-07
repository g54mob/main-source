namespace Simulation
{
	public class VoltageInput : Voltage
	{
		public float[] SampleBuffer;

		public int SampleRate;

		private int _readPosition;

		private int _rightSide;

		public VoltageInput()
			: base(default(WaveType))
		{
		}

		public VoltageInput(WaveType wf)
			: base(default(WaveType))
		{
		}

		public override int GetLeadCount()
		{
			return 0;
		}

		public override double GetVoltageDelta()
		{
			return 0.0;
		}

		public override bool IsLeadGround(int n1)
		{
			return false;
		}

		public override void MatrixInitialise()
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
