namespace Epic.OnlineServices.Sessions
{
	public class QueryInvitesCallbackInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public object ClientData { get; private set; }

		public ProductUserId LocalUserId { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(QueryInvitesCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
