using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	protected static T instance;

	public static T Instance
	{
		get
		{
			if (instance == null)
			{
				instance = (T)Object.FindObjectOfType(typeof(T));
				if (instance == null)
				{
					Debug.LogError(string.Concat("An instance of ", typeof(T), " is needed in the scene, but there is none."));
				}
			}
			return instance;
		}
	}

	public static bool Exist
	{
		get
		{
			if (instance == null)
			{
				instance = (T)Object.FindObjectOfType(typeof(T));
				if (instance == null)
				{
					return false;
				}
			}
			return true;
		}
	}
}
