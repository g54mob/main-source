using AwesomeTechnologies.Utility.Quadtree;
using AwesomeTechnologies.VegetationSystem;
using UnityEngine;

namespace AwesomeTechnologies.Utility
{
	[HelpURL("http://www.awesometech.no/index.php/background-mask-creator")]
	public class MaskBackgroundCreator : MonoBehaviour
	{
		public BackgroundMaskQuality BackgroundMaskQuality = BackgroundMaskQuality.Normal2048;

		public Rect AreaRect;

		public int GetBackgroundMaskQualityPixelResolution(BackgroundMaskQuality backgroundMaskQuality)
		{
			switch (backgroundMaskQuality)
			{
			case BackgroundMaskQuality.Low1024:
				return 1024;
			case BackgroundMaskQuality.Normal2048:
				return 2048;
			case BackgroundMaskQuality.High4096:
				return 4096;
			default:
				return 1024;
			}
		}

		private void Reset()
		{
			VegetationSystemPro component = GetComponent<VegetationSystemPro>();
			if ((bool)component)
			{
				AreaRect = RectExtension.CreateRectFromBounds(component.VegetationSystemBounds);
			}
		}
	}
}
