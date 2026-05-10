using System;
using UnityEngine;

namespace Pathfinding.Util
{
	public class GraphGizmoHelper : IAstarPooledObject, IDisposable
	{
		private RetainedGizmos gizmos;

		private PathHandler debugData;

		private ushort debugPathID;

		private GraphDebugMode debugMode;

		private bool showSearchTree;

		private float debugFloor;

		private float debugRoof;

		private Vector3 drawConnectionStart;

		private Color drawConnectionColor;

		private readonly Action<GraphNode> drawConnection;

		public RetainedGizmos.Hasher hasher { get; private set; }

		public RetainedGizmos.Builder builder { get; private set; }

		public void Init(AstarPath active, RetainedGizmos.Hasher hasher, RetainedGizmos gizmos)
		{
		}

		public void OnEnterPool()
		{
		}

		public void DrawConnections(GraphNode node)
		{
		}

		private void DrawConnection(GraphNode other)
		{
		}

		public Color NodeColor(GraphNode node)
		{
			return default(Color);
		}

		public static bool InSearchTree(GraphNode node, PathHandler handler, ushort pathID)
		{
			return false;
		}

		public void DrawWireTriangle(Vector3 a, Vector3 b, Vector3 c, Color color)
		{
		}

		public void DrawTriangles(Vector3[] vertices, Color[] colors, int numTriangles)
		{
		}

		public void DrawWireTriangles(Vector3[] vertices, Color[] colors, int numTriangles)
		{
		}

		public void Submit()
		{
		}

		void IDisposable.Dispose()
		{
		}
	}
}
