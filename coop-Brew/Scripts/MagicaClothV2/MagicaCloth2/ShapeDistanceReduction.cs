using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace MagicaCloth2
{
	public class ShapeDistanceReduction : StepReductionBase
	{
		[BurstCompile]
		private struct SearchJoinEdgeJob : IJob
		{
			public int vcnt;

			public float radius;

			public bool dontMakeLine;

			[ReadOnly]
			public NativeArray<float3> localPositions;

			[ReadOnly]
			public NativeArray<int> joinIndices;

			[ReadOnly]
			public NativeParallelMultiHashMap<ushort, ushort> vertexToVertexMap;

			public NativeList<JoinEdge> joinEdgeList;

			public void Execute()
			{
			}
		}

		public ShapeDistanceReduction(string name, VirtualMesh mesh, ReductionWorkData workingData, float startMergeLength, float endMergeLength, int maxStep, bool dontMakeLine, float joinPositionAdjustment)
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
