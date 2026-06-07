using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZLinq
{
	[StructLayout(LayoutKind.Auto)]
	public struct ValueEnumerator<TEnumerator, T> : IDisposable where TEnumerator : struct, IValueEnumerator<T>
	{
		private TEnumerator enumerator;

		private T current;

		public T Current
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return current;
			}
		}

		public ValueEnumerator(TEnumerator enumerator)
		{
			this.enumerator = enumerator;
			current = default(T);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool MoveNext()
		{
			if (enumerator.TryGetNext(out current))
			{
				return true;
			}
			current = default(T);
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Dispose()
		{
			enumerator.Dispose();
		}
	}
}
