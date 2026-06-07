using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DV.JObjectExtstensions;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.CrashReportHandler;

namespace DV.Mods
{
	public static class ModManagerInfo
	{
		private class ModInfo
		{
			private const string NAME_KEY = "name";

			private const string VERSION_KEY = "version";

			private const string TIMESTAMP_KEY = "timestamp";

			public readonly string name;

			public readonly string version;

			public readonly DateTime timestamp;

			public ModInfo(string name, string version, DateTime timestamp)
			{
				this.name = name;
				this.version = version;
				this.timestamp = timestamp;
			}

			public static bool TryFromJObject(JObject modInfoJObject, out ModInfo result)
			{
				string text = modInfoJObject.GetString("name");
				string text2 = modInfoJObject.GetString("version");
				DateTime dateTime = modInfoJObject.Value<DateTime>("timestamp");
				if (text != null && text2 != null && dateTime != default(DateTime))
				{
					result = new ModInfo(text, text2, dateTime);
					return true;
				}
				result = null;
				return false;
			}

			public JObject ToJObject()
			{
				JObject jObject = new JObject();
				jObject.SetString("name", name);
				jObject.SetString("version", version);
				jObject["timestamp"] = timestamp;
				return jObject;
			}
		}

		private const string CLOUD_DIAG_TAG_DETECTED = "modManagerDetected";

		private const string CLOUD_DIAG_TAG_INFO = "modManagerInfo";

		private const string MOD_MANAGER_NAME_KEY = "modManagerName";

		private const string MOD_MANAGER_VERSION_KEY = "modManagerVersion";

		private const string HARMONY_VERSION_KEY = "harmonyVersion";

		private const string LOADED_MODS_KEY = "loadedMods";

		private const string PREVIOUS_MODS_KEY = "previousMods";

		private const string TIMESTAMP_KEY = "timestamp";

		public static bool CurrentSavegameHasMods { get; private set; }

		public static string BootstrapQuickCheck()
		{
			try
			{
				List<(string, string)> list = new List<(string, string)>();
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				for (int i = 0; i < assemblies.Length; i++)
				{
					AssemblyName name = assemblies[i].GetName();
					string name2 = name.Name;
					switch (name2)
					{
					case "0Harmony":
					case "BepInEx":
					case "UnityModManager":
						list.Add((name2, name.Version.ToString()));
						break;
					}
				}
				if (list.Count == 0)
				{
					CrashReportHandler.SetUserMetadata("modManagerDetected", "false");
					CrashReportHandler.SetUserMetadata("modManagerInfo", "");
					CrashReportHandler.enableCaptureExceptions = true;
					return "No";
				}
				string text = string.Join(", ", list.Select(((string, string) m) => m.Item1 + " " + m.Item2));
				CrashReportHandler.SetUserMetadata("modManagerDetected", "true");
				CrashReportHandler.SetUserMetadata("modManagerInfo", text);
				CrashReportHandler.enableCaptureExceptions = false;
				return text;
			}
			catch (Exception exception)
			{
				Debug.Log("The following exception occurred while looking for mod managers:");
				Debug.LogException(exception);
				return "ERROR";
			}
		}

		public static void UpdateSaveGameData(SaveGameData saveGameData)
		{
			JObject jObject = Generate(saveGameData.GetJObject("ModManagers"));
			if (jObject != null)
			{
				saveGameData.SetJObject("ModManagers", jObject);
			}
		}

		private static JObject Generate(JObject previousModManagerInfo)
		{
			CurrentSavegameHasMods = false;
			JObject jObject = new JObject();
			List<ModInfo> loadedMods = GetLoadedMods(jObject);
			List<ModInfo> list = null;
			SetModInfos(jObject, "loadedMods", loadedMods);
			if (previousModManagerInfo != null)
			{
				list = GetPreviousMods(loadedMods, previousModManagerInfo);
				SetModInfos(jObject, "previousMods", list);
			}
			if (jObject.Count == 0)
			{
				Debug.Log("[ModManagerInfo] No mods detected");
				return null;
			}
			CurrentSavegameHasMods = true;
			string text = jObject.GetString("modManagerName") + " " + jObject.GetString("modManagerVersion");
			CrashReportHandler.SetUserMetadata("modManagerDetected", "true");
			CrashReportHandler.SetUserMetadata("modManagerInfo", text);
			CrashReportHandler.enableCaptureExceptions = false;
			loadedMods = loadedMods ?? new List<ModInfo>();
			list = list ?? new List<ModInfo>();
			string text2 = string.Join("\n", loadedMods.Select((ModInfo m) => $"    - {m.name} {m.version} -- {m.timestamp}"));
			string text3 = string.Join("\n", list.Select((ModInfo m) => $"    - {m.name} {m.version} -- {m.timestamp}"));
			Debug.Log(string.Join("\n", "[ModManagerInfo] Mods detected !!!", "  Mod manager: " + text, $"  Currently loaded mods ({loadedMods.Count})", text2, $"  Previously used mods ({list.Count})", text3));
			return jObject;
		}

		private static void SetModInfos(JObject modManagerInfo, string key, List<ModInfo> modInfos)
		{
			if (modInfos != null)
			{
				JObject[] array = new JObject[modInfos.Count];
				for (int i = 0; i < modInfos.Count; i++)
				{
					array[i] = modInfos[i].ToJObject();
				}
				modManagerInfo.SetJObjectArray(key, array);
			}
		}

		private static List<ModInfo> GetLoadedMods(JObject modManagerInfo)
		{
			List<ModInfo> result = null;
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach (Assembly assembly in assemblies)
			{
				AssemblyName name = assembly.GetName();
				if (name.Name == "0Harmony")
				{
					modManagerInfo.SetString("harmonyVersion", name.Version.ToString());
				}
				else if (name.Name == "BepInEx")
				{
					modManagerInfo.SetString("modManagerName", name.Name);
					modManagerInfo.SetString("modManagerVersion", name.Version.ToString());
					modManagerInfo["timestamp"] = DateTime.UtcNow;
					result = GetModsFromBepInEx(assembly);
				}
				else if (name.Name == "UnityModManager")
				{
					modManagerInfo.SetString("modManagerName", name.Name);
					modManagerInfo.SetString("modManagerVersion", name.Version.ToString());
					modManagerInfo["timestamp"] = DateTime.UtcNow;
					result = GetModsFromUnityModManager(assembly);
				}
			}
			return result;
		}

		private static void MergeOldModInfo(List<string> loadedModNames, List<ModInfo> oldModInfos, JObject[] fromPreviousJson)
		{
			if (fromPreviousJson == null)
			{
				return;
			}
			for (int i = 0; i < fromPreviousJson.Length; i++)
			{
				if (ModInfo.TryFromJObject(fromPreviousJson[i], out var result) && !loadedModNames.Contains(result.name))
				{
					oldModInfos.Add(result);
				}
			}
		}

		private static List<ModInfo> GetPreviousMods(List<ModInfo> loadedMods, JObject previousJson)
		{
			if (previousJson == null)
			{
				return null;
			}
			List<string> list = new List<string>();
			if (loadedMods != null)
			{
				foreach (ModInfo loadedMod in loadedMods)
				{
					list.Add(loadedMod.name);
				}
			}
			List<ModInfo> list2 = new List<ModInfo>();
			MergeOldModInfo(list, list2, previousJson.GetJObjectArray("loadedMods"));
			MergeOldModInfo(list, list2, previousJson.GetJObjectArray("previousMods"));
			return list2;
		}

		private static ICollection GetBepInEx5PluginInfos(Assembly assembly)
		{
			return (GetProperty(GetType(assembly, "BepInEx.Bootstrap.Chainloader"), "PluginInfos").GetValue(null) as IDictionary).Values;
		}

		private static ICollection GetBepInEx6PluginInfos(Assembly assembly)
		{
			Type type = GetType(assembly, "BepInEx.Unity.Mono.Bootstrap.UnityChainloader");
			PropertyInfo property = GetProperty(type, "Instance");
			PropertyInfo property2 = GetProperty(type, "Plugins");
			object value = property.GetValue(null);
			return (property2.GetValue(value) as IDictionary).Values;
		}

		private static List<ModInfo> GetModsFromBepInEx(Assembly assembly)
		{
			try
			{
				PropertyInfo property = GetProperty(GetType(assembly, "BepInEx.PluginInfo"), "Metadata");
				Type type = GetType(assembly, "BepInEx.BepInPlugin");
				PropertyInfo property2 = GetProperty(type, "GUID");
				PropertyInfo property3 = GetProperty(type, "Version");
				ICollection obj = ((assembly.GetName().Version.Major < 6) ? GetBepInEx5PluginInfos(assembly) : GetBepInEx6PluginInfos(assembly));
				List<ModInfo> list = new List<ModInfo>();
				foreach (object item in obj)
				{
					object value = property.GetValue(item);
					object value2 = property2.GetValue(value);
					object value3 = property3.GetValue(value);
					if (value2 != null && value3 != null)
					{
						list.Add(new ModInfo(value2.ToString(), value3.ToString(), DateTime.UtcNow));
					}
				}
				return list;
			}
			catch (Exception exception)
			{
				Debug.Log($"Unable to enumerate mods from {assembly.GetName().Name} {assembly.GetName().Version}");
				Debug.LogException(exception);
				return null;
			}
		}

		private static List<ModInfo> GetModsFromUnityModManager(Assembly assembly)
		{
			try
			{
				FieldInfo field = GetField(GetType(assembly, "UnityModManagerNet.UnityModManager"), "modEntries");
				FieldInfo field2 = GetField(GetType(assembly, "UnityModManagerNet.UnityModManager+ModEntry"), "Info");
				Type type = GetType(assembly, "UnityModManagerNet.UnityModManager+ModInfo");
				FieldInfo field3 = GetField(type, "Id");
				FieldInfo field4 = GetField(type, "Version");
				IList obj = field.GetValue(null) as IList;
				List<ModInfo> list = new List<ModInfo>();
				foreach (object item in obj)
				{
					object value = field2.GetValue(item);
					object value2 = field3.GetValue(value);
					object value3 = field4.GetValue(value);
					if (value2 != null && value3 != null)
					{
						list.Add(new ModInfo(value2.ToString(), value3.ToString(), DateTime.UtcNow));
					}
				}
				return list;
			}
			catch (Exception exception)
			{
				Debug.Log($"Unable to enumerate mods from {assembly.GetName().Name} {assembly.GetName().Version}");
				Debug.LogException(exception);
				return null;
			}
		}

		private static Type GetType(Assembly assembly, string name)
		{
			Type type = assembly.GetType(name);
			if (type == null)
			{
				throw new NullReferenceException("Unable to find type $" + name + " in $" + assembly.FullName);
			}
			return type;
		}

		private static FieldInfo GetField(Type type, string name)
		{
			FieldInfo field = type.GetField(name);
			if (field == null)
			{
				throw new NullReferenceException("Unable to find field $" + name + " in $" + type.Name);
			}
			return field;
		}

		private static PropertyInfo GetProperty(Type type, string name)
		{
			PropertyInfo property = type.GetProperty(name);
			if (property == null)
			{
				throw new NullReferenceException("Unable to find property $" + name + " in $" + type.Name);
			}
			return property;
		}
	}
}
