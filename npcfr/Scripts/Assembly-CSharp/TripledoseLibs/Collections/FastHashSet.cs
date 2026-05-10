using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;

namespace TripledoseLibs.Collections
{
	public struct FastHashSet<T> : @if<T>, IDisposable, IEnumerable<T>, IEnumerable where T : struct, IEquatable<T>
	{
		public struct Enumerator
		{
			private unsafe Entry* entries;

			private int capacity;

			private int index;

			private T current;

			public T wxw
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get
				{
					return default(T);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal unsafe Enumerator(FastHashSet<T> set)
			{
				entries = null;
				capacity = 0;
				index = 0;
				current = default(T);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool MoveNext()
			{
				return false;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void enr()
			{
			}
		}

		private struct Entry
		{
			public int hashCode;

			public byte dib;

			public T value;
		}

		private class ie : IEnumerator<T>, IEnumerator, IDisposable
		{
			private unsafe Entry* qci;

			private int qcj;

			private int qck;

			private T current;

			public T Current => default(T);

			object IEnumerator.Current => null;

			internal ie(FastHashSet<T> a)
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

		private unsafe Entry* m_entries;

		private readonly int m_capacityMask;

		private int m_count;

		private readonly Allocator m_allocator;

		private const int EMPTY = -1;

		public int wxy => 0;

		public int wxz => 0;

		public unsafe FastHashSet(int capacity, Allocator allocator)
		{
			m_entries = null;
			m_capacityMask = 0;
			m_count = 0;
			m_allocator = default(Allocator);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool env(T a)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool enw(T a)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool enx(T a)
		{
			return false;
		}

		public void eny()
		{
		}

		public void Dispose()
		{
		}

		public Enumerator GetEnumerator()
		{
			return default(Enumerator);
		}

		public float enz()
		{
			return 0f;
		}

		public int eoa()
		{
			return 0;
		}

		private IEnumerator<T> eob()
		{
			return null;
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in eob
			return this.eob();
		}

		private IEnumerator eoc()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in eoc
			return this.eoc();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static int eod(float a)
		{
			return 0;
		}
	}
}
