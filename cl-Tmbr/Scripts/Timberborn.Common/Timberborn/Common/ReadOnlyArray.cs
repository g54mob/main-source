using System;

namespace Timberborn.Common
{
	public readonly struct ReadOnlyArray<T>
	{
		private readonly T[] _array;

		public ReadOnlySpan<T> AsSpan => _array.AsSpan();

		public ref readonly T this[int index] => ref _array[index];

		public ReadOnlyArray(T[] array)
		{
			_array = array;
		}
	}
}
