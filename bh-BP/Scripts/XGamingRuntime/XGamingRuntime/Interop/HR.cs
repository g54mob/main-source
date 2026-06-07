namespace XGamingRuntime.Interop
{
	public class HR
	{
		public const int S_OK = 0;

		public const int E_INVALIDARG = -2147024809;

		public const int E_GS_USER_CANCELED = -2138898428;

		public const int E_GS_BLOB_NOT_FOUND = -2138898424;

		public const int E_GS_UPDATE_TOO_BIG = -2138898427;

		public const int E_GS_HANDLE_EXPIRED = -2138898419;

		public static bool SUCCEEDED(int hr)
		{
			return false;
		}

		public static bool FAILED(int hr)
		{
			return false;
		}
	}
}
