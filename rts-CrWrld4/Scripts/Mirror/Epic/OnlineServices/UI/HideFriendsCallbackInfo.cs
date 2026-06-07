namespace Epic.OnlineServices.UI
{
	public class HideFriendsCallbackInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public object ClientData { get; private set; }

		public EpicAccountId LocalUserId { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(HideFriendsCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
