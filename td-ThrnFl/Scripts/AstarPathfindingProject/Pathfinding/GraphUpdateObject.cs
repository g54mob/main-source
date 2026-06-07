using System;
using Pathfinding.Jobs;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
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
				for (int i = 0; i < data.nodeIndices.Length; i++)
				{
					int index = data.nodeIndices[i];
					if (bounds.Contains(data.nodePositions[index]) && shape.Contains(data.nodePositions[index]))
					{
						data.nodePenalties[index] += (uint)penaltyDelta;
						if (modifyWalkability)
						{
							data.nodeWalkable[index] = walkabilityValue;
						}
						if (modifyTag)
						{
							data.nodeTags[index] = tagValue;
						}
					}
				}
			}
		}

		public Bounds bounds;

		public bool updatePhysics = true;

		public bool resetPenaltyOnPhysics = true;

		public bool updateErosion = true;

		public NNConstraint nnConstraint = NNConstraint.None;

		public int addPenalty;

		public bool modifyWalkability;

		public bool setWalkability;

		public bool modifyTag;

		public PathfindingTag setTag;

		[Obsolete("This field does not do anything anymore. Use AstarPath.Snapshot instead.")]
		public bool trackChangedNodes;

		public GraphUpdateShape shape;

		internal int internalStage = -1;

		internal const int STAGE_CREATED = -1;

		internal const int STAGE_PENDING = -2;

		internal const int STAGE_ABORTED = -3;

		internal const int STAGE_APPLIED = 0;

		public GraphUpdateStage stage => internalStage switch
		{
			-1 => GraphUpdateStage.Created, 
			0 => GraphUpdateStage.Applied, 
			-3 => GraphUpdateStage.Aborted, 
			_ => GraphUpdateStage.Pending, 
		};

		public virtual void WillUpdateNode(GraphNode node)
		{
		}

		[Obsolete("Use AstarPath.Snapshot instead", true)]
		public virtual void RevertFromBackup()
		{
		}

		public virtual void Apply(GraphNode node)
		{
			if (shape == null || shape.Contains(node))
			{
				node.Penalty = (uint)(node.Penalty + addPenalty);
				if (modifyWalkability)
				{
					node.Walkable = setWalkability;
				}
				if (modifyTag)
				{
					node.Tag = setTag;
				}
			}
		}

		public virtual void ApplyJob(GraphUpdateData data, JobDependencyTracker dependencyTracker)
		{
			if (addPenalty != 0 || modifyWalkability || modifyTag)
			{
				new JobGraphUpdate
				{
					shape = ((shape != null) ? new GraphUpdateShape.BurstShape(shape, Allocator.Persistent) : GraphUpdateShape.BurstShape.Everything),
					data = data,
					bounds = bounds,
					penaltyDelta = addPenalty,
					modifyWalkability = modifyWalkability,
					walkabilityValue = setWalkability,
					modifyTag = modifyTag,
					tagValue = (int)setTag.value
				}.Schedule(dependencyTracker);
			}
		}

		public GraphUpdateObject()
		{
		}

		public GraphUpdateObject(Bounds b)
		{
			bounds = b;
		}
	}
}
