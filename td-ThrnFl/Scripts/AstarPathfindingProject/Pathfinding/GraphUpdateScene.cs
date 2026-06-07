using Pathfinding.Drawing;
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

		public bool convex = true;

		public float minBoundsHeight = 1f;

		public int penaltyDelta;

		public bool modifyWalkability;

		public bool setWalkability;

		public bool applyOnStart = true;

		public bool applyOnScan = true;

		public bool updatePhysics;

		public bool resetPenaltyOnPhysics = true;

		public bool updateErosion = true;

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
		private int setTagCompatibility = -1;

		private static readonly Color GizmoColorSelected = new Color(0.8901961f, 0.23921569f, 0.08627451f, 1f);

		private static readonly Color GizmoColorUnselected = new Color(0.8901961f, 0.23921569f, 0.08627451f, 0.9f);

		public void Start()
		{
			if (Application.isPlaying && !firstApplied && applyOnStart)
			{
				Apply();
			}
		}

		public override void OnPostScan()
		{
			if (applyOnScan)
			{
				Apply();
			}
		}

		public virtual void InvertSettings()
		{
			setWalkability = !setWalkability;
			penaltyDelta = -penaltyDelta;
			if ((uint)setTagInvert == 0)
			{
				setTagInvert = setTag;
				setTag = 0u;
			}
			else
			{
				setTag = setTagInvert;
				setTagInvert = 0u;
			}
		}

		public void RecalcConvex()
		{
			convexPoints = (convex ? Polygon.ConvexHullXZ(points) : null);
		}

		public Bounds GetBounds()
		{
			if (points == null || points.Length == 0)
			{
				Collider component = GetComponent<Collider>();
				Collider2D component2 = GetComponent<Collider2D>();
				Renderer component3 = GetComponent<Renderer>();
				Bounds bounds;
				if (component != null)
				{
					bounds = component.bounds;
				}
				else if (component2 != null)
				{
					bounds = component2.bounds;
					bounds.size = new Vector3(bounds.size.x, bounds.size.y, Mathf.Max(bounds.size.z, 1f));
				}
				else
				{
					if (!(component3 != null))
					{
						return new Bounds(Vector3.zero, Vector3.zero);
					}
					bounds = component3.bounds;
				}
				if (legacyMode && bounds.size.y < minBoundsHeight)
				{
					bounds.size = new Vector3(bounds.size.x, minBoundsHeight, bounds.size.z);
				}
				return bounds;
			}
			if (convexPoints == null)
			{
				RecalcConvex();
			}
			return GraphUpdateShape.GetBounds(convex ? convexPoints : points, (legacyMode && legacyUseWorldSpace) ? Matrix4x4.identity : base.transform.localToWorldMatrix, minBoundsHeight);
		}

		public virtual GraphUpdateObject GetGraphUpdate()
		{
			GraphUpdateObject graphUpdateObject;
			if (points == null || points.Length == 0)
			{
				PolygonCollider2D component = GetComponent<PolygonCollider2D>();
				if (component != null)
				{
					Vector2[] array = component.points;
					Vector3[] array2 = new Vector3[array.Length];
					for (int i = 0; i < array2.Length; i++)
					{
						Vector2 vector = array[i] + component.offset;
						array2[i] = new Vector3(vector.x, 0f, vector.y);
					}
					Matrix4x4 matrix = base.transform.localToWorldMatrix * Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(-90f, 0f, 0f), Vector3.one);
					GraphUpdateShape shape = new GraphUpdateShape(array2, convex, matrix, minBoundsHeight);
					graphUpdateObject = new GraphUpdateObject(GetBounds());
					graphUpdateObject.shape = shape;
				}
				else
				{
					Bounds bounds = GetBounds();
					if (bounds.center == Vector3.zero && bounds.size == Vector3.zero)
					{
						Debug.LogError("Cannot apply GraphUpdateScene, no points defined and no renderer or collider attached", this);
						return null;
					}
					if (bounds.size == Vector3.zero)
					{
						Debug.LogWarning("Collider bounding box was empty. Are you trying to apply the GraphUpdateScene before the collider has been enabled or initialized?", this);
					}
					graphUpdateObject = new GraphUpdateObject(bounds);
				}
			}
			else
			{
				GraphUpdateShape graphUpdateShape;
				if (legacyMode && !legacyUseWorldSpace)
				{
					Vector3[] array3 = new Vector3[points.Length];
					for (int j = 0; j < points.Length; j++)
					{
						array3[j] = base.transform.TransformPoint(points[j]);
					}
					graphUpdateShape = new GraphUpdateShape(array3, convex, Matrix4x4.identity, minBoundsHeight);
				}
				else
				{
					graphUpdateShape = new GraphUpdateShape(points, convex, (legacyMode && legacyUseWorldSpace) ? Matrix4x4.identity : base.transform.localToWorldMatrix, minBoundsHeight);
				}
				graphUpdateObject = new GraphUpdateObject(graphUpdateShape.GetBounds());
				graphUpdateObject.shape = graphUpdateShape;
			}
			firstApplied = true;
			graphUpdateObject.modifyWalkability = modifyWalkability;
			graphUpdateObject.setWalkability = setWalkability;
			graphUpdateObject.addPenalty = penaltyDelta;
			graphUpdateObject.updatePhysics = updatePhysics;
			graphUpdateObject.updateErosion = updateErosion;
			graphUpdateObject.resetPenaltyOnPhysics = resetPenaltyOnPhysics;
			graphUpdateObject.modifyTag = modifyTag;
			graphUpdateObject.setTag = setTag;
			return graphUpdateObject;
		}

		public void Apply()
		{
			if (AstarPath.active == null)
			{
				Debug.LogError("There is no AstarPath object in the scene", this);
				return;
			}
			GraphUpdateObject graphUpdate = GetGraphUpdate();
			if (graphUpdate != null)
			{
				AstarPath.active.UpdateGraphs(graphUpdate);
			}
		}

		public override void DrawGizmos()
		{
			bool flag = GizmoContext.InActiveSelection(this);
			Color color = (flag ? GizmoColorSelected : GizmoColorUnselected);
			if (flag)
			{
				Color color2 = Color.Lerp(color, new Color(1f, 1f, 1f, 0.2f), 0.9f);
				Bounds bounds = GetBounds();
				Draw.SolidBox(bounds.center, bounds.size, color2);
				Draw.WireBox(bounds.center, bounds.size, color2);
			}
			if (points == null)
			{
				return;
			}
			if (convex)
			{
				color.a *= 0.5f;
			}
			Matrix4x4 matrix = ((legacyMode && legacyUseWorldSpace) ? Matrix4x4.identity : base.transform.localToWorldMatrix);
			if (convex)
			{
				color.r -= 0.1f;
				color.g -= 0.2f;
				color.b -= 0.1f;
			}
			using (Draw.WithMatrix(matrix))
			{
				if (flag || !convex)
				{
					Color color3 = color;
					color3.a *= 0.7f;
					Draw.Polyline(points, cycle: true, convex ? color3 : color);
				}
				if (convex)
				{
					if (convexPoints == null)
					{
						RecalcConvex();
					}
					Draw.Polyline(convexPoints, cycle: true, flag ? GizmoColorSelected : GizmoColorUnselected);
				}
				Vector3[] array = (convex ? convexPoints : points);
				if (!flag || array == null || array.Length == 0)
				{
					return;
				}
				float num = array[0].y;
				float num2 = array[0].y;
				for (int i = 0; i < array.Length; i++)
				{
					num = Mathf.Min(num, array[i].y);
					num2 = Mathf.Max(num2, array[i].y);
				}
				float num3 = Mathf.Max(minBoundsHeight - (num2 - num), 0f) * 0.5f;
				num -= num3;
				num2 += num3;
				using (Draw.WithColor(new Color(1f, 1f, 1f, 0.2f)))
				{
					for (int j = 0; j < array.Length; j++)
					{
						int num4 = (j + 1) % array.Length;
						Vector3 a = array[j] + Vector3.up * (num - array[j].y);
						Vector3 vector = array[j] + Vector3.up * (num2 - array[j].y);
						Vector3 b = array[num4] + Vector3.up * (num - array[num4].y);
						Vector3 b2 = array[num4] + Vector3.up * (num2 - array[num4].y);
						Draw.Line(a, vector);
						Draw.Line(a, b);
						Draw.Line(vector, b2);
					}
				}
			}
		}

		public void DisableLegacyMode()
		{
			if (!legacyMode)
			{
				return;
			}
			legacyMode = false;
			if (legacyUseWorldSpace)
			{
				legacyUseWorldSpace = false;
				for (int i = 0; i < points.Length; i++)
				{
					points[i] = base.transform.InverseTransformPoint(points[i]);
				}
				RecalcConvex();
			}
		}

		protected override void OnUpgradeSerializedData(ref Migrations migrations, bool unityThread)
		{
			if (migrations.TryMigrateFromLegacyFormat(out var legacyVersion))
			{
				if (legacyVersion == 0 && points != null && points.Length != 0)
				{
					legacyMode = true;
				}
				if (setTagCompatibility != -1)
				{
					setTag = (uint)setTagCompatibility;
					setTagCompatibility = -1;
				}
			}
		}
	}
}
