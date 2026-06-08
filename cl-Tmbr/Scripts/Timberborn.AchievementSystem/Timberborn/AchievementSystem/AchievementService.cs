using System.Collections.Generic;
using System.Collections.Immutable;
using Timberborn.SingletonSystem;

namespace Timberborn.AchievementSystem
{
	internal class AchievementService : IPostLoadableSingleton
	{
		private readonly IStoreAchievements _storeAchievements;

		private readonly ImmutableArray<Achievement> _achievements;

		public AchievementService(IStoreAchievements storeAchievements, IEnumerable<Achievement> achievements)
		{
			_storeAchievements = storeAchievements;
			_achievements = achievements.ToImmutableArray();
		}

		public void PostLoad()
		{
			_storeAchievements.Initialize(EnableLockedAchievements);
		}

		private void EnableLockedAchievements()
		{
			foreach (Achievement achievement in GetLockedAchievements())
			{
				achievement.Enable(delegate
				{
					UnlockAchievement(achievement.Id);
				});
			}
		}

		private IEnumerable<Achievement> GetLockedAchievements()
		{
			ImmutableArray<Achievement>.Enumerator enumerator = _achievements.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Achievement current = enumerator.Current;
				if (!_storeAchievements.IsAchievementUnlocked(current.Id))
				{
					yield return current;
				}
			}
		}

		private void UnlockAchievement(string achievementId)
		{
			_storeAchievements.UnlockAchievement(achievementId);
		}
	}
}
