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
			source = Shims.FindObjectOfType<TranslucentImageSource>();
			ColorSchemeManager colorSchemeManager = GetComponent<ColorSchemeManager>();
			BackupValues();
			toggleLightMode.onValueChanged.AddListener(delegate(bool isOn)
			{
				if (isOn)
				{
					colorSchemeManager.SetColorScheme(ColorSchemeManager.DemoColorScheme.Light);
				}
			});
			toggleDarkMode.onValueChanged.AddListener(delegate(bool isOn)
			{
				if (isOn)
				{
					colorSchemeManager.SetColorScheme(ColorSchemeManager.DemoColorScheme.Dark);
				}
			});
			sliderBlurStrength.onValueChanged.AddListener(delegate(float value)
			{
				source.BlurConfig.Strength = value;
			});
			sliderVibrancy.onValueChanged.AddListener(delegate(float value)
			{
				for (int i = 0; i < translucentImages.Length; i++)
				{
					translucentImages[i].materialForRendering.SetFloat(ShaderID.VIBRANCY, value);
				}
			});
			sliderUpdateRate.onValueChanged.AddListener(delegate(float value)
			{
				source.MaxUpdateRate = (Mathf.Approximately(value, sliderUpdateRate.maxValue) ? float.PositiveInfinity : value);
			});
		}

		private void BackupValues()
		{
			backupBlurStrength = source.BlurConfig.Strength;
			backupVibrancy = new float[translucentImages.Length];
			for (int i = 0; i < translucentImages.Length; i++)
			{
				backupVibrancy[i] = translucentImages[i].materialForRendering.GetFloat(ShaderID.VIBRANCY);
			}
		}

		private void OnDestroy()
		{
			source.BlurConfig.Strength = backupBlurStrength;
			for (int i = 0; i < translucentImages.Length; i++)
			{
				translucentImages[i].materialForRendering.SetFloat(ShaderID.VIBRANCY, backupVibrancy[i]);
			}
		}
	}
}
