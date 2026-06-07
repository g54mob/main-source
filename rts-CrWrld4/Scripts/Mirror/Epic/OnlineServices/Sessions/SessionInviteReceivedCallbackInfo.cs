namespace Epic.OnlineServices.Sessions
{
	public class SessionInviteReceivedCallbackInfo : ICallbackInfo, ISettable
	{
		public object ClientData { get; private set; }

		public ProductUserId LocalUserId { get; private set; }

		public ProductUserId TargetUserId { get; private set; }

		public string InviteId { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(SessionInviteReceivedCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
