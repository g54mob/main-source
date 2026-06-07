using System.Collections.Generic;
using DV.UserManagement.Data;
using DV.UserManagement.Integration;
using DV.UserManagement.Storage;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.UserManagement.Util
{
	public static class Util
	{
		public const string DATA_VERSION = "DataVersion";

		private static JsonSerializer defaultSerializer = JsonSerializer.CreateDefault();

		private const string SigChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRTUVWXYZ0123456789.,/!@#$%^&*()-+{}[];:<>?";

		public static string Clamp(this string s, int maxLength)
		{
			if (string.IsNullOrEmpty(s) || s.Length <= maxLength)
			{
				return s;
			}
			return s.Substring(0, maxLength);
		}

		public static JObject Upgrade(this JObject json, UserManager manager, string path, IStorageProvider storage, AJSONDataUpgrader[] internalUpgraders, AJSONDataUpgrader[] gameDataUpgraders)
		{
			JObject jObject = json.Upgrade(manager, path, storage, internalUpgraders);
			if (jObject["GameData"] != null && jObject["GameData"] is JObject)
			{
				jObject["GameData"] = (jObject["GameData"] as JObject).Upgrade(manager, path, storage, gameDataUpgraders);
			}
			return jObject;
		}

		public static JObject Upgrade(this JObject json, UserManager manager, string path, IStorageProvider storage, AJSONDataUpgrader[] upgraders)
		{
			bool flag = false;
			int num = 1;
			if (json.ContainsKey("DataVersion"))
			{
				num = json["DataVersion"].Value<int>();
			}
			do
			{
				flag = false;
				for (int i = 0; i < upgraders.Length; i++)
				{
					if (upgraders[i].InputVersion == num)
					{
						json = upgraders[i].Upgrade(manager, path, storage, json);
						json["DataVersion"] = (num += 1);
						flag = true;
						break;
					}
				}
			}
			while (flag);
			return json;
		}

		public static JObject Upgrade(this JObject json, UserManager manager, string path, IStorageProvider storage, GameSession session, List<(int, byte[])> customChunks, ASaveSnapshotUpgrader[] internalUpgraders, ASaveSnapshotUpgrader[] gameDataUpgraders)
		{
			JObject jObject = json.Upgrade(manager, path, customChunks, storage, session, internalUpgraders);
			if (jObject["GameData"] != null && jObject["GameData"] is JObject)
			{
				jObject["GameData"] = (jObject["GameData"] as JObject).Upgrade(manager, path, customChunks, storage, session, gameDataUpgraders);
			}
			return jObject;
		}

		public static JObject Upgrade(this JObject json, UserManager manager, string path, List<(int, byte[])> customChunks, IStorageProvider storage, GameSession session, ASaveSnapshotUpgrader[] upgraders)
		{
			bool flag = false;
			int num = 1;
			if (json.ContainsKey("DataVersion"))
			{
				num = json["DataVersion"].Value<int>();
			}
			do
			{
				flag = false;
				for (int i = 0; i < upgraders.Length; i++)
				{
					if (upgraders[i].InputVersion == num)
					{
						json = upgraders[i].Upgrade(manager, path, customChunks, storage, session, json);
						json["DataVersion"] = (num += 1);
						flag = true;
						break;
					}
				}
			}
			while (flag);
			return json;
		}

		public static JObject SetVersion(this JObject json, int newVersion)
		{
			if (!json.ContainsKey("DataVersion") || json["DataVersion"].Type != JTokenType.Integer)
			{
				json["DataVersion"] = newVersion;
			}
			else if (json["DataVersion"].Value<int>() < newVersion)
			{
				json["DataVersion"] = newVersion;
			}
			return json;
		}

		public static void Populate<T>(this JToken value, T target) where T : class
		{
			using (JsonReader reader = value.CreateReader())
			{
				defaultSerializer.Populate(reader, target);
			}
		}

		public static string GenerateSignature(int length = 32)
		{
			char[] array = new char[length];
			for (int i = 0; i < length; i++)
			{
				array[i] = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRTUVWXYZ0123456789.,/!@#$%^&*()-+{}[];:<>?"[Random.Range(0, "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRTUVWXYZ0123456789.,/!@#$%^&*()-+{}[];:<>?".Length)];
			}
			return new string(array);
		}
	}
}
