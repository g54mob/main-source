namespace Epic.OnlineServices.Achievements
{
	public class OnQueryPlayerAchievementsCompleteCallbackInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public object ClientData { get; private set; }

		public ProductUserId UserId { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(OnQueryPlayerAchievementsCompleteCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
