#define LOG_LEVEL_VERBOSE
using System;
using System.IO;
using System.Text;
using FullSerializerSave;

namespace TH20
{
	public static class PreferencesUtils
	{
		public static T LoadPreferencesFromFile<T>(string preferencesFilePath) where T : class
		{
			Logging.Info(LogChannels.Preferences, "Attempting to load {0} from {1}", typeof(T).Name, preferencesFilePath);
			if (!PlatformFileManager.FileExists(preferencesFilePath))
			{
				Logging.Info(LogChannels.Preferences, "No preference file exists yet");
				return null;
			}
			byte[] array = PlatformFileManager.Load(preferencesFilePath);
			if (array == null)
			{
				Logging.Error(LogChannels.Preferences, "Failed to load preference file.");
				return null;
			}
			string text = Encoding.UTF8.GetString(array);
			int num = text.IndexOf('{');
			if (num < 0)
			{
				Logging.Error(LogChannels.Preferences, "Preferences file appears to be corrupt/invalid, aborting load.");
				return null;
			}
			text = text.Substring(num);
			return DeserializePreferences<T>(text);
		}

		public static T LoadLocalPreferencesFromFile<T>(string preferencesFilePath) where T : class
		{
			Logging.Info(LogChannels.Preferences, "Attempting to load {0} from {1}", typeof(T).Name, preferencesFilePath);
			if (!File.Exists(preferencesFilePath))
			{
				Logging.Info(LogChannels.Preferences, "No preference file exists yet");
				return null;
			}
			string fileContents;
			try
			{
				fileContents = File.ReadAllText(preferencesFilePath);
			}
			catch (Exception ex)
			{
				Logging.Error(LogChannels.Preferences, "Failed to load preference file. Exception: {0}", ex);
				return null;
			}
			return DeserializePreferences<T>(fileContents);
		}

		public static T DeserializePreferences<T>(string fileContents) where T : class
		{
			if (fsJsonParser.Parse(fileContents, out var data).Failed)
			{
				Logging.Error(LogChannels.Preferences, "Failed to parse preference file as JSON; skipping loading preference");
				return null;
			}
			fsSerializer obj = CreateAndConfigureSerializer();
			T instance = null;
			fsResult fsResult2 = obj.TryDeserialize(data, ref instance);
			if (fsResult2.Failed)
			{
				Logging.Error(LogChannels.Preferences, "Failed to deserialise preferences; skipping loading preferences. Error: {0}", fsResult2.FormattedMessages);
				return null;
			}
			if (fsResult2.HasWarnings)
			{
				Logging.Warning(LogChannels.Preferences, "Warnings encountered whilst deserialising preferences: {0}", fsResult2.FormattedMessages);
			}
			Logging.Info(LogChannels.Preferences, "Successfully loaded preferences");
			return instance;
		}

		public static void SavePreferencesToFile<T>(string preferencesFilePath, T preferences) where T : class
		{
			Logging.Info(LogChannels.Preferences, "Attempting to save {0} to {1}", typeof(T).Name, preferencesFilePath);
			string s = SerializePreferences(preferences);
			string directoryName = Path.GetDirectoryName(preferencesFilePath);
			if (!string.IsNullOrEmpty(directoryName))
			{
				PlatformFileManager.EnsureDirectoryExists(directoryName);
			}
			if (PlatformFileManager.Save(preferencesFilePath, Encoding.UTF8.GetBytes(s), useBackups: false))
			{
				Logging.Info(LogChannels.Preferences, "Successfully saved preferences");
			}
			else
			{
				Logging.Error(LogChannels.Preferences, "Failed to write preferences to file; save may or may not have succeeded");
			}
		}

		public static void SavePreferencesToLocalFile<T>(string preferencesFilePath, T preferences) where T : class
		{
			Logging.Info(LogChannels.Preferences, "Attempting to save {0} to {1}", typeof(T).Name, preferencesFilePath);
			string contents = SerializePreferences(preferences);
			string directoryName = Path.GetDirectoryName(preferencesFilePath);
			if (!string.IsNullOrEmpty(directoryName))
			{
				PlatformFileManager.EnsureDirectoryExists(directoryName);
			}
			try
			{
				File.WriteAllText(preferencesFilePath, contents);
			}
			catch (Exception ex)
			{
				Logging.Error(LogChannels.Preferences, "Failed to write preferences to file; save may or may not have succeeded. Exception: {0}", ex);
			}
			Logging.Info(LogChannels.Preferences, "Successfully saved preferences");
		}

		private static string SerializePreferences<T>(T preferences) where T : class
		{
			fsData data;
			fsResult fsResult2 = CreateAndConfigureSerializer().TrySerialize(preferences, out data);
			if (fsResult2.Failed)
			{
				Logging.Error(LogChannels.Preferences, "Failed to serialise preferences; aborting save. Errors: {0}", fsResult2.FormattedMessages);
				return null;
			}
			if (fsResult2.HasWarnings)
			{
				Logging.Warning(LogChannels.Preferences, "Warnings encountered whilst serialising preferences: {0}", fsResult2.FormattedMessages);
			}
			return fsJsonPrinter.PrettyJson(data);
		}

		private static fsSerializer CreateAndConfigureSerializer()
		{
			fsSerializer fsSerializer2 = new fsSerializer();
			fsSerializer2.Config.DefaultMemberSerialization = fsMemberSerialization.OptOut;
			fsSerializer2.Config.EnablePropertySerialization = false;
			fsSerializer2.Config.IgnoreSerializeAttributes = new Type[3]
			{
				typeof(DontSaveAttribute),
				typeof(NonSerializedAttribute),
				typeof(fsIgnoreAttribute)
			};
			return fsSerializer2;
		}
	}
}
