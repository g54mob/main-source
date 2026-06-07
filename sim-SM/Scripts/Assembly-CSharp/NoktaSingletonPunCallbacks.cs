using Photon.Pun;
using UnityEngine;

public abstract class NoktaSingletonPunCallbacks<T> : MonoBehaviourPunCallbacks where T : MonoBehaviourPunCallbacks
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
}
