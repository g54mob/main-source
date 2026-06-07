namespace Epic.OnlineServices.Sanctions
{
	public class QueryActivePlayerSanctionsCallbackInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public object ClientData { get; private set; }

		public ProductUserId TargetUserId { get; private set; }

		public ProductUserId LocalUserId { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(QueryActivePlayerSanctionsCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
