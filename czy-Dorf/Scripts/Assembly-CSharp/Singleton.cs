using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
	public static T Instance;

	protected virtual void Awake()
	{
		if (Instance == null)
		{
			Instance = GetComponent<T>();
		}
		else if (Instance != this)
		{
			Object.Destroy(base.gameObject);
		}
	}

	protected virtual void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}
}
