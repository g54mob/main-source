using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_dynamic_grid_obstacle.php")]
	public class DynamicGridObstacle : GraphModifier
	{
		private Collider coll;

		private Collider2D coll2D;

		private Transform tr;

		public float updateError;

		public float checkTime;

		private Bounds prevBounds;

		private Quaternion prevRotation;

		private bool prevEnabled;

		private float lastCheckTime;

		private Queue<GraphUpdateObject> pendingGraphUpdates;

		private Bounds bounds => default(Bounds);

		private bool colliderEnabled => false;

		protected override void Awake()
		{
		}

		public override void OnPostScan()
		{
		}

		private void Update()
		{
		}

		protected override void OnDisable()
		{
		}

		public void DoUpdateGraphs()
		{
		}

		private static float BoundsVolume(Bounds b)
		{
			return 0f;
		}
	}
}
