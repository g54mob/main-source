namespace Epic.OnlineServices.Connect
{
	public class DeleteDeviceIdCallbackInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public object ClientData { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(DeleteDeviceIdCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
