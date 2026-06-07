using System.Diagnostics;

namespace CommunityToolkit.HighPerformance.Buffers.Views
{
	internal sealed class MemoryDebugView<T>
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
		public T[]? Items { get; }

		public MemoryDebugView(ArrayPoolBufferWriter<T>? arrayPoolBufferWriter)
		{
			Items = arrayPoolBufferWriter?.WrittenSpan.ToArray();
		}

		public MemoryDebugView(MemoryBufferWriter<T>? memoryBufferWriter)
		{
			Items = memoryBufferWriter?.WrittenSpan.ToArray();
		}

		public MemoryDebugView(MemoryOwner<T>? memoryOwner)
		{
			Items = memoryOwner?.Span.ToArray();
		}

		public MemoryDebugView(SpanOwner<T> spanOwner)
		{
			Items = spanOwner.Span.ToArray();
		}
	}
}
