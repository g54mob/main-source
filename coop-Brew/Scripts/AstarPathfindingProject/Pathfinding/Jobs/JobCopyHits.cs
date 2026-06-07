using Pathfinding.Graphs.Grid;
using Unity.Burst;
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
		}

		public void Execute(uint outerIdx, uint innerIdx)
		{
		}
	}
}
