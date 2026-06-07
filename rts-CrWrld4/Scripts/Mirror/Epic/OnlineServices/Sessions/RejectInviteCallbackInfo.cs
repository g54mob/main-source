namespace Epic.OnlineServices.Sessions
{
	public class RejectInviteCallbackInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public object ClientData { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(RejectInviteCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
