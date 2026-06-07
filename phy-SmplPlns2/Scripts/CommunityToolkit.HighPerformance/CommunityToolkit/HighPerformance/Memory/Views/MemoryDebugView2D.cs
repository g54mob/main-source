using System.Diagnostics;

namespace CommunityToolkit.HighPerformance.Memory.Views
{
	internal sealed class MemoryDebugView2D<T>
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
		public T[,]? Items { get; }

		public MemoryDebugView2D(Memory2D<T> memory)
		{
			Items = memory.ToArray();
		}

		public MemoryDebugView2D(ReadOnlyMemory2D<T> memory)
		{
			Items = memory.ToArray();
		}

		public MemoryDebugView2D(Span2D<T> span)
		{
			Items = span.ToArray();
		}

		public MemoryDebugView2D(ReadOnlySpan2D<T> span)
		{
			Items = span.ToArray();
		}
	}
}
