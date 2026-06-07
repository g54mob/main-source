using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding.Graphs.Grid.Jobs
{
	[BurstCompile]
	public struct JobRelocateNodes : IJob, GridIterationUtilities.ICellAction
	{
		public Matrix4x4 previousWorldToGraph;

		public Matrix4x4 graphToWorld;

		public NativeArray<Vector3> positions;

		public IntBounds bounds;

		public void Execute()
		{
			GridIterationUtilities.ForEachCellIn3DArray(bounds.size, ref this);
		}

		public void Execute(uint innerIndex, int x, int y, int z)
		{
			float y2 = previousWorldToGraph.MultiplyPoint3x4(positions[(int)innerIndex]).y;
			positions[(int)innerIndex] = JobNodeGridLayout.NodePosition(graphToWorld, x, z, y2);
		}
	}
}
