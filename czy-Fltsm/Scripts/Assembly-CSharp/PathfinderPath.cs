using System;
using System.Collections.Generic;
using UnityEngine;

public class PathfinderPath : NavigatorPathBase
{
	public List<PathfindingNode> Nodes { get; private set; }

	public override int Length
	{
		get
		{
			if (Nodes == null)
			{
				return 0;
			}
			return Nodes.Count;
		}
	}

	public PathfinderPath(Navigator navigator, ITarget target)
		: base(navigator)
	{
		SetTarget(target);
	}

	public override void SetState(NavigatorPathState newState)
	{
		if (base.State == newState)
		{
			return;
		}
		switch (base.State)
		{
		case NavigatorPathState.None:
			if (newState == NavigatorPathState.Queued)
			{
				break;
			}
			goto default;
		case NavigatorPathState.Recalculate:
			if (newState == NavigatorPathState.Queued)
			{
				break;
			}
			goto default;
		case NavigatorPathState.Queued:
			if (newState == NavigatorPathState.Processing || newState == NavigatorPathState.Processed)
			{
				break;
			}
			goto default;
		case NavigatorPathState.Processing:
			if (newState == NavigatorPathState.Processed)
			{
				break;
			}
			goto default;
		case NavigatorPathState.Processed:
			if (newState == NavigatorPathState.Navigating || newState == NavigatorPathState.Canceled)
			{
				break;
			}
			goto default;
		case NavigatorPathState.Navigating:
			if (newState == NavigatorPathState.Navigated || newState == NavigatorPathState.Canceled)
			{
				break;
			}
			goto default;
		case NavigatorPathState.Dequeued:
		case NavigatorPathState.Navigated:
		case NavigatorPathState.Canceled:
		case NavigatorPathState.Interupted:
			if (newState == NavigatorPathState.None)
			{
				break;
			}
			goto default;
		default:
			Debug.LogException(new Exception($"'{base.Navigator}' its PathfinderPath with target '{base.Target}' is changing its State from '{base.State}' to '{newState}'. This is unexpected behaviour!"));
			break;
		}
		base.State = newState;
		if (newState == NavigatorPathState.Navigating)
		{
			GameEventDispatcher.AddListener(GameEventType.PathfindingNodeUpdated, OnPathfindingNodeUpdated);
		}
		else
		{
			GameEventDispatcher.RemoveListener(GameEventType.PathfindingNodeUpdated, OnPathfindingNodeUpdated);
		}
	}

	public void SetNodes(List<PathfindingNode> nodes, bool incompletePath = false)
	{
		Nodes = nodes;
		base.IncompletePath = incompletePath;
	}

	public override void ClearNodes()
	{
		if (!Nodes.IsNullOrEmpty())
		{
			for (int i = 0; i < Nodes.Count; i++)
			{
				Nodes[i].UnsubscribeDisposedListener(base.Navigator);
			}
			Nodes.Clear();
			Nodes = null;
		}
	}

	public override void PopulateLineRenderer(List<Vector3> linePath, Vector3 offset)
	{
		int length = Length;
		for (int i = 0; i < length; i++)
		{
			linePath.Add(Nodes[i].RootPosition + offset);
		}
	}

	protected override void Dequeue()
	{
		if (Pathfinder.DequeuePath(this))
		{
			SetState(NavigatorPathState.Dequeued);
		}
	}

	public override bool TryGetNextNode<T>(out T nextNode)
	{
		nextNode = null;
		if (base.State == NavigatorPathState.Navigating && 0 < Length)
		{
			nextNode = Nodes[0] as T;
		}
		return nextNode != null;
	}

	private void OnPathfindingNodeUpdated(GameEvent gameEvent)
	{
		if (base.State == NavigatorPathState.Navigating)
		{
			if (gameEvent is PathfindingEvent pathfindingEvent && pathfindingEvent.HasNodeUpdatedOnPath(Nodes))
			{
				Recalculate();
			}
		}
		else
		{
			GameEventDispatcher.RemoveListener(GameEventType.PathfindingNodeUpdated, OnPathfindingNodeUpdated);
		}
	}

	public override void OnDrawGizmos(Navigator navigator)
	{
		if (base.NoPathFound || base.State < NavigatorPathState.Processed || Length == 0)
		{
			return;
		}
		PathfindingNode pathfindingNode = null;
		navigator.DrawPathSegment(navigator.transform.position, Nodes[0].RootPosition, Color.cyan);
		List<PathfindingNode> nodes = Nodes;
		navigator.DrawPathSegment(nodes[nodes.Count - 1].RootPosition, base.Target.Position, Color.cyan);
		foreach (PathfindingNode node in Nodes)
		{
			if (pathfindingNode != null)
			{
				navigator.DrawPathSegment(pathfindingNode.RootPosition, node.RootPosition, Color.magenta);
			}
			Gizmos.DrawCube(node.RootPosition, new Vector3(0.5f, 1f, 0.5f));
			pathfindingNode = node;
		}
	}
}
