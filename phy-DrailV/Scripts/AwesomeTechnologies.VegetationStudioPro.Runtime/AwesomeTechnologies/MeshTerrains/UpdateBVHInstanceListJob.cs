using AwesomeTechnologies.Utility.BVHTree;
using AwesomeTechnologies.VegetationSystem;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace AwesomeTechnologies.MeshTerrains
{
	[BurstCompile(CompileSynchronously = true)]
	public struct UpdateBVHInstanceListJob : IJob
	{
		public NativeList<float3> Position;

		public NativeList<quaternion> Rotation;

		public NativeList<float3> Scale;

		public NativeList<float3> TerrainNormal;

		public NativeList<float> BiomeDistance;

		public NativeList<byte> TerrainTextureData;

		public NativeList<int> RandomNumberIndex;

		public NativeList<float> DistanceFalloff;

		public NativeList<float> VegetationMaskDensity;

		public NativeList<float> VegetationMaskScale;

		public NativeList<byte> TerrainSourceID;

		public NativeList<byte> TextureMaskData;

		public NativeList<byte> Excluded;

		public NativeList<byte> HeightmapSampled;

		[ReadOnly]
		public NativeArray<HitInfo> RaycastHits;

		[ReadOnly]
		public NativeArray<VegetationSpawnLocationInstance> SpawnLocationList;

		public void Execute()
		{
			for (int i = 0; i <= RaycastHits.Length - 1; i++)
			{
				HitInfo hitInfo = RaycastHits[i];
				if (hitInfo.HitDistance > 0f)
				{
					Position.Add(hitInfo.HitPoint);
					Rotation.Add(Quaternion.Euler(0f, 0f, 0f));
					Scale.Add(new float3(1f, 1f, 1f));
					TerrainNormal.Add(hitInfo.HitNormal);
					BiomeDistance.Add(100000f);
					TerrainTextureData.Add(0);
					RandomNumberIndex.Add(SpawnLocationList[i].RandomNumberIndex);
					DistanceFalloff.Add(1f);
					VegetationMaskDensity.Add(0f);
					VegetationMaskScale.Add(0f);
					TerrainSourceID.Add(hitInfo.TerrainSourceID);
					TextureMaskData.Add(0);
					Excluded.Add(0);
					HeightmapSampled.Add(0);
				}
			}
		}
	}
}
