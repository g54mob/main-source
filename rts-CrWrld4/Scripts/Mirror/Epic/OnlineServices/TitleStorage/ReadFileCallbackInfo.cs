namespace Epic.OnlineServices.TitleStorage
{
	public class ReadFileCallbackInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public object ClientData { get; private set; }

		public ProductUserId LocalUserId { get; private set; }

		public string Filename { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(ReadFileCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
