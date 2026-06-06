using Pathfinding.Collections;
using Pathfinding.Util;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pathfinding
{
	[HelpURL("https://arongranberg.com/astar/documentation/stable/navmeshadd.html")]
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

		public static readonly Color GizmoColor;

		public Vector3 Center => default(Vector3);

		public override bool RequiresUpdate(GridLookup<NavmeshClipper>.Root previousState)
		{
			return false;
		}

		public override void ForceUpdate()
		{
		}

		protected override void Awake()
		{
		}

		public override void NotifyUpdated(GridLookup<NavmeshClipper>.Root previousState)
		{
		}

		[ContextMenu("Rebuild Mesh")]
		public void RebuildMesh()
		{
		}

		public override Rect GetBounds(GraphTransform inverseTransform, float radiusMargin)
		{
			return default(Rect);
		}

		public void GetMesh(ref Int3[] vbuffer, out int[] tbuffer, out int vertexCount, GraphTransform inverseTransform = null)
		{
			tbuffer = null;
			vertexCount = default(int);
		}
	}
}
