using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using DV.Interaction.Inputs;
using DV.Telemetry;
using DV.UI.Presets;
using DV.Utils;
using DV.VR;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DV.UI
{
	public class SettingsProvider : ASettingsProvider
	{
		private const string FORMS_URL = "https://www.altfuture.gg/jobs/other";

		private Dictionary<string, Action> registeredPreferencesCallbacks = new Dictionary<string, Action>();

		public override bool IsFullscreen => Screen.fullScreen;

		public override bool ShouldShowLanguageSelector => !SceneSwitcher.IsInGameWorld;

		public override bool IsClosePauseMenuKeyPressed => InputManager.NewPlayer.GetButtonDown(InputManager.Actions.Escape);

		public override bool IsStillExportingTelemetry => TelemetrySavingTracker.AnyPendingSaves;

		public override bool IsVR => VRManager.IsVREnabled();

		public override bool AnyWandController => VRManager.AnyWandController();

		protected void OnDestroy()
		{
			UnregisterPreferences();
		}

		public override void ApplyChanges()
		{
			Debug.Log("Applying preference changes");
			Dictionary<string, PreferenceValues> dictionary = new Dictionary<string, PreferenceValues>();
			GetDiff(dictionary);
			foreach (KeyValuePair<string, PreferenceValues> item in dictionary)
			{
				string key = item.Key;
				PreferenceValues value = item.Value;
				string arg = key;
				PreferenceValues preferenceValues = value;
				Debug.Log($"Applying '{(object)preferenceValues.latestValue}' to {arg}");
				preferenceValues.Apply();
			}
			GamePreferences.SavePreferences();
			base.ApplyChanges();
		}

		public override bool IsPreferenceApplicable(string preferenceName)
		{
			if (preferenceValues.ContainsKey(preferenceName) && Enum.TryParse<Preferences>(preferenceName, out var result))
			{
				return !PreferencesUtils.IsExcluded(result);
			}
			return false;
		}

		private void UnregisterPreferences()
		{
			foreach (KeyValuePair<string, Action> registeredPreferencesCallback in registeredPreferencesCallbacks)
			{
				string key = registeredPreferencesCallback.Key;
				Action value = registeredPreferencesCallback.Value;
				GamePreferences.UnregisterFromPreferenceUpdated((Preferences)Enum.Parse(typeof(Preferences), key), value);
			}
			preferenceValues.Clear();
			registeredPreferencesCallbacks.Clear();
		}

		public override void ReloadPreferenceValues()
		{
			UnregisterPreferences();
			PreferencesUtils.GetPreferencesByExclusivity((!VRManager.IsVREnabled()) ? PreferencesExclusivity.NonVR : PreferencesExclusivity.VR).ForEach(RegisterPreference);
			if (!VRManager.IsVREnabled())
			{
				int currentIndex = SingletonBehaviour<ScreenResolutionOptions>.Instance.CurrentIndex;
				string key = "ScreenResolution-index-proxy";
				preferenceValues.Add(key, new PrefScreenResolutionDV(key, currentIndex, currentIndex));
			}
			preferenceValues.Add("Language", new PreferenceValueLanguage(this));
			presets.Clear();
			presets.Add("Graphics", GraphicsPresets.Get());
		}

		private void RegisterPreference(Preferences p)
		{
			PreferenceAttribute customAttribute = typeof(Preferences).GetField(p.ToString()).GetCustomAttribute<PreferenceAttribute>();
			if (customAttribute == null)
			{
				Debug.LogError(string.Format("Skipping preference '{0}' since it doesn't have '{1}'", p, "PreferenceAttribute"));
				return;
			}
			object obj = (VRManager.IsVREnabled() ? customAttribute.DefaultValueVR : customAttribute.DefaultValueNonVR);
			PreferenceValues value;
			if (customAttribute is BlnPrefAttribute)
			{
				bool defaultValue = obj != null && (bool)obj;
				value = new PrefDV<bool>(p.ToString(), defaultValue, GamePreferences.Get<bool>(p));
				RegisterPreferencesCallback<bool>(p);
			}
			else if (customAttribute is IntPrefAttribute)
			{
				int defaultValue2 = ((obj != null) ? ((int)obj) : 0);
				value = new PrefDV<int>(p.ToString(), defaultValue2, GamePreferences.Get<int>(p));
				RegisterPreferencesCallback<int>(p);
			}
			else if (customAttribute is FltPrefAttribute)
			{
				float defaultValue3 = ((obj == null) ? 0f : ((float)obj));
				switch (p)
				{
				case Preferences.MasterVolumeLevel:
					value = new PreferenceValueAudioMasterLevel(p.ToString(), defaultValue3, GamePreferences.Get<float>(p));
					break;
				case Preferences.MainMenuMusicVolume:
					value = new PreferenceValueMainMenuMusicVolume(this, p.ToString(), defaultValue3, GamePreferences.Get<float>(p));
					break;
				default:
					value = new PrefDV<float>(p.ToString(), defaultValue3, GamePreferences.Get<float>(p));
					break;
				}
				RegisterPreferencesCallback<float>(p);
			}
			else
			{
				if (!(customAttribute is StrPrefAttribute))
				{
					Debug.LogError($"Skipping preference '{p}', it has an unexpected attribute type '{customAttribute.GetType().Name}'");
					return;
				}
				string defaultValue4 = ((obj == null) ? "" : ((string)obj));
				value = new PrefDV<string>(p.ToString(), defaultValue4, GamePreferences.Get<string>(p));
				RegisterPreferencesCallback<string>(p);
			}
			preferenceValues.Add(p.ToString(), value);
		}

		private void RegisterPreferencesCallback<T>(Preferences p)
		{
			Action action = delegate
			{
				OnPreferenceUpdated<T>(p);
			};
			GamePreferences.RegisterToPreferenceUpdated(p, action);
			registeredPreferencesCallbacks.Add(p.ToString(), action);
		}

		private void OnPreferenceUpdated<T>(Preferences pref)
		{
			if (preferenceValues.TryGetValue(pref.ToString(), out var value))
			{
				value.latestValue = GamePreferences.Get<T>(pref);
				value.originalValue = value.latestValue;
				value.ImmediateEffectApply();
			}
		}

		public override string[] GetLocalizationKeysForSelector(string key)
		{
			GraphicsOptions instance = SingletonBehaviour<GraphicsOptions>.Instance;
			switch (key)
			{
			case "Crosshair":
				return new string[3] { "settings/crosshair_auto", "settings/crosshair_on", "settings/crosshair_off" };
			case "DetailLevel":
				return instance.DetailLevelLodBias_LOC;
			case "AnisotropicFiltering":
				return instance.AnisotropicLevel_LOC;
			case "AntiAliasingForwardLevelsIndex":
				return instance.AntiAliasingForward_LOC;
			case "AntiAliasingDeferredLevelsIndex":
				return instance.AntiAliasingDeferred_LOC;
			case "AmbientOcclusionQualityIndex":
				return instance.AmbientOcclusionQuality_LOC;
			case "ShadowsQualityIndex":
				return instance.ShadowsQuality_LOC;
			case "TerrainLightingQualityIndex":
				return instance.TerrainLightingQuality_LOC;
			case "RainQualityIndex":
				return instance.RainQuality_LOC;
			case "VegetationQualityIndex":
				return instance.VegetationQuality_LOC;
			case "ReflectionQualityIndex":
				return instance.WaterReflectionQuality_LOC;
			case "LightingQualityIndex":
				return instance.LightingQuality_LOC;
			case "ScreenResolution-index-proxy":
				return GetSupportedResolutions();
			case "MouseDrag":
				return new string[2] { "settings/mouse_drag_world", "settings/mouse_drag_vertical" };
			case "RotationMode":
				return new string[3] { "settings/rotation_off", "settings/rotation_snap", "settings/rotation_smooth" };
			case "ItemHoldType":
				return new string[2] { "settings/item_hold", "settings/item_toggle" };
			case "SeatedPlayAreaType":
				return new string[2] { "settings/roomscale", "settings/seated" };
			case "SmoothLocomotion":
				return new string[2] { "settings/locomotion_teleport", "settings/locomotion_smooth" };
			case "UseControllerDirection":
				return new string[2] { "settings/forward_direction_headset", "settings/forward_direction_controller" };
			case "SnapRotationAngle":
				return RotatePlayer.SNAP_VALUES.Select((float f) => f.ToString()).ToArray();
			case "VRTeleportOrientation":
				return new string[4] { "settings/teleport_orientation_off", "settings/teleport_orientation_player", "settings/teleport_orientation_play_area", "settings/teleport_orientation_play_area_reposition" };
			case "XrGameViewDisplayMode":
				return new string[4] { "settings/xr_game_view_display_mode_none", "settings/xr_game_view_display_mode_left_eye", "settings/xr_game_view_display_mode_right_eye", "settings/xr_game_view_display_mode_both_eyes" };
			case "ScrollDownMeansRight":
				return new string[2] { "settings/scroll_up_is_right", "settings/scroll_up_is_left" };
			default:
				Debug.LogError("Unhandled GetLocalizationKeysForSelector for '" + key + "'");
				return new string[0];
			}
		}

		public override T GetLiveReadout<T>(string key)
		{
			Debug.LogError("Unhandled GetLiveReadout for '" + key + "'");
			return default(T);
		}

		private string[] GetSupportedResolutions()
		{
			return SingletonBehaviour<ScreenResolutionOptions>.Instance.SupportedResolutions.Select((Vector2Int r) => $"{r.x}x{r.y}").ToArray();
		}

		public override bool ExportTelemetry(out string path)
		{
			if (SingletonBehaviour<TelemetryCentral>.Instance == null || !SingletonBehaviour<TelemetryCentral>.Instance.enabled || SingletonBehaviour<TelemetryCentral>.Instance.RecorderCount == 0)
			{
				path = "";
				return true;
			}
			string text = "TelemetryExport";
			string text2 = Path.Combine(Application.persistentDataPath, text);
			try
			{
				if (!Directory.Exists(text2))
				{
					Directory.CreateDirectory(text2);
				}
				SingletonBehaviour<TelemetryCentral>.Instance.SaveAll(text + Path.DirectorySeparatorChar);
				path = text2;
				return true;
			}
			catch (Exception ex)
			{
				Debug.LogError("Error exporting telemetry: " + ex.Message);
				Debug.LogException(ex);
				path = "";
				return false;
			}
		}

		public override void ToggleFullscreen()
		{
			Screen.fullScreen = !Screen.fullScreen;
		}

		public override void OpenLocalizationScene()
		{
			SceneSwitcher.SwitchToScene(DVScenes.LocalizationTest);
		}

		public override void CalibrateHeightVR()
		{
			SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TrySetState(CanvasController.ElementType.PauseMenu, on: false);
			SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TrySetState(CanvasController.ElementType.Inventory, on: false);
			VRCalibration.Recalibrate();
		}

		public override void CalibrateInputVR()
		{
			SceneSwitcher.SwitchToScene(DVScenes.VRCalibrationScene);
		}

		public override void OpenTranslationForm()
		{
			Application.OpenURL("https://www.altfuture.gg/jobs/other");
		}

		public override void ApplyLanguageAndRestart(string language)
		{
			ApplyLanguage(language);
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
