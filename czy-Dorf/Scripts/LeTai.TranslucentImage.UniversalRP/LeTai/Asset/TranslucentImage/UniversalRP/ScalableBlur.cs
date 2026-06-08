using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Scripting.APIUpdating;

namespace LeTai.Asset.TranslucentImage.UniversalRP
{
	[MovedFrom("LeTai.Asset.TranslucentImage.LWRP")]
	public class ScalableBlur : IBlurAlgorithm
	{
		private Material material;

		private ScalableBlurConfig config;

		private Material Material
		{
			get
			{
				if (material == null)
				{
					Material = new Material(Shader.Find("Hidden/EfficientBlur_UniversalRP"));
				}
				return material;
			}
			set
			{
				material = value;
			}
		}

		public void Init(BlurConfig config)
		{
			this.config = (ScalableBlurConfig)config;
		}

		public void Blur(CommandBuffer cmd, RenderTargetIdentifier src, Rect srcCropRegion, RenderTexture target)
		{
			float radius = ScaleWithResolution(config.Radius, (float)target.width * srcCropRegion.width, (float)target.height * srcCropRegion.height);
			ConfigMaterial(radius, Extensions.ToMinMaxVector(srcCropRegion));
			int downsampleFactor = ((config.Iteration > 0) ? 1 : 0);
			int num = Mathf.Max(config.Iteration * 2 - 1, 1);
			int num2 = ShaderId.intermediateRT[0];
			CreateTempRenderTextureFrom(cmd, num2, target, downsampleFactor);
			Extensions.BlitFullscreenTriangle(cmd, src, num2, Material, 1);
			for (int i = 1; i < num; i++)
			{
				BlurAtDepth(cmd, i, target);
			}
			Extensions.BlitFullscreenTriangle(cmd, ShaderId.intermediateRT[num - 1], target, Material, 0);
			CleanupIntermediateRT(cmd, num);
		}

		private void CreateTempRenderTextureFrom(CommandBuffer cmd, int nameId, RenderTexture src, int downsampleFactor)
		{
			int width = src.width >> downsampleFactor;
			int height = src.height >> downsampleFactor;
			cmd.GetTemporaryRT(nameId, width, height, 0, FilterMode.Bilinear);
		}

		protected virtual void BlurAtDepth(CommandBuffer cmd, int depth, RenderTexture baseTexture)
		{
			int a = Utilities.SimplePingPong(depth, config.Iteration - 1) + 1;
			a = Mathf.Min(a, config.MaxDepth);
			CreateTempRenderTextureFrom(cmd, ShaderId.intermediateRT[depth], baseTexture, a);
			Extensions.BlitFullscreenTriangle(cmd, ShaderId.intermediateRT[depth - 1], ShaderId.intermediateRT[depth], Material, 0);
		}

		private void CleanupIntermediateRT(CommandBuffer cmd, int amount)
		{
			for (int i = 0; i < amount; i++)
			{
				cmd.ReleaseTemporaryRT(ShaderId.intermediateRT[i]);
			}
		}

		private float ScaleWithResolution(float baseRadius, float width, float height)
		{
			float value = Mathf.Min(width, height) / 1080f;
			value = Mathf.Clamp(value, 0.5f, 2f);
			return baseRadius * value;
		}

		protected void ConfigMaterial(float radius, Vector4 cropRegion)
		{
			Material.SetFloat(LeTai.Asset.TranslucentImage.ShaderId.RADIUS, radius);
			Material.SetVector(LeTai.Asset.TranslucentImage.ShaderId.CROP_REGION, cropRegion);
		}
	}
}
