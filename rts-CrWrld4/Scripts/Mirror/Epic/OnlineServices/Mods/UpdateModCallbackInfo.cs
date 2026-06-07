namespace Epic.OnlineServices.Mods
{
	public class UpdateModCallbackInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public EpicAccountId LocalUserId { get; private set; }

		public object ClientData { get; private set; }

		public ModIdentifier Mod { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(UpdateModCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
