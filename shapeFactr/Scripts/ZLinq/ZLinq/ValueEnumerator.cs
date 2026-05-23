using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq
{
	[StructLayout((LayoutKind)3)]
	public struct ValueEnumerator<TEnumerator, T> : IDisposable where TEnumerator : struct, IValueEnumerator<T>
	{
		private TEnumerator enumerator;

		private T current;

		public T Current
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return default(T);
			}
		}

		public ValueEnumerator(TEnumerator enumerator)
		{
			this.enumerator = default(TEnumerator);
			current = default(T);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool MoveNext()
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Dispose()
		{
		}
	}
}
