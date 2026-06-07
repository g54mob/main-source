namespace Epic.OnlineServices.Mods
{
	public class InstallModCallbackInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public EpicAccountId LocalUserId { get; private set; }

		public object ClientData { get; private set; }

		public ModIdentifier Mod { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(InstallModCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
