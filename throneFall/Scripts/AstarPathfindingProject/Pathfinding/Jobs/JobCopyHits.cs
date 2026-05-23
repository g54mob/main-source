using Pathfinding.Graphs.Grid;
using Unity.Burst;
using Unity.Burst.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Jobs
{
	[BurstCompile(FloatMode = FloatMode.Fast)]
	public struct JobCopyHits : IJob, GridIterationUtilities.ISliceAction
	{
		[ReadOnly]
		public NativeArray<RaycastHit> hits;

		[WriteOnly]
		public NativeArray<Vector3> points;

		[WriteOnly]
		public NativeArray<float4> normals;

		public Slice3D slice;

		public void Execute()
		{
			slice.AssertMatchesOuter(points);
			slice.AssertMatchesOuter(normals);
			GridIterationUtilities.ForEachCellIn3DSlice(slice, ref this);
		}

		public void Execute(uint outerIdx, uint innerIdx)
		{
			Aliasing.ExpectNotAliased(in points, in normals);
			Vector3 normal = hits[(int)innerIdx].normal;
			float4 x = new float4(normal.x, normal.y, normal.z, 0f);
			normals[(int)outerIdx] = math.normalizesafe(x);
			if (math.lengthsq(x) > 1.1754944E-38f)
			{
				points[(int)outerIdx] = hits[(int)innerIdx].point;
			}
		}
	}
}
