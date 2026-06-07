using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct ovrAvatarBodyComponent_Offsets
{
	public static long leftEyeTransform = Marshal.OffsetOf(typeof(ovrAvatarBodyComponent), "leftEyeTransform").ToInt64();

	public static long rightEyeTransform = Marshal.OffsetOf(typeof(ovrAvatarBodyComponent), "rightEyeTransform").ToInt64();

	public static long centerEyeTransform = Marshal.OffsetOf(typeof(ovrAvatarBodyComponent), "centerEyeTransform").ToInt64();

	public static long renderComponent = Marshal.OffsetOf(typeof(ovrAvatarBodyComponent), "renderComponent").ToInt64();
}
