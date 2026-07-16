using UnityEngine;

namespace AudioSystem
{
	public static class GameObjectExtensions
	{
		public static T GetOrAdd<T>(this GameObject gameObject) where T : Component
		{
			T val = gameObject.GetComponent<T>();
			if (!val)
			{
				val = gameObject.AddComponent<T>();
			}
			return val;
		}

		public static GameObject AsGameObject(this object obj)
		{
			if (!(obj is GameObject result))
			{
				if (!(obj is Component { gameObject: var gameObject }))
				{
					return null;
				}
				return gameObject;
			}
			return result;
		}
	}
}
