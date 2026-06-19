using ModIO.Implementation;

namespace ModIO
{
	public struct Result
	{
		internal uint code;

		internal uint code_api;

		public string message => ResultCode.GetErrorCodeMeaning(code);

		public uint errorCode => code;

		public bool Succeeded()
		{
			return code == 0;
		}

		public bool IsCancelled()
		{
			return code == 20506;
		}

		public bool IsInitializationError()
		{
			if (code != 20000)
			{
				return code == 20010;
			}
			return true;
		}

		public bool IsAuthenticationError()
		{
			if (code != 20100 && code != 20101 && code != 20102 && code != 20103)
			{
				return code_api == 11005;
			}
			return true;
		}

		public bool IsInvalidSecurityCode()
		{
			if (code_api != 11012)
			{
				return code_api == 11014;
			}
			return true;
		}

		public bool IsInvalidEmailAddress()
		{
			return code == 20102;
		}

		public bool IsPermissionError()
		{
			if (code != 403 && code_api != 11003 && code_api != 11004 && code_api != 15006)
			{
				return code_api == 15019;
			}
			return true;
		}

		public bool IsNetworkError()
		{
			return code == 20302;
		}

		public bool IsStorageSpaceInsufficient()
		{
			return code == 20442;
		}
	}
}
