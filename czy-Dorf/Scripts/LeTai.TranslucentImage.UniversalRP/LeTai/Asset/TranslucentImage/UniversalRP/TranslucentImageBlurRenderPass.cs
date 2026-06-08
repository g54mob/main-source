using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Scripting.APIUpdating;

namespace LeTai.Asset.TranslucentImage.UniversalRP
{
	[MovedFrom("LeTai.Asset.TranslucentImage.LWRP")]
	public class TranslucentImageBlurRenderPass : ScriptableRenderPass
	{
		private const string PROFILER_TAG = "Translucent Image Source";

		private readonly RenderTargetHandle afterPostProcessTexture;

		private TISPassData currentPassData;

		private Material previewMaterial;

		public Material PreviewMaterial
		{
			get
			{
				if (!previewMaterial)
				{
					previewMaterial = CoreUtils.CreateEngineMaterial("Hidden/FillCrop_UniversalRP");
				}
				return previewMaterial;
			}
		}

		public TranslucentImageBlurRenderPass()
		{
			afterPostProcessTexture.Init("_AfterPostProcessTexture");
		}

		~TranslucentImageBlurRenderPass()
		{
			CoreUtils.Destroy(previewMaterial);
		}

		internal void Setup(TISPassData passData)
		{
			currentPassData = passData;
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			CommandBuffer commandBuffer = CommandBufferPool.Get("Translucent Image Source");
			RenderTargetIdentifier renderTargetIdentifier = (renderingData.cameraData.postProcessEnabled ? afterPostProcessTexture.Identifier() : currentPassData.cameraColorTarget);
			currentPassData.blurAlgorithm.Blur(commandBuffer, renderTargetIdentifier, currentPassData.blurSource.BlurRegion, currentPassData.blurSource.BlurredScreen);
			if (currentPassData.isPreviewing)
			{
				PreviewMaterial.SetVector(LeTai.Asset.TranslucentImage.ShaderId.CROP_REGION, Extensions.ToMinMaxVector(currentPassData.blurSource.BlurRegion));
				Extensions.BlitFullscreenTriangle(commandBuffer, currentPassData.blurSource.BlurredScreen, renderTargetIdentifier, PreviewMaterial, 0);
			}
			context.ExecuteCommandBuffer(commandBuffer);
			CommandBufferPool.Release(commandBuffer);
		}
	}
}
