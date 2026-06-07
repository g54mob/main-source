using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct ovrAvatarVisemes_Offsets
{
	public static int visemeParamCount = Marshal.OffsetOf(typeof(ovrAvatarVisemes), "visemeParamCount").ToInt32();

	public static long visemeParams = Marshal.SizeOf(typeof(uint));
}
