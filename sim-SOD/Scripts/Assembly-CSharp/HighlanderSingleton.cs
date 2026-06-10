using UnityEngine;

public abstract class HighlanderSingleton<T> : MonoBehaviour where T : Component
{
	private static T instance;

	public static T Instance => null;

	protected virtual void Awake()
	{
	}

	public void DestroySelf()
	{
	}

	private void OnDestroy()
	{
	}
}
