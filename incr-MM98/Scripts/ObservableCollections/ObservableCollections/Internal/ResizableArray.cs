using System;
using System.Buffers;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace ObservableCollections.Internal
{
	internal struct ResizableArray<T> : IDisposable
	{
		private T[]? array;

		private int count;

		public ReadOnlySpan<T> Span => array.AsSpan(0, count);

		public ResizableArray(int initialCapacity)
		{
			array = ArrayPool<T>.Shared.Rent(initialCapacity);
			count = 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Add(T item)
		{
			if (array == null)
			{
				Throw();
			}
			if (array.Length == count)
			{
				EnsureCapacity();
			}
			array[count++] = item;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void EnsureCapacity()
		{
			T[] array = this.array;
			T[] destinationArray = ArrayPool<T>.Shared.Rent(array.Length * 2);
			Array.Copy(array, destinationArray, array.Length);
			ArrayPool<T>.Shared.Return(array, RuntimeHelpersEx.IsReferenceOrContainsReferences<T>());
			this.array = destinationArray;
		}

		public void Dispose()
		{
			if (array != null)
			{
				ArrayPool<T>.Shared.Return(array, RuntimeHelpersEx.IsReferenceOrContainsReferences<T>());
				array = null;
			}
		}

		[DoesNotReturn]
		private void Throw()
		{
			throw new ObjectDisposedException("ResizableArray");
		}
	}
}
