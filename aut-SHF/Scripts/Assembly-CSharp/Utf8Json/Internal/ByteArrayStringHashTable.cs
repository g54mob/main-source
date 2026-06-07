using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Utf8Json.Internal
{
	internal class ByteArrayStringHashTable<T> : IEnumerable<KeyValuePair<string, T>>, IEnumerable
	{
		private struct Entry
		{
			public byte[] Key;

			public T Value;

			public override string ToString()
			{
				return null;
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetEnumerator_003Ed__10 : IEnumerator<KeyValuePair<string, T>>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private KeyValuePair<string, T> _003C_003E2__current;

			public ByteArrayStringHashTable<T> _003C_003E4__this;

			private Entry[][] _003C_003E7__wrap1;

			private int _003C_003E7__wrap2;

			private Entry[] _003C_003E7__wrap3;

			private int _003C_003E7__wrap4;

			KeyValuePair<string, T> IEnumerator<KeyValuePair<string, T>>.Current
			{
				[DebuggerHidden]
				get
				{
					return default(KeyValuePair<string, T>);
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CGetEnumerator_003Ed__10(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private readonly Entry[][] buckets;

		private readonly ulong indexFor;

		public ByteArrayStringHashTable(int capacity)
		{
		}

		public ByteArrayStringHashTable(int capacity, float loadFactor)
		{
		}

		public void Add(string key, T value)
		{
		}

		public void Add(byte[] key, T value)
		{
		}

		private bool TryAddInternal(byte[] key, T value)
		{
			return false;
		}

		public bool TryGetValue(ArraySegment<byte> key, out T value)
		{
			value = default(T);
			return false;
		}

		private static ulong ByteArrayGetHashCode(byte[] x, int offset, int count)
		{
			return 0uL;
		}

		private static int CalculateCapacity(int collectionSize, float loadFactor)
		{
			return 0;
		}

		[IteratorStateMachine(typeof(ByteArrayStringHashTable<>._003CGetEnumerator_003Ed__10))]
		public IEnumerator<KeyValuePair<string, T>> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}
}
