using System;
using System.Runtime.InteropServices;

namespace NAudio.CoreAudioApi.Interfaces
{
	[Guid("BFA971F1-4D5E-40BB-935E-967039BFBEE4")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	internal interface IAudioSessionManager
	{
		[PreserveSig]
		int GetAudioSessionControl([Optional][In] Guid sessionId, [In] uint streamFlags, out IAudioSessionControl sessionControl);

		[PreserveSig]
		int GetSimpleAudioVolume([Optional][In] Guid sessionId, [In] uint streamFlags, out ISimpleAudioVolume audioVolume);
	}
}
