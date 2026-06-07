using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TripledoseLibs.Collections;

namespace Effectors.ReceiveMethods.Index
{
	public struct ReadOnlyFastHashSet<T> : IEnumerable<T>, IEnumerable where T : struct, IEquatable<T>
	{
		public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
		{
			private FastHashSet<T>.Enumerator m_enumerator;

			public T Current
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get
				{
					return default(T);
				}
			}

			object IEnumerator.Current => null;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal Enumerator(FastHashSet<T> hashSet)
			{
				m_enumerator = default(FastHashSet<T>.Enumerator);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool MoveNext()
			{
				return false;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Reset()
			{
			}

			public void Dispose()
			{
			}
		}

		private FastHashSet<T> m_hashSet;

		public int xnx => 0;

		public int xny => 0;

		public ReadOnlyFastHashSet(FastHashSet<T> hashSet)
		{
			m_hashSet = default(FastHashSet<T>);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool jbv(T a)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Enumerator GetEnumerator()
		{
			return default(Enumerator);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private IEnumerator<T> jbw()
		{
			return null;
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in jbw
			return this.jbw();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private IEnumerator jbx()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in jbx
			return this.jbx();
		}
	}
}
