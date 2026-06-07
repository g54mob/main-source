using System.Collections.Generic;
using UnityEngine;

public static class DemoMode
{
	private static bool _enabled;

	public static readonly HashSet<string> AllowedTradingNpcIds;

	public static readonly HashSet<string> AllowedQuestNpcIds;

	public const int MaxBarUpgrades = 2;

	public const string AllowedHouseId = "violet";

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

	public static bool IsNpcAllowed(string npcId)
	{
		return false;
	}

	public static bool IsQuestNpcAllowed(string npcId)
	{
		return false;
	}

	public static bool IsHouseAllowed(string houseId)
	{
		return false;
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void Initialize()
	{
	}
}
