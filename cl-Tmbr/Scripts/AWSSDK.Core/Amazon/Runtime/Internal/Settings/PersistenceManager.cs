using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using Amazon.Runtime.Internal.Util;
using Amazon.Util.Internal;

namespace Amazon.Runtime.Internal.Settings
{
	public class PersistenceManager : IPersistenceManager
	{
		private static readonly HashSet<string> ENCRYPTEDKEYS;

		private static readonly Logger _logger;

		private readonly Dictionary<string, SettingsWatcher> _watchers = new Dictionary<string, SettingsWatcher>();

		private static string SettingsStoreFolder;

		public static IPersistenceManager Instance { get; set; }

		static PersistenceManager()
		{
			ENCRYPTEDKEYS = new HashSet<string>
			{
				"AWSAccessKey", "AWSSecretKey", "SessionToken", "ExternalId", "MfaSerial", "SecretKeyRepository", "EC2InstanceUserName", "EC2InstancePassword", "ProxyUsernameEncrypted", "ProxyPasswordEncrypted",
				"UserIdentity", "RoleSession"
			};
			SettingsStoreFolder = null;
			_logger = Logger.GetLogger(typeof(PersistenceManager));
			try
			{
				SettingsStoreFolder = Environment.GetEnvironmentVariable("HOME");
				if (string.IsNullOrEmpty(SettingsStoreFolder))
				{
					SettingsStoreFolder = Environment.GetEnvironmentVariable("USERPROFILE");
				}
				SettingsStoreFolder = Path.Combine(SettingsStoreFolder, "AppData/Local/AWSToolkit");
				if (!Directory.Exists(SettingsStoreFolder))
				{
					Directory.CreateDirectory(SettingsStoreFolder);
				}
				Instance = new PersistenceManager();
			}
			catch (UnauthorizedAccessException exception)
			{
				_logger.Error(exception, "Unable to initialize 'PersistenceManager'. Falling back to 'InMemoryPersistenceManager'.");
				Instance = new InMemoryPersistenceManager();
			}
		}

		public SettingsCollection GetSettings(string type)
		{
			return loadSettingsType(type);
		}

		public void SaveSettings(string type, SettingsCollection settings)
		{
			saveSettingsType(type, settings);
		}

		public string GetSetting(string key)
		{
			return GetSettings("MiscSettings")["MiscSettings"][key];
		}

		public void SetSetting(string key, string value)
		{
			SettingsCollection settings = GetSettings("MiscSettings");
			settings["MiscSettings"][key] = value;
			SaveSettings("MiscSettings", settings);
		}

		public static string GetSettingsStoreFolder()
		{
			return SettingsStoreFolder;
		}

		public SettingsWatcher Watch(string type)
		{
			SettingsWatcher settingsWatcher = new SettingsWatcher(getFileFromType(type), type);
			_watchers[type] = settingsWatcher;
			return settingsWatcher;
		}

		private void enableWatcher(string type)
		{
			SettingsWatcher value = null;
			if (_watchers.TryGetValue(type, out value))
			{
				value.Enable = true;
			}
		}

		private void disableWatcher(string type)
		{
			SettingsWatcher value = null;
			if (_watchers.TryGetValue(type, out value))
			{
				value.Enable = false;
			}
		}

		internal static bool IsEncrypted(string key)
		{
			return ENCRYPTEDKEYS.Contains(key);
		}

		private void saveSettingsType(string type, SettingsCollection settings)
		{
			disableWatcher(type);
			try
			{
				string fileFromType = getFileFromType(type);
				if (settings == null || settings.Count == 0)
				{
					if (File.Exists(fileFromType))
					{
						File.Delete(fileFromType);
					}
					return;
				}
				int num = 0;
				while (true)
				{
					try
					{
						using FileStream stream = new FileStream(fileFromType, FileMode.Create, FileAccess.Write, FileShare.None);
						using StreamWriter writer = new StreamWriter(stream);
						settings.Persist(writer);
						break;
					}
					catch (Exception)
					{
						if (num < 5)
						{
							Thread.Sleep(1000);
							num++;
							continue;
						}
						throw;
					}
				}
			}
			finally
			{
				enableWatcher(type);
			}
		}

		private SettingsCollection loadSettingsType(string type)
		{
			string fileFromType = getFileFromType(type);
			if (!File.Exists(fileFromType))
			{
				return new SettingsCollection();
			}
			int num = 0;
			while (true)
			{
				try
				{
					string text;
					using (FileStream stream = File.OpenRead(fileFromType))
					{
						using StreamReader streamReader = new StreamReader(stream);
						text = streamReader.ReadToEnd();
					}
					Dictionary<string, Dictionary<string, string>> dictionary;
					if (!string.IsNullOrEmpty(text))
					{
						dictionary = JsonSerializerHelper.Deserialize<Dictionary<string, Dictionary<string, string>>>(text, JsonSerializerContext.Default);
						if (dictionary == null)
						{
							dictionary = new Dictionary<string, Dictionary<string, string>>();
						}
					}
					else
					{
						dictionary = new Dictionary<string, Dictionary<string, string>>();
					}
					DecryptAnyEncryptedValues(dictionary);
					return new SettingsCollection(dictionary);
				}
				catch
				{
					if (num < 5)
					{
						Thread.Sleep(1000);
						num++;
						continue;
					}
					return new SettingsCollection();
				}
			}
		}

		private static void DecryptAnyEncryptedValues(Dictionary<string, Dictionary<string, string>> settings)
		{
			foreach (KeyValuePair<string, Dictionary<string, string>> setting in settings)
			{
				string key = setting.Key;
				Dictionary<string, string> value = setting.Value;
				foreach (string item in new List<string>(value.Keys))
				{
					if (!IsEncrypted(item) && !IsEncrypted(key))
					{
						continue;
					}
					string text = value[item];
					if (text != null)
					{
						try
						{
							value[item] = UserCrypto.Decrypt(text);
						}
						catch (Exception exception)
						{
							value.Remove(item);
							Logger.GetLogger(typeof(PersistenceManager)).Error(exception, "Exception decrypting value for key {0}/{1}", key, item);
						}
					}
				}
			}
		}

		private static string getFileFromType(string type)
		{
			return string.Format(CultureInfo.InvariantCulture, "{0}\\{1}.json", GetSettingsStoreFolder(), type);
		}
	}
}
