namespace Jundroo.Common.Platform
{
	public interface IDevice
	{
		string DeviceCaps { get; }

		string DeviceId { get; }

		string DeviceModel { get; }

		string DeviceName { get; }

		float Dpi { get; }

		DeviceFlags Flags { get; }

		bool IsAndroidBuild { get; }

		bool IsAndroidRuntime { get; }

		bool IsAndroidVRBuild { get; }

		bool IsDebugBuild { get; }

		bool IsDemoBuild { get; }

		bool IsDesktopBuild { get; }

		bool IsEducationBuild { get; }

		bool IsIosBuild { get; }

		bool IsIosRuntime { get; }

		bool IsLinuxBuild { get; }

		bool IsLinuxRuntime { get; }

		bool IsMobileBuild { get; }

		bool IsMobileRuntime { get; }

		bool IsMultiTouchEnabled { get; }

		bool IsOculusQuest1 { get; }

		bool IsOculusQuestBuild { get; }

		bool IsOsxBuild { get; }

		bool IsOsxRuntime { get; }

		bool IsPCVRExclusiveBuild { get; }

		bool IsPicoXRBuild { get; }

		bool IsTablet { get; }

		bool IsTouchEnabled { get; }

		bool IsUnityEditor { get; }

		bool IsUnityEditorApplicationPaused { get; }

		bool IsVRBuild { get; }

		bool IsVRExclusiveBuild { get; }

		bool IsWindowsBuild { get; }

		bool IsWindowsRuntime { get; }

		bool HasAnyFlag(DeviceFlags flags);

		void ToggleTouchEnabled();
	}
}
