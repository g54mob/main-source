using System;
using Digger.Modules.Core.Sources;
using Digger.Modules.Core.Sources.NativeCollections;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Digger.Modules.AdvancedOperations.Sources.ModificationJobs.EasyOverhangs
{
	[BurstCompile(CompileSynchronously = true, FloatMode = FloatMode.Fast)]
	public struct EasyOverhangsModificationJob : IJobParallelFor
	{
		public int SizeVox;

		public int SizeVox2;

		public float3 HeightmapScale;

		public float3 Center;

		public float Radius;

		public float3 ChunkWorldPosition;

		public uint TextureIndex;

		public float Intensity;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<float> Heights;

		public NativeArray<Voxel> Voxels;

		[WriteOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<int> Holes;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<float3> Normals;

		public void Execute(int index)
		{
			int3 int5 = Digger.Modules.Core.Sources.Utils.IndexToXYZ(index, SizeVox, SizeVox2);
			float3 float5 = int5 * HeightmapScale;
			float3 float6 = float5 + ChunkWorldPosition;
			float num = Heights[Digger.Modules.Core.Sources.Utils.XYZToHeightIndex(int5, SizeVox)];
			float terrainHeightValue = float6.y - num;
			float num2 = ComputeSphereDistance(float5);
			if (num2 < 0f)
			{
				return;
			}
			Voxel voxel = Voxels[index];
			float3 float7 = Normals[Digger.Modules.Core.Sources.Utils.XZToNormalIndex(int5.x, int5.z, SizeVox)];
			float end = math.max(voxel.Value, voxel.Value + math.lerp(Intensity * 2f, 0f, math.clamp(float7.y, 0f, 1f)));
			voxel.SetValue(math.lerp(voxel.Value, end, math.clamp(num2, 0f, 1f)), HeightmapScale.y);
			voxel.Alteration = 5u;
			voxel.AddTexture(TextureIndex, 1f);
			if (voxel.Alteration != 0)
			{
				voxel = Digger.Modules.Core.Sources.Utils.AdjustAlteration(voxel, int5, HeightmapScale.y, float6.y, terrainHeightValue, SizeVox, Heights);
			}
			if (voxel.IsAlteredNearBelowSurface || voxel.IsAlteredNearAboveSurface)
			{
				Digger.Modules.Core.Sources.NativeCollections.Utils.IncrementAt(Holes, Digger.Modules.Core.Sources.Utils.XZToHoleIndex(int5.x, int5.z, SizeVox));
				if (int5.x >= 1)
				{
					Digger.Modules.Core.Sources.NativeCollections.Utils.IncrementAt(Holes, Digger.Modules.Core.Sources.Utils.XZToHoleIndex(int5.x - 1, int5.z, SizeVox));
					if (int5.z >= 1)
					{
						Digger.Modules.Core.Sources.NativeCollections.Utils.IncrementAt(Holes, Digger.Modules.Core.Sources.Utils.XZToHoleIndex(int5.x - 1, int5.z - 1, SizeVox));
					}
				}
				if (int5.z >= 1)
				{
					Digger.Modules.Core.Sources.NativeCollections.Utils.IncrementAt(Holes, Digger.Modules.Core.Sources.Utils.XZToHoleIndex(int5.x, int5.z - 1, SizeVox));
				}
			}
			Voxels[index] = voxel;
		}

		private float ComputeSphereDistance(float3 p)
		{
			float3 float5 = p - Center;
			float num = (float)Math.Sqrt(float5.x * float5.x + float5.y * float5.y + float5.z * float5.z);
			return Radius - num;
		}
	}
}
