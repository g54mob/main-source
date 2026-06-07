namespace Epic.OnlineServices.PlayerDataStorage
{
	public class DeleteCacheCallbackInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public object ClientData { get; private set; }

		public ProductUserId LocalUserId { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(DeleteCacheCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
