using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;

namespace Kamgam.SettingsGenerator
{
	[CreateAssetMenu(fileName = "SettingsProvider", menuName = "SettingsGenerator/SettingsProvider", order = 1)]
	public class SettingsProvider : ScriptableObject
	{
		public static SettingsProvider LastUsedSettingsProvider;

		[SerializeField]
		[Tooltip("The player prefs key under which your settings will be saved.")]
		protected string playerPrefsKey;

		[Tooltip("The default settings asset.\nYou can leave this empty if you define all your settings via script.")]
		[FormerlySerializedAs("Default")]
		public Settings SettingsAsset;

		protected Settings _settings;

		[Tooltip("If turned on then for each change in a setting a save will be SCHEDULED. If for AutoSaveWaitTimeInSec after the last change no further change happens then it will save.")]
		public bool AutoSave = true;

		[Tooltip("Only used if AutoSave is turned on. If for AutoSaveWaitTimeInSec after the last change no further change happens then it will save.")]
		public float AutoSaveWaitTimeInSec = 1f;

		[SerializeField]
		[HideInInspector]
		private bool _hasBeenInitialisedInEditor;

		[NonSerialized]
		private double _awakeTime;

		[NonSerialized]
		protected float _autoSaveTime = -1f;

		public Settings Settings
		{
			get
			{
				LastUsedSettingsProvider = this;
				if (_settings == null)
				{
					if (SettingsAsset == null)
					{
						_settings = ScriptableObject.CreateInstance<Settings>();
					}
					else
					{
						_settings = UnityEngine.Object.Instantiate(SettingsAsset);
					}
					QualityPresets.AddCurrentLevel();
					Settings.Load(playerPrefsKey);
					Settings.OnSettingChanged += onSettingChanged;
				}
				return _settings;
			}
		}

		public bool HasSettings()
		{
			return _settings != null;
		}

		private string getDefaultStorageKey()
		{
			return "Settings." + Regex.Replace(Application.productName, "[^-a-zA-Z0-9_]", "");
		}

		public void OnEnable()
		{
			if (string.IsNullOrEmpty(playerPrefsKey))
			{
				playerPrefsKey = getDefaultStorageKey();
			}
		}

		public void Reset()
		{
			if (Settings != null)
			{
				Settings.Reset();
			}
		}

		public void Reset(params string[] ids)
		{
			Settings.Reset(ids);
		}

		public void ResetGroups(params string[] groups)
		{
			Settings.ResetGroups(groups);
		}

		public void ResetGroup(string group)
		{
			Settings.ResetGroups(group);
		}

		public void Apply(bool changedOnly = true)
		{
			Settings?.Apply(changedOnly);
		}

		public void Load()
		{
			if (_settings == null)
			{
				Settings.RefreshRegisteredResolvers();
				return;
			}
			Settings.PullFromConnections();
			Settings.Load(playerPrefsKey);
		}

		public void ResetToLastSave()
		{
			Settings.Load(playerPrefsKey);
		}

		public void Save()
		{
			Settings?.Save(playerPrefsKey);
		}

		public void Delete()
		{
			if (Settings != null)
			{
				Settings.Delete(playerPrefsKey);
			}
			else
			{
				Settings.DeletePlayerPrefs(playerPrefsKey);
			}
		}

		protected void onSettingChanged(ISetting setting)
		{
			if (AutoSave)
			{
				ScheduleAutoSave(AutoSaveWaitTimeInSec);
			}
		}

		public void ScheduleAutoSave(float autoSaveWaitTimeInSec)
		{
			if (_autoSaveTime < 0f)
			{
				_autoSaveTime = Time.realtimeSinceStartup + autoSaveWaitTimeInSec;
				scheduleAutoSaveAsync();
			}
			else
			{
				_autoSaveTime = Time.realtimeSinceStartup + autoSaveWaitTimeInSec;
			}
		}

		protected async void scheduleAutoSaveAsync()
		{
			for (float num = _autoSaveTime - Time.realtimeSinceStartup; num > 0f; num = _autoSaveTime - Time.realtimeSinceStartup)
			{
				await Task.Delay(Mathf.RoundToInt(num * 1000f) + 50);
			}
			Save();
			_autoSaveTime = -1f;
		}
	}
}
