using System;
using VampireSurvivors.Achievements;
using VampireSurvivors.Objects;

namespace VampireSurvivors.App.Scripts.Framework.Initialisation
{
	public static class PlatformIntegration
	{
		public static void Init(PlayerOptions playerOptions, AchievementManager achievementManager, Action onComplete)
		{
		}

		private static void LicenseCheckDlc(Action onComplete)
		{
		}

		private static void UpdateDlc(Action onComplete)
		{
		}

		private static void CheckSelectedDLCs(Action onComplete)
		{
		}

		private static void LoadDlc(Action onComplete)
		{
		}

		private static void SignIn(Action onComplete, Action onError)
		{
		}

		private static void InitStorage(Action onComplete, Action onError)
		{
		}

		private static void Load(PlayerOptions playerOptions, Action onComplete, Action onError)
		{
		}

		private static void HandleSaveDataCorruptedDialog(Action onComplete)
		{
		}

		private static void SetCurrentLanguageCode()
		{
		}

		private static void HandleNoFreeSpaceWhenLoading(PlayerOptions playerOptions, Action onComplete, Action onError)
		{
		}

		private static void ShowInternalNoFreeSpaceDialog(PlayerOptions playerOptions, Action button1Callback, Action button2Callback)
		{
		}

		private static void SyncAchievements(PlayerOptions playerOptions, AchievementManager achievementManager)
		{
		}

		private static void FireProgressUpdate(string term, bool isTerm = true)
		{
		}
	}
}
