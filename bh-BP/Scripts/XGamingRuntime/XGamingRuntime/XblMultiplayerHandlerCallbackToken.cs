using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public struct XblMultiplayerHandlerCallbackToken
	{
		public const int InvalidHandlerId = 0;

		public XblFunctionContext FunctionContext;

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
