using System.Collections.Generic;
using UnityEngine;

public abstract class PathfindingNodeData : IHeapItem<PathfindingNodeData>
{
	public abstract PathfindingNode Node { get; }

	public PathfindingNodeData Parent { get; set; }

	public PathfindingFlags Flags => Node.Flags;

	public abstract Vector3 RootPosition { get; }

	public abstract Vector2 RootPosition2D { get; }

	public abstract bool IsGridNode { get; }

	public float GCost { get; protected set; }

	public float HCost { get; protected set; }

	public float FCost { get; protected set; }

	public void SetOpen(PathfindingFlags openFlag)
	{
		Node.Flags |= openFlag;
	}

	public void SetClosed(PathfindingFlags openFlag, PathfindingFlags closedFlag)
	{
		Node.Flags &= ~openFlag;
		Node.Flags |= closedFlag;
	}

	public abstract bool CanFitNavigator(INavigator navigator);

	public abstract bool ReturnIgnoreClearane(INavigator navigator);

	public abstract int ReturnClearancePenalty(INavigator navigator);

	public void SetGCost(float gCost)
	{
		GCost = gCost;
		FCost = gCost + HCost;
	}

	public abstract float ReturnGCost(PathfindingNodeData antecede, INavigator navigator);

	public abstract float ReturnHCost(PathfindingNode target, INavigator navigator);

	public void SetFCost(float gCost, float hCost)
	{
		GCost = gCost;
		HCost = hCost;
		FCost = gCost + hCost;
	}

	public void PopulateNeighbors(List<PathfindingNode> neighbors)
	{
		Node.PopulateNeighbors(neighbors);
	}

	public virtual void Clear(PathfindingFlags openFlag, PathfindingFlags closedFlag)
	{
		if (Node != null)
		{
			Node.Flags &= ~openFlag;
			Node.Flags &= ~closedFlag;
		}
		HeapIndex = 0;
		Parent = null;
		GCost = 0f;
		HCost = 0f;
		FCost = 0f;
		Return();
	}

	public override int CompareTo(PathfindingNodeData node)
	{
		if (FCost == node.FCost)
		{
			return (int)(node.HCost - HCost);
		}
		return (int)(node.FCost - FCost);
	}

	protected abstract void Return();

	public bool IsFlagSet(PathfindingFlags flags)
	{
		return (Node.Flags & flags) != 0;
	}
}
