using System;
using System.Collections.Generic;
using System.Linq;
using Kamgam.UGUIComponentsForSettings;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Kamgam.SettingsGenerator
{
	[CreateAssetMenu(fileName = "Settings", menuName = "SettingsGenerator/Settings", order = 2)]
	public class Settings : ScriptableObject, ISerializationCallbackReceiver
	{
		public delegate void CustomStorageMethod(string key, Settings settings);

		protected bool _isLoading;

		protected List<ISetting> _settingsCache = new List<ISetting>();

		[SerializeField]
		protected List<SettingBool> _bools = new List<SettingBool>();

		[SerializeField]
		protected List<SettingOption> _options = new List<SettingOption>();

		[SerializeField]
		protected List<SettingInt> _integers = new List<SettingInt>();

		[SerializeField]
		protected List<SettingFloat> _floats = new List<SettingFloat>();

		[SerializeField]
		protected List<SettingString> _strings = new List<SettingString>();

		[SerializeField]
		protected List<SettingColor> _colors = new List<SettingColor>();

		[SerializeField]
		protected List<SettingColorOption> _colorOptions = new List<SettingColorOption>();

		[SerializeField]
		protected List<SettingKeyCombination> _keyCombinations = new List<SettingKeyCombination>();

		[NonSerialized]
		public static List<string> DeactivateBeforeInit = new List<string>();

		[NonSerialized]
		public static CustomStorageMethod CustomSaveMethod;

		[NonSerialized]
		public static CustomStorageMethod CustomLoadMethod;

		[NonSerialized]
		public static CustomStorageMethod CustomDeleteMethod;

		protected List<ISetting> _tmpSettingsSortedByConnectionOrder;

		protected List<ISetting> _tmpSettingsSortedByName;

		public List<ISettingResolver> RegisteredResolvers = new List<ISettingResolver>();

		public event Action<ISetting> OnSettingChanged;

		public static void AddToDeactivateBeforeInit(params string[] ids)
		{
			if (ids != null)
			{
				for (int i = 0; i < ids.Length; i++)
				{
					DeactivateBeforeInit.Add(ids[i]);
				}
			}
		}

		public void RebuildSettingsCache()
		{
			_settingsCache.Clear();
			foreach (SettingBool @bool in _bools)
			{
				if (@bool != null)
				{
					_settingsCache.Add(@bool);
				}
			}
			foreach (SettingOption option in _options)
			{
				if (option != null)
				{
					_settingsCache.Add(option);
				}
			}
			foreach (SettingInt integer in _integers)
			{
				if (integer != null)
				{
					_settingsCache.Add(integer);
				}
			}
			foreach (SettingFloat @float in _floats)
			{
				if (@float != null)
				{
					_settingsCache.Add(@float);
				}
			}
			foreach (SettingString @string in _strings)
			{
				if (@string != null)
				{
					_settingsCache.Add(@string);
				}
			}
			foreach (SettingColor color in _colors)
			{
				if (color != null)
				{
					_settingsCache.Add(color);
				}
			}
			foreach (SettingColorOption colorOption in _colorOptions)
			{
				if (colorOption != null)
				{
					_settingsCache.Add(colorOption);
				}
			}
			foreach (SettingKeyCombination keyCombination in _keyCombinations)
			{
				if (keyCombination != null)
				{
					_settingsCache.Add(keyCombination);
				}
			}
			foreach (ISetting item in _settingsCache)
			{
				item.OnSettingChanged -= onSettingChanged;
				item.OnSettingChanged += onSettingChanged;
			}
		}

		public List<ISetting> GetAllSettings()
		{
			return _settingsCache;
		}

		protected void onSettingChanged(ISetting setting)
		{
			if (!_isLoading && setting.IsActive)
			{
				this.OnSettingChanged?.Invoke(setting);
			}
		}

		public void RemoveSetting(ISetting setting)
		{
			RemoveSetting(setting.GetID());
		}

		public void RemoveSetting(string id)
		{
			removeSetting(_bools, id);
			removeSetting(_options, id);
			removeSetting(_integers, id);
			removeSetting(_floats, id);
			removeSetting(_strings, id);
			removeSetting(_colors, id);
			removeSetting(_colorOptions, id);
			removeSetting(_keyCombinations, id);
			removeSetting(_settingsCache, id);
		}

		protected void removeSetting<T>(List<T> list, string id) where T : ISetting
		{
			for (int num = list.Count - 1; num >= 0; num--)
			{
				if (list[num].MatchesID(id))
				{
					list.RemoveAt(num);
					break;
				}
			}
		}

		public void OnBeforeSerialize()
		{
			RebuildSettingsCache();
			foreach (ISetting item in _settingsCache)
			{
				item.OnBeforeSerialize();
			}
		}

		public void OnAfterDeserialize()
		{
			RebuildSettingsCache();
			foreach (ISetting item in _settingsCache)
			{
				item.OnAfterDeserialize();
			}
		}

		[Obsolete("LoadFromPlayerPrefs(string playerPrefsKey) is deprecated, please use Load(string key) instead.")]
		public void LoadFromPlayerPrefs(string playerPrefsKey)
		{
			Load(playerPrefsKey);
		}

		public void Load(string key)
		{
			_isLoading = true;
			if (CustomLoadMethod != null)
			{
				CustomLoadMethod(key, this);
			}
			else
			{
				string text = PlayerPrefs.GetString(key, null);
				if (!string.IsNullOrEmpty(text))
				{
					SettingsSerializer.FromJson(text, this);
				}
			}
			postLoad();
			_isLoading = false;
		}

		protected void postLoad()
		{
			deactivateBeforeInitialization();
			RebuildSettingsCache();
			foreach (ISetting item in _settingsCache)
			{
				if (item.IsActive)
				{
					if (item.HasConnection() && item.GetConnectionInterface() is IConnectionWithSettingsAccess connectionWithSettingsAccess)
					{
						connectionWithSettingsAccess.SetSettings(this);
					}
					item.InitializeConnection();
					if (!item.HasConnection() && !item.HasUserData())
					{
						item.ResetToDefault();
					}
				}
			}
			foreach (ISetting item2 in _settingsCache)
			{
				if (item2.IsActive)
				{
					item2.MarkAsChanged();
				}
			}
			Apply();
			RefreshRegisteredResolvers();
		}

		protected void deactivateBeforeInitialization()
		{
			foreach (string item in DeactivateBeforeInit)
			{
				ISetting setting = GetSetting(item);
				if (setting != null)
				{
					setting.IsActive = false;
				}
			}
		}

		[Obsolete("SaveToPlayerPrefs(string playerPrefsKey) is deprecated, please use Save(string key) instead.")]
		public void SaveToPlayerPrefs(string key)
		{
			Save(key);
		}

		public void Save(string playerPrefsKey)
		{
			if (CustomSaveMethod != null)
			{
				CustomSaveMethod(playerPrefsKey, this);
				return;
			}
			string value = SettingsSerializer.ToJson(this);
			if (!string.IsNullOrEmpty(value))
			{
				PlayerPrefs.SetString(playerPrefsKey, value);
				PlayerPrefs.Save();
			}
		}

		[Obsolete("DeleteFromPlayerPrefs(string playerPrefsKey) is deprecated, please use Delete(string key) instead.")]
		public void DeleteFromPlayerPrefs(string key)
		{
			Delete(key);
		}

		public void Delete(string playerPrefsKey)
		{
			if (CustomDeleteMethod != null)
			{
				CustomDeleteMethod(playerPrefsKey, this);
			}
			else
			{
				DeletePlayerPrefs(playerPrefsKey);
			}
		}

		public static void DeletePlayerPrefs(string playerPrefsKey)
		{
			PlayerPrefs.DeleteKey(playerPrefsKey);
			PlayerPrefs.Save();
		}

		public void Apply(bool changedOnly = true)
		{
			List<ISetting> settingsOrderedByConnectionOrderASC = getSettingsOrderedByConnectionOrderASC(_settingsCache);
			if (!changedOnly)
			{
				for (int i = 0; i < settingsOrderedByConnectionOrderASC.Count; i++)
				{
					ISetting setting = settingsOrderedByConnectionOrderASC[i];
					if (setting.IsActive)
					{
						setting.MarkAsChanged();
					}
				}
			}
			for (int j = 0; j < settingsOrderedByConnectionOrderASC.Count; j++)
			{
				ISetting setting = settingsOrderedByConnectionOrderASC[j];
				if (setting.IsActive && (!changedOnly || setting.HasUnappliedChanges()))
				{
					setting.Apply();
				}
			}
		}

		public void PullFromConnection(IConnection connection, bool exceptUnapplied = false, bool propagateChange = false)
		{
			List<ISetting> settingsOrderedByConnectionOrderASC = getSettingsOrderedByConnectionOrderASC(_settingsCache);
			for (int i = 0; i < settingsOrderedByConnectionOrderASC.Count; i++)
			{
				ISetting setting = settingsOrderedByConnectionOrderASC[i];
				if (setting.IsActive && setting.HasConnection() && (!exceptUnapplied || !setting.HasUnappliedChanges()) && setting.GetConnectionInterface() == connection)
				{
					setting.PullFromConnection(propagateChange);
				}
			}
		}

		public void PushToConnection(IConnection connection, bool exceptUnapplied = false)
		{
			List<ISetting> settingsOrderedByConnectionOrderASC = getSettingsOrderedByConnectionOrderASC(_settingsCache);
			for (int i = 0; i < settingsOrderedByConnectionOrderASC.Count; i++)
			{
				ISetting setting = settingsOrderedByConnectionOrderASC[i];
				if (setting.IsActive && setting.HasConnection() && (!exceptUnapplied || !setting.HasUnappliedChanges()) && setting.GetConnectionInterface() == connection)
				{
					setting.PushToConnection();
				}
			}
		}

		public void PullFromConnections(bool exceptUnapplied = false, bool propagateChange = false)
		{
			List<ISetting> settingsOrderedByConnectionOrderASC = getSettingsOrderedByConnectionOrderASC(_settingsCache);
			for (int i = 0; i < settingsOrderedByConnectionOrderASC.Count; i++)
			{
				ISetting setting = settingsOrderedByConnectionOrderASC[i];
				if (setting.IsActive && setting.HasConnection() && (!exceptUnapplied || !setting.HasUnappliedChanges()))
				{
					setting.PullFromConnection(propagateChange);
				}
			}
		}

		public void PullFromQualityConnections(bool exceptUnapplied = false, bool propagateChange = false)
		{
			List<ISetting> settingsOrderedByConnectionOrderASC = getSettingsOrderedByConnectionOrderASC(_settingsCache);
			for (int i = 0; i < settingsOrderedByConnectionOrderASC.Count; i++)
			{
				ISetting setting = settingsOrderedByConnectionOrderASC[i];
				if (setting.IsActive && setting.HasConnection() && (!exceptUnapplied || !setting.HasUnappliedChanges()))
				{
					setting.PullFromConnection(propagateChange);
				}
			}
		}

		public void PushToConnections()
		{
			List<ISetting> settingsOrderedByConnectionOrderASC = getSettingsOrderedByConnectionOrderASC(_settingsCache);
			for (int i = 0; i < settingsOrderedByConnectionOrderASC.Count; i++)
			{
				ISetting setting = settingsOrderedByConnectionOrderASC[i];
				if (setting.IsActive && setting.HasConnection())
				{
					setting.PushToConnection();
				}
			}
		}

		public void PushToConnections(params string[] groups)
		{
			List<ISetting> settingsOrderedByConnectionOrderASC = getSettingsOrderedByConnectionOrderASC(_settingsCache);
			for (int i = 0; i < settingsOrderedByConnectionOrderASC.Count; i++)
			{
				ISetting setting = settingsOrderedByConnectionOrderASC[i];
				if (setting.IsActive && setting.MatchesAnyGroup(groups) && setting.HasConnection())
				{
					setting.PushToConnection();
				}
			}
		}

		protected List<ISetting> getSettingsOrderedByConnectionOrderASC(IEnumerable<ISetting> settings)
		{
			if (_tmpSettingsSortedByConnectionOrder == null)
			{
				_tmpSettingsSortedByConnectionOrder = new List<ISetting>();
			}
			_tmpSettingsSortedByConnectionOrder.Clear();
			foreach (ISetting setting in settings)
			{
				if (setting.IsActive)
				{
					_tmpSettingsSortedByConnectionOrder.Add(setting);
				}
			}
			_tmpSettingsSortedByConnectionOrder.Sort(compartByConnectionOrder);
			return _tmpSettingsSortedByConnectionOrder;
		}

		protected int compartByConnectionOrder(ISetting a, ISetting b)
		{
			return a.GetConnectionOrder() - b.GetConnectionOrder();
		}

		protected List<ISetting> getSettingsOrderedByID(IEnumerable<ISetting> settings)
		{
			if (_tmpSettingsSortedByName == null)
			{
				_tmpSettingsSortedByName = new List<ISetting>();
			}
			_tmpSettingsSortedByName.Clear();
			foreach (ISetting setting in settings)
			{
				_tmpSettingsSortedByName.Add(setting);
			}
			_tmpSettingsSortedByName.Sort(compareByID);
			return _tmpSettingsSortedByName;
		}

		protected int compareByID(ISetting a, ISetting b)
		{
			return string.Compare(a.GetID(), b.GetID());
		}

		public bool HasID(string id)
		{
			return GetSetting(id) != null;
		}

		public bool HasActiveID(string id)
		{
			return GetActiveSetting(id) != null;
		}

		public ISetting GetSetting(string id)
		{
			foreach (ISetting item in _settingsCache)
			{
				if (item.GetID() == id)
				{
					return item;
				}
			}
			return null;
		}

		public ISetting GetActiveSetting(string id)
		{
			ISetting setting = GetSetting(id);
			if (setting != null && setting.IsActive)
			{
				return setting;
			}
			return null;
		}

		protected bool doesOtherSettingExist(string id, SettingData.DataType dataType)
		{
			ISetting setting = GetSetting(id);
			if (setting != null && setting.GetDataType() != dataType)
			{
				Debug.LogError("You are trying to create '" + id + "' (type: '" + dataType.ToString() + "') but another '" + id + "' with a DIFFERENT type ('" + setting.GetDataType().ToString() + "') already exists. Aborting creation. Duplicate IDs are not allowed.");
				return true;
			}
			return false;
		}

		public ISetting GetOrCreate(string id, SettingData.DataType dataType)
		{
			return dataType switch
			{
				SettingData.DataType.Int => GetOrCreateInt(id), 
				SettingData.DataType.Float => GetOrCreateFloat(id), 
				SettingData.DataType.Bool => GetOrCreateBool(id), 
				SettingData.DataType.String => GetOrCreateString(id), 
				SettingData.DataType.Color => GetOrCreateColor(id, Color.black), 
				SettingData.DataType.KeyCombination => GetOrCreateKeyCombination(id, new KeyCombination(UniversalKeyCode.None)), 
				SettingData.DataType.Option => GetOrCreateOption(id), 
				SettingData.DataType.ColorOption => GetOrCreateColorOption(id), 
				_ => null, 
			};
		}

		public SettingBool GetOrCreateBool(string id, bool defaultValue = false, List<string> groups = null, IConnection<bool> connection = null)
		{
			SettingBool settingBool = GetBool(id);
			if (settingBool == null)
			{
				settingBool = addBool(id, defaultValue, groups);
			}
			else if (groups != null)
			{
				settingBool.SetGroups(groups);
			}
			initConnectionForSetting(settingBool, connection);
			return settingBool;
		}

		protected void initConnectionForSetting<T>(ISettingWithConnection<T> setting, IConnection<T> connection)
		{
			if (connection != null)
			{
				if (connection is IConnectionWithSettingsAccess connectionWithSettingsAccess)
				{
					connectionWithSettingsAccess.SetSettings(this);
				}
				setting.SetConnection(connection);
			}
		}

		public SettingBool GetBool(string id)
		{
			foreach (SettingBool @bool in _bools)
			{
				if (@bool.GetID() == id)
				{
					return @bool;
				}
			}
			return null;
		}

		protected SettingBool addBool(string id, bool value, List<string> groups = null)
		{
			if (doesOtherSettingExist(id, SettingData.DataType.Bool))
			{
				return null;
			}
			SettingBool settingBool = new SettingBool(id, value, groups);
			_bools.Add(settingBool);
			RebuildSettingsCache();
			return settingBool;
		}

		public SettingBool AddBoolFromSerializedData(SettingData data, List<string> groups = null)
		{
			if (doesOtherSettingExist(data.ID, SettingData.DataType.Bool))
			{
				return null;
			}
			SettingBool settingBool = new SettingBool(data, groups);
			_bools.Add(settingBool);
			RebuildSettingsCache();
			return settingBool;
		}

		public SettingColor GetOrCreateColor(string id, Color defaultValue, List<string> groups = null, IConnection<Color> connection = null)
		{
			SettingColor settingColor = GetColor(id);
			if (settingColor == null)
			{
				settingColor = addColor(id, defaultValue, groups);
			}
			else if (groups != null)
			{
				settingColor.SetGroups(groups);
			}
			initConnectionForSetting(settingColor, connection);
			return settingColor;
		}

		public SettingColor GetColor(string id)
		{
			foreach (SettingColor color in _colors)
			{
				if (color.GetID() == id)
				{
					return color;
				}
			}
			return null;
		}

		protected SettingColor addColor(string id, Color value, List<string> groups = null)
		{
			if (doesOtherSettingExist(id, SettingData.DataType.Color))
			{
				return null;
			}
			SettingColor settingColor = new SettingColor(id, value, groups);
			_colors.Add(settingColor);
			RebuildSettingsCache();
			return settingColor;
		}

		public SettingColor AddColorFromSerializedData(SettingData data, List<string> groups = null)
		{
			if (doesOtherSettingExist(data.ID, SettingData.DataType.Color))
			{
				return null;
			}
			SettingColor settingColor = new SettingColor(data, groups);
			_colors.Add(settingColor);
			RebuildSettingsCache();
			return settingColor;
		}

		public SettingColorOption GetOrCreateColorOption(string id, int defaultOption = 0, List<string> groups = null, List<Color> options = null, IConnectionWithOptions<Color> connection = null)
		{
			SettingColorOption settingColorOption = GetColorOption(id);
			if (settingColorOption == null)
			{
				settingColorOption = addColorOption(id, defaultOption, groups, options);
			}
			else
			{
				if (groups != null && groups.Count > 0)
				{
					settingColorOption.SetGroups(groups);
				}
				if (options != null && options.Count > 0)
				{
					settingColorOption.SetOptionLabels(options);
					RefreshRegisteredResolvers(id);
				}
			}
			initConnectionForSetting(settingColorOption, connection);
			return settingColorOption;
		}

		public SettingColorOption GetColorOption(string id)
		{
			foreach (SettingColorOption colorOption in _colorOptions)
			{
				if (colorOption.GetID() == id)
				{
					return colorOption;
				}
			}
			return null;
		}

		protected SettingColorOption addColorOption(string id, int selectedIndex, List<string> groups = null, List<Color> options = null)
		{
			if (doesOtherSettingExist(id, SettingData.DataType.ColorOption))
			{
				return null;
			}
			SettingColorOption settingColorOption = new SettingColorOption(id, selectedIndex, groups, options);
			_colorOptions.Add(settingColorOption);
			RebuildSettingsCache();
			return settingColorOption;
		}

		public SettingColorOption AddColorOptionFromSerializedData(SettingData data, List<string> groups = null, List<Color> options = null)
		{
			if (doesOtherSettingExist(data.ID, SettingData.DataType.ColorOption))
			{
				return null;
			}
			SettingColorOption settingColorOption = new SettingColorOption(data, groups, options);
			_colorOptions.Add(settingColorOption);
			RebuildSettingsCache();
			return settingColorOption;
		}

		public SettingFloat GetOrCreateFloat(string id, float defaultValue = 0f, List<string> groups = null, IConnection<float> connection = null)
		{
			SettingFloat settingFloat = GetFloat(id);
			if (settingFloat == null)
			{
				settingFloat = addFloat(id, defaultValue, groups);
			}
			else if (groups != null)
			{
				settingFloat.SetGroups(groups);
			}
			initConnectionForSetting(settingFloat, connection);
			return settingFloat;
		}

		public SettingFloat GetFloat(string id)
		{
			foreach (SettingFloat @float in _floats)
			{
				if (@float.GetID() == id)
				{
					return @float;
				}
			}
			return null;
		}

		protected SettingFloat addFloat(string id, float value, List<string> groups = null)
		{
			if (doesOtherSettingExist(id, SettingData.DataType.Float))
			{
				return null;
			}
			SettingFloat settingFloat = new SettingFloat(id, value, groups);
			_floats.Add(settingFloat);
			RebuildSettingsCache();
			return settingFloat;
		}

		public SettingFloat AddFloatFromSerializedData(SettingData data, List<string> groups = null)
		{
			if (doesOtherSettingExist(data.ID, SettingData.DataType.Float))
			{
				return null;
			}
			SettingFloat settingFloat = new SettingFloat(data, groups);
			_floats.Add(settingFloat);
			RebuildSettingsCache();
			return settingFloat;
		}

		public SettingInt GetOrCreateInt(string id, int defaultValue = 0, List<string> groups = null, IConnection<int> connection = null)
		{
			SettingInt settingInt = GetInt(id);
			if (settingInt == null)
			{
				settingInt = addInt(id, defaultValue, groups);
			}
			else if (groups != null)
			{
				settingInt.SetGroups(groups);
			}
			initConnectionForSetting(settingInt, connection);
			return settingInt;
		}

		public SettingInt GetInt(string id)
		{
			foreach (SettingInt integer in _integers)
			{
				if (integer.GetID() == id)
				{
					return integer;
				}
			}
			return null;
		}

		protected SettingInt addInt(string id, int value, List<string> groups = null)
		{
			if (doesOtherSettingExist(id, SettingData.DataType.Int))
			{
				return null;
			}
			SettingInt settingInt = new SettingInt(id, value, groups);
			_integers.Add(settingInt);
			RebuildSettingsCache();
			return settingInt;
		}

		public SettingInt AddIntFromSerializedData(SettingData data, List<string> groups = null)
		{
			if (doesOtherSettingExist(data.ID, SettingData.DataType.Int))
			{
				return null;
			}
			SettingInt settingInt = new SettingInt(data, groups);
			_integers.Add(settingInt);
			RebuildSettingsCache();
			return settingInt;
		}

		public SettingKeyCombination GetOrCreateKeyCombination(string id, KeyCombination defaultValue, List<string> groups = null, IConnection<KeyCombination> connection = null)
		{
			SettingKeyCombination settingKeyCombination = GetKeyCombination(id);
			if (settingKeyCombination == null)
			{
				settingKeyCombination = addKeyCombination(id, defaultValue, groups);
			}
			else if (groups != null)
			{
				settingKeyCombination.SetGroups(groups);
			}
			initConnectionForSetting(settingKeyCombination, connection);
			return settingKeyCombination;
		}

		protected SettingKeyCombination addKeyCombination(string id, KeyCombination value, List<string> groups = null)
		{
			if (doesOtherSettingExist(id, SettingData.DataType.KeyCombination))
			{
				return null;
			}
			SettingKeyCombination settingKeyCombination = new SettingKeyCombination(id, value, groups);
			_keyCombinations.Add(settingKeyCombination);
			RebuildSettingsCache();
			return settingKeyCombination;
		}

		public SettingKeyCombination AddKeyCombinationFromSerializedData(SettingData data, List<string> groups = null)
		{
			if (doesOtherSettingExist(data.ID, SettingData.DataType.KeyCombination))
			{
				return null;
			}
			SettingKeyCombination settingKeyCombination = new SettingKeyCombination(data, groups);
			_keyCombinations.Add(settingKeyCombination);
			RebuildSettingsCache();
			return settingKeyCombination;
		}

		public SettingKeyCombination GetKeyCombination(string id)
		{
			foreach (SettingKeyCombination keyCombination in _keyCombinations)
			{
				if (keyCombination.GetID() == id)
				{
					return keyCombination;
				}
			}
			return null;
		}

		public SettingOption GetOrCreateOption(string id, int defaultOption = 0, List<string> groups = null, List<string> options = null, IConnectionWithOptions<string> connection = null)
		{
			SettingOption settingOption = GetOption(id);
			if (settingOption == null)
			{
				settingOption = addOption(id, defaultOption, groups, options);
			}
			else
			{
				if (groups != null && groups.Count > 0)
				{
					settingOption.SetGroups(groups);
				}
				if (options != null && options.Count > 0)
				{
					settingOption.SetOptionLabels(options);
					RefreshRegisteredResolvers(id);
				}
			}
			initConnectionForSetting(settingOption, connection);
			return settingOption;
		}

		public SettingOption GetOption(string id)
		{
			foreach (SettingOption option in _options)
			{
				if (option.GetID() == id)
				{
					return option;
				}
			}
			return null;
		}

		protected SettingOption addOption(string id, int selectedIndex, List<string> groups = null, List<string> options = null)
		{
			if (doesOtherSettingExist(id, SettingData.DataType.Option))
			{
				return null;
			}
			SettingOption settingOption = new SettingOption(id, selectedIndex, groups, options);
			_options.Add(settingOption);
			RebuildSettingsCache();
			return settingOption;
		}

		public SettingOption AddOptionFromSerializedData(SettingData data, List<string> groups = null, List<string> options = null)
		{
			if (doesOtherSettingExist(data.ID, SettingData.DataType.Option))
			{
				return null;
			}
			SettingOption settingOption = new SettingOption(data, groups, options);
			_options.Add(settingOption);
			RebuildSettingsCache();
			return settingOption;
		}

		public SettingString GetOrCreateString(string id, string defaultValue = "", List<string> groups = null, IConnection<string> connection = null)
		{
			SettingString settingString = GetString(id);
			if (settingString == null)
			{
				settingString = addString(id, defaultValue, groups);
			}
			else if (groups != null)
			{
				settingString.SetGroups(groups);
			}
			initConnectionForSetting(settingString, connection);
			return settingString;
		}

		public SettingString GetString(string id)
		{
			foreach (SettingString @string in _strings)
			{
				if (@string.GetID() == id)
				{
					return @string;
				}
			}
			return null;
		}

		protected SettingString addString(string id, string value, List<string> groups = null)
		{
			if (doesOtherSettingExist(id, SettingData.DataType.String))
			{
				return null;
			}
			SettingString settingString = new SettingString(id, value, groups);
			_strings.Add(settingString);
			RebuildSettingsCache();
			return settingString;
		}

		public SettingString AddStringFromSerializedData(SettingData data, List<string> groups = null)
		{
			if (doesOtherSettingExist(data.ID, SettingData.DataType.String))
			{
				return null;
			}
			SettingString settingString = new SettingString(data, groups);
			_strings.Add(settingString);
			RebuildSettingsCache();
			return settingString;
		}

		public object GetValue(string id)
		{
			return GetSetting(id)?.GetValueAsObject();
		}

		public T GetValue<T>(string id)
		{
			object value = GetValue(id);
			if (value != null)
			{
				if (value is T)
				{
					return (T)value;
				}
				Debug.LogError("SGSettings: The value for id '" + id + "' could not be read because of a type mismatch.\nThe type you requested (" + typeof(T).Name.Replace("Single", "Float") + ") does not match the '" + id + "' field in Settings (" + value.GetType().Name.Replace("Single", "Float") + ").\nYou may also get an ArgumentException if you try to set this value.");
				return default(T);
			}
			return default(T);
		}

		public void SetValue(string id, object value)
		{
			GetSetting(id)?.SetValueFromObject(value);
		}

		public void SetActive(string id, bool active)
		{
			ISetting setting = GetSetting(id);
			if (setting != null)
			{
				setting.IsActive = active;
			}
		}

		public void SetAllActive(bool active)
		{
			foreach (ISetting item in _settingsCache)
			{
				item.IsActive = active;
			}
		}

		public void OnQualityChanged(int qualityLevel, bool excludeChanged = false)
		{
			List<ISetting> settingsOrderedByConnectionOrderASC = getSettingsOrderedByConnectionOrderASC(_settingsCache);
			for (int i = 0; i < settingsOrderedByConnectionOrderASC.Count; i++)
			{
				ISetting setting = settingsOrderedByConnectionOrderASC[i];
				if (setting.IsActive && (!excludeChanged || !setting.HasUnappliedChanges()))
				{
					setting.OnQualityChanged(qualityLevel);
				}
			}
		}

		public string[] GetSettingIDsOrderedByName(bool filterByDataType = false, params SettingData.DataType[] dataTypes)
		{
			return (from s in getSettingsOrderedByID(_settingsCache)
				where !filterByDataType || dataTypes.Contains(s.GetDataType())
				select s.GetID()).ToArray();
		}

		public IList<TSetting> GetSettingsWithConnectionByType<TSetting, TConnection>(IList<TSetting> results = null) where TSetting : class, ISetting where TConnection : class, IConnection
		{
			if (results == null)
			{
				results = new List<TSetting>();
			}
			else
			{
				results.Clear();
			}
			foreach (ISetting item in _settingsCache)
			{
				if (item is TSetting val && val.GetConnectionInterface() as TConnection != null)
				{
					results.Add(val);
				}
			}
			return results;
		}

		public IList<TSetting> GetSettingsWithConnection<TSetting>(IConnection connection, IList<TSetting> results = null) where TSetting : class, ISetting
		{
			if (results == null)
			{
				results = new List<TSetting>();
			}
			else
			{
				results.Clear();
			}
			foreach (ISetting item in _settingsCache)
			{
				if (item is TSetting val && val.GetConnectionInterface() == connection)
				{
					results.Add(val);
				}
			}
			return results;
		}

		public IList<ISetting> GetSettingsWithConnection(IConnection connection, IList<ISetting> results = null)
		{
			if (results == null)
			{
				results = new List<ISetting>();
			}
			else
			{
				results.Clear();
			}
			foreach (ISetting item in _settingsCache)
			{
				if (item.GetConnectionInterface() == connection)
				{
					results.Add(item);
				}
			}
			return results;
		}

		public ISetting GetFirstSettingWithConnectionSO(ConnectionSO connectionSO)
		{
			foreach (ISetting item in _settingsCache)
			{
				if (item.GetConnectionSO() == connectionSO)
				{
					return item;
				}
			}
			return null;
		}

		public void SetInputActionAsset(InputActionAsset asset, bool applyImmediately = true)
		{
			foreach (SettingString item in GetSettingsWithConnectionByType<SettingString, InputBindingConnection>())
			{
				if (item.GetConnectionInterface() is InputBindingConnection inputBindingConnection)
				{
					inputBindingConnection.SetInputActionAsset(asset);
					if (applyImmediately)
					{
						item.Apply();
					}
				}
			}
		}

		public InputActionAsset GetInputActionAsset()
		{
			foreach (SettingString item in GetSettingsWithConnectionByType<SettingString, InputBindingConnection>())
			{
				if (item.GetConnectionInterface() is InputBindingConnection inputBindingConnection)
				{
					InputActionAsset inputActionAsset = inputBindingConnection.GetInputActionAsset();
					if (inputActionAsset != null)
					{
						return inputActionAsset;
					}
				}
			}
			return null;
		}

		public void RegisterResolver(ISettingResolver resolver)
		{
			if (resolver != null && HasID(resolver.GetID()))
			{
				RegisteredResolvers.Add(resolver);
				DefragRegisteredResolvers();
			}
		}

		public void UnregisterResolver(ISettingResolver input)
		{
			if (input != null)
			{
				RegisteredResolvers.Remove(input);
				DefragRegisteredResolvers();
			}
		}

		public void DefragRegisteredResolvers()
		{
			for (int num = RegisteredResolvers.Count - 1; num >= 0; num--)
			{
				if (RegisteredResolvers[num] == null)
				{
					RegisteredResolvers.RemoveAt(num);
				}
			}
		}

		public void RefreshRegisteredResolvers()
		{
			if (RegisteredResolvers == null || RegisteredResolvers.Count == 0)
			{
				return;
			}
			DefragRegisteredResolvers();
			foreach (ISettingResolver registeredResolver in RegisteredResolvers)
			{
				registeredResolver.Refresh();
			}
		}

		public void RefreshRegisteredResolvers(string id)
		{
			if (RegisteredResolvers == null || RegisteredResolvers.Count == 0)
			{
				return;
			}
			DefragRegisteredResolvers();
			foreach (ISettingResolver registeredResolver in RegisteredResolvers)
			{
				if (registeredResolver.GetID() == id)
				{
					registeredResolver.Refresh();
				}
			}
		}

		public void RefreshRegisteredResolvers(ISetting setting)
		{
			RefreshRegisteredResolvers(setting.GetID());
		}

		public void RefreshRegisteredResolversWithConnection<T>() where T : IConnection
		{
			if (RegisteredResolvers == null || RegisteredResolvers.Count == 0)
			{
				return;
			}
			DefragRegisteredResolvers();
			foreach (ISettingResolver registeredResolver in RegisteredResolvers)
			{
				string iD = registeredResolver.GetID();
				if (!string.IsNullOrEmpty(iD))
				{
					ISetting setting = GetSetting(iD);
					if (setting != null && setting.HasConnection() && setting.GetConnectionInterface() is T)
					{
						registeredResolver.Refresh();
					}
				}
			}
		}

		public void RefreshRegisteredResolversWithConnection(IConnection connection)
		{
			if (RegisteredResolvers == null || RegisteredResolvers.Count == 0)
			{
				return;
			}
			DefragRegisteredResolvers();
			foreach (ISettingResolver registeredResolver in RegisteredResolvers)
			{
				string iD = registeredResolver.GetID();
				if (!string.IsNullOrEmpty(iD))
				{
					ISetting setting = GetSetting(iD);
					if (setting != null && setting.HasConnection() && setting.GetConnectionInterface() == connection)
					{
						registeredResolver.Refresh();
					}
				}
			}
		}

		public void Reset()
		{
			foreach (ISetting item in _settingsCache)
			{
				item.ResetToDefault();
			}
			DefragRegisteredResolvers();
			foreach (ISettingResolver registeredResolver in RegisteredResolvers)
			{
				registeredResolver.Refresh();
			}
		}

		public void Reset(params string[] ids)
		{
			if (ids == null || ids.Length == 0)
			{
				return;
			}
			foreach (ISetting item in _settingsCache)
			{
				if (ids.Contains(item.GetID()))
				{
					item.ResetToDefault();
				}
			}
			DefragRegisteredResolvers();
			foreach (ISettingResolver registeredResolver in RegisteredResolvers)
			{
				registeredResolver.Refresh();
			}
		}

		public void ResetGroups(params string[] groups)
		{
			if (groups == null || groups.Length == 0)
			{
				return;
			}
			foreach (ISetting item in _settingsCache)
			{
				if (item.MatchesAnyGroup(groups))
				{
					item.ResetToDefault();
				}
			}
			DefragRegisteredResolvers();
			foreach (ISettingResolver registeredResolver in RegisteredResolvers)
			{
				registeredResolver.Refresh();
			}
		}
	}
}
