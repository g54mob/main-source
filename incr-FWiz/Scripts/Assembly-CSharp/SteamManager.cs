using UnityEngine;

public class SteamManager : MonoBehaviour
{
	public enum AuthenticationState
	{
		Authenticated = 0,
		SteamClosed = 1,
		LoggedOut = 2,
		NoOwnership = 3
	}

	private static SteamManager _instance;

	private static bool _initiated;

	public const uint SteamAPPID = 3868320u;

	public static bool Initiated => false;

	private void Awake()
	{
	}

	public static bool TryInitiateSteam()
	{
		return false;
	}

	public static bool TryAuthenticateOwnership(out AuthenticationState state)
	{
		state = default(AuthenticationState);
		return false;
	}

	private void Update()
	{
	}

	private void OnApplicationQuit()
	{
	}

	public static void ShowSteamPage()
	{
	}

	public static string GetSteamUserID()
	{
		return null;
	}
}
