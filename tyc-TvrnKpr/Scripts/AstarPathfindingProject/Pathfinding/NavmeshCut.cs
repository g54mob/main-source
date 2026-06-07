using System.Collections.Generic;
using Pathfinding.Collections;
using Pathfinding.Serialization;
using Pathfinding.Util;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pathfinding
{
	[AddComponentMenu("Pathfinding/Navmesh/Navmesh Cut")]
	[ExecuteAlways]
	[HelpURL("https://arongranberg.com/astar/documentation/stable/navmeshcut.html")]
	public class NavmeshCut : NavmeshClipper
	{
		public enum MeshType
		{
			Rectangle = 0,
			Circle = 1,
			CustomMesh = 2,
			Box = 3,
			Sphere = 4,
			Capsule = 5
		}

		public enum RadiusExpansionMode
		{
			DontExpand = 0,
			ExpandByAgentRadius = 1
		}

		public struct Contour
		{
			public float ymin;

			public float ymax;

			public List<Vector2> contour;
		}

		public struct ContourBurst
		{
			public int startIndex;

			public int endIndex;

			public float ymin;

			public float ymax;
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

		public RadiusExpansionMode radiusExpansionMode;

		public bool cutsAddedGeom;

		[Tooltip("How many degrees rotation that is required for an update to the navmesh. Should be between 0 and 180.")]
		public float updateRotationDistance;

		[Tooltip("Includes rotation in calculations. This is slower since a lot more matrix multiplications are needed but gives more flexibility.")]
		[FormerlySerializedAs("useRotation")]
		public bool useRotationAndScale;

		private NativeList<float3> meshContourVertices;

		private NativeList<ContourBurst> meshContours;

		protected Transform tr;

		private Mesh lastMesh;

		private static readonly Dictionary<Vector2Int, int> edges;

		private static readonly Dictionary<int, int> pointers;

		public static readonly Color GizmoColor;

		public static readonly Color GizmoColor2;

		private Matrix4x4 contourTransformationMatrix => default(Matrix4x4);

		protected override void Awake()
		{
		}

		protected override void OnDisable()
		{
		}

		public override void ForceUpdate()
		{
		}

		public override bool RequiresUpdate(GridLookup<NavmeshClipper>.Root previousState)
		{
			return false;
		}

		public virtual void UsedForCut()
		{
		}

		public override void NotifyUpdated(GridLookup<NavmeshClipper>.Root previousState)
		{
		}

		private void CalculateMeshContour()
		{
		}

		public override Bounds GetBounds(GraphTransform inverseTransform, float radiusMargin)
		{
			return default(Bounds);
		}

		public void GetContour(List<Contour> buffer, Matrix4x4 matrix, float radiusMargin)
		{
		}

		public unsafe void GetContourBurst(UnsafeList<float2>* outputVertices, UnsafeList<ContourBurst>* outputContours, Matrix4x4 matrix, float radiusMargin)
		{
		}

		private static NavmeshBase ClosestGraph(Vector3 position)
		{
			return null;
		}

		public override void DrawGizmos()
		{
		}

		protected override void OnUpgradeSerializedData(ref Migrations migrations, bool unityThread)
		{
		}
	}
}
