using System;
using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;

public abstract class GridNode : PathfindingNode
{
	private const int CLEARANCE_PENALTY = 30;

	private Vector2 _boundsMin;

	private Vector2 _boundsMax;

	private ushort _obstacleCount;

	private byte _clearance = byte.MaxValue;

	public override bool IsGridNode => true;

	public override byte Level => 0;

	public byte Clearance => _clearance;

	public override Vector3 RootPosition => new Vector3(Center.x, Graph.Height, Center.y);

	public override Vector2 RootPosition2D => Center;

	public override Vector3 LeveledRootPosition => new Vector3(Center.x, 0f, Center.y);

	public Vector2 Center { get; private set; }

	public override float Diameter => 1f;

	public override int Penalty => 0;

	public GridNode(GraphBase graph, Vector2 rootPosition)
	{
		Center = rootPosition;
		Vector2 vector = graph.NodeSize / 2f;
		_boundsMin = Center - vector;
		_boundsMax = Center + vector;
		SetIsBlocked();
	}

	public static GridNode Get(Grid grid, Vector2 rootPosition)
	{
		if (grid.GraphType == global::Graph.Type.WaterSurface)
		{
			return new WaterSurfaceNode(grid, rootPosition);
		}
		throw new NotImplementedException();
	}

	public override void UpdateRootPosition()
	{
	}

	public override void PopulateNeighbors(List<PathfindingNode> neighbors)
	{
		base.PopulateNeighbors(neighbors);
		GameManager.GraphManager.WaterSurfaceGraph.PopulateNeighbors(this, neighbors);
	}

	public void AddNeighbor(PathfindingNode node)
	{
		if (Neighbors == null)
		{
			Neighbors = new List<PathfindingNode> { node };
		}
		else
		{
			Neighbors.Add(node);
		}
	}

	public override bool RemoveNeighbor(PathfindingNode node)
	{
		if (Neighbors == null)
		{
			return false;
		}
		return Neighbors.Remove(node);
	}

	public void IncreaseObstacleCount()
	{
		_obstacleCount++;
		SetIsBlocked();
	}

	public void DecreaseObstacleCount()
	{
		_obstacleCount--;
		SetIsBlocked();
	}

	public void ResetClearance()
	{
		_clearance = byte.MaxValue;
		PathfindingEvent.AddUpdatedPathfindingNode(this);
	}

	public void SetClearance(byte clearance)
	{
		if (clearance < _clearance)
		{
			_clearance = clearance;
		}
	}

	protected override void SetIsBlocked()
	{
		bool flag = 0 < _obstacleCount;
		if (flag != base.IsBlocked)
		{
			PathfindingEvent.AddUpdatedPathfindingNode(this);
		}
		base.IsBlocked = flag;
	}

	public override void UpdateNode(bool setNeighbors)
	{
		throw new NotImplementedException();
	}

	public override void SetPenalty(int penalty)
	{
		Debug.LogException(new NotImplementedException());
	}

	public override void ClearPenalty()
	{
		Debug.LogException(new NotImplementedException());
	}

	public bool ReturnIsPolygonOverlapping(Polygon polygon)
	{
		Vector2[] vertices = polygon.ReturnPolygon();
		if (ReturnAreProjectionsOverlapping(vertices, Vector2.up, _boundsMin.y, _boundsMax.y) && ReturnAreProjectionsOverlapping(vertices, Vector2.right, _boundsMin.x, _boundsMax.x))
		{
			return polygon.ReturnIsAxisAllignedRectangleOverlapping(_boundsMin, _boundsMax);
		}
		return false;
	}

	private bool ReturnAreProjectionsOverlapping(Vector2[] vertices, Vector2 axis, float min, float max)
	{
		Vector2 vector = vertices[0];
		float num = axis.x * vector.x + axis.y * vector.y;
		float num2 = num;
		float num3 = num;
		int num4 = vertices.Length;
		for (int i = 1; i < num4; i++)
		{
			vector = vertices[i];
			num = axis.x * vector.x + axis.y * vector.y;
			if (num < num2)
			{
				num2 = num;
			}
			else if (num3 < num)
			{
				num3 = num;
			}
		}
		if (!(num3 < min))
		{
			return !(max < num2);
		}
		return false;
	}

	public override bool CanFitNavigator(INavigator navigator)
	{
		return navigator.RequiredClearance <= Clearance;
	}

	public override Transform GetAgentParent()
	{
		return GameManager.AgentManager.AgentParent;
	}

	public override int ReturnPenalty(INavigator navigator)
	{
		int num = 0;
		byte clearance = Clearance;
		byte preferredClearance = navigator.PreferredClearance;
		if (clearance == byte.MaxValue)
		{
			return 0;
		}
		if (clearance < preferredClearance)
		{
			byte requiredClearance = navigator.RequiredClearance;
			num = ((clearance >= requiredClearance) ? ((preferredClearance - clearance) * 30) : ((requiredClearance - clearance) * 100 * 30));
		}
		return base.ReturnPenalty(navigator) + num;
	}

	public bool TryReturnClosedNodeWithClearance(out GridNode nodeWithClearence, byte Clearance, float range)
	{
		Grid obj = (Grid)Graph;
		float num = float.MaxValue;
		nodeWithClearence = null;
		PathfindingNode[] array = obj.ReturnNeighborhood(RootPosition2D.x, RootPosition2D.y, 10);
		for (int i = 0; i < array.Length; i++)
		{
			GridNode gridNode = (GridNode)array[i];
			if (gridNode != null && gridNode.Clearance >= Clearance)
			{
				float num2 = gridNode.RootPosition2D.DistanceToSquared(RootPosition2D);
				if (num2 < num)
				{
					num = num2;
					nodeWithClearence = gridNode;
				}
			}
		}
		return nodeWithClearence != null;
	}

	public override PathfindingNodeData GetData()
	{
		return GridNodeData.Get(this);
	}

	public void DrawGizmo(bool wire = false)
	{
		DrawGizmo(Gizmos.color, wire);
	}

	public override void DrawGizmo(Color color, bool wire = false, float radius = 0.5f, Vector3 offset = default(Vector3))
	{
		Vector3 center = LeveledRootPosition + offset;
		Vector3 size = default(Vector3);
		size.x = _boundsMax.x - _boundsMin.x;
		size.y = size.x;
		size.z = _boundsMax.y - _boundsMin.y;
		Color color2 = Gizmos.color;
		Gizmos.color = color;
		if (wire)
		{
			Gizmos.DrawWireCube(center, size);
		}
		else
		{
			Gizmos.DrawCube(center, size);
		}
		Gizmos.color = color2;
	}
}
