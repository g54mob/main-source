using UnityEngine.Rendering;

namespace HauntedPSX.RenderPipelines.PSX.Runtime
{
	internal static class PSXProfilingSamplers
	{
		public static readonly string s_PushCameraParametersStr = "Push Camera Parameters";

		public static readonly string s_PushGlobalRasterizationParametersStr = "Push Global Rasterization Parameters";

		public static readonly string s_PushGlobalPostProcessingParametersStr = "Push Global Rasterization Parameters";

		public static readonly string s_PushSkyParametersStr = "Push Sky Parameters";

		public static readonly string s_PushQualityOverrideParametersStr = "Push Quality Override Parameters";

		public static readonly string s_PushTonemapperParametersStr = "Push Tonemapper Parameters";

		public static readonly string s_PushLightingParametersStr = "Push Lighting Parameters";

		public static readonly string s_PushDynamicLightingParametersStr = "Push Dynamic Lighting Parameters";

		public static readonly string s_PreMainParametersStr = "Push Pre Main Parameters";

		public static readonly string s_PreUIOverlayParametersStr = "Push Pre UI Overlay Parameters";

		public static readonly string s_PushPrecisionParametersStr = "Push Precision Parameters";

		public static readonly string s_PushFogParametersStr = "Push Fog Parameters";

		public static readonly string s_PushCompressionParametersStr = "Push Compression Parameters";

		public static readonly string s_PushCathodeRayTubeParametersStr = "Push Cathode Ray Tube Parameters";

		public static readonly string s_DrawAccumulationMotionBlurPreUIOverlayStr = "Accumulation Motion Blur Pre UI Overlay";

		public static readonly string s_DrawAccumulationMotionBlurPostUIOverlayStr = "Accumulation Motion Blur Post UI Overlay";

		public static readonly string s_DrawAccumulationMotionBlurFinalBlitStr = "Accumulation Motion Blur Final Blit";

		public static readonly string s_PushTerrainGrassParametersStr = "Push Terrain Grass Parameters";

		public static ProfilingSampler s_PushCameraParameters = new ProfilingSampler(s_PushCameraParametersStr);

		public static ProfilingSampler s_PushGlobalRasterizationParameters = new ProfilingSampler(s_PushGlobalRasterizationParametersStr);

		public static ProfilingSampler s_PushGlobalPostProcessingParameters = new ProfilingSampler(s_PushGlobalPostProcessingParametersStr);

		public static ProfilingSampler s_PushSkyParameters = new ProfilingSampler(s_PushSkyParametersStr);

		public static ProfilingSampler s_PushQualityOverrideParameters = new ProfilingSampler(s_PushQualityOverrideParametersStr);

		public static ProfilingSampler s_PushTonemapperParameters = new ProfilingSampler(s_PushTonemapperParametersStr);

		public static ProfilingSampler s_PushLightingParameters = new ProfilingSampler(s_PushLightingParametersStr);

		public static ProfilingSampler s_PushDynamicLightingParameters = new ProfilingSampler(s_PushDynamicLightingParametersStr);

		public static ProfilingSampler s_PreMainParameters = new ProfilingSampler(s_PreMainParametersStr);

		public static ProfilingSampler s_PreUIOverlayParameters = new ProfilingSampler(s_PreUIOverlayParametersStr);

		public static ProfilingSampler s_PushPrecisionParameters = new ProfilingSampler(s_PushPrecisionParametersStr);

		public static ProfilingSampler s_PushFogParameters = new ProfilingSampler(s_PushFogParametersStr);

		public static ProfilingSampler s_PushCompressionParameters = new ProfilingSampler(s_PushCompressionParametersStr);

		public static ProfilingSampler s_PushCathodeRayTubeParameters = new ProfilingSampler(s_PushCathodeRayTubeParametersStr);

		public static ProfilingSampler s_DrawAccumulationMotionBlurPreUIOverlay = new ProfilingSampler(s_DrawAccumulationMotionBlurPreUIOverlayStr);

		public static ProfilingSampler s_DrawAccumulationMotionBlurPostUIOverlay = new ProfilingSampler(s_DrawAccumulationMotionBlurPostUIOverlayStr);

		public static ProfilingSampler s_DrawAccumulationMotionBlurFinalBlit = new ProfilingSampler(s_DrawAccumulationMotionBlurFinalBlitStr);

		public static ProfilingSampler s_PushTerrainGrassParameters = new ProfilingSampler(s_PushTerrainGrassParametersStr);
	}
}
