namespace Epic.OnlineServices.Ecom
{
	public class RedeemEntitlementsCallbackInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public object ClientData { get; private set; }

		public EpicAccountId LocalUserId { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(RedeemEntitlementsCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
