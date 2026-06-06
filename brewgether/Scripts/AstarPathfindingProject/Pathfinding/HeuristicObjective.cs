using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pathfinding.Collections;
using Pathfinding.Graphs.Util;
using Unity.Burst;
using Unity.Mathematics;

namespace Pathfinding
{
	[BurstCompile]
	public readonly struct HeuristicObjective
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate int Calculate_000004BD_0024PostfixBurstDelegate(in HeuristicObjective objective, ref int3 point, uint nodeIndex);

		internal static class Calculate_000004BD_0024BurstDirectCall
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

			public static int Invoke(in HeuristicObjective objective, ref int3 point, uint nodeIndex)
			{
				return 0;
			}
		}

		private readonly int3 mn;

		private readonly int3 mx;

		private readonly Heuristic heuristic;

		private readonly float heuristicScale;

		private readonly UnsafeSpan<uint> euclideanEmbeddingCosts;

		private readonly uint euclideanEmbeddingPivots;

		private readonly uint targetNodeIndex;

		public bool hasHeuristic => false;

		public HeuristicObjective(int3 point, Heuristic heuristic, float heuristicScale)
		{
			mn = default(int3);
			mx = default(int3);
			this.heuristic = default(Heuristic);
			this.heuristicScale = 0f;
			euclideanEmbeddingCosts = default(UnsafeSpan<uint>);
			euclideanEmbeddingPivots = 0u;
			targetNodeIndex = 0u;
		}

		public HeuristicObjective(int3 point, Heuristic heuristic, float heuristicScale, uint targetNodeIndex, EuclideanEmbedding euclideanEmbedding)
		{
			mn = default(int3);
			mx = default(int3);
			this.heuristic = default(Heuristic);
			this.heuristicScale = 0f;
			euclideanEmbeddingCosts = default(UnsafeSpan<uint>);
			euclideanEmbeddingPivots = 0u;
			this.targetNodeIndex = 0u;
		}

		public HeuristicObjective(int3 mn, int3 mx, Heuristic heuristic, float heuristicScale, uint targetNodeIndex, EuclideanEmbedding euclideanEmbedding)
		{
			this.mn = default(int3);
			this.mx = default(int3);
			this.heuristic = default(Heuristic);
			this.heuristicScale = 0f;
			euclideanEmbeddingCosts = default(UnsafeSpan<uint>);
			euclideanEmbeddingPivots = 0u;
			this.targetNodeIndex = 0u;
		}

		public int Calculate(int3 point, uint nodeIndex)
		{
			return 0;
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(Calculate_000004BD_0024PostfixBurstDelegate))]
		public static int Calculate(in HeuristicObjective objective, ref int3 point, uint nodeIndex)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static int Calculate_0024BurstManaged(in HeuristicObjective objective, ref int3 point, uint nodeIndex)
		{
			return 0;
		}
	}
}
