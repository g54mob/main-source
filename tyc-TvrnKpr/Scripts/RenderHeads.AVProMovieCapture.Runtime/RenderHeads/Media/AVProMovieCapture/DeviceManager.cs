namespace RenderHeads.Media.AVProMovieCapture
{
	public static class DeviceManager
	{
		private static bool _isEnumerated;

		private static DeviceList _audioInputDevices;

		public static DeviceList AudioInputDevices => null;

		public static Device FindDevice(DeviceType deviceType, string name)
		{
			return null;
		}

		public static int GetDeviceCount(DeviceType deviceType)
		{
			return 0;
		}

		private static void CheckInit()
		{
		}

		private static DeviceList GetDevices(DeviceType deviceType)
		{
			return null;
		}

		private static void EnumerateDevices()
		{
		}
	}
}
