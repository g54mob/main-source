using UnityEngine;

namespace TMPEffects.SerializedCollections
{
	internal static class SerializedCollectionsUtility
	{
		public static bool IsValidKey(object obj)
		{
			try
			{
				return !(obj is Object obj2) || !(obj2 == null);
			}
			catch
			{
				return false;
			}
		}
	}
}
