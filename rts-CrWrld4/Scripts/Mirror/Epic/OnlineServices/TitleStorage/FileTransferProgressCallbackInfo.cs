namespace Epic.OnlineServices.TitleStorage
{
	public class FileTransferProgressCallbackInfo : ICallbackInfo, ISettable
	{
		public object ClientData { get; private set; }

		public ProductUserId LocalUserId { get; private set; }

		public string Filename { get; private set; }

		public uint BytesTransferred { get; private set; }

		public uint TotalFileSizeBytes { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(FileTransferProgressCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
