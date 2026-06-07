using System;
using System.Runtime.CompilerServices;
using Pathfinding.Graphs.Util;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Mathematics;

namespace Pathfinding
{
	[BurstCompile]
	public readonly struct HeuristicObjective
	{
		public delegate int Calculate_000004D2_0024PostfixBurstDelegate(in HeuristicObjective objective, ref int3 point, uint nodeIndex);

		internal static class Calculate_000004D2_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			private static IntPtr DeferredCompilation;

			[BurstDiscard]
			private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = (nint)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(Calculate_000004D2_0024PostfixBurstDelegate).TypeHandle);
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

			static Calculate_000004D2_0024BurstDirectCall()
			{
				Constructor();
			}

			public unsafe static int Invoke(in HeuristicObjective objective, ref int3 point, uint nodeIndex)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<ref HeuristicObjective, ref int3, uint, int>)functionPointer)(ref objective, ref point, nodeIndex);
					}
				}
				return Calculate_0024BurstManaged(in objective, ref point, nodeIndex);
			}
		}

		private readonly int3 mn;

		private readonly int3 mx;

		private readonly Heuristic heuristic;

		private readonly float heuristicScale;

		private readonly UnsafeSpan<uint> euclideanEmbeddingCosts;

		private readonly uint euclideanEmbeddingPivots;

		private readonly uint targetNodeIndex;

		public HeuristicObjective(int3 point, Heuristic heuristic, float heuristicScale)
		{
			mn = (mx = point);
			this.heuristic = heuristic;
			this.heuristicScale = heuristicScale;
			euclideanEmbeddingCosts = default(UnsafeSpan<uint>);
			euclideanEmbeddingPivots = 0u;
			targetNodeIndex = 0u;
		}

		public HeuristicObjective(int3 point, Heuristic heuristic, float heuristicScale, uint targetNodeIndex, EuclideanEmbedding euclideanEmbedding)
		{
			mn = (mx = point);
			this.heuristic = heuristic;
			this.heuristicScale = heuristicScale;
			euclideanEmbeddingCosts = euclideanEmbedding?.costs.AsUnsafeSpanNoChecks() ?? default(UnsafeSpan<uint>);
			euclideanEmbeddingPivots = (uint)(euclideanEmbedding?.pivotCount ?? 0);
			this.targetNodeIndex = targetNodeIndex;
		}

		public HeuristicObjective(int3 mn, int3 mx, Heuristic heuristic, float heuristicScale, uint targetNodeIndex, EuclideanEmbedding euclideanEmbedding)
		{
			this.mn = mn;
			this.mx = mx;
			this.heuristic = heuristic;
			this.heuristicScale = heuristicScale;
			euclideanEmbeddingCosts = euclideanEmbedding?.costs.AsUnsafeSpanNoChecks() ?? default(UnsafeSpan<uint>);
			euclideanEmbeddingPivots = (uint)(euclideanEmbedding?.pivotCount ?? 0);
			this.targetNodeIndex = targetNodeIndex;
		}

		public int Calculate(int3 point, uint nodeIndex)
		{
			return Calculate(in this, ref point, nodeIndex);
		}

		[BurstCompile]
		public static int Calculate(in HeuristicObjective objective, ref int3 point, uint nodeIndex)
		{
			return Calculate_000004D2_0024BurstDirectCall.Invoke(in objective, ref point, nodeIndex);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static int Calculate_0024BurstManaged(in HeuristicObjective objective, ref int3 point, uint nodeIndex)
		{
			int3 int5 = math.clamp(point, objective.mn, objective.mx);
			int3 int6 = point - int5;
			int num;
			switch (objective.heuristic)
			{
			case Heuristic.Euclidean:
				num = (int)(math.length(int6) * objective.heuristicScale);
				break;
			case Heuristic.Manhattan:
				num = (int)((float)math.csum(math.abs(int6)) * objective.heuristicScale);
				break;
			case Heuristic.DiagonalManhattan:
			{
				int6 = math.abs(int6);
				int a = int6.x;
				int b = int6.y;
				int b2 = int6.z;
				if (a > b)
				{
					Memory.Swap(ref a, ref b);
				}
				if (b > b2)
				{
					Memory.Swap(ref b, ref b2);
				}
				if (a > b)
				{
					Memory.Swap(ref a, ref b);
				}
				num = (int)(objective.heuristicScale * (1.7321f * (float)a + 1.4142f * (float)(b - a) + (float)(b2 - b - a)));
				break;
			}
			default:
				num = 0;
				break;
			}
			if (objective.euclideanEmbeddingPivots != 0)
			{
				num = math.max(num, (int)EuclideanEmbedding.GetHeuristic(objective.euclideanEmbeddingCosts, objective.euclideanEmbeddingPivots, nodeIndex, objective.targetNodeIndex));
			}
			return num;
		}
	}
}
