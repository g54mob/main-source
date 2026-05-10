using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;

namespace TripledoseLibs.Collections
{
	public struct ReadOnlyNativeList<T> : IEnumerable<T>, IEnumerable where T : struct, IEquatable<T>
	{
		public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
		{
			private NativeArray<T> m_array;

			private int m_index;

			public T Current => default(T);

			object IEnumerator.Current => null;

			internal Enumerator(NativeList<T> list)
			{
				m_array = default(NativeArray<T>);
				m_index = 0;
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

		private NativeList<T> m_list;

		public int wym => 0;

		public int wyn => 0;

		public bool wyo => false;

		public bool wyp => false;

		public T this[int index] => default(T);

		public ReadOnlyNativeList(NativeList<T> list)
		{
			m_list = default(NativeList<T>);
		}

		public bool epr(T a)
		{
			return false;
		}

		public int eps(T a)
		{
			return 0;
		}

		public NativeArray<T> ept()
		{
			return default(NativeArray<T>);
		}

		public Enumerator GetEnumerator()
		{
			return default(Enumerator);
		}

		private IEnumerator<T> epu()
		{
			return null;
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in epu
			return this.epu();
		}

		private IEnumerator epv()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in epv
			return this.epv();
		}
	}
}
