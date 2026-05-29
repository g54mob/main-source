using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
	public class GraphUpdateObject
	{
		public Bounds bounds;

		public bool updatePhysics;

		public bool resetPenaltyOnPhysics;

		public bool updateErosion;

		public NNConstraint nnConstraint;

		public int addPenalty;

		public bool modifyWalkability;

		public bool setWalkability;

		public bool modifyTag;

		public int setTag;

		public bool trackChangedNodes;

		public List<GraphNode> changedNodes;

		private List<uint> backupData;

		private List<Int3> backupPositionData;

		public GraphUpdateShape shape;

		internal int internalStage;

		internal const int STAGE_CREATED = -1;

		internal const int STAGE_PENDING = -2;

		internal const int STAGE_ABORTED = -3;

		internal const int STAGE_APPLIED = 0;

		[Obsolete("Not necessary anymore")]
		public bool requiresFloodFill
		{
			set
			{
			}
		}

		public GraphUpdateStage stage => default(GraphUpdateStage);

		public virtual void WillUpdateNode(GraphNode node)
		{
		}

		public virtual void RevertFromBackup()
		{
		}

		public virtual void Apply(GraphNode node)
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
