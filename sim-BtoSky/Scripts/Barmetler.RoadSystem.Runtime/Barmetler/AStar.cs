using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Barmetler.DictExtensions;
using Barmetler.RoadSystem.Util;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Barmetler
{
	[BurstCompile]
	public static class AStar
	{
		public class NodeBase
		{
			public Vector3 position;
		}

		public delegate float Heuristic<NodeType>(NodeType node, NodeType goal) where NodeType : NodeBase;

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate float Heuristic(in float3 node, in float3 goal);

		private struct FindShortestPathJob : IJob
		{
			public FunctionPointer<Heuristic> HeuristicPtr;

			[ReadOnly]
			public NativeArray<float3> Nodes;

			[ReadOnly]
			public ExtendedTwoDimensionalNativeArray<float> Weights;

			[ReadOnly]
			public int Start;

			[ReadOnly]
			public int Goal;

			[ReadOnly]
			public int MaxSteps;

			[NativeDisableUnsafePtrRestriction]
			public unsafe int* StepsTaken;

			public NativeList<int> Path;

			public unsafe void Execute()
			{
				NativeArray<int> nativeArray = new NativeArray<int>(Nodes.Length, Allocator.Temp);
				NativeArray<float> nativeArray2 = new NativeArray<float>(Nodes.Length, Allocator.Temp);
				NativeArray<float> nativeArray3 = new NativeArray<float>(Nodes.Length, Allocator.Temp);
				NativeMinHeap nativeMinHeap = new NativeMinHeap(Nodes.Length, Allocator.Temp);
				for (int i = 0; i < Nodes.Length; i++)
				{
					int index = i;
					float value = (nativeArray3[i] = float.PositiveInfinity);
					nativeArray2[index] = value;
				}
				nativeArray2[Start] = 0f;
				nativeArray3[Start] = HeuristicPtr.Invoke(Nodes[Start], Nodes[Goal]);
				nativeMinHeap.Insert(Start, nativeArray3[Start]);
				int j;
				for (j = 0; j < MaxSteps; j++)
				{
					if (nativeMinHeap.Count == 0)
					{
						break;
					}
					int num2 = nativeMinHeap.ExtractMin();
					if (num2 != Goal)
					{
						for (int k = 0; k < Nodes.Length; k++)
						{
							if (k != num2 && !float.IsInfinity(Weights[num2, k]) && !((double)Weights[num2, k] < 1E-06))
							{
								float num3 = nativeArray2[num2] + Weights[num2, k];
								if (!(num3 >= nativeArray2[k]))
								{
									nativeArray[k] = num2;
									nativeArray2[k] = num3;
									nativeArray3[k] = nativeArray2[k] + HeuristicPtr.Invoke(Nodes[k], Nodes[Goal]);
									nativeMinHeap.InsertOrUpdate(k, nativeArray3[k]);
								}
							}
						}
						continue;
					}
					int num4 = 0;
					int value2 = Goal;
					while (num4 < Nodes.Length && value2 != Start)
					{
						Path.Add(in value2);
						num4++;
						value2 = nativeArray[value2];
					}
					Path.Add(in Start);
					for (int l = 0; l < Path.Length / 2; l++)
					{
						int value3 = Path[l];
						Path[l] = Path[Path.Length - l - 1];
						Path[Path.Length - l - 1] = value3;
					}
					break;
				}
				*StepsTaken = j;
				nativeArray.Dispose();
				nativeArray2.Dispose();
				nativeArray3.Dispose();
				nativeMinHeap.Dispose();
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate float DistanceHeuristicFun_00000009_0024PostfixBurstDelegate(in float3 node, in float3 goal);

		internal static class DistanceHeuristicFun_00000009_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<DistanceHeuristicFun_00000009_0024PostfixBurstDelegate>(DistanceHeuristicFun).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static float Invoke(in float3 node, in float3 goal)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<ref float3, ref float3, float>)functionPointer)(ref node, ref goal);
					}
				}
				return DistanceHeuristicFun_0024BurstManaged(in node, in goal);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate float DijkstraHeuristicFun_0000000A_0024PostfixBurstDelegate(in float3 node, in float3 goal);

		internal static class DijkstraHeuristicFun_0000000A_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<DijkstraHeuristicFun_0000000A_0024PostfixBurstDelegate>(DijkstraHeuristicFun).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static float Invoke(in float3 node, in float3 goal)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<ref float3, ref float3, float>)functionPointer)(ref node, ref goal);
					}
				}
				return DijkstraHeuristicFun_0024BurstManaged(in node, in goal);
			}
		}

		private static readonly Lazy<FunctionPointer<Heuristic>> DistanceHeuristicLazy = new Lazy<FunctionPointer<Heuristic>>(() => BurstCompiler.CompileFunctionPointer<Heuristic>(DistanceHeuristicFun));

		private static readonly Lazy<FunctionPointer<Heuristic>> DijkstraHeuristicLazy = new Lazy<FunctionPointer<Heuristic>>(() => BurstCompiler.CompileFunctionPointer<Heuristic>(DijkstraHeuristicFun));

		public static FunctionPointer<Heuristic> DistanceHeuristic => DistanceHeuristicLazy.Value;

		public static FunctionPointer<Heuristic> DijkstraHeuristic => DijkstraHeuristicLazy.Value;

		private static float DefaultHeuristic<NodeType>(NodeType node, NodeType goal) where NodeType : NodeBase
		{
			return (node.position - goal.position).magnitude;
		}

		public static List<NodeType> FindShortestPath<NodeType>(List<NodeType> nodes, TwoDimensionalArray<float> weights, NodeType start, NodeType goal, Heuristic<NodeType> heuristic = null, int maxSteps = 10000) where NodeType : NodeBase
		{
			if (heuristic == null)
			{
				heuristic = DefaultHeuristic;
			}
			Dictionary<NodeType, NodeType> dictionary = new Dictionary<NodeType, NodeType>();
			Dictionary<NodeType, float> gScore = new Dictionary<NodeType, float> { [start] = 0f };
			Dictionary<NodeType, float> fScore = new Dictionary<NodeType, float> { [start] = h(start) };
			Comparer<NodeType> comparer = Comparer<NodeType>.Create(delegate(NodeType a, NodeType b)
			{
				int num3 = fScore.GetWithDefault(a, float.PositiveInfinity).CompareTo(fScore.GetWithDefault(b, float.PositiveInfinity));
				if (num3 != 0)
				{
					return num3;
				}
				int num4 = gScore.GetWithDefault(a, float.PositiveInfinity).CompareTo(gScore.GetWithDefault(b, float.PositiveInfinity));
				return (num4 != 0) ? num4 : nodes.IndexOf(a).CompareTo(nodes.IndexOf(b));
			});
			SortedSet<NodeType> sortedSet = new SortedSet<NodeType>(new NodeType[1] { start }, comparer);
			int num = 0;
			while (sortedSet.Count > 0)
			{
				if (num > maxSteps)
				{
					throw new Exception("Too many steps!");
				}
				NodeType min = sortedSet.Min;
				sortedSet.Remove(min);
				if (min == goal)
				{
					return ReconstructPath(dictionary, min);
				}
				foreach (KeyValuePair<NodeType, float> neighbor in GetNeighbors(nodes, weights, min))
				{
					float num2 = gScore[min] + neighbor.Value;
					if (num2 < gScore.GetWithDefault(neighbor.Key, float.PositiveInfinity))
					{
						sortedSet.Remove(neighbor.Key);
						dictionary[neighbor.Key] = min;
						gScore[neighbor.Key] = num2;
						fScore[neighbor.Key] = gScore[neighbor.Key] + h(neighbor.Key);
						sortedSet.Add(neighbor.Key);
					}
				}
				num++;
			}
			throw new Exception("No Path Found!");
			float h(NodeType node)
			{
				return heuristic(node, start);
			}
		}

		private static List<NodeType> ReconstructPath<NodeType>(Dictionary<NodeType, NodeType> cameFrom, NodeType current) where NodeType : NodeBase
		{
			List<NodeType> list = new List<NodeType>();
			while (cameFrom.ContainsKey(current))
			{
				list.Insert(0, current);
				current = cameFrom[current];
			}
			list.Insert(0, current);
			return list;
		}

		private static List<KeyValuePair<NodeType, float>> GetNeighbors<NodeType>(List<NodeType> nodes, TwoDimensionalArray<float> weights, NodeType current) where NodeType : NodeBase
		{
			List<KeyValuePair<NodeType, float>> list = new List<KeyValuePair<NodeType, float>>();
			int num = nodes.IndexOf(current);
			for (int i = 0; i < nodes.Count; i++)
			{
				if (num != i && !float.IsInfinity(weights[num, i]))
				{
					list.Add(new KeyValuePair<NodeType, float>(nodes[i], weights[num, i]));
				}
			}
			return list;
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(Heuristic))]
		private static float DistanceHeuristicFun(in float3 node, in float3 goal)
		{
			return DistanceHeuristicFun_00000009_0024BurstDirectCall.Invoke(in node, in goal);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(Heuristic))]
		private static float DijkstraHeuristicFun(in float3 node, in float3 goal)
		{
			return DijkstraHeuristicFun_0000000A_0024BurstDirectCall.Invoke(in node, in goal);
		}

		public unsafe static int[] FindShortestPath(NativeArray<float3> nodes, ExtendedTwoDimensionalNativeArray<float> weights, int start, int goal, out int stepsTaken, FunctionPointer<Heuristic> heuristic = default(FunctionPointer<Heuristic>))
		{
			if (!heuristic.IsCreated)
			{
				heuristic = DistanceHeuristic;
			}
			int num = 0;
			FindShortestPathJob jobData = new FindShortestPathJob
			{
				HeuristicPtr = heuristic,
				Nodes = nodes,
				Weights = weights,
				Start = start,
				Goal = goal,
				MaxSteps = 10000,
				StepsTaken = &num,
				Path = new NativeList<int>(Allocator.TempJob)
			};
			jobData.Run();
			int[] result = jobData.Path.AsArray().ToArray();
			jobData.Path.Dispose();
			stepsTaken = num;
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static float DistanceHeuristicFun_0024BurstManaged(in float3 node, in float3 goal)
		{
			return math.distance(node, goal);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static float DijkstraHeuristicFun_0024BurstManaged(in float3 node, in float3 goal)
		{
			return 0f;
		}
	}
}
