using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Jundroo.Common.Platform;
using Jundroo.Common.Settings;
using Jundroo.Common.Settings.Events;
using Jundroo.SocialPlatforms;
using UnityEngine;

namespace Assets.Scripts.Settings
{
	public class GameQualitySettings : IGameQualitySettings
	{
		private string _filePath;

		private Vector2i _nativeResolution;

		public IReadOnlyList<SettingsCategory> Categories { get; private set; }

		public CraftQualitySettings Craft { get; private set; }

		public DisplayQualitySettings Display { get; private set; }

		public EnvironmentQualitySettings Environment { get; private set; }

		public GeneralQualitySettings General { get; private set; }

		public OverallQualitySetting OverallQuality { get; private set; }

		public PhysicsQualitySettings Physics { get; private set; }

		public PostProcessingQualitySettings PostProcessing { get; private set; }

		public ShadowQualitySettings Shadow { get; private set; }

		public WaterQualitySettings Water { get; private set; }

		private GameQualitySettings()
		{
		}

		public static GameQualitySettings Create(string filePath)
		{
			GameQualitySettings gameQualitySettings = new GameQualitySettings();
			gameQualitySettings.Initialize(filePath);
			return gameQualitySettings;
		}

		public void ApplySettings()
		{
			ApplyDisplaySettings();
		}

		public bool HasAnyUnsavedChanges()
		{
			return Categories.HasUnsavedChanges();
		}

		public void Save()
		{
			XDocument xDocument = new XDocument(new XElement("QualitySettings"));
			foreach (SettingsCategory category in Categories)
			{
				category.SaveToXml(xDocument.Root);
			}
			xDocument.Save(_filePath);
		}

		public void SaveIfNecessary()
		{
			if (HasAnyUnsavedChanges())
			{
				Save();
			}
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
				int num = (int)((float)_nativeResolution.x * mobileResolutionScale.Value);
				int num2 = (int)((float)_nativeResolution.y * mobileResolutionScale.Value);
				if (Screen.width != num || Screen.height != num2)
				{
					Screen.SetResolution(num, num2, fullscreen: true);
				}
				Debug.LogFormat("Screen Size: {0}x{1}, Requested: {2}x{3}\nNative Resolution: {4}x{5}@{6}Hz\nMobile Resolution Scale: {7}", Screen.width, Screen.height, num, num2, _nativeResolution.x, _nativeResolution.y, Screen.currentResolution.refreshRateRatio, mobileResolutionScale.Value);
			}
		}

		private SettingsCategoryPreset GetDefaultPreset(SettingsCategory category)
		{
			if (SocialExt.IsSteam && SocialExt.Steam.IsRunningOnSteamDeck())
			{
				return SettingsCategoryPreset.Low;
			}
			DeviceFlags flags = Device.CurrentDevice.Flags;
			if (flags.HasFlag(DeviceFlags.HighEndGraphics))
			{
				return SettingsCategoryPreset.High;
			}
			if (flags.HasFlag(DeviceFlags.MidRangeGraphics))
			{
				return SettingsCategoryPreset.Medium;
			}
			return SettingsCategoryPreset.Low;
		}

		private IEnumerable<(DeviceFlags DeviceFlags, IEnumerable<SettingsCategoryPreset> Presets)> GetRegisteredPresets(SettingsCategory category)
		{
			if (category.GetDefaultPreset() != SettingsCategoryPreset.None)
			{
				yield return (DeviceFlags: DeviceFlags.All, Presets: new SettingsCategoryPreset[6]
				{
					SettingsCategoryPreset.VeryLow,
					SettingsCategoryPreset.Low,
					SettingsCategoryPreset.Medium,
					SettingsCategoryPreset.High,
					SettingsCategoryPreset.VeryHigh,
					SettingsCategoryPreset.Custom
				});
			}
		}

		private void Initialize(string filePath)
		{
			_filePath = filePath;
			XElement xElement = null;
			if (File.Exists(filePath))
			{
				try
				{
					xElement = XDocument.Load(filePath)?.Root;
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					Debug.LogError("An error occurred trying to load the quality settings file: " + filePath);
				}
			}
			Categories = SettingsCategory.InitializeCategoryProperties(this, xElement, GetDefaultPreset, GetRegisteredPresets);
			_nativeResolution = new Vector2i(UnityEngine.Display.main.systemWidth, UnityEngine.Display.main.systemHeight);
			if (xElement == null)
			{
				Save();
			}
		}

		private void OnMobileResolutionScaleChanged(object sender, SettingChangedEventArgs<float> e)
		{
			ApplyMobileResolution();
		}
	}
}
