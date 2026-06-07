using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct ovrAvatarLights_Offsets
{
	public static long ambientIntensity = Marshal.OffsetOf(typeof(ovrAvatarLights), "ambientIntensity").ToInt64();

	public static long lightCount = Marshal.OffsetOf(typeof(ovrAvatarLights), "lightCount").ToInt64();

	public static long lights = Marshal.OffsetOf(typeof(ovrAvatarLights), "lights").ToInt64();
}
