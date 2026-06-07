using System;

namespace VoxelBusters.CoreLibrary.NativePlugins
{
	[Obsolete("This class is deprecated. Instead use RuntimePlatformConstantUtility.", true)]
	public static class PlatformConstantUtility
	{
		public static PlatformConstant FindConstantForActivePlatform(PlatformConstant[] array)
		{
			return null;
		}

		public static PlatformConstant FindConstantForPlatform(PlatformConstant[] array, NativePlatform platform)
		{
			return null;
		}

		public static string GetActivePlatformConstantValue(PlatformConstant[] array)
		{
			return null;
		}

		public static string GetPlatformConstantValue(PlatformConstant[] array, NativePlatform platform)
		{
			return null;
		}
	}
}
