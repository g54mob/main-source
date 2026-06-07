namespace Coherence.Tend.Models
{
	public struct ReceiveMask
	{
		public const int Range = 32;

		private const int LastRangeIndex = 31;

		public uint Bits { get; }

		public ReceiveMask(uint mask)
		{
			Bits = 0u;
		}

		public override string ToString()
		{
			return null;
		}

		private static string GetIntBinaryString(uint n)
		{
			return null;
		}
	}
}
