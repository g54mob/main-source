using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace Brewery.Map.V2
{
	public class MapCartographicFeature : ScriptableRendererFeature
	{
		private class MapCartographicPass : ScriptableRenderPass
		{
			private class PassData
			{
				public TextureHandle colorTexture;

				public Material material;

				public RenderTextureDescriptor desc;
			}

			private readonly Material _material;

			private static readonly int _EdgeStrength;

			private static readonly int _EdgeThreshold;

			private static readonly int _EdgeThicknessID;

			private static readonly int _EdgeWobbleID;

			private static readonly int _EdgeColor;

			private static readonly int _ContourSpacing;

			private static readonly int _ContourThickness;

			private static readonly int _ContourColor;

			private static readonly int _MajorContourEvery;

			private static readonly int _HeightMin;

			private static readonly int _HeightMax;

			private static readonly int _HeightColor0;

			private static readonly int _HeightColor1;

			private static readonly int _HeightColor2;

			private static readonly int _HeightColor3;

			private static readonly int _HeightColor4;

			private static readonly int _HeightColorBlend;

			private static readonly int _PaperIntensity;

			private static readonly int _PaperTint;

			private static readonly int _PaperScale;

			private static readonly int _Desaturation;

			private static readonly int _GridEnabled;

			private static readonly int _GridSpacing;

			private static readonly int _GridThickness;

			private static readonly int _GridColor;

			private static readonly int _VignetteStrength;

			private static readonly int _VignetteTint;

			private static readonly int _MapInvViewProj;

			private static readonly int _MapCameraPos;

			private static readonly int _MapCameraOrthoSize;

			private static readonly int _MapCameraAspect;

			private static readonly int _MapCameraIsOrtho;

			private static readonly int _MapCameraNear;

			private static readonly int _MapCameraFar;

			private static readonly int _InkProgress;

			private static readonly int _OpenTID;

			private static readonly int _PaperVeilStrengthID;

			private static readonly int _PaperParallaxStrengthID;

			private static readonly int _InkBloomStrengthID;

			private static readonly int _FrameDarkenStrengthID;

			private static readonly int _TerrainSurfaceMaskID;

			private static readonly int _TerrainOriginID;

			private static readonly int _TerrainSizeID;

			private static readonly int _TerrainSurfaceEnabledID;

			private static readonly int _MapCamRightID;

			private static readonly int _MapCamUpID;

			private static readonly int _SurfFillAID;

			private static readonly int _SurfStrengthAID;

			private static readonly int _SurfContourSuppAID;

			private static readonly int _SurfEdgeColorAID;

			private static readonly int _SurfEdgeThreshAID;

			private static readonly int _SurfDashColorAID;

			private static readonly int _SurfDashParamsAID;

			private static readonly int _SurfHatchColorAID;

			private static readonly int _SurfHatchParamsAID;

			private static readonly int _SurfFillBID;

			private static readonly int _SurfStrengthBID;

			private static readonly int _SurfContourSuppBID;

			private static readonly int _SurfEdgeColorBID;

			private static readonly int _SurfEdgeThreshBID;

			private static readonly int _SurfDashColorBID;

			private static readonly int _SurfDashParamsBID;

			private static readonly int _SurfHatchColorBID;

			private static readonly int _SurfHatchParamsBID;

			private static readonly int _TempRT;

			public MapCartographicPass(Material material)
			{
			}

			private void UpdateMaterialProperties()
			{
			}

			private void SetSurfaceGroup(TerrainSurfaceStyle g, int fillID, int strID, int contID, int edgeColID, int edgeThID, int dashColID, int dashPID, int hatchColID, int hatchPID)
			{
			}

			public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
			{
			}
		}

		[SerializeField]
		private Shader cartographicShader;

		private MapCartographicPass _pass;

		private Material _material;

		public static bool FeatureCreated { get; private set; }

		public static string LastSkipReason { get; private set; }

		public override void Create()
		{
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
		}

		protected override void Dispose(bool disposing)
		{
		}
	}
}
