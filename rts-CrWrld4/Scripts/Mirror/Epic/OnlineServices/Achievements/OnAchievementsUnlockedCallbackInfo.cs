namespace Epic.OnlineServices.Achievements
{
	public class OnAchievementsUnlockedCallbackInfo : ICallbackInfo, ISettable
	{
		public object ClientData { get; private set; }

		public ProductUserId UserId { get; private set; }

		public string[] AchievementIds { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(OnAchievementsUnlockedCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
