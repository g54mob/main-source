using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Graphs.Grid.Jobs
{
	[BurstCompile(FloatMode = FloatMode.Fast)]
	public struct JobNodeWalkability : IJob
	{
		public bool useRaycastNormal;

		public float maxSlope;

		public Vector3 up;

		public bool unwalkableWhenNoGround;

		public float characterHeight;

		public int layerStride;

		[ReadOnly]
		public NativeArray<float3> nodePositions;

		public NativeArray<float4> nodeNormals;

		[WriteOnly]
		public NativeArray<bool> nodeWalkable;

		public void Execute()
		{
		}
	}
}
