namespace Epic.OnlineServices.Auth
{
	public class DeletePersistentAuthCallbackInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public object ClientData { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(DeletePersistentAuthCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
