namespace Epic.OnlineServices.Mods
{
	public class EnumerateModsCallbackInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public EpicAccountId LocalUserId { get; private set; }

		public object ClientData { get; private set; }

		public ModEnumerationType Type { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(EnumerateModsCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
