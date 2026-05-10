using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
	[Serializable]
	public class StartEndModifier : PathModifier
	{
		public enum Exactness
		{
			SnapToNode = 0,
			Original = 1,
			Interpolate = 2,
			ClosestOnNode = 3,
			NodeConnection = 4
		}

		public bool addPoints;

		public Exactness exactStartPoint;

		public Exactness exactEndPoint;

		public Func<Vector3> adjustStartPoint;

		public bool useRaycasting;

		public LayerMask mask;

		public bool useGraphRaycasting;

		private List<GraphNode> connectionBuffer;

		private Action<GraphNode> connectionBufferAddDelegate;

		public override int Order => 0;

		public override void Apply(Path _p)
		{
		}

		private Vector3 Snap(ABPath path, Exactness mode, bool start, out bool forceAddPoint, out int closestConnectionIndex)
		{
			forceAddPoint = default(bool);
			closestConnectionIndex = default(int);
			return default(Vector3);
		}

		protected Vector3 GetClampedPoint(Vector3 from, Vector3 to, GraphNode hint)
		{
			return default(Vector3);
		}
	}
}
