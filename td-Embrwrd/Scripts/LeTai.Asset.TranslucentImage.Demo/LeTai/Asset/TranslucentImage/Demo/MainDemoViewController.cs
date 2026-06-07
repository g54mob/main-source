using UnityEngine;
using UnityEngine.UI;

namespace LeTai.Asset.TranslucentImage.Demo
{
	public class MainDemoViewController : MonoBehaviour
	{
		public Toggle toggleLightMode;

		public Toggle toggleDarkMode;

		public Slider sliderBlurStrength;

		public Slider sliderVibrancy;

		public Slider sliderUpdateRate;

		public TranslucentImage[] translucentImages;

		private TranslucentImageSource source;

		private float backupBlurStrength;

		private float[] backupVibrancy;

		private void Start()
		{
		}

		private void BackupValues()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
