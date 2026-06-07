using System.Runtime.InteropServices;
using Pathfinding.Util;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;

namespace Pathfinding.Graphs.Navmesh.Jobs
{
	public struct JobWriteNodeConnections : IJob
	{
		[ReadOnly]
		public NativeArray<JobCalculateTriangleConnections.TileNodeConnectionsUnsafe> nodeConnections;

		public GCHandle tiles;

		public void Execute()
		{
			NavmeshTile[] array = (NavmeshTile[])tiles.Target;
			for (int i = 0; i < array.Length; i++)
			{
				JobCalculateTriangleConnections.TileNodeConnectionsUnsafe connections = nodeConnections[i];
				Apply(array[i].nodes, connections);
				connections.neighbourCounts.Dispose();
				connections.neighbours.Dispose();
			}
		}

		private void Apply(TriangleMeshNode[] nodes, JobCalculateTriangleConnections.TileNodeConnectionsUnsafe connections)
		{
			UnsafeAppendBuffer.Reader reader = connections.neighbourCounts.AsReader();
			UnsafeAppendBuffer.Reader reader2 = connections.neighbours.AsReader();
			foreach (TriangleMeshNode triangleMeshNode in nodes)
			{
				int num = reader.ReadNext<int>();
				Connection[] array = (triangleMeshNode.connections = ArrayPool<Connection>.ClaimWithExactLength(num));
				for (int j = 0; j < num; j++)
				{
					int num2 = reader2.ReadNext<int>();
					byte shapeEdgeInfo = (byte)reader2.ReadNext<int>();
					TriangleMeshNode triangleMeshNode2 = nodes[num2];
					int costMagnitude = (triangleMeshNode.position - triangleMeshNode2.position).costMagnitude;
					array[j] = new Connection(triangleMeshNode2, (uint)costMagnitude, shapeEdgeInfo);
				}
			}
		}
	}
}
