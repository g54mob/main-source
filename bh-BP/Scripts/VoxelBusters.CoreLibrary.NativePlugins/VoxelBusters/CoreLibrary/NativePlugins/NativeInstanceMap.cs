using System;
using System.Collections.Generic;

namespace VoxelBusters.CoreLibrary.NativePlugins
{
	public static class NativeInstanceMap
	{
		[ClearOnReload]
		private static Dictionary<IntPtr, object> s_instanceMap;

		static NativeInstanceMap()
		{
		}

		public static void AddInstance(IntPtr nativePtr, object owner)
		{
		}

		public static bool RemoveInstance(IntPtr nativePtr)
		{
			return false;
		}

		public static T GetOwner<T>(IntPtr nativePtr) where T : class
		{
			return null;
		}

		[ExecuteOnReload]
		private static void Initialize()
		{
		}
	}
}
