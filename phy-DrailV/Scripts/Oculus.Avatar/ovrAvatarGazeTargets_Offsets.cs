using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct ovrAvatarGazeTargets_Offsets
{
	public static int targetCount = Marshal.OffsetOf(typeof(ovrAvatarGazeTargets), "targetCount").ToInt32();

	public static long targets = Marshal.SizeOf(typeof(uint));
}
