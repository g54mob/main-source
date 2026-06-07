namespace Epic.OnlineServices.Auth
{
	public class LinkAccountCallbackInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public object ClientData { get; private set; }

		public EpicAccountId LocalUserId { get; private set; }

		public PinGrantInfo PinGrantInfo { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(LinkAccountCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
