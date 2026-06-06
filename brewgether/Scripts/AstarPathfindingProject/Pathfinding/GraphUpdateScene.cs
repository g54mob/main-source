using Pathfinding.Serialization;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pathfinding
{
	[AddComponentMenu("Pathfinding/GraphUpdateScene")]
	[HelpURL("https://arongranberg.com/astar/documentation/stable/graphupdatescene.html")]
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

		public PathfindingTag setTag;

		[HideInInspector]
		public bool legacyMode;

		private PathfindingTag setTagInvert;

		private bool firstApplied;

		[SerializeField]
		[FormerlySerializedAs("useWorldSpace")]
		private bool legacyUseWorldSpace;

		[SerializeField]
		[FormerlySerializedAs("setTag")]
		private int setTagCompatibility;

		private static readonly Color GizmoColorSelected;

		private static readonly Color GizmoColorUnselected;

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

		public Bounds GetBounds()
		{
			return default(Bounds);
		}

		public virtual GraphUpdateObject GetGraphUpdate()
		{
			return null;
		}

		public void Apply()
		{
		}

		public override void DrawGizmos()
		{
		}

		public void DisableLegacyMode()
		{
		}

		protected override void OnUpgradeSerializedData(ref Migrations migrations, bool unityThread)
		{
		}
	}
}
