namespace Coherence.Tend.Models
{
	public struct MutableReceiveMask
	{
		private uint mask;

		private int validBitCount;

		public MutableReceiveMask(ReceiveMask receiveBits, int validBits)
		{
			mask = 0u;
			validBitCount = 0;
		}

		public Bit ReadNextBit()
		{
			return default(Bit);
		}
	}
}
