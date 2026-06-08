using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Controllers;
using Kitchen.Components;
using Kitchen.NetworkSupport;
using KitchenData;
using LiveSplit;
using Newtonsoft.Json;
using Platforms;
using Sirenix.Utilities;
using UnityEngine;

namespace Kitchen
{
	public static class Preferences
	{
		private static Dictionary<Pref, IPreference> PreferenceMap = new Dictionary<Pref, IPreference>();

		private const float SAVE_DELAY_TIMER_INIT = 2f;

		private static bool isSaving = false;

		private static float saveDelayTimer = 2f;

		public static List<string> WindowLabels = new List<string> { "MENU_WINDOWED", "MENU_FULLSCREEN", "MENU_BORDERLESS" };

		public static List<FullScreenMode> WindowModes = new List<FullScreenMode>
		{
			FullScreenMode.Windowed,
			FullScreenMode.ExclusiveFullScreen,
			FullScreenMode.FullScreenWindow
		};

		public static bool TryGet<T>(Pref key, out T value)
		{
			value = default(T);
			if (!PreferenceMap.TryGetValue(key, out var value2))
			{
				return false;
			}
			value = ((Preference<T>)value2).Value;
			return true;
		}

		public static T Get<T>(Pref key)
		{
			if (TryGet<T>(key, out var value))
			{
				return value;
			}
			Debug.LogWarning($"Tried to get non-existent preference {key}");
			return default(T);
		}

		public static void Set<T>(Pref key, T value)
		{
			if (!PreferenceMap.TryGetValue(key, out var value2))
			{
				Debug.LogWarning($"Tried to set non-existent preference {key}");
				return;
			}
			((Preference<T>)value2).Value = value;
			Save();
		}

		private static Preference<T> AddGamePreference<T>(Preference<T> pref)
		{
			PreferenceMap.Add(pref.Key, pref);
			return pref;
		}

		public static Preference<T> AddPreference<T>(Preference<T> pref)
		{
			if (pref.Key.Namespace.IsNullOrWhitespace())
			{
				throw new Exception("Tried to add a non-namespaced preference");
			}
			PreferenceMap.Add(pref.Key, pref);
			return pref;
		}

		private static void SetUpPreferences()
		{
			if (PreferenceMap != null && PreferenceMap.Count != 0)
			{
				return;
			}
			PreferenceMap = new Dictionary<Pref, IPreference>();
			AddGamePreference(new BoolPreference(Pref.LiveSplitEnabled, default_value: false)).ApplyAction = delegate(bool value)
			{
				if (value)
				{
					global::LiveSplit.LiveSplit.Connect();
				}
				if (!value)
				{
					global::LiveSplit.LiveSplit.Disconnect();
				}
			};
			AddGamePreference(new LocalePreference(Pref.Localisation)).ApplyAction = delegate(Locale f)
			{
				Localisation.CurrentLocale = f;
				GameData.Main?.ReLocalise(f);
			};
			AddGamePreference(new BoolPreference(Pref.LettersSpawnInside, default_value: true));
			AddGamePreference(new BoolPreference(Pref.ProvideStartingEnvelopesAsParcels, default_value: false));
			AddGamePreference(new FloatPreference(Pref.OverallVolume, 0.5f));
			AddGamePreference(new FloatPreference(Pref.MusicVolume, VolumeManagement.MusicVolumeValues[VolumeManagement.MusicVolumeValues.Count - 2]));
			AddGamePreference(new FloatPreference(Pref.EffectVolume, VolumeManagement.VolumeValues[VolumeManagement.MusicVolumeValues.Count - 2]));
			AddGamePreference(new ScreenPreference(Pref.ScreenResolution, new ScreenPreference.ScreenData
			{
				Resolution = new Resolution
				{
					width = Screen.width,
					height = Screen.height,
					refreshRate = Screen.currentResolution.refreshRate
				},
				FullScreenMode = Screen.fullScreenMode
			})).ApplyAction = delegate(ScreenPreference.ScreenData value)
			{
				if (PlatformSettings.SupportsGraphicsMenu)
				{
					Screen.SetResolution(value.Resolution.width, value.Resolution.height, value.FullScreenMode, value.Resolution.refreshRate);
				}
			};
			AddGamePreference(new IntPreference(Pref.VSyncCount, 1)).ApplyAction = delegate(int value)
			{
				QualitySettings.vSyncCount = value;
			};
			AddGamePreference(new IntPreference(Pref.MaxFPS, 60)).ApplyAction = delegate(int value)
			{
				Application.targetFrameRate = value;
			};
			AddGamePreference(new IntPreference(Pref.Quality, 2)).ApplyAction = QualitySettings.SetQualityLevel;
			AddGamePreference(new BoolPreference(Pref.AccessibilityEnableNightFade, default_value: true));
			AddGamePreference(new BoolPreference(Pref.AccessibilityColourBlindMode, default_value: false));
			AddGamePreference(new BoolPreference(Pref.AccessibilityWeatherVisible, default_value: true));
			AddGamePreference(new BoolPreference(Pref.RequirePingForBlueprintInfo, default_value: false));
			AddGamePreference(new BoolPreference(Pref.SeedsAffectEverything, default_value: true));
			AddGamePreference(new BoolPreference(Pref.SkipNewRecipePopups, default_value: false));
			AddGamePreference(new BoolPreference(Pref.AlwaysShowRunTimer, default_value: false));
			AddGamePreference(new BoolPreference(Pref.SpeedrunMode, default_value: false));
			AddGamePreference(new BoolPreference(Pref.SwitchLegacyControls, default_value: false)).ApplyAction = delegate(bool v)
			{
				InputSourceIdentifier.UseAlternateControllerLayout = v;
			};
			Load();
		}

		public static void Save()
		{
			SetUpPreferences();
			foreach (KeyValuePair<Pref, IPreference> item in PreferenceMap)
			{
				item.Value.Save();
			}
			if (PlatformSettings.UseFileForPreferences)
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				foreach (KeyValuePair<Pref, IPreference> item2 in PreferenceMap)
				{
					IPreference value = item2.Value;
					dictionary.Add(value.Key.StorageKey, value.SaveAsString());
				}
				string s = JsonConvert.SerializeObject(dictionary);
				Persistence.PreferencesFile.Set(Encoding.UTF8.GetBytes(s));
			}
			else
			{
				Platform.Current.SavePlayerPrefs();
			}
		}

		public static void Load()
		{
			if (PlatformSettings.UseFileForPreferences)
			{
				SetUpPreferences();
				{
					foreach (SaveInfo<Nothing> item in Persistence.PreferencesFile.Get())
					{
						try
						{
							Dictionary<string, string> dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(Encoding.UTF8.GetString(item.Data));
							foreach (KeyValuePair<Pref, IPreference> item2 in PreferenceMap)
							{
								if (dictionary.TryGetValue(item2.Key.StorageKey, out var value))
								{
									item2.Value.LoadFromString(value);
								}
							}
							break;
						}
						catch (Exception arg)
						{
							EventLog.Files.Report(FileEvent.FailedToOpenPrefFile, $"Failed to open preferences save {item.Name}, {arg}");
						}
					}
					return;
				}
			}
			Platform.Current.LoadPlayerPrefs();
			SetUpPreferences();
			foreach (KeyValuePair<Pref, IPreference> item3 in PreferenceMap)
			{
				item3.Value.Load();
			}
		}

		public static IEnumerator DelayedSave()
		{
			saveDelayTimer = 2f;
			if (!isSaving)
			{
				Debug.Log($"Starting delayed save. Will save in {saveDelayTimer}s if no other calls to save occur...");
				isSaving = true;
				while (saveDelayTimer > 0f)
				{
					saveDelayTimer -= Time.deltaTime;
					yield return null;
				}
				Save();
				isSaving = false;
			}
		}

		public static void CleanUp()
		{
			PreferenceMap = new Dictionary<Pref, IPreference>();
			isSaving = false;
			saveDelayTimer = 2f;
		}
	}
}
