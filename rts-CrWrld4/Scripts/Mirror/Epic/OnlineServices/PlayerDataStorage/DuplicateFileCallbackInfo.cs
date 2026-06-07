namespace Epic.OnlineServices.PlayerDataStorage
{
	public class DuplicateFileCallbackInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public object ClientData { get; private set; }

		public ProductUserId LocalUserId { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(DuplicateFileCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
