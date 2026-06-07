using UnityEngine;

public static class OfflineMode
{
	public const bool Enabled = false;

	private const string PlayerIdPrefsKey = "OfflineMode_LocalPlayerId";

	private const string PlayerNamePrefsKey = "OfflineMode_LocalPlayerName";

	private static ulong _cachedPlayerId;

	private static bool _playerIdResolved;

	private static string _cachedPlayerName;

	public static ulong LocalPlayerId => 0uL;

	public static string LocalPlayerName
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void LogOnBoot()
	{
	}

	private static ulong GenerateStableId()
	{
		return 0uL;
	}
}
