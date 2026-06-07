using AwesomeTechnologies.VegetationSystem;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace AwesomeTechnologies.MeshTerrains
{
	[BurstCompile(CompileSynchronously = true)]
	public struct CreateBVHRaycastJob : IJob
	{
		[ReadOnly]
		public NativeArray<VegetationSpawnLocationInstance> SpawnLocationList;

		public NativeArray<BVHRay> Rays;

		public Rect TerrainRect;

		public int LayerMask;

		public int MaxHits;

		public void Execute()
		{
			for (int i = 0; i <= SpawnLocationList.Length - 1; i++)
			{
				float3 position = SpawnLocationList[i].Position;
				Vector2 point = new Vector2(position.x, position.z);
				if (!TerrainRect.Contains(point))
				{
					BVHRay value = new BVHRay
					{
						Origin = position + new float3(0f, 10000f, 0f),
						Direction = new float3(0f, -1f, 0f),
						DoRaycast = 0
					};
					Rays[i] = value;
				}
				else
				{
					BVHRay value2 = new BVHRay
					{
						Origin = position + new float3(0f, 10000f, 0f),
						Direction = new float3(0f, -1f, 0f),
						DoRaycast = math.select(1, 0, SpawnLocationList[i].SpawnChance < 0f)
					};
					Rays[i] = value2;
				}
			}
		}
	}
}
