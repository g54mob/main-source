using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct ovrAvatarComponent_Offsets
{
	public static long transform = Marshal.OffsetOf(typeof(ovrAvatarComponent), "transform").ToInt64();

	public static int renderPartCount = Marshal.OffsetOf(typeof(ovrAvatarComponent), "renderPartCount").ToInt32();

	public static int renderParts = Marshal.OffsetOf(typeof(ovrAvatarComponent), "renderParts").ToInt32();

	public static int name = Marshal.OffsetOf(typeof(ovrAvatarComponent), "name").ToInt32();
}
