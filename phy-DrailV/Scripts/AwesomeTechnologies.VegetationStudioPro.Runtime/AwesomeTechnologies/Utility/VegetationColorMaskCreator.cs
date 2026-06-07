using UnityEngine;

namespace AwesomeTechnologies.Utility
{
	public class VegetationColorMaskCreator : MonoBehaviour
	{
		public VegetationColorMaskQuality VegetationColorMaskQuality = VegetationColorMaskQuality.High4096;

		public int InvisibleLayer = 30;

		public bool IncludeGrass = true;

		public bool IncludePlants = true;

		public bool IncludeTrees;

		public bool IncludeObjects;

		public bool IncludeLargeObjects;

		public float VegetationScale = 2f;

		public Color BackgroundColor = new Color(0.2f, 42f / 85f, 0.03137255f, 0f);

		public bool RenderWithoutLight = true;

		public Texture2D BackgroundTexture;

		public Rect AreaRect;

		public VegetationColorMaskBackgroundSource BackgroundSource;

		public int GetVegetationColorMaskQualityPixelResolution(VegetationColorMaskQuality vegetationColorMaskQuality)
		{
			switch (vegetationColorMaskQuality)
			{
			case VegetationColorMaskQuality.Low1024:
				return 1024;
			case VegetationColorMaskQuality.Normal2048:
				return 2048;
			case VegetationColorMaskQuality.High4096:
				return 4096;
			case VegetationColorMaskQuality.Ultra8192:
				return 8192;
			default:
				return 1024;
			}
		}
	}
}
