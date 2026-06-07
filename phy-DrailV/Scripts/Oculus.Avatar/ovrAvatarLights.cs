using System.Runtime.InteropServices;

public struct ovrAvatarLights
{
	public float ambientIntensity;

	public uint lightCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public ovrAvatarLight[] lights;
}
