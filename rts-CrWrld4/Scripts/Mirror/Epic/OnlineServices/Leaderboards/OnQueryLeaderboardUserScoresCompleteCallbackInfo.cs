namespace Epic.OnlineServices.Leaderboards
{
	public class OnQueryLeaderboardUserScoresCompleteCallbackInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public object ClientData { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(OnQueryLeaderboardUserScoresCompleteCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
