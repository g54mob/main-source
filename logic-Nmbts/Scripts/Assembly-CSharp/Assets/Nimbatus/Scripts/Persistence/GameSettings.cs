using System;
using System.IO;
using System.Reflection;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Persistence
{
	[Serializable]
	public class GameSettings
	{
		public string SettingsPath = Application.persistentDataPath + "/Settings.ini";

		private float _lastSoundVolume;

		private float _lastMusicVolume;

		public static readonly Color DefaultGridColor = new Color(0.2f, 13f / 51f, 26f / 85f, 1f);

		public static readonly Color DefaultBackgroundColor = new Color(0.1626838f, 0.2807316f, 0.375f, 1f);

		[GameSetting("Display")]
		public int ScreenHeight { get; set; }

		[GameSetting("Display")]
		public int ScreenWidth { get; set; }

		[GameSetting("Display")]
		public bool UseFullScreen { get; set; }

		[GameSetting("Display")]
		public bool BloomActive { get; set; }

		[GameSetting("Display")]
		public bool AntiAliasingActive { get; set; }

		[GameSetting("Display")]
		public bool VSyncActive { get; set; }

		[GameSetting("Audio")]
		public float SoundEffectVolume { get; set; }

		[GameSetting("Audio")]
		public float MusicVolume { get; set; }

		[GameSetting("Display")]
		public float BloomIntensity { get; set; }

		[GameSetting("Gameplay")]
		public bool SkipTutorial { get; set; }

		[GameSetting("Gameplay")]
		public bool SkipCampaignTutorial { get; set; }

		[GameSetting("Misc")]
		public bool HideReviewDisplay { get; set; }

		[GameSetting("Misc")]
		public bool HideNewsDisplay { get; set; }

		[GameSetting("Misc")]
		public float DroneSkinTransparency { get; set; }

		[GameSetting("Misc")]
		public Color BackgroundColor { get; set; }

		[GameSetting("Misc")]
		public Color GridColor { get; set; }

		[GameSetting("Language")]
		public string SelectedLanguage { get; set; }

		public void Init()
		{
			Load();
			Apply();
			ApplyResolution();
		}

		private void SetDefault()
		{
			if (Screen.width > 100 && Screen.height > 100)
			{
				ScreenHeight = Screen.height;
				ScreenWidth = Screen.width;
				UseFullScreen = Screen.fullScreen;
			}
			else
			{
				ScreenHeight = 768;
				ScreenWidth = 1024;
				UseFullScreen = false;
			}
			BloomActive = true;
			AntiAliasingActive = true;
			VSyncActive = false;
			SoundEffectVolume = 0.4f;
			MusicVolume = 0.5f;
			BloomIntensity = 0.5f;
			Application.targetFrameRate = 300;
			SkipTutorial = false;
			SkipCampaignTutorial = false;
			HideReviewDisplay = false;
			HideNewsDisplay = false;
			DroneSkinTransparency = 0.25f;
			SelectedLanguage = LocalizationManager.CurrentLanguageCode;
			GridColor = DefaultGridColor;
			BackgroundColor = DefaultBackgroundColor;
		}

		public void Save()
		{
			try
			{
				ScreenHeight = Screen.height;
				ScreenWidth = Screen.width;
				INIParser iNIParser = new INIParser();
				iNIParser.Open(SettingsPath);
				PropertyInfo[] properties = typeof(GameSettings).GetProperties();
				foreach (PropertyInfo propertyInfo in properties)
				{
					GameSetting[] array = (GameSetting[])propertyInfo.GetCustomAttributes(typeof(GameSetting), false);
					foreach (GameSetting gameSetting in array)
					{
						if (propertyInfo.PropertyType == typeof(bool))
						{
							iNIParser.WriteValue(gameSetting.Category, propertyInfo.Name, (bool)propertyInfo.GetValue(this, null));
						}
						if (propertyInfo.PropertyType == typeof(int))
						{
							iNIParser.WriteValue(gameSetting.Category, propertyInfo.Name, (int)propertyInfo.GetValue(this, null));
						}
						if (propertyInfo.PropertyType == typeof(float))
						{
							iNIParser.WriteValue(gameSetting.Category, propertyInfo.Name, (float)propertyInfo.GetValue(this, null));
						}
						if (propertyInfo.PropertyType == typeof(Color))
						{
							string value = "#" + ColorUtility.ToHtmlStringRGBA((Color)propertyInfo.GetValue(this, null));
							iNIParser.WriteValue(gameSetting.Category, propertyInfo.Name, value);
						}
					}
				}
				iNIParser.Close();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		public void Load()
		{
			SetDefault();
			INIParser iNIParser = new INIParser();
			if (File.Exists(SettingsPath))
			{
				try
				{
					iNIParser.Open(SettingsPath);
					PropertyInfo[] properties = typeof(GameSettings).GetProperties();
					foreach (PropertyInfo propertyInfo in properties)
					{
						GameSetting[] array = (GameSetting[])propertyInfo.GetCustomAttributes(typeof(GameSetting), false);
						foreach (GameSetting gameSetting in array)
						{
							if (propertyInfo.PropertyType == typeof(bool))
							{
								propertyInfo.SetValue(this, iNIParser.ReadValue(gameSetting.Category, propertyInfo.Name, (bool)propertyInfo.GetValue(this, null)), null);
							}
							if (propertyInfo.PropertyType == typeof(int))
							{
								propertyInfo.SetValue(this, iNIParser.ReadValue(gameSetting.Category, propertyInfo.Name, (int)propertyInfo.GetValue(this, null)), null);
							}
							if (propertyInfo.PropertyType == typeof(float))
							{
								propertyInfo.SetValue(this, iNIParser.ReadValue(gameSetting.Category, propertyInfo.Name, (float)propertyInfo.GetValue(this, null)), null);
							}
							if (propertyInfo.PropertyType == typeof(Color))
							{
								Color color = (Color)propertyInfo.GetValue(this, null);
								string defaultValue = "#" + ColorUtility.ToHtmlStringRGBA(color);
								Color color2;
								if (ColorUtility.TryParseHtmlString(iNIParser.ReadValue(gameSetting.Category, propertyInfo.Name, defaultValue), out color2))
								{
									propertyInfo.SetValue(this, color2);
								}
							}
						}
					}
					iNIParser.Close();
				}
				catch (Exception message)
				{
					SetDefault();
					Debug.Log(message);
					try
					{
						iNIParser.Close();
					}
					catch (Exception message2)
					{
						Debug.Log(message2);
					}
				}
			}
			if (ScreenHeight <= 100 || ScreenWidth <= 100)
			{
				if (Screen.width > 100 && Screen.height > 100)
				{
					ScreenHeight = Screen.height;
					ScreenWidth = Screen.width;
				}
				else
				{
					ScreenHeight = 768;
					ScreenWidth = 1024;
				}
				UseFullScreen = false;
			}
		}

		public void Apply()
		{
			QualitySettings.vSyncCount = (VSyncActive ? 1 : 0);
			QualitySettings.antiAliasing = (AntiAliasingActive ? 8 : 0);
			NGUITools.soundVolume = SoundEffectVolume;
			if (ScreenHeight <= 100 || ScreenWidth <= 100)
			{
				ScreenHeight = 768;
				ScreenWidth = 1024;
				UseFullScreen = false;
			}
			LocalizationManager.SetLanguageAndCode(LocalizationManager.GetLanguageFromCode(SelectedLanguage), SelectedLanguage);
		}

		public void ApplyResolution()
		{
			Screen.SetResolution(ScreenWidth, ScreenHeight, UseFullScreen);
		}

		public void ApplySoundSettings()
		{
			if ((double)Math.Abs(_lastSoundVolume - SoundEffectVolume) > 0.01 || (double)Math.Abs(_lastMusicVolume - MusicVolume) > 0.01)
			{
				AudioController.SetCategoryVolume("Music", MusicVolume);
				if (!RuntimeGlobals.IsGamePaused)
				{
					AudioController.SetCategoryVolume("Sound", SoundEffectVolume);
				}
				_lastSoundVolume = SoundEffectVolume;
				_lastMusicVolume = MusicVolume;
				NGUITools.soundVolume = SoundEffectVolume;
			}
		}
	}
}
