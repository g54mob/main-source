namespace Epic.OnlineServices.Achievements
{
	public class OnUnlockAchievementsCompleteCallbackInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public object ClientData { get; private set; }

		public ProductUserId UserId { get; private set; }

		public uint AchievementsCount { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(OnUnlockAchievementsCompleteCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
