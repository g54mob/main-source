using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{
	private static T instance;

	private static bool isApplicationQuit;

	public static T GetStatus => null;

	public static T Instance => null;

	private void OnApplicationQuit()
	{
	}

	public static bool HasInstance()
	{
		return false;
	}

	protected virtual void Awake()
	{
	}
}
