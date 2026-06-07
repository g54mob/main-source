using System;
using System.Runtime.InteropServices;

namespace NAudio.CoreAudioApi.Interfaces
{
	internal class PropVariantNative
	{
		[PreserveSig]
		internal static extern int PropVariantClear(ref PropVariant pvar);

		[PreserveSig]
		internal static extern int PropVariantClear(IntPtr pvar);
	}
}
