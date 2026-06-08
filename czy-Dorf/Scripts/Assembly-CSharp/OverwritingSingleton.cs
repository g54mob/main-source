using UnityEngine;

public class OverwritingSingleton<T> : MonoBehaviour where T : OverwritingSingleton<T>
{
	public static T Instance;

	protected virtual void Awake()
	{
		Instance = GetComponent<T>();
	}

	protected virtual void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}
}
