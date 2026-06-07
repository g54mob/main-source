using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace MagicaCloth2
{
	public abstract class StepReductionBase : IDisposable
	{
		public struct JoinEdge : IComparable<JoinEdge>
		{
			public int2 vertexPair;

			public float cost;

			public bool Contains(in int2 pair)
			{
				return false;
			}

			public int CompareTo(JoinEdge other)
			{
				return 0;
			}
		}

		[BurstCompile]
		private struct DeterminJoinEdgeJob : IJob
		{
			public int stepIndex;

			public float mergeLength;

			[ReadOnly]
			public NativeList<JoinEdge> joinEdgeList;

			public NativeParallelHashSet<int> completeVertexSet;

			public NativeList<int2> removePairList;

			public NativeArray<int> resultArray;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		private struct JoinPairJob : IJob
		{
			public float joinPositionAdjustment;

			[ReadOnly]
			public NativeList<int2> removePairList;

			public NativeArray<float3> localPositions;

			public NativeArray<float3> localNormals;

			public NativeParallelMultiHashMap<ushort, ushort> vertexToVertexMap;

			public NativeArray<VirtualMeshBoneWeight> boneWeights;

			public NativeArray<VertexAttribute> attributes;

			public NativeArray<int> joinIndices;

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

		protected string name;

		protected VirtualMesh vmesh;

		protected ReductionWorkData workData;

		protected ResultCode result;

		protected float startMergeLength;

		protected float endMergeLength;

		protected int maxStep;

		protected bool dontMakeLine;

		protected float joinPositionAdjustment;

		protected int nowStepIndex;

		protected float nowMergeLength;

		protected float nowStepScale;

		protected NativeList<JoinEdge> joinEdgeList;

		private NativeParallelHashSet<int> completeVertexSet;

		private NativeList<int2> removePairList;

		private NativeArray<int> resultArray;

		public ResultCode Result => default(ResultCode);

		public StepReductionBase()
		{
		}

		public StepReductionBase(string name, VirtualMesh mesh, ReductionWorkData workingData, float startMergeLength, float endMergeLength, int maxStep, bool dontMakeLine, float joinPositionAdjustment)
		{
		}

		public virtual void Dispose()
		{
		}

		public ResultCode Reduction()
		{
			return default(ResultCode);
		}

		private void InitStep()
		{
		}

		private bool IsEndStep()
		{
			return false;
		}

		private void NextStep()
		{
		}

		private void ReductionStep()
		{
		}

		protected virtual void StepInitialize()
		{
		}

		protected virtual void CustomReductionStep()
		{
		}

		private void PreReductionStep()
		{
		}

		private void PostReductionStep()
		{
		}

		private void SortJoinEdge()
		{
		}

		private void DetermineJoinEdge()
		{
		}

		private void RunJoinEdge()
		{
		}

		private void UpdateJoinAndLink()
		{
		}

		private void UpdateReductionResultJob()
		{
		}

		protected static bool CheckJoin2(in NativeParallelMultiHashMap<ushort, ushort> vertexToVertexMap, int vindex, int tvindex, bool dontMakeLine)
		{
			return false;
		}

		protected static bool CheckJoin(in NativeArray<FixedList128Bytes<ushort>> vertexToVertexArray, int vindex, int tvindex, in FixedList128Bytes<ushort> vlist, in FixedList128Bytes<ushort> tvlist, bool dontMakeLine)
		{
			return false;
		}
	}
}
