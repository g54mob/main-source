using System;

namespace Coherence.Common.Pooling
{
	internal class Buffer<T>
	{
		public T[] Data { get; private set; }

		public int Length { get; private set; }

		public int Capacity => 0;

		public Buffer(int capacity)
		{
		}

		public Buffer(ReadOnlySpan<T> data)
		{
		}

		public ReadOnlySpan<T> AsSpan()
		{
			return default(ReadOnlySpan<T>);
		}

		public void Accomodate(ReadOnlySpan<T> data)
		{
		}
	}
}
