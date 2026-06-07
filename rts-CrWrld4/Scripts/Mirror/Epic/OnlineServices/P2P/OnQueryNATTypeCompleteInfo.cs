namespace Epic.OnlineServices.P2P
{
	public class OnQueryNATTypeCompleteInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public object ClientData { get; private set; }

		public NATType NATType { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(OnQueryNATTypeCompleteInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
