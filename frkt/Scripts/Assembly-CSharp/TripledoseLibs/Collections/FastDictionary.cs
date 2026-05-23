using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;

namespace TripledoseLibs.Collections
{
	public struct FastDictionary<TKey, TValue> : hw<TKey, TValue>, IDisposable, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable where TKey : struct, IEquatable<TKey> where TValue : unmanaged
	{
		private class ia : IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable
		{
			private unsafe Entry* qbu;

			private readonly int qbv;

			private int qbw;

			private KeyValuePair<TKey, TValue> qbx;

			public KeyValuePair<TKey, TValue> Current => default(KeyValuePair<TKey, TValue>);

			object IEnumerator.Current => null;

			internal ia(FastDictionary<TKey, TValue> a)
			{
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

		public struct Entry
		{
			public int hashCode;

			public byte dib;

			public TKey key;

			public TValue value;
		}

		public struct KeyCollection : IEnumerable<TKey>, IEnumerable
		{
			public struct KeyEnumerator
			{
				private unsafe readonly Entry* m_entries;

				private readonly int m_capacity;

				private int m_index;

				private TKey m_current;

				public TKey wxo => default(TKey);

				internal unsafe KeyEnumerator(FastDictionary<TKey, TValue> dict)
				{
					m_entries = null;
					m_capacity = 0;
					m_index = 0;
					m_current = default(TKey);
				}

				public bool MoveNext()
				{
					return false;
				}
			}

			private class ib : IEnumerator<TKey>, IEnumerator, IDisposable
			{
				private unsafe Entry* qby;

				private readonly int qbz;

				private int qca;

				private TKey qcb;

				public TKey Current => default(TKey);

				object IEnumerator.Current => null;

				internal ib(FastDictionary<TKey, TValue> a)
				{
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

			private FastDictionary<TKey, TValue> m_dictionary;

			internal KeyCollection(FastDictionary<TKey, TValue> dict)
			{
				m_dictionary = default(FastDictionary<TKey, TValue>);
			}

			public KeyEnumerator GetEnumerator()
			{
				return default(KeyEnumerator);
			}

			private IEnumerator<TKey> emq()
			{
				return null;
			}

			IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in emq
				return this.emq();
			}

			private IEnumerator emr()
			{
				return null;
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in emr
				return this.emr();
			}
		}

		public struct ValueCollection : IEnumerable<TValue>, IEnumerable
		{
			public struct ValueEnumerator
			{
				private unsafe readonly Entry* m_entries;

				private readonly int m_capacity;

				private int m_index;

				private TValue m_current;

				public TValue wxq => default(TValue);

				internal unsafe ValueEnumerator(FastDictionary<TKey, TValue> dict)
				{
					m_entries = null;
					m_capacity = 0;
					m_index = 0;
					m_current = default(TValue);
				}

				public bool MoveNext()
				{
					return false;
				}
			}

			private class ic : IEnumerator<TValue>, IEnumerator, IDisposable
			{
				private unsafe Entry* qcc;

				private readonly int qcd;

				private int qce;

				private TValue qcf;

				public TValue Current => default(TValue);

				object IEnumerator.Current => null;

				internal ic(FastDictionary<TKey, TValue> a)
				{
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

			private FastDictionary<TKey, TValue> m_dictionary;

			internal ValueCollection(FastDictionary<TKey, TValue> dict)
			{
				m_dictionary = default(FastDictionary<TKey, TValue>);
			}

			public ValueEnumerator GetEnumerator()
			{
				return default(ValueEnumerator);
			}

			private IEnumerator<TValue> emu()
			{
				return null;
			}

			IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in emu
				return this.emu();
			}

			private IEnumerator emv()
			{
				return null;
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in emv
				return this.emv();
			}
		}

		public struct Enumerator
		{
			private unsafe Entry* m_entries;

			private int m_capacity;

			private int m_index;

			private KeyValuePair<TKey, TValue> m_current;

			public KeyValuePair<TKey, TValue> wxs
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get
				{
					return default(KeyValuePair<TKey, TValue>);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal unsafe Enumerator(FastDictionary<TKey, TValue> dict)
			{
				m_entries = null;
				m_capacity = 0;
				m_index = 0;
				m_current = default(KeyValuePair<TKey, TValue>);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool MoveNext()
			{
				return false;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void emx()
			{
			}
		}

		private readonly int m_declaredCapacity;

		private unsafe Entry* m_entries;

		private readonly int m_capacityMask;

		private int m_count;

		private readonly Allocator m_allocator;

		private const int EMPTY = -1;

		public TValue this[TKey key]
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return default(TValue);
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
			}
		}

		public int wxg => 0;

		public int wxh => 0;

		public KeyCollection wxt => default(KeyCollection);

		public ValueCollection wxu => default(ValueCollection);

		public unsafe FastDictionary(int capacity, Allocator allocator)
		{
			m_declaredCapacity = 0;
			m_entries = null;
			m_capacityMask = 0;
			m_count = 0;
			m_allocator = default(Allocator);
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
		public bool elr(TKey a, TValue b)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void emy(TKey a, TValue b)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool elu(TKey a)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe TValue* emz(TKey a)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe Entry* ena(TKey a)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe bool enb(TKey a, out TValue* b)
		{
			System.Runtime.CompilerServices.Unsafe.As<TValue*, @null>(ref b) = null;
			return false;
		}

		public void elv()
		{
		}

		public void Dispose()
		{
		}

		public float ene()
		{
			return 0f;
		}

		public int enf()
		{
			return 0;
		}

		public Enumerator GetEnumerator()
		{
			return default(Enumerator);
		}

		private IEnumerator<KeyValuePair<TKey, TValue>> eng()
		{
			return null;
		}

		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in eng
			return this.eng();
		}

		private IEnumerator enh()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in enh
			return this.enh();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static int eni(float a)
		{
			return 0;
		}
	}
}
