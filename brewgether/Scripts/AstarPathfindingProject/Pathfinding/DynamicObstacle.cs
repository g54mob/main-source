using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
	[AddComponentMenu("Pathfinding/Dynamic Obstacle")]
	[HelpURL("https://arongranberg.com/astar/documentation/stable/dynamicobstacle.html")]
	public class DynamicObstacle : GraphModifier, DynamicGridObstacle
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

		float DynamicGridObstacle.updateError
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		float DynamicGridObstacle.checkTime
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		bool DynamicGridObstacle.enabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

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
