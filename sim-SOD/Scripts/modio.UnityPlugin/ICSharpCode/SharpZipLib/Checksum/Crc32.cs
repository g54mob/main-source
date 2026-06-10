using System;
using System.Runtime.CompilerServices;

namespace ICSharpCode.SharpZipLib.Checksum
{
	public sealed class Crc32 : IChecksum
	{
		private static readonly uint crcInit;

		private static readonly uint crcXor;

		private static readonly uint[] crcTable;

		private uint checkValue;

		public long Value => 0L;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static uint ComputeCrc32(uint oldCrc, byte bval)
		{
			return 0u;
		}

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
