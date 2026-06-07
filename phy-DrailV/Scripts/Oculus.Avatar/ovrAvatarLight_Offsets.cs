using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct ovrAvatarLight_Offsets
{
	public static long id = Marshal.OffsetOf(typeof(ovrAvatarLight), "id").ToInt64();

	public static long type = Marshal.OffsetOf(typeof(ovrAvatarLight), "type").ToInt64();

	public static long intensity = Marshal.OffsetOf(typeof(ovrAvatarLight), "intensity").ToInt64();

	public static long worldDirection = Marshal.OffsetOf(typeof(ovrAvatarLight), "worldDirection").ToInt64();

	public static long worldPosition = Marshal.OffsetOf(typeof(ovrAvatarLight), "worldPosition").ToInt64();

	public static long range = Marshal.OffsetOf(typeof(ovrAvatarLight), "range").ToInt64();

	public static long spotAngleDeg = Marshal.OffsetOf(typeof(ovrAvatarLight), "spotAngleDeg").ToInt64();
}
