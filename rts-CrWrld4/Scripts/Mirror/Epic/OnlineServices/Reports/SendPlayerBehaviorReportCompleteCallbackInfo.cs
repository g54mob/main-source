namespace Epic.OnlineServices.Reports
{
	public class SendPlayerBehaviorReportCompleteCallbackInfo : ICallbackInfo, ISettable
	{
		public Result ResultCode { get; private set; }

		public object ClientData { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(SendPlayerBehaviorReportCompleteCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
