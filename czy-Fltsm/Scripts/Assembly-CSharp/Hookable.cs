using System;
using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Construction))]
public class Hookable : MonoBehaviour, IBuildableExtendable, IPersistentReference
{
	public class Edge
	{
		public Vector3 StartPoint;

		public Vector3 EndPoint;

		public Vector3 Center;

		public Vector3 Vector;

		public Vector3 InwardNormal;

		public Vector3[] GridPoints;

		public Edge(Transform startPointTransform, Transform endPointTransform)
		{
			StartPoint = FlotsamGame.SetY(startPointTransform.position, 0f);
			EndPoint = FlotsamGame.SetY(endPointTransform.position, 0f);
			Center = (StartPoint + EndPoint) / 2f;
			Vector = EndPoint - StartPoint;
			InwardNormal = Vector3.Cross(Vector, Vector3.up);
			float num = GameSettings.Instance.BuildableSettings.GridSize;
			int num2 = (int)((float)System.Math.Round(Vector.magnitude, 1) / num) + 1;
			GridPoints = new Vector3[num2];
			Vector3 normalized = Vector.normalized;
			for (int i = 0; i < num2; i++)
			{
				float num3 = (float)i * num;
				GridPoints[i] = StartPoint + normalized * num3;
			}
			Vector.Normalize();
			InwardNormal.Normalize();
		}

		public void DrawGizmos(Color color)
		{
			Color color2 = Gizmos.color;
			Gizmos.color = color;
			Gizmos.DrawLine(StartPoint, EndPoint);
			Gizmos.DrawSphere(Center, 0.1f);
			Gizmos.DrawLine(Center, Center + InwardNormal);
			Gizmos.color = Color.red;
			Vector3[] gridPoints = GridPoints;
			foreach (Vector3 vector in gridPoints)
			{
				Gizmos.DrawSphere(vector, 0.1f);
				Gizmos.DrawLine(vector, vector + InwardNormal);
			}
			Gizmos.color = color2;
		}
	}

	public class Hook
	{
		public Edge Edge;

		public Vector3 Projection;

		public float SqrDistance;

		public float SqrDistanceToCenter;

		public Vector3 Forward => Edge.InwardNormal;

		public Vector3 Right => Edge.Vector;

		public Vector3 ReturnHookedPosition(Vector3 position, float distance)
		{
			Vector3 vector = Edge.InwardNormal * distance;
			return position - vector;
		}

		public Vector3 ReturnPosition(Vector3 position, bool snap, out int gridIndex)
		{
			if (snap)
			{
				return ReturnClosestGridPosition(position, out gridIndex);
			}
			gridIndex = 0;
			return Projection;
		}

		private Vector3 ReturnClosestGridPosition(Vector3 position, out int gridIndex)
		{
			gridIndex = 0;
			Vector3 result = Edge.Center;
			float num = float.MaxValue;
			for (int i = 0; i < Edge.GridPoints.Length; i++)
			{
				Vector3 vector = Edge.GridPoints[i];
				float magnitude = (position - vector).magnitude;
				if (magnitude < num)
				{
					result = vector;
					num = magnitude;
					gridIndex = i;
				}
			}
			return result;
		}

		public bool HasMatchingEdge(Hook other)
		{
			if (other == this)
			{
				return true;
			}
			float num = Vector3.Angle(other.Edge.StartPoint - Edge.StartPoint, Edge.Vector);
			if (!(num < 1f))
			{
				return num > 179f;
			}
			return true;
		}
	}

	public float HookHeightOffset;

	[FormerlySerializedAs("AngleCanAdjustHook")]
	public bool RotateAroundHook;

	[ConditionalHide(false, ConditionalSourceField = "RotateAroundHook")]
	public float RotateRadius = 1f;

	private Edge[] _edges;

	private Color _gizmoColor;

	private WalkwaySegment _walkwaySegment;

	private bool _isHookable;

	private List<WalkwaySegment> _segmentsToBuildPontonFor;

	public static List<Hookable> Hookables = new List<Hookable>();

	public bool Active { get; private set; }

	public int PersistentIndex { get; set; } = -1;

	public Buildable Buildable { get; private set; }

	public Construction Construction { get; private set; }

	private void LateUpdate()
	{
		bool flag = IsHookable(Buildable);
		if (_isHookable != flag)
		{
			_isHookable = flag;
			if (_isHookable)
			{
				Hookables.AddUnique(this);
			}
			else
			{
				Hookables.Remove(this);
			}
		}
	}

	private void OnDestroy()
	{
		Hookables.Remove(this);
	}

	private void OnDrawGizmosSelected()
	{
		if (_edges != null)
		{
			Edge[] edges = _edges;
			for (int i = 0; i < edges.Length; i++)
			{
				edges[i].DrawGizmos(_gizmoColor);
			}
		}
	}

	public void Initialize(Buildable buildable, bool restored = false)
	{
		Buildable = buildable;
		_isHookable = IsHookable(buildable);
		if (_isHookable)
		{
			Hookables.AddUnique(this);
		}
		InitializeEdges(buildable);
		_gizmoColor = UnityEngine.Random.ColorHSV();
		if (Buildable.TryReturnBuildableExtendable<Construction>(out var buildableExtendable))
		{
			Construction = buildableExtendable;
			_walkwaySegment = GetComponent<WalkwaySegment>();
			return;
		}
		throw new NotImplementedException($"Hookable {Buildable.Properties.Name} has no construction component.");
	}

	private void InitializeEdges(Buildable buildable)
	{
		int count = buildable.OutlineCorners.Count;
		if (_edges.IsNullOrEmpty())
		{
			_edges = new Edge[count];
		}
		for (int i = 0; i < count; i++)
		{
			Edge edge = new Edge(buildable.OutlineCorners[(int)Mathf.Repeat(i + 1, count)], buildable.OutlineCorners[i]);
			_edges[i] = edge;
		}
	}

	public static bool TryReturnClosestIntersection(out Vector2 closestIntersection, Vector2 start, Vector2 end, Hookable illegalHook = null)
	{
		float num = Vector2.Distance(start, end);
		closestIntersection = Vector2.zero;
		bool result = false;
		foreach (Hookable hookable in Hookables)
		{
			if (hookable == illegalHook)
			{
				continue;
			}
			hookable.Buildable.OutlinePolygon.FastUpdate();
			if (hookable.Buildable.OutlinePolygon.ReturnIsLineIntersecting(start, end, out var closestIntersection2))
			{
				float num2 = Vector2.Distance(start, closestIntersection2);
				if (num2 < num)
				{
					num = num2;
					closestIntersection = closestIntersection2;
					result = true;
				}
			}
		}
		return result;
	}

	public static bool TryHook(out Hook closestHook, out Hookable closestHookable, float snapDistance, Vector3 pointToHook, Hookable illegalHook, bool construction = true, Vector3 hookDirection = default(Vector3), float hookableWidth = 0f)
	{
		float num = snapDistance * snapDistance;
		float num2 = num;
		float num3 = float.MaxValue;
		closestHook = null;
		closestHookable = null;
		foreach (Hookable hookable in Hookables)
		{
			if (hookable == illegalHook || (construction && !hookable.CanHookConstruction()) || !hookable.TryToHookPoint(pointToHook, num, out var hook, hookDirection, hookableWidth))
			{
				continue;
			}
			if (Mathf.Approximately(hook.SqrDistance, num2))
			{
				if (num3 <= hook.SqrDistanceToCenter)
				{
					continue;
				}
			}
			else
			{
				if (!(hook.SqrDistance < num2))
				{
					continue;
				}
				num2 = hook.SqrDistance;
			}
			num3 = hook.SqrDistanceToCenter;
			closestHook = hook;
			closestHookable = hookable;
		}
		return closestHook != null;
	}

	public bool TryToHookPoint(Vector3 pointToHook, float sqrMaximumDistance, out Hook hook, Vector3 hookDirection = default(Vector3), float hookableWidth = 0f)
	{
		if (TryReturnClosestEdge(pointToHook, sqrMaximumDistance, out var closestEdge, out var sqrSmallestDistance, out var closestEdgeProjection) && !IsHookingParallelToEdge(closestEdge, sqrSmallestDistance, hookDirection, hookableWidth))
		{
			hook = new Hook
			{
				Edge = closestEdge,
				Projection = closestEdgeProjection,
				SqrDistance = sqrSmallestDistance,
				SqrDistanceToCenter = (closestEdge.Center - pointToHook).sqrMagnitude
			};
			return true;
		}
		hook = null;
		return false;
	}

	private bool IsHookingParallelToEdge(Edge edge, float sqrDistance, Vector3 hookDirection, float hookableWidth)
	{
		if (hookDirection != Vector3.zero && MathExtensions.Approximately(Mathf.Abs(Vector3.Dot(edge.Vector.normalized, hookDirection)), 1f))
		{
			return MathExtensions.Approximately(sqrDistance, hookableWidth * hookableWidth);
		}
		return false;
	}

	public bool TryReturnClosestEdge(Vector3 point, float sqrMaximumDistance, out Edge closestEdge, out float sqrSmallestDistance, out Vector3 closestEdgeProjection)
	{
		sqrSmallestDistance = sqrMaximumDistance;
		closestEdge = null;
		closestEdgeProjection = Vector3.zero;
		Vector3 projectedPoint = Vector3.zero;
		Edge[] edges = _edges;
		foreach (Edge edge in edges)
		{
			if (Math3d.TryProjectPointOnLineSegment(out projectedPoint, edge.StartPoint, edge.EndPoint, point))
			{
				float sqrMagnitude = (point - projectedPoint).sqrMagnitude;
				if (sqrMagnitude <= sqrSmallestDistance)
				{
					closestEdge = edge;
					closestEdgeProjection = projectedPoint;
					sqrSmallestDistance = sqrMagnitude;
				}
			}
		}
		return closestEdge != null;
	}

	public bool TryReturnWalkwaySegment(out WalkwaySegment walkwaySegment)
	{
		walkwaySegment = _walkwaySegment;
		return walkwaySegment != null;
	}

	public float ReturnWeight()
	{
		return 0f;
	}

	public bool TryReturnClosestHierarchicalNodeMarker(out HierarchicalNodeMarker closestMarker, Vector3 position)
	{
		closestMarker = null;
		Construction buildableExtendable;
		if ((bool)_walkwaySegment)
		{
			closestMarker = _walkwaySegment.ReturnClosestHierarchicalNodeMarker(position);
		}
		else if (Buildable.TryReturnBuildableExtendable<Construction>(out buildableExtendable))
		{
			closestMarker = buildableExtendable.Target.PrimaryMarker.ReturnChildClosestToPoint(position);
		}
		return closestMarker != null;
	}

	public void ReturnBlockingNeighbours(ref ListPool<VisualPrefab>.List blockingConstructions)
	{
		if (!(Construction != null))
		{
			return;
		}
		foreach (Construction neighbourConstruction in Construction.NeighbourConstructions)
		{
			if (!neighbourConstruction.IsConnectedToTownheart(Construction))
			{
				blockingConstructions.Add(neighbourConstruction.Buildable.SpawnedVisual);
			}
		}
	}

	private bool IsHookable(Buildable buildable)
	{
		bool flag = (bool)buildable && !buildable.CancelConstructionAfterHaul;
		if (flag)
		{
			BuildPhase buildPhase = buildable.BuildPhase;
			bool flag2 = (((uint)(buildPhase - 2) > 1u && buildPhase != BuildPhase.HaulFrom) ? true : false);
			flag = flag2;
		}
		return flag;
	}

	private bool CanHookConstruction()
	{
		if (Buildable.TryReturnBuildableExtendable<WalkwayPonton>(out var buildableExtendable))
		{
			foreach (WalkwaySegment neighbouringWalkwaySegment in buildableExtendable.NeighbouringWalkwaySegments)
			{
				if (IsHookable(neighbouringWalkwaySegment.Buildable))
				{
					return true;
				}
			}
			return false;
		}
		return true;
	}

	private void PopulateDependentNeighbouringWalkways()
	{
		foreach (Construction neighbourConstruction in Construction.NeighbourConstructions)
		{
			if (neighbourConstruction.Buildable.TryReturnBuildableExtendable<WalkwaySegment>(out var buildableExtendable) && !Construction.Buildable.TryReturnBuildableExtendable<WalkwayPonton>(out var _) && buildableExtendable.IsHookedTo(this, out var _))
			{
				if (_segmentsToBuildPontonFor == null)
				{
					_segmentsToBuildPontonFor = new List<WalkwaySegment>();
				}
				_segmentsToBuildPontonFor.Add(buildableExtendable);
			}
		}
	}

	private void BuildPontonsForNeighbouringSegments()
	{
		foreach (WalkwaySegment item in _segmentsToBuildPontonFor)
		{
			if (item.Buildable.Properties is WalkwaySegmentProperties walkwaySegmentProperties && walkwaySegmentProperties.walkwayPontonProperties.PlacementCursorProperties is LineConstructionCursorProperties lineConstructionCursorProperties)
			{
				item.IsHookedTo(this, out var isHookedToEnd);
				lineConstructionCursorProperties.CreatePontonForSegment(item, walkwaySegmentProperties.walkwayPontonProperties.Prefab, isHookedToEnd);
			}
		}
		_segmentsToBuildPontonFor = null;
	}

	public void Finish(bool restored = false)
	{
	}

	public void Remove()
	{
		Hookables.Remove(this);
		if (_segmentsToBuildPontonFor != null)
		{
			BuildPontonsForNeighbouringSegments();
		}
	}

	public void Activate()
	{
		Active = true;
		if (Buildable != null && _isHookable)
		{
			Hookables.AddUnique(this);
			InitializeEdges(Buildable);
		}
	}

	public void Deactivate()
	{
		Active = false;
		Hookables.Remove(this);
		if (_segmentsToBuildPontonFor == null)
		{
			PopulateDependentNeighbouringWalkways();
			if (_segmentsToBuildPontonFor != null)
			{
				BuildPontonsForNeighbouringSegments();
			}
		}
	}

	public void Shutdown()
	{
		Active = false;
		Hookables.Remove(this);
	}

	public void ShutdownImmediately()
	{
		throw new NotImplementedException();
	}

	public bool CanBeUpgraded()
	{
		return true;
	}

	public bool CanBeSalvaged()
	{
		if (_walkwaySegment != null)
		{
			return _walkwaySegment.CanBeSalvaged();
		}
		foreach (Construction neighbourConstruction in Construction.NeighbourConstructions)
		{
			if (!neighbourConstruction.IsConnectedToTownheart(Construction))
			{
				return false;
			}
		}
		return true;
	}

	public bool IsEnabled()
	{
		if (Active)
		{
			return Buildable.BuildPhase == BuildPhase.Finished;
		}
		return false;
	}

	public IBuildableExtendablePersistentData ReturnPersistentData()
	{
		return new HookablePersistentData(this);
	}

	public void Restore(IBuildableExtendablePersistentData persistentData)
	{
	}

	public void RestoreReferences(IBuildableExtendablePersistentData persistentData)
	{
	}

	public void PopulateReferences(IBuildableExtendablePersistentData persistentData)
	{
	}

	public void OnDeconstruct()
	{
		PopulateDependentNeighbouringWalkways();
	}

	public bool CanBeDeconstructed()
	{
		return CanBeSalvaged();
	}

	public void Upgrade(Buildable upgradedBuildable)
	{
	}

	public void ShowResearchInfo(RectTransform parent)
	{
	}

	public string ReturnDescription(string text)
	{
		return text;
	}
}
