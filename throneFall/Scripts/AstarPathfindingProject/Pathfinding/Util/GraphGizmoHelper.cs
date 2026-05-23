using System;
using Pathfinding.Drawing;
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

		public GraphGizmoHelper()
		{
			drawConnection = DrawConnection;
		}

		public static GraphGizmoHelper GetSingleFrameGizmoHelper(DrawingData gizmos, AstarPath active, RedrawScope redrawScope)
		{
			return GetGizmoHelper(gizmos, active, DrawingData.Hasher.NotSupplied, redrawScope);
		}

		public static GraphGizmoHelper GetGizmoHelper(DrawingData gizmos, AstarPath active, DrawingData.Hasher hasher, RedrawScope redrawScope)
		{
			GraphGizmoHelper graphGizmoHelper = ObjectPool<GraphGizmoHelper>.Claim();
			graphGizmoHelper.Init(active, hasher, gizmos, redrawScope);
			return graphGizmoHelper;
		}

		public void Init(AstarPath active, DrawingData.Hasher hasher, DrawingData gizmos, RedrawScope redrawScope)
		{
			if (active != null)
			{
				debugData = active.debugPathData;
				debugPathID = active.debugPathID;
				debugMode = active.debugMode;
				debugFloor = active.debugFloor;
				debugRoof = active.debugRoof;
				nodeStorage = active.nodeStorage;
				showSearchTree = false;
			}
			this.hasher = hasher;
			builder = gizmos.GetBuilder(hasher, redrawScope);
		}

		public void OnEnterPool()
		{
			builder.Dispose();
			debugData = null;
		}

		public void DrawConnections(GraphNode node)
		{
			if (!showSearchTree)
			{
				drawConnectionColor = NodeColor(node);
				drawConnectionStart = (Vector3)node.position;
				node.GetConnections(drawConnection);
			}
		}

		private void DrawConnection(GraphNode other)
		{
			builder.Line(drawConnectionStart, ((Vector3)other.position + drawConnectionStart) * 0.5f, drawConnectionColor);
		}

		public Color NodeColor(GraphNode node)
		{
			if (node.Walkable)
			{
				switch (debugMode)
				{
				case GraphDebugMode.Areas:
					return AstarColor.GetAreaColor(node.Area);
				case GraphDebugMode.HierarchicalNode:
				case GraphDebugMode.NavmeshBorderObstacles:
					return AstarColor.GetTagColor((uint)node.HierarchicalNodeIndex);
				case GraphDebugMode.Penalty:
					return Color.Lerp(AstarColor.ConnectionLowLerp, AstarColor.ConnectionHighLerp, ((float)node.Penalty - debugFloor) / (debugRoof - debugFloor));
				case GraphDebugMode.Tags:
					return AstarColor.GetTagColor(node.Tag);
				case GraphDebugMode.SolidColor:
					return AstarColor.SolidColor;
				default:
					return AstarColor.SolidColor;
				}
			}
			return AstarColor.UnwalkableNode;
		}

		public void DrawWireTriangle(Vector3 a, Vector3 b, Vector3 c, Color color)
		{
			builder.Line(a, b, color);
			builder.Line(b, c, color);
			builder.Line(c, a, color);
		}

		public void DrawTriangles(Vector3[] vertices, Color[] colors, int numTriangles)
		{
			int[] array = ArrayPool<int>.Claim(numTriangles * 3);
			for (int i = 0; i < numTriangles * 3; i++)
			{
				array[i] = i;
			}
			builder.SolidMesh(vertices, array, colors, numTriangles * 3, numTriangles * 3);
			ArrayPool<int>.Release(ref array);
		}

		public void DrawWireTriangles(Vector3[] vertices, Color[] colors, int numTriangles)
		{
			for (int i = 0; i < numTriangles; i++)
			{
				DrawWireTriangle(vertices[i * 3], vertices[i * 3 + 1], vertices[i * 3 + 2], colors[i * 3]);
			}
		}

		void IDisposable.Dispose()
		{
			GraphGizmoHelper obj = this;
			ObjectPool<GraphGizmoHelper>.Release(ref obj);
		}
	}
}
