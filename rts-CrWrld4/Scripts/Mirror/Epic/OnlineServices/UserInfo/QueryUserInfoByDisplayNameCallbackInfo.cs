namespace Epic.OnlineServices.UserInfo
{
	public class QueryUserInfoByDisplayNameCallbackInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public object ClientData { get; private set; }

		public EpicAccountId LocalUserId { get; private set; }

		public EpicAccountId TargetUserId { get; private set; }

		public string DisplayName { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(QueryUserInfoByDisplayNameCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
