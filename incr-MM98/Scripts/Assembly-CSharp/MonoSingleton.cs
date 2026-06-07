using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : Component
{
	public static bool HasInstance => Current;

	public static T Current { get; private set; }

	public static T Instance
	{
		get
		{
			if (HasInstance)
			{
				return Current;
			}
			Current = Object.FindAnyObjectByType<T>();
			return Current;
		}
	}

	protected virtual void OnDestroy()
	{
		if (!(Current != this))
		{
			Current = null;
		}
	}
}
