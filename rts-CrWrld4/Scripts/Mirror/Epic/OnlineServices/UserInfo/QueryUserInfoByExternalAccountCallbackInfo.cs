namespace Epic.OnlineServices.UserInfo
{
	public class QueryUserInfoByExternalAccountCallbackInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public object ClientData { get; private set; }

		public EpicAccountId LocalUserId { get; private set; }

		public string ExternalAccountId { get; private set; }

		public ExternalAccountType AccountType { get; private set; }

		public EpicAccountId TargetUserId { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(QueryUserInfoByExternalAccountCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
