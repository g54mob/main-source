using System;
using System.Collections.Generic;
using Mandragora.PWS;
using Restory.Data.Elements;
using Restory.ObjectPools;
using UnityEngine;
using UnityEngine.Rendering;
using Zenject;

namespace Restory.Gameplay.TextureMasks
{
	public class TextureMaskCreationService : IInitializable, IDisposable
	{
		private static readonly int ResultTextureParam = Shader.PropertyToID("Result");

		private static readonly int RandomSeedParam = Shader.PropertyToID("RandomSeed");

		private static readonly int RedChannelParam = Shader.PropertyToID("RedChannel");

		private static readonly int GreenChannelParam = Shader.PropertyToID("GreenChannel");

		private static readonly int BlueChannelParam = Shader.PropertyToID("BlueChannel");

		private static readonly int CoverageMaskParam = Shader.PropertyToID("CoverageMask");

		private static readonly int TrianglesParam = Shader.PropertyToID("Triangles");

		private static readonly int SettingsParam = Shader.PropertyToID("Settings");

		private static readonly int TriangleCountParam = Shader.PropertyToID("TriangleCount");

		private static readonly int TextureSizeXParam = Shader.PropertyToID("TextureSizeX");

		private static readonly int TextureSizeYParam = Shader.PropertyToID("TextureSizeY");

		private static readonly int PixelCounter = Shader.PropertyToID("PixelCounter");

		private readonly ComputeShader computeShader;

		private readonly ComputeShader meshUVRasterizerShader;

		private readonly ComputeShader uvMaskPaddingAddingComputeShader;

		private readonly MaskPresetInfoBase defaultMaskPreset;

		private readonly RenderTexturePool renderTexturePool;

		private int computeShaderKernel;

		private int meshRasterizerKernel;

		private ComputeBuffer resultBuffer;

		private ComputeBuffer redChannelBuffer;

		private ComputeBuffer greenChannelBuffer;

		private ComputeBuffer blueChannelBuffer;

		private ComputeBuffer trianglesBuffer;

		private ComputeBuffer settingsBuffer;

		private ComputeBuffer pixelCounterBuffer;

		private readonly float[] colorChannelBufferData = new float[5];

		private readonly uint[] pixelCountArray = new uint[1];

		private int uvMaskPaddingAddingComputeShaderKernel;

		public TextureMaskCreationService(ComputeShader computeShader, ComputeShader meshUVRasterizerShader, ComputeShader uvMaskPaddingAddingComputeShader, MaskPresetInfoBase defaultMaskPreset, RenderTexturePool renderTexturePool)
		{
			this.computeShader = computeShader;
			this.meshUVRasterizerShader = meshUVRasterizerShader;
			this.uvMaskPaddingAddingComputeShader = uvMaskPaddingAddingComputeShader;
			this.defaultMaskPreset = defaultMaskPreset;
			this.renderTexturePool = renderTexturePool;
		}

		public void Initialize()
		{
			if (computeShader != null)
			{
				computeShaderKernel = computeShader.FindKernel("GradientNoiseGenerator");
			}
			if (meshUVRasterizerShader != null)
			{
				meshRasterizerKernel = meshUVRasterizerShader.FindKernel("RasterizeTriangles");
			}
			if (uvMaskPaddingAddingComputeShader != null)
			{
				uvMaskPaddingAddingComputeShaderKernel = uvMaskPaddingAddingComputeShader.FindKernel("DilateMask");
			}
			redChannelBuffer = new ComputeBuffer(1, 20);
			greenChannelBuffer = new ComputeBuffer(1, 20);
			blueChannelBuffer = new ComputeBuffer(1, 20);
			settingsBuffer = new ComputeBuffer(1, 16);
			pixelCounterBuffer = new ComputeBuffer(1, 4, ComputeBufferType.Structured);
			PrewarmTexturePool();
		}

		public void Dispose()
		{
			if (resultBuffer != null)
			{
				resultBuffer.Release();
				resultBuffer = null;
			}
			if (redChannelBuffer != null)
			{
				redChannelBuffer.Release();
			}
			if (greenChannelBuffer != null)
			{
				greenChannelBuffer.Release();
			}
			if (blueChannelBuffer != null)
			{
				blueChannelBuffer.Release();
			}
			if (trianglesBuffer != null)
			{
				trianglesBuffer.Release();
				trianglesBuffer = null;
			}
			if (settingsBuffer != null)
			{
				settingsBuffer.Release();
				settingsBuffer = null;
			}
			if (pixelCounterBuffer != null)
			{
				pixelCounterBuffer.Release();
				pixelCounterBuffer = null;
			}
		}

		public Texture2D CreateTextureMask(Vector2Int textureMaskSize, MaskPresetInfoBase preset, float noiseSeed)
		{
			return GenerateTextureMask(textureMaskSize, preset, noiseSeed);
		}

		public Texture2D CreateTextureMask(Vector2Int textureMaskSize, MaskPresetInfoBase preset, out float resultingNoiseSeed)
		{
			resultingNoiseSeed = GetRandomOrDebugNoiseSeed(preset);
			return GenerateTextureMask(textureMaskSize, preset, resultingNoiseSeed);
		}

		public Texture2D CreateTextureMaskWithMesh(Texture2D sourceTexture, MaskPresetInfoBase specificPreset, Mesh mesh, MeshUVProcessor.ProcessingSettings meshSettings, float noiseSeed, out int pixelsOnMeshCount)
		{
			if (specificPreset == null)
			{
				specificPreset = defaultMaskPreset;
			}
			return GenerateTextureMaskWithMesh(sourceTexture, specificPreset, mesh, meshSettings, noiseSeed, out pixelsOnMeshCount);
		}

		public bool TryCreateMeshUVCoverageMask(Mesh mesh, MeshUVProcessor.ProcessingSettings meshSettings, Texture2D targetMaskTexture, out int pixelsCountOnMesh, int padding = 0)
		{
			if (!mesh)
			{
				Debug.LogError("[TextureMaskCreationService] failed to create a UV coverage mask, because the supplied mesh was NULL.");
				pixelsCountOnMesh = 0;
				return false;
			}
			if (!targetMaskTexture)
			{
				Debug.LogError("[TextureMaskCreationService] failed to create a UV coverage mask, because there was no target texture supplied.");
				pixelsCountOnMesh = 0;
				return false;
			}
			Vector2Int textureSize = new Vector2Int(targetMaskTexture.width, targetMaskTexture.height);
			RenderTexture renderTexture = CreateMeshUVCoverageMaskGPU(mesh, textureSize, meshSettings, out pixelsCountOnMesh);
			if (padding > 0)
			{
				RenderTexture orCreateCoverageMaskTexture = GetOrCreateCoverageMaskTexture(textureSize);
				AddPaddingToMeshUVCoverageMask(renderTexture, orCreateCoverageMaskTexture, padding);
				Graphics.CopyTexture(orCreateCoverageMaskTexture, targetMaskTexture);
				ReleaseTexture(renderTexture);
				ReleaseTexture(orCreateCoverageMaskTexture);
			}
			else
			{
				Graphics.CopyTexture(renderTexture, targetMaskTexture);
				ReleaseTexture(renderTexture);
			}
			return true;
		}

		public bool TryCreateMeshUVCoverageMask(IEnumerable<Mesh> meshes, MeshUVProcessor.ProcessingSettings meshSettings, Texture2D targetMaskTexture, out int pixelsCountOnMesh, int padding = 0)
		{
			if (meshes == null)
			{
				Debug.LogError("[TextureMaskCreationService] failed to create a UV coverage mask, because the supplied meshes collection was NULL.");
				pixelsCountOnMesh = 0;
				return false;
			}
			if (!targetMaskTexture)
			{
				Debug.LogError("[TextureMaskCreationService] failed to create a UV coverage mask, because there was no target texture supplied.");
				pixelsCountOnMesh = 0;
				return false;
			}
			List<GPUTriangle> list = new List<GPUTriangle>();
			foreach (Mesh mesh in meshes)
			{
				AddMeshTriangles(mesh, list);
			}
			if (list.Count == 0)
			{
				Debug.LogError("[TextureMaskCreationService] failed to create a UV coverage mask, because no valid mesh triangles were supplied.");
				pixelsCountOnMesh = 0;
				return false;
			}
			Vector2Int textureSize = new Vector2Int(targetMaskTexture.width, targetMaskTexture.height);
			RenderTexture renderTexture = RasterizeTrianglesGPU(list, textureSize, meshSettings, out pixelsCountOnMesh);
			if (padding > 0)
			{
				RenderTexture orCreateCoverageMaskTexture = GetOrCreateCoverageMaskTexture(textureSize);
				AddPaddingToMeshUVCoverageMask(renderTexture, orCreateCoverageMaskTexture, padding);
				Graphics.CopyTexture(orCreateCoverageMaskTexture, targetMaskTexture);
				ReleaseTexture(renderTexture);
				ReleaseTexture(orCreateCoverageMaskTexture);
			}
			else
			{
				Graphics.CopyTexture(renderTexture, targetMaskTexture);
				ReleaseTexture(renderTexture);
			}
			return true;
		}

		public float GetRandomOrDebugNoiseSeed(MaskPresetInfoBase preset, ElementInfo elementInfo = null)
		{
			if (!preset)
			{
				preset = defaultMaskPreset;
			}
			if (preset.IsInDebugMode)
			{
				return preset.PredefinedSeed;
			}
			if (!elementInfo)
			{
				return UnityEngine.Random.value;
			}
			if (elementInfo.ProvenNoiseSeeds.Count == 0)
			{
				Debug.LogError("Failed to get proven noise seed from " + elementInfo.ID + ", ProvenNoiseSeeds collection is empty.");
				return UnityEngine.Random.value;
			}
			int index = UnityEngine.Random.Range(0, elementInfo.ProvenNoiseSeeds.Count);
			return elementInfo.ProvenNoiseSeeds[index];
		}

		private Texture2D GenerateTextureMask(Vector2Int textureSize, MaskPresetInfoBase specificPreset, float noiseSeed)
		{
			Texture2D texture2D = new Texture2D(textureSize.x, textureSize.y, TextureFormat.RGBA32, mipChain: false);
			RenderTexture orCreateResultTexture = GetOrCreateResultTexture(textureSize);
			PrepareResultBuffer(textureSize.x * textureSize.y);
			PrepareAndExecuteCommandBuffer(specificPreset ? specificPreset : defaultMaskPreset, textureSize, orCreateResultTexture, noiseSeed);
			Graphics.CopyTexture(orCreateResultTexture, texture2D);
			ReleaseTexture(orCreateResultTexture);
			return texture2D;
		}

		private void PrepareResultBuffer(int textureAreaSize)
		{
			resultBuffer?.Release();
			resultBuffer = new ComputeBuffer(textureAreaSize, 4);
		}

		private void PrepareAndExecuteCommandBuffer(MaskPresetInfoBase preset, Vector2Int textureSize, RenderTexture resultTexture, float noiseSeed)
		{
			CommandBuffer commandBuffer = CommandBufferPool.Get("DirtyMaskGeneratorCommandBuffer");
			commandBuffer.SetComputeTextureParam(computeShader, computeShaderKernel, ResultTextureParam, resultTexture);
			SetChannelBuffer(commandBuffer, redChannelBuffer, preset.RedChannel, RedChannelParam);
			SetChannelBuffer(commandBuffer, greenChannelBuffer, preset.GreenChannel, GreenChannelParam);
			SetChannelBuffer(commandBuffer, blueChannelBuffer, preset.BlueChannel, BlueChannelParam);
			commandBuffer.SetComputeFloatParam(computeShader, RandomSeedParam, noiseSeed);
			computeShader.GetKernelThreadGroupSizes(computeShaderKernel, out var x, out var y, out var _);
			int threadGroupsX = Mathf.CeilToInt((float)textureSize.x / (float)x);
			int threadGroupsY = Mathf.CeilToInt((float)textureSize.y / (float)y);
			commandBuffer.DispatchCompute(computeShader, computeShaderKernel, threadGroupsX, threadGroupsY, 1);
			Graphics.ExecuteCommandBuffer(commandBuffer);
			CommandBufferPool.Release(commandBuffer);
		}

		private void SetChannelBuffer(CommandBuffer commandBuffer, ComputeBuffer targetBuffer, ChannelGenerationEntry channelGenerationEntry, int parameterIndex)
		{
			colorChannelBufferData[0] = channelGenerationEntry.NoiseScale;
			colorChannelBufferData[1] = channelGenerationEntry.MinColorValueClamp;
			colorChannelBufferData[2] = channelGenerationEntry.MaxColorValueClamp;
			colorChannelBufferData[3] = channelGenerationEntry.MinEdgeSmoothStepValue;
			colorChannelBufferData[4] = channelGenerationEntry.MaxEdgeSmoothStepValue;
			targetBuffer.SetData(colorChannelBufferData);
			commandBuffer.SetComputeBufferParam(computeShader, computeShaderKernel, parameterIndex, targetBuffer);
		}

		private Texture2D GenerateTextureMaskWithMesh(Texture2D sourceTexture, MaskPresetInfoBase specificPreset, Mesh mesh, MeshUVProcessor.ProcessingSettings meshSettings, float noiseSeed, out int pixelsCountOnMesh)
		{
			Vector2Int textureSize = new Vector2Int(sourceTexture.width, sourceTexture.height);
			RenderTexture renderTexture = CreateMeshUVCoverageMaskGPU(mesh, textureSize, meshSettings, out pixelsCountOnMesh);
			RenderTexture orCreateResultTexture = GetOrCreateResultTexture(textureSize);
			PrepareResultBuffer(textureSize.x * textureSize.y);
			PrepareAndExecuteCommandBufferWithCoverageMaskRT(specificPreset, textureSize, renderTexture, orCreateResultTexture, noiseSeed);
			Graphics.CopyTexture(orCreateResultTexture, sourceTexture);
			ReleaseTexture(renderTexture);
			ReleaseTexture(orCreateResultTexture);
			return sourceTexture;
		}

		private void PrepareAndExecuteCommandBufferWithCoverageMaskRT(MaskPresetInfoBase preset, Vector2Int textureSize, RenderTexture coverageMask, RenderTexture resultTexture, float noiseSeed)
		{
			CommandBuffer commandBuffer = CommandBufferPool.Get("DirtyMaskGeneratorWithCoverageMaskCommandBuffer");
			commandBuffer.SetComputeTextureParam(computeShader, computeShaderKernel, ResultTextureParam, resultTexture);
			SetChannelBuffer(commandBuffer, redChannelBuffer, preset.RedChannel, RedChannelParam);
			SetChannelBuffer(commandBuffer, greenChannelBuffer, preset.GreenChannel, GreenChannelParam);
			SetChannelBuffer(commandBuffer, blueChannelBuffer, preset.BlueChannel, BlueChannelParam);
			commandBuffer.SetComputeTextureParam(computeShader, computeShaderKernel, CoverageMaskParam, coverageMask);
			commandBuffer.SetComputeFloatParam(computeShader, RandomSeedParam, noiseSeed);
			computeShader.GetKernelThreadGroupSizes(computeShaderKernel, out var x, out var y, out var _);
			int threadGroupsX = Mathf.CeilToInt((float)textureSize.x / (float)x);
			int threadGroupsY = Mathf.CeilToInt((float)textureSize.y / (float)y);
			commandBuffer.DispatchCompute(computeShader, computeShaderKernel, threadGroupsX, threadGroupsY, 1);
			Graphics.ExecuteCommandBuffer(commandBuffer);
			CommandBufferPool.Release(commandBuffer);
		}

		private RenderTexture CreateMeshUVCoverageMaskGPU(Mesh mesh, Vector2Int textureSize, MeshUVProcessor.ProcessingSettings settings, out int generatedPixelsCount)
		{
			if (settings.enableDebugOutput)
			{
				Debug.Log("\ud83d\udd0d GPU Mesh UV Processing Debug:");
				Debug.Log("   Mesh: " + (mesh?.name ?? "null"));
				Debug.Log($"   Texture Size: {textureSize}");
				Debug.Log($"   Wireframe: {settings.enableWireframe}");
				Debug.Log($"   Wire Thickness: {settings.wireThickness}");
			}
			if (mesh == null)
			{
				Debug.LogError("TextureMaskCreationService: Mesh is null");
				generatedPixelsCount = 0;
				return GetOrCreateCoverageMaskTexture(textureSize);
			}
			List<GPUTriangle> list = new List<GPUTriangle>();
			AddMeshTriangles(mesh, list);
			if (list.Count == 0)
			{
				generatedPixelsCount = 0;
				return GetOrCreateCoverageMaskTexture(textureSize);
			}
			RenderTexture result = RasterizeTrianglesGPU(list, textureSize, settings, out generatedPixelsCount);
			if (settings.enableDebugOutput)
			{
				Debug.Log($"✅ GPU Mesh UV Coverage Mask created: {list.Count} triangles processed");
			}
			return result;
		}

		private void AddMeshTriangles(Mesh mesh, List<GPUTriangle> gpuTriangles)
		{
			if (mesh == null)
			{
				Debug.LogError("TextureMaskCreationService: Mesh is null");
				return;
			}
			Vector2[] uv = mesh.uv;
			int[] triangles = mesh.triangles;
			if (uv == null || uv.Length == 0)
			{
				Debug.LogError("TextureMaskCreationService: Mesh has no UV coordinates");
				return;
			}
			if (triangles == null || triangles.Length == 0)
			{
				Debug.LogError("TextureMaskCreationService: Mesh has no triangles");
				return;
			}
			for (int i = 0; i < triangles.Length; i += 3)
			{
				gpuTriangles.Add(new GPUTriangle
				{
					uv0 = uv[triangles[i]],
					uv1 = uv[triangles[i + 1]],
					uv2 = uv[triangles[i + 2]]
				});
			}
		}

		private RenderTexture RasterizeTrianglesGPU(List<GPUTriangle> triangles, Vector2Int textureSize, MeshUVProcessor.ProcessingSettings settings, out int pixelsCountInCoverageMask)
		{
			if (meshUVRasterizerShader == null)
			{
				Debug.LogError("TextureMaskCreationService: MeshUVRasterizer shader is null");
				pixelsCountInCoverageMask = textureSize.x * textureSize.y;
				return GetOrCreateCoverageMaskTexture(textureSize);
			}
			RenderTexture orCreateCoverageMaskTexture = GetOrCreateCoverageMaskTexture(textureSize);
			PrepareTrianglesBuffer(triangles);
			PrepareSettingsBuffer(settings);
			PreparePixelCounterBuffer();
			CommandBuffer commandBuffer = CommandBufferPool.Get("MeshUVRasterizerCommandBuffer");
			commandBuffer.SetComputeTextureParam(meshUVRasterizerShader, meshRasterizerKernel, ResultTextureParam, orCreateCoverageMaskTexture);
			commandBuffer.SetComputeBufferParam(meshUVRasterizerShader, meshRasterizerKernel, TrianglesParam, trianglesBuffer);
			commandBuffer.SetComputeBufferParam(meshUVRasterizerShader, meshRasterizerKernel, SettingsParam, settingsBuffer);
			commandBuffer.SetComputeIntParam(meshUVRasterizerShader, TriangleCountParam, triangles.Count);
			commandBuffer.SetComputeIntParam(meshUVRasterizerShader, TextureSizeXParam, textureSize.x);
			commandBuffer.SetComputeIntParam(meshUVRasterizerShader, TextureSizeYParam, textureSize.y);
			commandBuffer.SetComputeBufferParam(meshUVRasterizerShader, meshRasterizerKernel, PixelCounter, pixelCounterBuffer);
			meshUVRasterizerShader.GetKernelThreadGroupSizes(meshRasterizerKernel, out var x, out var _, out var _);
			int threadGroupsX = Mathf.CeilToInt((float)triangles.Count / (float)x);
			int threadGroupsY = 1;
			int threadGroupsZ = 1;
			commandBuffer.DispatchCompute(meshUVRasterizerShader, meshRasterizerKernel, threadGroupsX, threadGroupsY, threadGroupsZ);
			Graphics.ExecuteCommandBuffer(commandBuffer);
			CommandBufferPool.Release(commandBuffer);
			pixelCounterBuffer.GetData(pixelCountArray);
			pixelsCountInCoverageMask = (int)pixelCountArray[0];
			return orCreateCoverageMaskTexture;
		}

		private RenderTexture GetOrCreateCoverageMaskTexture(Vector2Int textureSize)
		{
			return renderTexturePool.Get(textureSize.x, textureSize.y, RenderTextureFormat.R8, RenderTextureReadWrite.Linear, "CoverageMaskTexture");
		}

		private RenderTexture GetOrCreateResultTexture(Vector2Int textureSize)
		{
			return renderTexturePool.Get(textureSize.x, textureSize.y, RenderTextureFormat.ARGB32, RenderTextureReadWrite.sRGB, "ResultTexture");
		}

		private void ReleaseTexture(RenderTexture renderTexture)
		{
			renderTexturePool.Release(renderTexture);
		}

		private void PrepareTrianglesBuffer(List<GPUTriangle> triangles)
		{
			if (triangles != null && triangles.Count != 0)
			{
				trianglesBuffer?.Release();
				trianglesBuffer = new ComputeBuffer(triangles.Count, 24);
				trianglesBuffer.SetData(triangles);
			}
		}

		private void PrepareSettingsBuffer(MeshUVProcessor.ProcessingSettings settings)
		{
			GPUProcessingSettings gPUProcessingSettings = new GPUProcessingSettings
			{
				enableWireframe = (settings.enableWireframe ? 1f : 0f),
				wireThickness = settings.wireThickness,
				wrapUV = (settings.wrapUV ? 1f : 0f),
				enableDebugOutput = (settings.enableDebugOutput ? 1f : 0f)
			};
			settingsBuffer.SetData(new GPUProcessingSettings[1] { gPUProcessingSettings });
		}

		private void PreparePixelCounterBuffer()
		{
			uint[] data = new uint[1];
			pixelCounterBuffer.SetData(data);
		}

		private void AddPaddingToMeshUVCoverageMask(RenderTexture source, RenderTexture destination, int padding)
		{
			uvMaskPaddingAddingComputeShader.SetTexture(uvMaskPaddingAddingComputeShaderKernel, "InputMask", source);
			uvMaskPaddingAddingComputeShader.SetTexture(uvMaskPaddingAddingComputeShaderKernel, "OutputMask", destination);
			uvMaskPaddingAddingComputeShader.SetInt("Width", source.width);
			uvMaskPaddingAddingComputeShader.SetInt("Height", source.height);
			uvMaskPaddingAddingComputeShader.SetInt("Padding", padding);
			int threadGroupsX = Mathf.CeilToInt((float)source.width / 8f);
			int threadGroupsY = Mathf.CeilToInt((float)source.height / 8f);
			uvMaskPaddingAddingComputeShader.Dispatch(uvMaskPaddingAddingComputeShaderKernel, threadGroupsX, threadGroupsY, 1);
		}

		private void PrewarmTexturePool()
		{
			renderTexturePool.Prewarm(2, 2048, 2048, RenderTextureFormat.R8, RenderTextureReadWrite.Linear, "CoverageMaskTexture");
			renderTexturePool.Prewarm(2, 1024, 1024, RenderTextureFormat.R8, RenderTextureReadWrite.Linear, "CoverageMaskTexture");
			renderTexturePool.Prewarm(2, 2048, 2048, RenderTextureFormat.ARGB32, RenderTextureReadWrite.sRGB, "ResultTexture");
			renderTexturePool.Prewarm(2, 1024, 1024, RenderTextureFormat.ARGB32, RenderTextureReadWrite.sRGB, "ResultTexture");
		}
	}
}
