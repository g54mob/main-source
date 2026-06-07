namespace Epic.OnlineServices.Presence
{
	public class PresenceChangedCallbackInfo : ICallbackInfo, ISettable
	{
		public object ClientData { get; private set; }

		public EpicAccountId LocalUserId { get; private set; }

		public EpicAccountId PresenceUserId { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(PresenceChangedCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
