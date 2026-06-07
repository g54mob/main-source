using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.Burst;
using Unity.Burst.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace Pathfinding.Util
{
	[BurstCompile]
	public struct HierarchicalBitset
	{
		[BurstCompile]
		public struct Iterator : IEnumerator<UnsafeSpan<int>>, IEnumerator, IDisposable, IEnumerable<UnsafeSpan<int>>, IEnumerable
		{
			public delegate bool MoveNextBurst_00000D1D_0024PostfixBurstDelegate(ref Iterator iter);

			internal static class MoveNextBurst_00000D1D_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				private static IntPtr DeferredCompilation;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = (nint)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(MoveNextBurst_00000D1D_0024PostfixBurstDelegate).TypeHandle);
					}
					P_0 = Pointer;
				}

				private static IntPtr GetFunctionPointer()
				{
					nint result = 0;
					GetFunctionPointerDiscard(ref result);
					return result;
				}

				public static void Constructor()
				{
					DeferredCompilation = BurstCompiler.CompileILPPMethod2((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/);
				}

				public static void Initialize()
				{
				}

				static MoveNextBurst_00000D1D_0024BurstDirectCall()
				{
					Constructor();
				}

				public unsafe static bool Invoke(ref Iterator iter)
				{
					if (BurstCompiler.IsEnabled)
					{
						IntPtr functionPointer = GetFunctionPointer();
						if (functionPointer != (IntPtr)0)
						{
							return ((delegate* unmanaged[Cdecl]<ref Iterator, bool>)functionPointer)(ref iter);
						}
					}
					return MoveNextBurst_0024BurstManaged(ref iter);
				}
			}

			private HierarchicalBitset bitSet;

			private UnsafeSpan<int> result;

			private int resultCount;

			private int l3index;

			private int l3bitIndex;

			private int l2bitIndex;

			public UnsafeSpan<int> Current => result.Slice(0, resultCount);

			object IEnumerator.Current
			{
				get
				{
					throw new NotImplementedException();
				}
			}

			public void Reset()
			{
				throw new NotImplementedException();
			}

			public void Dispose()
			{
			}

			public IEnumerator<UnsafeSpan<int>> GetEnumerator()
			{
				return this;
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				throw new NotImplementedException();
			}

			private static int l2index(int l3index, int l3bitIndex)
			{
				return (l3index << 6) + l3bitIndex;
			}

			private static int l1index(int l2index, int l2bitIndex)
			{
				return (l2index << 6) + l2bitIndex;
			}

			public Iterator(HierarchicalBitset bitSet, UnsafeSpan<int> result)
			{
				this.bitSet = bitSet;
				this.result = result;
				resultCount = 0;
				l3index = 0;
				l3bitIndex = 0;
				l2bitIndex = 0;
				if (result.Length < 128)
				{
					throw new ArgumentException("Result array must be at least 128 elements long");
				}
			}

			public bool MoveNext()
			{
				return MoveNextBurst(ref this);
			}

			[BurstCompile]
			public static bool MoveNextBurst(ref Iterator iter)
			{
				return MoveNextBurst_00000D1D_0024BurstDirectCall.Invoke(ref iter);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private bool MoveNextInternal()
			{
				uint num = 0u;
				int i = l3index;
				int num2 = l3bitIndex;
				int num3 = l2bitIndex;
				for (; i < bitSet.l3.length; i++)
				{
					ulong num4 = bitSet.l3[i] & (ulong)(-1L << num2);
					if (num4 == 0L)
					{
						continue;
					}
					while (num4 != 0L)
					{
						num2 = math.tzcnt(num4);
						int index = l2index(i, num2);
						for (ulong num5 = bitSet.l2[index] & (ulong)(-1L << num3); num5 != 0L; num5 &= num5 - 1)
						{
							num3 = math.tzcnt(num5);
							if (num + 64 > result.Length)
							{
								resultCount = (int)num;
								l3index = i;
								l3bitIndex = num2;
								l2bitIndex = num3;
								return true;
							}
							int num6 = l1index(index, num3);
							ulong num7 = bitSet.l1[num6];
							int num8 = num6 << 6;
							while (num7 != 0L)
							{
								int num9 = math.tzcnt(num7);
								num7 &= num7 - 1;
								int num10 = num8 + num9;
								Hint.Assume(num < (uint)result.Length);
								result[num++] = num10;
							}
						}
						num4 &= num4 - 1;
						num3 = 0;
					}
					num3 = 0;
					num2 = 0;
				}
				resultCount = (int)num;
				l3index = i;
				l3bitIndex = num2;
				l2bitIndex = num3;
				return num != 0;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			public static bool MoveNextBurst_0024BurstManaged(ref Iterator iter)
			{
				return iter.MoveNextInternal();
			}
		}

		private UnsafeSpan<ulong> l1;

		private UnsafeSpan<ulong> l2;

		private UnsafeSpan<ulong> l3;

		private Allocator allocator;

		private const int Log64 = 6;

		public bool IsCreated => Capacity > 0;

		public int Capacity
		{
			get
			{
				return l1.Length << 6;
			}
			set
			{
				if (value < Capacity)
				{
					throw new ArgumentException("Shrinking the bitset is not supported");
				}
				if (value != Capacity)
				{
					HierarchicalBitset hierarchicalBitset = new HierarchicalBitset(value, allocator);
					l1.CopyTo(hierarchicalBitset.l1);
					l2.CopyTo(hierarchicalBitset.l2);
					l3.CopyTo(hierarchicalBitset.l3);
					Dispose();
					this = hierarchicalBitset;
				}
			}
		}

		public bool IsEmpty
		{
			get
			{
				for (int i = 0; i < l3.Length; i++)
				{
					if (l3[i] != 0L)
					{
						return false;
					}
				}
				return true;
			}
		}

		public HierarchicalBitset(int size, Allocator allocator)
		{
			this.allocator = allocator;
			l1 = new UnsafeSpan<ulong>(allocator, size + 64 - 1 >> 6);
			l2 = new UnsafeSpan<ulong>(allocator, size + 4095 >> 6 >> 6);
			l3 = new UnsafeSpan<ulong>(allocator, size + 262143 >> 6 >> 6 >> 6);
			l1.FillZeros();
			l2.FillZeros();
			l3.FillZeros();
		}

		public void Dispose()
		{
			l1.Free(allocator);
			l2.Free(allocator);
			l3.Free(allocator);
			this = default(HierarchicalBitset);
		}

		public int Count()
		{
			int num = 0;
			for (int i = 0; i < l1.Length; i++)
			{
				num += math.countbits(l1[i]);
			}
			return num;
		}

		public void Clear()
		{
			l1.FillZeros();
			l2.FillZeros();
			l3.FillZeros();
		}

		public void GetIndices(NativeList<int> result)
		{
			NativeArray<int> arr = new NativeArray<int>(256, Allocator.Temp);
			Iterator iterator = GetIterator(arr.AsUnsafeSpan());
			while (iterator.MoveNext())
			{
				UnsafeSpan<int> current = iterator.Current;
				for (int i = 0; i < current.Length; i++)
				{
					result.Add(in current[i]);
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool SetAtomic(ref UnsafeSpan<ulong> span, int index)
		{
			int index2 = index >> 6;
			ulong num = span[index2];
			if ((num & (ulong)(1L << index)) != 0L)
			{
				return true;
			}
			while (true)
			{
				ulong num2 = (ulong)Interlocked.CompareExchange(ref UnsafeUtility.As<ulong, long>(ref span[index2]), (long)num | (1L << index), (long)num);
				if (num2 == num)
				{
					break;
				}
				num = num2;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool ResetAtomic(ref UnsafeSpan<ulong> span, int index)
		{
			int index2 = index >> 6;
			ulong num = span[index2];
			if ((num & (ulong)(1L << index)) == 0L)
			{
				return true;
			}
			while (true)
			{
				ulong num2 = (ulong)Interlocked.CompareExchange(ref UnsafeUtility.As<ulong, long>(ref span[index2]), (long)num & ~(1L << index), (long)num);
				if (num2 == num)
				{
					break;
				}
				num = num2;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Get(int index)
		{
			return (l1[index >> 6] & (ulong)(1L << index)) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(int index)
		{
			if (!SetAtomic(ref l1, index))
			{
				SetAtomic(ref l2, index >> 6);
				SetAtomic(ref l3, index >> 12);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Reset(int index)
		{
			if (!ResetAtomic(ref l1, index))
			{
				if (l1[index >> 6] == 0L)
				{
					ResetAtomic(ref l2, index >> 6);
				}
				if (l2[index >> 12] == 0L)
				{
					ResetAtomic(ref l3, index >> 12);
				}
			}
		}

		public Iterator GetIterator(UnsafeSpan<int> scratchBuffer)
		{
			return new Iterator(this, scratchBuffer);
		}
	}
}
