using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;

namespace TripledoseLibs.Collections
{
	public struct NativeHashMapWrapper<TKey, TValue> : hw<TKey, TValue>, IDisposable, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable where TKey : struct, IEquatable<TKey> where TValue : struct
	{
		public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable
		{
			private NativeHashMap<TKey, TValue>.Enumerator m_enumerator;

			public KeyValuePair<TKey, TValue> Current
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get
				{
					return default(KeyValuePair<TKey, TValue>);
				}
			}

			object IEnumerator.Current => null;

			internal Enumerator(NativeHashMap<TKey, TValue>.Enumerator enumerator)
			{
				m_enumerator = default(NativeHashMap<TKey, TValue>.Enumerator);
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

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Dispose()
			{
			}
		}

		private NativeHashMap<TKey, TValue> m_hashMap;

		private int m_cachedCount;

		private bool m_isCountDirty;

		public readonly bool wxj => false;

		public readonly int wxg
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return 0;
			}
		}

		public int wxh
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				return 0;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
			}
		}

		public readonly bool wxk => false;

		public TValue this[TKey key]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
				return default(TValue);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
			}
		}

		public NativeHashMapWrapper(int capacity, Allocator allocator)
		{
			m_hashMap = default(NativeHashMap<TKey, TValue>);
			m_cachedCount = 0;
			m_isCountDirty = false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool elr(TKey a, TValue b)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool els(TKey a)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool elt(TKey a, out TValue b)
		{
			b = default(TValue);
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool elu(TKey a)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void elv()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public NativeArray<TKey> emc(Allocator a)
		{
			return default(NativeArray<TKey>);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public NativeArray<TValue> emd(Allocator a)
		{
			return default(NativeArray<TValue>);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public NativeKeyValueArrays<TKey, TValue> eme(Allocator a)
		{
			return default(NativeKeyValueArrays<TKey, TValue>);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Dispose()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly NativeHashMap<TKey, TValue> emf()
		{
			return default(NativeHashMap<TKey, TValue>);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Enumerator GetEnumerator()
		{
			return default(Enumerator);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private IEnumerator<KeyValuePair<TKey, TValue>> emg()
		{
			return null;
		}

		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in emg
			return this.emg();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private IEnumerator emh()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in emh
			return this.emh();
		}
	}
}
