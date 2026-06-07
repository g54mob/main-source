namespace Simulation
{
	public class Voltage : CircuitModel
	{
		public enum WaveType
		{
			DC = 0,
			AC = 1,
			SQUARE = 2,
			TRIANGLE = 3,
			SAWTOOTH = 4,
			PULSE = 5,
			VAR = 6
		}

		private WaveType _waveform;

		private double _frequency;

		private double _phaseShift;

		private double _dutyCycle;

		protected double freqTimeZero;

		public WaveType waveform
		{
			get
			{
				return default(WaveType);
			}
			set
			{
			}
		}

		public double frequency { get; set; }

		public double phaseShift
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public double dutyCycle
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public double maxVoltage { get; set; }

		public double bias { get; set; }

		public Voltage(WaveType wf)
		{
		}

		public override void Reset()
		{
		}

		protected void setFrequency(double newFreq, double timeStep, double time)
		{
		}

		public double triangleFunc(double x)
		{
			return 0.0;
		}

		public override void MatrixInitialise()
		{
		}

		public override void Step()
		{
		}

		protected virtual double GetVoltage()
		{
			return 0.0;
		}

		public override int GetVoltageSourceCount()
		{
			return 0;
		}

		public override double GetVoltageDelta()
		{
			return 0.0;
		}
	}
}
