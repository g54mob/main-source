using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pathfinding.Collections;
using Unity.Burst;

namespace Pathfinding
{
	[BurstCompile]
	public struct BinaryHeap
	{
		public enum TieBreaking : byte
		{
			HScore = 0,
			InsertionOrder = 1
		}

		private struct HeapNode
		{
			public uint pathNodeIndex;

			public ulong sortKey;

			public uint F
			{
				get
				{
					return 0u;
				}
				set
				{
				}
			}

			public uint TieBreaker
			{
				get
				{
					return 0u;
				}
				set
				{
				}
			}

			public HeapNode(uint pathNodeIndex, uint tieBreaker, uint f)
			{
				this.pathNodeIndex = 0u;
				sortKey = 0uL;
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void Add_000002F9_0024PostfixBurstDelegate(ref BinaryHeap binaryHeap, ref UnsafeSpan<PathNode> nodes, uint pathNodeIndex, uint g, uint h, uint insertionOrder, TieBreaking tieBreaking);

		internal static class Add_000002F9_0024BurstDirectCall
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

			public static void Invoke(ref BinaryHeap binaryHeap, ref UnsafeSpan<PathNode> nodes, uint pathNodeIndex, uint g, uint h, uint insertionOrder, TieBreaking tieBreaking)
			{
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate uint Remove_000002FC_0024PostfixBurstDelegate(ref UnsafeSpan<PathNode> nodes, ref BinaryHeap binaryHeap, [NoAlias] out uint removedTieBreaker, [NoAlias] out uint removedF);

		internal static class Remove_000002FC_0024BurstDirectCall
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

			public static uint Invoke(ref UnsafeSpan<PathNode> nodes, ref BinaryHeap binaryHeap, [NoAlias] out uint removedTieBreaker, [NoAlias] out uint removedF)
			{
				removedTieBreaker = default(uint);
				removedF = default(uint);
				return 0u;
			}
		}

		private UnsafeSpan<HeapNode> heap;

		public int numberOfItems;

		private uint insertionOrder;

		public TieBreaking tieBreaking;

		public const float GrowthFactor = 2f;

		private const int D = 4;

		public const ushort NotInHeap = ushort.MaxValue;

		public bool isEmpty => false;

		private static int RoundUpToNextMultipleMod1(int v)
		{
			return 0;
		}

		public BinaryHeap(int capacity)
		{
			heap = default(UnsafeSpan<HeapNode>);
			numberOfItems = 0;
			insertionOrder = 0u;
			tieBreaking = default(TieBreaking);
		}

		public void Dispose()
		{
		}

		public void Clear(UnsafeSpan<PathNode> pathNodes)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint GetPathNodeIndex(int heapIndex)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint GetH(int heapIndex)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint GetF(int heapIndex)
		{
			return 0u;
		}

		public void SetH(int heapIndex, uint h)
		{
		}

		private static void Expand(ref UnsafeSpan<HeapNode> heap)
		{
		}

		public void Add(UnsafeSpan<PathNode> nodes, uint pathNodeIndex, uint g, uint h)
		{
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(Add_000002F9_0024PostfixBurstDelegate))]
		private static void Add(ref BinaryHeap binaryHeap, ref UnsafeSpan<PathNode> nodes, uint pathNodeIndex, uint g, uint h, uint insertionOrder, TieBreaking tieBreaking)
		{
		}

		private static void DecreaseKey(UnsafeSpan<HeapNode> heap, UnsafeSpan<PathNode> nodes, HeapNode node, ushort index)
		{
		}

		public uint Remove(UnsafeSpan<PathNode> nodes, out uint g, out uint h)
		{
			g = default(uint);
			h = default(uint);
			return 0u;
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(Remove_000002FC_0024PostfixBurstDelegate))]
		private static uint Remove(ref UnsafeSpan<PathNode> nodes, ref BinaryHeap binaryHeap, [NoAlias] out uint removedTieBreaker, [NoAlias] out uint removedF)
		{
			removedTieBreaker = default(uint);
			removedF = default(uint);
			return 0u;
		}

		[Conditional("VALIDATE_BINARY_HEAP")]
		private static void Validate(ref UnsafeSpan<PathNode> nodes, ref BinaryHeap binaryHeap)
		{
		}

		public void Rebuild(UnsafeSpan<PathNode> nodes)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void Add_0024BurstManaged(ref BinaryHeap binaryHeap, ref UnsafeSpan<PathNode> nodes, uint pathNodeIndex, uint g, uint h, uint insertionOrder, TieBreaking tieBreaking)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static uint Remove_0024BurstManaged(ref UnsafeSpan<PathNode> nodes, ref BinaryHeap binaryHeap, [NoAlias] out uint removedTieBreaker, [NoAlias] out uint removedF)
		{
			removedTieBreaker = default(uint);
			removedF = default(uint);
			return 0u;
		}
	}
}
