using System;
using UnityEngine;

[Serializable]
public abstract class GraphBase
{
	[Tooltip("Graph type that this graph handles.")]
	[EnumFlag(0)]
	public Graph.Type GraphType;

	[Tooltip("Graph types that the nodes of this graph can link with.")]
	[EnumFlag(0)]
	public Graph.Type ValidNeighborTypes;

	[Space]
	[Tooltip("This graph is a standard grid node.")]
	public bool IsGridNode = true;

	[Tooltip("Maximum depth for the grid node.")]
	[ConditionalHide("IsGridNode", true)]
	public int MaximumDepth = 6;

	[Tooltip("Height of this graph in the world.")]
	public float Height;

	[Tooltip("Rules for navigating this graph.")]
	public NavigationMethod NavigationMethod;

	[Header("Debugging")]
	[Tooltip("Displays grid gizmos for the graph when enabled.")]
	public bool DisplayGraph;

	[Tooltip("The colors to give to the debug gizmos for this graph.")]
	public Gradient GizmoColors;

	[Tooltip("Show all the nodes at once of this graph.")]
	public bool ShowAllNodes = true;

	[Tooltip("Level of gizmos to show for this graph.")]
	[Range(0f, 1f)]
	public float DisplayLevel = 1f;

	protected bool _isDirty;

	public int MaximumSize { get; protected set; }

	public Navigator.TerrainType TerrainType { get; protected set; } = Navigator.TerrainType.Construction;

	public Vector2 NodeSize => Vector2.one;

	public abstract void Initialize();

	public abstract PathfindingNode ReturnNode(Target target, Navigator navigator, int deepestLevel, bool onlyUnblocked = true, bool hasLineOfSight = true);

	public abstract PathfindingNode ReturnNode(Vector3 position);

	public bool CanLinkWith(GraphBase graph)
	{
		return (ValidNeighborTypes & GraphType) != 0;
	}

	public static bool TypesMatch(Graph.Type firstGraphType, Graph.Type secondGraphType)
	{
		return (firstGraphType & secondGraphType) != 0;
	}

	public bool TypesMatch(Graph.Type graphType)
	{
		return (GraphType & graphType) != 0;
	}

	private bool TypesMatchCompletely(Graph.Type firstGraphType, Graph.Type secondGraphType)
	{
		if (firstGraphType != 0)
		{
			return firstGraphType == secondGraphType;
		}
		return false;
	}

	public abstract void Draw();
}
