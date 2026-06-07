using System.IO;

namespace Pathfinding.Ionic.BZip2
{
	internal class BitWriter
	{
		private uint accumulator;

		private int nAccumulatedBits;

		private Stream output;

		private int totalBytesWrittenOut;

		public byte RemainingBits => 0;

		public int NumRemainingBits => 0;

		public int TotalBytesWrittenOut => 0;

		public BitWriter(Stream s)
		{
		}

		public void Reset()
		{
		}

		public void WriteBits(int nbits, uint value)
		{
		}

		public void WriteByte(byte b)
		{
		}

		public void WriteInt(uint u)
		{
		}

		public void Flush()
		{
		}

		public void FinishAndPad()
		{
		}
	}
}
