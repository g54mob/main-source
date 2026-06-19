using System.Collections.Generic;
using UnityEngine;

public static class GraphDebug
{
	public class Graph
	{
		public List<Vector2> points;

		public LineRenderer lineRenderer;
	}

	public static Dictionary<string, Graph> graphIdMap = new Dictionary<string, Graph>();

	public static GameObject graphHandler;

	private const float LineThickness = 0.1f;

	private static Material defaultMaterial;

	public static void GraphValue(string id, Vector2 point, Color color)
	{
		MaybeAddNewGraph(id, color).points.Add(point);
		RedrawGraph();
	}

	private static void RedrawGraph()
	{
		foreach (Graph value in graphIdMap.Values)
		{
			value.lineRenderer.positionCount = value.points.Count;
			for (int i = 0; i < value.points.Count; i++)
			{
				value.lineRenderer.SetPosition(i, value.points[i]);
			}
		}
	}

	public static Graph MaybeAddNewGraph(string id, Color color)
	{
		if (graphHandler == null)
		{
			graphHandler = new GameObject();
		}
		if (graphIdMap.TryGetValue(id, out var value))
		{
			return value;
		}
		defaultMaterial = Resources.Load<Material>("GraphDebug/defaultMaterial");
		Graph graph = new Graph();
		graph.lineRenderer = graphHandler.AddComponent<LineRenderer>();
		graph.lineRenderer.widthMultiplier = 0.1f;
		graph.lineRenderer.material = defaultMaterial;
		graph.lineRenderer.startColor = color;
		graph.points = new List<Vector2>();
		graphIdMap.Add(id, graph);
		return graphIdMap[id];
	}
}
