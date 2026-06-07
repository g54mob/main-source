namespace XGamingRuntime
{
	public struct XblRealTimeActivityCallbackToken
	{
		public const int InvalidHandlerId = 0;

		public int InteropHandlerId;

		public void Reset()
		{
		}

		public bool IsValid()
		{
			return false;
		}

		public static bool IsValid(int interopHandlerId)
		{
			return false;
		}
	}
}
