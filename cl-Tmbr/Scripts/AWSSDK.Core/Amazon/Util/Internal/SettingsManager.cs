using System;
using System.Collections.Generic;
using System.Linq;
using Amazon.Runtime;
using Amazon.Runtime.Internal.Settings;

namespace Amazon.Util.Internal
{
	public class SettingsManager
	{
		public static bool IsAvailable => UserCrypto.IsUserCryptAvailable;

		public string SettingsType { get; private set; }

		public SettingsManager(string settingsType)
		{
			EnsureAvailable();
			SettingsType = settingsType;
		}

		public string RegisterObject(Dictionary<string, string> properties)
		{
			return RegisterObject(null, properties);
		}

		public string RegisterObject(string uniqueKey, Dictionary<string, string> properties)
		{
			SettingsCollection settings = GetSettings();
			if (!TryGetObjectSettings(uniqueKey, settings, out var objectSettings))
			{
				string uniqueKey2 = ((!string.IsNullOrEmpty(uniqueKey)) ? uniqueKey : Guid.NewGuid().ToString("D"));
				objectSettings = settings.NewObjectSettings(uniqueKey2);
			}
			foreach (KeyValuePair<string, string> property in properties)
			{
				if (property.Value == null)
				{
					objectSettings.Remove(property.Key);
				}
				else
				{
					objectSettings[property.Key] = property.Value;
				}
			}
			SaveSettings(settings);
			return objectSettings.UniqueKey;
		}

		public bool TryGetObject(string uniqueKey, out Dictionary<string, string> properties)
		{
			SettingsCollection settings = GetSettings();
			properties = null;
			if (TryGetObjectSettings(uniqueKey, settings, out var objectSettings))
			{
				uniqueKey = objectSettings.UniqueKey;
				properties = new Dictionary<string, string>();
				foreach (string key in objectSettings.Keys)
				{
					properties.Add(key, objectSettings[key]);
				}
			}
			return properties != null;
		}

		public bool TryGetObjectByProperty(string propertyName, string value, out string uniqueKey, out Dictionary<string, string> properties)
		{
			SettingsCollection settings = GetSettings();
			properties = null;
			uniqueKey = null;
			if (TryGetObjectSettings(propertyName, value, settings, out var objectSettings))
			{
				uniqueKey = objectSettings.UniqueKey;
				properties = new Dictionary<string, string>();
				foreach (string key in objectSettings.Keys)
				{
					properties.Add(key, objectSettings[key]);
				}
			}
			return properties != null;
		}

		public List<string> ListUniqueKeys()
		{
			return new List<string>(from x in GetSettings()
				select x.UniqueKey);
		}

		public List<string> SelectProperty(string propertyName)
		{
			return new List<string>(from x in GetSettings()
				select x[propertyName]);
		}

		public void UnregisterObject(string uniqueKey)
		{
			SettingsCollection settings = GetSettings();
			SettingsCollection.ObjectSettings objectSettings = null;
			if (TryGetObjectSettings(uniqueKey, settings, out objectSettings))
			{
				settings.Remove(objectSettings.UniqueKey);
				SaveSettings(settings);
			}
		}

		private SettingsCollection GetSettings()
		{
			return PersistenceManager.Instance.GetSettings(SettingsType);
		}

		private void SaveSettings(SettingsCollection settings)
		{
			PersistenceManager.Instance.SaveSettings(SettingsType, settings);
		}

		private static bool TryGetObjectSettings(string propertyName, string value, SettingsCollection settings, out SettingsCollection.ObjectSettings objectSettings)
		{
			objectSettings = settings.FirstOrDefault((SettingsCollection.ObjectSettings x) => string.Equals(x[propertyName], value, StringComparison.OrdinalIgnoreCase));
			return objectSettings != null;
		}

		private static bool TryGetObjectSettings(string uniqueKey, SettingsCollection settings, out SettingsCollection.ObjectSettings objectSettings)
		{
			objectSettings = settings.FirstOrDefault((SettingsCollection.ObjectSettings x) => string.Equals(x.UniqueKey, uniqueKey, StringComparison.OrdinalIgnoreCase));
			return objectSettings != null;
		}

		private static void EnsureAvailable()
		{
			if (!IsAvailable)
			{
				throw new AmazonClientException("The encrypted store is not available.  This may be due to use of a non-Windows operating system or Windows Nano Server, or the current user account may not have its profile loaded.");
			}
		}
	}
}
