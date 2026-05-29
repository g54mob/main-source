using System;

namespace ExitGames.Client.Photon
{
	public class ByteArraySlice : IDisposable
	{
		public byte[] Buffer;

		public int Offset;

		public int Count;

		private readonly ByteArraySlicePool returnPool;

		private readonly int stackIndex;

		internal ByteArraySlice(ByteArraySlicePool returnPool, int stackIndex)
		{
		}

		public ByteArraySlice(byte[] buffer, int offset = 0, int count = 0)
		{
		}

		public ByteArraySlice()
		{
		}

		public void Dispose()
		{
		}

		public bool Release()
		{
			return false;
		}

		public void Reset()
		{
		}
	}
}
