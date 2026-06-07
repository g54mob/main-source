using UnityEngine;
using UnityEngine.Rendering;

namespace LeTai.Asset.TranslucentImage
{
	public class ScalableBlur : IBlurAlgorithm
	{
		private readonly RenderTargetIdentifier[] scratches;

		private bool isBirp;

		private Material material;

		private ScalableBlurConfig config;

		private MaterialPropertyBlock propertyBlock;

		private LocalKeyword kwBackgroundFillNone;

		private LocalKeyword kwBackgroundFillColor;

		private LocalKeyword kwUseExtraSample;

		private Material Material
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Init(BlurConfig config, bool isBirp)
		{
		}

		public void Blur(CommandBuffer cmd, RenderTargetIdentifier src, Rect srcCropRegion, Rect activeRegion, BackgroundFill backgroundFill, RenderTexture target)
		{
		}

		public int GetScratchesCount(float targetWidth, float targetHeight)
		{
			return 0;
		}

		public void GetNextScratchDescriptor(ref RenderTextureDescriptor prevDescriptor)
		{
		}

		public void SetScratch(int index, RenderTargetIdentifier value)
		{
		}

		protected void ConfigMaterial(BackgroundFill backgroundFill)
		{
		}

		private (float, float, int) GetEffectiveConfig(float targetWidth, float targetHeight)
		{
			return default((float, float, int));
		}

		public static int SimplePingPong(int t, int max)
		{
			return 0;
		}
	}
}
