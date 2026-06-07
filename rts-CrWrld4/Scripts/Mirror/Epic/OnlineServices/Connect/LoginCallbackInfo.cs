namespace Epic.OnlineServices.Connect
{
	public class LoginCallbackInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public object ClientData { get; private set; }

		public ProductUserId LocalUserId { get; private set; }

		public ContinuanceToken ContinuanceToken { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(LoginCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
