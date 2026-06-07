using System;
using System.Runtime.InteropServices;

namespace NAudio.CoreAudioApi.Interfaces
{
	[Guid("87CE5498-68D6-44E5-9215-6DA47EF883D8")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	internal interface ISimpleAudioVolume
	{
		[PreserveSig]
		int SetMasterVolume([In] float levelNorm, [In] Guid eventContext);

		[PreserveSig]
		int GetMasterVolume(out float levelNorm);

		[PreserveSig]
		int SetMute([In] bool isMuted, [In] Guid eventContext);

		[PreserveSig]
		int GetMute(out bool isMuted);
	}
}
