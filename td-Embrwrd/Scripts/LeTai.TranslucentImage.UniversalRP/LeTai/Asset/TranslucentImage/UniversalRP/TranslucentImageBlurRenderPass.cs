using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Scripting.APIUpdating;

namespace LeTai.Asset.TranslucentImage.UniversalRP
{
	[MovedFrom("LeTai.Asset.TranslucentImage.LWRP")]
	public class TranslucentImageBlurRenderPass : ScriptableRenderPass
	{
		internal struct PassData
		{
			public TranslucentImageSource blurSource;

			public IBlurAlgorithm blurAlgorithm;

			public Rect camPixelRect;

			public bool shouldUpdateBlur;

			public bool isPreviewing;

			public Material previewMaterial;
		}

		internal struct SRPassData
		{
			public bool canvasDisappearWorkaround;
		}

		public readonly struct PreviewExecutionData
		{
			public readonly TranslucentImageSource blurSource;

			public readonly RenderTargetIdentifier previewTarget;

			public readonly Material previewMaterial;

			public PreviewExecutionData(TranslucentImageSource blurSource, RenderTargetIdentifier previewTarget, Material previewMaterial)
			{
				this.blurSource = null;
				this.previewTarget = default(RenderTargetIdentifier);
				this.previewMaterial = null;
			}
		}

		private const string PROFILER_TAG = "Translucent Image Source";

		private readonly URPRendererInternal urpRendererInternal;

		private PassData currentPassData;

		private SRPassData currentSRPassData;

		internal TranslucentImageBlurRenderPass(URPRendererInternal urpRendererInternal)
		{
		}

		internal void SetupSRP(SRPassData srPassData)
		{
		}

		public void Dispose()
		{
		}

		internal void Setup(PassData passData)
		{
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
		}

		public static void ExecutePreview(CommandBuffer cmd, ref PreviewExecutionData data)
		{
		}

		private void RenderGraphInit()
		{
		}

		private void RenderGraphDispose()
		{
		}
	}
}
