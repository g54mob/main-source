using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;

namespace TripledoseLibs.Collections
{
	public struct ReadOnlyNativeHashMap<TKey, TValue> : IEnumerable<NativeKeyValuePair<TKey, TValue>>, IEnumerable where TKey : struct, IEquatable<TKey> where TValue : struct
	{
		private struct Enumerator : IEnumerator<NativeKeyValuePair<TKey, TValue>>, IEnumerator, IDisposable
		{
			private NativeHashMap<TKey, TValue>.Enumerator m_enumerator;

			public NativeKeyValuePair<TKey, TValue> Current => default(NativeKeyValuePair<TKey, TValue>);

			object IEnumerator.Current => null;

			internal Enumerator(NativeHashMap<TKey, TValue> hashMap)
			{
				m_enumerator = default(NativeHashMap<TKey, TValue>.Enumerator);
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

		private NativeHashMap<TKey, TValue> m_hashMap;

		public int wyc => 0;

		public int wyd => 0;

		public bool wye => false;

		public TValue this[TKey key] => default(TValue);

		public ReadOnlyNativeHashMap(NativeHashMap<TKey, TValue> hashMap)
		{
			m_hashMap = default(NativeHashMap<TKey, TValue>);
		}

		public bool eot(TKey a, out TValue b)
		{
			b = default(TValue);
			return false;
		}

		public bool eou(TKey a)
		{
			return false;
		}

		public NativeArray<TKey> eov(Allocator a)
		{
			return default(NativeArray<TKey>);
		}

		public NativeArray<TValue> eow(Allocator a)
		{
			return default(NativeArray<TValue>);
		}

		private Enumerator GetEnumerator()
		{
			return default(Enumerator);
		}

		private IEnumerator<NativeKeyValuePair<TKey, TValue>> eox()
		{
			return null;
		}

		IEnumerator<NativeKeyValuePair<TKey, TValue>> IEnumerable<NativeKeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in eox
			return this.eox();
		}

		private IEnumerator eoy()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in eoy
			return this.eoy();
		}
	}
}
