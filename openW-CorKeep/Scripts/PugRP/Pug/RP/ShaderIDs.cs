using UnityEngine;

namespace Pug.RP
{
	public static class ShaderIDs
	{
		public static readonly int GlobalCurveTexture = GetID("_GlobalCurveTexture");

		public static readonly int LightFalloffDither = GetID("_LightFalloffDither");

		public static readonly int LightPenetrationParams = GetID("_LightPenetrationParams");

		public static readonly int Time = GetID("_Time");

		public static readonly int SinTime = GetID("_SinTime");

		public static readonly int CosTime = GetID("_CosTime");

		public static readonly int DeltaTime = GetID("_DeltaTime");

		public static readonly int TimeParameters = GetID("_TimeParameters");

		public static readonly int Alpha = GetID("_Alpha");

		public static readonly int Additive = GetID("_Additive");

		public static readonly int GBuffer0 = GetID("_GBuffer0");

		public static readonly int GBuffer1 = GetID("_GBuffer1");

		public static readonly int GBuffer2 = GetID("_GBuffer2");

		public static readonly int DepthTexture = GetID("_DepthTexture");

		public static readonly int Outlines = GetID("_Outlines");

		public static readonly int ProjectionParams = GetID("_ProjectionParams");

		public static readonly int WorldSpaceCameraPos = GetID("_WorldSpaceCameraPos");

		public static readonly int ScreenParams = GetID("_ScreenParams");

		public static readonly int ScaledScreenParams = GetID("_ScaledScreenParams");

		public static readonly int ZBufferParams = GetID("_ZBufferParams");

		public static readonly int OrthoParams = GetID("_OrthoParams");

		public static readonly int ScreenSize = GetID("_ScreenSize");

		public static readonly int GlobalMipBias = GetID("_GlobalMipBias");

		public static readonly int WorldToCameraMatrix = GetID("_WorldToCameraMatrix");

		public static readonly int CameraToWorldMatrix = GetID("_CameraToWorldMatrix");

		public static readonly int InverseViewMatrix = GetID("_InverseViewMatrix");

		public static readonly int InverseProjectionMatrix = GetID("_InverseProjectionMatrix");

		public static readonly int InverseViewAndProjectionMatrix = GetID("_InverseViewAndProjectionMatrix");

		public static readonly int MATRIX_VP = GetID("MATRIX_VP");

		public static readonly int MATRIX_VP_PREV = GetID("MATRIX_VP_PREV");

		public static readonly int CameraPosition = GetID("_CameraPosition");

		public static readonly int CameraRight = GetID("_CameraRight");

		public static readonly int CameraUp = GetID("_CameraUp");

		public static readonly int CameraForward = GetID("_CameraForward");

		public static readonly int CameraCorners = GetID("_CameraCorners");

		public static readonly int CameraRays = GetID("_CameraRays");

		public static readonly int CameraViewSize = GetID("_CameraViewSize");

		public static readonly int LightWorldToShadow = GetID("_LightWorldToShadow");

		public static readonly int LightPositionRange = GetID("_LightPositionRange");

		public static readonly int LightColorSpotAngleNorm = GetID("_LightColorSpotAngleNorm");

		public static readonly int LightForwardCosSpotAngle = GetID("_LightForwardCosSpotAngle");

		public static readonly int LightParams = GetID("_LightParams");

		public static readonly int FallbackLightNormalFactor = GetID("_FallbackLightNormalFactor");

		public static readonly int CelShadeParams = GetID("_CelShadeParams");

		public static readonly int LightPosition = GetID("_LightPosition");

		public static readonly int LightRange = GetID("_LightRange");

		public static readonly int Pass = GetID("_Pass");

		public static readonly int DirectionalShadowBias = GetID("_DirectionalShadowBias");

		public static readonly int PointShadowSampleKernel = GetID("_PointShadowSampleKernel");

		public static readonly int PointShadowSampleCount = GetID("_PointShadowSampleCount");

		public static readonly int PointShadowBias = GetID("_PointShadowBias");

		public static readonly int WorldToShadow = GetID("_WorldToShadow");

		public static readonly int ShadowToWorld = GetID("_ShadowToWorld");

		public static readonly int ShadowCubeVP = GetID("_ShadowCubeVP");

		public static readonly int DstArraySlice = GetID("_DstArraySlice");

		public static readonly int PixelsPerMeter = GetID("_PixelsPerMeter");

		public static readonly int Bluenoise64 = GetID("_Bluenoise64");

		public static readonly int Bluenoise128 = GetID("_Bluenoise128");

		public static readonly int FrameIndex = GetID("_FrameIndex");

		public static readonly int FrameIndex128 = GetID("_FrameIndex128");

		public static readonly int RadianceCascade = GetID("_RadianceCascade");

		public static readonly int RadianceCascadeTmp = GetID("_RadianceCascadeTmp");

		public static readonly int RadianceCascadeIn = GetID("_RadianceCascadeIn");

		public static readonly int RadianceCascadeIndex = GetID("_RadianceCascadeIndex");

		public static readonly int SampleWeight = GetID("_SampleWeight");

		public static readonly int Input = GetID("_Input");

		public static readonly int Input2 = GetID("_Input2");

		public static readonly int Output = GetID("_Output");

		public static readonly int BentNormal = GetID("_BentNormal");

		public static readonly int Axis = GetID("_Axis");

		public static readonly int Width = GetID("_Width");

		public static readonly int BloomThreshold = GetID("_BloomThreshold");

		public static readonly int Threshold = GetID("_Threshold");

		public static readonly int OriginalOpacity = GetID("_OriginalOpacity");

		public static readonly int InputMip = GetID("_InputMip");

		public static readonly int IndirectLightLimit = GetID("_IndirectLightLimit");

		public static readonly int Radiance = GetID("_Radiance");

		public static readonly int Irradiance = GetID("_Irradiance");

		public static readonly int ObjectShadowParam1 = GetID("_ObjectShadowParam1");

		public static readonly int ObjectShadowParam2 = GetID("_ObjectShadowParam2");

		public static readonly int ObjectShadowParam3 = GetID("_ObjectShadowParam3");

		public static readonly int ObjectShadowParam4 = GetID("_ObjectShadowParam4");

		public static readonly int ObjectShadowParam5 = GetID("_ObjectShadowParam5");

		public static readonly int ObjectShadowParam6 = GetID("_ObjectShadowParam6");

		public static readonly int IndirectLightDepth = GetID("_IndirectLightDepth");

		public static readonly int IndirectDepthThreshold = GetID("_IndirectDepthThreshold");

		public static readonly int IndirectBlockerThreshold = GetID("_IndirectBlockerThreshold");

		public static readonly int IndirectBlockerMinZ = GetID("_IndirectBlockerMinZ");

		public static readonly int IrradianceInput = GetID("_IrradianceInput");

		public static readonly int IrradianceInput2 = GetID("_IrradianceInput2");

		public static readonly int IrradiancePrevInput = GetID("_IrradiancePrevInput");

		public static readonly int IrradianceOutput = GetID("_IrradianceOutput");

		public static readonly int SampleKernel = GetID("_SampleKernel");

		public static readonly int BufferSize = GetID("_BufferSize");

		public static readonly int InputSize = GetID("_InputSize");

		public static readonly int OutputSize = GetID("_OutputSize");

		public static readonly int Weight = GetID("_Weight");

		public static readonly int BlockerWeight = GetID("_BlockerWeight");

		public static readonly int RayCount = GetID("_RayCount");

		public static readonly int SampleCount = GetID("_SampleCount");

		public static readonly int IndirectToPrev = GetID("_IndirectToPrev");

		public static readonly int AlbedoOutput = GetID("_AlbedoOutput");

		public static readonly int AlbedoInput = GetID("_AlbedoInput");

		public static readonly int IndirectIrradiance = GetID("_IndirectIrradiance");

		public static readonly int IndirectSize = GetID("_IndirectSize");

		public static readonly int WorldToIndirect = GetID("_WorldToIndirect");

		public static readonly int IndirectToWorld = GetID("_IndirectToWorld");

		public static readonly int PrevWorldToIndirect = GetID("_PrevWorldToIndirect");

		public static readonly int IndirectBoostParams = GetID("_IndirectBoostParams");

		public static readonly int IndirectNormalBias = GetID("_IndirectNormalBias");

		public static readonly int IndirectBlockerDepthTexture = GetID("_IndirectBlockerDepthTexture");

		public static readonly int IndirectEdgeRadiance = GetID("_IndirectEdgeRadiance");

		public static readonly int IndirectEdgeRadianceAmount = GetID("_IndirectEdgeRadianceAmount");

		public static readonly int RaymarchedShadowParams = GetID("_RaymarchedShadowParams");

		public static readonly int RaymarchDither = GetID("_RaymarchDither");

		public static readonly int IndirectLeakPrevention = GetID("_IndirectLeakPrevention");

		public static readonly int IndirectUpscaling = GetID("_IndirectUpscaling");

		public static readonly int IndirectBentNormal = GetID("_IndirectBentNormal");

		public static readonly int IndirectLightFeedback = GetID("_IndirectLightFeedback");

		public static readonly int IndirectLightDirectionality = GetID("_IndirectLightDirectionality");

		public static readonly int TopRadianceCascade = GetID("_TopRadianceCascade");

		public static readonly int BlitInput = GetID("_BlitInput");

		public static readonly int TonemapParams = GetID("_TonemapParams");

		public static readonly int TonemapParams2 = GetID("_TonemapParams2");

		public static readonly int CRTEmulationParams = GetID("_CRTEmulationParams");

		public static readonly int CRTEmulationParams2 = GetID("_CRTEmulationParams2");

		public static readonly int DitherOutput = GetID("_DitherOutput");

		public static readonly int BloomTexture = GetID("_BloomTexture");

		public static readonly int BloomIntensity = GetID("_BloomIntensity");

		public static readonly int PlanarReflection = GetID("_PlanarReflection");

		public static readonly int PlanarReflectionPlane = GetID("_PlanarReflectionPlane");

		public static readonly int FixedDepth = GetID("_FixedDepth");

		public static readonly int VolumetricLight = GetID("_VolumetricLight");

		public static readonly int VolumetricLightDirect = GetID("_VolumetricLightDirect");

		public static readonly int WorldToVolumetric = GetID("_WorldToVolumetric");

		public static readonly int VolumetricLightDepthBias = GetID("_VolumetricLightDepthBias");

		public static readonly int ApplicationIsPlaying = GetID("_ApplicationIsPlaying");

		public static readonly int RenderOrigin = GetID("_RenderOrigin");

		public static readonly int WorldPixelSnap = GetID("_WorldPixelSnap");

		public static readonly int OutputTexelDelta = GetID("_OutputTexelDelta");

		public static readonly int TargetSize = GetID("_TargetSize");

		public static readonly int FadeColor = GetID("_FadeColor");

		public static readonly int OutputExposure = GetID("_OutputExposure");

		public static readonly int OutputGamma = GetID("_OutputGamma");

		public static readonly int OutputColorDepth = GetID("_OutputColorDepth");

		public static readonly int OpaqueTexture = GetID("_OpaqueTexture");

		public static readonly int LTMaxSampleCount = GetID("_LT_MaxSampleCount");

		public static readonly int LTShadows = GetID("_LT_Shadows");

		public static readonly int LTShadowSharpen = GetID("_LT_ShadowSharpen");

		public static readonly int LTOcclusion = GetID("_LT_Occlusion");

		public static readonly int LTOcclusionStrength = GetID("_LT_OcclusionStrength");

		public static readonly int LTTransmittance = GetID("_LT_Transmittance");

		public static readonly int LightDir = GetID("_LightDir");

		public static readonly int LightColor = GetID("_LightColor");

		public static readonly int LightColorTexture = GetID("_LightColorTexture");

		public static readonly int LightDepthTexture = GetID("_LightDepthTexture");

		public static readonly int LightDepthTextureSize = GetID("_LightDepthTextureSize");

		public static readonly int WorldToLight = GetID("_WorldToLight");

		public static readonly int ShadowRange = GetID("_ShadowRange");

		public static readonly int ShadowBias = GetID("_ShadowBias");

		public static readonly int RaymarchSkyTest = GetID("_RaymarchSkyTest");

		public static readonly int DitherTexture = GetID("_DitherTexture");

		public static readonly int ColorLUT = GetID("_ColorLUT");

		public static readonly int ColorLUT2 = GetID("_ColorLUT2");

		public static readonly int PointShadowAtlas = GetID("_PointShadowAtlas");

		public static readonly int SpotShadowAtlas = GetID("_SpotShadowAtlas");

		public static readonly int PointShadowAtlasSize = GetID("_PointShadowAtlasSize");

		public static readonly int SpotShadowAtlasSize = GetID("_SpotShadowAtlasSize");

		public static readonly int FullbrightOn = GetID("_FullbrightOn");

		public static readonly int Radius = GetID("_Radius");

		public static readonly int ScreenSpaceRadius = GetID("_ScreenSpaceRadius");

		public static readonly int Bias = GetID("_Bias");

		public static readonly int ScreenBias = GetID("_ScreenBias");

		public static readonly int Exponent = GetID("_Exponent");

		public static readonly int NormalizedEdges = GetID("_NormalizedEdges");

		public static readonly int Animated = GetID("_Animated");

		public static readonly int Directionality = GetID("_Directionality");

		public static readonly int Noise = GetID("_Noise");

		public static readonly int Size = GetID("_Size");

		public static readonly int Kernel = GetID("_Kernel");

		public static readonly int Spacing = GetID("_Spacing");

		public static readonly int Output2 = GetID("_Output2");

		public static readonly int Depth = GetID("_Depth");

		public static readonly int Basis = GetID("_Basis");

		public static readonly int Offset = GetID("_Offset");

		public static readonly int Slice = GetID("_Slice");

		public static readonly int BlurWidth = GetID("_BlurWidth");

		public static readonly int BlurDepthWeight = GetID("_BlurDepthWeight");

		public static readonly int BlurNormalWeight = GetID("_BlurNormalWeight");

		public static readonly int SSAOTexture = GetID("_SSAOTexture");

		public static readonly int SSAOColorize = GetID("_SSAOColorize");

		public static readonly int TemporalWeight = GetID("_TemporalWeight");

		public static readonly int OutlineColorLookup = GetID("_OutlineColorLookup");

		public static readonly int OutlineColorLookup2 = GetID("_OutlineColorLookup2");

		public static readonly int OutlineParams = GetID("_OutlineParams");

		public static readonly int DebugOutlineColorLookup = GetID("_DebugOutlineColorLookup");

		private static int GetID(string name)
		{
			return Shader.PropertyToID(name);
		}
	}
}
