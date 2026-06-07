namespace Epic.OnlineServices.Ecom
{
	public class QueryOwnershipCallbackInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public object ClientData { get; private set; }

		public EpicAccountId LocalUserId { get; private set; }

		public ItemOwnership[] ItemOwnership { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(QueryOwnershipCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
