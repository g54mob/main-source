namespace Epic.OnlineServices.Auth
{
	public class VerifyUserAuthCallbackInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public object ClientData { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(VerifyUserAuthCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
