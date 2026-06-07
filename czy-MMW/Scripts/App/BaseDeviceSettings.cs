using System;
using System.Collections.Generic;

public class BaseDeviceSettings : ForwardCompatibleJsonSaveData, IDeviceSettings, IJsonSerializableSaveData, IStorable
{
	public enum DeviceSettingsSerializationVersion
	{
		InitialVersion = 0,
		DummyVersionFixup = 1,
		AddedSiriRemote = 2,
		Count = 3
	}

	private int _version = LatestVersion;

	private DateTime _lastPlayedUtcTimestamp = DateTime.MinValue;

	private LocaleDatabase.LocaleId _lastLocaleId;

	private bool _syncToCloud = true;

	private readonly Dictionary<string, Dictionary<string, string>> _controllerDeviceNameToMappings = new Dictionary<string, Dictionary<string, string>>();

	private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("BaseDeviceSettings");

	private const string VersionKey = "_version";

	private const string LastPlayedUtcTimestampKey = "LastPlayedUtcTimestamp";

	private const string LocaleKey = "LastLocaleId";

	private const string CloudKey = "SyncToCloud";

	private const string ControllerMappingsKey = "_controllerDeviceNameToMappings";

	public Player Player { get; set; }

	public DateTime LastPlayedUtcTime
	{
		get
		{
			return _lastPlayedUtcTimestamp;
		}
		set
		{
			if (value > _lastPlayedUtcTimestamp)
			{
				_lastPlayedUtcTimestamp = value;
				OnValueChanged();
			}
		}
	}

	public LocaleDatabase.LocaleId LastLocaleId
	{
		get
		{
			return _lastLocaleId;
		}
		set
		{
			if (_lastLocaleId != value)
			{
				_lastLocaleId = value;
				OnValueChanged();
			}
		}
	}

	public bool SyncToCloud
	{
		get
		{
			return _syncToCloud;
		}
		set
		{
			if (_syncToCloud != value)
			{
				_syncToCloud = value;
				OnValueChanged();
			}
		}
	}

	private static int LatestVersion => 2;

	protected override void LoadFromJson(JSON.Dictionary asJson)
	{
		_version = asJson.GetInt("_version");
		if (_version == 1)
		{
			_version = 0;
		}
		_lastLocaleId = LocaleDatabase.LocaleId.Unknown;
		string text = asJson.GetString("LastLocaleId");
		Diagnostics.Verify(Enum.TryParse<LocaleDatabase.LocaleId>(text, out _lastLocaleId), "Failed to parse the last locale from the device settings. Found the string '{0}'.", text);
		_lastPlayedUtcTimestamp = asJson.GetDateTime("LastPlayedUtcTimestamp");
		_syncToCloud = asJson.GetBool("SyncToCloud");
		JSON.Dictionary dictionary = asJson.GetDictionary("_controllerDeviceNameToMappings");
		if (_version < 2)
		{
			dictionary = null;
		}
		if (dictionary == null)
		{
			return;
		}
		foreach (string key in dictionary.Keys)
		{
			JSON.Dictionary dictionary2 = dictionary.GetDictionary(key);
			Dictionary<string, string> dictionary3 = new Dictionary<string, string>();
			if (dictionary2 != null)
			{
				foreach (string key2 in dictionary2.Keys)
				{
					dictionary3.Add(key2, dictionary2.GetString(key2));
				}
			}
			_controllerDeviceNameToMappings.Add(key, dictionary3);
		}
	}

	protected override void SaveToJson(Dictionary<string, object> jsonDictionary)
	{
		jsonDictionary["_version"] = _version;
		jsonDictionary["LastPlayedUtcTimestamp"] = _lastPlayedUtcTimestamp;
		jsonDictionary["LastLocaleId"] = _lastLocaleId.ToString();
		jsonDictionary["SyncToCloud"] = _syncToCloud;
		jsonDictionary["_controllerDeviceNameToMappings"] = _controllerDeviceNameToMappings;
	}

	protected override void MergeValues(ForwardCompatibleJsonSaveData otherSaveData)
	{
		if (otherSaveData is BaseDeviceSettings baseDeviceSettings)
		{
			LastPlayedUtcTime = ChooseMax(_lastPlayedUtcTimestamp, baseDeviceSettings._lastPlayedUtcTimestamp);
			SyncToCloud = ChooseLatest(_syncToCloud, baseDeviceSettings._syncToCloud, baseDeviceSettings.UtcTimestamp);
			LastLocaleId = ChooseLatest(_lastLocaleId, baseDeviceSettings.LastLocaleId, baseDeviceSettings.UtcTimestamp);
		}
	}

	public Dictionary<string, string> GetDeviceControlMapping(string deviceName)
	{
		if (_controllerDeviceNameToMappings.ContainsKey(deviceName))
		{
			return _controllerDeviceNameToMappings[deviceName];
		}
		return null;
	}

	public void SetDeviceControlMappings(string deviceName, Dictionary<string, string> deviceControlMappings)
	{
		if (_controllerDeviceNameToMappings.ContainsKey(deviceName))
		{
			bool flag = deviceControlMappings.Count != _controllerDeviceNameToMappings[deviceName].Count;
			if (!flag)
			{
				foreach (KeyValuePair<string, string> item in _controllerDeviceNameToMappings[deviceName])
				{
					if (!deviceControlMappings.ContainsKey(item.Key) || deviceControlMappings[item.Key] != item.Value)
					{
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				_controllerDeviceNameToMappings[deviceName] = deviceControlMappings;
				OnValueChanged();
			}
		}
		else
		{
			_controllerDeviceNameToMappings.Add(deviceName, deviceControlMappings);
			OnValueChanged();
		}
	}
}
