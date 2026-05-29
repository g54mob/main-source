using Pathfinding.Util;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pathfinding
{
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_navmesh_add.php")]
	public class NavmeshAdd : NavmeshClipper
	{
		public enum MeshType
		{
			Rectangle = 0,
			CustomMesh = 1
		}

		public MeshType type;

		public Mesh mesh;

		private Vector3[] verts;

		private int[] tris;

		public Vector2 rectangleSize;

		public float meshScale;

		public Vector3 center;

		[FormerlySerializedAs("useRotation")]
		public bool useRotationAndScale;

		[Tooltip("Distance between positions to require an update of the navmesh\nA smaller distance gives better accuracy, but requires more updates when moving the object over time, so it is often slower.")]
		public float updateDistance;

		[Tooltip("How many degrees rotation that is required for an update to the navmesh. Should be between 0 and 180.")]
		public float updateRotationDistance;

		protected Transform tr;

		private Vector3 lastPosition;

		private Quaternion lastRotation;

		public static readonly Color GizmoColor;

		public Vector3 Center => default(Vector3);

		public override bool RequiresUpdate()
		{
			return false;
		}

		public override void ForceUpdate()
		{
		}

		protected override void Awake()
		{
		}

		internal override void NotifyUpdated()
		{
		}

		[ContextMenu("Rebuild Mesh")]
		public void RebuildMesh()
		{
		}

		public override Rect GetBounds(GraphTransform inverseTransform)
		{
			return default(Rect);
		}

		public void GetMesh(ref Int3[] vbuffer, out int[] tbuffer, GraphTransform inverseTransform = null)
		{
			tbuffer = null;
		}
	}
}
