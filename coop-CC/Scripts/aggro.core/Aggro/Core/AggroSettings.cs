using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Aggro.Core
{
	public static class AggroSettings
	{
		private static List<Dictionary<int, AggroSettingBase>> _settings = new List<Dictionary<int, AggroSettingBase>>();

		private static List<AggroSettingBase> _ordered = new List<AggroSettingBase>();

		private static bool _initialized;

		private static GameObject _settingsObj;

		private static Action _onClosed;

		private static bool _isDirty;

		private static Action _onInputTaken;

		private static Action<GameObject> _onInputReleased;

		public static uint version { get; private set; }

		public static uint globalSaveVersion { get; private set; }

		public static InputMode inputMode { get; private set; }

		public static bool suppressInput { get; private set; }

		public static bool isLocalizing { get; private set; }

		public static bool isInitialized => _initialized;

		public static bool isShowing
		{
			get
			{
				if (_settingsObj == null)
				{
					return false;
				}
				return _settingsObj.activeInHierarchy;
			}
		}

		[RuntimeInitializeOnLoadMethod]
		private static void RuntimeInitialized()
		{
			_settings.Clear();
			_ordered.Clear();
			version = 0u;
			_initialized = false;
			_isDirty = false;
			_onClosed = null;
			isLocalizing = false;
		}

		public static void Initialize(bool localized, Action onInputTaken, Action<GameObject> onInputReleased)
		{
			if (!_initialized)
			{
				if (!GlobalScriptableObject<AggroSettingsObject>.Exists())
				{
					UnityEngine.Debug.LogError("[SETTINGS] AggroSettingsObject does not exist! Can't generate settings!");
					return;
				}
				_initialized = true;
				version = GlobalScriptableObject<AggroSettingsObject>.instance.version;
				_onInputTaken = onInputTaken;
				_onInputReleased = onInputReleased;
				isLocalizing = localized;
			}
		}

		public static bool TryGetSetting<T>(string id, out T setting) where T : AggroSettingBase
		{
			return TryGetSetting<T>(IdToHash(id), out setting);
		}

		public static bool TryGetSetting<T>(int idHash, out T setting) where T : AggroSettingBase
		{
			int index = EntityTypeManager.GetIndex(typeof(T));
			if (index >= _settings.Count)
			{
				setting = null;
				return false;
			}
			Dictionary<int, AggroSettingBase> dictionary = _settings[index];
			if (dictionary == null)
			{
				setting = null;
				return false;
			}
			if (dictionary.TryGetValue(idHash, out var value) && value is T val)
			{
				setting = val;
				return true;
			}
			setting = null;
			return false;
		}

		public static T GetSetting<T>(string id) where T : AggroSettingBase
		{
			TryGetSetting<T>(id, out var setting);
			return setting;
		}

		public static T GetSetting<T>(int idHash) where T : AggroSettingBase
		{
			TryGetSetting<T>(idHash, out var setting);
			return setting;
		}

		public static void AddSetting(string id, string category, string label, AggroSettingBase setting)
		{
			int index = EntityTypeManager.GetIndex(setting.GetType());
			while (_settings.Count <= index)
			{
				_settings.Add(null);
			}
			Dictionary<int, AggroSettingBase> dictionary = _settings[index];
			if (dictionary == null)
			{
				dictionary = new Dictionary<int, AggroSettingBase>();
				_settings[index] = dictionary;
			}
			int num = IdToHash(id);
			if (dictionary.ContainsKey(num))
			{
				throw new ArgumentException("[SETTINGS] Duplicate setting id! (Or hash collision!) " + id);
			}
			setting.InternalInitialize(id, num, category, label, version);
			dictionary[num] = setting;
			_ordered.Add(setting);
			_isDirty = true;
		}

		public static int IdToHash(string id)
		{
			return Hash.Calculate(id);
		}

		public static void GetSettings<T>(string category, List<T> settings) where T : AggroSettingBase
		{
			for (int i = 0; i < _ordered.Count; i++)
			{
				AggroSettingBase aggroSettingBase = _ordered[i];
				if (aggroSettingBase is T item && aggroSettingBase.category == category)
				{
					settings.Add(item);
				}
			}
		}

		public static void GetSettings(string category, List<AggroSettingBase> settings)
		{
			for (int i = 0; i < _ordered.Count; i++)
			{
				AggroSettingBase aggroSettingBase = _ordered[i];
				if (aggroSettingBase.category == category)
				{
					settings.Add(aggroSettingBase);
				}
			}
		}

		public static void ResetAllToDefault()
		{
			for (int i = 0; i < _ordered.Count; i++)
			{
				_ordered[i].SetToDefault();
			}
			SaveAll();
			RefreshSettingUIs();
		}

		public static void RefreshSettingUIs()
		{
			if (_settingsObj != null)
			{
				_settingsObj.GetComponent<AggroSettingsManagerUI>().RefreshSettingUIs();
			}
		}

		public static void SaveAll()
		{
			globalSaveVersion++;
			for (int i = 0; i < _ordered.Count; i++)
			{
				_ordered[i].Save();
			}
			PlayerPrefs.Save();
		}

		public static void LoadAll()
		{
			for (int i = 0; i < _ordered.Count; i++)
			{
				_ordered[i].Load();
			}
		}

		public static void ClearSettings()
		{
			_settings.Clear();
			_ordered.Clear();
		}

		public static void IncrementSaveVersion()
		{
			globalSaveVersion++;
		}

		public static void ShowSettings(string category, Transform parent, InputMode mode)
		{
			inputMode = mode;
			if (_isDirty)
			{
				_isDirty = false;
				if (_settingsObj != null)
				{
					UnityEngine.Object.Destroy(_settingsObj);
					_settingsObj = null;
				}
			}
			if (_settingsObj == null)
			{
				CreateUI(parent);
			}
			_settingsObj.SetActive(value: true);
			_settingsObj.GetComponent<AggroSettingsManagerUI>().Show(mode, category);
		}

		public static void CreateUI(Transform parent)
		{
			_isDirty = false;
			if (_settingsObj != null)
			{
				UnityEngine.Object.Destroy(_settingsObj);
			}
			if (GlobalScriptableObject<AggroSettingsObject>.instance.optionsPrefab == null)
			{
				UnityEngine.Debug.LogError("[SETTINGS] Options prefab in AggroSettingsObject is null!", GlobalScriptableObject<AggroSettingsObject>.instance);
				return;
			}
			_settingsObj = UnityEngine.Object.Instantiate(GlobalScriptableObject<AggroSettingsObject>.instance.optionsPrefab, parent);
			_settingsObj.transform.ResetAll();
			_settingsObj.GetComponent<AggroSettingsManagerUI>().Initialize(_ordered.FindAll((AggroSettingBase s) => s.userEditable).ToArray());
		}

		public static void CloseSettings()
		{
			suppressInput = false;
			if (_settingsObj == null)
			{
				return;
			}
			SaveAll();
			if (_settingsObj.activeSelf)
			{
				_settingsObj.GetComponent<AggroSettingsManagerUI>().Closing();
				_settingsObj.SetActive(value: false);
				if (_onClosed != null)
				{
					_onClosed();
				}
			}
		}

		public static void RefreshSettings(string category)
		{
			_isDirty = true;
			if (_settingsObj != null && _settingsObj.activeSelf)
			{
				Transform parent = _settingsObj.transform.parent;
				ShowSettings(category, parent, inputMode);
			}
		}

		public static void RefreshCurrentCategory()
		{
			if (_settingsObj != null && _settingsObj.activeSelf)
			{
				_settingsObj.GetComponent<AggroSettingsManagerUI>().Refresh();
			}
		}

		public static void SetSettingsDirty()
		{
			_isDirty = true;
		}

		public static void SetOnClosedCallback(Action onClosed)
		{
			_onClosed = onClosed;
		}

		public static void ClearOnClosedCallback()
		{
			_onClosed = null;
		}

		public static void SetInputMode(InputMode mode)
		{
			inputMode = mode;
			if (_settingsObj != null)
			{
				_settingsObj.GetComponent<AggroSettingsManagerUI>().SetInputMode(inputMode);
			}
		}

		public static bool GetBool(string id)
		{
			return GetBool(IdToHash(id));
		}

		public static bool GetBool(int idHash)
		{
			return GetSetting<ToggleSetting>(idHash).value;
		}

		public static float GetFloat(string id)
		{
			return GetFloat(IdToHash(id));
		}

		public static float GetFloat(int idHash)
		{
			return GetSetting<FloatSetting>(idHash).value;
		}

		public static int GetIndex(string id)
		{
			return GetIndex(IdToHash(id));
		}

		public static int GetIndex(int idHash)
		{
			return GetSetting<DropdownSetting>(idHash).index;
		}

		public static uint GetSaveVersion<T>(string id) where T : AggroSettingBase
		{
			return GetSaveVersion<T>(IdToHash(id));
		}

		public static uint GetSaveVersion<T>(int idHash) where T : AggroSettingBase
		{
			return GetSetting<T>(idHash).saveVersion;
		}

		public static bool HasSetting<T>(string id) where T : AggroSettingBase
		{
			return HasSetting<T>(IdToHash(id));
		}

		public static bool HasSetting<T>(int idHash) where T : AggroSettingBase
		{
			T setting;
			return TryGetSetting<T>(idHash, out setting);
		}

		public static void TakeInputControl()
		{
			suppressInput = true;
			if (_onInputTaken != null)
			{
				_onInputTaken();
			}
		}

		public static void ReleaseInputControl(GameObject selected)
		{
			suppressInput = false;
			if (_onInputReleased != null)
			{
				_onInputReleased(selected);
			}
		}

		[Conditional("UNITY_EDITOR")]
		[Conditional("DEVELOPMENT_BUILD")]
		private static void VerifyIsInitialized()
		{
			if (!_initialized)
			{
				throw new InvalidOperationException("[SETTINGS] Settings aren't initialized!");
			}
		}

		[Conditional("UNITY_EDITOR")]
		[Conditional("DEVELOPMENT_BUILD")]
		private static void VerifyIsNotEmpty(string str, string context)
		{
			if (string.IsNullOrWhiteSpace(str))
			{
				throw new ArgumentException("[SETTINGS] " + context + " cannot be null or empty!");
			}
		}

		[Conditional("UNITY_EDITOR")]
		[Conditional("DEVELOPMENT_BUILD")]
		private static void VerifyNotZero(int id, string context)
		{
			if (id == 0)
			{
				throw new ArgumentException("[SETTINGS] " + context + " cannot be zero!");
			}
		}

		[Conditional("UNITY_EDITOR")]
		[Conditional("DEVELOPMENT_BUILD")]
		private static void VerifyIsNotNull(object o, string context)
		{
			if (o == null)
			{
				throw new ArgumentNullException("[SETTINGS] " + context + " cannot be null!");
			}
		}

		[Conditional("UNITY_EDITOR")]
		[Conditional("DEVELOPMENT_BUILD")]
		private static void VerifyUnityObjIsNotNull(UnityEngine.Object o, string context)
		{
			if (o == null)
			{
				throw new ArgumentNullException("[SETTINGS] " + context + " cannot be null (or destroyed)!");
			}
		}
	}
}
