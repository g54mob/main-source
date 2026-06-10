using System;
using System.Runtime.CompilerServices;

namespace ICSharpCode.SharpZipLib.Checksum
{
	public sealed class BZip2Crc : IChecksum
	{
		private const uint crcInit = uint.MaxValue;

		private static readonly uint[] crcTable;

		private uint checkValue;

		public long Value => 0L;

		public void Reset()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Update(int bval)
		{
		}

		public void Update(byte[] buffer)
		{
		}

		public void Update(ArraySegment<byte> segment)
		{
		}

		private void Update(byte[] data, int offset, int count)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void SlowUpdateLoop(byte[] data, int offset, int end)
		{
		}
	}
}
