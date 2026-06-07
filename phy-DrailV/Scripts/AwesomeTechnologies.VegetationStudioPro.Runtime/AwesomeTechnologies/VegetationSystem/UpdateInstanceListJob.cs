using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem
{
	[BurstCompile(CompileSynchronously = true)]
	public struct UpdateInstanceListJob : IJob
	{
		[ReadOnly]
		public NativeArray<RaycastHit> RaycastHits;

		[ReadOnly]
		public NativeArray<VegetationSpawnLocationInstance> SpawnLocationList;

		public Rect TerrainRect;

		public float3 FloatingOriginOffset;

		public byte TerrainSourceID;

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

		public NativeList<byte> TerrainSourceIDs;

		public NativeList<byte> TextureMaskData;

		public NativeList<byte> Excluded;

		public NativeList<byte> HeightmapSampled;

		public void Execute()
		{
			for (int i = 0; i <= RaycastHits.Length - 1; i++)
			{
				if (SpawnLocationList[i].SpawnChance < 0f)
				{
					continue;
				}
				RaycastHit raycastHit = RaycastHits[i];
				if (raycastHit.distance > 0f)
				{
					float3 value = raycastHit.point;
					value -= FloatingOriginOffset;
					Vector2 point = new Vector2(value.x, value.z);
					if (TerrainRect.Contains(point))
					{
						Position.Add(value);
						Rotation.Add(Quaternion.Euler(0f, 45f, 0f));
						Scale.Add(new float3(1f, 1f, 1f));
						TerrainNormal.Add(raycastHit.normal);
						BiomeDistance.Add(SpawnLocationList[i].BiomeDistance);
						TerrainTextureData.Add(0);
						RandomNumberIndex.Add(SpawnLocationList[i].RandomNumberIndex);
						DistanceFalloff.Add(1f);
						VegetationMaskDensity.Add(1f);
						VegetationMaskScale.Add(1f);
						TerrainSourceIDs.Add(TerrainSourceID);
						TextureMaskData.Add(0);
						Excluded.Add(0);
						HeightmapSampled.Add(0);
					}
				}
			}
		}
	}
}
