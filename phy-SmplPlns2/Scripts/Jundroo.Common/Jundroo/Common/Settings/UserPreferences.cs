using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Jundroo.Common.Settings
{
	public class UserPreferences
	{
		private enum UserPrefType
		{
			Bool = 0,
			Double = 1,
			String = 2,
			Int = 3,
			Vector2 = 4
		}

		private class UserPref
		{
			public UserPrefType PrefType { get; private set; }

			public object Value { get; private set; }

			public UserPref(UserPrefType type, object value)
			{
				PrefType = type;
				Value = value;
			}
		}

		private const string XmlAttributeName = "name";

		private const string XmlAttributeType = "type";

		private const string XmlAttributeValue = "value";

		private Dictionary<string, UserPref> _prefs = new Dictionary<string, UserPref>();

		public bool HasUnsavedChanges { get; private set; }

		public bool GetBool(string key, bool defaultValue = false)
		{
			return GetValue(key, defaultValue, UserPrefType.Bool);
		}

		public double GetDouble(string key, double defaultValue = 0.0)
		{
			return GetValue(key, defaultValue, UserPrefType.Double);
		}

		public int GetInt(string key, int defaultValue = 0)
		{
			return GetValue(key, defaultValue, UserPrefType.Int);
		}

		public string GetString(string key, string defaultValue = null)
		{
			return GetValue(key, defaultValue, UserPrefType.String);
		}

		public Vector2 GetVector2(string key, Vector2 defaultValue)
		{
			return GetValue(key, defaultValue, UserPrefType.Vector2);
		}

		public Vector2? GetVector2OrNull(string key)
		{
			return GetValue<Vector2?>(key, null, UserPrefType.Vector2);
		}

		public void Load(XElement element)
		{
			if (element != null)
			{
				foreach (XElement item in element.Elements("Pref"))
				{
					try
					{
						string stringAttribute = item.GetStringAttribute("name");
						switch (item.GetEnumAttribute("type", UserPrefType.Bool))
						{
						case UserPrefType.Bool:
							SetBool(stringAttribute, item.GetBoolAttribute("value"));
							break;
						case UserPrefType.Double:
							SetDouble(stringAttribute, item.GetDoubleAttribute("value"));
							break;
						case UserPrefType.String:
							SetString(stringAttribute, item.GetStringAttribute("value"));
							break;
						case UserPrefType.Int:
							SetInt(stringAttribute, item.GetIntAttribute("value"));
							break;
						case UserPrefType.Vector2:
							SetVector2(stringAttribute, item.GetVector2Attribute("value", Vector2.zero));
							break;
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
			}
			HasUnsavedChanges = false;
		}

		public void Remove(Predicate<string> predicate)
		{
			foreach (string item in _prefs.Keys.Where((string x) => predicate(x)).ToList())
			{
				_prefs.Remove(item);
			}
		}

		public XElement Save(XElement element)
		{
			foreach (KeyValuePair<string, UserPref> pref in _prefs)
			{
				XElement xElement = new XElement("Pref");
				xElement.SetAttributeValue("name", pref.Key);
				xElement.SetAttributeValue("type", pref.Value.PrefType);
				if (pref.Value.PrefType == UserPrefType.Vector2)
				{
					xElement.SetAttributeValue("value", Utilities.Vector2ToString((Vector2)pref.Value.Value));
				}
				else
				{
					xElement.SetAttributeValue("value", pref.Value.Value);
				}
				element.Add(xElement);
			}
			HasUnsavedChanges = false;
			return element;
		}

		public void SetBool(string key, bool value)
		{
			SetValue(key, value, UserPrefType.Bool);
		}

		public void SetDouble(string key, double value)
		{
			SetValue(key, value, UserPrefType.Double);
		}

		public void SetInt(string key, int value)
		{
			SetValue(key, value, UserPrefType.Int);
		}

		public void SetString(string key, string value)
		{
			SetValue(key, value, UserPrefType.String);
		}

		public void SetVector2(string key, Vector2 value)
		{
			SetValue(key, value, UserPrefType.Vector2);
		}

		private T GetValue<T>(string key, T defaultValue, UserPrefType type)
		{
			try
			{
				if (_prefs.ContainsKey(key))
				{
					UserPref userPref = _prefs[key];
					if (userPref.PrefType == type)
					{
						return (T)userPref.Value;
					}
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			return defaultValue;
		}

		private void SetValue<T>(string key, T value, UserPrefType type)
		{
			_prefs[key] = new UserPref(type, value);
			HasUnsavedChanges = true;
		}
	}
}
