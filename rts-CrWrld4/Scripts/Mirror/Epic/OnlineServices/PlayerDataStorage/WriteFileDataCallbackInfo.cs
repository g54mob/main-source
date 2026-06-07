namespace Epic.OnlineServices.PlayerDataStorage
{
	public class WriteFileDataCallbackInfo : ICallbackInfo, ISettable
	{
		public object ClientData { get; private set; }

		public ProductUserId LocalUserId { get; private set; }

		public string Filename { get; private set; }

		public uint DataBufferLengthBytes { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(WriteFileDataCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
