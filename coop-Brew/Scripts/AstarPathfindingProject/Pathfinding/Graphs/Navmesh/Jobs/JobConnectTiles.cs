using System.Runtime.InteropServices;
using Unity.Jobs;
using Unity.Profiling;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh.Jobs
{
	public struct JobConnectTiles : IJob
	{
		public GCHandle tiles;

		public int coordinateSum;

		public int direction;

		public int zOffset;

		public int zStride;

		private Vector2 tileWorldSize;

		private IntRect tileRect;

		public float maxTileConnectionEdgeDistance;

		private static readonly ProfilerMarker ConnectTilesMarker;

		public static JobHandle ScheduleBatch(GCHandle tilesHandle, JobHandle dependency, IntRect tileRect, Vector2 tileWorldSize, float maxTileConnectionEdgeDistance)
		{
			return default(JobHandle);
		}

		public static JobHandle ScheduleRecalculateBorders(GCHandle tilesHandle, JobHandle dependency, IntRect tileRect, IntRect innerRect, Vector2 tileWorldSize, float maxTileConnectionEdgeDistance)
		{
			return default(JobHandle);
		}

		public void Execute()
		{
		}
	}
}
