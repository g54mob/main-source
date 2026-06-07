using System.IO;

namespace SevenZip.Compression.RangeCoder
{
	internal class Encoder
	{
		public const uint kTopValue = 16777216u;

		private Stream Stream;

		public ulong Low;

		public uint Range;

		private uint _cacheSize;

		private byte _cache;

		private long StartPosition;

		public void SetStream(Stream stream)
		{
		}

		public void ReleaseStream()
		{
		}

		public void Init()
		{
		}

		public void FlushData()
		{
		}

		public void FlushStream()
		{
		}

		public void CloseStream()
		{
		}

		public void Encode(uint start, uint size, uint total)
		{
		}

		public void ShiftLow()
		{
		}

		public void EncodeDirectBits(uint v, int numTotalBits)
		{
		}

		public void EncodeBit(uint size0, int numTotalBits, uint symbol)
		{
		}

		public long GetProcessedSizeAdd()
		{
			return 0L;
		}
	}
}
