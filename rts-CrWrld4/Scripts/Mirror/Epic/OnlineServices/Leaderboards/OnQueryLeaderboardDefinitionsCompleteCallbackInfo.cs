namespace Epic.OnlineServices.Leaderboards
{
	public class OnQueryLeaderboardDefinitionsCompleteCallbackInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public object ClientData { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(OnQueryLeaderboardDefinitionsCompleteCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
