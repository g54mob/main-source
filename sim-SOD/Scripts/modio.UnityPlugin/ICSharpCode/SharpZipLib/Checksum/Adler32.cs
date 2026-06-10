using System;

namespace ICSharpCode.SharpZipLib.Checksum
{
	public sealed class Adler32 : IChecksum
	{
		private static readonly uint BASE;

		private uint checkValue;

		public long Value => 0L;

		public void Reset()
		{
		}

		public void Update(int bval)
		{
		}

		public void Update(byte[] buffer)
		{
		}

		public void Update(ArraySegment<byte> segment)
		{
		}
	}
}
