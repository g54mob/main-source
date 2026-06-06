using System;
using System.Buffers;

namespace ObservableCollections.Internal
{
	internal ref struct FixedBoolArray
	{
		public const int StackallocSize = 128;

		public readonly Span<bool> Span;

		private bool[]? array;

		public FixedBoolArray(Span<bool> scratchBuffer, int capacity)
		{
			array = null;
			if (scratchBuffer.Length == 0)
			{
				array = ArrayPool<bool>.Shared.Rent(capacity);
				Span = array.AsSpan(0, capacity);
			}
			else
			{
				Span = scratchBuffer;
			}
		}

		public void Dispose()
		{
			if (array != null)
			{
				ArrayPool<bool>.Shared.Return(array);
			}
		}
	}
}
