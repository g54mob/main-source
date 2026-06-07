using UnityEngine;
using UnityEngine.Rendering;

namespace LeTai.Asset.TranslucentImage
{
	public class ScalableBlur : IBlurAlgorithm
	{
		private readonly RenderTargetIdentifier[] scratches = new RenderTargetIdentifier[14];

		private bool isBirp;

		private Material material;

		private ScalableBlurConfig config;

		private MaterialPropertyBlock propertyBlock;

		private Material Material
		{
			get
			{
				if (material == null)
				{
					Material = new Material(Shader.Find(isBirp ? "Hidden/EfficientBlur" : "Hidden/EfficientBlur_UniversalRP"));
				}
				return material;
			}
			set
			{
				material = value;
			}
		}

		public void Init(BlurConfig config, bool isBirp)
		{
			this.isBirp = isBirp;
			this.config = (ScalableBlurConfig)config;
			propertyBlock = propertyBlock ?? new MaterialPropertyBlock();
		}

		private Rect Crop(Rect src, Rect cropRegion)
		{
			Rect result = src;
			result.x += cropRegion.x * result.width;
			result.y += cropRegion.y * result.height;
			result.width *= cropRegion.width;
			result.height *= cropRegion.height;
			return result;
		}

		private Rect Intersect(Rect a, Rect b)
		{
			float num = Mathf.Max(a.xMin, b.xMin);
			float num2 = Mathf.Min(a.xMax, b.xMax);
			float num3 = Mathf.Max(a.yMin, b.yMin);
			float num4 = Mathf.Min(a.yMax, b.yMax);
			if (num < num2 && num3 < num4)
			{
				return new Rect(num, num3, num2 - num, num4 - num3);
			}
			return Rect.zero;
		}

		public void Blur(CommandBuffer cmd, RenderTargetIdentifier src, Rect srcCropRegion, Rect activeRegion, BackgroundFill backgroundFill, RenderTexture target)
		{
			float radius = ScaleWithResolution(config.Radius, (float)target.width * srcCropRegion.width, (float)target.height * srcCropRegion.height);
			ConfigMaterial(radius, backgroundFill);
			int num = Mathf.Clamp(config.Iteration * 2 - 1, 1, scratches.Length * 2 - 1);
			float strength = config.Strength;
			Rect activeRegionRelative = Intersect(activeRegion, srcCropRegion);
			activeRegionRelative.x = (activeRegionRelative.x - srcCropRegion.x) / srcCropRegion.width;
			activeRegionRelative.y = (activeRegionRelative.y - srcCropRegion.y) / srcCropRegion.height;
			activeRegionRelative.width /= srcCropRegion.width;
			activeRegionRelative.height /= srcCropRegion.height;
			if (activeRegionRelative.width != 0f && activeRegionRelative.height != 0f)
			{
				if (num > 1)
				{
					CropViewport(target.width >> 1, target.height >> 1, strength, out var viewport, out var activeRegionSnapped);
					propertyBlock.SetVector(ShaderID.CROP_REGION, RectUtils.ToMinMaxVector(Crop(srcCropRegion, activeRegionSnapped)));
					Blitter.Blit(cmd, src, scratches[0], Material, 0, propertyBlock, viewport);
				}
				int max = Mathf.Min(config.Iteration - 1, scratches.Length - 1);
				for (int i = 1; i < num; i++)
				{
					int num2 = SimplePingPong(i - 1, max);
					int num3 = SimplePingPong(i, max);
					int num4 = num3 + 1;
					CropViewport(target.width >> num4, target.height >> num4, strength, out var viewport2, out var activeRegionSnapped2);
					propertyBlock.SetVector(ShaderID.CROP_REGION, RectUtils.ToMinMaxVector(activeRegionSnapped2));
					Blitter.Blit(cmd, scratches[num2], scratches[num3], Material, 0, propertyBlock, viewport2);
				}
				CropViewport(target.width, target.height, 0f, out var viewport3, out var activeRegionSnapped3);
				activeRegionSnapped3 = ((num > 1) ? activeRegionSnapped3 : Crop(srcCropRegion, activeRegionSnapped3));
				propertyBlock.SetVector(ShaderID.CROP_REGION, RectUtils.ToMinMaxVector(activeRegionSnapped3));
				Blitter.Blit(cmd, (num > 1) ? scratches[0] : src, target, Material, 0, propertyBlock, viewport3);
			}
			void CropViewport(int targetWidth, int targetHeight, float padding, out Rect reference, out Rect reference2)
			{
				float num5 = activeRegionRelative.x * (float)targetWidth;
				float num6 = activeRegionRelative.y * (float)targetHeight;
				float num7 = Mathf.Floor(num5 - padding);
				float num8 = Mathf.Floor(num6 - padding);
				reference = new Rect(num7, num8, Mathf.Ceil(num5 + activeRegionRelative.width * (float)targetWidth + padding) - num7, Mathf.Ceil(num6 + activeRegionRelative.height * (float)targetHeight + padding) - num8);
				reference.x = Mathf.Max(reference.x, 0f);
				reference.y = Mathf.Max(reference.y, 0f);
				reference.width = Mathf.Min(reference.width, targetWidth);
				reference.height = Mathf.Min(reference.height, targetHeight);
				reference2 = new Rect(reference.x / (float)targetWidth, reference.y / (float)targetHeight, reference.width / (float)targetWidth, reference.height / (float)targetHeight);
			}
		}

		public int GetScratchesCount()
		{
			return Mathf.Min(config.Iteration, scratches.Length);
		}

		public void GetScratchDescriptor(int index, ref RenderTextureDescriptor descriptor)
		{
			if (index == 0)
			{
				int num = ((config.Iteration > 0) ? 1 : 0);
				descriptor.width >>= num;
				descriptor.height >>= num;
			}
			else
			{
				descriptor.width >>= 1;
				descriptor.height >>= 1;
			}
			if (descriptor.width <= 0)
			{
				descriptor.width = 1;
			}
			if (descriptor.height <= 0)
			{
				descriptor.height = 1;
			}
		}

		public void SetScratch(int index, RenderTargetIdentifier value)
		{
			scratches[index] = value;
		}

		protected void ConfigMaterial(float radius, BackgroundFill backgroundFill)
		{
			switch (backgroundFill.mode)
			{
			case BackgroundFillMode.None:
				Material.EnableKeyword("BACKGROUND_FILL_NONE");
				Material.DisableKeyword("BACKGROUND_FILL_COLOR");
				break;
			case BackgroundFillMode.Color:
				Material.EnableKeyword("BACKGROUND_FILL_COLOR");
				Material.DisableKeyword("BACKGROUND_FILL_NONE");
				Material.SetColor(ShaderID.BACKGROUND_COLOR, backgroundFill.color);
				break;
			}
			Material.SetFloat(ShaderID.RADIUS, radius);
		}

		private float ScaleWithResolution(float baseRadius, float width, float height)
		{
			float value = Mathf.Min(width, height) / 1080f;
			value = Mathf.Clamp(value, 0.5f, 2f);
			return baseRadius * value;
		}

		public static int SimplePingPong(int t, int max)
		{
			if (t > max)
			{
				return 2 * max - t;
			}
			return t;
		}
	}
}
