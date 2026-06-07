using System;
using System.Runtime.InteropServices;

namespace NAudio.CoreAudioApi.Interfaces
{
	[Guid("24918ACC-64B3-37C1-8CA9-74A66E9957A8")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioSessionEvents
	{
		[PreserveSig]
		int OnDisplayNameChanged([In] string displayName, [In] ref Guid eventContext);

		[PreserveSig]
		int OnIconPathChanged([In] string iconPath, [In] ref Guid eventContext);

		[PreserveSig]
		int OnSimpleVolumeChanged([In] float volume, [In] bool isMuted, [In] ref Guid eventContext);

		[PreserveSig]
		int OnChannelVolumeChanged([In] uint channelCount, [In] IntPtr newVolumes, [In] uint channelIndex, [In] ref Guid eventContext);

		[PreserveSig]
		int OnGroupingParamChanged([In] ref Guid groupingId, [In] ref Guid eventContext);

		[PreserveSig]
		int OnStateChanged([In] AudioSessionState state);

		[PreserveSig]
		int OnSessionDisconnected([In] AudioSessionDisconnectReason disconnectReason);
	}
}
