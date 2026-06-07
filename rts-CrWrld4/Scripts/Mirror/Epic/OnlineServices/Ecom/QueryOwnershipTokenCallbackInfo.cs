namespace Epic.OnlineServices.Ecom
{
	public class QueryOwnershipTokenCallbackInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public object ClientData { get; private set; }

		public EpicAccountId LocalUserId { get; private set; }

		public string OwnershipToken { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(QueryOwnershipTokenCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
