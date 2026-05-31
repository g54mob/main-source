using System;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	public class FreemodeProfile : Profile
	{
		public string Name { get; private set; }

		public MapInfoSO MapInfo { get; set; }

		public DateTime SaveTime { get; set; }

		public float PlayTime { get; private set; }

		public int Money { get; set; }

		public Sprite Screenshot { get; private set; }

		public DifficultyData DifficultyData { get; set; }

		public LevelSettingsList Settings { get; set; }

		private FreemodeProfile()
		{
		}

		public FreemodeProfile(string name)
		{
			Name = name;
		}

		public override string GetName()
		{
			return "Freemode_" + Name;
		}

		public override void PlayProfile()
		{
			if (ES3.FileExists(SaveSettings.GetGlobalFolderSettings(GetName() + "/" + MapInfo.name)))
			{
				CTSSingleton<ProfileManager>.Instance.LoadScene(MapInfo, EGameMode.FreeMode);
			}
			else
			{
				CTSSingleton<ProfileManager>.Instance.RestartScene(MapInfo, EGameMode.FreeMode);
			}
		}

		public override bool DoesLevelHaveSave(MapInfoSO mapInfo)
		{
			return ES3.FileExists(SaveSettings.GetGlobalFolderSettings(GetName() + "/" + mapInfo.name));
		}

		public bool IsValid()
		{
			return ES3.FileExists(SaveSettings.GetGlobalFolderSettings(GetName() + "/profile"));
		}

		public void LoadScreenshot()
		{
			ES3Settings imageSaveSettings = SaveBarScreenshot.GetImageSaveSettings();
			string imagePath = SaveBarScreenshot.GetImagePath(GetName(), MapInfo);
			imageSaveSettings.path = imagePath;
			if (ES3.FileExists(imageSaveSettings))
			{
				Texture2D screenshot = ES3.LoadImage(imageSaveSettings);
				SetScreenshot(screenshot);
			}
		}

		public void AddPlayTime(float time)
		{
			PlayTime += time;
		}

		public void SetScreenshot(Texture2D image)
		{
			Screenshot = Sprite.Create(image, image.GetRect(), Vector2.one);
		}
	}
}
