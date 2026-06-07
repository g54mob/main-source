using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Steamworks;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Persistence.Achievements
{
	public class AchievementManager : BaseSingleton<AchievementManager>
	{
		[HideInInspector]
		public List<AchievementSetting> AchievementSettings;

		private string _achievementsPath;

		private Dictionary<EAchievement, bool> _achievementStatus;

		private readonly string _currentVersion = "1.0.0";

		protected override void Awake()
		{
			base.Awake();
			InitAchievementSettings();
			string text = Application.persistentDataPath + "/Saves/Global";
			_achievementsPath = text + "/Achievements.binary";
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			Init();
			LoadFromFile();
			LoadFromSteam();
			RuntimeGlobals.Achievements = this;
		}

		private void InitAchievementSettings()
		{
			AchievementSettings = new List<AchievementSetting>();
			Texture2D[] source = Resources.LoadAll<Texture2D>("Achievements");
			foreach (EAchievement a in Enum.GetValues(typeof(EAchievement)))
			{
				if (a != EAchievement.None)
				{
					AchievementSetting achievementSetting = new AchievementSetting();
					achievementSetting.AchievementType = a;
					achievementSetting.Description = new TranslationTerm
					{
						Term = string.Concat("Achievements/", a, "Description")
					};
					achievementSetting.Name = new TranslationTerm
					{
						Term = string.Concat("Achievements/", a, "Title")
					};
					achievementSetting.RewardText = new TranslationTerm
					{
						Term = string.Concat("Achievements/", a, "Reward")
					};
					achievementSetting.UnlockedIcon = source.FirstOrDefault((Texture2D t) => t.name == string.Concat(a, "Unlocked"));
					achievementSetting.LockedIcon = source.FirstOrDefault((Texture2D t) => t.name == string.Concat(a, "Locked"));
					AchievementSettings.Add(achievementSetting);
				}
			}
		}

		private void LoadFromSteam()
		{
			if (!SteamManager.Initialized)
			{
				return;
			}
			foreach (EAchievement value in EnumHelper.GetValues<EAchievement>())
			{
				bool pbAchieved;
				if (SteamUserStats.GetAchievement(value.ToString(), out pbAchieved) && pbAchieved)
				{
					_achievementStatus[value] = true;
				}
			}
		}

		public void UnlockAchievement(EAchievement achievement)
		{
			try
			{
				_achievementStatus[achievement] = true;
				if (SteamManager.Initialized)
				{
					SteamUserStats.SetAchievement(achievement.ToString());
					SteamUserStats.StoreStats();
				}
			}
			catch (Exception message)
			{
				Debug.Log(message);
			}
		}

		public bool IsAchievementUnlocked(EAchievement achievement)
		{
			return _achievementStatus[achievement];
		}

		private void Init()
		{
			_achievementStatus = new Dictionary<EAchievement, bool>();
			foreach (EAchievement value in EnumHelper.GetValues<EAchievement>())
			{
				_achievementStatus.Add(value, false);
			}
		}

		private void LoadFromFile()
		{
			try
			{
				if (!File.Exists(_achievementsPath))
				{
					return;
				}
				using (BinaryReader binaryReader = new BinaryReader(File.Open(_achievementsPath, FileMode.Open)))
				{
					binaryReader.ReadString();
					int num = binaryReader.ReadInt32();
					for (int i = 0; i < num; i++)
					{
						EAchievement eAchievement = (EAchievement)binaryReader.ReadInt32();
						bool flag = binaryReader.ReadBoolean();
						if (_achievementStatus.ContainsKey(eAchievement) && flag)
						{
							UnlockAchievement(eAchievement);
						}
					}
				}
			}
			catch (Exception message)
			{
				Debug.Log(message);
			}
		}

		private void SaveToFile()
		{
			using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(_achievementsPath, FileMode.OpenOrCreate)))
			{
				binaryWriter.Write(_currentVersion);
				int count = _achievementStatus.Count;
				foreach (KeyValuePair<EAchievement, bool> item in _achievementStatus)
				{
					binaryWriter.Write((int)item.Key);
					binaryWriter.Write(item.Value);
				}
			}
		}

		public void OnApplicationQuit()
		{
			SaveToFile();
		}
	}
}
