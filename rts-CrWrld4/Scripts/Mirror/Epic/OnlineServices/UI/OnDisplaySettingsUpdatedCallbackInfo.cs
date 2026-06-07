namespace Epic.OnlineServices.UI
{
	public class OnDisplaySettingsUpdatedCallbackInfo : ICallbackInfo, ISettable
	{
		public object ClientData { get; private set; }

		public bool IsVisible { get; private set; }

		public bool IsExclusiveInput { get; private set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(OnDisplaySettingsUpdatedCallbackInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
