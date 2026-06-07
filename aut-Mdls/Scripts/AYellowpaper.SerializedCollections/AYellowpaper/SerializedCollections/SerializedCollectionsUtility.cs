using UnityEngine;

namespace AYellowpaper.SerializedCollections
{
	public static class SerializedCollectionsUtility
	{
		public static bool IsValidKey(object obj)
		{
			try
			{
				return obj != null && (!(obj is Object obj2) || !(obj2 == null));
			}
			catch
			{
				return false;
			}
		}

		public static bool KeysAreEqual<T>(T key, object otherKey)
		{
			if ((object)key != otherKey)
			{
				return key.Equals(otherKey);
			}
			return true;
		}
	}
}
