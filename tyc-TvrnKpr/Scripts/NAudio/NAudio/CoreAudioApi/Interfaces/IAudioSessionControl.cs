using System;
using System.Runtime.InteropServices;

namespace NAudio.CoreAudioApi.Interfaces
{
	[Guid("F4B1A599-7266-4319-A8CA-E70ACB11E8CD")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioSessionControl
	{
		[PreserveSig]
		int GetState(out AudioSessionState state);

		[PreserveSig]
		int GetDisplayName(out string displayName);

		[PreserveSig]
		int SetDisplayName([In] string displayName, [In] Guid eventContext);

		[PreserveSig]
		int GetIconPath(out string iconPath);

		[PreserveSig]
		int SetIconPath([In] string iconPath, [In] Guid eventContext);

		[PreserveSig]
		int GetGroupingParam(out Guid groupingId);

		[PreserveSig]
		int SetGroupingParam([In] Guid groupingId, [In] Guid eventContext);

		[PreserveSig]
		int RegisterAudioSessionNotification([In] IAudioSessionEvents client);

		[PreserveSig]
		int UnregisterAudioSessionNotification([In] IAudioSessionEvents client);
	}
}
