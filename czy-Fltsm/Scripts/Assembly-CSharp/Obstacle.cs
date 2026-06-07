using System;
using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;

[DisallowMultipleComponent]
public class Obstacle : Target
{
	[Header("Obstacle Properties")]
	[Tooltip("Graph types that this obstacle can block.")]
	[EnumFlag(0)]
	public Graph.Type ObstacleGraphType;

	[Tooltip("Polygon that comprises this obstacle.")]
	public Polygon Polygon;

	[Tooltip("Should the obstacle automatically refersh it's clearance when it has moved?")]
	[SerializeField]
	private bool _autoUpdateGraphs;

	[Tooltip("Distance threshold for obstacle to refresh.")]
	[SerializeField]
	private float _refreshThreshold = 1f;

	[SerializeField]
	private bool _buildBlockingObstacle;

	[Header("Debug")]
	[SerializeField]
	private bool _drawBounds;

	[SerializeField]
	private bool _drawPolygon;

	[SerializeField]
	private bool _drawPathfindingPolygons;

	public const int OBSTABLE_RANGE = 8;

	private bool _initialized;

	private Vector2 _lastPosition = Vector2.one;

	private bool _updateGraphs;

	private List<PathfindingPolygon> _pathfindingPolygons = new List<PathfindingPolygon>();

	public int ClearanceRange => 8;

	public static List<Obstacle> AllObstacles { get; private set; } = new List<Obstacle>();

	public static List<Obstacle> LineOfSightObstables { get; private set; } = new List<Obstacle>();

	protected override void Awake()
	{
		base.Awake();
		SetRadius();
		Polygon.Initialize(base.transform);
		AllObstacles.AddUnique(this);
		OnTownheartMoved();
		if (_buildBlockingObstacle)
		{
			Buildable.BlockingPolygons.Add(Polygon);
			Buildable.FreeformBlockerPolygons.Add(Polygon);
		}
		GameEventDispatcher.AddListener(GameEventType.UpdateAllObstacles, OnUpdateAllObstacles);
		GameEventDispatcher.AddListener(GameEventType.TownheartMoved, OnTownheartMoved);
	}

	private void LateUpdate()
	{
		Polygon.Update(checkPosition: true);
		if (!_updateGraphs && (!_autoUpdateGraphs || _lastPosition.IsInRange(Polygon.Position2D, _refreshThreshold)))
		{
			return;
		}
		_lastPosition = Polygon.Position2D;
		foreach (PathfindingPolygon pathfindingPolygon in _pathfindingPolygons)
		{
			pathfindingPolygon.UpdateGraphs();
		}
		_updateGraphs = false;
	}

	private void OnDrawGizmos()
	{
		if (_drawBounds)
		{
			if (Polygon != null)
			{
				Vector3 center = new Vector3(Polygon.Bounds.center.x, 0f, Polygon.Bounds.center.y);
				Vector3 size = new Vector3(Polygon.Bounds.size.x, 3f, Polygon.Bounds.size.y);
				Gizmos.color = Color.black;
				Gizmos.DrawCube(center, size);
			}
			foreach (PathfindingPolygon pathfindingPolygon in _pathfindingPolygons)
			{
				pathfindingPolygon.DrawBoundsGizmo(Color.cyan);
			}
		}
		if (_drawPolygon && Polygon != null)
		{
			Polygon.DrawGizmos();
		}
		if (!_drawPathfindingPolygons || _pathfindingPolygons.IsNullOrEmpty())
		{
			return;
		}
		foreach (PathfindingPolygon pathfindingPolygon2 in _pathfindingPolygons)
		{
			pathfindingPolygon2.DrawGizmos();
		}
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		AllObstacles.Remove(this);
		LineOfSightObstables.Remove(this);
		foreach (PathfindingPolygon pathfindingPolygon in _pathfindingPolygons)
		{
			pathfindingPolygon.OnDestroy();
		}
		_pathfindingPolygons.Clear();
		Buildable.BlockingPolygons.Remove(Polygon);
		Buildable.FreeformBlockerPolygons.Remove(Polygon);
		GameEventDispatcher.RemoveListener(GameEventType.UpdateAllObstacles, OnUpdateAllObstacles);
		GameEventDispatcher.RemoveListener(GameEventType.TownheartMoved, OnTownheartMoved);
	}

	public void Initialize()
	{
		InitializePathfindinPolygons();
		_refreshThreshold += UnityEngine.Random.Range((0f - _refreshThreshold) / 2f, _refreshThreshold / 2f);
		_updateGraphs = true;
		OnTownheartMoved();
		_initialized = true;
	}

	public void Initialize(List<Transform> vertices, Vector2Polygon[] pathfindingPolygons = null)
	{
		foreach (Vector2Polygon prefabPolygon in pathfindingPolygons)
		{
			_pathfindingPolygons.Add(new PathfindingPolygon(this, prefabPolygon));
		}
		Polygon.SetVertices(vertices);
		Polygon.Update();
		SetRadius();
		Initialize();
	}

	private void InitializePathfindinPolygons()
	{
		if (_pathfindingPolygons.Count == 0)
		{
			IPolygonProvider componentInChildren = GetComponentInChildren<IPolygonProvider>();
			if (componentInChildren != null && componentInChildren.TryGetPathfindingPolygons(out var pathfindingPolygons))
			{
				Polygon[] array = pathfindingPolygons;
				foreach (Polygon prefabPolygon in array)
				{
					_pathfindingPolygons.Add(new PathfindingPolygon(this, prefabPolygon));
				}
			}
			else
			{
				_pathfindingPolygons.Add(new PathfindingPolygon(this, Polygon));
			}
		}
		else
		{
			Debug.LogException(new Exception($"Pathfinding polygons for Obstacle '{this}' have already been initialized."));
		}
	}

	public void SetRadius()
	{
		List<Transform> list = Polygon.ReturnVertices();
		float num = 0f;
		Radius = 0f;
		for (int i = 0; i < list.Count; i++)
		{
			num = Vector3.Distance(base.transform.position, list[i].position);
			if (Radius < num)
			{
				Radius = num;
			}
		}
	}

	[ContextMenu("Update graphs")]
	private void ResetBlockedNodes()
	{
		throw new NotImplementedException();
	}

	private void OnUpdateAllObstacles(GameEvent evt)
	{
		if (!_initialized || evt.EventType != GameEventType.UpdateAllObstacles)
		{
			return;
		}
		foreach (PathfindingPolygon pathfindingPolygon in _pathfindingPolygons)
		{
			pathfindingPolygon.Clear();
		}
		_updateGraphs = true;
	}

	private void OnTownheartMoved(GameEvent gameEvent = null)
	{
		if (!_isVessel)
		{
			if (IsInBoatRadius())
			{
				LineOfSightObstables.AddUnique(this);
			}
			else
			{
				LineOfSightObstables.Remove(this);
			}
		}
	}

	public bool ReturnIsLineIntersecting(Vector3 origin, Vector3 direction, float width)
	{
		foreach (PathfindingPolygon pathfindingPolygon in _pathfindingPolygons)
		{
			if (pathfindingPolygon.ReturnIsLineIntersecting(origin, direction, width))
			{
				return true;
			}
		}
		return false;
	}

	private bool IsInBoatRadius()
	{
		foreach (Transform item in Polygon.ReturnVertices())
		{
			if (GameManager.WorldManager.IsInBoatRadius(item.position))
			{
				return true;
			}
		}
		if (base.MooringPoints.IsNullOrEmpty())
		{
			return false;
		}
		foreach (LandmarkMooringPoint mooringPoint in base.MooringPoints)
		{
			if (GameManager.WorldManager.IsInBoatRadius(mooringPoint.EntranceTransform.position))
			{
				return true;
			}
		}
		return false;
	}
}
