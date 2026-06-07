namespace ModApi
{
	public interface IDevice
	{
		string DeviceCaps { get; }

		string DeviceId { get; }

		string DeviceModel { get; }

		string DeviceName { get; }

		float Dpi { get; }

		bool IsAndroidBuild { get; }

		bool IsAndroidRuntime { get; }

		bool IsDebugBuild { get; }

		bool IsEducationBuild { get; }

		bool IsFreemiumBuild { get; }

		bool IsIosBuild { get; }

		bool IsIosRuntime { get; }

		bool IsLinuxBuild { get; }

		bool IsLinuxRuntime { get; }

		bool IsMobileBuild { get; }

		bool IsMobileRuntime { get; }

		bool IsMultiTouchEnabled { get; }

		bool IsOsxBuild { get; }

		bool IsOsxRuntime { get; }

		bool IsTablet { get; }

		bool IsTouchEnabled { get; }

		bool IsUnityEditor { get; }

		bool IsWindowsBuild { get; }

		bool IsWindowsRuntime { get; }
	}
}
