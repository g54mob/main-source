namespace ShellFileDialogs
{
	internal static class HResults
	{
		public static readonly HResult Cancelled;

		private const uint _codeBitMask = 65535u;

		private const uint _facilityBitMask = 134152192u;

		private const uint _reserveXBitMask = 134217728u;

		private const uint _ntStatusBitMask = 268435456u;

		private const uint _customerBitMask = 536870912u;

		private const uint _reservedBitMask = 1073741824u;

		private const uint _severityBitMask = 2147483648u;

		public static HResult CreateWin32(Win32ErrorCodes code)
		{
			return default(HResult);
		}

		public static HResult Create(bool isFailure, bool isCustomer, HResultFacility facility, ushort code)
		{
			return default(HResult);
		}

		public static HResultSeverity GetSeverity(this HResult hr)
		{
			return default(HResultSeverity);
		}

		public static HResultCustomer GetCustomer(this HResult hr)
		{
			return default(HResultCustomer);
		}

		public static HResultFacility GetFacility(this HResult hr)
		{
			return default(HResultFacility);
		}

		public static ushort GetCode(this HResult hr)
		{
			return 0;
		}

		public static bool IsValidHResult(this HResult hr)
		{
			return false;
		}

		public static bool TryGetWin32ErrorCode(this HResult hr, out Win32ErrorCodes win32Code)
		{
			win32Code = default(Win32ErrorCodes);
			return false;
		}
	}
}
