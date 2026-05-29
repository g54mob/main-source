using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh.Jobs
{
	[BurstCompile(FloatMode = FloatMode.Fast)]
	public struct JobTransformTileCoordinates : IJob
	{
		public unsafe UnsafeAppendBuffer* vertices;

		public Matrix4x4 matrix;

		public unsafe void Execute()
		{
			int num = vertices->Length / UnsafeUtility.SizeOf<Int3>();
			for (int i = 0; i < num; i++)
			{
				Int3* ptr = (Int3*)vertices->Ptr + i;
				Vector3 point = new Vector3(ptr->x, ptr->y, ptr->z);
				*ptr = (Int3)matrix.MultiplyPoint3x4(point);
			}
		}
	}
}
