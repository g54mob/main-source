using System;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

public sealed class VolumetricFogRenderPass : ScriptableRenderPass
{
	private enum DownsampleFactor : byte
	{
		Half = 2
	}

	private enum PassStage : byte
	{
		DownsampleDepth = 0,
		VolumetricFogRender = 1,
		VolumetricFogBlur = 2,
		VolumetricFogUpsampleComposition = 3
	}

	private class PassData
	{
		public PassStage stage;

		public TextureHandle source;

		public TextureHandle target;

		public Material material;

		public int materialPassIndex;

		public int materialAdditionalPassIndex;

		public TextureHandle downsampledCameraDepthTarget;

		public TextureHandle volumetricFogRenderTarget;

		public UniversalLightData lightData;
	}

	public const RenderPassEvent DefaultRenderPassEvent = RenderPassEvent.BeforeRenderingPostProcessing;

	public const VolumetricFogRenderPassEvent DefaultVolumetricFogRenderPassEvent = VolumetricFogRenderPassEvent.BeforeRenderingPostProcessing;

	private const string DownsampledCameraDepthRTName = "_DownsampledCameraDepth";

	private const string VolumetricFogRenderRTName = "_VolumetricFog";

	private const string VolumetricFogBlurRTName = "_VolumetricFogBlur";

	private const string VolumetricFogUpsampleCompositionRTName = "_VolumetricFogUpsampleComposition";

	private static readonly int DownsampledCameraDepthTextureId = Shader.PropertyToID("_DownsampledCameraDepthTexture");

	private static readonly int VolumetricFogTextureId = Shader.PropertyToID("_VolumetricFogTexture");

	private static readonly int FrameCountId = Shader.PropertyToID("_FrameCount");

	private static readonly int CustomAdditionalLightsCountId = Shader.PropertyToID("_CustomAdditionalLightsCount");

	private static readonly int DistanceId = Shader.PropertyToID("_Distance");

	private static readonly int BaseHeightId = Shader.PropertyToID("_BaseHeight");

	private static readonly int MaximumHeightId = Shader.PropertyToID("_MaximumHeight");

	private static readonly int GroundHeightId = Shader.PropertyToID("_GroundHeight");

	private static readonly int DensityId = Shader.PropertyToID("_Density");

	private static readonly int AbsortionId = Shader.PropertyToID("_Absortion");

	private static readonly int APVContributionWeigthId = Shader.PropertyToID("_APVContributionWeight");

	private static readonly int TintId = Shader.PropertyToID("_Tint");

	private static readonly int MaxStepsId = Shader.PropertyToID("_MaxSteps");

	private static readonly int AnisotropiesArrayId = Shader.PropertyToID("_Anisotropies");

	private static readonly int ScatteringsArrayId = Shader.PropertyToID("_Scatterings");

	private static readonly int RadiiSqArrayId = Shader.PropertyToID("_RadiiSq");

	private static int LightsParametersLength = UniversalRenderPipeline.maxVisibleAdditionalLights + 1;

	private static readonly float[] Anisotropies = new float[LightsParametersLength];

	private static readonly float[] Scatterings = new float[LightsParametersLength];

	private static readonly float[] RadiiSq = new float[LightsParametersLength];

	private int downsampleDepthPassIndex;

	private int volumetricFogRenderPassIndex;

	private int volumetricFogHorizontalBlurPassIndex;

	private int volumetricFogVerticalBlurPassIndex;

	private int volumetricFogUpsampleCompositionPassIndex;

	private Material downsampleDepthMaterial;

	private Material volumetricFogMaterial;

	private RTHandle downsampledCameraDepthRTHandle;

	private RTHandle volumetricFogRenderRTHandle;

	private RTHandle volumetricFogBlurRTHandle;

	private RTHandle volumetricFogUpsampleCompositionRTHandle;

	private ProfilingSampler downsampleDepthProfilingSampler;

	public VolumetricFogRenderPass(Material downsampleDepthMaterial, Material volumetricFogMaterial, RenderPassEvent passEvent)
	{
		base.profilingSampler = new ProfilingSampler("Volumetric Fog");
		downsampleDepthProfilingSampler = new ProfilingSampler("Downsample Depth");
		base.renderPassEvent = passEvent;
		base.requiresIntermediateTexture = false;
		this.downsampleDepthMaterial = downsampleDepthMaterial;
		this.volumetricFogMaterial = volumetricFogMaterial;
		InitializePassesIndices();
	}

	private void InitializePassesIndices()
	{
		downsampleDepthPassIndex = downsampleDepthMaterial.FindPass("DownsampleDepth");
		volumetricFogRenderPassIndex = volumetricFogMaterial.FindPass("VolumetricFogRender");
		volumetricFogHorizontalBlurPassIndex = volumetricFogMaterial.FindPass("VolumetricFogHorizontalBlur");
		volumetricFogVerticalBlurPassIndex = volumetricFogMaterial.FindPass("VolumetricFogVerticalBlur");
		volumetricFogUpsampleCompositionPassIndex = volumetricFogMaterial.FindPass("VolumetricFogUpsampleComposition");
	}

	[Obsolete]
	public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
	{
		base.OnCameraSetup(cmd, ref renderingData);
		RenderTextureDescriptor descriptor = renderingData.cameraData.cameraTargetDescriptor;
		descriptor.depthBufferBits = 0;
		RenderTextureFormat colorFormat = descriptor.colorFormat;
		Vector2Int vector2Int = new Vector2Int(descriptor.width, descriptor.height);
		descriptor.width /= 2;
		descriptor.height /= 2;
		descriptor.graphicsFormat = GraphicsFormat.R32_SFloat;
		ReAllocateIfNeeded(ref downsampledCameraDepthRTHandle, in descriptor, TextureWrapMode.Clamp, "_DownsampledCameraDepth");
		descriptor.colorFormat = RenderTextureFormat.ARGBHalf;
		ReAllocateIfNeeded(ref volumetricFogRenderRTHandle, in descriptor, TextureWrapMode.Clamp, "_VolumetricFog");
		ReAllocateIfNeeded(ref volumetricFogBlurRTHandle, in descriptor, TextureWrapMode.Clamp, "_VolumetricFogBlur");
		descriptor.width = vector2Int.x;
		descriptor.height = vector2Int.y;
		descriptor.colorFormat = colorFormat;
		ReAllocateIfNeeded(ref volumetricFogUpsampleCompositionRTHandle, in descriptor, TextureWrapMode.Clamp, "_VolumetricFogUpsampleComposition");
	}

	[Obsolete]
	public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
	{
		CommandBuffer commandBuffer = CommandBufferPool.Get();
		using (new ProfilingScope(commandBuffer, downsampleDepthProfilingSampler))
		{
			Blitter.BlitCameraTexture(commandBuffer, downsampledCameraDepthRTHandle, downsampledCameraDepthRTHandle, downsampleDepthMaterial, downsampleDepthPassIndex);
			volumetricFogMaterial.SetTexture(DownsampledCameraDepthTextureId, downsampledCameraDepthRTHandle);
		}
		using (new ProfilingScope(commandBuffer, base.profilingSampler))
		{
			UpdateVolumetricFogMaterialParameters(volumetricFogMaterial, renderingData.lightData.mainLightIndex, renderingData.lightData.additionalLightsCount, renderingData.lightData.visibleLights);
			Blitter.BlitCameraTexture(commandBuffer, volumetricFogRenderRTHandle, volumetricFogRenderRTHandle, volumetricFogMaterial, volumetricFogRenderPassIndex);
			int value = VolumeManager.instance.stack.GetComponent<VolumetricFogVolumeComponent>().blurIterations.value;
			for (int i = 0; i < value; i++)
			{
				Blitter.BlitCameraTexture(commandBuffer, volumetricFogRenderRTHandle, volumetricFogBlurRTHandle, volumetricFogMaterial, volumetricFogHorizontalBlurPassIndex);
				Blitter.BlitCameraTexture(commandBuffer, volumetricFogBlurRTHandle, volumetricFogRenderRTHandle, volumetricFogMaterial, volumetricFogVerticalBlurPassIndex);
			}
			volumetricFogMaterial.SetTexture(VolumetricFogTextureId, volumetricFogRenderRTHandle);
			RTHandle cameraColorTargetHandle = renderingData.cameraData.renderer.cameraColorTargetHandle;
			Blitter.BlitCameraTexture(commandBuffer, cameraColorTargetHandle, volumetricFogUpsampleCompositionRTHandle, volumetricFogMaterial, volumetricFogUpsampleCompositionPassIndex);
			Blitter.BlitCameraTexture(commandBuffer, volumetricFogUpsampleCompositionRTHandle, cameraColorTargetHandle);
		}
		context.ExecuteCommandBuffer(commandBuffer);
		commandBuffer.Clear();
		CommandBufferPool.Release(commandBuffer);
	}

	public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
	{
		UniversalCameraData cameraData = frameData.Get<UniversalCameraData>();
		UniversalLightData lightData = frameData.Get<UniversalLightData>();
		UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
		CreateRenderGraphTextures(renderGraph, cameraData, out var downsampledCameraDepthTarget, out var volumetricFogRenderTarget, out var volumetricFogBlurRenderTarget, out var volumetricFogUpsampleCompositionTarget);
		PassData passData;
		using (IRasterRenderGraphBuilder rasterRenderGraphBuilder = renderGraph.AddRasterRenderPass<PassData>("Downsample Depth Pass", out passData, downsampleDepthProfilingSampler, ".\\Library\\PackageCache\\com.cqf.urpvolumetricfog@0a37318047a7\\Runtime\\VolumetricFogRenderPass.cs", 256))
		{
			passData.stage = PassStage.DownsampleDepth;
			passData.source = universalResourceData.cameraDepthTexture;
			passData.target = downsampledCameraDepthTarget;
			passData.material = downsampleDepthMaterial;
			passData.materialPassIndex = downsampleDepthPassIndex;
			rasterRenderGraphBuilder.SetRenderAttachment(downsampledCameraDepthTarget, 0, AccessFlags.WriteAll);
			rasterRenderGraphBuilder.UseTexture(universalResourceData.cameraDepthTexture);
			rasterRenderGraphBuilder.SetRenderFunc(delegate(PassData data, RasterGraphContext context)
			{
				ExecutePass(data, context);
			});
		}
		PassData passData2;
		using (IRasterRenderGraphBuilder rasterRenderGraphBuilder2 = renderGraph.AddRasterRenderPass<PassData>("Volumetric Fog Render Pass", out passData2, base.profilingSampler, ".\\Library\\PackageCache\\com.cqf.urpvolumetricfog@0a37318047a7\\Runtime\\VolumetricFogRenderPass.cs", 269))
		{
			passData2.stage = PassStage.VolumetricFogRender;
			passData2.source = downsampledCameraDepthTarget;
			passData2.target = volumetricFogRenderTarget;
			passData2.material = volumetricFogMaterial;
			passData2.materialPassIndex = volumetricFogRenderPassIndex;
			passData2.downsampledCameraDepthTarget = downsampledCameraDepthTarget;
			passData2.lightData = lightData;
			rasterRenderGraphBuilder2.SetRenderAttachment(volumetricFogRenderTarget, 0, AccessFlags.WriteAll);
			rasterRenderGraphBuilder2.UseTexture(in downsampledCameraDepthTarget);
			if (universalResourceData.mainShadowsTexture.IsValid())
			{
				rasterRenderGraphBuilder2.UseTexture(universalResourceData.mainShadowsTexture);
			}
			if (universalResourceData.additionalShadowsTexture.IsValid())
			{
				rasterRenderGraphBuilder2.UseTexture(universalResourceData.additionalShadowsTexture);
			}
			rasterRenderGraphBuilder2.SetRenderFunc(delegate(PassData data, RasterGraphContext context)
			{
				ExecutePass(data, context);
			});
		}
		PassData passData3;
		using (IUnsafeRenderGraphBuilder unsafeRenderGraphBuilder = renderGraph.AddUnsafePass<PassData>("Volumetric Fog Blur Pass", out passData3, base.profilingSampler, ".\\Library\\PackageCache\\com.cqf.urpvolumetricfog@0a37318047a7\\Runtime\\VolumetricFogRenderPass.cs", 288))
		{
			passData3.stage = PassStage.VolumetricFogBlur;
			passData3.source = volumetricFogRenderTarget;
			passData3.target = volumetricFogBlurRenderTarget;
			passData3.material = volumetricFogMaterial;
			passData3.materialPassIndex = volumetricFogHorizontalBlurPassIndex;
			passData3.materialAdditionalPassIndex = volumetricFogVerticalBlurPassIndex;
			unsafeRenderGraphBuilder.UseTexture(in volumetricFogRenderTarget, AccessFlags.ReadWrite);
			unsafeRenderGraphBuilder.UseTexture(in volumetricFogBlurRenderTarget, AccessFlags.ReadWrite);
			unsafeRenderGraphBuilder.SetRenderFunc(delegate(PassData data, UnsafeGraphContext context)
			{
				ExecuteUnsafeBlurPass(data, context);
			});
		}
		PassData passData4;
		using (IRasterRenderGraphBuilder rasterRenderGraphBuilder3 = renderGraph.AddRasterRenderPass<PassData>("Volumetric Fog Upsample Composition Pass", out passData4, base.profilingSampler, ".\\Library\\PackageCache\\com.cqf.urpvolumetricfog@0a37318047a7\\Runtime\\VolumetricFogRenderPass.cs", 302))
		{
			passData4.stage = PassStage.VolumetricFogUpsampleComposition;
			passData4.source = universalResourceData.cameraColor;
			passData4.target = volumetricFogUpsampleCompositionTarget;
			passData4.material = volumetricFogMaterial;
			passData4.materialPassIndex = volumetricFogUpsampleCompositionPassIndex;
			passData4.volumetricFogRenderTarget = volumetricFogRenderTarget;
			rasterRenderGraphBuilder3.SetRenderAttachment(volumetricFogUpsampleCompositionTarget, 0, AccessFlags.WriteAll);
			rasterRenderGraphBuilder3.UseTexture(universalResourceData.cameraDepthTexture);
			rasterRenderGraphBuilder3.UseTexture(in downsampledCameraDepthTarget);
			rasterRenderGraphBuilder3.UseTexture(in volumetricFogRenderTarget);
			rasterRenderGraphBuilder3.UseTexture(universalResourceData.cameraColor);
			rasterRenderGraphBuilder3.SetRenderFunc(delegate(PassData data, RasterGraphContext context)
			{
				ExecutePass(data, context);
			});
		}
		universalResourceData.cameraColor = volumetricFogUpsampleCompositionTarget;
	}

	private static void UpdateVolumetricFogMaterialParameters(Material volumetricFogMaterial, int mainLightIndex, int additionalLightsCount, NativeArray<VisibleLight> visibleLights)
	{
		VolumetricFogVolumeComponent component = VolumeManager.instance.stack.GetComponent<VolumetricFogVolumeComponent>();
		bool flag = component.enableMainLightContribution.value && component.scattering.value > 0f && mainLightIndex > -1;
		bool flag2 = component.enableAdditionalLightsContribution.value && additionalLightsCount > 0;
		if (component.enableAPVContribution.value && component.APVContributionWeight.value > 0f)
		{
			volumetricFogMaterial.EnableKeyword("_APV_CONTRIBUTION_ENABLED");
		}
		else
		{
			volumetricFogMaterial.DisableKeyword("_APV_CONTRIBUTION_ENABLED");
		}
		if (flag)
		{
			volumetricFogMaterial.DisableKeyword("_MAIN_LIGHT_CONTRIBUTION_DISABLED");
		}
		else
		{
			volumetricFogMaterial.EnableKeyword("_MAIN_LIGHT_CONTRIBUTION_DISABLED");
		}
		if (flag2)
		{
			volumetricFogMaterial.DisableKeyword("_ADDITIONAL_LIGHTS_CONTRIBUTION_DISABLED");
		}
		else
		{
			volumetricFogMaterial.EnableKeyword("_ADDITIONAL_LIGHTS_CONTRIBUTION_DISABLED");
		}
		UpdateLightsParameters(volumetricFogMaterial, component, flag, flag2, mainLightIndex, visibleLights);
		volumetricFogMaterial.SetInteger(FrameCountId, Time.renderedFrameCount % 64);
		volumetricFogMaterial.SetInteger(CustomAdditionalLightsCountId, additionalLightsCount);
		volumetricFogMaterial.SetFloat(DistanceId, component.distance.value);
		volumetricFogMaterial.SetFloat(BaseHeightId, component.baseHeight.value);
		volumetricFogMaterial.SetFloat(MaximumHeightId, component.maximumHeight.value);
		volumetricFogMaterial.SetFloat(GroundHeightId, (component.enableGround.overrideState && component.enableGround.value) ? component.groundHeight.value : float.MinValue);
		volumetricFogMaterial.SetFloat(DensityId, component.density.value);
		volumetricFogMaterial.SetFloat(AbsortionId, 1f / component.attenuationDistance.value);
		volumetricFogMaterial.SetFloat(APVContributionWeigthId, component.enableAPVContribution.value ? component.APVContributionWeight.value : 0f);
		volumetricFogMaterial.SetColor(TintId, component.tint.value);
		volumetricFogMaterial.SetInteger(MaxStepsId, component.maxSteps.value);
	}

	private static void UpdateLightsParameters(Material volumetricFogMaterial, VolumetricFogVolumeComponent fogVolume, bool enableMainLightContribution, bool enableAdditionalLightsContribution, int mainLightIndex, NativeArray<VisibleLight> visibleLights)
	{
		int num = Mathf.Clamp(visibleLights.Length, 0, LightsParametersLength);
		num--;
		if (enableMainLightContribution && num >= 0)
		{
			Anisotropies[num] = fogVolume.anisotropy.value;
			Scatterings[num] = fogVolume.scattering.value;
		}
		if (enableAdditionalLightsContribution)
		{
			int num2 = 0;
			for (int i = 0; i <= num; i++)
			{
				if (i != mainLightIndex)
				{
					float num3 = 0f;
					float num4 = 0f;
					float num5 = 0f;
					if (visibleLights[i].light.TryGetComponent<VolumetricAdditionalLight>(out var component) && component.gameObject.activeInHierarchy && component.enabled)
					{
						num3 = component.Anisotropy;
						num4 = component.Scattering;
						num5 = component.Radius;
					}
					Anisotropies[num2] = num3;
					Scatterings[num2] = num4;
					RadiiSq[num2++] = num5 * num5;
				}
			}
		}
		if (enableMainLightContribution || enableAdditionalLightsContribution)
		{
			volumetricFogMaterial.SetFloatArray(AnisotropiesArrayId, Anisotropies);
			volumetricFogMaterial.SetFloatArray(ScatteringsArrayId, Scatterings);
			volumetricFogMaterial.SetFloatArray(RadiiSqArrayId, RadiiSq);
		}
	}

	private void CreateRenderGraphTextures(RenderGraph renderGraph, UniversalCameraData cameraData, out TextureHandle downsampledCameraDepthTarget, out TextureHandle volumetricFogRenderTarget, out TextureHandle volumetricFogBlurRenderTarget, out TextureHandle volumetricFogUpsampleCompositionTarget)
	{
		RenderTextureDescriptor cameraTargetDescriptor = cameraData.cameraTargetDescriptor;
		cameraTargetDescriptor.depthBufferBits = 0;
		RenderTextureFormat colorFormat = cameraTargetDescriptor.colorFormat;
		Vector2Int vector2Int = new Vector2Int(cameraTargetDescriptor.width, cameraTargetDescriptor.height);
		cameraTargetDescriptor.width /= 2;
		cameraTargetDescriptor.height /= 2;
		cameraTargetDescriptor.graphicsFormat = GraphicsFormat.R32_SFloat;
		downsampledCameraDepthTarget = UniversalRenderer.CreateRenderGraphTexture(renderGraph, cameraTargetDescriptor, "_DownsampledCameraDepth", clear: false);
		cameraTargetDescriptor.colorFormat = RenderTextureFormat.ARGBHalf;
		volumetricFogRenderTarget = UniversalRenderer.CreateRenderGraphTexture(renderGraph, cameraTargetDescriptor, "_VolumetricFog", clear: false);
		volumetricFogBlurRenderTarget = UniversalRenderer.CreateRenderGraphTexture(renderGraph, cameraTargetDescriptor, "_VolumetricFogBlur", clear: false);
		cameraTargetDescriptor.width = vector2Int.x;
		cameraTargetDescriptor.height = vector2Int.y;
		cameraTargetDescriptor.colorFormat = colorFormat;
		volumetricFogUpsampleCompositionTarget = UniversalRenderer.CreateRenderGraphTexture(renderGraph, cameraTargetDescriptor, "_VolumetricFogUpsampleComposition", clear: false);
	}

	private static void ExecutePass(PassData passData, RasterGraphContext context)
	{
		switch (passData.stage)
		{
		case PassStage.VolumetricFogRender:
			passData.material.SetTexture(DownsampledCameraDepthTextureId, passData.downsampledCameraDepthTarget);
			UpdateVolumetricFogMaterialParameters(passData.material, passData.lightData.mainLightIndex, passData.lightData.additionalLightsCount, passData.lightData.visibleLights);
			break;
		case PassStage.VolumetricFogUpsampleComposition:
			passData.material.SetTexture(VolumetricFogTextureId, passData.volumetricFogRenderTarget);
			break;
		}
		Blitter.BlitTexture(context.cmd, passData.source, Vector2.one, passData.material, passData.materialPassIndex);
	}

	private static void ExecuteUnsafeBlurPass(PassData passData, UnsafeGraphContext context)
	{
		CommandBuffer nativeCommandBuffer = CommandBufferHelpers.GetNativeCommandBuffer(context.cmd);
		int value = VolumeManager.instance.stack.GetComponent<VolumetricFogVolumeComponent>().blurIterations.value;
		for (int i = 0; i < value; i++)
		{
			Blitter.BlitCameraTexture(nativeCommandBuffer, passData.source, passData.target, RenderBufferLoadAction.DontCare, RenderBufferStoreAction.Store, passData.material, passData.materialPassIndex);
			Blitter.BlitCameraTexture(nativeCommandBuffer, passData.target, passData.source, RenderBufferLoadAction.DontCare, RenderBufferStoreAction.Store, passData.material, passData.materialAdditionalPassIndex);
		}
	}

	private void ReAllocateIfNeeded(ref RTHandle handle, in RenderTextureDescriptor descriptor, TextureWrapMode wrapMode, string name)
	{
		RenderingUtils.ReAllocateHandleIfNeeded(ref handle, in descriptor, FilterMode.Point, wrapMode, 1, 0f, name);
	}

	public void Dispose()
	{
		downsampledCameraDepthRTHandle?.Release();
		volumetricFogRenderRTHandle?.Release();
		volumetricFogBlurRTHandle?.Release();
		volumetricFogUpsampleCompositionRTHandle?.Release();
	}
}
