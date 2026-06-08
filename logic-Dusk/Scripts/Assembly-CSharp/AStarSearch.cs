using System.Collections.Generic;
using UnityEngine;

public class AStarSearch
{
	private PriorityQueue<Waypoint, float> _priorityQueue;

	private Dictionary<Waypoint, WaypointEdge> _searchFrontier;

	private Dictionary<Waypoint, float> _realCostForWaypointSoFar;

	private Dictionary<Waypoint, WaypointEdge> _shortestPathTree;

	private IDistanceHeuristic _heuristic;

	public AStarSearch()
	{
		Initialize();
		_heuristic = new EuclideanHeuristic();
	}

	public AStarSearch(IDistanceHeuristic heuristic)
	{
		Initialize();
		_heuristic = heuristic;
	}

	private void Initialize()
	{
		_priorityQueue = new PriorityQueue<Waypoint, float>();
		_searchFrontier = new Dictionary<Waypoint, WaypointEdge>();
		_realCostForWaypointSoFar = new Dictionary<Waypoint, float>();
		_shortestPathTree = new Dictionary<Waypoint, WaypointEdge>();
	}

	public bool Search(Waypoint start, Waypoint end, List<Waypoint> path, bool stopAtBlocked)
	{
		path.Clear();
		if (start == null || end == null)
		{
			if (start == null)
			{
				Debug.LogWarning("Search failed, start is null");
			}
			else
			{
				Debug.LogWarning("Search failed, end is null");
			}
			return false;
		}
		bool flag = false;
		_priorityQueue.Clear();
		_searchFrontier.Clear();
		_realCostForWaypointSoFar.Clear();
		_shortestPathTree.Clear();
		WaypointEdge value = new WaypointEdge(null, start, 0f);
		_priorityQueue.Enqueue(start, 0f);
		_searchFrontier[start] = value;
		_realCostForWaypointSoFar.Add(start, 0f);
		while (!_priorityQueue.IsEmpty())
		{
			Waypoint waypoint = _priorityQueue.Dequeue();
			_shortestPathTree[waypoint] = _searchFrontier[waypoint];
			if (waypoint == end)
			{
				flag = true;
				break;
			}
			int count = waypoint.WaypointEdges.Count;
			for (int i = 0; i < count; i++)
			{
				WaypointEdge waypointEdge = waypoint.WaypointEdges[i];
				if (waypointEdge.Destination == null)
				{
					string text = "<unknown>";
					if (waypointEdge.Start != null && waypointEdge.Start.Room != null)
					{
						text = waypointEdge.Start.Room.Label;
					}
					Debug.LogWarning("Encountered a null edge destination waypoint in Search! Start of edge in: " + text);
				}
				else if (!stopAtBlocked || !(waypointEdge.Destination.Door != null) || waypointEdge.Destination.Door.state != DoorState.Closed)
				{
					float num = _heuristic.Calculate(waypointEdge.Destination, end);
					float num2 = _realCostForWaypointSoFar[waypoint] + waypointEdge.Weight;
					float num3 = num2 + num;
					if (!_searchFrontier.ContainsKey(waypointEdge.Destination))
					{
						_realCostForWaypointSoFar[waypointEdge.Destination] = num2;
						_priorityQueue.Enqueue(waypointEdge.Destination, num3);
						_searchFrontier[waypointEdge.Destination] = waypointEdge;
					}
					else if (num2 < _realCostForWaypointSoFar[waypointEdge.Destination] && !_shortestPathTree.ContainsKey(waypointEdge.Destination))
					{
						_realCostForWaypointSoFar[waypointEdge.Destination] = num2;
						_priorityQueue.UpdatePriority(waypointEdge.Destination, num3);
						_searchFrontier[waypointEdge.Destination] = waypointEdge;
					}
				}
			}
		}
		if (flag)
		{
			Waypoint waypoint2 = end;
			int count2 = _shortestPathTree.Count;
			for (int j = 0; j < count2; j++)
			{
				path.Insert(0, waypoint2);
				waypoint2 = _shortestPathTree[waypoint2].Start;
				if (waypoint2 == null)
				{
					if (path[0] != start)
					{
						Debug.LogWarning(string.Format("A* Search failed to find start node in tree?? ({0})", path[0]));
					}
					break;
				}
			}
		}
		return flag;
	}
}
