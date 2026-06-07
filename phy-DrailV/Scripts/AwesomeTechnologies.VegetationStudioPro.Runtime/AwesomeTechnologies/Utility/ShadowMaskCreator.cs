using UnityEngine;

namespace AwesomeTechnologies.Utility
{
	public class ShadowMaskCreator : MonoBehaviour
	{
		public ShadowMaskQuality ShadowMaskQuality = ShadowMaskQuality.High4096;

		public int InvisibleLayer = 30;

		public bool IncludeTrees = true;

		public bool IncludeLargeObjects = true;

		public Rect AreaRect;

		public int GetShadowMaskQualityPixelResolution(ShadowMaskQuality shadowMaskQuality)
		{
			switch (shadowMaskQuality)
			{
			case ShadowMaskQuality.Low1024:
				return 1024;
			case ShadowMaskQuality.Normal2048:
				return 2048;
			case ShadowMaskQuality.High4096:
				return 4096;
			case ShadowMaskQuality.Ultra8192:
				return 8192;
			default:
				return 1024;
			}
		}
	}
}
