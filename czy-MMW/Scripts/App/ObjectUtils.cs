using UnityEngine;

public static class ObjectUtils
{
	public static bool IsNullOrDestroyed<T>(T obj)
	{
		if (obj != null)
		{
			if (obj is Object obj2)
			{
				return obj2 == null;
			}
			return false;
		}
		return true;
	}
}
