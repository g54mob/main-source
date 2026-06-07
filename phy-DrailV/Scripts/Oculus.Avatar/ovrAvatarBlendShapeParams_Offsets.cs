using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct ovrAvatarBlendShapeParams_Offsets
{
	public static int blendShapeParamCount = Marshal.OffsetOf(typeof(ovrAvatarBlendShapeParams), "blendShapeParamCount").ToInt32();

	public static long blendShapeParams = Marshal.SizeOf(typeof(uint));
}
