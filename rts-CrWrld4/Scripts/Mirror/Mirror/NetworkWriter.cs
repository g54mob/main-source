using System;
using System.Runtime.CompilerServices;

namespace Mirror
{
	public class NetworkWriter
	{
		public const int MaxStringLength = 32768;

		private byte[] buffer;

		private int position;

		private int length;

		public int Length => 0;

		public int Position
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public void Reset()
		{
		}

		public void SetLength(int newLength)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void EnsureLength(int value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void EnsureCapacity(int value)
		{
		}

		public byte[] ToArray()
		{
			return null;
		}

		public ArraySegment<byte> ToArraySegment()
		{
			return default(ArraySegment<byte>);
		}

		public void WriteByte(byte value)
		{
		}

		public void WriteBytes(byte[] buffer, int offset, int count)
		{
		}

		public void Write<T>(T value)
		{
		}
	}
}
