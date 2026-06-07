using System.Runtime.InteropServices;

public struct ovrAvatarGazeTargets
{
	public uint targetCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public ovrAvatarGazeTarget[] targets;
}
