using Unity.Burst;

namespace Simulation
{
	public abstract class LogicGate : CircuitModel
	{
		protected int _inputCount;

		public Circuit.Lead leadOut => null;

		public int inputCount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public LogicGate()
		{
		}

		public abstract bool calcFunction();

		public virtual bool isInverting()
		{
			return false;
		}

		public override int GetLeadCount()
		{
			return 0;
		}

		public override int GetVoltageSourceCount()
		{
			return 0;
		}

		public override void MatrixInitialise()
		{
		}

		public bool getInput(int x)
		{
			return false;
		}

		[BurstCompile(FloatMode = FloatMode.Fast)]
		public override void Step()
		{
		}

		public override bool leadsAreConnected(int n1, int n2)
		{
			return false;
		}

		public override bool IsLeadGround(int n1)
		{
			return false;
		}
	}
}
