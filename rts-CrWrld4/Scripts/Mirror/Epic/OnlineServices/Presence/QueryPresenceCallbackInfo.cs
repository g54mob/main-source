namespace Epic.OnlineServices.Presence
{
	public class QueryPresenceCallbackInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public object ClientData { get; private set; }

		public EpicAccountId LocalUserId { get; private set; }

		public EpicAccountId TargetUserId { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(QueryPresenceCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
