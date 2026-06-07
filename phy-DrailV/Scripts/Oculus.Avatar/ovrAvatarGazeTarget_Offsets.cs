using System.Runtime.InteropServices;
using UnityEngine;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct ovrAvatarGazeTarget_Offsets
{
	public static int id = 0;

	public static int worldPosition = Marshal.SizeOf(typeof(uint));

	public static int type = worldPosition + Marshal.SizeOf(typeof(Vector3));
}
