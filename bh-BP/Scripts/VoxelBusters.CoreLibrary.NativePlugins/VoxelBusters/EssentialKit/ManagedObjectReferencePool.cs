using System.Collections.Generic;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	internal static class ManagedObjectReferencePool
	{
		[ClearOnReload]
		private static List<object> s_objectList;

		public static void Retain(object obj)
		{
		}

		public static void Release(object obj)
		{
		}

		private static void EnsureInitialized()
		{
		}
	}
}
