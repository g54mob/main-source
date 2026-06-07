namespace VRTK.WindowsMixedReality.Utilities
{
	public static class WindowsApiChecker
	{
		public static bool UniversalApiContractV5_IsAvailable { get; private set; }

		public static bool UniversalApiContractV4_IsAvailable { get; private set; }

		public static bool UniversalApiContractV3_IsAvailable { get; private set; }

		static WindowsApiChecker()
		{
			UniversalApiContractV5_IsAvailable = false;
			UniversalApiContractV4_IsAvailable = false;
			UniversalApiContractV3_IsAvailable = false;
		}
	}
}
