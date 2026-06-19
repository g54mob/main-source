using UnityEngine;

public struct GameSettings
{
	public GameLoadType loadType;

	public NetworkType networkType;

	public string address;

	public ushort port;

	public bool allowFriends;

	public string scene;

	public const ushort DEFAULT_PORT = 7777;

	public static bool hasSettings => current.loadType != GameLoadType.None;

	public static GameSettings current { get; private set; }

	public static void Set(GameSettings gameSettings)
	{
		current = gameSettings;
	}

	public static void Clear()
	{
		current = default(GameSettings);
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void Initialize()
	{
		current = default(GameSettings);
	}
}
