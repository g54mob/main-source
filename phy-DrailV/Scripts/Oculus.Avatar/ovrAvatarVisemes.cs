using System.Runtime.InteropServices;

public struct ovrAvatarVisemes
{
	public uint visemeParamCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public float[] visemeParams;
}
