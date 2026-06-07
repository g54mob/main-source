using FishNet.Serializing;

namespace FishNet.Managing.Timing
{
	public static class PreciseTickSerializer
	{
		public static void WritePreciseTick(this Writer writer, PreciseTick value)
		{
		}

		public static PreciseTick ReadPreciseTick(this Reader reader)
		{
			return default(PreciseTick);
		}
	}
}
