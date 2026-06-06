using Pathfinding.Collections;
using Unity.Burst;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh.Jobs
{
	[BurstCompile(FloatMode = FloatMode.Fast)]
	public struct JobTransformTileCoordinates : IJob
	{
		public UnsafeSpan<Int3> vertices;

		public Matrix4x4 matrix;

		public void Execute()
		{
		}
	}
}
