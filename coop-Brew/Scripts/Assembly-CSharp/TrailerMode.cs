using UnityEngine;

public static class TrailerMode
{
	private static bool _enabled;

	public static bool Enabled
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public static int MaxPlayers => 0;

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void Initialize()
	{
	}
}
