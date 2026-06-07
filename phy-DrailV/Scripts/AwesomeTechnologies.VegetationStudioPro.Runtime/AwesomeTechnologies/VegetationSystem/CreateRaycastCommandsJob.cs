using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem
{
	[BurstCompile(CompileSynchronously = true)]
	public struct CreateRaycastCommandsJob : IJob
	{
		[ReadOnly]
		public NativeArray<VegetationSpawnLocationInstance> SpawnLocationList;

		public NativeArray<RaycastCommand> RaycastCommands;

		public int LayerMask;

		public int MaxHits;

		public float3 FloatingOriginOffset;

		public void Execute()
		{
			for (int i = 0; i <= SpawnLocationList.Length - 1; i++)
			{
				RaycastCommand value = new RaycastCommand
				{
					distance = 20000f,
					from = SpawnLocationList[i].Position + new float3(0f, 10000f, 0f) + FloatingOriginOffset,
					direction = new Vector3(0f, -1f, 0f),
					layerMask = LayerMask,
					maxHits = MaxHits
				};
				RaycastCommands[i] = value;
			}
		}
	}
}
