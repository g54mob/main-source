namespace Simulation
{
	public class DiodeElm : CircuitModel
	{
		public Diode diode;

		public double leakage;

		protected double _forwardDrop;

		protected double _zvoltage;

		protected double defaultdrop;

		public Circuit.Lead leadIn => null;

		public Circuit.Lead leadOut => null;

		public double forwardDrop
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public double zvoltage
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public override bool IsNonLinear()
		{
			return false;
		}

		public virtual void setup()
		{
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

		public override string GetName()
		{
			return null;
		}

		public override bool FailCondition()
		{
			return false;
		}

		public override void CalculateCurrent()
		{
		}
	}
}
