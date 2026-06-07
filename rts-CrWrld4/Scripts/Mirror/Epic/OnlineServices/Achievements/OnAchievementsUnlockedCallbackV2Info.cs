using System;

namespace Epic.OnlineServices.Achievements
{
	public class OnAchievementsUnlockedCallbackV2Info : ICallbackInfo, ISettable
	{
		public object ClientData { get; private set; }

		public ProductUserId UserId { get; private set; }

		public string AchievementId { get; private set; }

		public DateTimeOffset? UnlockTime { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(OnAchievementsUnlockedCallbackV2InfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
