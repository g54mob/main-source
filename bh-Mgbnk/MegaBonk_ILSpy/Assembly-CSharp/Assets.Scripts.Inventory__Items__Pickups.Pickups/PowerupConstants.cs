using System;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Menu.Shop;
using Cpp2ILInjected;

namespace Assets.Scripts.Inventory__Items__Pickups.Pickups;

public class PowerupConstants
{
	public unsafe static float GetTime(EStatusEffect statusEffect)
	{
		//IL_002b: Expected O, but got I4
		//IL_00c1: Expected O, but got Ref
		bool flag = statusEffect == EStatusEffect.Haste;
		if (!flag)
		{
			object obj = statusEffect - 1;
			if (flag || (nint)obj == 1)
			{
				float stat = PlayerStats.GetStat(EStat.PowerupBoostMultiplier);
				return stat * 15f;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002360");
			object obj2 = default(object);
			string text = ((Enum)(&obj2)).ToString();
			string message = "No time defined for status effect: " + text;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			Exception ex = new Exception(message);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
		}
		float stat2 = PlayerStats.GetStat(EStat.PowerupBoostMultiplier);
		return stat2 * 20f;
	}

	public static float GetExplosionRadius()
	{
		float stat = PlayerStats.GetStat(EStat.PowerupBoostMultiplier);
		return stat * 150f;
	}

	public static float GetHasteTime()
	{
		float stat = PlayerStats.GetStat(EStat.PowerupBoostMultiplier);
		return stat * 20f;
	}

	public static float GetHasteMultiplier()
	{
		float stat = PlayerStats.GetStat(EStat.PowerupBoostMultiplier);
		return stat * 1.75f;
	}

	public static float GetRageTime()
	{
		float stat = PlayerStats.GetStat(EStat.PowerupBoostMultiplier);
		return stat * 15f;
	}

	public static float GetRageDamageMultiplier()
	{
		float stat = PlayerStats.GetStat(EStat.PowerupBoostMultiplier);
		return stat * 1.5f;
	}

	public static float GetRageCooldownMultiplier()
	{
		float stat = PlayerStats.GetStat(EStat.PowerupBoostMultiplier);
		return stat + stat;
	}

	public static float GetShieldTime()
	{
		float stat = PlayerStats.GetStat(EStat.PowerupBoostMultiplier);
		return stat * 15f;
	}

	public static float GetStonksTime()
	{
		float stat = PlayerStats.GetStat(EStat.PowerupBoostMultiplier);
		return stat * 15f;
	}

	public static float GetStonksMultiplier()
	{
		float stat = PlayerStats.GetStat(EStat.PowerupBoostMultiplier);
		return stat + stat;
	}

	public static float GetFreezeTime()
	{
		float stat = PlayerStats.GetStat(EStat.PowerupBoostMultiplier);
		return stat * 12f;
	}

	private static float GetMultiplier()
	{
		return PlayerStats.GetStat(EStat.PowerupBoostMultiplier);
	}
}
