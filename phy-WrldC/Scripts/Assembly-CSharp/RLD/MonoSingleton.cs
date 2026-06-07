using UnityEngine;

namespace RLD
{
	public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		private static object _singletonLock = new object();

		private static T _instance;

		public static T Get
		{
			get
			{
				if (_instance == null)
				{
					lock (_singletonLock)
					{
						T[] array = Object.FindObjectsOfType(typeof(T)) as T[];
						if (array.Length == 0)
						{
							return null;
						}
						if (array.Length > 1)
						{
							if (Application.isEditor)
							{
								Debug.LogWarning("MonoSingleton<T>.Instance: Only 1 singleton instance can exist in the scene. Null will be returned.");
							}
							return null;
						}
						_instance = array[0];
					}
				}
				return _instance;
			}
		}
	}
}
