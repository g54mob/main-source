using System;
using System.Collections.Generic;
using PajamaLlama.Debugs;
using PajamaLlama.Extensions;
using PajamaLlama.Math;
using UnityEngine;

public class HierarchicalNode : PathfindingNode
{
	public bool Leaf;

	public HierarchicalNode ParentNode;

	public List<HierarchicalNode> Children = new List<HierarchicalNode>();

	public HierarchicalNodeMarker Marker;

	public static int DeepestLevel;

	public Color GizmoColor;

	private byte _level;

	private bool _updateAllChildren;

	private List<HierarchicalNode> _allChildren;

	private bool _updateLeafChildren;

	private List<HierarchicalNode> _leafChildren;

	private Vector3 _rootPosition;

	private float _diameter;

	protected List<IPathfindingNodeDisposedListener> _subscribedDisposedListeners = new List<IPathfindingNodeDisposedListener>();

	private Transform _markerTransform;

	private int _childCount;

	private int _penalty;

	private NavMesh _navMesh;

	private string _markerPath;

	public override bool IsGridNode => false;

	public override byte Level => _level;

	public override Vector3 RootPosition => _rootPosition;

	public override Vector2 RootPosition2D => new Vector2(_rootPosition.x, _rootPosition.z);

	public override Vector3 LeveledRootPosition => new Vector3(_rootPosition.x, 0f, _rootPosition.z);

	public override float Diameter => _diameter;

	public float Range { get; private set; }

	public override int Penalty => _penalty;

	public override GraphBase Graph => _navMesh;

	public override bool IsOutOfBounds
	{
		get
		{
			if (Marker != null)
			{
				return Marker.IsOutOfBounds;
			}
			return false;
		}
	}

	public HierarchicalNode(HierarchicalNodeMarker marker, byte level, NavMesh navMesh, HierarchicalNode parent = null)
	{
		Marker = marker;
		Marker.SetNode(this);
		_markerTransform = Marker.transform;
		_markerPath = Marker.HierarchyPathToString();
		_rootPosition = Marker.transform.position;
		_level = level;
		_navMesh = navMesh;
		ParentNode = parent;
		Neighbors = new List<PathfindingNode>();
		_diameter = Marker.Diameter;
		Range = Marker.Range;
		GizmoColor = Color.HSVToRGB(UnityEngine.Random.Range(0f, 1f), 1f, 1f);
		if (Level > DeepestLevel)
		{
			DeepestLevel = Level;
		}
		AddNavMeshNeighbors(navMesh);
		AddGridNeighbors();
		navMesh.AddChild(this);
		AddChildrenFromMarker(Marker.GetComponentsInChildren<HierarchicalNodeMarker>(), navMesh);
		_allChildren = new List<HierarchicalNode>();
		_updateAllChildren = true;
		_leafChildren = new List<HierarchicalNode>();
		_updateLeafChildren = true;
	}

	public void SetDirty()
	{
		_updateAllChildren = true;
		_updateLeafChildren = true;
		int count = Children.Count;
		for (int i = 0; i < count; i++)
		{
			Children[i].SetDirty();
		}
	}

	public void Dispose()
	{
		int count = Children.Count;
		while (0 < count--)
		{
			Children[count].Dispose();
		}
		PathfindingEvent.AddUpdatedPathfindingNode(this);
		if (_subscribedDisposedListeners != null)
		{
			int count2 = _subscribedDisposedListeners.Count;
			while (0 < count2--)
			{
				_subscribedDisposedListeners[count2]?.OnPathfindingNodeDisposed(this);
			}
		}
		if (Neighbors != null)
		{
			foreach (PathfindingNode neighbor in Neighbors)
			{
				neighbor.RemoveNeighbor(this);
			}
		}
		_navMesh?.RemoveChild(this);
		_navMesh = null;
		ParentNode?.RemoveChild(this);
		ParentNode = null;
		if ((bool)Marker && Marker.gameObject.scene.isLoaded)
		{
			Navigator[] componentsInChildren = Marker.GetComponentsInChildren<Navigator>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].OnParentNodeDisposed();
			}
			Marker.SetNode(null);
			Marker = null;
		}
		Neighbors?.Clear();
		Neighbors = null;
		Children?.Clear();
		Children = null;
		_childCount = 0;
		_allChildren?.Clear();
		_allChildren = null;
		_leafChildren?.Clear();
		_leafChildren = null;
		_subscribedDisposedListeners?.Clear();
		_subscribedDisposedListeners = null;
	}

	public override void SetPenalty(int penalty)
	{
		_penalty = penalty;
		PathfindingEvent.AddUpdatedPathfindingNode(this);
	}

	public override void ClearPenalty()
	{
		_penalty = 0;
		PathfindingEvent.AddUpdatedPathfindingNode(this);
	}

	private void AddNavMeshNeighbors(NavMesh navMesh)
	{
		List<HierarchicalNode> list = navMesh.ReturnAllNodes();
		Vector3 leveledRootPosition = LeveledRootPosition;
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			HierarchicalNode hierarchicalNode = list[i];
			if (CanBeNavMeshNeighbor(hierarchicalNode, leveledRootPosition))
			{
				Neighbors.Add(hierarchicalNode);
				hierarchicalNode.Neighbors.Add(this);
			}
		}
	}

	private bool CanBeNavMeshNeighbor(HierarchicalNode node, Vector3 leveledRootPosition)
	{
		if (node == this)
		{
			return false;
		}
		if (leveledRootPosition.IsInRange(node.LeveledRootPosition, Mathf.Max(Range, node.Range)) && (Neighbors == null || !Neighbors.Contains(node)))
		{
			if (!(Graph is Grid))
			{
				return HasLineOfSightAt(node, Diameter);
			}
			return HasLineOfSightAt(node, 0f);
		}
		return false;
	}

	private void AddGridNeighbors()
	{
		if ((Graph.ValidNeighborTypes & global::Graph.Type.WaterSurface) == global::Graph.Type.WaterSurface)
		{
			AddGridNeighbors(GameManager.GraphManager.WaterSurfaceGraph);
		}
	}

	private void AddGridNeighbors(Grid grid)
	{
		if (grid == null)
		{
			Debugger.Warning("No valid graph found to get neighbors from.");
		}
		else
		{
			if (!Graph.CanLinkWith(grid))
			{
				return;
			}
			List<GridNode> list = ListPool<GridNode>.Get();
			grid.PopulateNeighborhood(RootPosition.x, RootPosition.z, Mathf.FloorToInt(Range), list);
			foreach (GridNode item in list)
			{
				Neighbors.Add(item);
				item.AddNeighbor(this);
			}
			ListPool<GridNode>.Add(list);
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

	private void ClearNeighbors()
	{
		if (Neighbors == null)
		{
			return;
		}
		foreach (PathfindingNode neighbor in Neighbors)
		{
			neighbor.RemoveNeighbor(this);
		}
		Neighbors.Clear();
	}

	public override void UpdateRootPosition()
	{
		_rootPosition = _markerTransform.position;
		for (int i = 0; i < _childCount; i++)
		{
			Children[i].UpdateRootPosition();
		}
	}

	public override void UpdateNode(bool setNeigbors = true)
	{
		Leaf = Children.Count == 0;
		SetIsBlocked();
	}

	protected override void SetIsBlocked()
	{
		base.IsBlocked = false;
		for (int i = 0; i < Obstacle.AllObstacles.Count; i++)
		{
			Obstacle obstacle = Obstacle.AllObstacles[i];
			if (obstacle.ObstacleGraphType == global::Graph.Type.Constructions && Vector3.Distance(RootPosition, obstacle.transform.position) < Diameter + obstacle.Radius)
			{
				base.IsBlocked = true;
				break;
			}
		}
	}

	public void AddChild(HierarchicalNodeMarker marker)
	{
		AddChild(new HierarchicalNode(marker, (byte)(Level + 1), Graph as NavMesh, this));
	}

	public void AddChild(HierarchicalNode node, bool resetNeighbors = true)
	{
		node.UpdateNode(false);
		Children.Add(node);
		Leaf = false;
		HierarchicalNode root = (Graph as NavMesh).Root;
		root._updateAllChildren = true;
		root._updateLeafChildren = true;
		_childCount++;
	}

	public void AddChildrenFromMarker(HierarchicalNodeMarker[] childmarkers, NavMesh navMesh)
	{
		int num = childmarkers.Length;
		byte level = _level.Add(1);
		Transform transform = Marker.transform;
		for (int i = 0; i < num; i++)
		{
			HierarchicalNodeMarker hierarchicalNodeMarker = childmarkers[i];
			if (!(hierarchicalNodeMarker == Marker) && transform == hierarchicalNodeMarker.transform.parent)
			{
				AddChild(new HierarchicalNode(hierarchicalNodeMarker, level, navMesh, this), resetNeighbors: false);
			}
		}
	}

	public bool RemoveChild(HierarchicalNode node)
	{
		if (Children.IsNullOrEmpty())
		{
			return false;
		}
		if (Children.Remove(node))
		{
			node.Dispose();
			Leaf = Children.Count == 0;
			_updateAllChildren = true;
			_updateLeafChildren = true;
			_childCount--;
			return true;
		}
		foreach (HierarchicalNode child in Children)
		{
			if (child.RemoveChild(node))
			{
				_updateAllChildren = true;
				_updateLeafChildren = true;
				return true;
			}
		}
		return false;
	}

	public List<HierarchicalNode> ReturnAllChildren(bool onlyLeaves = false, int level = -1)
	{
		if (onlyLeaves)
		{
			if (_updateLeafChildren)
			{
				_leafChildren.Clear();
				if (Leaf)
				{
					_leafChildren.Add(this);
				}
				else
				{
					PopulateChildren(_leafChildren, this, addNonLeaves: false);
				}
				_updateLeafChildren = false;
			}
			return _leafChildren;
		}
		if (_updateAllChildren)
		{
			_allChildren.Clear();
			_allChildren.Add(this);
			PopulateChildren(_allChildren, this, addNonLeaves: true);
			_updateAllChildren = false;
		}
		return _allChildren;
	}

	private void PopulateChildren(List<HierarchicalNode> family, HierarchicalNode parent, bool addNonLeaves)
	{
		int count = parent.Children.Count;
		for (int i = 0; i < count; i++)
		{
			HierarchicalNode hierarchicalNode = parent.Children[i];
			if (hierarchicalNode.Leaf)
			{
				family.Add(hierarchicalNode);
				continue;
			}
			if (addNonLeaves)
			{
				family.Add(hierarchicalNode);
			}
			PopulateChildren(family, hierarchicalNode, addNonLeaves);
		}
	}

	public PathfindingNode ReturnNode(Target target, Navigator navigator, bool onlyUnblocked = true, bool leaf = true, int maximumDepth = 16, bool hasLineOfSight = true, bool onlyInRange = true)
	{
		if (!Graph.TypesMatch(target.TargetGraphType))
		{
			return null;
		}
		HierarchicalNode result = null;
		List<HierarchicalNode> list = ReturnAllChildren(leaf);
		list.Add(this);
		float num = 3f;
		Vector3 position = target.Position;
		float num2 = float.MaxValue;
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			HierarchicalNode hierarchicalNode = list[i];
			if (maximumDepth < hierarchicalNode.Level || !hierarchicalNode.CanFitNavigator(navigator) || (onlyUnblocked && hierarchicalNode.IsBlocked))
			{
				continue;
			}
			if (onlyInRange)
			{
				num = hierarchicalNode.Range + target.Radius;
				if (!hierarchicalNode.RootPosition.IsInRange(position, num))
				{
					continue;
				}
			}
			if ((!hasLineOfSight && !(navigator != null)) || hierarchicalNode.HasLineOfSightAt(position, navigator.Width))
			{
				float num3 = Vector3.Distance(position, hierarchicalNode.RootPosition);
				if (num3 < num2)
				{
					result = hierarchicalNode;
					num2 = num3;
				}
			}
		}
		return result;
	}

	public bool ReturnHasNodeInRange(Vector3 position, float range)
	{
		if (_rootPosition.IsInRange(position, Mathf.Min(Range, range) * 0.95f))
		{
			return true;
		}
		if (!Leaf)
		{
			int count = Children.Count;
			for (int i = 0; i < count; i++)
			{
				if (Children[i].ReturnHasNodeInRange(position, range))
				{
					return true;
				}
			}
		}
		return false;
	}

	public bool HasLineOfSightAt(Vector3 position, float width)
	{
		Vector3 direction = position - RootPosition;
		foreach (Obstacle allObstacle in Obstacle.AllObstacles)
		{
			if (allObstacle.ObstacleGraphType == global::Graph.Type.Constructions && allObstacle.ReturnIsLineIntersecting(RootPosition, direction, width))
			{
				return false;
			}
		}
		return true;
	}

	public bool HasLineOfSightAt(HierarchicalNode node, float width)
	{
		return HasLineOfSightAt(node.RootPosition, width);
	}

	public override bool CanFitNavigator(INavigator navigator)
	{
		return true;
	}

	public override Transform GetAgentParent()
	{
		if (Leaf && ParentNode != null && (bool)ParentNode.Marker)
		{
			Transform transform = ParentNode.Marker.transform;
			if (transform.parent != null)
			{
				return transform;
			}
		}
		if ((bool)Marker)
		{
			return Marker.transform;
		}
		Debug.LogException(new Exception());
		return GameManager.AgentManager.AgentParent;
	}

	public HierarchicalNode ReturnClosestNode(Vector3 position)
	{
		if (Leaf)
		{
			return this;
		}
		if (ReturnClosestDescendant(position, out var closestDescendant, out var distanceToDescendant) && distanceToDescendant < position.DistanceToSquared(RootPosition))
		{
			return closestDescendant;
		}
		return this;
	}

	private bool ReturnClosestDescendant(Vector3 position, out HierarchicalNode closestDescendant, out float distanceToDescendant)
	{
		closestDescendant = null;
		distanceToDescendant = float.MaxValue;
		foreach (HierarchicalNode child in Children)
		{
			if (child != this)
			{
				float distanceToDescendant2 = position.DistanceToSquared(child.RootPosition);
				if (distanceToDescendant2 < distanceToDescendant)
				{
					closestDescendant = child;
					distanceToDescendant = distanceToDescendant2;
				}
				if (!child.Leaf && child.ReturnClosestDescendant(position, out var closestDescendant2, out distanceToDescendant2) && distanceToDescendant2 < distanceToDescendant)
				{
					closestDescendant = closestDescendant2;
					distanceToDescendant = distanceToDescendant2;
				}
			}
		}
		return closestDescendant != null;
	}

	public override PathfindingNodeData GetData()
	{
		return HierarchicalNodeData.Get(this);
	}

	public override void SubscribeDisposedListener(IPathfindingNodeDisposedListener disposedListener)
	{
		_subscribedDisposedListeners?.AddUnique(disposedListener);
	}

	public override void UnsubscribeDisposedListener(IPathfindingNodeDisposedListener disposedListener)
	{
		_subscribedDisposedListeners?.Remove(disposedListener);
	}

	public override void DrawGizmo(Color color, bool wire = false, float radius = 0.5f, Vector3 offset = default(Vector3))
	{
		Color color2 = Gizmos.color;
		Gizmos.color = color;
		if (wire)
		{
			Gizmos.DrawWireSphere(RootPosition, radius);
		}
		else
		{
			Gizmos.DrawSphere(RootPosition, radius);
		}
		Gizmos.color = color2;
	}
}
