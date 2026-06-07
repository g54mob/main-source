namespace Epic.OnlineServices.Connect
{
	public class LoginStatusChangedCallbackInfo : ICallbackInfo, ISettable
	{
		public object ClientData { get; private set; }

		public ProductUserId LocalUserId { get; private set; }

		public LoginStatus PreviousStatus { get; private set; }

		public LoginStatus CurrentStatus { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(LoginStatusChangedCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
