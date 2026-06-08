using System;
using System.Collections.Generic;
using Amazon.Runtime.Internal.Settings;

namespace Amazon.Util.Internal
{
	public class NamedSettingsManager
	{
		private SettingsManager settingsManager;

		public static bool IsAvailable => UserCrypto.IsUserCryptAvailable;

		public NamedSettingsManager(string settingsType)
		{
			settingsManager = new SettingsManager(settingsType);
		}

		public string RegisterObject(string displayName, Dictionary<string, string> properties)
		{
			if (string.IsNullOrEmpty(displayName))
			{
				throw new ArgumentException("displayName cannot be null or empty.");
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>(properties);
			dictionary["DisplayName"] = displayName;
			if (settingsManager.TryGetObjectByProperty("DisplayName", displayName, out var uniqueKey, out properties))
			{
				return settingsManager.RegisterObject(uniqueKey, dictionary);
			}
			return settingsManager.RegisterObject(dictionary);
		}

		public bool TryGetObject(string displayName, out Dictionary<string, string> properties)
		{
			string uniqueKey;
			return TryGetObject(displayName, out uniqueKey, out properties);
		}

		public bool TryGetObject(string displayName, out string uniqueKey, out Dictionary<string, string> properties)
		{
			return settingsManager.TryGetObjectByProperty("DisplayName", displayName, out uniqueKey, out properties);
		}

		public void UnregisterObject(string displayName)
		{
			if (settingsManager.TryGetObjectByProperty("DisplayName", displayName, out var uniqueKey, out var _))
			{
				settingsManager.UnregisterObject(uniqueKey);
			}
		}

		public void RenameObject(string oldDisplayName, string newDisplayName, bool force)
		{
			if (TryGetObject(oldDisplayName, out var uniqueKey, out var properties))
			{
				if (TryGetObject(newDisplayName, out var uniqueKey2, out var _))
				{
					if (!string.Equals(oldDisplayName, newDisplayName, StringComparison.Ordinal))
					{
						if (!force)
						{
							throw new ArgumentException("Cannot rename object. The destination object '" + newDisplayName + "' already exists.");
						}
						settingsManager.UnregisterObject(uniqueKey2);
						RenameObject(oldDisplayName, newDisplayName, force: false);
					}
				}
				else
				{
					properties["DisplayName"] = newDisplayName;
					settingsManager.RegisterObject(uniqueKey, properties);
				}
				return;
			}
			throw new ArgumentException("Cannot rename object. The source object '" + oldDisplayName + "' does not exist.");
		}

		public void CopyObject(string fromDisplayName, string toDisplayName, bool force)
		{
			if (TryGetObject(fromDisplayName, out var properties))
			{
				if (TryGetObject(toDisplayName, out var uniqueKey, out var _))
				{
					if (!string.Equals(fromDisplayName, toDisplayName, StringComparison.Ordinal))
					{
						if (!force)
						{
							throw new ArgumentException("Cannot copy object. The destination object '" + toDisplayName + "' already exists.");
						}
						settingsManager.UnregisterObject(uniqueKey);
						CopyObject(fromDisplayName, toDisplayName, force);
					}
				}
				else
				{
					RegisterObject(toDisplayName, properties);
				}
				return;
			}
			throw new ArgumentException("Cannot copy object. The source object '" + fromDisplayName + "' does not exist.");
		}

		public List<string> ListObjectNames()
		{
			return settingsManager.SelectProperty("DisplayName");
		}
	}
}
