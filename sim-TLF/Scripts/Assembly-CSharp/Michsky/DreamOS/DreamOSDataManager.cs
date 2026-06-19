using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Michsky.DreamOS
{
	public class DreamOSDataManager : MonoBehaviour
	{
		public enum DataCategory
		{
			User = 0,
			System = 1,
			Apps = 2,
			Widgets = 3,
			Network = 4,
			DateAndTime = 5
		}

		public static string profileID;

		private static string subPath = "DreamOS_UserData";

		private static string jsonExtension = ".json";

		private static string dataPath;

		private static void InitializeProfile()
		{
			string text = Application.dataPath;
			text = text.Replace(Application.productName + "_Data", "");
			dataPath = text + subPath + "/" + profileID + "/";
		}

		private static string GetProjectName()
		{
			return Application.dataPath.Split('/')[^2];
		}

		private static string GetTempDataPath(DataCategory cat)
		{
			if (string.IsNullOrEmpty(dataPath))
			{
				InitializeProfile();
			}
			if (!Directory.Exists(dataPath))
			{
				Directory.CreateDirectory(dataPath);
			}
			if (!File.Exists(dataPath + cat.ToString() + jsonExtension))
			{
				File.WriteAllText(dataPath + cat.ToString() + jsonExtension, "{}");
			}
			if (string.IsNullOrEmpty(File.ReadAllText(dataPath + cat.ToString() + jsonExtension)))
			{
				File.WriteAllText(dataPath + cat.ToString() + jsonExtension, "{}");
			}
			return dataPath + cat.ToString() + jsonExtension;
		}

		public static bool ContainsJsonKey(DataCategory cat, string key)
		{
			return JsonConvert.DeserializeObject<JObject>(File.ReadAllText(GetTempDataPath(cat))).ContainsKey(key);
		}

		public static void WriteStringData(DataCategory cat, string key, string value)
		{
			string tempDataPath = GetTempDataPath(cat);
			string value2 = File.ReadAllText(tempDataPath);
			Dictionary<string, object>? dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(value2);
			dictionary[key] = value;
			value2 = JsonConvert.SerializeObject(dictionary);
			File.WriteAllText(tempDataPath, value2);
		}

		public static void WriteIntData(DataCategory cat, string key, int value)
		{
			string tempDataPath = GetTempDataPath(cat);
			string value2 = File.ReadAllText(tempDataPath);
			Dictionary<string, object>? dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(value2);
			dictionary[key] = value;
			value2 = JsonConvert.SerializeObject(dictionary);
			File.WriteAllText(tempDataPath, value2);
		}

		public static void WriteFloatData(DataCategory cat, string key, float value)
		{
			string tempDataPath = GetTempDataPath(cat);
			string value2 = File.ReadAllText(tempDataPath);
			Dictionary<string, object>? dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(value2);
			dictionary[key] = value;
			value2 = JsonConvert.SerializeObject(dictionary);
			File.WriteAllText(tempDataPath, value2);
		}

		public static void WriteBooleanData(DataCategory cat, string key, bool value)
		{
			string tempDataPath = GetTempDataPath(cat);
			string value2 = File.ReadAllText(tempDataPath);
			Dictionary<string, object>? dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(value2);
			dictionary[key] = value;
			value2 = JsonConvert.SerializeObject(dictionary);
			File.WriteAllText(tempDataPath, value2);
		}

		public static string ReadStringData(DataCategory cat, string key)
		{
			return (string)JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(GetTempDataPath(cat)))[key];
		}

		public static int ReadIntData(DataCategory cat, string key)
		{
			return (int)(long)JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(GetTempDataPath(cat)))[key];
		}

		public static float ReadFloatData(DataCategory cat, string key)
		{
			return (float)(double)JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(GetTempDataPath(cat)))[key];
		}

		public static bool ReadBooleanData(DataCategory cat, string key)
		{
			return (bool)JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(GetTempDataPath(cat)))[key];
		}

		public static void DeleteData(DataCategory cat, string key)
		{
			string tempDataPath = GetTempDataPath(cat);
			string value = File.ReadAllText(tempDataPath);
			Dictionary<string, object>? dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(value);
			dictionary.Remove(key);
			value = JsonConvert.SerializeObject(dictionary);
			File.WriteAllText(tempDataPath, value);
		}

		public static void DeleteDataCategory(DataCategory cat)
		{
			File.WriteAllText(dataPath + cat.ToString() + jsonExtension, "{}");
		}
	}
}
