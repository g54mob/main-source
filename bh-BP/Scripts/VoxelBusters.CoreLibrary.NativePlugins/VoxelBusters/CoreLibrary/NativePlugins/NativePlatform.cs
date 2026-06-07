using System;

namespace VoxelBusters.CoreLibrary.NativePlugins
{
	[Flags]
	public enum NativePlatform
	{
		Unknown = 0,
		iOS = 1,
		tvOS = 2,
		Android = 4,
		All = 7
	}
}
