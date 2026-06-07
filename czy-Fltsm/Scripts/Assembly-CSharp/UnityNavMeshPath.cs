using System;
using System.Collections.Generic;
using UnityEngine;

public class UnityNavMeshPath : NavigatorPathBase
{
	public List<Vector3> Nodes { get; private set; }

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

	public UnityNavMeshPath(UnityNavMeshNavigator navMeshNavigator)
		: base(navMeshNavigator.Navigator)
	{
		Nodes = new List<Vector3>();
	}

	public override void SetTarget(ITarget target)
	{
		base.SetTarget(target);
		SetState(NavigatorPathState.Processing);
	}

	public override void SetState(NavigatorPathState state)
	{
		if (base.State == state)
		{
			return;
		}
		switch (base.State)
		{
		case NavigatorPathState.None:
		case NavigatorPathState.Recalculate:
			if (state == NavigatorPathState.Processing)
			{
				break;
			}
			goto default;
		case NavigatorPathState.Processing:
			if (state == NavigatorPathState.Navigating)
			{
				break;
			}
			goto default;
		case NavigatorPathState.Navigating:
			if (state == NavigatorPathState.Navigated || state == NavigatorPathState.Canceled)
			{
				break;
			}
			goto default;
		case NavigatorPathState.Navigated:
		case NavigatorPathState.Canceled:
		case NavigatorPathState.Interupted:
			if (state == NavigatorPathState.None)
			{
				break;
			}
			goto default;
		default:
			Debug.LogException(new Exception($"'{base.Navigator}' its NavMeshPath with target '{base.Target}' is changing State from '{base.State}' to '{state}'. This is unexpected behaviour!"));
			break;
		}
		base.State = state;
	}

	public override void ClearNodes()
	{
		Nodes.Clear();
	}

	public override void PopulateLineRenderer(List<Vector3> linePath, Vector3 offset)
	{
		for (int i = 0; i < Nodes.Count; i++)
		{
			linePath.Add(Nodes[i] + offset);
		}
	}
}
