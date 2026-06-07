using System.Collections.Generic;
using System.Xml.Linq;
using ModApi;
using ModApi.Settings;
using ModApi.Settings.Core;
using ModApi.Settings.Core.Events;
using UnityEngine;

namespace Assets.Scripts.Settings
{
	public class GameQualitySettings : IGameQualitySettings
	{
		private static Vector2i _nativeMobileResolution;

		public IReadOnlyList<SettingsCategory> Categories { get; private set; }

		public CraftQualitySettings Crafts { get; private set; }

		public DisplayQualitySettings Display { get; private set; }

		public ImageEffectsQualitySettings ImageEffects { get; private set; }

		public MapQualitySettings Map { get; private set; }

		public OverallQualitySetting OverallQuality { get; private set; }

		public PhysicsQualitySettings Physics { get; private set; }

		public ShadowQualitySettings Shadows { get; private set; }

		public TerrainQualitySettings Terrain { get; private set; }

		public VisualEffectsQualitySettings VisualEffects { get; private set; }

		public WaterQualitySettings Water { get; private set; }

		public static GameQualitySettings CreateFromXml(XElement xml)
		{
			_nativeMobileResolution = new Vector2i(UnityEngine.Display.main.systemWidth, UnityEngine.Display.main.systemHeight);
			GameQualitySettings gameQualitySettings = new GameQualitySettings();
			gameQualitySettings.Categories = SettingsCategory.InitializeCategoryProperties(gameQualitySettings, xml?.Element("Quality"));
			return gameQualitySettings;
		}

		public void ApplySettings()
		{
			ApplyDisplaySettings();
		}

		public void SaveToXml(XElement xml)
		{
			XElement xElement = new XElement("Quality");
			foreach (SettingsCategory category in Categories)
			{
				category.SaveToXml(xElement);
			}
			xml.Add(xElement);
		}

		private void ApplyDisplaySettings()
		{
			if (Device.IsMobileBuild)
			{
				Screen.autorotateToLandscapeLeft = true;
				Screen.autorotateToLandscapeRight = true;
				Screen.orientation = ScreenOrientation.AutoRotation;
				ApplyMobileResolution();
				Display.MobileResolutionScale.Changed += OnMobileResolutionScaleChanged;
				return;
			}
			Resolution resolution = Display.Resolution.Value;
			if (resolution.width <= 0 || resolution.height <= 0)
			{
				resolution = new Resolution
				{
					width = 1024,
					height = 768,
					refreshRateRatio = resolution.refreshRateRatio
				};
			}
			Screen.SetResolution(resolution.width, resolution.height, Display.Fullscreen);
			if (!Device.IsUnityEditor)
			{
				Debug.LogFormat("Screen Size: {0}x{1}, Requested: {2}x{3}@{4}hz\nResolution: {5}x{6}@{7}hz, Full Screen: {8}", Screen.width, Screen.height, resolution.width, resolution.height, resolution.refreshRateRatio, Screen.currentResolution.width, Screen.currentResolution.height, Screen.currentResolution.refreshRateRatio, Screen.fullScreen);
			}
		}

		private void ApplyMobileResolution()
		{
			NumericSetting<float> mobileResolutionScale = Display.MobileResolutionScale;
			if (mobileResolutionScale.State == SettingState.Enabled)
			{
				int num = (int)((float)_nativeMobileResolution.x * mobileResolutionScale.Value);
				int num2 = (int)((float)_nativeMobileResolution.y * mobileResolutionScale.Value);
				if (Screen.width != num || Screen.height != num2)
				{
					Screen.SetResolution(num, num2, fullscreen: true);
				}
				Debug.LogFormat("Screen Size: {0}x{1}, Requested: {2}x{3}\nNative Resolution: {4}x{5}@{6}Hz\nMobile Resolution Scale: {7}", Screen.width, Screen.height, num, num2, _nativeMobileResolution.x, _nativeMobileResolution.y, Screen.currentResolution.refreshRateRatio, mobileResolutionScale.Value);
			}
		}

		private void OnMobileResolutionScaleChanged(object sender, SettingChangedEventArgs<float> e)
		{
			ApplyMobileResolution();
		}
	}
}
