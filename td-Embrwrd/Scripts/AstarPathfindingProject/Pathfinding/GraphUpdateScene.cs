using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pathfinding
{
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_graph_update_scene.php")]
	[AddComponentMenu("Pathfinding/GraphUpdateScene")]
	public class GraphUpdateScene : GraphModifier
	{
		public Vector3[] points;

		private Vector3[] convexPoints;

		public bool convex;

		public float minBoundsHeight;

		public int penaltyDelta;

		public bool modifyWalkability;

		public bool setWalkability;

		public bool applyOnStart;

		public bool applyOnScan;

		public bool updatePhysics;

		public bool resetPenaltyOnPhysics;

		public bool updateErosion;

		public bool modifyTag;

		public int setTag;

		[HideInInspector]
		public bool legacyMode;

		private int setTagInvert;

		private bool firstApplied;

		[SerializeField]
		private int serializedVersion;

		[SerializeField]
		[FormerlySerializedAs("useWorldSpace")]
		private bool legacyUseWorldSpace;

		public void Start()
		{
		}

		public override void OnPostScan()
		{
		}

		public virtual void InvertSettings()
		{
		}

		public void RecalcConvex()
		{
		}

		[Obsolete("World space can no longer be used as it does not work well with rotated graphs. Use transform.InverseTransformPoint to transform points to local space.", true)]
		private void ToggleUseWorldSpace()
		{
		}

		[Obsolete("The Y coordinate is no longer important. Use the position of the object instead", true)]
		public void LockToY()
		{
		}

		public Bounds GetBounds()
		{
			return default(Bounds);
		}

		public void Apply()
		{
		}

		private void OnDrawGizmos()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}

		private void OnDrawGizmos(bool selected)
		{
		}

		public void DisableLegacyMode()
		{
		}

		protected override void Awake()
		{
		}
	}
}
