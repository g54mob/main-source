namespace XGamingRuntime.Interop
{
	internal class HR
	{
		internal const int S_OK = 0;

		internal const int E_INVALIDARG = -2147024809;

		internal static bool SUCCEEDED(int hr)
		{
			return hr >= 0;
		}

		internal static bool FAILED(int hr)
		{
			return hr < 0;
		}
	}
}
