using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace ObservableCollections.Internal
{
	internal ref struct FixedArray<T>
	{
		public readonly Span<T> Span;

		private T[]? array;

		public FixedArray(int size)
		{
			array = ArrayPool<T>.Shared.Rent(size);
			Span = array.AsSpan(0, size);
		}

		public void Dispose()
		{
			if (array != null)
			{
				ArrayPool<T>.Shared.Return(array, RuntimeHelpersEx.IsReferenceOrContainsReferences<T>());
			}
		}
	}
}
