using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace MagicaCloth2
{
	public class SimpleDistanceReduction : StepReductionBase
	{
		[BurstCompile]
		private struct InitGridJob : IJob
		{
			public int vcnt;

			public float gridSize;

			[ReadOnly]
			public NativeArray<float3> localPositions;

			[ReadOnly]
			public NativeArray<int> joinIndices;

			public NativeParallelMultiHashMap<int3, int> gridMap;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		private struct SearchJoinEdgeJob : IJob
		{
			public int vcnt;

			public float gridSize;

			public float radius;

			[ReadOnly]
			public NativeArray<float3> localPositions;

			[ReadOnly]
			public NativeArray<int> joinIndices;

			[ReadOnly]
			public NativeParallelMultiHashMap<ushort, ushort> vertexToVertexMap;

			[ReadOnly]
			public NativeParallelMultiHashMap<int3, int> gridMap;

			[WriteOnly]
			public NativeList<JoinEdge> joinEdgeList;

			public void Execute()
			{
			}
		}

		private GridMap<int> gridMap;

		public SimpleDistanceReduction(string name, VirtualMesh mesh, ReductionWorkData workingData, float startMergeLength, float endMergeLength, int maxStep, bool dontMakeLine, float joinPositionAdjustment)
		{
		}

		public override void Dispose()
		{
		}

		protected override void StepInitialize()
		{
		}

		protected override void CustomReductionStep()
		{
		}
	}
}
