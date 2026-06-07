using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Digger.Modules.Core.Sources.Jobs
{
	[BurstCompile(CompileSynchronously = true, FloatMode = FloatMode.Fast, OptimizeFor = OptimizeFor.Performance)]
	public struct AdvancedVoxelGenerationJob : IJobParallelFor
	{
		public int3 ChunkVoxelPosition;

		public int SizeVox;

		public int SizeVox2;

		public float3 HeightmapScale;

		public int RefreshOnly;

		public int DepthLayerCount;

		[ReadOnly]
		public NativeArray<float> DepthThresholds;

		[ReadOnly]
		public NativeArray<int> DepthTextures;

		[ReadOnly]
		public NativeArray<float> DepthDestructible;

		public int NoiseLayerCount;

		[ReadOnly]
		public NativeArray<float> NoiseScales;

		[ReadOnly]
		public NativeArray<int> NoiseOctaves;

		[ReadOnly]
		public NativeArray<float> NoisePersistences;

		[ReadOnly]
		public NativeArray<float> NoiseDestructible;

		[ReadOnly]
		public NativeArray<int> NoiseTextureIndices;

		[ReadOnly]
		public NativeArray<int> NoiseBlendModes;

		[ReadOnly]
		public NativeArray<float> NoiseThresholds;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<float> Heights;

		public NativeArray<Voxel> Voxels;

		public void Execute(int index)
		{
			if (RefreshOnly != 1 || !Voxels[index].IsAlteredFarOrNearSurface)
			{
				int3 int5 = Utils.IndexToXYZ(index, SizeVox, SizeVox2);
				float num = Heights[Utils.XYZToHeightIndex(int5, SizeVox)];
				float3 float5 = Utils.ChunkVoxelToUnityPosition(ChunkVoxelPosition, int5, HeightmapScale);
				float y = float5.y;
				if (RefreshOnly == 1 && !Voxels[index].IsAlteredFarOrNearSurface)
				{
					Voxels[index].SetValue(float5.y - num, HeightmapScale.y);
					return;
				}
				Voxel value = new Voxel(y - num, HeightmapScale.y);
				float num2 = ComputeStrengthAt(int5);
				uint textureIndex = ComputeTextureIndexAt(int5);
				value.SetMaxValue(HeightmapScale.y - 2f * num2 * HeightmapScale.y, HeightmapScale.y);
				value.AddTexture(textureIndex, 1f);
				Voxels[index] = value;
			}
		}

		private float ComputeStrengthAt(int3 pi)
		{
			float num = Heights[Utils.XYZToHeightIndex(pi, SizeVox)];
			float3 float5 = Utils.ChunkVoxelToUnityPosition(ChunkVoxelPosition, pi, HeightmapScale);
			float num2 = num - float5.y;
			float num3 = 0f;
			if (DepthLayerCount > 0 && num2 > 0f)
			{
				for (int i = 0; i < DepthLayerCount && i < 8; i++)
				{
					if (num2 >= DepthThresholds[i])
					{
						num3 = math.lerp(num3, NoiseDestructible[i], math.clamp((num2 - DepthThresholds[i]) / HeightmapScale.y, 0f, 1f));
						break;
					}
				}
			}
			for (int j = 0; j < NoiseLayerCount && j < 8; j++)
			{
				float num4 = Noise3D(float5 / NoiseScales[j], NoiseOctaves[j], NoisePersistences[j]) + (math.saturate(0.8f * num2 / HeightmapScale.y) - 1f);
				float num5 = NoiseThresholds[j];
				float num6 = math.clamp(num4 - num5, -1f, 1f);
				float num7 = NoiseDestructible[j];
				switch (NoiseBlendModes[j])
				{
				case 0:
					num3 = math.lerp(num3, num7, num6);
					break;
				case 1:
				{
					float num8 = num7 * num6;
					num3 = math.clamp(num3 + num8, 0f, 1f);
					break;
				}
				}
			}
			return num3;
		}

		private uint ComputeTextureIndexAt(int3 pi)
		{
			float num = Heights[Utils.XYZToHeightIndex(pi, SizeVox)];
			float3 float5 = Utils.ChunkVoxelToUnityPosition(ChunkVoxelPosition, pi, HeightmapScale);
			float num2 = num - float5.y;
			uint result = 0u;
			if (DepthLayerCount > 0 && num2 > 0f)
			{
				for (int i = 0; i < DepthLayerCount && i < 8; i++)
				{
					if (num2 >= DepthThresholds[i])
					{
						result = (uint)DepthTextures[i];
						break;
					}
				}
			}
			for (int j = 0; j < NoiseLayerCount && j < 8; j++)
			{
				if (NoiseTextureIndices[j] >= 0)
				{
					float num3 = Noise3D(float5 / NoiseScales[j], NoiseOctaves[j], NoisePersistences[j]);
					float num4 = NoiseThresholds[j];
					if (math.clamp(num3 - num4, -1f, 1f) > 0.001f)
					{
						result = (uint)NoiseTextureIndices[j];
					}
				}
			}
			return result;
		}

		private float Noise3D(float3 position, int octaves, float persistence)
		{
			float num = 0f;
			float num2 = 1f;
			float num3 = 1f;
			float num4 = 0f;
			for (int i = 0; i < octaves; i++)
			{
				num += noise.snoise(position * num2) * num3;
				num4 += num3;
				num3 *= persistence;
				num2 *= 2f;
			}
			return num / num4;
		}
	}
}
