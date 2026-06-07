using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding.Graphs.Grid.Jobs
{
	[BurstCompile(FloatMode = FloatMode.Fast)]
	public struct JobNodeGridLayout : IJob, GridIterationUtilities.ICellAction
	{
		public Matrix4x4 graphToWorld;

		public IntBounds bounds;

		[WriteOnly]
		public NativeArray<Vector3> nodePositions;

		public static Vector3 NodePosition(Matrix4x4 graphToWorld, int x, int z, float height = 0f)
		{
			return default(Vector3);
		}

		public void Execute()
		{
		}

		public void Execute(uint innerIndex, int x, int y, int z)
		{
		}
	}
}
