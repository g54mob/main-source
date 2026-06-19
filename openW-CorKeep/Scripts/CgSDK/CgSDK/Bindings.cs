using System.Runtime.InteropServices;

namespace CgSDK
{
	internal static class Bindings
	{
		[DllImport("CgSDK.x64_2019.dll")]
		internal unsafe static extern bool CgSdkSetState(byte* stateName);

		[DllImport("CgSDK.x64_2019.dll")]
		internal unsafe static extern bool CgSdkClearState(byte* stateName);

		[DllImport("CgSDK.x64_2019.dll")]
		internal unsafe static extern bool CgSdkSetStateWithKey(byte* stateName, LedId key);

		[DllImport("CgSDK.x64_2019.dll")]
		internal unsafe static extern bool CgSdkClearStateWithKey(byte* stateName, LedId key);

		[DllImport("CgSDK.x64_2019.dll")]
		internal static extern bool CgSdkClearAllStates();

		[DllImport("CgSDK.x64_2019.dll")]
		internal unsafe static extern bool CgSdkSetEvent(byte* eventName);

		[DllImport("CgSDK.x64_2019.dll")]
		internal unsafe static extern bool CgSdkSetEventWithKey(byte* eventName, LedId key);

		[DllImport("CgSDK.x64_2019.dll")]
		internal static extern bool CgSdkClearAllEvents();

		[DllImport("CgSDK.x64_2019.dll")]
		internal unsafe static extern bool CgSdkShowProgressBar(byte* progressBarName);

		[DllImport("CgSDK.x64_2019.dll")]
		internal unsafe static extern bool CgSdkSetProgressBarValue(byte* progressBarName, int value);

		[DllImport("CgSDK.x64_2019.dll")]
		internal unsafe static extern bool CgSdkHideProgressBar(byte* progressBarName);

		[DllImport("CgSDK.x64_2019.dll")]
		internal static extern ProtocolDetails CgSdkPerformProtocolHandshake();

		[DllImport("CgSDK.x64_2019.dll")]
		internal static extern Error CgSdkGetLastError();

		[DllImport("CgSDK.x64_2019.dll")]
		internal static extern bool CgSdkRequestControl();

		[DllImport("CgSDK.x64_2019.dll")]
		internal unsafe static extern bool CgSdkSetGame(byte* gameName);

		[DllImport("CgSDK.x64_2019.dll")]
		internal static extern bool CgSdkReleaseControl();
	}
}
