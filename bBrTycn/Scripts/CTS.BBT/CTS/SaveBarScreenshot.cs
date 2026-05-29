using CTS.Core;

namespace CTS
{
	public class SaveBarScreenshot : SaveContainer
	{
		private static ES3Settings _imageSaveSettings;

		public static ES3Settings GetImageSaveSettings()
		{
			if (_imageSaveSettings == null)
			{
				_imageSaveSettings = new ES3Settings();
			}
			_imageSaveSettings.location = ES3.Location.File;
			_imageSaveSettings.directory = ES3.Directory.PersistentDataPath;
			return _imageSaveSettings;
		}

		public static string GetImagePath(string profileName, MapInfoSO map)
		{
			return "Saves/" + profileName + "/" + map.name + ".png";
		}

		public override void Save(ES3Settings settings)
		{
			if (CTSSingleton<GameMode>.TryGetInstance(out var outInstance))
			{
				if (CTSSingleton<ProfileManager>.Instance.CurrentProfile is CareerProfile careerProfile)
				{
					careerProfile.SetScreenshot(outInstance.LevelInfo, CTSSingleton<BarScreenshot>.Instance.Texture2D);
					ES3Settings imageSaveSettings = GetImageSaveSettings();
					imageSaveSettings.path = GetImagePath(careerProfile.GetName(), outInstance.LevelInfo);
					ES3.SaveImage(CTSSingleton<BarScreenshot>.Instance.Texture2D, imageSaveSettings);
				}
				else if (CTSSingleton<ProfileManager>.Instance.CurrentProfile is FreemodeProfile freemodeProfile)
				{
					freemodeProfile.SetScreenshot(CTSSingleton<BarScreenshot>.Instance.Texture2D);
					ES3Settings imageSaveSettings2 = GetImageSaveSettings();
					imageSaveSettings2.path = GetImagePath(freemodeProfile.GetName(), outInstance.LevelInfo);
					ES3.SaveImage(CTSSingleton<BarScreenshot>.Instance.Texture2D, imageSaveSettings2);
				}
			}
		}

		public override void LoadInit(ES3Settings settings)
		{
		}

		public override void LoadPost(ES3Settings settings)
		{
		}
	}
}
