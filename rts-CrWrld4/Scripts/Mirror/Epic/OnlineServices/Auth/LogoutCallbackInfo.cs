namespace Epic.OnlineServices.Auth
{
	public class LogoutCallbackInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public object ClientData { get; private set; }

		public EpicAccountId LocalUserId { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(LogoutCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
