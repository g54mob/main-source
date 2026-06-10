namespace ModIO
{
	public struct Result
	{
		internal uint code;

		internal uint code_api;

		public string message => null;

		public uint errorCode => 0u;

		public bool Succeeded()
		{
			return false;
		}

		public bool IsCancelled()
		{
			return false;
		}

		public bool IsInitializationError()
		{
			return false;
		}

		public bool IsAuthenticationError()
		{
			return false;
		}

		public bool IsInvalidSecurityCode()
		{
			return false;
		}

		public bool IsInvalidEmailAddress()
		{
			return false;
		}

		public bool IsPermissionError()
		{
			return false;
		}

		public bool IsNetworkError()
		{
			return false;
		}

		public bool IsStorageSpaceInsufficient()
		{
			return false;
		}
	}
}
