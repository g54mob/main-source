namespace Epic.OnlineServices.Connect
{
	public class CreateDeviceIdCallbackInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public object ClientData { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(CreateDeviceIdCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
