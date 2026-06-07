using System;
using Pathfinding.Drawing;
using Pathfinding.Pooling;
using UnityEngine;

namespace Pathfinding.Util
{
	public class GraphGizmoHelper : IAstarPooledObject, IDisposable
	{
		private PathHandler debugData;

		private ushort debugPathID;

		private GraphDebugMode debugMode;

		public bool showSearchTree;

		private float debugFloor;

		private float debugRoof;

		public CommandBuilder builder;

		private Vector3 drawConnectionStart;

		private Color drawConnectionColor;

		private readonly Action<GraphNode> drawConnection;

		private GlobalNodeStorage nodeStorage;

		public DrawingData.Hasher hasher { get; private set; }

		public static GraphGizmoHelper GetSingleFrameGizmoHelper(DrawingData gizmos, AstarPath active, RedrawScope redrawScope, bool renderInGame)
		{
			return null;
		}

		public static GraphGizmoHelper GetGizmoHelper(DrawingData gizmos, AstarPath active, DrawingData.Hasher hasher, RedrawScope redrawScope, bool renderInGame)
		{
			return null;
		}

		public void Init(AstarPath active, DrawingData.Hasher hasher, DrawingData gizmos, RedrawScope redrawScope, bool renderInGame)
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

		public void DrawWireTriangle(Vector3 a, Vector3 b, Vector3 c, Color color)
		{
		}

		public void DrawTriangles(Vector3[] vertices, Color[] colors, int numTriangles)
		{
		}

		public void DrawWireTriangles(Vector3[] vertices, Color[] colors, int numTriangles)
		{
		}

		public void Dispose()
		{
		}
	}
}
