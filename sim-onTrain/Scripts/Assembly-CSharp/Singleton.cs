using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T _instance;

	private static object _lock = new object();

	public static T Instance
	{
		get
		{
			lock (_lock)
			{
				if (_instance == null)
				{
					Object[] array = Object.FindObjectsOfType(typeof(T));
					if (array.Length > 1)
					{
						Debug.LogWarning($"[Singleton] Multiple instances of {typeof(T).Name} found ({array.Length}). Keeping first, destroying others.");
						_instance = (T)array[0];
						for (int i = 1; i < array.Length; i++)
						{
							Object.Destroy(((MonoBehaviour)array[i]).gameObject);
						}
					}
					else if (array.Length == 1)
					{
						_instance = (T)array[0];
					}
				}
				return _instance;
			}
		}
	}
}
