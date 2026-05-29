using Pathfinding.Jobs;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Graphs.Grid.Jobs
{
	[BurstCompile]
	public struct JobCopyBuffers : IJob
	{
		[ReadOnly]
		[DisableUninitializedReadCheck]
		public GridGraphNodeData input;

		[WriteOnly]
		public GridGraphNodeData output;

		public IntBounds bounds;

		public bool copyPenaltyAndTags;

		public void Execute()
		{
			Slice3D inputSlice = new Slice3D(input.bounds, bounds);
			Slice3D outputSlice = new Slice3D(output.bounds, bounds);
			JobCopyRectangle<Vector3>.Copy(input.positions, output.positions, inputSlice, outputSlice);
			JobCopyRectangle<float4>.Copy(input.normals, output.normals, inputSlice, outputSlice);
			JobCopyRectangle<ulong>.Copy(input.connections, output.connections, inputSlice, outputSlice);
			if (copyPenaltyAndTags)
			{
				JobCopyRectangle<uint>.Copy(input.penalties, output.penalties, inputSlice, outputSlice);
				JobCopyRectangle<int>.Copy(input.tags, output.tags, inputSlice, outputSlice);
			}
			JobCopyRectangle<bool>.Copy(input.walkable, output.walkable, inputSlice, outputSlice);
			JobCopyRectangle<bool>.Copy(input.walkableWithErosion, output.walkableWithErosion, inputSlice, outputSlice);
		}
	}
}
