namespace Epic.OnlineServices.Stats
{
	public class IngestStatCompleteCallbackInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public object ClientData { get; private set; }

		public ProductUserId LocalUserId { get; private set; }

		public ProductUserId TargetUserId { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(IngestStatCompleteCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
