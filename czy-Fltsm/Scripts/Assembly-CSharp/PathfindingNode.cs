using System.Collections.Generic;
using UnityEngine;

public abstract class PathfindingNode
{
	public List<PathfindingNode> Neighbors;

	public PathfindingFlags Flags;

	public abstract GraphBase Graph { get; }

	public abstract bool IsGridNode { get; }

	public abstract byte Level { get; }

	public bool IsBlocked { get; protected set; }

	public virtual bool IsOutOfBounds => false;

	public abstract int Penalty { get; }

	public abstract Vector3 RootPosition { get; }

	public abstract Vector3 LeveledRootPosition { get; }

	public abstract Vector2 RootPosition2D { get; }

	public abstract float Diameter { get; }

	protected virtual void SetIsBlocked()
	{
	}

	public abstract void SetPenalty(int penalty);

	public abstract void ClearPenalty();

	public abstract bool RemoveNeighbor(PathfindingNode node);

	public virtual void PopulateNeighbors(List<PathfindingNode> neighbors)
	{
		if (Neighbors != null)
		{
			neighbors.AddRange(Neighbors);
		}
	}

	public virtual void PopulateNeighbors(List<PathfindingNode> listToPopulate, Graph.Type acceptedGraphs)
	{
		int count = Neighbors.Count;
		for (int i = 0; i < count; i++)
		{
			PathfindingNode pathfindingNode = Neighbors[i];
			if ((pathfindingNode.Graph.GraphType & acceptedGraphs) != 0)
			{
				listToPopulate.Add(pathfindingNode);
			}
		}
	}

	public abstract void UpdateNode(bool setNeighbors = true);

	public abstract void UpdateRootPosition();

	public abstract bool CanFitNavigator(INavigator navigator);

	public abstract Transform GetAgentParent();

	public virtual int ReturnPenalty(INavigator navigator)
	{
		return Penalty;
	}

	public abstract PathfindingNodeData GetData();

	public virtual void SubscribeDisposedListener(IPathfindingNodeDisposedListener disposedListener)
	{
	}

	public virtual void UnsubscribeDisposedListener(IPathfindingNodeDisposedListener disposedListener)
	{
	}

	public abstract void DrawGizmo(Color color, bool wire = false, float radius = 0.5f, Vector3 offset = default(Vector3));
}
