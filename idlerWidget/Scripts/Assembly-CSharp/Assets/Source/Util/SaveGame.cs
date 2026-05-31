using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using Assets.Behaviour.UI;
using Assets.Source.Player;
using LightJson;
using UnityEngine;

namespace Assets.Source.Util
{
	public class SaveGame
	{
		public const string DefaultSaveFile = "autosave";

		public const int AutosaveSlots = 3;

		public const float AutosaveFrequency = 300f;

		public static string SavesPath;

		public const SaveGameFormat DefaultSaveFormat = SaveGameFormat.Compressed;

		public const string SaveFileExtension = ".save";

		private static DirectoryInfo SavesDir;

		private static List<SaveGameFile> _saves;

		static SaveGame()
		{
			SavesPath = Application.persistentDataPath + "/Saves";
			SavesDir = new DirectoryInfo(SavesPath);
			if (!SavesDir.Exists)
			{
				SavesDir.Create();
			}
		}

		public static JsonObject SaveCurrentState()
		{
			JsonObject jsonObject = new JsonObject();
			jsonObject["Version"] = Application.version;
			jsonObject["Player"] = GamePlayer.Current.ToJson();
			SeedGenerator seedGenerator = new SeedGenerator();
			seedGenerator.Add(jsonObject);
			if (!GamePlayer.Current.Integrity)
			{
				seedGenerator.Add("Cheated widgets don't get achievements");
			}
			jsonObject["Secret"] = seedGenerator.Hash.ToString();
			return jsonObject;
		}

		public static void LoadState(JsonObject data)
		{
			GamePlayer.Current = GamePlayer.FromJson(data["Player"]);
			if (data.ContainsKey("Secret"))
			{
				ulong num = ulong.Parse(data["Secret"]);
				data.Remove("Secret");
				SeedGenerator seedGenerator = new SeedGenerator();
				seedGenerator.Add(data);
				if (seedGenerator.Hash != num)
				{
					Debug.Log("Save game integrity compromised!");
				}
			}
		}

		public static void StoreAutosaveState(string saveFile = null)
		{
			Store(SaveCurrentState(), saveFile ?? GetAutosaveSlot());
		}

		public static void DoSave(string saveFile)
		{
			Store(SaveCurrentState(), saveFile);
		}

		private static string GetAutosaveSlot()
		{
			List<SaveGameFile> list = new List<SaveGameFile>();
			for (int i = 0; i < 3; i++)
			{
				string text = "autosave-" + i;
				SaveGameFile saveGame = GetSaveGame(text);
				if (saveGame == null)
				{
					return text;
				}
				list.Add(saveGame);
			}
			list.Sort((SaveGameFile a, SaveGameFile b) => a.File.LastWriteTime.Ticks.CompareTo(b.File.LastWriteTime.Ticks));
			return list[0].Name;
		}

		public static void Store(JsonObject data, string saveName, SaveGameFormat format = SaveGameFormat.Compressed)
		{
			_saves = null;
			using (FileStream fileStream = new FileInfo(SavesDir.FullName + "/" + saveName + ".save").Open(FileMode.Create))
			{
				if (format == SaveGameFormat.Compressed)
				{
					byte[] bytes = Encoding.UTF8.GetBytes(data.ToString());
					using GZipStream gZipStream = new GZipStream(fileStream, CompressionMode.Compress);
					gZipStream.Write(bytes, 0, bytes.Length);
				}
				else
				{
					byte[] bytes2 = Encoding.UTF8.GetBytes(data.ToString(format == SaveGameFormat.Pretty));
					fileStream.Write(bytes2, 0, bytes2.Length);
				}
			}
			if ((bool)GameUI.Instance)
			{
				UIStatusMessage.Show("Game saved as " + saveName, SpriteLibrary.Get("Items_37"), persistent: false);
			}
		}

		public static List<SaveGameFile> GetSaveGames()
		{
			if (_saves == null)
			{
				_saves = new List<SaveGameFile>();
				FileInfo[] files = SavesDir.GetFiles("*.save");
				foreach (FileInfo file in files)
				{
					_saves.Add(new SaveGameFile(file));
				}
			}
			return _saves;
		}

		public static SaveGameFile GetSaveGame(string name)
		{
			foreach (SaveGameFile saveGame in GetSaveGames())
			{
				if (saveGame.Name == name)
				{
					return saveGame;
				}
			}
			return null;
		}

		public static SaveGameFile GetLatestSave()
		{
			List<SaveGameFile> saveGames = GetSaveGames();
			saveGames.Sort((SaveGameFile a, SaveGameFile b) => b.File.LastWriteTime.Ticks.CompareTo(a.File.LastWriteTime.Ticks));
			return saveGames[0];
		}

		public static bool LoadLatestSave()
		{
			SaveGameFile latestSave = GetLatestSave();
			if (latestSave != null)
			{
				latestSave.LoadSaveGame();
				return true;
			}
			return false;
		}
	}
}
