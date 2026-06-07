namespace Epic.OnlineServices.Connect
{
	public class AuthExpirationCallbackInfo : ICallbackInfo, ISettable
	{
		public object ClientData { get; private set; }

		public ProductUserId LocalUserId { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(AuthExpirationCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
