using System.IO;

namespace SevenZip.Compression.RangeCoder
{
	internal class Decoder
	{
		public const uint kTopValue = 16777216u;

		public uint Range;

		public uint Code;

		public Stream Stream;

		public void Init(Stream stream)
		{
		}

		public void ReleaseStream()
		{
		}

		public void CloseStream()
		{
		}

		public void Normalize()
		{
		}

		public void Normalize2()
		{
		}

		public uint GetThreshold(uint total)
		{
			return 0u;
		}

		public void Decode(uint start, uint size, uint total)
		{
		}

		public uint DecodeDirectBits(int numTotalBits)
		{
			return 0u;
		}

		public uint DecodeBit(uint size0, int numTotalBits)
		{
			return 0u;
		}
	}
}
