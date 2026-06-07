namespace Epic.OnlineServices.Sessions
{
	public class JoinSessionAcceptedCallbackInfo : ICallbackInfo, ISettable
	{
		public object ClientData { get; private set; }

		public ProductUserId LocalUserId { get; private set; }

		public ulong UiEventId { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(JoinSessionAcceptedCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
