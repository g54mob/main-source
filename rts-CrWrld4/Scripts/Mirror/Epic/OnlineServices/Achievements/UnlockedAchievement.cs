using System;

namespace Epic.OnlineServices.Achievements
{
	public class UnlockedAchievement : ISettable
	{
		public string AchievementId { get; set; }

		public DateTimeOffset? UnlockTime { get; set; }

		internal void Set(UnlockedAchievementInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
