using System;
using System.Runtime.InteropServices;

namespace NAudio.CoreAudioApi.Interfaces
{
	[Guid("bfb7ff88-7239-4fc9-8fa2-07c950be9c6d")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioSessionControl2 : IAudioSessionControl
	{
		[PreserveSig]
		new int GetState(out AudioSessionState state);

		[PreserveSig]
		new int GetDisplayName(out string displayName);

		[PreserveSig]
		new int SetDisplayName([In] string displayName, [In] Guid eventContext);

		[PreserveSig]
		new int GetIconPath(out string iconPath);

		[PreserveSig]
		new int SetIconPath([In] string iconPath, [In] Guid eventContext);

		[PreserveSig]
		new int GetGroupingParam(out Guid groupingId);

		[PreserveSig]
		new int SetGroupingParam([In] Guid groupingId, [In] Guid eventContext);

		[PreserveSig]
		new int RegisterAudioSessionNotification([In] IAudioSessionEvents client);

		[PreserveSig]
		new int UnregisterAudioSessionNotification([In] IAudioSessionEvents client);

		[PreserveSig]
		int GetSessionIdentifier(out string retVal);

		[PreserveSig]
		int GetSessionInstanceIdentifier(out string retVal);

		[PreserveSig]
		int GetProcessId(out uint retVal);

		[PreserveSig]
		int IsSystemSoundsSession();

		[PreserveSig]
		int SetDuckingPreference(bool optOut);
	}
}
