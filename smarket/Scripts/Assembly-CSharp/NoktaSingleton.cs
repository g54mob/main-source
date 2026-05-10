using UnityEngine;

public abstract class NoktaSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T _instance;

	private static bool _hasSet;

	private static bool _isQuitting;

	public static T Instance => null;

	private void OnApplicationQuit()
	{
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void ResetStatics()
	{
	}

	protected void InitializeSingleton(bool persistent = true)
	{
	}
}
