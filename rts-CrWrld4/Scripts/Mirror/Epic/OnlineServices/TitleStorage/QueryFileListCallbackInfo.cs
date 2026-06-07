namespace Epic.OnlineServices.TitleStorage
{
	public class QueryFileListCallbackInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public object ClientData { get; private set; }

		public ProductUserId LocalUserId { get; private set; }

		public uint FileCount { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(QueryFileListCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
