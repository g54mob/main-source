using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;

namespace TripledoseLibs.Collections
{
	public struct NativeHashSetWrapper<T> : @if<T>, IDisposable, IEnumerable<T>, IEnumerable where T : struct, IEquatable<T>
	{
		public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
		{
			private NativeHashSet<T>.Enumerator _enumerator;

			public readonly T Current => default(T);

			readonly object IEnumerator.Current => null;

			internal Enumerator(NativeHashSet<T>.Enumerator enumerator)
			{
				_enumerator = default(NativeHashSet<T>.Enumerator);
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

		private int m_cachedCount;

		private bool m_isCountDirty;

		public int wxy => 0;

		public int wxz
		{
			readonly get
			{
				return 0;
			}
			set
			{
			}
		}

		public NativeHashSetWrapper(int capacity, Allocator allocator)
		{
			m_hashSet = default(NativeHashSet<T>);
			m_cachedCount = 0;
			m_isCountDirty = false;
		}

		public bool enw(T a)
		{
			return false;
		}

		public bool env(T a)
		{
			return false;
		}

		public bool enx(T a)
		{
			return false;
		}

		public void eny()
		{
		}

		public readonly NativeArray<T> eoi(Allocator a)
		{
			return default(NativeArray<T>);
		}

		public void eoj(NativeArray<T> a)
		{
		}

		public void eok(NativeArray<T> a)
		{
		}

		public void eol(NativeArray<T> a)
		{
		}

		public void Dispose()
		{
		}

		public readonly Enumerator GetEnumerator()
		{
			return default(Enumerator);
		}

		private readonly IEnumerator<T> eom()
		{
			return null;
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in eom
			return this.eom();
		}

		private readonly IEnumerator eon()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in eon
			return this.eon();
		}

		public readonly NativeHashSet<T> eoo()
		{
			return default(NativeHashSet<T>);
		}
	}
}
