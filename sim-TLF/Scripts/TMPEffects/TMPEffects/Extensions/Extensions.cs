using UnityEngine;

namespace TMPEffects.Extensions
{
	public static class Extensions
	{
		internal static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
		{
			T val = gameObject.GetComponent<T>();
			if (val == null)
			{
				val = gameObject.AddComponent<T>();
			}
			return val;
		}
	}
}
