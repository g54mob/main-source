namespace Coherence.Common
{
	public struct Ping
	{
		public int AverageLatencyMs;

		public bool IsStable;

		public int LatestLatencyMs;

		public int AverageRoundTripMs => 0;

		public static implicit operator int(Ping ping)
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
