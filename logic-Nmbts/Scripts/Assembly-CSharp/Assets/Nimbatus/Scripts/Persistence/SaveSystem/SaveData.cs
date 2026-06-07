using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks;
using I2.Loc;
using Ionic.Zip;

namespace Assets.Nimbatus.Scripts.Persistence.SaveSystem
{
	[Serializable]
	public class SaveData
	{
		public string SaveGameVersion { get; set; }

		public string Name { get; set; }

		public EGameMode Mode { get; set; }

		public EGameModeDifficulty Difficulty { get; set; }

		public DateTime CreateTime { get; set; }

		public float TimePlayed { get; set; }

		public DateTime LastPlayedTime { get; set; }

		public GameModeSettings Settings { get; set; }

		[XmlIgnore]
		public string FilePath { get; set; }

		public SaveData()
		{
		}

		public SaveData(string name, EGameMode mode, EGameModeDifficulty difficulty, string path)
		{
			Name = name;
			FilePath = path;
			Mode = mode;
			Difficulty = difficulty;
			SaveGameVersion = SaveManager.CurrentGameVersion;
			try
			{
				CreateTime = DateTime.Now;
				LastPlayedTime = DateTime.Now;
			}
			catch (TimeZoneNotFoundException)
			{
				CreateTime = DateTime.UtcNow;
				LastPlayedTime = DateTime.UtcNow;
			}
			TimePlayed = 0f;
			Settings = new GameModeSettings();
			Settings.Init(mode, difficulty);
		}

		public static SaveData ExtractFromSavefile(string savePath)
		{
			using (ZipFile source = ZipFile.Read(savePath))
			{
				ZipEntry zipEntry = source.FirstOrDefault((ZipEntry e) => e.FileName == "SaveData.xml");
				if (zipEntry != null)
				{
					using (MemoryStream memoryStream = new MemoryStream())
					{
						zipEntry.Extract(memoryStream);
						memoryStream.Position = 0L;
						SaveData obj = new XmlSerializer(typeof(SaveData)).Deserialize(memoryStream) as SaveData;
						obj.FilePath = savePath;
						return obj;
					}
				}
			}
			return null;
		}

		public void StoreIntoSavefile()
		{
			MemoryStream memoryStream = new MemoryStream();
			using (StreamWriter textWriter = new StreamWriter(memoryStream))
			{
				new XmlSerializer(typeof(SaveData)).Serialize(textWriter, this);
			}
			using (ZipFile zipFile = ZipFile.Read(FilePath))
			{
				if (zipFile.ContainsEntry("SaveData.xml"))
				{
					zipFile.UpdateEntry("SaveData.xml", memoryStream.ToArray());
					zipFile.Save();
				}
				else
				{
					zipFile.AddEntry("SaveData.xml", memoryStream.ToArray());
					zipFile.Save();
				}
			}
		}

		public string GetDescription()
		{
			if (Mode == EGameMode.Creative)
			{
				return Settings.GetSandboxDetails();
			}
			DronePerk perk = SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.GetPerk(Settings.DronePerkId);
			if (perk != null)
			{
				return LabelHelper.White + LocalizationManager.GetTermTranslation("MainMenu/Captain") + " " + LabelHelper.Orange + perk.Name.GetTranslation() + LabelHelper.NewLine + LabelHelper.White + LocalizationManager.GetTermTranslation("MainMenu/Difficulty") + " " + LabelHelper.Orange + Difficulty.ToLocalizationString();
			}
			return "";
		}
	}
}
