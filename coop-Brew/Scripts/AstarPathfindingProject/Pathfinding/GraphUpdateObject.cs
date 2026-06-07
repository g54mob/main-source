using System;
using Pathfinding.Jobs;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding
{
	public class GraphUpdateObject
	{
		public struct GraphUpdateData
		{
			public NativeArray<Vector3> nodePositions;

			public NativeArray<uint> nodePenalties;

			public NativeArray<bool> nodeWalkable;

			public NativeArray<int> nodeTags;

			public NativeArray<float4> nodeNormals;

			public NativeArray<int> nodeIndices;
		}

		[BurstCompile]
		public struct JobGraphUpdate : IJob
		{
			public GraphUpdateShape.BurstShape shape;

			public GraphUpdateData data;

			public Bounds bounds;

			public int penaltyDelta;

			public bool modifyWalkability;

			public bool walkabilityValue;

			public bool modifyTag;

			public int tagValue;

			public void Execute()
			{
			}
		}

		public Bounds bounds;

		public bool updatePhysics;

		public bool resetPenaltyOnPhysics;

		public bool updateErosion;

		public NNConstraint nnConstraint;

		public int addPenalty;

		public bool modifyWalkability;

		public bool setWalkability;

		public bool modifyTag;

		public PathfindingTag setTag;

		[Obsolete("This field does not do anything anymore. Use AstarPath.Snapshot instead.")]
		public bool trackChangedNodes;

		public GraphUpdateShape shape;

		internal int internalStage;

		internal const int STAGE_CREATED = -1;

		internal const int STAGE_PENDING = -2;

		internal const int STAGE_ABORTED = -3;

		internal const int STAGE_APPLIED = 0;

		public GraphUpdateStage stage => default(GraphUpdateStage);

		public virtual void WillUpdateNode(GraphNode node)
		{
		}

		[Obsolete("Use AstarPath.Snapshot instead", true)]
		public virtual void RevertFromBackup()
		{
		}

		public virtual void Apply(GraphNode node)
		{
		}

		public virtual void ApplyJob(GraphUpdateData data, JobDependencyTracker dependencyTracker)
		{
		}

		public GraphUpdateObject()
		{
		}

		public GraphUpdateObject(Bounds b)
		{
		}
	}
}
