using UnityEngine;

public class SteamInteractionManager : MonoBehaviour
{
	public static SteamInteractionManager Instance;

	[SerializeField]
	private bool steamInitialized;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		if (SteamManager.Initialized)
		{
			steamInitialized = true;
		}
	}

	public bool IsSteamInitialized()
	{
		return steamInitialized;
	}
}
