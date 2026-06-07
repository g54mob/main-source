using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Multiplayer.ActivityFramework.Events;
using FishNet.Serializing;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.ActivityFramework
{
	public class NetworkedActivitySettings
	{
		private Dictionary<string, NetworkedActivitySetting> _settings;

		public IReadOnlyCollection<NetworkedActivitySetting> AllSettings => _settings.Values;

		public bool IsDefault => AllSettings.All((NetworkedActivitySetting x) => x.IsDefault);

		public event EventHandler<NetworkedActivitySettingEventArgs> SettingAdded;

		public event EventHandler<NetworkedActivitySettingValueChangedEventArgs<object>> SettingValueChanged;

		public NetworkedActivitySettings()
		{
			_settings = new Dictionary<string, NetworkedActivitySetting>();
		}

		public static NetworkedActivitySettings LoadFromXml(XElement xml)
		{
			NetworkedActivitySettings networkedActivitySettings = new NetworkedActivitySettings();
			networkedActivitySettings.SerializeRead(xml, valuesOnly: false);
			return networkedActivitySettings;
		}

		public NetworkedActivitySetting CreateSetting<TValue>(string id, TValue value)
		{
			if (_settings.ContainsKey(id))
			{
				throw new InvalidOperationException("Setting with id '" + id + "' already exists");
			}
			NetworkedActivitySetting networkedActivitySetting = NetworkedActivitySetting.CreateNew(id, value);
			_settings[id] = networkedActivitySetting;
			networkedActivitySetting.ValueChanged += OnValueChanged;
			this.SettingAdded?.Invoke(this, new NetworkedActivitySettingEventArgs(networkedActivitySetting));
			return networkedActivitySetting;
		}

		public NetworkedActivitySetting GetOrCreateSetting<TValue>(string id)
		{
			return GetSetting(id) ?? CreateSetting(id, default(TValue));
		}

		public NetworkedActivitySetting GetSetting(string id)
		{
			if (!_settings.TryGetValue(id, out var value))
			{
				return null;
			}
			return value;
		}

		public bool GetValueBool(string id, bool defaultValue = false)
		{
			return GetSetting(id)?.ValueBool ?? defaultValue;
		}

		public float GetValueFloat(string id, float defaultValue = 0f)
		{
			return GetSetting(id)?.ValueFloat ?? defaultValue;
		}

		public int GetValueInt(string id, int defaultValue = 0)
		{
			return GetSetting(id)?.ValueInt ?? defaultValue;
		}

		public string GetValueString(string id, string defaultValue = null)
		{
			return GetSetting(id)?.ValueString ?? defaultValue;
		}

		public void RestoreDefaultValues()
		{
			foreach (NetworkedActivitySetting allSetting in AllSettings)
			{
				allSetting.RestoreDefaultValue();
			}
		}

		public void SerializeRead(Reader reader, bool valuesOnly)
		{
			int num = reader.ReadInt32();
			for (int i = 0; i < num; i++)
			{
				if (valuesOnly)
				{
					string text = reader.ReadStringAllocated();
					NetworkedActivitySetting setting = GetSetting(text);
					if (setting == null)
					{
						Debug.LogError("Unable to find setting '" + text + "' when reading network serialized values.");
					}
					else
					{
						setting.SerializeRead(reader, valuesOnly);
					}
					continue;
				}
				NetworkedActivitySetting networkedActivitySetting = NetworkedActivitySetting.LoadFromNetwork(reader);
				if (_settings.ContainsKey(networkedActivitySetting.Id))
				{
					Debug.LogError("Unable to read setting '" + networkedActivitySetting.Id + "' from the networked serialized data because a setting with that id already exists.");
					continue;
				}
				_settings.Add(networkedActivitySetting.Id, networkedActivitySetting);
				networkedActivitySetting.ValueChanged += OnValueChanged;
				this.SettingAdded?.Invoke(this, new NetworkedActivitySettingEventArgs(networkedActivitySetting));
			}
		}

		public void SerializeRead(XElement xml, bool valuesOnly)
		{
			if (xml == null)
			{
				return;
			}
			foreach (XElement item in xml.Elements("Setting"))
			{
				if (valuesOnly)
				{
					string stringAttribute = item.GetStringAttribute("id");
					GetSetting(stringAttribute)?.SerializeRead(xml, valuesOnly);
					continue;
				}
				NetworkedActivitySetting networkedActivitySetting = NetworkedActivitySetting.LoadFromXml(item);
				if (_settings.ContainsKey(networkedActivitySetting.Id))
				{
					Debug.LogError("Unable to read setting '" + networkedActivitySetting.Id + "' from the XML serialized data because a setting with that id already exists.");
					continue;
				}
				_settings.Add(networkedActivitySetting.Id, networkedActivitySetting);
				networkedActivitySetting.ValueChanged += OnValueChanged;
				this.SettingAdded?.Invoke(this, new NetworkedActivitySettingEventArgs(networkedActivitySetting));
			}
		}

		public void SerializeWrite(Writer writer, bool valuesOnly, IReadOnlyCollection<NetworkedActivitySetting> settings = null)
		{
			if (settings == null)
			{
				settings = AllSettings;
			}
			writer.Write(settings.Count);
			foreach (NetworkedActivitySetting setting in settings)
			{
				if (valuesOnly)
				{
					writer.Write(setting.Id);
				}
				setting.SerializeWrite(writer, valuesOnly);
			}
		}

		public void SerializeWrite(XElement xml, bool valuesOnly, IReadOnlyCollection<NetworkedActivitySetting> settings = null)
		{
			if (settings == null)
			{
				settings = AllSettings;
			}
			foreach (NetworkedActivitySetting setting in settings)
			{
				XElement xElement = new XElement("Setting");
				if (valuesOnly)
				{
					xElement.SetAttributeValue("id", setting.Id);
				}
				setting.SerializeWrite(xElement, valuesOnly);
				xml.Add(xElement);
			}
		}

		public void SetValue(string id, int value)
		{
			GetOrCreateSetting<int>(id).ValueInt = value;
		}

		public void SetValue(string id, float value)
		{
			GetOrCreateSetting<float>(id).ValueFloat = value;
		}

		public void SetValue(string id, bool value)
		{
			GetOrCreateSetting<bool>(id).ValueBool = value;
		}

		public void SetValue(string id, string value)
		{
			GetOrCreateSetting<string>(id).ValueString = value;
		}

		private void OnValueChanged(object sender, NetworkedActivitySettingValueChangedEventArgs<object> e)
		{
			this.SettingValueChanged?.Invoke(sender, e);
		}
	}
}
