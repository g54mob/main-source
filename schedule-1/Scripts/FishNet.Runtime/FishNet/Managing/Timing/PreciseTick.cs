namespace FishNet.Managing.Timing
{
	public struct PreciseTick
	{
		public uint Tick;

		public double Percent;

		public PreciseTick(uint tick, double percent)
		{
			Tick = 0u;
			Percent = 0.0;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
