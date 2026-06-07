using System;
using System.IO;
using DV.UserManagement.Storage;
using DV.UserManagement.Util;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.UserManagement.Migration
{
	[CreateAssetMenu(menuName = "DV/App To User Data migration")]
	public class AppToUserDataMigration : APreLoadUpgrader
	{
		private const string SAVEGAME_DIRECTORY_NAME = "SaveGameData";

		private const int MAX_BACKUPS_DISK_USAGE_KB = 10000;

		private const string SUPER_SECRET = "WeDidntSecureThisVeryWell!!1";

		private const string WorldName = "World1";

		private static readonly string[] GameModes = new string[2] { "Career", "FreeRoam" };

		private static string SaveDirPath => string.Join("/", Application.dataPath, "SaveGameData");

		public override void ProcessData(UserManager manager, IStorageProvider storage)
		{
			if (storage.FileExists("Users/global.json"))
			{
				return;
			}
			string path = Path.Combine(Application.dataPath, "SaveGameData", "GamePreferences.ini");
			string text = Path.Combine(Application.dataPath, "SaveGameData", "savegame");
			if (!File.Exists(path) && !File.Exists(text))
			{
				return;
			}
			string defaultName = manager.NamingProvider.DefaultName;
			JObject jObject = new JObject();
			string text2 = DV.UserManagement.Util.Util.GenerateSignature();
			jObject.Add("DataVersion", 1);
			jObject.Add("LastUser", defaultName);
			jObject.Add("GameData", new JObject());
			storage.WriteFile("Users/global.json", jObject.ToString());
			JObject jObject2 = new JObject();
			jObject2.Add("Name", defaultName);
			jObject2.Add("DataVersion", 1);
			jObject2.Add("GameData", new JObject());
			jObject2.Add("CurrentMode", GameModes[0]);
			jObject2.Add("Signature", text2);
			JObject jObject3 = new JObject();
			for (int i = 0; i < GameModes.Length; i++)
			{
				jObject3.Add(GameModes[i], -1);
			}
			jObject2.Add("selectedSessionUID", jObject3);
			storage.WriteFile("Users/000_" + defaultName + "/userData.json", jObject2.ToString());
			if (File.Exists(path))
			{
				string data = File.ReadAllText(path);
				storage.WriteFile("Preferences/000_" + defaultName + ".ini", data);
			}
			string text3 = null;
			DateTime dateTime = DateTime.Now;
			if (File.Exists(text))
			{
				dateTime = File.GetLastWriteTime(text);
				text3 = File.ReadAllText(text);
				text3 = DataProtection.DecryptString(text3, "WeDidntSecureThisVeryWell!!1");
			}
			else if (File.Exists(text + ".json"))
			{
				dateTime = File.GetLastWriteTime(text + ".json");
				text3 = File.ReadAllText(text + ".json");
			}
			if (!string.IsNullOrEmpty(text3))
			{
				string text4 = "Users/000_" + defaultName + "/" + GameModes[0] + "/000_" + GameModes[0] + "/";
				string text5 = text4 + "Saves/00000_" + storage.SanitizeName(dateTime.ToString("yyyy-MM-dd HH:mm:ss"));
				JObject jObject4 = new JObject();
				jObject4.Add("DataVersion", 1);
				jObject4.Add("GameMode", GameModes[0]);
				jObject4.Add("World", "World1");
				jObject4.Add("SessionID", 0);
				jObject4.Add("Name", "Legacy Session");
				jObject4.Add("GameData", new JObject());
				storage.WriteFile(text4 + "sessionData.json", jObject4.ToString());
				JObject jObject5 = new JObject();
				jObject5.Add("Timestamp", dateTime);
				jObject5.Add("Type", 0);
				jObject5.Add("Name", dateTime.ToString());
				jObject5.Add("World", "World1");
				jObject5.Add("GameMode", GameModes[0]);
				storage.WriteFile(text5 + ".json", jObject5.ToString());
				byte[] key = null;
				if (manager.KeyProvider != null)
				{
					key = manager.KeyProvider.GetKeyFor(0, defaultName, text2);
				}
				storage.WriteFile(text5 + ".sav", text3, key);
			}
			if (File.Exists(path))
			{
				File.Delete(path);
			}
			if (File.Exists(text))
			{
				File.Delete(text);
			}
			Debug.Log("AppToUserDataMigration done.");
		}
	}
}
