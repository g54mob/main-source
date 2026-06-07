namespace Epic.OnlineServices.Sessions
{
	public class RegisterPlayersCallbackInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public object ClientData { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(RegisterPlayersCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
