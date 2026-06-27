using Restory.Data.Achievements;
using UnityEngine;
using Zenject;

namespace Restory.Achievements
{
	public sealed class AchievementUnlocker : MonoBehaviour
	{
		[SerializeField]
		private Achievement achievement;

		private AchievementsManager achievementsManager;

		public Achievement Achievement => achievement;

		[Inject]
		public void Construct(AchievementsManager achievementsManager)
		{
			this.achievementsManager = achievementsManager;
		}

		public void AddAchievementProgress(float delta)
		{
			achievementsManager.AddProgressAchievement(achievement, delta);
		}

		public void SetAchievementProgress(float value)
		{
			achievementsManager.SetProgressAchievement(achievement, value);
		}

		public void UnlockAchievement()
		{
			achievementsManager.UnlockAchievement(achievement);
		}
	}
}
