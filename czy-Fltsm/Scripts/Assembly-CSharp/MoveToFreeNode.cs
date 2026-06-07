using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class MoveToFreeNode : TaskBase
{
	public string taskName;

	public override TaskType Type => TaskType.RescueLandmark;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		while (!Pathfinder.HasInstance)
		{
			yield return null;
		}
		HierarchicalNodeMarker component = project.Target.GetComponent<HierarchicalNodeMarker>();
		using ListPool<HierarchicalNodeMarker>.List neighbours = GetNeighbours(component);
		HierarchicalNode newTargetNode = null;
		foreach (HierarchicalNodeMarker item in neighbours)
		{
			if (item.IsFree)
			{
				item.ReservedForIdling = true;
				newTargetNode = item.Node;
				break;
			}
		}
		if (newTargetNode == null)
		{
			newTargetNode = neighbours[neighbours.Count - 1].Node;
		}
		PathfindingNodeTarget target = new PathfindingNodeTarget(newTargetNode);
		yield return MoveAgentCoroutine(target);
		if (newTargetNode.Graph == null)
		{
			agent.ReturnNavigator().StopNavigation(ProjectFlags.Exception);
			yield break;
		}
		newTargetNode.Marker.ReservedForIdling = false;
		agent.ReturnNavigator().AttachToNode(newTargetNode);
	}

	private ListPool<HierarchicalNodeMarker>.List GetNeighbours(HierarchicalNodeMarker startNodeMarker)
	{
		ListPool<HierarchicalNodeMarker>.List list = ListPool<HierarchicalNodeMarker>.Get();
		foreach (PathfindingNode item in (IEnumerable<PathfindingNode>)startNodeMarker.Node.Neighbors.FindAll((PathfindingNode n) => n.Graph.GraphType == Graph.Type.Constructions))
		{
			AddMarkerToNeighbours(item, list);
			foreach (PathfindingNode item2 in (IEnumerable<PathfindingNode>)item.Neighbors.FindAll((PathfindingNode n) => n.Graph.GraphType == Graph.Type.Constructions))
			{
				if (item2 != startNodeMarker.Node)
				{
					AddMarkerToNeighbours(item2, list);
				}
			}
		}
		list.OrderBy((HierarchicalNodeMarker m) => Vector3.Distance(m.transform.position, startNodeMarker.transform.position));
		return list;
	}

	private void AddMarkerToNeighbours(PathfindingNode node, List<HierarchicalNodeMarker> neighboursList)
	{
		if (node is HierarchicalNode hierarchicalNode && !neighboursList.Contains(hierarchicalNode.Marker))
		{
			neighboursList.Add(hierarchicalNode.Marker);
		}
	}

	protected override void OnGUI()
	{
		Header("Move to free node", 0, Color.green);
		EditorGUI_HelpBox("Move towards closest free node on construction.");
	}
}
