namespace NAudio.CoreAudioApi.Interfaces
{
	internal static class ErrorCodes
	{
		public const int SEVERITY_ERROR = 1;

		public const int FACILITY_AUDCLNT = 2185;

		public static readonly int AUDCLNT_E_NOT_INITIALIZED;

		public static readonly int AUDCLNT_E_ALREADY_INITIALIZED;

		public static readonly int AUDCLNT_E_WRONG_ENDPOINT_TYPE;

		public static readonly int AUDCLNT_E_DEVICE_INVALIDATED;

		public static readonly int AUDCLNT_E_NOT_STOPPED;

		public static readonly int AUDCLNT_E_BUFFER_TOO_LARGE;

		public static readonly int AUDCLNT_E_OUT_OF_ORDER;

		public static readonly int AUDCLNT_E_UNSUPPORTED_FORMAT;

		public static readonly int AUDCLNT_E_INVALID_SIZE;

		public static readonly int AUDCLNT_E_DEVICE_IN_USE;

		public static readonly int AUDCLNT_E_BUFFER_OPERATION_PENDING;

		public static readonly int AUDCLNT_E_THREAD_NOT_REGISTERED;

		public static readonly int AUDCLNT_E_EXCLUSIVE_MODE_NOT_ALLOWED;

		public static readonly int AUDCLNT_E_ENDPOINT_CREATE_FAILED;

		public static readonly int AUDCLNT_E_SERVICE_NOT_RUNNING;

		public static readonly int AUDCLNT_E_EVENTHANDLE_NOT_EXPECTED;

		public static readonly int AUDCLNT_E_EXCLUSIVE_MODE_ONLY;

		public static readonly int AUDCLNT_E_BUFDURATION_PERIOD_NOT_EQUAL;

		public static readonly int AUDCLNT_E_EVENTHANDLE_NOT_SET;

		public static readonly int AUDCLNT_E_INCORRECT_BUFFER_SIZE;

		public static readonly int AUDCLNT_E_BUFFER_SIZE_ERROR;

		public static readonly int AUDCLNT_E_CPUUSAGE_EXCEEDED;

		public static readonly int AUDCLNT_E_RESOURCES_INVALIDATED;
	}
}
