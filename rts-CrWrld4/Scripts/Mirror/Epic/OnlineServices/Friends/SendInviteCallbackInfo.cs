namespace Epic.OnlineServices.Friends
{
	public class SendInviteCallbackInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public object ClientData { get; private set; }

		public EpicAccountId LocalUserId { get; private set; }

		public EpicAccountId TargetUserId { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(SendInviteCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
