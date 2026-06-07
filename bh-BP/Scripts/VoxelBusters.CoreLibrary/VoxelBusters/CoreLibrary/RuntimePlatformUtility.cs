using UnityEngine;

namespace VoxelBusters.CoreLibrary
{
	public static class RuntimePlatformUtility
	{
		public static bool IsEditor(this RuntimePlatform other)
		{
			return false;
		}
	}
}
