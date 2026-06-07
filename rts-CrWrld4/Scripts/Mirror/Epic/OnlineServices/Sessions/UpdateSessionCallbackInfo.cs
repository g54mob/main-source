namespace Epic.OnlineServices.Sessions
{
	public class UpdateSessionCallbackInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public object ClientData { get; private set; }

		public string SessionName { get; private set; }

		public string SessionId { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(UpdateSessionCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
