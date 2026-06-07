using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Kamgam.SettingsGenerator
{
	public class QualityPreset
	{
		public int particleRaycastBudget;

		public bool softVegetation;

		public int vSyncCount;

		public int antiAliasing;

		public int asyncUploadTimeSlice;

		public int asyncUploadBufferSize;

		public bool asyncUploadPersistentBuffer;

		public bool realtimeReflectionProbes;

		public bool billboardsFaceCameraPosition;

		public float resolutionScalingFixedDPIFactor;

		public bool softParticles;

		public RenderPipelineAsset renderPipeline;

		public SkinWeights skinWeights;

		public bool streamingMipmapsActive;

		public float streamingMipmapsMemoryBudget;

		public int streamingMipmapsRenderersPerFrame;

		public int streamingMipmapsMaxLevelReduction;

		public bool streamingMipmapsAddAllCameras;

		public int streamingMipmapsMaxFileIORequests;

		public int maxQueuedFrames;

		public ColorSpace desiredColorSpace;

		public ColorSpace activeColorSpace;

		public int globalTextureMipmapLimit;

		public int pixelLightCount;

		public int maximumLODLevel;

		public ShadowProjection shadowProjection;

		public int shadowCascades;

		public float shadowDistance;

		public UnityEngine.ShadowQuality shadows;

		public ShadowmaskMode shadowmaskMode;

		public float shadowNearPlaneOffset;

		public float shadowCascade2Split;

		public Vector3 shadowCascade4Split;

		public float lodBias;

		public AnisotropicFiltering anisotropicFiltering;

		public UnityEngine.ShadowResolution shadowResolution;

		public static QualityPreset CreateFromCurrentLevel()
		{
			return new QualityPreset
			{
				particleRaycastBudget = QualitySettings.particleRaycastBudget,
				softVegetation = QualitySettings.softVegetation,
				vSyncCount = QualitySettings.vSyncCount,
				antiAliasing = QualitySettings.antiAliasing,
				asyncUploadTimeSlice = QualitySettings.asyncUploadTimeSlice,
				asyncUploadBufferSize = QualitySettings.asyncUploadBufferSize,
				asyncUploadPersistentBuffer = QualitySettings.asyncUploadPersistentBuffer,
				realtimeReflectionProbes = QualitySettings.realtimeReflectionProbes,
				billboardsFaceCameraPosition = QualitySettings.billboardsFaceCameraPosition,
				resolutionScalingFixedDPIFactor = QualitySettings.resolutionScalingFixedDPIFactor,
				softParticles = QualitySettings.softParticles,
				skinWeights = QualitySettings.skinWeights,
				streamingMipmapsActive = QualitySettings.streamingMipmapsActive,
				streamingMipmapsMemoryBudget = QualitySettings.streamingMipmapsMemoryBudget,
				streamingMipmapsRenderersPerFrame = QualitySettings.streamingMipmapsRenderersPerFrame,
				streamingMipmapsMaxLevelReduction = QualitySettings.streamingMipmapsMaxLevelReduction,
				streamingMipmapsAddAllCameras = QualitySettings.streamingMipmapsAddAllCameras,
				streamingMipmapsMaxFileIORequests = QualitySettings.streamingMipmapsMaxFileIORequests,
				maxQueuedFrames = QualitySettings.maxQueuedFrames,
				desiredColorSpace = QualitySettings.desiredColorSpace,
				activeColorSpace = QualitySettings.activeColorSpace,
				globalTextureMipmapLimit = QualitySettings.globalTextureMipmapLimit,
				pixelLightCount = QualitySettings.pixelLightCount,
				maximumLODLevel = QualitySettings.maximumLODLevel,
				shadowProjection = QualitySettings.shadowProjection,
				shadowCascades = QualitySettings.shadowCascades,
				shadowDistance = QualitySettings.shadowDistance,
				shadows = QualitySettings.shadows,
				shadowmaskMode = QualitySettings.shadowmaskMode,
				shadowNearPlaneOffset = QualitySettings.shadowNearPlaneOffset,
				shadowCascade2Split = QualitySettings.shadowCascade2Split,
				shadowCascade4Split = QualitySettings.shadowCascade4Split,
				lodBias = QualitySettings.lodBias,
				anisotropicFiltering = QualitySettings.anisotropicFiltering,
				shadowResolution = QualitySettings.shadowResolution,
				renderPipeline = ((QualitySettings.renderPipeline == null) ? null : UnityEngine.Object.Instantiate(QualitySettings.renderPipeline))
			};
		}

		public void ApplyToCurrentLevel()
		{
			QualitySettings.particleRaycastBudget = particleRaycastBudget;
			QualitySettings.softVegetation = softVegetation;
			QualitySettings.vSyncCount = vSyncCount;
			QualitySettings.antiAliasing = antiAliasing;
			QualitySettings.asyncUploadTimeSlice = asyncUploadTimeSlice;
			QualitySettings.asyncUploadBufferSize = asyncUploadBufferSize;
			QualitySettings.asyncUploadPersistentBuffer = asyncUploadPersistentBuffer;
			QualitySettings.realtimeReflectionProbes = realtimeReflectionProbes;
			QualitySettings.billboardsFaceCameraPosition = billboardsFaceCameraPosition;
			QualitySettings.resolutionScalingFixedDPIFactor = resolutionScalingFixedDPIFactor;
			QualitySettings.softParticles = softParticles;
			QualitySettings.skinWeights = skinWeights;
			QualitySettings.streamingMipmapsActive = streamingMipmapsActive;
			QualitySettings.streamingMipmapsMemoryBudget = streamingMipmapsMemoryBudget;
			QualitySettings.streamingMipmapsRenderersPerFrame = streamingMipmapsRenderersPerFrame;
			QualitySettings.streamingMipmapsMaxLevelReduction = streamingMipmapsMaxLevelReduction;
			QualitySettings.streamingMipmapsAddAllCameras = streamingMipmapsAddAllCameras;
			QualitySettings.streamingMipmapsMaxFileIORequests = streamingMipmapsMaxFileIORequests;
			QualitySettings.maxQueuedFrames = maxQueuedFrames;
			QualitySettings.globalTextureMipmapLimit = globalTextureMipmapLimit;
			QualitySettings.pixelLightCount = pixelLightCount;
			QualitySettings.maximumLODLevel = maximumLODLevel;
			QualitySettings.shadowProjection = shadowProjection;
			QualitySettings.shadowCascades = shadowCascades;
			QualitySettings.shadowDistance = shadowDistance;
			QualitySettings.shadows = shadows;
			QualitySettings.shadowmaskMode = shadowmaskMode;
			QualitySettings.shadowNearPlaneOffset = shadowNearPlaneOffset;
			QualitySettings.shadowCascade2Split = shadowCascade2Split;
			QualitySettings.shadowCascade4Split = shadowCascade4Split;
			QualitySettings.lodBias = lodBias;
			QualitySettings.anisotropicFiltering = anisotropicFiltering;
			QualitySettings.shadowResolution = shadowResolution;
			if (QualitySettings.renderPipeline != null && renderPipeline != null)
			{
				applyToCurrentLevelURP();
			}
		}

		protected void applyToCurrentLevelURP()
		{
			UniversalRenderPipelineAsset universalRenderPipelineAsset = (UniversalRenderPipelineAsset)renderPipeline;
			UniversalRenderPipelineAsset universalRenderPipelineAsset2 = (UniversalRenderPipelineAsset)QualitySettings.renderPipeline;
			if (universalRenderPipelineAsset != null && universalRenderPipelineAsset2 != null)
			{
				universalRenderPipelineAsset2.useAdaptivePerformance = universalRenderPipelineAsset.useAdaptivePerformance;
				universalRenderPipelineAsset2.colorGradingLutSize = universalRenderPipelineAsset.colorGradingLutSize;
				universalRenderPipelineAsset2.colorGradingMode = universalRenderPipelineAsset.colorGradingMode;
				universalRenderPipelineAsset2.useSRPBatcher = universalRenderPipelineAsset.useSRPBatcher;
				universalRenderPipelineAsset2.supportsDynamicBatching = universalRenderPipelineAsset.supportsDynamicBatching;
				universalRenderPipelineAsset2.shadowDepthBias = universalRenderPipelineAsset.shadowDepthBias;
				universalRenderPipelineAsset2.supportsCameraDepthTexture = universalRenderPipelineAsset.supportsCameraDepthTexture;
				universalRenderPipelineAsset2.supportsCameraOpaqueTexture = universalRenderPipelineAsset.supportsCameraOpaqueTexture;
				universalRenderPipelineAsset2.supportsHDR = universalRenderPipelineAsset.supportsHDR;
				universalRenderPipelineAsset2.msaaSampleCount = universalRenderPipelineAsset.msaaSampleCount;
				universalRenderPipelineAsset2.renderScale = universalRenderPipelineAsset.renderScale;
				universalRenderPipelineAsset2.shadowCascadeCount = universalRenderPipelineAsset.shadowCascadeCount;
				universalRenderPipelineAsset2.shadowDistance = universalRenderPipelineAsset.shadowDistance;
				universalRenderPipelineAsset2.maxAdditionalLightsCount = universalRenderPipelineAsset.maxAdditionalLightsCount;
				try
				{
					UniversalRenderPipelineUtils.SetMainLightShadowResolution(universalRenderPipelineAsset.mainLightShadowmapResolution, universalRenderPipelineAsset2);
					UniversalRenderPipelineUtils.SetAdditionalLightShadowResolution(universalRenderPipelineAsset.additionalLightsShadowmapResolution, universalRenderPipelineAsset2);
				}
				catch (Exception ex)
				{
					Debug.LogError("ShadowResolutionConnection reflection execution failed. Maybe the API has changed? \n" + ex.Message);
				}
			}
		}
	}
}
