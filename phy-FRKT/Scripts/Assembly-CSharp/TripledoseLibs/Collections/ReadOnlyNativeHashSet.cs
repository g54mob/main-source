using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;

namespace TripledoseLibs.Collections
{
	public struct ReadOnlyNativeHashSet<T> : IEnumerable<T>, IEnumerable where T : struct, IEquatable<T>
	{
		public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
		{
			private NativeHashSet<T>.Enumerator m_enumerator;

			public T Current => default(T);

			object IEnumerator.Current => null;

			internal Enumerator(NativeHashSet<T> hashSet)
			{
				m_enumerator = default(NativeHashSet<T>.Enumerator);
			}

			public bool MoveNext()
			{
				return false;
			}

			public void Reset()
			{
			}

			public void Dispose()
			{
			}
		}

		private NativeHashSet<T> m_hashSet;

		public int wyi => 0;

		public int wyj => 0;

		public bool wyk => false;

		public ReadOnlyNativeHashSet(NativeHashSet<T> hashSet)
		{
			m_hashSet = default(NativeHashSet<T>);
		}

		public bool epi(T a)
		{
			return false;
		}

		public NativeArray<T> epj(Allocator a)
		{
			return default(NativeArray<T>);
		}

		public Enumerator GetEnumerator()
		{
			return default(Enumerator);
		}

		private IEnumerator<T> epk()
		{
			return null;
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in epk
			return this.epk();
		}

		private IEnumerator epl()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in epl
			return this.epl();
		}
	}
}
