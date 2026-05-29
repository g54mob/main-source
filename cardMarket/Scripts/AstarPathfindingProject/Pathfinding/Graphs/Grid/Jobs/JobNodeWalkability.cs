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
			float num = math.cos(math.radians(maxSlope));
			float4 float5 = new float4(up.x, up.y, up.z, 0f);
			float3 xyz = float5.xyz;
			for (int i = 0; i < nodeNormals.Length; i++)
			{
				bool flag = math.any(nodeNormals[i]);
				bool flag2 = flag;
				if (!flag && !unwalkableWhenNoGround && i < layerStride)
				{
					flag2 = true;
					nodeNormals[i] = float5;
				}
				if (flag2 && useRaycastNormal && flag && math.dot(nodeNormals[i], float5) < num)
				{
					flag2 = false;
				}
				if (flag2 && i + layerStride < nodeNormals.Length && math.any(nodeNormals[i + layerStride]))
				{
					flag2 = math.dot(xyz, nodePositions[i + layerStride] - nodePositions[i]) >= characterHeight;
				}
				nodeWalkable[i] = flag2;
			}
		}
	}
}
