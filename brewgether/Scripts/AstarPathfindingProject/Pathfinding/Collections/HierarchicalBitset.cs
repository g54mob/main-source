using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Unity.Burst;
using Unity.Collections;

namespace Pathfinding.Collections
{
	[BurstCompile]
	public struct HierarchicalBitset
	{
		[BurstCompile]
		public struct Iterator : IEnumerator<UnsafeSpan<int>>, IEnumerator, IDisposable, IEnumerable<UnsafeSpan<int>>, IEnumerable
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate bool MoveNextBurst_00000D40_0024PostfixBurstDelegate(ref Iterator iter);

			internal static class MoveNextBurst_00000D40_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				[BurstDiscard]
				private static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
				}

				private static IntPtr GetFunctionPointer()
				{
					return (IntPtr)0;
				}

				public static bool Invoke(ref Iterator iter)
				{
					return false;
				}
			}

			private HierarchicalBitset bitSet;

			private UnsafeSpan<int> result;

			private int resultCount;

			private int l3index;

			private int l3bitIndex;

			private int l2bitIndex;

			public UnsafeSpan<int> Current => default(UnsafeSpan<int>);

			object IEnumerator.Current => null;

			public void Reset()
			{
			}

			public void Dispose()
			{
			}

			public IEnumerator<UnsafeSpan<int>> GetEnumerator()
			{
				return null;
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}

			private static int l2index(int l3index, int l3bitIndex)
			{
				return 0;
			}

			private static int l1index(int l2index, int l2bitIndex)
			{
				return 0;
			}

			public Iterator(HierarchicalBitset bitSet, UnsafeSpan<int> result)
			{
				this.bitSet = default(HierarchicalBitset);
				this.result = default(UnsafeSpan<int>);
				resultCount = 0;
				l3index = 0;
				l3bitIndex = 0;
				l2bitIndex = 0;
			}

			public bool MoveNext()
			{
				return false;
			}

			[BurstCompile]
			[MonoPInvokeCallback(typeof(MoveNextBurst_00000D40_0024PostfixBurstDelegate))]
			public static bool MoveNextBurst(ref Iterator iter)
			{
				return false;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private bool MoveNextInternal()
			{
				return false;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			internal static bool MoveNextBurst_0024BurstManaged(ref Iterator iter)
			{
				return false;
			}
		}

		private UnsafeSpan<ulong> l1;

		private UnsafeSpan<ulong> l2;

		private UnsafeSpan<ulong> l3;

		private Allocator allocator;

		private const int Log64 = 6;

		public bool IsCreated => false;

		public int Capacity
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool IsEmpty => false;

		public HierarchicalBitset(int size, Allocator allocator)
		{
			l1 = default(UnsafeSpan<ulong>);
			l2 = default(UnsafeSpan<ulong>);
			l3 = default(UnsafeSpan<ulong>);
			this.allocator = default(Allocator);
		}

		public void Dispose()
		{
		}

		public int Count()
		{
			return 0;
		}

		public void Clear()
		{
		}

		public void GetIndices(NativeList<int> result)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool SetAtomic(ref UnsafeSpan<ulong> span, int index)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool ResetAtomic(ref UnsafeSpan<ulong> span, int index)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Get(int index)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(int index)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Reset(int index)
		{
		}

		public Iterator GetIterator(UnsafeSpan<int> scratchBuffer)
		{
			return default(Iterator);
		}
	}
}
