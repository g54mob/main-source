using System;

namespace VoxelBusters.CoreLibrary
{
	public static class ObjectHelper
	{
		public static T CreateInstanceIfNull<T>(ref T reference, Func<T> createFunc) where T : class
		{
			return null;
		}
	}
}
