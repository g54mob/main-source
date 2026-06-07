namespace Epic.OnlineServices.Sessions
{
	public class DestroySessionCallbackInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public object ClientData { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(DestroySessionCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
