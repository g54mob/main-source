using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;

public class GraphManager : SceneBehaviour
{
	[Tooltip("Grid for the water surface.")]
	public Grid WaterSurfaceGraph;

	[Tooltip("NavMesh for the constructions.")]
	public NavMesh ConstructionGraph;

	[SerializeField]
	private int _openNodeHeapSize = 4096;

	public int OpenNodeHeapSize => _openNodeHeapSize;

	public int ClosedNodeListSize => WaterSurfaceGraph.MaximumSize + ConstructionGraph.MaximumSize;

	public void Initialize()
	{
		LoadingScreen.AddTask(WaterSurfaceGraph.Initialize);
		LoadingScreen.AddTask(ConstructionGraph.Initialize);
	}

	private void Update()
	{
		if (GameManager.Instance.InitializeEnvironment && GameSpeedManager.GameSpeed != GameSpeed.Zero)
		{
			Pathfinder.ProcessQueue();
		}
	}

	private void LateUpdate()
	{
		if (!GameManager.Instance.IntroScene)
		{
			ConstructionGraph.UpdateRootPosition();
		}
		PathfindingEvent.TryDispatch();
	}

	private void OnDrawGizmos()
	{
		DrawGraph(WaterSurfaceGraph);
		DrawGraph(ConstructionGraph);
	}

	private void OnDestroy()
	{
		WaterSurfaceGraph.Dispose();
		ConstructionGraph.Dispose();
	}

	public static void RefreshNavigatorPaths()
	{
	}

	private void DrawGraph(GraphBase graph)
	{
		if (graph != null && graph.DisplayGraph)
		{
			graph.Draw();
		}
	}

	public PathfindingNode ReturnNode(Target target, Navigator navigator, int deepestLevel = 16, bool onlyUnblocked = true, bool hasLineOfSight = false)
	{
		List<PathfindingNode> list = ListPool<PathfindingNode>.Get();
		if (Graph.TypesMatch(navigator.TargetGraphType, WaterSurfaceGraph.GraphType))
		{
			PathfindingNode pathfindingNode = WaterSurfaceGraph.ReturnNode(target, navigator, deepestLevel, onlyUnblocked, hasLineOfSight);
			if (pathfindingNode != null)
			{
				list.Add(pathfindingNode);
			}
		}
		if (Graph.TypesMatch(navigator.TargetGraphType, ConstructionGraph.GraphType))
		{
			PathfindingNode pathfindingNode2 = ConstructionGraph.ReturnNode(target, navigator, deepestLevel, onlyUnblocked, hasLineOfSight);
			if (pathfindingNode2 != null)
			{
				list.Add(pathfindingNode2);
			}
		}
		PathfindingNode result = ReturnClosestNode(list, target.transform.position);
		ListPool<PathfindingNode>.Add(list);
		return result;
	}

	public PathfindingNode ReturnNode(Vector3 position, Graph.Type graphType)
	{
		if (!TryReturnGraph(graphType, out var graph))
		{
			return null;
		}
		return graph.ReturnNode(position);
	}

	private PathfindingNode ReturnClosestNode(List<PathfindingNode> nodes, Vector3 position)
	{
		int count = nodes.Count;
		float num = float.MaxValue;
		PathfindingNode result = null;
		for (int i = 0; i < count; i++)
		{
			PathfindingNode pathfindingNode = nodes[i];
			float num2 = position.DistanceToLeveledSquared(pathfindingNode.RootPosition);
			if (num2 < num)
			{
				result = pathfindingNode;
				num = num2;
			}
		}
		return result;
	}

	private bool TryReturnGraph(Graph.Type graphType, out GraphBase graph)
	{
		switch (graphType)
		{
		case Graph.Type.WaterSurface:
			graph = WaterSurfaceGraph;
			return true;
		case Graph.Type.Constructions:
			graph = ConstructionGraph;
			return true;
		default:
			Debug.LogErrorFormat("Returning a graph of Graph.type '{0}' is currently not implemented.", graphType);
			graph = null;
			return false;
		}
	}
}
