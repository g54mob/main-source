using System.Runtime.InteropServices;
using Unity.Collections;
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
		}

		private void Apply(TriangleMeshNode[] nodes, JobCalculateTriangleConnections.TileNodeConnectionsUnsafe connections)
		{
		}
	}
}
