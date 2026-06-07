using System.Collections.Generic;
using Assets.Scripts.Craft;
using Jundroo.SocialPlatforms;
using Jundroo.SocialPlatforms.Achievements;

namespace Assets.Scripts.Achievements
{
	internal static class AchievementHelper
	{
		private static bool? _cheater;

		private static List<string> _combatTrainingLevelIds = new List<string> { "LevelGunTraining", "LevelRocketTraining", "LevelBombTraining", "LevelMissileTraining" };

		private static bool? _complicatedDesign;

		private static AchievementInfo _dogfightAceAchievementInfo;

		private static AchievementInfo _dogfightAceOfAcesAchievementInfo;

		private static bool? _selfInflictedGunshot;

		private static List<string> _trainingLevelIds = new List<string> { "DesignerTutorial", "TrainingGroundSchool", "TrainingWeapons", "TutLanding", "TutFirstSolo" };

		public static void CheckComplicatedDesign(AircraftScript aircraft)
		{
		}

		public static void OnAircraftAttacked(AircraftScript victim, AircraftScript attacker)
		{
		}

		public static void OnLevelCompleted(string levelId)
		{
		}

		public static void UnlockAchievement(AchievementKey key)
		{
		}

		internal static void IncrementDesignTime(float hours)
		{
		}

		internal static void IncrementDogfightKills()
		{
		}

		internal static void IncrementFlightTime(float flightHours)
		{
		}

		internal static void OnSelfInflictedGunshot(AircraftScript aircraft)
		{
		}

		private static void CheckAllCombatTraining()
		{
		}

		private static void CheckAllTraining()
		{
		}

		private static bool ShouldShowDesignHoursProgress(AchievementInfo achievementInfo, Achievement achievement, double previousStatValue, double newStatValue)
		{
			return false;
		}

		private static bool ShouldShowDogfightKillProgress(AchievementInfo achievementInfo, IAchievement achievement, double oldKillCount, double newKillCount)
		{
			return newKillCount % 25.0 == 0.0;
		}

		private static bool ShouldShowFlightHoursProgress(AchievementInfo achievementInfo, Achievement achievement, double previousStatValue, double newStatValue)
		{
			return false;
		}
	}
}
