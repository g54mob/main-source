using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace MagicaCloth2
{
	public class SameDistanceReduction : IDisposable
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
		private struct SearchJoinJob : IJob
		{
			public int vcnt;

			public float gridSize;

			public float radius;

			[ReadOnly]
			public NativeArray<float3> localPositions;

			[ReadOnly]
			public NativeArray<int> joinIndices;

			[ReadOnly]
			public NativeParallelMultiHashMap<int3, int> gridMap;

			public NativeParallelMultiHashMap<ushort, ushort> joinPairMap;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		private struct JoinJob2 : IJob
		{
			public int vertexCount;

			[ReadOnly]
			public NativeParallelMultiHashMap<ushort, ushort> joinPairMap;

			public NativeArray<int> joinIndices;

			public NativeParallelMultiHashMap<ushort, ushort> vertexToVertexMap;

			public NativeArray<VirtualMeshBoneWeight> boneWeights;

			public NativeArray<VertexAttribute> attributes;

			public NativeReference<int> result;

			public NativeList<ushort> tempList;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		private struct UpdateJoinIndexJob : IJobParallelFor
		{
			[NativeDisableParallelForRestriction]
			public NativeArray<int> joinIndices;

			public void Execute(int vindex)
			{
			}
		}

		[BurstCompile]
		private struct UpdateLinkIndexJob : IJobParallelFor
		{
			[NativeDisableParallelForRestriction]
			public NativeArray<int> joinIndices;

			public NativeParallelMultiHashMap<ushort, ushort> vertexToVertexMap;

			public void Execute(int vindex)
			{
			}
		}

		[BurstCompile]
		private struct FinalMergeVertexJob : IJobParallelFor
		{
			[ReadOnly]
			public NativeArray<int> joinIndices;

			public NativeArray<float3> localNormals;

			public NativeArray<VirtualMeshBoneWeight> boneWeights;

			public void Execute(int vindex)
			{
			}
		}

		private string name;

		private VirtualMesh vmesh;

		private ReductionWorkData workData;

		private ResultCode result;

		private float mergeLength;

		private GridMap<int> gridMap;

		private NativeParallelMultiHashMap<ushort, ushort> joinPairMap;

		private NativeReference<int> resultRef;

		public ResultCode Result => default(ResultCode);

		public SameDistanceReduction()
		{
		}

		public SameDistanceReduction(string name, VirtualMesh mesh, ReductionWorkData workingData, float mergeLength)
		{
		}

		public virtual void Dispose()
		{
		}

		public ResultCode Reduction()
		{
			return default(ResultCode);
		}

		private void UpdateJoinAndLink()
		{
		}

		private void UpdateReductionResultJob()
		{
		}
	}
}
