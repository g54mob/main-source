using System;
using System.Collections.Generic;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class SaveProfile : SaveContainer
	{
		public override void Save(ES3Settings settings)
		{
			GameMode outInstance2;
			if (CTSSingleton<ProfileManager>.Instance.CurrentProfile is CareerProfile careerProfile)
			{
				if (CTSSingleton<GameMode>.TryGetInstance(out var outInstance) && (bool)outInstance.LevelInfo)
				{
					careerProfile.SetMoney(outInstance.LevelInfo, MonoSingleton<MoneyHandler>.Instance.CurrentMoney);
					careerProfile.AddPlayTime(outInstance.LevelInfo, outInstance.TimeSinceSave);
					outInstance.ResetTimeSinceSave();
				}
				CareerMetaData value = new CareerMetaData
				{
					ProfileIndex = careerProfile.ProfileIndex,
					TotalMoney = careerProfile.GetTotalMoney(),
					TotalScore = careerProfile.GetTotalScore(),
					SaveTime = DateTime.Now
				};
				ES3.Save("CareerMeta", value, settings);
				ES3.Save("Difficulty", CTSSingleton<Difficulty>.Instance.CurrentDifficulty, settings);
			}
			else if (CTSSingleton<ProfileManager>.Instance.CurrentProfile is FreemodeProfile freemodeProfile && CTSSingleton<GameMode>.TryGetInstance(out outInstance2))
			{
				freemodeProfile.AddPlayTime(outInstance2.TimeSinceSave);
				freemodeProfile.Money = MonoSingleton<MoneyHandler>.Instance.CurrentMoney;
				freemodeProfile.SaveTime = DateTime.Now;
				outInstance2.ResetTimeSinceSave();
			}
			if (CTSSingleton<GameMode>.TryGetInstance(out var outInstance3))
			{
				ES3.Save("LastLevelPlayed", new AssetRef<MapInfoSO>(outInstance3.LevelInfo), settings);
			}
			ES3.Save("Progress", CTSSingleton<ProfileManager>.Instance.CurrentProfile, settings);
		}

		public override void LoadInit(ES3Settings settings)
		{
			if (ES3.KeyExists("Progress", settings))
			{
				Profile currentProfile = ES3.Load<Profile>("Progress", settings);
				CTSSingleton<ProfileManager>.Instance.SetCurrentProfile(currentProfile);
			}
			if (CTSSingleton<ProfileManager>.Instance.CurrentProfile is FreemodeProfile freemodeProfile)
			{
				CTSSingleton<Difficulty>.Instance.CustomDifficulty = freemodeProfile.DifficultyData;
				return;
			}
			CTSSingleton<Difficulty>.Instance.CustomDifficulty = null;
			if (CTSSingleton<ProfileManager>.Instance.CurrentProfile is CareerProfile)
			{
				if (ES3.KeyExists("Difficulty", settings))
				{
					StringKey currentDifficulty = ES3.Load<StringKey>("Difficulty", settings);
					CTSSingleton<Difficulty>.Instance.SetCurrentDifficulty(currentDifficulty);
				}
				else
				{
					CTSSingleton<Difficulty>.Instance.ResetDifficulty();
				}
			}
		}

		public override void LoadPost(ES3Settings settings)
		{
			if (CTSSingleton<ProfileManager>.Instance.CurrentProfile is CareerProfile careerProfile)
			{
				ES3Settings imageSaveSettings = SaveBarScreenshot.GetImageSaveSettings();
				Dictionary<MapInfoSO, Texture2D> dictionary = new Dictionary<MapInfoSO, Texture2D>();
				foreach (MapInfoSO key in careerProfile.LevelProgress.Keys)
				{
					string imagePath = SaveBarScreenshot.GetImagePath(careerProfile.GetName(), key);
					imageSaveSettings.path = imagePath;
					if (ES3.FileExists(imageSaveSettings))
					{
						Texture2D value = ES3.LoadImage(imageSaveSettings);
						dictionary[key] = value;
					}
				}
				{
					foreach (var (map, image) in dictionary)
					{
						careerProfile.SetScreenshot(map, image);
					}
					return;
				}
			}
			if (CTSSingleton<ProfileManager>.Instance.CurrentProfile is FreemodeProfile freemodeProfile)
			{
				freemodeProfile.LoadScreenshot();
			}
		}
	}
}
