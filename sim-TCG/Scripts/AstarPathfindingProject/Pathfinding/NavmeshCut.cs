using System;
using System.Collections.Generic;
using Pathfinding.Drawing;
using Pathfinding.Graphs.Util;
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
		public MeshType type = MeshType.Box;

		[Tooltip("The contour(s) of the mesh will be extracted. This mesh should only be a 2D surface, not a volume (see documentation).")]
		public Mesh mesh;

		public Vector2 rectangleSize = new Vector2(1f, 1f);

		public float circleRadius = 1f;

		public int circleResolution = 6;

		public float height = 1f;

		[Tooltip("Scale of the custom mesh")]
		public float meshScale = 1f;

		public Vector3 center;

		[Tooltip("Distance between positions to require an update of the navmesh\nA smaller distance gives better accuracy, but requires more updates when moving the object over time, so it is often slower.")]
		public float updateDistance = 0.4f;

		[Tooltip("Only makes a split in the navmesh, but does not remove the geometry to make a hole")]
		public bool isDual;

		public RadiusExpansionMode radiusExpansionMode = RadiusExpansionMode.ExpandByAgentRadius;

		public bool cutsAddedGeom = true;

		[Tooltip("How many degrees rotation that is required for an update to the navmesh. Should be between 0 and 180.")]
		public float updateRotationDistance = 10f;

		[Tooltip("Includes rotation in calculations. This is slower since a lot more matrix multiplications are needed but gives more flexibility.")]
		[FormerlySerializedAs("useRotation")]
		public bool useRotationAndScale;

		private NativeList<float3> meshContourVertices;

		private NativeList<ContourBurst> meshContours;

		protected Transform tr;

		private Mesh lastMesh;

		private static readonly Dictionary<Int2, int> edges = new Dictionary<Int2, int>();

		private static readonly Dictionary<int, int> pointers = new Dictionary<int, int>();

		public static readonly Color GizmoColor = new Color(0.14509805f, 0.72156864f, 0.9372549f);

		public static readonly Color GizmoColor2 = new Color(0.6627451f, 0.36078432f, 0.9490196f);

		private Matrix4x4 contourTransformationMatrix
		{
			get
			{
				if (useRotationAndScale)
				{
					return tr.localToWorldMatrix * Matrix4x4.Translate(center);
				}
				return Matrix4x4.Translate(tr.position + center);
			}
		}

		protected override void Awake()
		{
			base.Awake();
			tr = base.transform;
		}

		protected override void OnDisable()
		{
			if (meshContourVertices.IsCreated)
			{
				meshContourVertices.Dispose();
			}
			if (meshContours.IsCreated)
			{
				meshContours.Dispose();
			}
			lastMesh = null;
			base.OnDisable();
		}

		public override void ForceUpdate()
		{
			if (AstarPath.active != null)
			{
				AstarPath.active.navmeshUpdates.ForceUpdateAround(this);
			}
		}

		public override bool RequiresUpdate(GridLookup<NavmeshClipper>.Root previousState)
		{
			if (!((tr.position - previousState.previousPosition).sqrMagnitude > updateDistance * updateDistance))
			{
				if (useRotationAndScale)
				{
					return Quaternion.Angle(previousState.previousRotation, tr.rotation) > updateRotationDistance;
				}
				return false;
			}
			return true;
		}

		public virtual void UsedForCut()
		{
		}

		internal override void NotifyUpdated(GridLookup<NavmeshClipper>.Root previousState)
		{
			previousState.previousPosition = tr.position;
			if (useRotationAndScale)
			{
				previousState.previousRotation = tr.rotation;
			}
		}

		private void CalculateMeshContour()
		{
			if (mesh == null)
			{
				return;
			}
			edges.Clear();
			pointers.Clear();
			Vector3[] vertices = mesh.vertices;
			int[] triangles = mesh.triangles;
			for (int i = 0; i < triangles.Length; i += 3)
			{
				if (VectorMath.IsClockwiseXZ(vertices[triangles[i]], vertices[triangles[i + 1]], vertices[triangles[i + 2]]))
				{
					int num = triangles[i];
					triangles[i] = triangles[i + 2];
					triangles[i + 2] = num;
				}
				edges[new Int2(triangles[i], triangles[i + 1])] = i;
				edges[new Int2(triangles[i + 1], triangles[i + 2])] = i;
				edges[new Int2(triangles[i + 2], triangles[i])] = i;
			}
			for (int j = 0; j < triangles.Length; j += 3)
			{
				for (int k = 0; k < 3; k++)
				{
					if (!edges.ContainsKey(new Int2(triangles[j + (k + 1) % 3], triangles[j + k % 3])))
					{
						pointers[triangles[j + k % 3]] = triangles[j + (k + 1) % 3];
					}
				}
			}
			NativeList<float3> nativeList = new NativeList<float3>(Allocator.Persistent);
			NativeList<ContourBurst> nativeList2 = new NativeList<ContourBurst>(Allocator.Persistent);
			for (int l = 0; l < vertices.Length; l++)
			{
				if (!pointers.ContainsKey(l))
				{
					continue;
				}
				int length = nativeList.Length;
				int num2 = l;
				do
				{
					int num3 = pointers[num2];
					if (num3 == -1)
					{
						break;
					}
					pointers[num2] = -1;
					nativeList.Add((float3)vertices[num2]);
					num2 = num3;
				}
				while (num2 != l);
				if (nativeList.Length != length)
				{
					ContourBurst value = new ContourBurst
					{
						startIndex = length,
						endIndex = nativeList.Length,
						ymin = 0f,
						ymax = 0f
					};
					nativeList2.Add(in value);
				}
			}
			if (meshContourVertices.IsCreated)
			{
				meshContourVertices.Dispose();
			}
			if (meshContours.IsCreated)
			{
				meshContours.Dispose();
			}
			meshContourVertices = nativeList;
			meshContours = nativeList2;
		}

		public override Rect GetBounds(GraphTransform inverseTransform, float radiusMargin)
		{
			List<Contour> list = ListPool<Contour>.Claim();
			GetContour(list, inverseTransform.inverseMatrix, radiusMargin);
			Rect result = default(Rect);
			for (int i = 0; i < list.Count; i++)
			{
				List<Vector2> list2 = list[i].contour;
				for (int j = 0; j < list2.Count; j++)
				{
					Vector2 vector = list2[j];
					if (j == 0 && i == 0)
					{
						result = new Rect(vector.x, vector.y, 0f, 0f);
						continue;
					}
					result.xMax = Math.Max(result.xMax, vector.x);
					result.yMax = Math.Max(result.yMax, vector.y);
					result.xMin = Math.Min(result.xMin, vector.x);
					result.yMin = Math.Min(result.yMin, vector.y);
				}
				ListPool<Vector2>.Release(ref list2);
			}
			ListPool<Contour>.Release(ref list);
			return result;
		}

		public unsafe void GetContour(List<Contour> buffer, Matrix4x4 matrix, float radiusMargin)
		{
			UnsafeList<float2> unsafeList = new UnsafeList<float2>(0, Allocator.Temp);
			UnsafeList<ContourBurst> unsafeList2 = new UnsafeList<ContourBurst>(1, Allocator.Temp);
			GetContourBurst(&unsafeList, &unsafeList2, matrix, radiusMargin);
			for (int i = 0; i < unsafeList2.Length; i++)
			{
				List<Vector2> list = ListPool<Vector2>.Claim();
				ContourBurst contourBurst = unsafeList2[i];
				for (int j = contourBurst.startIndex; j < contourBurst.endIndex; j++)
				{
					list.Add(unsafeList[j]);
				}
				buffer.Add(new Contour
				{
					ymin = contourBurst.ymin,
					ymax = contourBurst.ymax,
					contour = list
				});
			}
			unsafeList.Dispose();
			unsafeList2.Dispose();
		}

		public unsafe void GetContourBurst(UnsafeList<float2>* outputVertices, UnsafeList<ContourBurst>* outputContours, Matrix4x4 matrix, float radiusMargin)
		{
			if (radiusExpansionMode == RadiusExpansionMode.DontExpand)
			{
				radiusMargin = 0f;
			}
			if (type == MeshType.CustomMesh && (mesh != lastMesh || !meshContours.IsCreated || !meshContourVertices.IsCreated))
			{
				CalculateMeshContour();
				lastMesh = mesh;
			}
			NavmeshCutJobs.JobCalculateContour jobCalculateContour = new NavmeshCutJobs.JobCalculateContour
			{
				outputVertices = outputVertices,
				outputContours = outputContours,
				matrix = matrix,
				localToWorldMatrix = contourTransformationMatrix,
				radiusMargin = radiusMargin,
				circleResolution = circleResolution,
				circleRadius = circleRadius,
				rectangleSize = rectangleSize,
				height = height,
				meshType = type,
				meshContours = meshContours.GetUnsafeList(),
				meshContourVertices = meshContourVertices.GetUnsafeList(),
				meshScale = meshScale
			};
			NavmeshCutJobsCached.CalculateContourBurst(&jobCalculateContour);
		}

		public unsafe override void DrawGizmos()
		{
			if (tr == null)
			{
				tr = base.transform;
			}
			bool flag = GizmoContext.InActiveSelection(tr);
			NavmeshBase navmeshBase = (NavmeshBase)((AstarPath.active != null) ? (((object)AstarPath.active.data.recastGraph) ?? ((object)AstarPath.active.data.navmesh)) : null);
			GraphTransform graphTransform = ((navmeshBase != null) ? navmeshBase.transform : GraphTransform.identityTransform);
			float radiusMargin = navmeshBase?.NavmeshCuttingCharacterRadius ?? 0f;
			UnsafeList<float2> unsafeList = new UnsafeList<float2>(0, Allocator.Temp);
			UnsafeList<ContourBurst> unsafeList2 = new UnsafeList<ContourBurst>(0, Allocator.Temp);
			GetContourBurst(&unsafeList, &unsafeList2, graphTransform.inverseMatrix, radiusMargin);
			Color color = Color.Lerp(GizmoColor, Color.white, 0.5f);
			color.a *= 0.5f;
			using (Draw.WithColor(color))
			{
				for (int i = 0; i < unsafeList2.Length; i++)
				{
					ContourBurst contourBurst = unsafeList2[i];
					float y = (contourBurst.ymin + contourBurst.ymax) * 0.5f;
					int num = contourBurst.endIndex - contourBurst.startIndex;
					for (int j = 0; j < num; j++)
					{
						float2 float5 = unsafeList[contourBurst.startIndex + j];
						float2 float6 = unsafeList[contourBurst.startIndex + (j + 1) % num];
						Vector3 vector = new Vector3(float5.x, y, float5.y);
						Vector3 vector2 = new Vector3(float6.x, y, float6.y);
						Draw.Line(graphTransform.Transform(vector), graphTransform.Transform(vector2), GizmoColor);
						if (flag)
						{
							Vector3 point = vector;
							Vector3 point2 = vector2;
							Vector3 point3 = vector;
							Vector3 point4 = vector2;
							point.y = (point2.y = contourBurst.ymin);
							point3.y = (point4.y = contourBurst.ymax);
							Draw.Line(graphTransform.Transform(point), graphTransform.Transform(point2));
							Draw.Line(graphTransform.Transform(point3), graphTransform.Transform(point4));
							Draw.Line(graphTransform.Transform(point), graphTransform.Transform(point3));
						}
					}
				}
			}
			if (flag)
			{
				switch (type)
				{
				case MeshType.Box:
					using (Draw.WithMatrix(contourTransformationMatrix * Matrix4x4.Scale(new Vector3(rectangleSize.x, height, rectangleSize.y))))
					{
						Draw.WireBox(Vector3.zero, Vector3.one, GizmoColor2);
					}
					break;
				case MeshType.Capsule:
				{
					Matrix4x4 matrix4x = contourTransformationMatrix;
					float num3 = Mathf.Max(height, circleRadius * 2f);
					float x = math.length(matrix4x.GetColumn(0));
					float y2 = math.length(matrix4x.GetColumn(2));
					float num4 = circleRadius * math.max(x, y2);
					Vector3 normalized = ((Vector3)matrix4x.GetColumn(1)).normalized;
					Vector3 vector3 = contourTransformationMatrix.MultiplyPoint3x4(new Vector3(0f, num3 * 0.5f, 0f)) - normalized * num4;
					Draw.WireCapsule(end: contourTransformationMatrix.MultiplyPoint3x4(-new Vector3(0f, num3 * 0.5f, 0f)) + normalized * num4, start: vector3, radius: num4, color: GizmoColor2);
					break;
				}
				case MeshType.Sphere:
				{
					float num2 = (useRotationAndScale ? math.cmax(tr.lossyScale) : 1f);
					using (Draw.WithMatrix(Matrix4x4.TRS(tr.position, useRotationAndScale ? tr.rotation : Quaternion.identity, Vector3.one * num2) * Matrix4x4.Translate(center)))
					{
						Draw.WireSphere(Vector3.zero, circleRadius, GizmoColor2);
					}
					break;
				}
				case MeshType.CustomMesh:
					if (mesh != null)
					{
						using (Draw.WithMatrix(contourTransformationMatrix * Matrix4x4.Scale(Vector3.one * meshScale)))
						{
							Draw.WireMesh(mesh, GizmoColor2);
						}
					}
					break;
				}
			}
			unsafeList.Dispose();
			unsafeList2.Dispose();
		}

		protected override void OnUpgradeSerializedData(ref Migrations migrations, bool unityThread)
		{
			if (migrations.TryMigrateFromLegacyFormat(out var legacyVersion) && legacyVersion < 2)
			{
				radiusExpansionMode = RadiusExpansionMode.DontExpand;
			}
		}
	}
}
