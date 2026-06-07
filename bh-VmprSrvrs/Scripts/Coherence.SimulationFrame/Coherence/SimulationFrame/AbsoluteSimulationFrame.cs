namespace Coherence.SimulationFrame
{
	public struct AbsoluteSimulationFrame
	{
		public const long Invalid = -1L;

		public long Frame;

		public static AbsoluteSimulationFrame operator ++(AbsoluteSimulationFrame frame)
		{
			return default(AbsoluteSimulationFrame);
		}

		public static implicit operator long(AbsoluteSimulationFrame frame)
		{
			return 0L;
		}

		public static implicit operator AbsoluteSimulationFrame(long frame)
		{
			return default(AbsoluteSimulationFrame);
		}

		public bool Equals(AbsoluteSimulationFrame other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
