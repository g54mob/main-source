using System;
using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;

public class PathfindingPolygon : Polygon
{
	private Obstacle _obstacle;

	private Rect _lastBounds;

	private Dictionary<Graph.Type, List<GridNode>> _blockedNodesPerGrid = new Dictionary<Graph.Type, List<GridNode>>();

	private int _clearanceDistance;

	private GridNode _clearanceCenter;

	private Rect _clearanceRect;

	private Grid _watersurfaceGraph;

	private static List<PathfindingPolygon> _allPathfindingPolygons = new List<PathfindingPolygon>();

	public PathfindingPolygon(Obstacle obstacle, Polygon prefabPolygon)
	{
		_allPathfindingPolygons.Add(this);
		_obstacle = obstacle;
		_watersurfaceGraph = GameManager.GraphManager.WaterSurfaceGraph;
		Initialize(obstacle.transform, prefabPolygon);
	}

	public PathfindingPolygon(Obstacle obstacle, Vector2Polygon prefabPolygon)
	{
		Transform transform = obstacle.transform;
		_allPathfindingPolygons.Add(this);
		_obstacle = obstacle;
		_watersurfaceGraph = GameManager.GraphManager.WaterSurfaceGraph;
		Initialize(transform);
		using ListPool<Vector2>.List list = ListPool<Vector2>.Get();
		Vector2[] vertices = prefabPolygon.Vertices;
		foreach (Vector2 vector in vertices)
		{
			list.Add(transform.TransformPoint(vector.Vector3TopDown()).Vector2TopDown());
		}
		Update(list);
	}

	public void OnDestroy()
	{
		_allPathfindingPolygons.Remove(this);
		ClearBlockedNodes();
		ClearClearance();
		foreach (PathfindingPolygon allPathfindingPolygon in _allPathfindingPolygons)
		{
			if (allPathfindingPolygon._clearanceCenter != null && _clearanceRect.Overlaps(allPathfindingPolygon._clearanceRect))
			{
				allPathfindingPolygon.SetClearance(allPathfindingPolygon._lastBounds);
			}
		}
	}

	public void InitializeGraphs()
	{
		_watersurfaceGraph = GameManager.GraphManager.WaterSurfaceGraph;
	}

	public void UpdateGraphs()
	{
		Update(checkPosition: true);
		ClearBlockedNodes();
		SetBlockedNodesForGraph(GameManager.GraphManager.WaterSurfaceGraph, Bounds);
		ClearClearance();
		SetClearance(Bounds);
	}

	public void ResetClearance()
	{
		SetClearance(_lastBounds);
	}

	public void Clear()
	{
		ClearBlockedNodes();
		ClearClearance();
	}

	private void ClearBlockedNodes()
	{
		if (_blockedNodesPerGrid == null)
		{
			return;
		}
		foreach (List<GridNode> value in _blockedNodesPerGrid.Values)
		{
			foreach (GridNode item in value)
			{
				item.DecreaseObstacleCount();
			}
			ListPool<GridNode>.Add(value);
		}
		_blockedNodesPerGrid.Clear();
	}

	private void SetBlockedNodesForGraph(Grid grid, Rect bounds)
	{
		if ((_obstacle.ObstacleGraphType & grid.GraphType) == grid.GraphType)
		{
			if (_blockedNodesPerGrid.ContainsKey(grid.GraphType))
			{
				throw new NotSupportedException();
			}
			List<GridNode> list = ListPool<GridNode>.Get();
			grid.UpdateBlockedNodes(this, bounds, list);
			_blockedNodesPerGrid.Add(grid.GraphType, list);
		}
	}

	private void ClearClearance()
	{
		if (_clearanceCenter != null && _watersurfaceGraph != null)
		{
			_watersurfaceGraph.ResetClearance(_clearanceCenter, _clearanceDistance);
			_clearanceCenter = null;
		}
	}

	private void SetClearance(Rect bounds)
	{
		if (_watersurfaceGraph == null)
		{
			throw new NotSupportedException("Obstacle.SetClearance can not be called before the Obstalce is initialized.");
		}
		if (!_watersurfaceGraph.WasDisposed)
		{
			_clearanceDistance = Mathf.CeilToInt(Mathf.Max(bounds.size.x, bounds.size.y) / 2f) + _obstacle.ClearanceRange;
			_clearanceCenter = _watersurfaceGraph.ReturnNode(bounds.center);
			_clearanceRect = new Rect(Mathf.Floor(bounds.center.x - (float)_clearanceDistance), Mathf.Floor(bounds.center.y - (float)_clearanceDistance), _clearanceDistance * 2 + 1, _clearanceDistance * 2 + 1);
			_watersurfaceGraph.SetClearance(_clearanceCenter, _clearanceDistance);
			_lastBounds = bounds;
		}
	}

	public void DrawBoundsGizmo(Color color)
	{
		Vector3 center = new Vector3(_lastBounds.center.x, 0f, _lastBounds.center.y);
		Vector3 size = new Vector3(_lastBounds.size.x, 3f, _lastBounds.size.y);
		Gizmos.color = Color.black;
		Gizmos.DrawCube(center, size);
	}
}
