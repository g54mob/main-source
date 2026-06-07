using System;
using System.Collections.Generic;
using Digger.Modules.Core.Sources.Jobs;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Digger.Modules.Core.Sources.Generators
{
	[CreateAssetMenu(fileName = "AdvancedVoxelGenerator", menuName = "Digger/Voxel Generators/Advanced Generator", order = 2)]
	public class AdvancedVoxelGenerator : ScriptableObject, IVoxelGenerator
	{
		[Serializable]
		public enum NoiseBlendMode
		{
			Replace = 0,
			Add = 1
		}

		[Serializable]
		public class DepthLayer
		{
			[Tooltip("Minimum depth below surface (in world units) where this texture starts to appear")]
			public float minDepth = 5f;

			[Tooltip("Texture index to use for this depth range")]
			public int textureIndex = 1;

			[Tooltip("Whether voxels in this layer can be destroyed")]
			public bool destructible = true;

			[Tooltip("VFX type to play when digging this layer (maps to LayerVFX enum)")]
			public int vfxType;

			[Tooltip("SFX type to play when digging this layer (maps to LayerSFX enum)")]
			public int sfxType;
		}

		[Serializable]
		public class NoiseLayer
		{
			[Tooltip("Scale of the Perlin noise. Higher values = larger patterns")]
			[Range(1f, 100f)]
			public float scale = 15f;

			[Tooltip("Number of noise octaves. More octaves = more detail")]
			[Range(1f, 4f)]
			public int octaves = 2;

			[Tooltip("Persistence of noise between octaves. Higher = rougher")]
			[Range(0.1f, 1f)]
			public float persistence = 0.5f;

			[Tooltip("How this layer combines with previous layers")]
			public NoiseBlendMode blendMode = NoiseBlendMode.Add;

			[Tooltip("Noise threshold with smooth transition. Effect gradually fades in/out around this value (normalized -1 to 1)")]
			[Range(-1f, 1f)]
			public float threshold = -0.2f;

			[Tooltip("Texture index override (-1 for no override)")]
			public int textureIndex = -1;

			[Tooltip("Whether voxels affected by this noise layer can be destroyed")]
			public bool destructible = true;
		}

		[Header("Depth-Based Layers")]
		[Tooltip("Texture and destructibility layers based on depth below surface. Sorted by depth (deepest first).")]
		public List<DepthLayer> depthLayers = new List<DepthLayer>
		{
			new DepthLayer
			{
				minDepth = 0f,
				textureIndex = 0,
				destructible = true
			}
		};

		[Header("Noise-Based Layers")]
		[Tooltip("Procedural layers based on Perlin noise. Applied in order after depth layers.")]
		public List<NoiseLayer> noiseLayers = new List<NoiseLayer>();

		public JobHandle GenerateVoxels(float[] heightArray, int3 chunkVoxelPosition, int sizeVox, float3 heightmapScale, NativeArray<float> heights, NativeArray<Voxel> voxels, bool refreshOnly)
		{
			List<DepthLayer> list = new List<DepthLayer>(depthLayers);
			list.Sort((DepthLayer a, DepthLayer b) => b.minDepth.CompareTo(a.minDepth));
			int num = Math.Min(list.Count, 8);
			NativeArray<float> depthThresholds = new NativeArray<float>(8, Allocator.TempJob);
			NativeArray<int> depthTextures = new NativeArray<int>(8, Allocator.TempJob);
			NativeArray<float> depthDestructible = new NativeArray<float>(8, Allocator.TempJob);
			for (int num2 = 0; num2 < num; num2++)
			{
				depthThresholds[num2] = list[num2].minDepth;
				depthTextures[num2] = list[num2].textureIndex;
				depthDestructible[num2] = (list[num2].destructible ? 0f : 1f);
			}
			int num3 = Math.Min(noiseLayers.Count, 8);
			NativeArray<float> noiseScales = new NativeArray<float>(8, Allocator.TempJob);
			NativeArray<int> noiseOctaves = new NativeArray<int>(8, Allocator.TempJob);
			NativeArray<float> noisePersistences = new NativeArray<float>(8, Allocator.TempJob);
			NativeArray<float> noiseDestructible = new NativeArray<float>(8, Allocator.TempJob);
			NativeArray<int> noiseTextureIndices = new NativeArray<int>(8, Allocator.TempJob);
			NativeArray<int> noiseBlendModes = new NativeArray<int>(8, Allocator.TempJob);
			NativeArray<float> noiseThresholds = new NativeArray<float>(8, Allocator.TempJob);
			for (int num4 = 0; num4 < num3; num4++)
			{
				noiseScales[num4] = noiseLayers[num4].scale;
				noiseOctaves[num4] = noiseLayers[num4].octaves;
				noisePersistences[num4] = noiseLayers[num4].persistence;
				noiseDestructible[num4] = (noiseLayers[num4].destructible ? 0f : 1f);
				noiseTextureIndices[num4] = noiseLayers[num4].textureIndex;
				noiseBlendModes[num4] = (int)noiseLayers[num4].blendMode;
				noiseThresholds[num4] = noiseLayers[num4].threshold;
			}
			JobHandle inputDeps = IJobParallelForExtensions.Schedule(new AdvancedVoxelGenerationJob
			{
				RefreshOnly = (refreshOnly ? 1 : 0),
				ChunkVoxelPosition = chunkVoxelPosition,
				Heights = heights,
				Voxels = voxels,
				SizeVox = sizeVox,
				SizeVox2 = sizeVox * sizeVox,
				HeightmapScale = heightmapScale,
				DepthLayerCount = num,
				DepthThresholds = depthThresholds,
				DepthTextures = depthTextures,
				DepthDestructible = depthDestructible,
				NoiseLayerCount = num3,
				NoiseScales = noiseScales,
				NoiseOctaves = noiseOctaves,
				NoisePersistences = noisePersistences,
				NoiseDestructible = noiseDestructible,
				NoiseTextureIndices = noiseTextureIndices,
				NoiseBlendModes = noiseBlendModes,
				NoiseThresholds = noiseThresholds
			}, voxels.Length, 64);
			inputDeps = depthThresholds.Dispose(inputDeps);
			inputDeps = depthTextures.Dispose(inputDeps);
			inputDeps = depthDestructible.Dispose(inputDeps);
			inputDeps = noiseScales.Dispose(inputDeps);
			inputDeps = noiseOctaves.Dispose(inputDeps);
			inputDeps = noisePersistences.Dispose(inputDeps);
			inputDeps = noiseDestructible.Dispose(inputDeps);
			inputDeps = noiseTextureIndices.Dispose(inputDeps);
			inputDeps = noiseBlendModes.Dispose(inputDeps);
			return noiseThresholds.Dispose(inputDeps);
		}
	}
}
