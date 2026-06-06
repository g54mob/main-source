using System;
using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;

[Serializable]
public class NavMesh : GraphBase
{
	private List<HierarchicalNode> _children;

	private HierarchicalNode _root;

	public HierarchicalNode Root => _root;

	public override void Initialize()
	{
		HierarchicalNodeBaseMarker hierarchicalNodeBaseMarker = UnityEngine.Object.FindAnyObjectByType<HierarchicalNodeBaseMarker>();
		if (!(hierarchicalNodeBaseMarker == null))
		{
			_children = new List<HierarchicalNode>();
			_root = new HierarchicalNode(hierarchicalNodeBaseMarker, 0, this);
			_root.UpdateNode(false);
			base.TerrainType = Navigator.ReturnTerrainTypeFromGraphType(Graph.Type.Constructions);
		}
	}

	public void Dispose()
	{
		_root?.Dispose();
	}

	public void UpdateRootPosition()
	{
		_root.UpdateRootPosition();
	}

	public void AddNode(HierarchicalNodeMarker nodeMarker)
	{
		_root.AddChild(nodeMarker);
	}

	public bool RemoveNode(HierarchicalNode node)
	{
		return _root.RemoveChild(node);
	}

	public void AddChild(HierarchicalNode child)
	{
		if (!_children.AddUnique(child))
		{
			Debug.LogError("Trying to add a child to the NavMesh which is already in the _children list!");
		}
	}

	public void RemoveChild(HierarchicalNode child)
	{
		if (!_children.Remove(child))
		{
			Debug.LogError("Trying to remove a child of the NavMEsh that is not in the _children list!");
		}
	}

	public override PathfindingNode ReturnNode(Target target, Navigator navigator, int deepestLevel, bool onlyUnblocked = true, bool hasLineOfSight = true)
	{
		if (target.PrimaryMarker == null)
		{
			if (_root != null)
			{
				return _root.ReturnNode(target, navigator, onlyUnblocked, leaf: false, deepestLevel, hasLineOfSight);
			}
			return null;
		}
		return target.PrimaryMarker.Node;
	}

	public override PathfindingNode ReturnNode(Vector3 position)
	{
		return null;
	}

	public List<HierarchicalNode> ReturnAllNodes()
	{
		return _children;
	}

	public bool ReturnHasNodeInRange(MarkerProxy marker)
	{
		return _root.ReturnHasNodeInRange(marker.Position, marker.Range);
	}

	public PathfindingNode ReturnClosestNode(Vector3 position)
	{
		return _root.ReturnClosestNode(position);
	}

	public override void Draw()
	{
		if (_root == null)
		{
			return;
		}
		DrawNode(_root, onlyNeighborsOnSameGraph: true);
		List<HierarchicalNode> list = _root.ReturnAllChildren();
		if (ShowAllNodes)
		{
			for (int i = 0; i < list.Count; i++)
			{
				DrawNode(list[i], onlyNeighborsOnSameGraph: true);
			}
			return;
		}
		int num = Mathf.RoundToInt(DisplayLevel * 2f);
		for (int j = 0; j < list.Count; j++)
		{
			PathfindingNode pathfindingNode = list[j];
			if (pathfindingNode.Level == num)
			{
				DrawNode(pathfindingNode as HierarchicalNode, onlyNeighborsOnSameGraph: true);
			}
		}
	}

	private void DrawNode(HierarchicalNode node, bool onlyNeighborsOnSameGraph = false)
	{
		if (node == null)
		{
			return;
		}
		if (node.ParentNode != null)
		{
			Gizmos.color = Color.cyan * 0.5f;
			Gizmos.DrawLine(node.RootPosition, node.ParentNode.RootPosition);
		}
		float num = ((float)(int)node.Level + 1f) / ((float)HierarchicalNode.DeepestLevel + 1f);
		if (node.Leaf)
		{
			num = 1f;
			Gizmos.color = node.GizmoColor;
			if (node.IsBlocked)
			{
				Gizmos.DrawSphere(node.RootPosition, node.Diameter * 0.5f * num);
			}
			Gizmos.color = node.GizmoColor;
			Gizmos.DrawWireSphere(node.RootPosition, node.Diameter * 0.5f * num);
		}
		else
		{
			Gizmos.color = node.GizmoColor * 0.5f;
			Gizmos.DrawSphere(node.RootPosition, node.Diameter * 0.5f * num);
			Gizmos.DrawWireSphere(node.RootPosition, node.Diameter * 0.5f * num);
			if (node.Level > 0)
			{
				Vector3 vector = Vector3.one * 999f;
				Vector3 vector2 = Vector3.zero;
				for (int i = 0; i < node.Children.Count; i++)
				{
					Vector3 rootPosition = node.Children[i].RootPosition;
					if (rootPosition.x < vector.x)
					{
						vector = vector.SetX(rootPosition.x);
					}
					if (rootPosition.x > vector2.x)
					{
						vector2 = vector2.SetX(rootPosition.x);
					}
					if (rootPosition.y < vector.y)
					{
						vector = vector.SetY(rootPosition.y);
					}
					if (rootPosition.y > vector2.y)
					{
						vector2 = vector2.SetY(rootPosition.y);
					}
					if (rootPosition.z < vector.z)
					{
						vector = vector.SetZ(rootPosition.z);
					}
					if (rootPosition.z > vector2.z)
					{
						vector2 = vector2.SetZ(rootPosition.z);
					}
				}
				Vector3 vector3 = vector2 - vector;
				Vector3 center = (vector2 + vector) / 2f;
				vector3 = new Vector3(vector3.x + node.Diameter, vector3.x + node.Diameter, vector3.z + node.Diameter);
				Gizmos.DrawWireCube(center, vector3);
			}
		}
		Gizmos.color = new Color(255f, 69f, 0f) * 0.5f;
		if (node.Neighbors == null)
		{
			return;
		}
		foreach (PathfindingNode neighbor in node.Neighbors)
		{
			if (!onlyNeighborsOnSameGraph || neighbor.Graph == node.Graph)
			{
				Gizmos.DrawLine(node.RootPosition, neighbor.RootPosition);
			}
		}
	}
}
