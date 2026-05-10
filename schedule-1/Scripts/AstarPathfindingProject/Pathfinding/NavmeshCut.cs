using System.Collections.Generic;
using Pathfinding.Util;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pathfinding
{
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_navmesh_cut.php")]
	[AddComponentMenu("Pathfinding/Navmesh/Navmesh Cut")]
	public class NavmeshCut : NavmeshClipper
	{
		public enum MeshType
		{
			Rectangle = 0,
			Circle = 1,
			CustomMesh = 2
		}

		[Tooltip("Shape of the cut")]
		public MeshType type;

		[Tooltip("The contour(s) of the mesh will be extracted. This mesh should only be a 2D surface, not a volume (see documentation).")]
		public Mesh mesh;

		public Vector2 rectangleSize;

		public float circleRadius;

		public int circleResolution;

		public float height;

		[Tooltip("Scale of the custom mesh")]
		public float meshScale;

		public Vector3 center;

		[Tooltip("Distance between positions to require an update of the navmesh\nA smaller distance gives better accuracy, but requires more updates when moving the object over time, so it is often slower.")]
		public float updateDistance;

		[Tooltip("Only makes a split in the navmesh, but does not remove the geometry to make a hole")]
		public bool isDual;

		public bool cutsAddedGeom;

		[Tooltip("How many degrees rotation that is required for an update to the navmesh. Should be between 0 and 180.")]
		public float updateRotationDistance;

		[Tooltip("Includes rotation in calculations. This is slower since a lot more matrix multiplications are needed but gives more flexibility.")]
		[FormerlySerializedAs("useRotation")]
		public bool useRotationAndScale;

		private Vector3[][] contours;

		protected Transform tr;

		private Mesh lastMesh;

		private Vector3 lastPosition;

		private Quaternion lastRotation;

		private static readonly Dictionary<Int2, int> edges;

		private static readonly Dictionary<int, int> pointers;

		public static readonly Color GizmoColor;

		protected override void Awake()
		{
		}

		protected override void OnEnable()
		{
		}

		public override void ForceUpdate()
		{
		}

		public override bool RequiresUpdate()
		{
			return false;
		}

		public virtual void UsedForCut()
		{
		}

		internal override void NotifyUpdated()
		{
		}

		private void CalculateMeshContour()
		{
		}

		public override Rect GetBounds(GraphTransform inverseTransform)
		{
			return default(Rect);
		}

		public void GetContour(List<List<Vector3>> buffer)
		{
		}

		private void TransformBuffer(List<Vector3> buffer, bool reverse)
		{
		}

		public void OnDrawGizmos()
		{
		}

		internal float GetY(GraphTransform transform)
		{
			return 0f;
		}

		public void OnDrawGizmosSelected()
		{
		}
	}
}
