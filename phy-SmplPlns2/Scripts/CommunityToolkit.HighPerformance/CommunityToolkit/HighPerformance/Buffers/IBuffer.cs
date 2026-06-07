using System;
using System.Buffers;

namespace CommunityToolkit.HighPerformance.Buffers
{
	public interface IBuffer<T> : IBufferWriter<T>
	{
		ReadOnlyMemory<T> WrittenMemory { get; }

		ReadOnlySpan<T> WrittenSpan { get; }

		int WrittenCount { get; }

		int Capacity { get; }

		int FreeCapacity { get; }

		void Clear();
	}
}
