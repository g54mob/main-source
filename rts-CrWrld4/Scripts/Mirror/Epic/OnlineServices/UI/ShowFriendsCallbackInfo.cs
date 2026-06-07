namespace Epic.OnlineServices.UI
{
	public class ShowFriendsCallbackInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public object ClientData { get; private set; }

		public EpicAccountId LocalUserId { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(ShowFriendsCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
