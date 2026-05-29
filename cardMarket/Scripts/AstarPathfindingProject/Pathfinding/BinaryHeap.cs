using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Burst.CompilerServices;
using Unity.Collections;
using Unity.Mathematics;

namespace Pathfinding
{
	[BurstCompile]
	public struct BinaryHeap
	{
		private struct HeapNode
		{
			public uint pathNodeIndex;

			public ulong sortKey;

			public uint F
			{
				get
				{
					return (uint)(sortKey >> 32);
				}
				set
				{
					sortKey = (sortKey & 0xFFFFFFFFu) | ((ulong)value << 32);
				}
			}

			public uint G => (uint)sortKey;

			public HeapNode(uint pathNodeIndex, uint g, uint f)
			{
				this.pathNodeIndex = pathNodeIndex;
				sortKey = ((ulong)f << 32) | g;
			}
		}

		public delegate void Add_000002E0_0024PostfixBurstDelegate(ref BinaryHeap binaryHeap, ref UnsafeSpan<PathNode> nodes, uint pathNodeIndex, uint g, uint f);

		internal static class Add_000002E0_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			private static IntPtr DeferredCompilation;

			[BurstDiscard]
			private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = (nint)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(Add_000002E0_0024PostfixBurstDelegate).TypeHandle);
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

			static Add_000002E0_0024BurstDirectCall()
			{
				Constructor();
			}

			public unsafe static void Invoke(ref BinaryHeap binaryHeap, ref UnsafeSpan<PathNode> nodes, uint pathNodeIndex, uint g, uint f)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref BinaryHeap, ref UnsafeSpan<PathNode>, uint, uint, uint, void>)functionPointer)(ref binaryHeap, ref nodes, pathNodeIndex, g, f);
						return;
					}
				}
				Add_0024BurstManaged(ref binaryHeap, ref nodes, pathNodeIndex, g, f);
			}
		}

		public delegate uint Remove_000002E3_0024PostfixBurstDelegate(ref UnsafeSpan<PathNode> nodes, ref BinaryHeap binaryHeap, [NoAlias] out uint removedG, [NoAlias] out uint removedF);

		internal static class Remove_000002E3_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			private static IntPtr DeferredCompilation;

			[BurstDiscard]
			private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = (nint)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(Remove_000002E3_0024PostfixBurstDelegate).TypeHandle);
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

			static Remove_000002E3_0024BurstDirectCall()
			{
				Constructor();
			}

			public unsafe static uint Invoke(ref UnsafeSpan<PathNode> nodes, ref BinaryHeap binaryHeap, [NoAlias] out uint removedG, [NoAlias] out uint removedF)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<ref UnsafeSpan<PathNode>, ref BinaryHeap, ref uint, ref uint, uint>)functionPointer)(ref nodes, ref binaryHeap, ref removedG, ref removedF);
					}
				}
				return Remove_0024BurstManaged(ref nodes, ref binaryHeap, out removedG, out removedF);
			}
		}

		public int numberOfItems;

		public const float GrowthFactor = 2f;

		private const int D = 4;

		private const bool SortGScores = true;

		public const ushort NotInHeap = ushort.MaxValue;

		private UnsafeSpan<HeapNode> heap;

		public bool isEmpty => numberOfItems <= 0;

		private static int RoundUpToNextMultipleMod1(int v)
		{
			return v + (4 - (v - 1) % 4) % 4;
		}

		public BinaryHeap(int capacity)
		{
			capacity = RoundUpToNextMultipleMod1(capacity);
			heap = new UnsafeSpan<HeapNode>(Allocator.Persistent, capacity);
			numberOfItems = 0;
		}

		public unsafe void Dispose()
		{
			AllocatorManager.Free(Allocator.Persistent, heap.ptr, heap.Length);
		}

		public void Clear(UnsafeSpan<PathNode> pathNodes)
		{
			for (int i = 0; i < numberOfItems; i++)
			{
				pathNodes[heap[i].pathNodeIndex].heapIndex = ushort.MaxValue;
			}
			numberOfItems = 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint GetPathNodeIndex(int heapIndex)
		{
			return heap[heapIndex].pathNodeIndex;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint GetG(int heapIndex)
		{
			return heap[heapIndex].G;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint GetF(int heapIndex)
		{
			return heap[heapIndex].F;
		}

		public void SetH(int heapIndex, uint h)
		{
			heap[heapIndex].F = heap[heapIndex].G + h;
		}

		private unsafe static void Expand(ref UnsafeSpan<HeapNode> heap)
		{
			int v = math.max(heap.Length + 4, math.min(65533, (int)math.round((float)heap.Length * 2f)));
			v = RoundUpToNextMultipleMod1(v);
			if (v > 65534)
			{
				throw new Exception("Binary Heap Size really large (>65534). A heap size this large is probably the cause of pathfinding running in an infinite loop. ");
			}
			UnsafeSpan<HeapNode> unsafeSpan = new UnsafeSpan<HeapNode>(Allocator.Persistent, v);
			unsafeSpan.CopyFrom(heap);
			AllocatorManager.Free(Allocator.Persistent, heap.ptr, heap.Length);
			heap = unsafeSpan;
		}

		public void Add(UnsafeSpan<PathNode> nodes, uint pathNodeIndex, uint g, uint f)
		{
			Add(ref this, ref nodes, pathNodeIndex, g, f);
		}

		[BurstCompile]
		private static void Add(ref BinaryHeap binaryHeap, ref UnsafeSpan<PathNode> nodes, uint pathNodeIndex, uint g, uint f)
		{
			Add_000002E0_0024BurstDirectCall.Invoke(ref binaryHeap, ref nodes, pathNodeIndex, g, f);
		}

		private static void DecreaseKey(UnsafeSpan<HeapNode> heap, UnsafeSpan<PathNode> nodes, HeapNode node, ushort index)
		{
			uint num = index;
			while (num != 0)
			{
				uint num2 = (num - 1) / 4;
				Hint.Assume(num2 < heap.length);
				Hint.Assume(num < heap.length);
				if (node.sortKey >= heap[num2].sortKey)
				{
					break;
				}
				heap[num] = heap[num2];
				nodes[heap[num].pathNodeIndex].heapIndex = (ushort)num;
				num = num2;
			}
			Hint.Assume(num < heap.length);
			heap[num] = node;
			nodes[node.pathNodeIndex].heapIndex = (ushort)num;
		}

		public uint Remove(UnsafeSpan<PathNode> nodes, out uint g, out uint f)
		{
			return Remove(ref nodes, ref this, out g, out f);
		}

		[BurstCompile]
		private static uint Remove(ref UnsafeSpan<PathNode> nodes, ref BinaryHeap binaryHeap, [NoAlias] out uint removedG, [NoAlias] out uint removedF)
		{
			return Remove_000002E3_0024BurstDirectCall.Invoke(ref nodes, ref binaryHeap, out removedG, out removedF);
		}

		[Conditional("VALIDATE_BINARY_HEAP")]
		private static void Validate(ref UnsafeSpan<PathNode> nodes, ref BinaryHeap binaryHeap)
		{
			for (int i = 1; i < binaryHeap.numberOfItems; i++)
			{
				int index = (i - 1) / 4;
				if (binaryHeap.heap[index].F > binaryHeap.heap[i].F)
				{
					throw new Exception("Invalid state at " + i + ":" + index + " ( " + binaryHeap.heap[index].F + " > " + binaryHeap.heap[i].F + " ) ");
				}
				if (binaryHeap.heap[index].sortKey > binaryHeap.heap[i].sortKey)
				{
					throw new Exception("Invalid state at " + i + ":" + index + " ( " + binaryHeap.heap[index].F + " > " + binaryHeap.heap[i].F + " ) ");
				}
				if (nodes[binaryHeap.heap[i].pathNodeIndex].heapIndex != i)
				{
					throw new Exception("Invalid heap index");
				}
			}
		}

		public void Rebuild(UnsafeSpan<PathNode> nodes)
		{
			for (int i = 2; i < numberOfItems; i++)
			{
				int num = i;
				HeapNode heapNode = heap[i];
				uint f = heapNode.F;
				while (num != 1)
				{
					int num2 = num / 4;
					if (f >= heap[num2].F)
					{
						break;
					}
					heap[num] = heap[num2];
					nodes[heap[num].pathNodeIndex].heapIndex = (ushort)num;
					heap[num2] = heapNode;
					nodes[heap[num2].pathNodeIndex].heapIndex = (ushort)num2;
					num = num2;
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static void Add_0024BurstManaged(ref BinaryHeap binaryHeap, ref UnsafeSpan<PathNode> nodes, uint pathNodeIndex, uint g, uint f)
		{
			ref int reference = ref binaryHeap.numberOfItems;
			ref UnsafeSpan<HeapNode> reference2 = ref binaryHeap.heap;
			ref PathNode reference3 = ref nodes[pathNodeIndex];
			if (reference3.heapIndex != ushort.MaxValue)
			{
				DecreaseKey(node: new HeapNode(pathNodeIndex, g, f), heap: reference2, nodes: nodes, index: reference3.heapIndex);
				return;
			}
			if (reference == reference2.Length)
			{
				Expand(ref reference2);
			}
			DecreaseKey(reference2, nodes, new HeapNode(pathNodeIndex, g, f), (ushort)reference);
			reference++;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static uint Remove_0024BurstManaged(ref UnsafeSpan<PathNode> nodes, ref BinaryHeap binaryHeap, [NoAlias] out uint removedG, [NoAlias] out uint removedF)
		{
			ref int reference = ref binaryHeap.numberOfItems;
			UnsafeSpan<HeapNode> unsafeSpan = binaryHeap.heap;
			if (reference == 0)
			{
				throw new InvalidOperationException("Removing item from empty heap");
			}
			Hint.Assume(0uL < (ulong)unsafeSpan.length);
			uint pathNodeIndex = unsafeSpan[0].pathNodeIndex;
			nodes[pathNodeIndex].heapIndex = ushort.MaxValue;
			removedG = unsafeSpan[0].G;
			removedF = unsafeSpan[0].F;
			reference--;
			if (reference == 0)
			{
				return pathNodeIndex;
			}
			Hint.Assume((uint)reference < unsafeSpan.length);
			HeapNode heapNode = unsafeSpan[reference];
			uint num = 0u;
			ulong sortKey = heapNode.sortKey;
			while (true)
			{
				uint num2 = num;
				uint num3 = num2 * 4 + 1;
				if (num3 >= reference)
				{
					break;
				}
				Hint.Assume(num3 < unsafeSpan.length);
				ulong num4 = (unsafeSpan[num3].sortKey & 0xFFFFFFFFFFFFFFFCuL) | 0;
				Hint.Assume(num3 + 1 < unsafeSpan.length);
				ulong y = (unsafeSpan[num3 + 1].sortKey & 0xFFFFFFFFFFFFFFFCuL) | 1;
				Hint.Assume(num3 + 2 < unsafeSpan.length);
				ulong y2 = (unsafeSpan[num3 + 2].sortKey & 0xFFFFFFFFFFFFFFFCuL) | 2;
				Hint.Assume(num3 + 3 < unsafeSpan.length);
				ulong y3 = (unsafeSpan[num3 + 3].sortKey & 0xFFFFFFFFFFFFFFFCuL) | 3;
				ulong num5 = num4;
				if (num3 + 1 < reference)
				{
					num5 = math.min(num5, y);
				}
				if (num3 + 2 < reference)
				{
					num5 = math.min(num5, y2);
				}
				if (num3 + 3 < reference)
				{
					num5 = math.min(num5, y3);
				}
				if (num5 >= sortKey)
				{
					break;
				}
				num = num3 + (uint)(int)(num5 & 3);
				Hint.Assume(num2 < unsafeSpan.length);
				Hint.Assume(num < unsafeSpan.length);
				unsafeSpan[num2] = unsafeSpan[num];
				Hint.Assume(num < unsafeSpan.length);
				nodes[unsafeSpan[num].pathNodeIndex].heapIndex = (ushort)num2;
			}
			Hint.Assume(num < unsafeSpan.length);
			unsafeSpan[num] = heapNode;
			nodes[heapNode.pathNodeIndex].heapIndex = (ushort)num;
			return pathNodeIndex;
		}
	}
}
