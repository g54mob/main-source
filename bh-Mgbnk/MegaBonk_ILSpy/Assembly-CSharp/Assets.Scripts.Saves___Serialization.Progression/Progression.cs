using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.Saves___Serialization.Progression.Challenges;
using Assets.Scripts.Saves___Serialization.Progression.Stats;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;

namespace Assets.Scripts.Saves___Serialization.Progression;

public static class Progression
{
	public static void Init()
	{
		MyStats.Init();
		MyAchievements.Init();
		AchievementTracker.Init();
		ChallengesTracker.Init();
		TrackStats.Init();
		RunUnlockables.Init();
	}

	public static void Cleanup()
	{
		MyStats.Cleanup();
		MyAchievements.Cleanup();
		AchievementTracker.Cleanup();
		ChallengesTracker.Cleanup();
		TrackStats.Init();
		RunUnlockables.Cleanup();
	}
}
