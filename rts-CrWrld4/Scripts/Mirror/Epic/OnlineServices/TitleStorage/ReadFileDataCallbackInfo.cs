namespace Epic.OnlineServices.TitleStorage
{
	public class ReadFileDataCallbackInfo : ICallbackInfo, ISettable
	{
		public object ClientData { get; private set; }

		public ProductUserId LocalUserId { get; private set; }

		public string Filename { get; private set; }

		public uint TotalFileSizeBytes { get; private set; }

		public bool IsLastChunk { get; private set; }

		public byte[] DataChunk { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(ReadFileDataCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
