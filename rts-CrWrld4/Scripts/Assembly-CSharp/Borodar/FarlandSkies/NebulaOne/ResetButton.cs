using UnityEngine;
using UnityEngine.UI;

namespace Borodar.FarlandSkies.NebulaOne
{
	public class ResetButton : MonoBehaviour
	{
		private static class DefaultValue
		{
			public static Color BackgroundColor;

			public static Color StarsTint;

			public static float BrightnessMin;

			public static float BrightnessMax;

			public static Color BackgroundTint;

			public static Color BasementTint;

			public static Color RipplesTint1;

			public static Color RipplesTint2;

			public static Vector3 DensityRotation;

			public static float ThresholdLow;

			public static float ThresholdHigh;

			public static Vector3 RipplesDistortion;

			public static float Exposure;
		}

		public Image BackgroundColorImage;

		public Image StarsTintImage;

		public Slider BrightnessMinSlider;

		public Slider BrightnessMaxSlider;

		public Image BackgroundTintImage;

		public Slider BackgroundAlphaSlider;

		public Image BasementTintImage;

		public Slider BasementAlphaSlider;

		public Image RipplesTint1Image;

		public Slider RipplesAlpha1Slider;

		public Image RipplesTint2Image;

		public Slider RipplesAlpha2Slider;

		public Slider DensityRotationX;

		public Slider DensityRotationY;

		public Slider DensityRotationZ;

		public Slider ThresholdLow;

		public Slider ThresholdHigh;

		public Slider RipplesDistortionX;

		public Slider RipplesDistortionY;

		public Slider RipplesDistortionZ;

		public Slider ExoposureSlider;

		public void Start()
		{
		}

		public void OnClick()
		{
		}
	}
}
