using System;

namespace CommunityToolkit.HighPerformance.Buffers.Internals.Interfaces
{
	internal interface IMemoryManager
	{
		Memory<T> GetMemory<T>(int offset, int length) where T : unmanaged;
	}
}
