using System.Runtime.InteropServices;

public struct ovrAvatarBlendShapeParams
{
	public uint blendShapeParamCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public float[] blendShapeParams;
}
